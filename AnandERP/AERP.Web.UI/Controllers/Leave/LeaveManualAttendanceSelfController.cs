using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class LeaveManualAttendanceSelfController : BaseController
    {
        ILeaveManualAttendanceBA _ILeaveManualAttendanceBA = null;

        ILeaveManualAttendanceViewModel _LeaveManualAttendanceViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveManualAttendanceSelfController()
        {
            _ILeaveManualAttendanceBA = new LeaveManualAttendanceBA();
            _LeaveManualAttendanceViewModel = new LeaveManualAttendanceViewModel();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Leave/LeaveManualAttendanceSelf/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveManualAttendanceSelf/List.cshtml", _LeaveManualAttendanceViewModel);
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

            List<SelectListItem> AttendenceFor = new List<SelectListItem>();
            AttendenceFor.Add(new SelectListItem { Text = "Both", Value = "B" });
            AttendenceFor.Add(new SelectListItem { Text = "CheckIn Time", Value = "CIT" });
            AttendenceFor.Add(new SelectListItem { Text = "CheckOut Time", Value = "COT" });
            ViewBag.AttendenceFor = new SelectList(AttendenceFor, "Value", "Text");
            return PartialView("/Views/Leave/LeaveManualAttendanceSelf/Create.cshtml", _LeaveManualAttendanceViewModel);
        }

        [HttpPost]
        public ActionResult Create(LeaveManualAttendanceViewModel model)
        {
            try
            {

                if (model != null && model.LeaveManualAttendanceDTO != null)
                {
                    model.LeaveManualAttendanceDTO.ConnectionString = _connectioString;
                    model.LeaveManualAttendanceDTO.EmployeeID = Convert.ToInt32(Session["PersonId"].ToString());
                    model.LeaveManualAttendanceDTO.AttendanceDate = model.AttendanceDate;
                    model.LeaveManualAttendanceDTO.AttendenceFor = model.AttendenceFor;
                    model.LeaveManualAttendanceDTO.CheckInTime = model.CheckInTime;
                    model.LeaveManualAttendanceDTO.CheckOutTime = model.CheckOutTime;
                    model.LeaveManualAttendanceDTO.Reason = model.Reason;
                    model.LeaveManualAttendanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<LeaveManualAttendance> response = _ILeaveManualAttendanceBA.InsertLeaveManualAttendance(model.LeaveManualAttendanceDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.LeaveManualAttendanceDTO.errorMessage = "Salary span is not defined.,#FFCC80,''";
                    }
                    else
                    {
                        model.LeaveManualAttendanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.LeaveManualAttendanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LeaveManualAttendanceViewModel model = new LeaveManualAttendanceViewModel();
            try
            {
                model.LeaveManualAttendanceDTO = new LeaveManualAttendance();
                model.LeaveManualAttendanceDTO.ID = id;
                model.LeaveManualAttendanceDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<LeaveManualAttendance> response = _ILeaveManualAttendanceBA.SelectByID(model.LeaveManualAttendanceDTO);
                if (response != null && response.Entity != null)
                {
                    model.LeaveManualAttendanceDTO.ID                   = response.Entity.ID;
                    model.LeaveManualAttendanceDTO.EmployeeID           = response.Entity.EmployeeID;
                    model.LeaveManualAttendanceDTO.AttendanceDate       = response.Entity.AttendanceDate;
                    model.LeaveManualAttendanceDTO.CheckInTime          = response.Entity.CheckInTime;
                    model.LeaveManualAttendanceDTO.CheckOutTime         = response.Entity.CheckOutTime;
                    model.LeaveManualAttendanceDTO.Reason               = response.Entity.Reason;
                    model.LeaveManualAttendanceDTO.Status               = response.Entity.Status;
                    model.LeaveManualAttendanceDTO.ApprovedByUSerID     = response.Entity.ApprovedByUSerID;
                    model.LeaveManualAttendanceDTO.AttendenceFor        = response.Entity.AttendenceFor;
                    model.LeaveManualAttendanceDTO.IsWorkFlow           = response.Entity.IsWorkFlow;
                    model.LeaveManualAttendanceDTO.CreatedBy            = response.Entity.CreatedBy;

                    List<SelectListItem> AttendenceFor = new List<SelectListItem>();
                    // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
                    AttendenceFor.Add(new SelectListItem { Text = "Both", Value = "B" });
                    AttendenceFor.Add(new SelectListItem { Text = "CheckIn Time", Value = "CIT" });
                    AttendenceFor.Add(new SelectListItem { Text = "CheckOut Time", Value = "COT" });
                    ViewData["AttendenceFor"] = AttendenceFor;
                    ViewData["AttendenceFor"] = new SelectList(AttendenceFor, "Value", "Text", (model.LeaveManualAttendanceDTO.AttendenceFor).ToString().Trim());
                    
                }
                return PartialView("/Views/Leave/LeaveManualAttendanceSelf/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(LeaveManualAttendanceViewModel model)
        {
           
                if (model != null && model.LeaveManualAttendanceDTO != null)
                {
                    if (model != null && model.LeaveManualAttendanceDTO != null)
                    {
                        model.LeaveManualAttendanceDTO.ConnectionString = _connectioString;
                        model.LeaveManualAttendanceDTO.EmployeeID = Convert.ToInt32(Session["PersonId"].ToString());
                        model.LeaveManualAttendanceDTO.AttendanceDate = model.AttendanceDate;
                        model.LeaveManualAttendanceDTO.AttendenceFor = model.AttendenceFor;
                        model.LeaveManualAttendanceDTO.CheckInTime = model.CheckInTime;
                        model.LeaveManualAttendanceDTO.CheckOutTime = model.CheckOutTime;
                        model.LeaveManualAttendanceDTO.Reason = model.Reason;
                       //s model.LeaveManualAttendanceDTO.Status = model.Status;
                      
                        model.LeaveManualAttendanceDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveManualAttendance> response = _ILeaveManualAttendanceBA.UpdateLeaveManualAttendance(model.LeaveManualAttendanceDTO);
                        model.LeaveManualAttendanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                return Json(model.LeaveManualAttendanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<LeaveManualAttendanceViewModel> GetLeaveManualAttendance(out int TotalRecords, int personID, string centreCode)
        {
            LeaveManualAttendanceSearchRequest searchRequest = new LeaveManualAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = personID;
            searchRequest.CentreCode = centreCode;
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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<LeaveManualAttendanceViewModel> listLeaveManualAttendanceViewModel = new List<LeaveManualAttendanceViewModel>();
            List<LeaveManualAttendance> listLeaveManualAttendance = new List<LeaveManualAttendance>();
            IBaseEntityCollectionResponse<LeaveManualAttendance> baseEntityCollectionResponse = _ILeaveManualAttendanceBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveManualAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveManualAttendance item in listLeaveManualAttendance)
                    {
                        LeaveManualAttendanceViewModel leaveManualAttendanceViewModel = new LeaveManualAttendanceViewModel();
                        leaveManualAttendanceViewModel.LeaveManualAttendanceDTO = item;
                        listLeaveManualAttendanceViewModel.Add(leaveManualAttendanceViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveManualAttendanceViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<LeaveManualAttendanceViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.AttendanceDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AttendanceDate Like '%" + param.sSearch + "%' or A.CheckInTime Like '%" + param.sSearch + "%' or A.CheckOutTime Like '%" + param.sSearch + "%' or A.Status Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.CheckInTime";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AttendanceDate Like '%" + param.sSearch + "%' or A.CheckInTime Like '%" + param.sSearch + "%' or A.CheckOutTime Like '%" + param.sSearch + "%' or A.Status Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.CheckOutTime";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AttendanceDate Like '%" + param.sSearch + "%' or A.CheckInTime Like '%" + param.sSearch + "%' or A.CheckOutTime Like '%" + param.sSearch + "%' or A.Status Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.Status";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AttendanceDate Like '%" + param.sSearch + "%' or A.CheckInTime Like '%" + param.sSearch + "%' or A.CheckOutTime Like '%" + param.sSearch + "%' or A.Status Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "A.Reason";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AttendanceDate Like '%" + param.sSearch + "%' or A.CheckInTime Like '%" + param.sSearch + "%' or A.CheckOutTime Like '%" + param.sSearch + "%' or A.Status Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(Session["PersonId"].ToString()))
                {

                    filteredCountryMaster = GetLeaveManualAttendance(out TotalRecords, Convert.ToInt32(Session["PersonId"].ToString()), "0");
                }
                else
                {
                    filteredCountryMaster = new List<LeaveManualAttendanceViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.AttendanceDate.ToString(), c.CheckInTime.ToString(), c.CheckOutTime.ToString(), c.Reason.ToString(), Convert.ToString(c.Status), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);

            }
        }
        #endregion
    }
}