using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;

namespace AERP.Web.UI.Controllers
{
    public class AdminRoleApplicableDetailsController : BaseController
    {
        IAdminRoleApplicableDetailsBA _adminRoleApplicableDetailsBA = null;
        AdminRoleApplicableDetailsBaseViewModel _adminRoleApplicableDetailsBaseViewModel = null;

        string _centreCode = string.Empty;
        string _designationId = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AdminRoleApplicableDetailsController()
        {
            _adminRoleApplicableDetailsBA = new AdminRoleApplicableDetailsBA();
            _adminRoleApplicableDetailsBaseViewModel = new AdminRoleApplicableDetailsBaseViewModel();

        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/Admin/AdminRoleApplicableDetails/Index.cshtml");
            }

            else
            {
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);

                if (listAdminRoleApplicableDetails.Count > 0)
                {
                    return View("/Views/Admin/AdminRoleApplicableDetails/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
        }

        public ActionResult List(string centerCode, string departmentID, string actionMode)
        {
            try
            {
                AdminRoleApplicableDetailsBaseViewModel _adminRoleApplicableDetailsBaseViewModel = new AdminRoleApplicableDetailsBaseViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _adminRoleApplicableDetailsBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _adminRoleApplicableDetailsBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _adminRoleApplicableDetailsBaseViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                }
                _adminRoleApplicableDetailsBaseViewModel.SelectedCentreCode = centerCode;
                _adminRoleApplicableDetailsBaseViewModel.SelectedDepartmentID = departmentID;
                foreach (var b in _adminRoleApplicableDetailsBaseViewModel.ListOrganisationDepartmentMaster)
                {
                    b.DeptID = b.ID + ":" + b.DepartmentName;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Admin/AdminRoleApplicableDetails/List.cshtml", _adminRoleApplicableDetailsBaseViewModel);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDepartmentByCentreCode(string SelectedCentreCode)
        {
            try
            {
                string[] splited;
                splited = SelectedCentreCode.Split(':');
                //_adminRoleApplicableDetailsBaseViewModel.SelectedCentreName = splited[1];
                SelectedCentreCode = splited[0];
                if (String.IsNullOrEmpty(SelectedCentreCode))
                {
                    throw new ArgumentNullException("SelectedCentreCode");
                }
                int id = 0;
                bool isValid = Int32.TryParse(SelectedCentreCode, out id);
                var departments = GetListOrganisationDepartmentMaster(SelectedCentreCode);
                var result = (from s in departments
                              select new
                              {
                                  id = s.ID + ":" + s.DepartmentName,
                                  name = s.DepartmentName,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string ID, string CentreCode, string CentreName, string DepartmentID, string DepartmentName, string EmployeeID, string DesignationID, string EmployeeName, string RoleApplicableID)
        {
            AdminRoleApplicableDetailsViewModel model = new AdminRoleApplicableDetailsViewModel();
            try
            {

                string[] SplitedValue = ID.Split('~');
                string[] splitCentreCode = CentreCode.Split(':');
                model.CentreCode = splitCentreCode[0];

                if (Convert.ToInt32(RoleApplicableID) == 0)
                {
                    model.AdminRoleApplicableDetailsDTO.ConnectionString = _connectioString;
                    model.AdminRoleApplicableDetailsDTO.EmployeeID = Convert.ToInt32(EmployeeID);
                    model.AdminRoleApplicableDetailsDTO.CentreCode = model.CentreCode;
                    model.AdminRoleApplicableDetailsDTO.DepartmentID = Convert.ToInt32(DepartmentID);
                    IBaseEntityResponse<AdminRoleApplicableDetails> response = _adminRoleApplicableDetailsBA.SelectActiveAdminRoleCodeByEmployeeID(model.AdminRoleApplicableDetailsDTO);

                    if (response != null && response.Entity != null)
                    {
                        model.WorkFromDate = "";
                        model.Reason = "";
                        model.IsActive = true;
                        model.RoleApplicableID = 0;
                        model.RoleType = "Regular";
                        model.AdminRoleCode = response.Entity.AdminRoleCode;
                        model.AdminRoleMasterID = response.Entity.AdminRoleMasterID;//RoleName   
                    }
                }
                else
                {
                    model.AdminRoleApplicableDetailsDTO.ConnectionString = _connectioString;
                    model.AdminRoleApplicableDetailsDTO.RoleApplicableID = Convert.ToInt32(RoleApplicableID);
                    IBaseEntityResponse<AdminRoleApplicableDetails> response = _adminRoleApplicableDetailsBA.SelectByID(model.AdminRoleApplicableDetailsDTO);

                    if (response != null && response.Entity != null)
                    {
                        model.WorkFromDate = response.Entity.WorkFromDate;
                        model.Reason = response.Entity.Reason;
                        model.IsActive = response.Entity.IsActive;
                        model.RoleApplicableID = response.Entity.RoleApplicableID;
                        model.RoleType = response.Entity.RoleType;
                        model.AdminRoleCode = response.Entity.AdminRoleCode;
                        model.AdminRoleMasterID = response.Entity.AdminRoleMasterID;//RoleName   
                    }
                }
                model.EmployeeName = EmployeeName.Replace('~', ' ');
                model.EmployeeID = Convert.ToInt32(EmployeeID);
                model.CentreCodeWithName = CentreName.Replace('~', ' ');
                model.DepartmentIdWithName = DepartmentID;
                model.DesignationID = Convert.ToInt32(DesignationID);
                return PartialView("/Views/Admin/AdminRoleApplicableDetails/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AdminRoleApplicableDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AdminRoleApplicableDetailsDTO != null)
                    {
                        model.AdminRoleApplicableDetailsDTO.ConnectionString = _connectioString;

                        model.AdminRoleApplicableDetailsDTO.EmployeeID = model.EmployeeID;
                        model.AdminRoleApplicableDetailsDTO.SelectedIDs = model.SelectedIDs;
                        model.AdminRoleApplicableDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<AdminRoleApplicableDetails> response = _adminRoleApplicableDetailsBA.InsertAdminRoleApplicableDetails(model.AdminRoleApplicableDetailsDTO);
                        model.AdminRoleApplicableDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.AdminRoleApplicableDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region Methods
        [NonAction]
        public IEnumerable<AdminRoleApplicableDetailsViewModel> GetAdminRoleApplicableDetails(string centerCode, int departmentId, out int TotalRecords)
        {
            try
            {
                AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _actionMode = Convert.ToString(TempData["ActionMode"]);
                if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
                {
                    if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                    {
                        searchRequest.CentreCode = centerCode;
                        searchRequest.DepartmentID = departmentId;
                        searchRequest.SortBy = "CreatedDate";
                        searchRequest.StartRow = 0;
                        searchRequest.EndRow = 10;
                        searchRequest.SearchBy = string.Empty;
                        searchRequest.SortDirection = "Desc";
                    }
                    if (actionModeEnum == ActionModeEnum.Update)
                    {
                        searchRequest.CentreCode = centerCode;
                        searchRequest.DepartmentID = departmentId;
                        searchRequest.SortBy = "ModifiedDate";
                        searchRequest.StartRow = 0;
                        searchRequest.EndRow = 10;
                        searchRequest.SearchBy = string.Empty;
                        searchRequest.SortDirection = "Desc";
                    }
                }
                else
                {
                    searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition(Procedure Name : USP_AdminPostApplicableToRole_SelectAll)
                    searchRequest.StartRow = _startRow;
                    searchRequest.EndRow = _startRow + _rowLength;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = _sortDirection;
                    searchRequest.CentreCode = centerCode;
                    searchRequest.DepartmentID = departmentId;
                }

                List<AdminRoleApplicableDetailsViewModel> listAdminRoleApplicableDetailsViewModel = new List<AdminRoleApplicableDetailsViewModel>();
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
                IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (AdminRoleApplicableDetails item in listAdminRoleApplicableDetails)
                        {
                            AdminRoleApplicableDetailsViewModel AdminRoleApplicableDetailsViewModel = new AdminRoleApplicableDetailsViewModel();
                            AdminRoleApplicableDetailsViewModel.AdminRoleApplicableDetailsDTO = item;
                            listAdminRoleApplicableDetailsViewModel.Add(AdminRoleApplicableDetailsViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listAdminRoleApplicableDetailsViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public List<AdminRoleApplicableDetailsViewModel> GetAdminRoleApplicableDetailsForViewPurpose(string centerCode, int departmentId, out int TotalRecords)
        {
            try
            {
                AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ID = 0;
                searchRequest.SortBy = "ID";
                searchRequest.StartRow = 0;
                searchRequest.EndRow = 100;
                searchRequest.CentreCode = centerCode;
                searchRequest.DepartmentID = departmentId;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;

                List<AdminRoleApplicableDetailsViewModel> listAdminRoleApplicableDetailsViewModel = new List<AdminRoleApplicableDetailsViewModel>();
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
                IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (AdminRoleApplicableDetails item in listAdminRoleApplicableDetails)
                        {
                            AdminRoleApplicableDetailsViewModel AdminRoleApplicableDetailsViewModel = new AdminRoleApplicableDetailsViewModel();
                            AdminRoleApplicableDetailsViewModel.AdminRoleApplicableDetailsDTO = item;
                            listAdminRoleApplicableDetailsViewModel.Add(AdminRoleApplicableDetailsViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listAdminRoleApplicableDetailsViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public List<AdminRoleApplicableDetailsViewModel> GetAdminRegularRoleList(int AdminRoleMasterID, string CentreCode, int DepartmentID)
        {
            try
            {
                AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                // searchRequest.ID = 0;
                searchRequest.CentreCode = CentreCode;
                searchRequest.DepartmentID = DepartmentID;
                searchRequest.AdminRoleMasterID = AdminRoleMasterID;

                List<AdminRoleApplicableDetailsViewModel> AdminRegularRoleListViewModel = new List<AdminRoleApplicableDetailsViewModel>();
                List<AdminRoleApplicableDetails> listAdminRegularRoleList = new List<AdminRoleApplicableDetails>();
                IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetAdminRegularListBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAdminRegularRoleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (AdminRoleApplicableDetails item in listAdminRegularRoleList)
                        {
                            AdminRoleApplicableDetailsViewModel AdminRoleApplicableDetailsViewModel = new AdminRoleApplicableDetailsViewModel();
                            AdminRoleApplicableDetailsViewModel.AdminRoleApplicableDetailsDTO = item;
                            AdminRegularRoleListViewModel.Add(AdminRoleApplicableDetailsViewModel);
                        }
                    }
                }
                return AdminRegularRoleListViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public List<AdminRoleApplicableDetailsViewModel> GetAdminAddtionalRoleList(string centerCode, int DepartmentID, int EmployeeID, out int TotalRecords)
        {
            try
            {
                AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ID = 0;
                searchRequest.SortBy = "ID";
                searchRequest.StartRow = 0;
                searchRequest.EndRow = 100;
                searchRequest.CentreCode = centerCode;
                searchRequest.DepartmentID = DepartmentID;
                searchRequest.EmployeeID = EmployeeID;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;

                List<AdminRoleApplicableDetailsViewModel> listAdminRoleApplicableDetailsViewModel = new List<AdminRoleApplicableDetailsViewModel>();
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
                IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetAdminAdditionalListBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (AdminRoleApplicableDetails item in listAdminRoleApplicableDetails)
                        {
                            AdminRoleApplicableDetailsViewModel AdminRoleApplicableDetailsViewModel = new AdminRoleApplicableDetailsViewModel();
                            AdminRoleApplicableDetailsViewModel.AdminRoleApplicableDetailsDTO = item;
                            listAdminRoleApplicableDetailsViewModel.Add(AdminRoleApplicableDetailsViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listAdminRoleApplicableDetailsViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string DepartmentID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<AdminRoleApplicableDetailsViewModel> filteredAdminRoleApplicableDetails;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "EmployeeDesignationMasterID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%' or EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeMiddleName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "EmployeeDesignationMasterID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%' or EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeMiddleName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "AdminRoleCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%' or EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeMiddleName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(Convert.ToString(CentreCode)) && !string.IsNullOrEmpty(Convert.ToString(DepartmentID)))
            {
                string[] splitCentreCode = CentreCode.Split(':');
                string[] splitDepartmentID = DepartmentID.Split(':');
                filteredAdminRoleApplicableDetails = GetAdminRoleApplicableDetails(splitCentreCode[0], Convert.ToInt32(splitDepartmentID[0]), out TotalRecords);
            }
            else
            {
                filteredAdminRoleApplicableDetails = new List<AdminRoleApplicableDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredAdminRoleApplicableDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeName), Convert.ToString(c.DesignationName), Convert.ToString(c.AdminRoleCode), Convert.ToString(c.AdminRoleMasterID + "~" + c.AdminRoleCode), Convert.ToString(c.EmployeeID), Convert.ToString(c.DesignationID), Convert.ToString(c.RoleApplicableID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerForAdditionalRole(JQueryDataTableParamModel param, string CentreCode, string DepartmentID, string EmployeeID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<AdminRoleApplicableDetailsViewModel> filteredAdminAddtionalRoleList;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "EmployeeDesignationMasterID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%' or SactionedPostDescription Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "EmployeeDesignationMasterID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%' or SactionedPostDescription Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(Convert.ToString(CentreCode)) && !string.IsNullOrEmpty(Convert.ToString(DepartmentID)))
            {
                string[] splitCentreCode = CentreCode.Split(':');
                string[] splitDepartmentID = DepartmentID.Split(':');
                filteredAdminAddtionalRoleList = GetAdminAddtionalRoleList(splitCentreCode[0], Convert.ToInt32(DepartmentID), Convert.ToInt32(EmployeeID), out TotalRecords);
            }
            else
            {
                filteredAdminAddtionalRoleList = new List<AdminRoleApplicableDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredAdminAddtionalRoleList.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.StatusFlag), Convert.ToString(c.CentreName + '-' + c.DepartmentIdWithName), Convert.ToString(c.AdminRoleCode), Convert.ToString(c.AdminRoleMasterID), Convert.ToString(c.WorkFromDate), Convert.ToString(c.WorkToDate), Convert.ToString(c.Reason), Convert.ToString(c.RoleApplicableID), Convert.ToString(c.DesignationID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


