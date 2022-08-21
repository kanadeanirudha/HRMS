using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using AERP.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;

namespace AERP.Web.UI.Controllers
{
    public class OrganisationCentrewiseDepartmentController : BaseController
    {
        IOrganisationCentrewiseDepartmentBA _organisationCentrewiseDepartmentBA = null;
        OrganisationCentrewiseDepartmentBaseViewModel _organisationCentrewiseDepartmentBaseViewModel = null;
        IOrganisationDepartmentMasterBA _orgDepartmentMasterBA = null;
        IAdminRoleMasterBA _AdminRoleMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationCentrewiseDepartmentController()
        {
            _orgDepartmentMasterBA = new OrganisationDepartmentMasterBA();
            _organisationCentrewiseDepartmentBA = new OrganisationCentrewiseDepartmentBA();
            _organisationCentrewiseDepartmentBaseViewModel = new OrganisationCentrewiseDepartmentBaseViewModel();
            _AdminRoleMasterBA = new AdminRoleMasterBA();
        }

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/Organisation/OrganisationCentrewiseDepartment/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string centreCode, string centreName, string actionMode)
        {
            try
            {
                OrganisationDepartmentMasterViewModel model = new OrganisationDepartmentMasterViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

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
                            a.CentreCode = item.CentreCode;
                            a.CentreName = item.CentreName;
                            model.ListGetAdminRoleApplicableCentre.Add(a);
                        
                    }
                }
                model.SelectedCentreCode = centreCode;
                
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Organisation/OrganisationCentrewiseDepartment/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string CentreCode, string centreName,string DepartmentName, int ID)
        {
            try
            {
                
                OrganisationCentrewiseDepartmentViewModel model = new OrganisationCentrewiseDepartmentViewModel();
                model.OrganisationCentrewiseDepartmentDTO.SelectedCentreName = centreName.Replace('~',' ');
                model.OrganisationCentrewiseDepartmentDTO.DepartmentName = DepartmentName.Replace('~', ' ');
                model.OrganisationCentrewiseDepartmentDTO.CentreCode = CentreCode.ToString();
                model.OrganisationCentrewiseDepartmentDTO.DepartmentID = ID;

                model.GetAdminRoleDomainList = GetListAdminRoleDomain(0);

                return PartialView("/Views/Organisation/OrganisationCentrewiseDepartment/Create.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(OrganisationCentrewiseDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationCentrewiseDepartmentDTO != null)
                    {
                        model.OrganisationCentrewiseDepartmentDTO.ConnectionString = _connectioString;
                        model.OrganisationCentrewiseDepartmentDTO.CentreCode = model.CentreCode;
                        model.OrganisationCentrewiseDepartmentDTO.DepartmentID = model.DepartmentID;
                     //   model.OrganisationCentrewiseDepartmentDTO.DepartmentSeqNo = model.DepartmentSeqNo;
                        model.OrganisationCentrewiseDepartmentDTO.ActiveFlag = model.ActiveFlag;
                        model.OrganisationCentrewiseDepartmentDTO.SelectedDomainIDs = model.SelectedDomainIDs;
                        model.OrganisationCentrewiseDepartmentDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationCentrewiseDepartment> response = _organisationCentrewiseDepartmentBA.InsertOrganisationCentrewiseDepartment(model.OrganisationCentrewiseDepartmentDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    model.CentreCodeWithName = model.CentreCode+'~'+model.SelectedCentreName;
                    return Json(model, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(string centreName, string DepartmentName, int CentrewiseDepartmentID)
        {
            try
            {
                OrganisationCentrewiseDepartmentViewModel model = new OrganisationCentrewiseDepartmentViewModel();
                model.OrganisationCentrewiseDepartmentDTO = new OrganisationCentrewiseDepartment();
                model.OrganisationCentrewiseDepartmentDTO.ID = CentrewiseDepartmentID;
                model.OrganisationCentrewiseDepartmentDTO.SelectedCentreName = centreName.Replace('~', ' ');
                model.OrganisationCentrewiseDepartmentDTO.DepartmentName = DepartmentName.Replace('~', ' ');
                model.OrganisationCentrewiseDepartmentDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<OrganisationCentrewiseDepartment> response = _organisationCentrewiseDepartmentBA.SelectByID(model.OrganisationCentrewiseDepartmentDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationCentrewiseDepartmentDTO.ID = response.Entity.ID;
                    model.OrganisationCentrewiseDepartmentDTO.ActiveFlag = response.Entity.ActiveFlag;
                    model.OrganisationCentrewiseDepartmentDTO.DepartmentID = response.Entity.DepartmentID;
                 //   model.OrganisationCentrewiseDepartmentDTO.DepartmentSeqNo = response.Entity.DepartmentSeqNo;
                    model.OrganisationCentrewiseDepartmentDTO.CentreCode = response.Entity.CentreCode;
                 
                }

                model.GetAdminRoleDomainList = GetListAdminRoleDomain(CentrewiseDepartmentID);

                return PartialView("/Views/Organisation/OrganisationCentrewiseDepartment/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(OrganisationCentrewiseDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationCentrewiseDepartmentDTO != null)
                    {
                        model.OrganisationCentrewiseDepartmentDTO.ConnectionString = _connectioString;
                        model.OrganisationCentrewiseDepartmentDTO.ID = model.ID;
                        model.OrganisationCentrewiseDepartmentDTO.CentreCode = model.CentreCode;
                        model.OrganisationCentrewiseDepartmentDTO.DepartmentID = model.DepartmentID;
                      //  model.OrganisationCentrewiseDepartmentDTO.DepartmentSeqNo = model.DepartmentSeqNo;
                        model.OrganisationCentrewiseDepartmentDTO.ActiveFlag = model.ActiveFlag;
                        model.OrganisationCentrewiseDepartmentDTO.SelectedDomainIDs = model.SelectedDomainIDs;
                        model.OrganisationCentrewiseDepartmentDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationCentrewiseDepartment> response = _organisationCentrewiseDepartmentBA.UpdateOrganisationCentrewiseDepartment(model.OrganisationCentrewiseDepartmentDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    model.CentreCodeWithName = model.CentreCode + '~' + model.SelectedCentreName;
                    return Json(model, JsonRequestBehavior.AllowGet);
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

        #region --------------Non Action methods--------------

        protected List<AdminRoleMaster> GetListAdminRoleDomain(int CentrewiseDepartmentID)
        {
            AdminRoleMasterSearchRequest searchRequest = new AdminRoleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleDomainForID = CentrewiseDepartmentID;
            searchRequest.AdminRoleDomainFor = "DEPARTMENT";
            List<AdminRoleMaster> listAdminRoleDomain = new List<AdminRoleMaster>();
            IBaseEntityCollectionResponse<AdminRoleMaster> baseEntityCollectionResponse = _AdminRoleMasterBA.GetAdminRoleDomainList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleDomain = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.AdminRoleDomainName).ToList();
                }
            }
            return listAdminRoleDomain;
        }

        [NonAction]
        protected List<OrganisationDepartmentMasterViewModel> listOrganisationCentrewiseDepartment(string centreCode, out int TotalRecords)
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
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
                    searchRequest.CentreCode = centreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centreCode;
            }
            List<OrganisationDepartmentMasterViewModel> listOrganisationDepartmentMasterViewModel = new List<OrganisationDepartmentMasterViewModel>();
            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _orgDepartmentMasterBA.GetByCentrewise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationDepartmentMaster item in listOrganisationDepartmentMaster)
                    {
                        OrganisationDepartmentMasterViewModel orgDepartmentMasterViewModel = new OrganisationDepartmentMasterViewModel();
                        orgDepartmentMasterViewModel.OrganisationDepartmentMasterDTO = item;
                        listOrganisationDepartmentMasterViewModel.Add(orgDepartmentMasterViewModel);
                    }
                }
            }
             TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationDepartmentMasterViewModel;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param,string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationDepartmentMasterViewModel> filteredOrganisationCentrewiseDepartment;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "DepartmentName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {
                filteredOrganisationCentrewiseDepartment = listOrganisationCentrewiseDepartment(SelectedCentreCode, out TotalRecords);
            }
            else
            {
                filteredOrganisationCentrewiseDepartment = new List<OrganisationDepartmentMasterViewModel>();
                TotalRecords = 0;
            }
           
            var displayedPosts = filteredOrganisationCentrewiseDepartment.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.DepartmentName.ToString(), c.CentrewiseDepartmentStatus.ToString(),Convert.ToString(c.CentrewiseDepartmentID), Convert.ToString(c.ID) };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}