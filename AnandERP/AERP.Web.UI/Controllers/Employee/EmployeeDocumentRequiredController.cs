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
    public class EmployeeDocumentRequiredController : BaseController
    {
        IEmployeeDocumentRequiredBA _IEmployeeDocumentRequiredBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeDocumentRequiredController()
        {
            _IEmployeeDocumentRequiredBA = new EmployeeDocumentRequiredBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                return View("/Views/Employee/EmployeeDocumentRequired/Index.cshtml");
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
                    return View("/Views/Employee/EmployeeDocumentRequired/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
        }

        public ActionResult List(string actionMode, string centerCode, string centreName)
        {
            try
            {
                IEmployeeDocumentRequiredViewModel _employeeDocumentRequiredViewModel = new EmployeeDocumentRequiredViewModel();
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _employeeDocumentRequiredViewModel.CentreCode = splitCentreCode[0];
                    _employeeDocumentRequiredViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _employeeDocumentRequiredViewModel.CentreCode = centerCode;
                    _employeeDocumentRequiredViewModel.EntityLevel = null;
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
                        _employeeDocumentRequiredViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _employeeDocumentRequiredViewModel.EntityLevel = "Centre";

                    foreach (var b in _employeeDocumentRequiredViewModel.ListGetAdminRoleApplicableCentre)
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        _employeeDocumentRequiredViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _employeeDocumentRequiredViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                    }
                }

                _employeeDocumentRequiredViewModel.CentreCode = centerCode;
                _employeeDocumentRequiredViewModel.LeaveRuleDescription = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeeDocumentRequired/List.cshtml", _employeeDocumentRequiredViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string LeaveRuleMasterID, string LeaveDescription, string LeaveRuleDescription)
        {
            IEmployeeDocumentRequiredViewModel _employeeDocumentRequiredViewModel = new EmployeeDocumentRequiredViewModel();           
            _employeeDocumentRequiredViewModel.LeaveRuleMasterID = Convert.ToInt32(LeaveRuleMasterID);
            _employeeDocumentRequiredViewModel.LeaveDescription = LeaveDescription.Replace('~', ' ');
            _employeeDocumentRequiredViewModel.LeaveRuleDescription = LeaveRuleDescription.Replace('~', ' ');


            /////----------------------------- Get GeneralLeaveDocument List------------------------///// 
            List<EmployeeDocumentRequired> EmployeeDocumentRequiredByLeaveRuleMasterIDList = GetEmployeeDocumentRequiredByLeaveRuleMasterID(_employeeDocumentRequiredViewModel.LeaveRuleMasterID);
            //if (EmployeeDocumentRequiredByLeaveRuleMasterIDList.Count > 0)
            //{
                ViewBag.Data = 1;
                ViewBag.ListEmployeeDocumentRequiredByLeaveRuleMasterID = EmployeeDocumentRequiredByLeaveRuleMasterIDList;

            //}

            return PartialView("/Views/Employee/EmployeeDocumentRequired/Create.cshtml", _employeeDocumentRequiredViewModel);
        }

        [HttpPost]
        public ActionResult Create(EmployeeDocumentRequiredViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeDocumentRequiredDTO != null)
                    {
                        model.EmployeeDocumentRequiredDTO.ConnectionString = _connectioString;
                        model.EmployeeDocumentRequiredDTO.LeaveRuleMasterID = model.LeaveRuleMasterID;
                        model.EmployeeDocumentRequiredDTO.SelectedIDs = model.SelectedIDs;
                        model.EmployeeDocumentRequiredDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<EmployeeDocumentRequired> response = _IEmployeeDocumentRequiredBA.InsertEmployeeDocumentRequired(model.EmployeeDocumentRequiredDTO);
                        model.EmployeeDocumentRequiredDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeDocumentRequiredDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(string LeaveRuleMasterID, string LeaveDescription, string LeaveRuleDescription)
        {
            IEmployeeDocumentRequiredViewModel _employeeDocumentRequiredViewModel = new EmployeeDocumentRequiredViewModel();
            _employeeDocumentRequiredViewModel.LeaveRuleMasterID = Convert.ToInt32(LeaveRuleMasterID);
            _employeeDocumentRequiredViewModel.LeaveDescription = LeaveDescription.Replace('~', ' ');
            _employeeDocumentRequiredViewModel.LeaveRuleDescription = LeaveRuleDescription.Replace('~', ' ');


            /////----------------------------- Get GeneralLeaveDocument List------------------------///// 
            List<EmployeeDocumentRequired> EmployeeDocumentRequiredByLeaveRuleMasterIDList = GetEmployeeDocumentRequiredByLeaveRuleMasterID(_employeeDocumentRequiredViewModel.LeaveRuleMasterID);
            if (EmployeeDocumentRequiredByLeaveRuleMasterIDList.Count > 0)
            {
                ViewBag.Data = 1;
                ViewBag.ListEmployeeDocumentRequiredByLeaveRuleMasterID = EmployeeDocumentRequiredByLeaveRuleMasterIDList;

            }

            return PartialView("/Views/Employee/EmployeeDocumentRequired/Create.cshtml", _employeeDocumentRequiredViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDocumentRequiredViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeDocumentRequiredDTO != null)
                    {
                        if (model != null && model.EmployeeDocumentRequiredDTO != null)
                        {
                            model.EmployeeDocumentRequiredDTO.ConnectionString = _connectioString;                           
                            model.EmployeeDocumentRequiredDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<EmployeeDocumentRequired> response = _IEmployeeDocumentRequiredBA.UpdateEmployeeDocumentRequired(model.EmployeeDocumentRequiredDTO);
                            model.EmployeeDocumentRequiredDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.EmployeeDocumentRequiredDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

      

        // Non-Action Methods
        #region Methods
        public IEnumerable<EmployeeDocumentRequiredViewModel> GetEmployeeDocumentRequiredDetails(out int TotalRecords, string CentreCode)
        {
            EmployeeDocumentRequiredSearchRequest searchRequest = new EmployeeDocumentRequiredSearchRequest();
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
                    searchRequest.CentreCode = CentreCode;                   
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
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
            List<EmployeeDocumentRequiredViewModel> listEmployeeDocumentRequiredViewModel = new List<EmployeeDocumentRequiredViewModel>();
            List<EmployeeDocumentRequired> listEmployeeDocumentRequired = new List<EmployeeDocumentRequired>();
            IBaseEntityCollectionResponse<EmployeeDocumentRequired> baseEntityCollectionResponse = _IEmployeeDocumentRequiredBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeDocumentRequired = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeDocumentRequired item in listEmployeeDocumentRequired)
                    {
                        EmployeeDocumentRequiredViewModel _EmployeeDocumentRequiredViewModel = new EmployeeDocumentRequiredViewModel();
                        _EmployeeDocumentRequiredViewModel.EmployeeDocumentRequiredDTO = item;
                        listEmployeeDocumentRequiredViewModel.Add(_EmployeeDocumentRequiredViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeDocumentRequiredViewModel;
        }

        protected List<EmployeeDocumentRequired> GetEmployeeDocumentRequiredByLeaveRuleMasterID(int LeaveRuleMasterID)
        {
            EmployeeDocumentRequiredSearchRequest searchRequest = new EmployeeDocumentRequiredSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.LeaveRuleMasterID = LeaveRuleMasterID;

            List<EmployeeDocumentRequired> listEmployeeDocumentRequiredByLeaveRuleMasterID = new List<EmployeeDocumentRequired>();
            IBaseEntityCollectionResponse<EmployeeDocumentRequired> baseEntityCollectionResponse = _IEmployeeDocumentRequiredBA.SelectByLeaveRuleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeDocumentRequiredByLeaveRuleMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeDocumentRequiredByLeaveRuleMasterID;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param,string CentreCode, string EntityLevel)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeDocumentRequiredViewModel> filteredEmployeeDocumentRequired;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LeaveRuleDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveRuleDescription Like '%" + param.sSearch + "%' or DocumentName Like '%" + param.sSearch + "%' or DocumentCompulsaryFlag Like '%" + param.sSearch + "%'";       //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DocumentName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveRuleDescription Like '%" + param.sSearch + "%' or DocumentName Like '%" + param.sSearch + "%' or DocumentCompulsaryFlag Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "DocumentCompulsaryFlag";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveRuleDescription Like '%" + param.sSearch + "%' or DocumentName Like '%" + param.sSearch + "%' or DocumentCompulsaryFlag Like '%" + param.sSearch + "%'";       //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(CentreCode))
            {

                string[] splitCentreCode = CentreCode.Split(':');
                var centreCode = splitCentreCode[0];
                var scopeIdentity = splitCentreCode[1];
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

                filteredEmployeeDocumentRequired = GetEmployeeDocumentRequiredDetails(out TotalRecords, centreCode);
            }
            else
            {
                filteredEmployeeDocumentRequired = new List<EmployeeDocumentRequiredViewModel>();
                TotalRecords = 0;
            }
           
            var records = filteredEmployeeDocumentRequired.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveDescription).Replace(' ', '~'), Convert.ToString(c.LeaveRuleDescription), Convert.ToString(c.DocumentName), Convert.ToString(c.DocumentID), Convert.ToString(c.DocumentCompulsaryFlag), Convert.ToString(c.LeaveRuleMasterID), Convert.ToString(c.LeaveMasterID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

        #endregion
