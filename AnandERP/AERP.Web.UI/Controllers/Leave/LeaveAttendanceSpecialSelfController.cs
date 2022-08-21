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
    public class LeaveAttendanceSpecialSelfController : BaseController
    {
        ILeaveAttendanceSpecialRequestBA _ILeaveAttendanceSpecialRequestBA = null;
        ILeaveAttendanceSpecialRequestViewModel _leaveAttendanceSpecialRequestViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveAttendanceSpecialSelfController()
        {
            _ILeaveAttendanceSpecialRequestBA = new LeaveAttendanceSpecialRequestBA();
            _leaveAttendanceSpecialRequestViewModel = new LeaveAttendanceSpecialRequestViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
             return View("/Views/Leave/LeaveAttendanceSpecialRequestSelf/Index.cshtml");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode, string centerCode, string centreName)
        {
            try
            {
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _leaveAttendanceSpecialRequestViewModel.CentreCode = splitCentreCode[0];
                    // _leaveAttendanceSpecialRequestViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _leaveAttendanceSpecialRequestViewModel.CentreCode = centerCode;
                    //_leaveAttendanceSpecialRequestViewModel.EntityLevel = null;
                }
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        _leaveAttendanceSpecialRequestViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _leaveAttendanceSpecialRequestViewModel.EntityLevel = "Centre";

                    foreach (var b in _leaveAttendanceSpecialRequestViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + "Centre";
                    }
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID,0);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _leaveAttendanceSpecialRequestViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _leaveAttendanceSpecialRequestViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _leaveAttendanceSpecialRequestViewModel.CentreCode = centerCode;
                _leaveAttendanceSpecialRequestViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveAttendanceSpecialRequestSelf/List.cshtml", _leaveAttendanceSpecialRequestViewModel);
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
                return View("/Views/Leave/LeaveAttendanceSpecialRequestSelf/Create.cshtml", _leaveAttendanceSpecialRequestViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(LeaveAttendanceSpecialRequestViewModel model)
        {
            try
            {
                 if (model != null && model.LeaveAttendanceSpecialRequestDTO != null)
                {
                    model.LeaveAttendanceSpecialRequestDTO.ConnectionString = _connectioString;
                    model.LeaveAttendanceSpecialRequestDTO.CentreCode = model.CentreCode;
                    model.LeaveAttendanceSpecialRequestDTO.ID = model.ID;
                    model.LeaveAttendanceSpecialRequestDTO.EmployeeID=Convert.ToInt32(Session["PersonID"]);
                    model.LeaveAttendanceSpecialRequestDTO.StatusFlag = model.StatusFlag;
                    model.LeaveAttendanceSpecialRequestDTO.RequestedDate = model.RequestedDate;
                    model.LeaveAttendanceSpecialRequestDTO.CentreCode = model.CentreCode;
                    model.LeaveAttendanceSpecialRequestDTO.Reason = model.Reason;
                    model.LeaveAttendanceSpecialRequestDTO.CommingTime = model.CommingTime;
                    model.LeaveAttendanceSpecialRequestDTO.LeavingTime = model.LeavingTime;
                    model.LeaveAttendanceSpecialRequestDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<LeaveAttendanceSpecialRequest> response = _ILeaveAttendanceSpecialRequestBA.InsertLeaveAttendanceSpecialRequest(model.LeaveAttendanceSpecialRequestDTO);
                    model.LeaveAttendanceSpecialRequestDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.LeaveAttendanceSpecialRequestDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //// Non-Action Methods
        #region Methods
        [HttpPost]
        public JsonResult GetEmployeeCentrewise(string term, string centreCode)
        {
            var data = GetEmployeeCentrewiseSearchList(term, centreCode);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.EmployeeFirstName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<LeaveAttendanceSpecialRequestViewModel> GetLeaveAttendanceSpecialRequestRecords(out int TotalRecords, string CentreCode)
        {
            LeaveAttendanceSpecialRequestSearchRequest searchRequest = new LeaveAttendanceSpecialRequestSearchRequest();
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
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.EmployeeID= Convert.ToInt32(Session["PersonID"]);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = string.Empty;
                searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            }
            List<LeaveAttendanceSpecialRequestViewModel> listLeaveAttendanceSpecialRequestViewModel = new List<LeaveAttendanceSpecialRequestViewModel>();
            List<LeaveAttendanceSpecialRequest> listLeaveAttendanceSpecialRequest = new List<LeaveAttendanceSpecialRequest>();
            IBaseEntityCollectionResponse<LeaveAttendanceSpecialRequest> baseEntityCollectionResponse = _ILeaveAttendanceSpecialRequestBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveAttendanceSpecialRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveAttendanceSpecialRequest item in listLeaveAttendanceSpecialRequest)
                    {
                        LeaveAttendanceSpecialRequestViewModel _leaveAttendanceSpecialRequestViewModel = new LeaveAttendanceSpecialRequestViewModel();
                        _leaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO = item;
                        listLeaveAttendanceSpecialRequestViewModel.Add(_leaveAttendanceSpecialRequestViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveAttendanceSpecialRequestViewModel;
        }

        #endregion

        //// AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveAttendanceSpecialRequestViewModel> filteredLeaveAttendanceSpecialRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = " A.RequestedDate desc,B.EmployeeFirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%'  or A.CommingTime Like '%" + param.sSearch + "%' or A.LeavingTime Like '%" + param.sSearch + "%'or A.Reason Like '%" + param.sSearch + "%'  ";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "A.CommingTime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%'  or A.CommingTime Like '%" + param.sSearch + "%' or A.LeavingTime Like '%" + param.sSearch + "%'or A.Reason Like '%" + param.sSearch + "%'  ";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "A.LeavingTime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%'  or A.CommingTime Like '%" + param.sSearch + "%' or A.LeavingTime Like '%" + param.sSearch + "%'or A.Reason Like '%" + param.sSearch + "%'  ";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredLeaveAttendanceSpecialRequest = GetLeaveAttendanceSpecialRequestRecords(out TotalRecords, string.Empty);
            var records = filteredLeaveAttendanceSpecialRequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveAttendanceSpecialRequestDTO.EmployeeName), Convert.ToString(c.LeaveAttendanceSpecialRequestDTO.RequestedDate), Convert.ToString(c.LeaveAttendanceSpecialRequestDTO.CommingTime), Convert.ToString(c.LeaveAttendanceSpecialRequestDTO.LeavingTime), Convert.ToString(c.LeaveAttendanceSpecialRequestDTO.Reason), Convert.ToString(c.LeaveAttendanceSpecialRequestDTO.ID), Convert.ToString(c.LeaveAttendanceSpecialRequestDTO.ApprovalStatus),Convert.ToString(c.LeaveAttendanceSpecialRequestDTO.StatusFlag)};
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


