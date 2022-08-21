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
    public class AdminSnPostsController : BaseController
    {
        IAdminSnPostsBA _adminSnPostsBA = null;
        AdminSnPostsBaseViewModel _adminSnPostsBaseViewModel = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AdminSnPostsController()
        {
            _adminSnPostsBA = new AdminSnPostsBA();
            _adminSnPostsBaseViewModel = new AdminSnPostsBaseViewModel();

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
                return View("/Views/Admin/AdminSnPosts/Index.cshtml");
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
                    return View("/Views/Admin/AdminSnPosts/Index.cshtml");
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
                AdminSnPostsBaseViewModel _adminSnPostsBaseViewModel = new AdminSnPostsBaseViewModel();
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
                        _adminSnPostsBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);

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
                        _adminSnPostsBaseViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _adminSnPostsBaseViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                }
                _adminSnPostsBaseViewModel.SelectedCentreCode = centerCode;
                _adminSnPostsBaseViewModel.SelectedDepartmentID = departmentID;
                foreach (var b in _adminSnPostsBaseViewModel.ListOrganisationDepartmentMaster)
                {
                    b.DeptID = b.ID + ":" + b.DepartmentName;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Admin/AdminSnPosts/List.cshtml", _adminSnPostsBaseViewModel);             
          
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
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            _adminSnPostsBaseViewModel.SelectedCentreName = splited[1];
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

        [HttpGet]
        public ActionResult Create(string CentreCode, string DepartmentID)
        {
            string cencode = _adminSnPostsBaseViewModel.SelectedCentreCode;

            AdminSnPostsViewModel model = new AdminSnPostsViewModel();
            try
            {
                //_designationId = designationId;
                //TempData["DesignationID"] = designationId;
                List<EmpDesignationMaster> empDesignationMasterList = GetListEmpDesignationMaster();
                List<SelectListItem> empDesignationMaster = new List<SelectListItem>();
                foreach (EmpDesignationMaster item in empDesignationMasterList)
                {
                    empDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID + ":" + item.Description });
                }
                ViewBag.EmpDesignationMaster = new SelectList(empDesignationMaster, "Value", "Text");

                List<SelectListItem> li = new List<SelectListItem>();
               // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "Temporary" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "Permanent" });
                ViewData["PostType"] = li;

                List<SelectListItem> li1 = new List<SelectListItem>();
               // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li1.Add(new SelectListItem { Text = Resources.DisplayNames_Regular, Value = "Active" });
                li1.Add(new SelectListItem { Text = Resources.DisplayNames_AddOn, Value = "Passive" });
                ViewData["DesignationType"] = li1;

                if (CentreCode != null)
                {
                    string[] splitCentreCode = CentreCode.Split(':');                   
                    model.CentreCode = splitCentreCode[0];
                    model.CentreCodeWithName = CentreCode;
                }
              
                if (DepartmentID != null)
                {
                    string[] splitdepartmentId = DepartmentID.Split(':');                   
                    model.DepartmentID = Convert.ToInt32(splitdepartmentId[0]);
                    model.DepartmentIdWithName = splitdepartmentId[1];                    
                }
                

            }
            catch (Exception)
            {

            }
            return PartialView("/Views/Admin/AdminSnPosts/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(AdminSnPostsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] SplitDesignation = model.DesignationIdWithName.Split(':');
                    string[] SplitDepartment = model.DepartmentIdWithName.Split(':');
                    if (model != null && model.AdminSnPostsDTO != null)
                    {
                      
                        model.AdminSnPostsDTO.ConnectionString = _connectioString;
                        model.AdminSnPostsDTO.DesignationID = Convert.ToInt32(SplitDesignation[0]);                        
                        model.AdminSnPostsDTO.DesignationType = model.DesignationType;
                        model.AdminSnPostsDTO.PostType = model.PostType;
                        string DesignationType = string.Empty;
                        if (model.DesignationType == "Active")
                        {
                            DesignationType = "Regular";
                        }
                        else
                        {
                            DesignationType = "Add-On";
                        }
                        model.AdminSnPostsDTO.SactionedPostDescription = Convert.ToString(SplitDesignation[1] + "-" + SplitDepartment[1] + "-" + Convert.ToString(model.PostType) + "-" + Convert.ToString(DesignationType));                       
                        model.AdminSnPostsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                        model.AdminSnPostsDTO.CentreCode = Convert.ToString(model.CentreCode);
                        model.AdminSnPostsDTO.DepartmentID = Convert.ToInt32(SplitDepartment[0]);                      
                        model.AdminSnPostsDTO.IsActive = true;

                        IBaseEntityResponse<AdminSnPosts> response = _adminSnPostsBA.InsertAdminSnPosts(model.AdminSnPostsDTO);
                        model.AdminSnPostsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }                
                    return Json(model.AdminSnPostsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            AdminSnPostsViewModel model = new AdminSnPostsViewModel();
            try
            {
                model.AdminSnPostsDTO = new AdminSnPosts();
                model.AdminSnPostsDTO.ID = id;
                model.AdminSnPostsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<AdminSnPosts> response = _adminSnPostsBA.SelectByID(model.AdminSnPostsDTO);

                if (response != null && response.Entity != null)
                {
                    model.AdminSnPostsDTO.ID = response.Entity.ID;
                    model.AdminSnPostsDTO.SactionedPostDescription = response.Entity.SactionedPostDescription;
                    model.AdminSnPostsDTO.IsActive = response.Entity.IsActive; 
                }
                return PartialView("/Views/Admin/AdminSnPosts/Edit.cshtml",model);
            }          
             catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AdminSnPostsViewModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            try
            {               
                    if (model != null && model.AdminSnPostsDTO != null)
                    {
                        if (model != null && model.AdminSnPostsDTO != null)
                        {
                            model.AdminSnPostsDTO.ConnectionString = _connectioString;                          
                            model.AdminSnPostsDTO.ID = model.ID;                          
                            model.AdminSnPostsDTO.IsActive = model.IsActive;
                            model.AdminSnPostsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);                                     
                            IBaseEntityResponse<AdminSnPosts> response = _adminSnPostsBA.UpdateAdminSnPosts(model.AdminSnPostsDTO);
                            model.AdminSnPostsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }          
                    return Json(model.AdminSnPostsDTO.errorMessage, JsonRequestBehavior.AllowGet);               
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        
        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            AdminSnPostsViewModel model = new AdminSnPostsViewModel();
            
                if (ID > 0)
                {
                    AdminSnPosts AdminSnPostsDTO = new AdminSnPosts();
                    AdminSnPostsDTO.ConnectionString = _connectioString;
                    AdminSnPostsDTO.ID = ID;
                    AdminSnPostsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AdminSnPosts> response = _adminSnPostsBA.DeleteAdminSnPosts(AdminSnPostsDTO);
                    model.AdminSnPostsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.AdminSnPostsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            

        }

        #endregion

        #region Methods
        [NonAction]
        public IEnumerable<AdminSnPostsViewModel> GetAdminSnPosts(string centerCode, int departmentId, out int TotalRecords)
        {
            AdminSnPostsSearchRequest searchRequest = new AdminSnPostsSearchRequest();
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
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode=centerCode;
                searchRequest.DepartmentID = departmentId;
            }
            List<AdminSnPostsViewModel> listAdminSnPostsViewModel = new List<AdminSnPostsViewModel>();
            List<AdminSnPosts> listAdminSnPosts = new List<AdminSnPosts>();
            IBaseEntityCollectionResponse<AdminSnPosts> baseEntityCollectionResponse = _adminSnPostsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminSnPosts = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (AdminSnPosts item in listAdminSnPosts)
                    {
                        AdminSnPostsViewModel adminSnPostsViewModel = new AdminSnPostsViewModel();
                        adminSnPostsViewModel.AdminSnPostsDTO = item;
                        listAdminSnPostsViewModel.Add(adminSnPostsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listAdminSnPostsViewModel;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedDepartmentID)
        {            
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
                int TotalRecords;
                IEnumerable<AdminSnPostsViewModel> filteredAdminSnPosts;

                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "SactionedPostDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "SactionedPostDescription Like '%" + param.sSearch + "%' or NoOfPosts Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;                  
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedDepartmentID))
                {
                    string[] splitCentreCode = SelectedCentreCode.Split(':');
                    string[] splitDepartmentID = SelectedDepartmentID.Split(':');
                    filteredAdminSnPosts = GetAdminSnPosts(splitCentreCode[0], Convert.ToInt32(splitDepartmentID[0]), out TotalRecords);
                }
                else
                {
                    filteredAdminSnPosts = new List<AdminSnPostsViewModel>();
                    TotalRecords = 0;
                }
             
                var records = filteredAdminSnPosts.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.SactionedPostDescription), Convert.ToString(c.ID),Convert.ToString(c.IsActive) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }  
        #endregion
    }
}

