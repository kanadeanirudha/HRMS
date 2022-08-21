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
using AERP.DataProvider;
namespace AERP.Web.UI.Controllers
{
    public class GeneralOperatorRelatedRoleController : BaseController
    {
        IGeneralOperatorRelatedRoleBA _GeneralOperatorRelatedRoleBA = null;
        IOrganisationStudyCentreMasterBA _organisationStudyCentreMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralOperatorRelatedRoleController()
        {
            _GeneralOperatorRelatedRoleBA = new GeneralOperatorRelatedRoleBA();
            _organisationStudyCentreMasterBA = new OrganisationStudyCentreMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralOperatorRelatedRole/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string centerCode)
        {
            try
            {
                GeneralOperatorRelatedRoleViewModel model = new GeneralOperatorRelatedRoleViewModel();
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

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByStoreManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }
                model.SelectedCentreCode = centerCode;

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralOperatorRelatedRole/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string CentreCode)
        {
            GeneralOperatorRelatedRoleViewModel model = new GeneralOperatorRelatedRoleViewModel();
            model.CentreCode = CentreCode;


            List<GeneralOperatorRelatedRole> AdminRoleCode = GetListAdminRoleCode(CentreCode);
            List<SelectListItem> AdminRoleCodeList = new List<SelectListItem>();
            foreach (GeneralOperatorRelatedRole item in AdminRoleCode)
            {
                AdminRoleCodeList.Add(new SelectListItem { Text = item.AdminRoleCode, Value = Convert.ToString(item.AdminRoleMasterID) });
            }
            ViewBag.AdminRoleCodeList = new SelectList(AdminRoleCodeList, "Value", "Text");

            return PartialView("/Views/Inventory/GeneralOperatorRelatedRole/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralOperatorRelatedRoleViewModel model, string CentreCode)
        {
            try
            {
                if (model != null && model.GeneralOperatorRelatedRoleDTO != null)
                {
                    model.GeneralOperatorRelatedRoleDTO.ConnectionString = _connectioString;
                    model.GeneralOperatorRelatedRoleDTO.AdminRoleMasterID = model.AdminRoleMasterID;
                    model.GeneralOperatorRelatedRoleDTO.CentreCode = CentreCode;
                    if (!string.IsNullOrEmpty(CentreCode))
                    {
                        string[] splitCentreCode = CentreCode.Split(':');
                        model.CentreCode = splitCentreCode[0];
                    }
                    else
                    {
                        model.CentreCode = CentreCode;
                    }
                    model.GeneralOperatorRelatedRoleDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralOperatorRelatedRole> response = _GeneralOperatorRelatedRoleBA.InsertGeneralOperatorRelatedRole(model.GeneralOperatorRelatedRoleDTO);
                    model.GeneralOperatorRelatedRoleDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralOperatorRelatedRoleDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                return Json("Please review your form");

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Edit(Int16 id)
        {
            try
            {
                GeneralOperatorRelatedRoleViewModel model = new GeneralOperatorRelatedRoleViewModel();
                model.GeneralOperatorRelatedRoleDTO.ConnectionString = _connectioString;
                model.GeneralOperatorRelatedRoleDTO.ID = id;
                model.GeneralOperatorRelatedRoleDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<GeneralOperatorRelatedRole> response = _GeneralOperatorRelatedRoleBA.UpdateGeneralOperatorRelatedRole(model.GeneralOperatorRelatedRoleDTO);
                model.GeneralOperatorRelatedRoleDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(model.GeneralOperatorRelatedRoleDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        #endregion

        // Non-Action Method
        #region Methods

        protected List<GeneralOperatorRelatedRole> GetListAdminRoleCode(string CentreCode)
        {
            GeneralOperatorRelatedRoleSearchRequest searchRequest = new GeneralOperatorRelatedRoleSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            if (!string.IsNullOrEmpty(CentreCode))
            {
                string[] splitCentreCode = CentreCode.Split(':');
                searchRequest.CentreCode = splitCentreCode[0];
                //model.EntityLevel = splitCentreCode[1];
            }
            else
            {
                searchRequest.CentreCode = CentreCode;
                //model.EntityLevel = null;
            }
            List<GeneralOperatorRelatedRole> listtGeneralPriceGroup = new List<GeneralOperatorRelatedRole>();
            IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> baseEntityCollectionResponse = _GeneralOperatorRelatedRoleBA.GetAdminRoleCodeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }
        public IEnumerable<GeneralOperatorRelatedRole> GetGeneralOperatorRelatedRole(string centreCode, out int TotalRecords)
        {
            GeneralOperatorRelatedRoleSearchRequest searchRequest = new GeneralOperatorRelatedRoleSearchRequest();
            List<GeneralOperatorRelatedRole> listGeneralOperatorRelatedRole = new List<GeneralOperatorRelatedRole>();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                string[] Centre_code = centreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
            }
            IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> baseEntityCollectionResponse = _GeneralOperatorRelatedRoleBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralOperatorRelatedRole = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralOperatorRelatedRole;
        }



        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<GeneralOperatorRelatedRole> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.AdminRoleCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.AdminRoleCode like '%'";
                        }
                        else
                        {
                            _searchBy = "B.AdminRoleCode Like '%" + param.sSearch + "%' or B.AdminRoleCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.AdminRoleCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AdminRoleCode Like '%" + param.sSearch + "%' or B.AdminRoleCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(SelectedCentreCode))
                {
                    filteredCountryMaster = GetGeneralOperatorRelatedRole(SelectedCentreCode, out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<GeneralOperatorRelatedRole>();
                    TotalRecords = 0;
                }

                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<GeneralOperatorRelatedRole>();
                    TotalRecords = 0;
                }
                //if ((filteredCountryMaster.Count()) == 0)
                //{
                //    filteredCountryMaster = new List<GeneralOperatorRelatedRoleViewModel>();
                //    TotalRecords = 0;
                //}

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AdminRoleMasterID), Convert.ToString(c.AdminRoleCode), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}