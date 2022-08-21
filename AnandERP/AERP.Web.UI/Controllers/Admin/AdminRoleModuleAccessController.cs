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
    public class AdminRoleModuleAccessController : BaseController
    {
        IAdminRoleModuleAccessBA _adminRoleModuleAccessBA = null;
        IAdminSnPostsBA _adminSnPostsBA = null;
        AdminRoleModuleAccessBaseViewModel _adminRoleModuleAccessBaseViewModel = null;
        AdminRoleModuleAccessViewModel _adminRoleModuleAccessViewModel = null;
        IAdminRoleMasterBA _adminRoleMasterBA = null;
        AdminSnPostsViewModel _adminSnPostsViewModel = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        string entityType;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);



        public AdminRoleModuleAccessController()
        {
            _adminRoleModuleAccessBA = new AdminRoleModuleAccessBA();
            _adminRoleModuleAccessBaseViewModel = new AdminRoleModuleAccessBaseViewModel();
            _adminRoleModuleAccessViewModel = new AdminRoleModuleAccessViewModel();
            _adminSnPostsViewModel = new AdminSnPostsViewModel();
            _adminRoleMasterBA = new AdminRoleMasterBA();
            _adminSnPostsBA = new AdminSnPostsBA();
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
                return View("/Views/Admin/AdminRoleModuleAccess/Index.cshtml");
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
                    return View("/Views/Admin/AdminRoleModuleAccess/Index.cshtml");
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
                AdminRoleModuleAccessBaseViewModel _adminRoleModuleAccessBaseViewModel = new AdminRoleModuleAccessBaseViewModel();
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
                        _adminRoleModuleAccessBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
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
                        _adminRoleModuleAccessBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _adminRoleModuleAccessBaseViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                }
                _adminRoleModuleAccessBaseViewModel.SelectedCentreCodeforRoleMaster = centerCode;
                _adminRoleModuleAccessBaseViewModel.SelectedDepartmentIDforRoleMaster = departmentID;
                foreach (var b in _adminRoleModuleAccessBaseViewModel.ListOrganisationDepartmentMaster)
                {
                    b.DeptID = b.ID + ":" + b.DepartmentName;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Admin/AdminRoleModuleAccess/List.cshtml", _adminRoleModuleAccessBaseViewModel);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDepartmentByCentreCodeForRoleMaster(string SelectedCentreCodeforRoleMaster)
        {
            try
            {
                string[] splited;
                splited = SelectedCentreCodeforRoleMaster.Split(':');
                _adminRoleModuleAccessBaseViewModel.SelectedCentreNameforRoleMaster = splited[1];
                string _SelectedCentreCode = splited[0];
                if (String.IsNullOrEmpty(SelectedCentreCodeforRoleMaster))
                {
                    throw new ArgumentNullException("SelectedCentreCodeforRoleMaster");
                }
                int id = 0;
                bool isValid = Int32.TryParse(SelectedCentreCodeforRoleMaster, out id);
                var departments = GetListOrganisationDepartmentMaster(_SelectedCentreCode);
                var result = (from s in departments
                              select new
                              {
                                  id = s.ID,
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

        public ActionResult GetEntityByCentreCode(int AdminRoleMasterID, string AccessibleCentreCode, string MonitoringLevel, string EntityType)
        {
            try
            {
                if (String.IsNullOrEmpty(AccessibleCentreCode))
                {
                    throw new ArgumentNullException("AccessibleCentreList");
                }
                int id = 0;
                bool isValid = Int32.TryParse(AccessibleCentreCode, out id);
                var entity = GetEntity(AccessibleCentreCode, AdminRoleMasterID, MonitoringLevel, EntityType);
                var result = (from s in entity
                              select new
                              {
                                  id = s.EntityID,
                                  name = s.Entity,
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
        public ActionResult GetPostsByCentreCodeDepartmentID(string SelectedCentreCodeforRoleMaster, string SelectedDepartmentIDforRoleMaster)
        {
            try
            {
                if (String.IsNullOrEmpty(SelectedCentreCodeforRoleMaster) || String.IsNullOrEmpty(SelectedDepartmentIDforRoleMaster))
                {
                    throw new ArgumentNullException("SelectedCentreCodeforRoleMaster");
                    throw new ArgumentNullException("SelectedDepartmentIDforRoleMaster");
                }
                int id = 0;
                bool isValid = Int32.TryParse(SelectedCentreCodeforRoleMaster, out id);
                var departments = GetListAdminSnPosts(SelectedCentreCodeforRoleMaster, SelectedDepartmentIDforRoleMaster);
                var result = (from s in departments
                              select new
                              {
                                  id = s.ID + ":" + s.SactionedPostDescription,
                                  name = s.SactionedPostDescription,
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
        public ActionResult Create(string AdminRoleMasterID, AdminRoleModuleAccessViewModel model)
        {
            try
            {
                string[] splitedAdminRoleMasterID = AdminRoleMasterID.Split(':');

                model.AdminRoleModuleAccessDTO.ID = Convert.ToInt32(splitedAdminRoleMasterID[3]);
                model.ID = Convert.ToInt32(splitedAdminRoleMasterID[3]);
                model.AdminRoleModuleAccessDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AdminRoleModuleAccess> response = _adminRoleModuleAccessBA.SelectByAdminRoleMasterID(model.AdminRoleModuleAccessDTO);
                model.AdminRoleCode = response.Entity.AdminRoleCode;
                model.CentreName = response.Entity.CentreName;
                model.DepartmentName = response.Entity.DepartmentName;
                model.DesignationType = response.Entity.DesignationType;
                model.MonitoringLevel = response.Entity.MonitoringLevel;
                if (model.AccessibleCentreCode == null && splitedAdminRoleMasterID[0] != "0")
                {
                    model.AccessibleCentreList = GetAccessibleCentreList(Convert.ToInt32(splitedAdminRoleMasterID[3]));
                    model.AccessibleCentreCode = splitedAdminRoleMasterID[0];
                }
                else
                {
                    model.AccessibleCentreList = GetAccessibleCentreList(Convert.ToInt32(splitedAdminRoleMasterID[3]));

                }
                Session["accessibleCentreCode"] = splitedAdminRoleMasterID[0];
                Session["monitoringLevel"] = splitedAdminRoleMasterID[1];
                Session["entityType"] = splitedAdminRoleMasterID[2];
                model.EntityType = splitedAdminRoleMasterID[2];
                model.Entity = splitedAdminRoleMasterID[2];
                Session["id"] = Convert.ToInt32(splitedAdminRoleMasterID[3]);

                //model.CentreCodeWithName = Session["centreName"].ToString();
                //model.DepartmentIdWithName = Session["departmentId"].ToString();
                //model.CentreCode = Session["centerCode"].ToString();

                if (model.AccessibleCentreCode != null)
                {
                    model.EntityList = GetEntity(model.AccessibleCentreCode, Convert.ToInt32(splitedAdminRoleMasterID[3]), model.MonitoringLevel, model.EntityType);
                }
                model.AccessibleCentreCode = model.AccessibleCentreCode;
                return PartialView("/Views/Admin/AdminRoleModuleAccess/Create.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AdminRoleModuleAccessViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AdminRoleModuleAccessDTO != null)
                    {

                        model.AdminRoleModuleAccessDTO.ConnectionString = _connectioString;
                        model.AdminRoleModuleAccessDTO.AdminRoleMasterID = model.AdminRoleMasterID;
                        model.AdminRoleModuleAccessDTO.AdminRoleCode = model.AdminRoleCode;
                        model.AdminRoleModuleAccessDTO.AccessibleCentreCode = model.AccessibleCentreCode;
                        model.AccessibleCentreList = GetAccessibleCentreList(model.AdminRoleMasterID);
                        model.AdminRoleModuleAccessDTO.EntityType = model.EntityType;
                        model.AdminRoleModuleAccessDTO.IsActive = model.IsActive;
                        model.AdminRoleModuleAccessDTO.IDs = model.IDs;
                        model.AdminRoleModuleAccessDTO.CreatedDate = DateTime.Now;
                        model.AdminRoleModuleAccessDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        //---------------------used Procedure Name:-USP_AdminRoleDetails_Insert and inner procedure name:-USP_AdminRoleModuleAccess_Insert_xml--------------------------//
                        IBaseEntityResponse<AdminRoleModuleAccess> response = _adminRoleModuleAccessBA.InsertAdminRoleModuleAccess(model.AdminRoleModuleAccessDTO);
                        model.AdminRoleModuleAccessDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.AdminRoleModuleAccessDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    // return PartialView();
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

        public IEnumerable<AdminRoleModuleAccessViewModel> GetAdminRoleModuleAccess(string centerCode, int departmentId, out int TotalRecords)
        {
            AdminRoleModuleAccessSearchRequest searchRequest = new AdminRoleModuleAccessSearchRequest();
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
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition(Procedure Name : USP_AdminRoleMaster_SelectAll)
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centerCode;
                searchRequest.DepartmentID = departmentId;
            }

            List<AdminRoleModuleAccessViewModel> listAdminRoleModuleAccessViewModel = new List<AdminRoleModuleAccessViewModel>();
            List<AdminRoleModuleAccess> listAdminRoleModuleAccess = new List<AdminRoleModuleAccess>();
            IBaseEntityCollectionResponse<AdminRoleModuleAccess> baseEntityCollectionResponse = _adminRoleModuleAccessBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleModuleAccess = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (AdminRoleModuleAccess item in listAdminRoleModuleAccess)
                    {
                        AdminRoleModuleAccessViewModel AdminRoleModuleAccessViewModel = new AdminRoleModuleAccessViewModel();
                        AdminRoleModuleAccessViewModel.AdminRoleModuleAccessDTO = item;
                        listAdminRoleModuleAccessViewModel.Add(AdminRoleModuleAccessViewModel);
                    }
                }
                else if (baseEntityCollectionResponse.Message != null && baseEntityCollectionResponse.Message.Count > 0)
                {
                    IMessageDTO errordto = baseEntityCollectionResponse.Message.FirstOrDefault();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAdminRoleModuleAccessViewModel;
        }

        protected List<AdminRoleModuleAccess> GetAccessibleCentreList(int ID)
        {
            try
            {
                //List<AdminRoleModuleAccessViewModel> listAdminRoleModuleAccessViewModel = new List<AdminRoleModuleAccessViewModel>();
                AdminRoleModuleAccessSearchRequest searchRequest = new AdminRoleModuleAccessSearchRequest();
                //AdminRoleModuleAccess listAdminRoleModuleAccess = new AdminRoleModuleAccess();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ID = ID;

                List<AdminRoleModuleAccess> AccessibleCentreList = new List<AdminRoleModuleAccess>();

                IBaseEntityCollectionResponse<AdminRoleModuleAccess> baseEntityCollectionResponse = _adminRoleModuleAccessBA.GetAccessibleCentreListByID(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        AccessibleCentreList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return AccessibleCentreList;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        protected List<AdminRoleModuleAccess> GetEntity(string centreCode, int adminRoleMasterID, string MonitoringLevel, string entityType)
        {
            try
            {
                AdminRoleModuleAccessSearchRequest searchRequest = new AdminRoleModuleAccessSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.AdminRoleMasterID = adminRoleMasterID;
                searchRequest.CentreCode = centreCode;
                searchRequest.MonitoringLevel = MonitoringLevel;
                searchRequest.EntityType = entityType;


                List<AdminRoleModuleAccess> EntityList = new List<AdminRoleModuleAccess>();
                IBaseEntityCollectionResponse<AdminRoleModuleAccess> baseEntityCollectionResponse = _adminRoleModuleAccessBA.GetEntityByID(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        EntityList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return EntityList;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<AdminRoleModuleAccessViewModel> GetAdminEntityIndividualList(string AccessibleCentreCode, string MonitoringLevel, string EntityType, int ID)
        {
            try
            {
                AdminRoleModuleAccessSearchRequest searchRequest = new AdminRoleModuleAccessSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = AccessibleCentreCode;
                searchRequest.MonitoringLevel = MonitoringLevel;
                searchRequest.EntityType = EntityType;
                searchRequest.ID = ID;


                List<AdminRoleModuleAccessViewModel> adminEntityInduvidualListViewModel = new List<AdminRoleModuleAccessViewModel>();
                List<AdminRoleModuleAccess> listAdminRoleModuleAccess = new List<AdminRoleModuleAccess>();
                IBaseEntityCollectionResponse<AdminRoleModuleAccess> baseEntityCollectionResponse = _adminRoleModuleAccessBA.GetAdminEntityInduvidualListBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAdminRoleModuleAccess = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (AdminRoleModuleAccess item in listAdminRoleModuleAccess)
                        {
                            AdminRoleModuleAccessViewModel AdminRoleModuleAccessViewModel = new AdminRoleModuleAccessViewModel();
                            AdminRoleModuleAccessViewModel.AdminRoleModuleAccessDTO = item;
                            adminEntityInduvidualListViewModel.Add(AdminRoleModuleAccessViewModel);
                        }
                    }
                    else if (baseEntityCollectionResponse.Message != null && baseEntityCollectionResponse.Message.Count > 0)
                    {
                        IMessageDTO errordto = baseEntityCollectionResponse.Message.FirstOrDefault();
                    }
                }

                return adminEntityInduvidualListViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string DepartmentID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<AdminRoleModuleAccessViewModel> filteredAdminRoleModuleAccess;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "AdminRoleCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
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
                filteredAdminRoleModuleAccess = GetAdminRoleModuleAccess(Convert.ToString(splitCentreCode[0]), Convert.ToInt32(splitDepartmentID[0]), out TotalRecords);
            }
            else
            {
                filteredAdminRoleModuleAccess = new List<AdminRoleModuleAccessViewModel>();
                TotalRecords = 0;
            }
            var records = filteredAdminRoleModuleAccess.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.AdminRoleCode.ToString(), c.Designation.ToString(), Convert.ToString(c.AdminRoleMasterID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerForCreate(JQueryDataTableParamModel param, string AccessibleCentreCode, string MonitoringLevel, string EntityType, string AdminRoleMasterID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AdminRoleModuleAccessViewModel> AdminEntityInduvidualList;
            string centreCode = _adminRoleModuleAccessViewModel.AccessibleCentreCode;
            string monitoringLevel = _adminRoleModuleAccessViewModel.MonitoringLevel;
            entityType = _adminRoleModuleAccessViewModel.EntityType;
            int ID = _adminRoleModuleAccessViewModel.ID;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ID";
                    break;
                case 1:
                    _sortBy = "ID";
                    break;
            }
            // _sortOrder = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered             
                var AdminRoleCodeFilter = Convert.ToString(Request["sSearch_0"]);
                var SanctPostNameFilter = Convert.ToString(Request["sSearch_1"]);


                //Optionally check whether the columns are searchable at all                
                var isAdminRoleCodeSearchable = Convert.ToBoolean(Request["bSearchable_0"]);
                var isSanctPostNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);


                AdminEntityInduvidualList = GetAdminEntityIndividualList(AccessibleCentreCode, MonitoringLevel, EntityType, Convert.ToInt32(AdminRoleMasterID))
                   .Where(c => isAdminRoleCodeSearchable && c.AccessibleCentreCode.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isSanctPostNameSearchable && c.CentreCodeWithName.ToString().Contains(param.sSearch.ToLower()));
            }
            else
            {
                AdminEntityInduvidualList = GetAdminEntityIndividualList(AccessibleCentreCode, MonitoringLevel, EntityType, Convert.ToInt32(AdminRoleMasterID));
            }

            var isAdminRoleCodeSortable = Convert.ToBoolean(Request["bSortable_0"]);
            var isSanctPostNameSortable = Convert.ToBoolean(Request["bSortable_1"]);

            //Func<AdminSnPostsViewModel, string> orderingFunction = (c => sortColumnIndex == 0 && isSactionedPostDescriptionSortable ? c.SactionedPostDescription :
            //                                               sortColumnIndex == 1 && isNoOfPostsSortable ? c.NoOfPosts.ToString() :
            //                                               "");


            if (sortColumnIndex == 0)
            {
                if (sortDirection == "asc")
                {
                    AdminEntityInduvidualList = AdminEntityInduvidualList.OrderBy(x => x.AccessibleCentreCode);
                }
                else if (sortDirection == "desc")
                {
                    AdminEntityInduvidualList = AdminEntityInduvidualList.OrderByDescending(x => x.CentreCodeWithName);
                }
            }
            else if (sortColumnIndex == 1)
            {
                if (sortDirection == "asc")
                {
                    AdminEntityInduvidualList = AdminEntityInduvidualList.OrderBy(x => x.AccessibleCentreCode);
                }
                else if (sortDirection == "desc")
                {
                    AdminEntityInduvidualList = AdminEntityInduvidualList.OrderByDescending(x => x.CentreCodeWithName);
                }
            }
            var totalRecordLength = AdminEntityInduvidualList.Count();
            var displayedFields = AdminEntityInduvidualList.Skip(0).Take(totalRecordLength);

            //IEnumerable<String[]> result =
            var result = from c in displayedFields select new[] { c.status.ToString(), c.EntitySourceName.ToString(), c.SourceID.ToString(), Convert.ToString(c.AdminRoleDetailsID) };
            
            return Json(new
            {
                sEcho = param.sEcho,
                // iTotalRecords = TotalRecords,
                // iTotalDisplayRecords = TotalRecords,
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
