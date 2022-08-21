using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using AERP.Common;
using AERP.DataProvider;
using System.Configuration;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class LeaveCompensatoryWorkDayController : BaseController
    {
        ILeaveCompensatoryWorkDayBA _ILeaveCompensatoryWorkDayBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveCompensatoryWorkDayController()
        {
            _ILeaveCompensatoryWorkDayBA = new LeaveCompensatoryWorkDayBA();
        }

        //  Controller Methods
        #region ------------------Controller Methods------------------

        public ActionResult Index()
        {
            return View("/Views/Leave/LeaveCompensatoryWorkDay/Index.cshtml");
        }


        public ActionResult List(string actionMode)
        {
            try
            {
                ILeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel = new LeaveCompensatoryWorkDayViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveCompensatoryWorkDay/List.cshtml", _LeaveCompensatoryWorkDayViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                ILeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel = new LeaveCompensatoryWorkDayViewModel();
                _LeaveCompensatoryWorkDayViewModel.EmployeeID = Convert.ToInt32(Session["PersonID"]);


                List<GeneralHolidays> GeneralHolidaysList = GetListGeneralWeeklyOffAndHoliday(_LeaveCompensatoryWorkDayViewModel.EmployeeID);
                List<SelectListItem> generalHolidays = new List<SelectListItem>();
                Dictionary<String, Dictionary<String, TimeSpan>> CheckInCheckOutTimeList = new Dictionary<String, Dictionary<String, TimeSpan>>();

                foreach (GeneralHolidays item in GeneralHolidaysList)
                {
                    generalHolidays.Add(new SelectListItem { Text = item.Date + " - " + item.Description, Value = (item.Date).ToString().Trim() });
                    Dictionary<String, TimeSpan> CheckInCheckOutTime = new Dictionary<String, TimeSpan>();
                    CheckInCheckOutTime.Add("CheckIn",item.CheckInTime);
                    CheckInCheckOutTime.Add("CheckOut",item.CheckOutTime);
                    CheckInCheckOutTimeList.Add(item.Date + " - " + item.Description, CheckInCheckOutTime);
                }
                ViewBag.GeneralHolidays = new SelectList(generalHolidays, "Value", "Text");
                ViewBag.CheckInCheckOutTimeList = CheckInCheckOutTimeList;


                return View("/Views/Leave/LeaveCompensatoryWorkDay/Create.cshtml", _LeaveCompensatoryWorkDayViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(LeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel)
        {
            try
            {
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingDate = _LeaveCompensatoryWorkDayViewModel.WorkingDate;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckInTime = _LeaveCompensatoryWorkDayViewModel.CheckInTime;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckOutTime = _LeaveCompensatoryWorkDayViewModel.CheckOutTime;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingReason = _LeaveCompensatoryWorkDayViewModel.WorkingReason;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = _LeaveCompensatoryWorkDayViewModel.EmployeeID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.IsHalfDayUtilized = _LeaveCompensatoryWorkDayViewModel.IsHalfDayUtilized;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.InsertLeaveCompensatoryWorkDay(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + _LeaveCompensatoryWorkDayViewModel);
        }

        [HttpGet]
        public ActionResult GetPunchTime(string Date)
        {
            try
            {
                ILeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel = new LeaveCompensatoryWorkDayViewModel();
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingDate = Date;

                var department = GetListCheckInCheckOutTime(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
                var result = (from s in department
                              select new
                              {
                                  CheckInTime =  Convert.ToString(s.CheckInTime),
                                  CheckOutTime = Convert.ToString(s.CheckOutTime),
                              }).ToList();


                // BaseEntityCollectionResponse<GeneralHolidays> GeneralHolidaysList = GetListGeneralWeeklyOffAndHoliday(_LeaveCompensatoryWorkDayViewModel.EmployeeID);

                return Json(result, JsonRequestBehavior.AllowGet);
                //return View("/Views/Leave/LeaveCompensatoryWorkDay/Create.cshtml", _LeaveCompensatoryWorkDayViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ILeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel = new LeaveCompensatoryWorkDayViewModel();
            try
            {
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO = new LeaveCompensatoryWorkDay();
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = id;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;

                _LeaveCompensatoryWorkDayViewModel.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                List<GeneralHolidays> GeneralHolidaysList = GetListGeneralWeeklyOffAndHoliday(_LeaveCompensatoryWorkDayViewModel.EmployeeID);
                List<SelectListItem> generalHolidays = new List<SelectListItem>();
                foreach (GeneralHolidays item in GeneralHolidaysList)
                {
                    generalHolidays.Add(new SelectListItem { Text = item.Date + " - " + item.Description, Value = (item.Date).ToString().Trim() });
                }
                IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.SelectByID(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
                if (response != null && response.Entity != null)
                {
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = response.Entity.ID;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = response.Entity.EmployeeID;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingDate = response.Entity.WorkingDate;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckInTime = response.Entity.CheckInTime;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckOutTime = response.Entity.CheckOutTime;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingReason = response.Entity.WorkingReason;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.IsHalfDayUtilized = response.Entity.IsHalfDayUtilized;
                    ViewBag.GeneralHolidays = new SelectList(generalHolidays, "Value", "Text", _LeaveCompensatoryWorkDayViewModel.WorkingDate.Trim());
                }
                return View("/Views/Leave/LeaveCompensatoryWorkDay/Edit.cshtml", _LeaveCompensatoryWorkDayViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(LeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel)
        {
            //if (ModelState.IsValid)
            //{
            if (_LeaveCompensatoryWorkDayViewModel != null && _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO != null)
            {
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = _LeaveCompensatoryWorkDayViewModel.ID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingDate = _LeaveCompensatoryWorkDayViewModel.WorkingDate;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckInTime = _LeaveCompensatoryWorkDayViewModel.CheckInTime;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckOutTime = _LeaveCompensatoryWorkDayViewModel.CheckOutTime;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingReason = _LeaveCompensatoryWorkDayViewModel.WorkingReason;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = _LeaveCompensatoryWorkDayViewModel.EmployeeID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.IsHalfDayUtilized = _LeaveCompensatoryWorkDayViewModel.IsHalfDayUtilized;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.UpdateLeaveCompensatoryWorkDay(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(Resources.DisplayMessage_PleaseReviewYourForm);
            }
            //   }

        }


        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    ILeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel = new LeaveCompensatoryWorkDayViewModel();
        //    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO = new LeaveCompensatoryWorkDay();
        //    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = ID;
        //    return PartialView("/Views/Leave/LeaveCompensatoryWorkDay/Delete.cshtml", _LeaveCompensatoryWorkDayViewModel);
        //}

        //[HttpPost]
        //public ActionResult Delete(LeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (_LeaveCompensatoryWorkDayViewModel.ID > 0)
        //        {
        //            LeaveCompensatoryWorkDay LeaveCompensatoryWorkDayDTO = new LeaveCompensatoryWorkDay();
        //            LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;
        //            LeaveCompensatoryWorkDayDTO.ID = _LeaveCompensatoryWorkDayViewModel.ID;
        //            LeaveCompensatoryWorkDayDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _LeaveCompensatoryWorkDayServiceAccess.DeleteLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDayDTO);
        //            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            try { 
                LeaveCompensatoryWorkDayViewModel model = new LeaveCompensatoryWorkDayViewModel();
                if (ID > 0)
                {
                    LeaveCompensatoryWorkDay LeaveCompensatoryWorkDayDTO = new LeaveCompensatoryWorkDay();
                    LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;
                    LeaveCompensatoryWorkDayDTO.ID = ID;
                    LeaveCompensatoryWorkDayDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.DeleteLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDayDTO);
                    //_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    model.LeaveCompensatoryWorkDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                }
                return Json(model.LeaveCompensatoryWorkDayDTO.errorMessage, JsonRequestBehavior.AllowGet);
                
            }catch(Exception ex){
                    _logException.Error(ex.Message);
                    throw;
                
            }
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            ILeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel = new LeaveCompensatoryWorkDayViewModel();
            try
            {
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO = new LeaveCompensatoryWorkDay();
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = id;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;

                _LeaveCompensatoryWorkDayViewModel.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                List<GeneralHolidays> GeneralHolidaysList = GetListGeneralWeeklyOffAndHoliday(_LeaveCompensatoryWorkDayViewModel.EmployeeID);
                List<SelectListItem> generalHolidays = new List<SelectListItem>();
                foreach (GeneralHolidays item in GeneralHolidaysList)
                {
                    generalHolidays.Add(new SelectListItem { Text = item.Date + " - " + item.Description, Value = (item.Date).ToString().Trim() });
                }
                IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.SelectByID(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
                if (response != null && response.Entity != null)
                {
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = response.Entity.ID;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = response.Entity.EmployeeID;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingDate = response.Entity.WorkingDate;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckInTime = response.Entity.CheckInTime;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckOutTime = response.Entity.CheckOutTime;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingReason = response.Entity.WorkingReason;
                    _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.IsHalfDayUtilized = response.Entity.IsHalfDayUtilized;
                    ViewBag.GeneralHolidays = new SelectList(generalHolidays, "Value", "Text", _LeaveCompensatoryWorkDayViewModel.WorkingDate.Trim());
                }
                return View("/Views/Leave/LeaveCompensatoryWorkDay/View.cshtml", _LeaveCompensatoryWorkDayViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult RequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            ILeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel = new LeaveCompensatoryWorkDayViewModel();
            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO = new LeaveCompensatoryWorkDay();
            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = PersonID;
            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.TaskNotificationMasterID = Convert.ToInt32(TNMID);

            _LeaveCompensatoryWorkDayViewModel.PersonID = Convert.ToInt32(PersonID);
            _LeaveCompensatoryWorkDayViewModel.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            _LeaveCompensatoryWorkDayViewModel.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            _LeaveCompensatoryWorkDayViewModel.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            _LeaveCompensatoryWorkDayViewModel.TaskCode = TaskCode;
            _LeaveCompensatoryWorkDayViewModel.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            _LeaveCompensatoryWorkDayViewModel.IsLastRecord = Convert.ToBoolean(IsLast);

            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.GetCompensatoryOffDayApplicationDetailsByID(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
            if (response != null && response.Entity != null)
            {
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = response.Entity.ID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = response.Entity.EmployeeID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingDate = response.Entity.WorkingDate;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckInTime = response.Entity.CheckInTime;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckOutTime = response.Entity.CheckOutTime;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingReason = response.Entity.WorkingReason;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ApplicationStatus = response.Entity.ApplicationStatus;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.LeaveSessionID = response.Entity.LeaveSessionID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CentreCode = response.Entity.CentreCode;
            }
            return View("/Views/Leave/LeaveCompensatoryWorkDay/RequestApproval.cshtml", _LeaveCompensatoryWorkDayViewModel);
        }

        [HttpGet]
        public ActionResult RequestApprovalV2(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            ILeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel = new LeaveCompensatoryWorkDayViewModel();
            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO = new LeaveCompensatoryWorkDay();
            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = PersonID;
            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.TaskNotificationMasterID = Convert.ToInt32(TNMID);

            _LeaveCompensatoryWorkDayViewModel.PersonID = Convert.ToInt32(PersonID);
            _LeaveCompensatoryWorkDayViewModel.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            _LeaveCompensatoryWorkDayViewModel.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            _LeaveCompensatoryWorkDayViewModel.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            _LeaveCompensatoryWorkDayViewModel.TaskCode = TaskCode;
            _LeaveCompensatoryWorkDayViewModel.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            _LeaveCompensatoryWorkDayViewModel.IsLastRecord = Convert.ToBoolean(IsLast);

            _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.GetCompensatoryOffDayApplicationDetailsByID(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
            if (response != null && response.Entity != null)
            {
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = response.Entity.ID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = response.Entity.EmployeeID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingDate = response.Entity.WorkingDate;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckInTime = response.Entity.CheckInTime;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CheckOutTime = response.Entity.CheckOutTime;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.WorkingReason = response.Entity.WorkingReason;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.IsHalfDayUtilized = response.Entity.IsHalfDayUtilized;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ApplicationStatus = response.Entity.ApplicationStatus;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.LeaveSessionID = response.Entity.LeaveSessionID;
                _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CentreCode = response.Entity.CentreCode;
            }
            return View("/Views/Leave/LeaveCompensatoryWorkDay/RequestApprovalV2.cshtml", _LeaveCompensatoryWorkDayViewModel);
        }

        [HttpPost]
        public ActionResult RequestApproval(LeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_LeaveCompensatoryWorkDayViewModel != null && _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO != null)
                    {
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = _LeaveCompensatoryWorkDayViewModel.ID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = _LeaveCompensatoryWorkDayViewModel.PersonID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.IsLastRecord = Convert.ToBoolean(_LeaveCompensatoryWorkDayViewModel.IsLastRecord);
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.TaskNotificationMasterID = _LeaveCompensatoryWorkDayViewModel.TaskNotificationMasterID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.TaskNotificationDetailsID = _LeaveCompensatoryWorkDayViewModel.TaskNotificationDetailsID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.GeneralTaskReportingDetailsID = _LeaveCompensatoryWorkDayViewModel.GeneralTaskReportingDetailsID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.StageSequenceNumber = _LeaveCompensatoryWorkDayViewModel.StageSequenceNumber;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ApplicationStatus = _LeaveCompensatoryWorkDayViewModel.ApplicationStatus;

                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ApprovalStatus = _LeaveCompensatoryWorkDayViewModel.ApprovalStatus;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.LeaveSessionID = _LeaveCompensatoryWorkDayViewModel.LeaveSessionID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CentreCode = _LeaveCompensatoryWorkDayViewModel.CentreCode;


                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.InsertApprovedCompensatoryWorkDayRecord(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult RequestApprovalV2(LeaveCompensatoryWorkDayViewModel _LeaveCompensatoryWorkDayViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_LeaveCompensatoryWorkDayViewModel != null && _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO != null)
                    {
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ConnectionString = _connectioString;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ID = _LeaveCompensatoryWorkDayViewModel.ID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.EmployeeID = _LeaveCompensatoryWorkDayViewModel.PersonID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.IsLastRecord = Convert.ToBoolean(_LeaveCompensatoryWorkDayViewModel.IsLastRecord);
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.TaskNotificationMasterID = _LeaveCompensatoryWorkDayViewModel.TaskNotificationMasterID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.TaskNotificationDetailsID = _LeaveCompensatoryWorkDayViewModel.TaskNotificationDetailsID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.GeneralTaskReportingDetailsID = _LeaveCompensatoryWorkDayViewModel.GeneralTaskReportingDetailsID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.StageSequenceNumber = _LeaveCompensatoryWorkDayViewModel.StageSequenceNumber;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ApplicationStatus = _LeaveCompensatoryWorkDayViewModel.ApplicationStatus;

                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.ApprovalStatus = _LeaveCompensatoryWorkDayViewModel.ApprovalStatus;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.LeaveSessionID = _LeaveCompensatoryWorkDayViewModel.LeaveSessionID;
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CentreCode = _LeaveCompensatoryWorkDayViewModel.CentreCode;


                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveCompensatoryWorkDay> response = _ILeaveCompensatoryWorkDayBA.InsertApprovedCompensatoryWorkDayRecord(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO);
                        _LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(_LeaveCompensatoryWorkDayViewModel.LeaveCompensatoryWorkDayDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        // Non-Action Method
        #region ---------------------Methods-ddd----------------------

        public TimeSpan timeFormat(TimeSpan time)
        {
            var result = TimeSpan.Parse("0:00:00");
            var splitedTime = Convert.ToString(time).Split(':');
            int hours = Convert.ToInt32(splitedTime[0]);
            int min = Convert.ToInt32(splitedTime[1]);
            if (hours < 12)
            {
                result = TimeSpan.Parse(hours + ':' + min + ':' + "00");
            }
            else
            {
                hours = hours - 12;
                hours = Convert.ToInt32((Convert.ToString(hours).Length < 10) ? "00" + Convert.ToString(hours) : Convert.ToString(hours));
                result = TimeSpan.Parse(hours + ':' + min + "PM");
            }
            return result;
        }

        public IEnumerable<LeaveCompensatoryWorkDayViewModel> GetLeaveCompensatoryWorkDay(int EmployeeID, out int TotalRecords)
        {
            LeaveCompensatoryWorkDaySearchRequest searchRequest = new LeaveCompensatoryWorkDaySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = Convert.ToInt32(EmployeeID);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = Convert.ToInt32(EmployeeID);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = Convert.ToInt32(EmployeeID);
            }
            List<LeaveCompensatoryWorkDayViewModel> listEmployeeExperienceViewModel = new List<LeaveCompensatoryWorkDayViewModel>();
            List<LeaveCompensatoryWorkDay> listEmployeeExperience = new List<LeaveCompensatoryWorkDay>();
            IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> baseEntityCollectionResponse = _ILeaveCompensatoryWorkDayBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeExperience = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveCompensatoryWorkDay item in listEmployeeExperience)
                    {
                        LeaveCompensatoryWorkDayViewModel EmployeeExperienceViewModel = new LeaveCompensatoryWorkDayViewModel();
                        EmployeeExperienceViewModel.LeaveCompensatoryWorkDayDTO = item;
                        listEmployeeExperienceViewModel.Add(EmployeeExperienceViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeExperienceViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region ----------------------AjaxHandler---------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveCompensatoryWorkDayViewModel> filteredLeaveCompensatoryWorkDay;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApplicationStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.ApplicationStatus";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApplicationStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredLeaveCompensatoryWorkDay = GetLeaveCompensatoryWorkDay(Convert.ToInt32(Session["PersonID"]), out TotalRecords);
            var records = filteredLeaveCompensatoryWorkDay.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.WorkingDate), Convert.ToString(c.CheckInTime), Convert.ToString(c.CheckOutTime), Convert.ToString(c.ApplicationStatus), Convert.ToString(c.WorkingReason), Convert.ToString(c.ID), Convert.ToString(c.IsAvailed) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}
