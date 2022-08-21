using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AERP.Common;
using System.Web.UI.WebControls;


namespace AERP.Web.UI.Controllers
{
    public class AdminRoleMenuDetailsController : BaseController
    {
        IAdminRoleMenuDetailsBA _AdminRoleMenuDetailsBA = null;
        IAdminSnPostsBA _adminSnPostsBA= null;
        AdminRoleMenuDetailsBaseViewModel _AdminRoleMenuDetailsBaseViewModel = null;
        AdminRoleMenuDetailsViewModel _AdminRoleMenuDetailsViewModel = null;
        AdminSnPostsViewModel _adminSnPostsViewModel = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        string _designationId = string.Empty;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AdminRoleMenuDetailsController()
        {
            _AdminRoleMenuDetailsBA = new AdminRoleMenuDetailsBA();
            _AdminRoleMenuDetailsBaseViewModel = new AdminRoleMenuDetailsBaseViewModel();
            _AdminRoleMenuDetailsViewModel = new AdminRoleMenuDetailsViewModel();
            _adminSnPostsViewModel = new AdminSnPostsViewModel();
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
                return View("/Views/Admin/AdminRoleMenuDetails/Index.cshtml");
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
                    return View("/Views/Admin/AdminRoleMenuDetails/Index.cshtml");
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
                AdminRoleMenuDetailsBaseViewModel _adminRoleMenuDetailsBaseViewModel = new AdminRoleMenuDetailsBaseViewModel();
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
                        _adminRoleMenuDetailsBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
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
                        _adminRoleMenuDetailsBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _adminRoleMenuDetailsBaseViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                }
                _adminRoleMenuDetailsBaseViewModel.SelectedCentreCodeforRoleMaster = centerCode;
                _adminRoleMenuDetailsBaseViewModel.SelectedDepartmentIDforRoleMaster = departmentID;
                foreach (var b in _adminRoleMenuDetailsBaseViewModel.ListOrganisationDepartmentMaster)
                {
                    b.DeptID = b.ID + ":" + b.DepartmentName;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Admin/AdminRoleMenuDetails/List.cshtml", _adminRoleMenuDetailsBaseViewModel);

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
                _AdminRoleMenuDetailsBaseViewModel.SelectedCentreNameforRoleMaster = splited[1];
                string _SelectedCentreCode = splited[0];
                if (String.IsNullOrEmpty(SelectedCentreCodeforRoleMaster))
                {
                    throw new ArgumentNullException("SelectedCentreCodeforRoleMaster");
                }
                int id = 0;
                bool isValid = Int32.TryParse(_SelectedCentreCode, out id);
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

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetListAdminMenuDetails1(int ModuleID, int AdminRoleMasterID)
        {
            try
            {
                AdminRoleMenuDetailsViewModel model = new AdminRoleMenuDetailsViewModel();
                List<AdminRoleMenuDetails> AdminModuleList = GetListAdminModule();
                List<SelectListItem> AdminModule = new List<SelectListItem>();
                model.AdminRoleMenuDetailsDTO.AdminRoleMasterID = AdminRoleMasterID;
                model.AdminRoleMenuDetailsDTO.AdminRoleCode = Session["AdminRoleCode"].ToString();
                foreach (AdminRoleMenuDetails item in AdminModuleList)
                {
                    AdminModule.Add(new SelectListItem { Text = item.ModuleName, Value = item.ModuleID.ToString() });
                }

                ViewBag.AdminModuleList = new SelectList(AdminModule, "Value", "Text");
                //for Menu List
                model.AdminMenuDetailsList = GetListAdminMenuDetails(ModuleID, AdminRoleMasterID);
                model.ModuleID = ModuleID;
                // return Json( JsonRequestBehavior.AllowGet);
                return PartialView("/Views/Admin/AdminRoleMenuDetails/Create.cshtml", model);
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
        public ActionResult Create(string IDs)
        {
            try
            {
                AdminRoleMenuDetailsViewModel model = new AdminRoleMenuDetailsViewModel();

                //For Module List
                // model.AdminRoleMasterID = IDs;
                string[] Array = IDs.Split('~');
                Session["AdminRoleCode"] = Array[1];

                model.AdminRoleMenuDetailsDTO.AdminRoleMasterID = Convert.ToInt32(Array[0]);
                model.AdminRoleMenuDetailsDTO.AdminRoleCode = Array[1].ToString();
                List<AdminRoleMenuDetails> AdminModuleList = GetListAdminModule();
                List<SelectListItem> AdminModule = new List<SelectListItem>();
                foreach (AdminRoleMenuDetails item in AdminModuleList)
                {
                    AdminModule.Add(new SelectListItem { Text = item.ModuleName, Value = item.ModuleID.ToString() });
                }

                ViewBag.AdminModuleList = new SelectList(AdminModule, "Value", "Text");

                //for Menu List
                model.AdminMenuDetailsList = GetListAdminMenuDetails(0, 0);

                return PartialView("/Views/Admin/AdminRoleMenuDetails/Create.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AdminRoleMenuDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AdminRoleMenuDetailsDTO != null)
                    {
                        model.AdminRoleMenuDetailsDTO.ConnectionString = _connectioString;
                        model.AdminRoleMenuDetailsDTO.AdminRoleMasterID = model.AdminRoleMasterID;
                        model.AdminRoleMenuDetailsDTO.AdminRoleCode = model.AdminRoleCode;
                        model.AdminRoleMenuDetailsDTO.SelectedTreeViewIDs = model.SelectedTreeViewIDs;
                        model.AdminRoleMenuDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                        IBaseEntityResponse<AdminRoleMenuDetails> response = _AdminRoleMenuDetailsBA.InsertAdminRoleMenuDetails(model.AdminRoleMenuDetailsDTO);
                        model.AdminRoleMenuDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.AdminRoleMenuDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<AdminRoleMenuDetailsViewModel> GetAdminRoleMenuDetails(string centerCode, int departmentId, out int TotalRecords)
        {
            try
            {
                AdminRoleMenuDetailsSearchRequest searchRequest = new AdminRoleMenuDetailsSearchRequest();
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

                List<AdminRoleMenuDetailsViewModel> listAdminRoleMenuDetailsViewModel = new List<AdminRoleMenuDetailsViewModel>();
                List<AdminRoleMenuDetails> listAdminRoleMenuDetails = new List<AdminRoleMenuDetails>();
                IBaseEntityCollectionResponse<AdminRoleMenuDetails> baseEntityCollectionResponse = _AdminRoleMenuDetailsBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAdminRoleMenuDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (AdminRoleMenuDetails item in listAdminRoleMenuDetails)
                        {
                            AdminRoleMenuDetailsViewModel AdminRoleMenuDetailsViewModel = new AdminRoleMenuDetailsViewModel();
                            AdminRoleMenuDetailsViewModel.AdminRoleMenuDetailsDTO = item;
                            listAdminRoleMenuDetailsViewModel.Add(AdminRoleMenuDetailsViewModel);
                        }
                    }
                    else if (baseEntityCollectionResponse.Message != null && baseEntityCollectionResponse.Message.Count > 0)
                    {
                        IMessageDTO errordto = baseEntityCollectionResponse.Message.FirstOrDefault();
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;
                return listAdminRoleMenuDetailsViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        protected List<AdminRoleMenuDetails> GetListAdminMenuDetails(int ModuleID, int AdminRoleMasterID)
        {
            try
            {
                AdminRoleMenuDetailsSearchRequest searchRequest = new AdminRoleMenuDetailsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ModuleID = ModuleID;
                searchRequest.AdminRoleMasterID = AdminRoleMasterID;
                List<AdminRoleMenuDetails> AdminMenuList = new List<AdminRoleMenuDetails>();
                IBaseEntityCollectionResponse<AdminRoleMenuDetails> baseEntityCollectionResponse = _AdminRoleMenuDetailsBA.GetBySearchAdminMenuList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        AdminMenuList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return AdminMenuList;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        protected List<AdminRoleMenuDetails> GetListAdminModule()
        {
            try
            {
                AdminRoleMenuDetailsSearchRequest searchRequest = new AdminRoleMenuDetailsSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                List<AdminRoleMenuDetails> listAdminModule = new List<AdminRoleMenuDetails>();
                IBaseEntityCollectionResponse<AdminRoleMenuDetails> baseEntityCollectionResponse = _AdminRoleMenuDetailsBA.GetBySearchModuleList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAdminModule = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listAdminModule;
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
                IEnumerable<AdminRoleMenuDetailsViewModel> filteredAdminRoleMenuDetails;

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
                            _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                            _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "DesignationType,DesignationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "AdminRoleCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                filteredAdminRoleMenuDetails = GetAdminRoleMenuDetails(Convert.ToString(Convert.ToString(splitCentreCode[0])), Convert.ToInt32(splitDepartmentID[0]), out TotalRecords);
                }
                  else
                  {
                      filteredAdminRoleMenuDetails = new List<AdminRoleMenuDetailsViewModel>();
                      TotalRecords = 0;
                  }   
               
                var records = filteredAdminRoleMenuDetails.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.DesignationName, c.AdminRoleCode.ToString(), c.DesignationType, Convert.ToString(c.AdminRoleMasterID + "~" + c.AdminRoleCode) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);           
        }
        #endregion
    }
}
