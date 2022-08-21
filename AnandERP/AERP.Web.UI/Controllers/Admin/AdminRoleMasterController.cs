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
    public class AdminRoleMasterController : BaseController
    {
        IAdminRoleMasterBA _adminRoleMasterBA = null;
        IAdminSnPostsBA _adminSnPostsBA= null;
        AdminRoleMasterBaseViewModel _adminRoleMasterBaseViewModel = null;
        AdminRoleMasterViewModel _adminRoleMasterViewModel = null;
        AdminSnPostsViewModel _adminSnPostsViewModel = null;
        AdminRoleCentreRightsBA _adminRoleCentreRightsBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AdminRoleMasterController()
        {
            _adminRoleMasterBA = new AdminRoleMasterBA();
            _adminRoleMasterBaseViewModel = new AdminRoleMasterBaseViewModel();
            _adminRoleMasterViewModel = new AdminRoleMasterViewModel();
            _adminSnPostsViewModel = new AdminSnPostsViewModel();
            _adminSnPostsBA = new AdminSnPostsBA();
            _adminRoleCentreRightsBA = new AdminRoleCentreRightsBA();
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
                return View("/Views/Admin/AdminRoleMaster/Index.cshtml");
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
                    return View("/Views/Admin/AdminRoleMaster/Index.cshtml");
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
                AdminRoleMasterBaseViewModel _adminRoleMasterBaseViewModel = new AdminRoleMasterBaseViewModel();
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
                        _adminRoleMasterBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
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
                        _adminRoleMasterBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _adminRoleMasterBaseViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                }
                _adminRoleMasterBaseViewModel.SelectedCentreCodeforRoleMaster = centerCode;
                _adminRoleMasterBaseViewModel.SelectedDepartmentIDforRoleMaster = departmentID;
                foreach (var b in _adminRoleMasterBaseViewModel.ListOrganisationDepartmentMaster)
                {
                    b.DeptID = b.ID + ":" + b.DepartmentName;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Admin/AdminRoleMaster/List.cshtml", _adminRoleMasterBaseViewModel);

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
                _adminRoleMasterBaseViewModel.SelectedCentreNameforRoleMaster = splited[1];
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
        public ActionResult Create(int ID)
        {
            try
            {
                AdminRoleMasterViewModel model = new AdminRoleMasterViewModel();
                if (ID != 0)
                {

                    AdminSnPostsViewModel adminSnPostsmodel = new AdminSnPostsViewModel();
                    model.ListOrgStudyCentreMaster = GetListOrgStudyCentreMaster();
                    model.ListDemo = GetListAdminRoleCentreRightsByAdminRole(0);
                    model.DefaultRightsType = GetListAdminRoleRightsTypeDefault(0);
                    model.AdminRoleMasterDTO.AdminSnPostID = ID;
                    adminSnPostsmodel.AdminSnPostsDTO.ID = ID;
                    adminSnPostsmodel.AdminSnPostsDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<AdminSnPosts> response = _adminSnPostsBA.SelectByID(adminSnPostsmodel.AdminSnPostsDTO);

                    List<SelectListItem> li = new List<SelectListItem>();
                    li.Add(new SelectListItem { Text = Resources.DisplayName_Self, Value = "Self" });
                    li.Add(new SelectListItem { Text = Resources.DisplayName_Other, Value = "Other" });
                    ViewData["MonitoringLevel"] = li;

                    foreach(var centrecode in model.ListDemo)
                    {
                        if (centrecode.CentreCode == response.Entity.CentreCode)
                        {
                            model.CentreCodeWithName = centrecode.CentreName;
                        }
                    }
                    
                    model.DepartmentID = response.Entity.DepartmentID;
                    model.CentreCode = response.Entity.CentreCode;
                    model.DesignationType = response.Entity.DesignationType;                   
                    model.AdminSnPostsIDWithName = response.Entity.SactionedPostDescription;
                    ViewBag.AdminRoleMasterID = response.Entity.AdminRoleMasterID;
                   
                   return PartialView("/Views/Admin/AdminRoleMaster/Create.cshtml",model);
                           
                }
                else
                {
                    return Json("No post available for applying role");
                }


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AdminRoleMasterViewModel model)
        {
            // <rows><row><ID>0</ID><CentreCode>1</CentreCode><IsSuperUser>0</IsSuperUser><IsAcadMgr>1</IsAcadMgr><IsEstMgr>1</IsEstMgr><IsFinMgr>1</IsFinMgr><IsAdmMgr>1</IsAdmMgr><IsActive>1</IsActive></row></rows>
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AdminRoleMasterDTO != null)
                    {
                        model.AdminRoleMasterDTO.ConnectionString = _connectioString;
                        model.AdminRoleMasterDTO.AdminSnPostID = model.AdminSnPostID;
                        model.AdminRoleMasterDTO.SanctPostName = model.AdminSnPostsIDWithName.Trim();
                        model.AdminRoleMasterDTO.IsAttendaceAllowFromOutside = Convert.ToBoolean(model.IsAttendaceAllowFromOutside);
                        model.AdminRoleMasterDTO.IsLoginAllowFromOutside = Convert.ToBoolean(model.IsLoginAllowFromOutside);   
                        model.AdminRoleMasterDTO.MonitoringLevel = model.MonitoringLevel;                      
                        model.AdminRoleMasterDTO.IsSuperUser = Convert.ToBoolean(model.IsSuperUser);
                        model.AdminRoleMasterDTO.IsAcadMgr = Convert.ToBoolean(model.IsAcadMgr);
                        model.AdminRoleMasterDTO.IsEstMgr = Convert.ToBoolean(model.IsEstMgr);
                        model.AdminRoleMasterDTO.IsFinMgr = Convert.ToBoolean(model.IsFinMgr);
                        model.AdminRoleMasterDTO.IsAdmMgr = Convert.ToBoolean(model.IsAdmMgr);                      
                        model.AdminRoleMasterDTO.IsActive = true;
                        model.AdminRoleMasterDTO.AdminRoleMasterID = 0;
                        model.AdminRoleMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);// model.CreatedBy;                  
                        if (model.MonitoringLevel == "Self")
                        {
                            model.AdminRoleMasterDTO.IDs = model.selectItemRightsIDs;
                            model.AdminRoleMasterDTO.OthCentreLevel = string.Empty;
                        }
                        else if (model.MonitoringLevel == "Other")
                        {
                            model.AdminRoleMasterDTO.IDs = model.selectItemRightsIDs;
                            model.OthCentreLevel = "Selected";
                        }
                        IBaseEntityResponse<AdminRoleMaster> response = _adminRoleMasterBA.InsertAdminRoleMaster(model.AdminRoleMasterDTO);
                        model.AdminRoleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }                   
                    return Json(model.AdminRoleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID,string CentreCode,string CentreName)
        {
            try
            {
                AdminRoleMasterViewModel model = new AdminRoleMasterViewModel();
                AdminSnPostsViewModel adminSnPostsmodel = new AdminSnPostsViewModel();
                model.AdminRoleMasterDTO = new AdminRoleMaster();
                model.AdminRoleMasterDTO.ID = ID;
                model.AdminRoleMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AdminRoleMaster> response = _adminRoleMasterBA.SelectByID(model.AdminRoleMasterDTO);

                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = Resources.DisplayName_Self, Value = "Self" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Other, Value = "Other" });

                if (response != null && response.Entity != null)
                {
                    model.AdminRoleMasterDTO.ID = response.Entity.ID;
                    model.AdminRoleMasterDTO.AdminSnPostID = response.Entity.AdminSnPostID;
                    model.AdminRoleMasterDTO.SanctPostName = response.Entity.SanctPostName;
                    ViewData["MonitoringLevel"] = new SelectList(li, "Text", "Value", response.Entity.MonitoringLevel);
                    model.AdminRoleMasterDTO.MonitoringLevel = response.Entity.MonitoringLevel;
                    model.AdminRoleMasterDTO.AdminRoleCode = response.Entity.AdminRoleCode;
                    // model.AdminRoleMasterDTO.OthCentreLevel = response.Entity.OthCentreLevel;
                    model.AdminRoleMasterDTO.IsSuperUser = response.Entity.IsSuperUser;
                    model.AdminRoleMasterDTO.IsAcadMgr = response.Entity.IsAcadMgr;
                    model.AdminRoleMasterDTO.IsEstMgr = response.Entity.IsEstMgr;
                    model.AdminRoleMasterDTO.IsFinMgr = response.Entity.IsFinMgr;
                    model.AdminRoleMasterDTO.IsAdmMgr = response.Entity.IsAdmMgr;
                    model.AdminRoleMasterDTO.IsLoginAllowFromOutside = response.Entity.IsLoginAllowFromOutside;
                    model.AdminRoleMasterDTO.IsAttendaceAllowFromOutside = response.Entity.IsAttendaceAllowFromOutside;
                    model.AdminRoleMasterDTO.IsActive = response.Entity.IsActive;
                    model.AdminRoleMasterDTO.DesignationType = response.Entity.DesignationType; 
                    model.ListDemo = GetListAdminRoleCentreRightsByAdminRole(response.Entity.ID);
                    model.DefaultRightsType = GetListAdminRoleRightsTypeDefault(response.Entity.ID);
                    model.CentreCodeWithName = CentreName.Replace('~',' ');
                    string[] splitCentreCode = CentreCode.Split(':');
                    model.CentreCode = splitCentreCode[0];
                    model.AdminRoleMasterDTO.AdminRoleMasterID = response.Entity.AdminRoleMasterID;
                }
                return PartialView("/Views/Admin/AdminRoleMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AdminRoleMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AdminRoleMasterDTO != null)
                    {
                        if (model != null && model.AdminRoleMasterDTO != null)
                        {
                            model.AdminRoleMasterDTO.ConnectionString = _connectioString;
                            model.AdminRoleMasterDTO.ID = model.ID;
                            model.AdminRoleMasterDTO.AdminSnPostID = model.AdminSnPostID;
                            model.AdminRoleMasterDTO.SanctPostName = model.SanctPostName.Trim();
                            model.AdminRoleMasterDTO.MonitoringLevel = model.MonitoringLevel;
                            //model.AdminRoleMasterDTO.AdminRoleCode = model.AdminRoleCode;
                            //model.AdminRoleMasterDTO.OthCentreLevel = model.OthCentreLevel;
                            model.AdminRoleMasterDTO.IsSuperUser = model.IsSuperUser;
                            model.AdminRoleMasterDTO.IsAcadMgr = model.IsAcadMgr;
                            model.AdminRoleMasterDTO.IsEstMgr = model.IsEstMgr;
                            model.AdminRoleMasterDTO.IsFinMgr = model.IsFinMgr;
                            model.AdminRoleMasterDTO.IsAdmMgr = model.IsAdmMgr;
                            model.AdminRoleMasterDTO.IsLoginAllowFromOutside = model.IsLoginAllowFromOutside;
                            model.AdminRoleMasterDTO.IsAttendaceAllowFromOutside = model.IsAttendaceAllowFromOutside;
                            model.AdminRoleMasterDTO.IsActive = model.IsActive;
                            if (model.MonitoringLevel == "Self")
                            {
                                model.AdminRoleMasterDTO.IDs = model.selectItemRightsIDs;
                                model.AdminRoleMasterDTO.OthCentreLevel = string.Empty;
                            }
                            if (model.MonitoringLevel == "Other")
                            {
                                model.AdminRoleMasterDTO.IDs = model.selectItemRightsIDs;
                                model.OthCentreLevel = "Selected";
                            }
                            model.AdminRoleMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                            // model.AdminRoleMasterDTO.ModifiedDate = DateTime.Now;

                            IBaseEntityResponse<AdminRoleMaster> response = _adminRoleMasterBA.UpdateAdminRoleMaster(model.AdminRoleMasterDTO);
                            model.AdminRoleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.AdminRoleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        public ActionResult Delete(int ID)
        {
            try
            {
                AdminRoleMasterViewModel model = new AdminRoleMasterViewModel();
                model.AdminRoleMasterDTO = new AdminRoleMaster();
                model.AdminRoleMasterDTO.ID = ID;
                model.AdminRoleMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AdminRoleMaster> response = _adminRoleMasterBA.SelectByID(model.AdminRoleMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.AdminRoleMasterDTO.ID = response.Entity.ID;
                    model.AdminRoleMasterDTO.IsActive = response.Entity.IsActive;
                    model.AdminRoleMasterDTO.AdminRoleCode = response.Entity.AdminRoleCode;
                }
                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpPost]
        public ActionResult Delete(AdminRoleMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ID > 0)
                    {
                        AdminRoleMaster AdminRoleMasterDTO = new AdminRoleMaster();
                        AdminRoleMasterDTO.ConnectionString = _connectioString;
                        AdminRoleMasterDTO.ID = model.ID;
                        IBaseEntityResponse<AdminRoleMaster> response = _adminRoleMasterBA.DeleteAdminRoleMaster(AdminRoleMasterDTO);
                        model.AdminRoleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.AdminRoleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<AdminRoleMasterViewModel> GetAdminRoleMaster(string centerCode, int departmentId, out int TotalRecords)
        {
            try
            {
                AdminRoleMasterSearchRequest searchRequest = new AdminRoleMasterSearchRequest();
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
                List<AdminRoleMasterViewModel> listAdminRoleMasterViewModel = new List<AdminRoleMasterViewModel>();
                List<AdminRoleMaster> listAdminRoleMaster = new List<AdminRoleMaster>();
                IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollectionResponse = _adminRoleMasterBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAdminRoleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (AdminRoleMaster item in listAdminRoleMaster)
                        {
                            AdminRoleMasterViewModel AdminRoleMasterViewModel = new AdminRoleMasterViewModel();
                            AdminRoleMasterViewModel.AdminRoleMasterDTO = item;
                            listAdminRoleMasterViewModel.Add(AdminRoleMasterViewModel);
                        }
                    }
                    else if (baseEntityCollectionResponse.Message != null && baseEntityCollectionResponse.Message.Count > 0)
                    {
                        IMessageDTO errordto = baseEntityCollectionResponse.Message.FirstOrDefault();
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;
                return listAdminRoleMasterViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        protected List<AdminRoleMaster> GetListAdminRoleCentreRightsByAdminRole(int ID)
        {
            try
            {
                AdminRoleMasterSearchRequest searchRequest = new AdminRoleMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ID = ID;

                List<AdminRoleMaster> ListDemo = new List<AdminRoleMaster>();
                IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollectionResponse = _adminRoleMasterBA.GetCentreRightsByRole(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        ListDemo = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return ListDemo;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        protected List<AdminRoleMaster> GetListAdminRoleRightsTypeDefault(int ID)
        {
            try
            {
                AdminRoleMasterSearchRequest searchRequest = new AdminRoleMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ID = ID;

                List<AdminRoleMaster> ListDemo = new List<AdminRoleMaster>();
                IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollectionResponse = _adminRoleMasterBA.GetDefaultRoleRightsType(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        ListDemo = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return ListDemo;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param,string CentreCode,string DepartmentID)
        {           
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
                int TotalRecords;
                IEnumerable<AdminRoleMasterViewModel> filteredAdminRoleMaster;

                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                    filteredAdminRoleMaster = GetAdminRoleMaster(splitCentreCode[0], Convert.ToInt32(splitDepartmentID[0]), out TotalRecords);
                }
                else
                {
                    filteredAdminRoleMaster = new List<AdminRoleMasterViewModel>();
                    TotalRecords = 0;
                }            
               
                var records = filteredAdminRoleMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AdminRoleCode), Convert.ToString(c.SanctPostName), Convert.ToString(c.AdminSnPostID), Convert.ToString(c.ID), Convert.ToString(c.NoOfPosts), Convert.ToString(records.Count()) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
           
        }
        #endregion
    }
}
