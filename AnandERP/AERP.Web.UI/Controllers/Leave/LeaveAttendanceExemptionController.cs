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
    public class LeaveAttendanceExemptionController : BaseController
    {
        ILeaveAttendanceExemptionBA _ILeaveAttendanceExemptionBA = null;
        ILeaveAttendanceExemptionViewModel _leaveAttendanceExemptionViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveAttendanceExemptionController()
        {
            _ILeaveAttendanceExemptionBA = new LeaveAttendanceExemptionBA();
            _leaveAttendanceExemptionViewModel = new LeaveAttendanceExemptionViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeaveAttendanceExemption/Index.cshtml");
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
                    if (listAdminRoleApplicableDetails.Count > 0)
                    {
                        return View("/Views/Leave/LeaveAttendanceExemption/Index.cshtml");
                    }
                    else
                    {
                        return RedirectToAction("UnauthorizedAccess", "Home");
                    }
                }
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
                    _leaveAttendanceExemptionViewModel.CentreCode = splitCentreCode[0];
                    // _leaveAttendanceExemptionViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _leaveAttendanceExemptionViewModel.CentreCode = centerCode;
                    //_leaveAttendanceExemptionViewModel.EntityLevel = null;
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
                        _leaveAttendanceExemptionViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _leaveAttendanceExemptionViewModel.EntityLevel = "Centre";

                    foreach (var b in _leaveAttendanceExemptionViewModel.ListGetAdminRoleApplicableCentre)
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
                        _leaveAttendanceExemptionViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _leaveAttendanceExemptionViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _leaveAttendanceExemptionViewModel.CentreCode = centerCode;
                _leaveAttendanceExemptionViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveAttendanceExemption/List.cshtml", _leaveAttendanceExemptionViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Action(int ID)
        {
            try
            {
                if (ID > 0) // for edit
                {
                    _leaveAttendanceExemptionViewModel.LeaveAttendanceExemptionDTO = new LeaveAttendanceExemption();
                    _leaveAttendanceExemptionViewModel.LeaveAttendanceExemptionDTO.ID = ID;
                    _leaveAttendanceExemptionViewModel.LeaveAttendanceExemptionDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<LeaveAttendanceExemption> response = _ILeaveAttendanceExemptionBA.SelectByID(_leaveAttendanceExemptionViewModel.LeaveAttendanceExemptionDTO);
                    if (response != null && response.Entity != null)
                    {
                        _leaveAttendanceExemptionViewModel.ID = response.Entity.ID;
                        _leaveAttendanceExemptionViewModel.EmployeeId = response.Entity.EmployeeId;
                        _leaveAttendanceExemptionViewModel.EmployeeName = response.Entity.EmployeeName;
                        _leaveAttendanceExemptionViewModel.ExemptionFromDate = response.Entity.ExemptionFromDate;
                        _leaveAttendanceExemptionViewModel.ExemptionUpToDate = response.Entity.ExemptionUpToDate;
                        _leaveAttendanceExemptionViewModel.CentreCode = response.Entity.CentreCode;
                    }
                }
                return View("/Views/Leave/LeaveAttendanceExemption/Action.cshtml", _leaveAttendanceExemptionViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Action(LeaveAttendanceExemptionViewModel model)
        {
            try
            {
                if (model != null && model.LeaveAttendanceExemptionDTO != null && model.ID > 0) // for edit
                {
                    model.LeaveAttendanceExemptionDTO.ConnectionString = _connectioString;
                    model.LeaveAttendanceExemptionDTO.CentreCode = model.CentreCode;
                    model.LeaveAttendanceExemptionDTO.ID = model.ID;
                    model.LeaveAttendanceExemptionDTO.EmployeeId = model.EmployeeId;
                    model.LeaveAttendanceExemptionDTO.ExemptionFromDate = model.ExemptionFromDate;
                    model.LeaveAttendanceExemptionDTO.ExemptionUpToDate = model.ExemptionUpToDate;
                    model.LeaveAttendanceExemptionDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<LeaveAttendanceExemption> response = _ILeaveAttendanceExemptionBA.UpdateLeaveAttendanceExemption(model.LeaveAttendanceExemptionDTO);
                    model.LeaveAttendanceExemptionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    return Json(model.LeaveAttendanceExemptionDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else if (model != null && model.LeaveAttendanceExemptionDTO != null && model.ID == 0) // for create
                {
                    model.LeaveAttendanceExemptionDTO.ConnectionString = _connectioString;
                    model.LeaveAttendanceExemptionDTO.CentreCode = model.CentreCode;
                    model.LeaveAttendanceExemptionDTO.ID = model.ID;
                    model.LeaveAttendanceExemptionDTO.EmployeeId = model.EmployeeId;
                    model.LeaveAttendanceExemptionDTO.ExemptionFromDate = model.ExemptionFromDate;
                    model.LeaveAttendanceExemptionDTO.ExemptionUpToDate = model.ExemptionUpToDate;
                    model.LeaveAttendanceExemptionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<LeaveAttendanceExemption> response = _ILeaveAttendanceExemptionBA.InsertLeaveAttendanceExemption(model.LeaveAttendanceExemptionDTO);
                    model.LeaveAttendanceExemptionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.LeaveAttendanceExemptionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<LeaveAttendanceExemptionViewModel> GetLeaveAttendanceExemptionRecords(out int TotalRecords, string CentreCode)
        {
            LeaveAttendanceExemptionSearchRequest searchRequest = new LeaveAttendanceExemptionSearchRequest();
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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
            }
            List<LeaveAttendanceExemptionViewModel> listLeaveAttendanceExemptionViewModel = new List<LeaveAttendanceExemptionViewModel>();
            List<LeaveAttendanceExemption> listLeaveAttendanceExemption = new List<LeaveAttendanceExemption>();
            IBaseEntityCollectionResponse<LeaveAttendanceExemption> baseEntityCollectionResponse = _ILeaveAttendanceExemptionBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveAttendanceExemption = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveAttendanceExemption item in listLeaveAttendanceExemption)
                    {
                        LeaveAttendanceExemptionViewModel _leaveAttendanceExemptionViewModel = new LeaveAttendanceExemptionViewModel();
                        _leaveAttendanceExemptionViewModel.LeaveAttendanceExemptionDTO = item;
                        listLeaveAttendanceExemptionViewModel.Add(_leaveAttendanceExemptionViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveAttendanceExemptionViewModel;
        }

        #endregion

        //// AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveAttendanceExemptionViewModel> filteredLeaveAttendanceExemption;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "B.EmployeeFirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%'  or A.ExemptionFromDate Like '%" + param.sSearch + "%' or A.ExemptionUpToDate Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "A.ExemptionFromDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%'  or A.ExemptionFromDate Like '%" + param.sSearch + "%' or A.ExemptionUpToDate Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "A.ExemptionUpToDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%' or B.EmployeeLastName Like '%" + param.sSearch + "%'  or A.ExemptionFromDate Like '%" + param.sSearch + "%' or A.ExemptionUpToDate Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(CentreCode))
            {

                //string[] splitCentreCode = CentreCode.Split(':');
                var centreCode = CentreCode;
                var RoleID = "";
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
                //centerCode = splitCentreCode[0];

                filteredLeaveAttendanceExemption = GetLeaveAttendanceExemptionRecords(out TotalRecords, centreCode);
            }
            else
            {
                filteredLeaveAttendanceExemption = new List<LeaveAttendanceExemptionViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveAttendanceExemption.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeName), Convert.ToString(c.ExemptionFromDate), Convert.ToString(c.ExemptionUpToDate), Convert.ToString(c.LeaveAttendanceExemptionDTO.IsActive), Convert.ToString(c.LeaveAttendanceExemptionDTO.StatusFlag), Convert.ToString(c.ID) };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


