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
    public class LeaveMasterController : BaseController
    {
        ILeaveMasterBA _ILeaveMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveMasterController()
        {
            _ILeaveMasterBA = new LeaveMasterBA();
        }

        //  Controller Methods
        #region ------------------Controller Methods------------------

        public ActionResult Index()
        {
            
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0)
            {
                return View("/Views/Leave/LeaveMaster/Index.cshtml");
            }
            else
            {
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                if (listAdminRoleApplicableDetails.Count > 0)
                {
                    return View("/Views/Leave/LeaveMaster/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }    
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                ILeaveMasterViewModel _leaveMasterViewModel = new LeaveMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveMaster/List.cshtml", _leaveMasterViewModel);
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
                ILeaveMasterViewModel _leaveMasterViewModel = new LeaveMasterViewModel();

                //For Leave Type
                List<SelectListItem> LeaveMaster_LeaveType = new List<SelectListItem>();
                ViewBag.LeaveMaster_LeaveType = new SelectList(LeaveMaster_LeaveType, "Value", "Text");
                List<SelectListItem> li_LeaveMaster_LeaveType = new List<SelectListItem>();
                //li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "---Select Category---",Value="" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "Leave Without Pay", Value = "LeaveWithoutPay" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "OutDoor", Value = "OutDoor" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "Vacations", Value = "Vacations" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "Regular", Value = "Regular" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "C-Off", Value = "C-Off" });
                ViewData["LeaveType"] = li_LeaveMaster_LeaveType;
                _leaveMasterViewModel.LeaveType = " ";

                return View("/Views/Leave/LeaveMaster/Create.cshtml", _leaveMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(LeaveMasterViewModel _leaveMasterViewModel)
        {
            try
            {
                _leaveMasterViewModel.LeaveMasterDTO.LeaveDescription = _leaveMasterViewModel.LeaveDescription;
                _leaveMasterViewModel.LeaveMasterDTO.LeaveCode = _leaveMasterViewModel.LeaveCode;
                _leaveMasterViewModel.LeaveMasterDTO.LeaveType = _leaveMasterViewModel.LeaveType;
                _leaveMasterViewModel.LeaveMasterDTO.IsCarryForwardForNextYear = _leaveMasterViewModel.IsCarryForwardForNextYear;
                _leaveMasterViewModel.LeaveMasterDTO.MinServiceRequire = _leaveMasterViewModel.MinServiceRequire;
                //_leaveMasterViewModel.LeaveMasterDTO.HalfDayFlag = _leaveMasterViewModel.HalfDayFlag;
                _leaveMasterViewModel.LeaveMasterDTO.DocumentsNeeded = _leaveMasterViewModel.DocumentsNeeded;
                //_leaveMasterViewModel.LeaveMasterDTO.AttendanceNeeded = _leaveMasterViewModel.AttendanceNeeded;
                _leaveMasterViewModel.LeaveMasterDTO.LossOfPay = _leaveMasterViewModel.LossOfPay;
                //_leaveMasterViewModel.LeaveMasterDTO.NoCredit = _leaveMasterViewModel.NoCredit;
                _leaveMasterViewModel.LeaveMasterDTO.IsEnCash = _leaveMasterViewModel.IsEnCash;
                //_leaveMasterViewModel.LeaveMasterDTO.OnDuty = _leaveMasterViewModel.OnDuty;
                _leaveMasterViewModel.LeaveMasterDTO.NeedToInformInAdvance = _leaveMasterViewModel.NeedToInformInAdvance;
                _leaveMasterViewModel.LeaveMasterDTO.IsPostedOnce = _leaveMasterViewModel.IsPostedOnce;
                _leaveMasterViewModel.LeaveMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                _leaveMasterViewModel.LeaveMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<LeaveMaster> response = _ILeaveMasterBA.InsertLeaveMaster(_leaveMasterViewModel.LeaveMasterDTO);
                _leaveMasterViewModel.LeaveMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(_leaveMasterViewModel.LeaveMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + _leaveMasterViewModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ILeaveMasterViewModel _leaveMasterViewModel = new LeaveMasterViewModel();
            try
            {

                //For Leave Type
                List<SelectListItem> LeaveMaster_LeaveType = new List<SelectListItem>();
                ViewBag.LeaveMaster_LeaveType = new SelectList(LeaveMaster_LeaveType, "Value", "Text");
                List<SelectListItem> li_LeaveMaster_LeaveType = new List<SelectListItem>();
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "-- Select Leave Type -- ", Value = " " });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "Leave Without Pay", Value = "LeaveWithoutPay" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "OutDoor", Value = "OutDoor" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "Vacations", Value = "Vacations" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "Regular", Value = "Regular" });
                li_LeaveMaster_LeaveType.Add(new SelectListItem { Text = "C-Off", Value = "C-Off" });
               
               

               _leaveMasterViewModel.LeaveMasterDTO = new LeaveMaster();
               _leaveMasterViewModel.LeaveMasterDTO.ID = id;
               _leaveMasterViewModel.LeaveMasterDTO.ConnectionString = _connectioString;

               IBaseEntityResponse<LeaveMaster> response = _ILeaveMasterBA.SelectByID(_leaveMasterViewModel.LeaveMasterDTO);
                if (response != null && response.Entity != null)
                {
                   _leaveMasterViewModel.LeaveMasterDTO.ID = response.Entity.ID;
                   _leaveMasterViewModel.LeaveMasterDTO.LeaveDescription = response.Entity.LeaveDescription;
                   _leaveMasterViewModel.LeaveMasterDTO.LeaveCode = response.Entity.LeaveCode;                
                   _leaveMasterViewModel.LeaveMasterDTO.IsCarryForwardForNextYear = response.Entity.IsCarryForwardForNextYear;
                   _leaveMasterViewModel.LeaveMasterDTO.MinServiceRequire = response.Entity.MinServiceRequire;
                   //_leaveMasterViewModel.LeaveMasterDTO.HalfDayFlag = response.Entity.HalfDayFlag;
                   _leaveMasterViewModel.LeaveMasterDTO.DocumentsNeeded = response.Entity.DocumentsNeeded; 
                   //_leaveMasterViewModel.LeaveMasterDTO.AttendanceNeeded = response.Entity.AttendanceNeeded;
                   _leaveMasterViewModel.LeaveMasterDTO.LossOfPay = response.Entity.LossOfPay;
                  // _leaveMasterViewModel.LeaveMasterDTO.NoCredit = response.Entity.NoCredit;
                   _leaveMasterViewModel.LeaveMasterDTO.IsEnCash = response.Entity.IsEnCash;
                    // _leaveMasterViewModel.LeaveMasterDTO.OnDuty = response.Entity.OnDuty;
                    _leaveMasterViewModel.LeaveMasterDTO.NeedToInformInAdvance = response.Entity.NeedToInformInAdvance;
                    _leaveMasterViewModel.LeaveMasterDTO.IsPostedOnce = response.Entity.IsPostedOnce;
                   ViewData["LeaveType"] = new SelectList(li_LeaveMaster_LeaveType, "Value", "Text", response.Entity.LeaveType);

                }
                return View("/Views/Leave/LeaveMaster/Edit.cshtml", _leaveMasterViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(LeaveMasterViewModel _leaveMasterViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_leaveMasterViewModel != null &&_leaveMasterViewModel.LeaveMasterDTO != null)
                {
                    if (_leaveMasterViewModel != null &&_leaveMasterViewModel.LeaveMasterDTO != null)
                    {
                        _leaveMasterViewModel.LeaveMasterDTO.LeaveDescription = _leaveMasterViewModel.LeaveDescription;
                        _leaveMasterViewModel.LeaveMasterDTO.LeaveCode = _leaveMasterViewModel.LeaveCode;
                        _leaveMasterViewModel.LeaveMasterDTO.LeaveType = _leaveMasterViewModel.LeaveType;
                        _leaveMasterViewModel.LeaveMasterDTO.IsCarryForwardForNextYear = _leaveMasterViewModel.IsCarryForwardForNextYear;
                        _leaveMasterViewModel.LeaveMasterDTO.MinServiceRequire = _leaveMasterViewModel.MinServiceRequire;
                        _leaveMasterViewModel.LeaveMasterDTO.HalfDayFlag = _leaveMasterViewModel.HalfDayFlag;
                        _leaveMasterViewModel.LeaveMasterDTO.DocumentsNeeded = _leaveMasterViewModel.DocumentsNeeded;
                        _leaveMasterViewModel.LeaveMasterDTO.AttendanceNeeded = _leaveMasterViewModel.AttendanceNeeded;
                        _leaveMasterViewModel.LeaveMasterDTO.LossOfPay = _leaveMasterViewModel.LossOfPay;
                        _leaveMasterViewModel.LeaveMasterDTO.NoCredit = _leaveMasterViewModel.NoCredit;
                        _leaveMasterViewModel.LeaveMasterDTO.IsEnCash = _leaveMasterViewModel.IsEnCash;
                        _leaveMasterViewModel.LeaveMasterDTO.OnDuty = _leaveMasterViewModel.OnDuty;
                        _leaveMasterViewModel.LeaveMasterDTO.IsPostedOnce = _leaveMasterViewModel.IsPostedOnce;
                        _leaveMasterViewModel.LeaveMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        _leaveMasterViewModel.LeaveMasterDTO.ConnectionString = _connectioString;

                        IBaseEntityResponse<LeaveMaster> response = _ILeaveMasterBA.UpdateLeaveMaster(_leaveMasterViewModel.LeaveMasterDTO);
                       _leaveMasterViewModel.LeaveMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(_leaveMasterViewModel.LeaveMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }


        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    ILeaveMasterViewModel _leaveMasterViewModel = new LeaveMasterViewModel();
        //    _leaveMasterViewModel.LeaveMasterDTO = new LeaveMaster();
        //    _leaveMasterViewModel.LeaveMasterDTO.ID = ID;
        //    return PartialView("/Views/Leave/LeaveMaster/Delete.cshtml", _leaveMasterViewModel);
        //}

        //[HttpPost]
        //public ActionResult Delete(LeaveMasterViewModel _leaveMasterViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (_leaveMasterViewModel.ID > 0)
        //        {
        //            LeaveMaster LeaveMasterDTO = new LeaveMaster();
        //            LeaveMasterDTO.ConnectionString = _connectioString;
        //            LeaveMasterDTO.ID = _leaveMasterViewModel.ID;
        //            LeaveMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<LeaveMaster> response = _leaveMasterServiceAccess.DeleteLeaveMaster(LeaveMasterDTO);
        //            _leaveMasterViewModel.LeaveMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(_leaveMasterViewModel.LeaveMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            LeaveMasterViewModel _leaveMasterViewModel = new LeaveMasterViewModel();
            //if (!ModelState.IsValid)
            //{
                if (ID!= null)
                {
                    LeaveMaster LeaveMasterDTO = new LeaveMaster();
                    LeaveMasterDTO.ConnectionString = _connectioString;
                    LeaveMasterDTO.ID = ID;
                    LeaveMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<LeaveMaster> response = _ILeaveMasterBA.DeleteLeaveMaster(LeaveMasterDTO);
                    //_leaveMasterViewModel.LeaveMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    _leaveMasterViewModel.LeaveMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(_leaveMasterViewModel.LeaveMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        #endregion

        // Non-Action Method
        #region ---------------------Methods-ddd----------------------

        public IEnumerable<LeaveMasterViewModel> GetLeaveMaster(out int TotalRecords)
        {
            LeaveMasterSearchRequest searchRequest = new LeaveMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
           
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<LeaveMasterViewModel> listEmployeeExperienceViewModel = new List<LeaveMasterViewModel>();
            List<LeaveMaster> listEmployeeExperience = new List<LeaveMaster>();
            IBaseEntityCollectionResponse<LeaveMaster> baseEntityCollectionResponse = _ILeaveMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeExperience = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveMaster item in listEmployeeExperience)
                    {
                        LeaveMasterViewModel EmployeeExperienceViewModel = new LeaveMasterViewModel();
                        EmployeeExperienceViewModel.LeaveMasterDTO = item;
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

            IEnumerable<LeaveMasterViewModel> filteredLeaveMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LeaveDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveCode Like '%" + param.sSearch + "%' or LeaveType Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "LeaveCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveCode Like '%" + param.sSearch + "%' or LeaveType Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "LeaveType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveCode Like '%" + param.sSearch + "%' or LeaveType Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredLeaveMaster = GetLeaveMaster(out TotalRecords);
            var records = filteredLeaveMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveDescription), Convert.ToString(c.LeaveCode), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}
