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
    public class GeneralAllocateSaleProcessUnitController : BaseController
    {
        IGeneralAllocateSaleProcessUnitBA _GeneralAllocateSaleProcessUnitBA = null;
        IGeneralCityMasterBA _generalCityMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralAllocateSaleProcessUnitController()
        {
            _GeneralAllocateSaleProcessUnitBA = new GeneralAllocateSaleProcessUnitBA();
            _generalCityMasterBA = new GeneralCityMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralAllocateSaleProcessUnit/Index.cshtml");
            }else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string centerCode)
        {
            //try
            //{
            //    GeneralAllocateSaleProcessUnitViewModel model = new GeneralAllocateSaleProcessUnitViewModel();
            //    if (!string.IsNullOrEmpty(actionMode))
            //    {
            //        TempData["ActionMode"] = actionMode;
            //    }
            //    return PartialView("/Views/Inventory/GeneralAllocateSaleProcessUnit/List.cshtml", model);
            //}
            //catch (Exception ex)
            //{
            //    _logException.Error(ex.Message);
            //    throw;
            //}


            try
            {
                GeneralAllocateSaleProcessUnitViewModel model = new GeneralAllocateSaleProcessUnitViewModel();
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

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    // model.ListGetOrganisationDepartmentCentreAndRoleWise= GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                }
                model.SelectedCentreCode = centerCode;
                //model.SelectedDepartmentID = departmentID;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralAllocateSaleProcessUnit/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }


        }
        public ActionResult Create(string IDs)
        {
            
            GeneralAllocateSaleProcessUnitViewModel model = new GeneralAllocateSaleProcessUnitViewModel();
            //  model.GeneralUnitTypeID = Convert.ToInt16(IDs);

            string[] IDsArray = IDs.Split('~');
            model.SalesUnitID =Convert.ToInt16(IDsArray[0]);
            model.UnitName = IDsArray[1];
            model.CentreCode = IDsArray[2];
            string centreCode = model.CentreCode;
            List<GeneralAllocateSaleProcessUnit> GeneralAllocateSaleProcess = GetListGeneralAllocateSaleProcessForProcessUnit(centreCode);
            List<SelectListItem> GeneralAllocateSaleProcessUnitList = new List<SelectListItem>();
            GeneralAllocateSaleProcessUnitList.Add(new SelectListItem { Text = "---Select Process Unit ---", Value = Convert.ToString(0) });
            foreach (GeneralAllocateSaleProcessUnit item in GeneralAllocateSaleProcess)
            {
                GeneralAllocateSaleProcessUnitList.Add(new SelectListItem { Text = item.ProcessUnitName, Value = Convert.ToString(item.SalesUnitProssessID) });
            }
            ViewBag.GeneralAllocateSaleProcessUnitList = new SelectList(GeneralAllocateSaleProcessUnitList, "Value", "Text");

            return PartialView("/Views/Inventory/GeneralAllocateSaleProcessUnit/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralAllocateSaleProcessUnitViewModel model)
        {
            try
            {
                if (model != null && model.GeneralAllocateSaleProcessUnitDTO != null)
                {
                    model.GeneralAllocateSaleProcessUnitDTO.ConnectionString = _connectioString;
                    model.GeneralAllocateSaleProcessUnitDTO.SalesUnitProssessID = model.SalesUnitProssessID;
                    model.GeneralAllocateSaleProcessUnitDTO.SalesUnitID = model.SalesUnitID;
                    model.GeneralAllocateSaleProcessUnitDTO.AllocatedUptoDate = model.AllocatedUptoDate;
                    model.GeneralAllocateSaleProcessUnitDTO.AllocatedFromDate = model.AllocatedFromDate;
                    model.GeneralAllocateSaleProcessUnitDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralAllocateSaleProcessUnit> response = _GeneralAllocateSaleProcessUnitBA.InsertGeneralAllocateSaleProcessUnit(model.GeneralAllocateSaleProcessUnitDTO);
                    model.GeneralAllocateSaleProcessUnitDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralAllocateSaleProcessUnitDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        [HttpGet]
        public ActionResult ViewDetails(Int16 id)
        {
            GeneralAllocateSaleProcessUnitViewModel model = new GeneralAllocateSaleProcessUnitViewModel();
            try
            {
                model.GeneralAllocateSaleProcessUnitDTO = new GeneralAllocateSaleProcessUnit();
                model.GeneralAllocateSaleProcessUnitDTO.ID = id;
                model.GeneralAllocateSaleProcessUnitDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralAllocateSaleProcessUnit> response = _GeneralAllocateSaleProcessUnitBA.SelectByID(model.GeneralAllocateSaleProcessUnitDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralAllocateSaleProcessUnitDTO.ID = response.Entity.ID;
                    model.GeneralAllocateSaleProcessUnitDTO.ProcessUnitName = response.Entity.ProcessUnitName;
                    model.GeneralAllocateSaleProcessUnitDTO.UnitName = response.Entity.UnitName;
                    model.GeneralAllocateSaleProcessUnitDTO.AllocatedFromDate = response.Entity.AllocatedFromDate;
                    model.GeneralAllocateSaleProcessUnitDTO.AllocatedUptoDate = response.Entity.AllocatedUptoDate;
                    
                    model.GeneralAllocateSaleProcessUnitDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/GeneralAllocateSaleProcessUnit/View.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralAllocateSaleProcessUnit> response = null;
                GeneralAllocateSaleProcessUnit GeneralAllocateSaleProcessUnitDTO = new GeneralAllocateSaleProcessUnit();
                GeneralAllocateSaleProcessUnitDTO.ConnectionString = _connectioString;
                GeneralAllocateSaleProcessUnitDTO.ID = ID;
                GeneralAllocateSaleProcessUnitDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralAllocateSaleProcessUnitBA.DeleteGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnitDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        //drop down for process unit
        protected List<GeneralAllocateSaleProcessUnit> GetListGeneralAllocateSaleProcessForProcessUnit(string centreCode)
        {
            GeneralAllocateSaleProcessUnitSearchRequest searchRequest = new GeneralAllocateSaleProcessUnitSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralAllocateSaleProcessUnit> listGeneralIndustryMaster = new List<GeneralAllocateSaleProcessUnit>();
            searchRequest.CentreCode = centreCode;
            IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> baseEntityCollectionResponse = _GeneralAllocateSaleProcessUnitBA.GetGeneralAllocateSaleProcessUnitSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralIndustryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralIndustryMaster;
        }



        public IEnumerable<GeneralAllocateSaleProcessUnitViewModel> GetGeneralAllocateSaleProcessUnit(out int TotalRecords, string centreCode)
        {
            GeneralAllocateSaleProcessUnitSearchRequest searchRequest = new GeneralAllocateSaleProcessUnitSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.UnitName,B.CreatedDate";
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
            List<GeneralAllocateSaleProcessUnitViewModel> listGeneralAllocateSaleProcessUnitViewModel = new List<GeneralAllocateSaleProcessUnitViewModel>();
            List<GeneralAllocateSaleProcessUnit> listGeneralAllocateSaleProcessUnit = new List<GeneralAllocateSaleProcessUnit>();
            IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> baseEntityCollectionResponse = _GeneralAllocateSaleProcessUnitBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralAllocateSaleProcessUnit = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralAllocateSaleProcessUnit item in listGeneralAllocateSaleProcessUnit)
                    {
                        GeneralAllocateSaleProcessUnitViewModel GeneralAllocateSaleProcessUnitViewModel = new GeneralAllocateSaleProcessUnitViewModel();
                        GeneralAllocateSaleProcessUnitViewModel.GeneralAllocateSaleProcessUnitDTO = item;
                        listGeneralAllocateSaleProcessUnitViewModel.Add(GeneralAllocateSaleProcessUnitViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralAllocateSaleProcessUnitViewModel;
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

                IEnumerable<GeneralAllocateSaleProcessUnitViewModel> filteredCountryMaster;

                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.UnitName,A.GeneralUnitsID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.UnitName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.UnitName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.UnitName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.AllocatedFromDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.UnitName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "B.AllocatedUptoDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.UnitName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;


                if (!string.IsNullOrEmpty(SelectedCentreCode))
                //if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedDepartmentID))
                {
                    filteredCountryMaster = GetGeneralAllocateSaleProcessUnit(out TotalRecords, SelectedCentreCode);
                    // filteredCountryMaster = GetGeneralUnits(out TotalRecords, SelectedCentreCode, SelectedDepartmentID);
                }
                else
                {
                    filteredCountryMaster = new List<GeneralAllocateSaleProcessUnitViewModel>();
                    TotalRecords = 0;
                }
                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<GeneralAllocateSaleProcessUnitViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.GeneralUnitsID), Convert.ToString(c.UnitName), Convert.ToString(c.ProcessUnitName), Convert.ToString(c.ID), Convert.ToString(c.AllocatedFromDate), Convert.ToString(c.AllocatedUptoDate), Convert.ToString(c.CentreCode) };

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