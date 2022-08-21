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
using System.IO;
using System.Web.Hosting;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf.parser;
using System.Web;
using iTextSharp.text.html;

namespace AERP.Web.UI.Controllers
{
    public class ReplenishmentController : BaseController
    {
        IPurchaseReplenishmentBA _PurchaseReplenishmentBA = null;
        IGeneralUnitsBA _GeneralUnitsBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public ReplenishmentController()
        {
            _PurchaseReplenishmentBA = new PurchaseReplenishmentBA();
            _GeneralUnitsBA = new GeneralUnitsBA();

        }

        // Controller Methods
        #region ---------------Controller Methods------------------
        public ActionResult Index(string CentreCode, string GeneralUnitsID)
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0)
            {
                PurchaseReplenishmentViewModel model = new PurchaseReplenishmentViewModel();

                model.GeneralUnitsID = Convert.ToInt16(GeneralUnitsID);
                model.SelectedCentreCode = CentreCode;
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

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByPurchaseManager(AdminRoleMasterID);
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
                if (!string.IsNullOrEmpty(CentreCode))
                {
                    string[] splitCentreCode = CentreCode.Split(':');
                    model.CentreCode = splitCentreCode[0];
                }
                model.ListGeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);



                //List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);
                //List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
                //foreach (GeneralUnits item in GeneralUnits)
                //{
                //    GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
                //}
                //ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");

                return View("/Views/Purchase/PurchaseReplenishment/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string GeneralUnitsID)
        {
            try
            {
                PurchaseReplenishmentViewModel model = new PurchaseReplenishmentViewModel();
                model.GeneralUnitsID = Convert.ToInt16(GeneralUnitsID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                return PartialView("/Views/Purchase/PurchaseReplenishment/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            PurchaseReplenishmentViewModel model = new PurchaseReplenishmentViewModel();

            return PartialView("/Views/Purchase/PurchaseReplenishment/Create.cshtml", model);
        }

        [HttpGet]
        public ActionResult ViewPurchaseReplenishment()
        {
            PurchaseReplenishmentViewModel model = new PurchaseReplenishmentViewModel();

            PurchaseReplenishmentSearchRequest searchRequest = new PurchaseReplenishmentSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            IBaseEntityCollectionResponse<PurchaseReplenishment> baseEntityCollectionResponse = _PurchaseReplenishmentBA.SelectByPurchaseGRNMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    // model.PurchaseRequisitionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }

            return PartialView("/Views/Purchase/PurchaseReplenishment/ViewPurchaseReplenishment.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(PurchaseReplenishmentViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    model.PurchaseReplenishmentDTO.ConnectionString = _connectioString;
                    model.PurchaseReplenishmentDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseReplenishment> response = _PurchaseReplenishmentBA.InsertPurchaseReplenishment(model.PurchaseReplenishmentDTO);
                    //errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    //return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    model.PurchaseReplenishmentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.PurchaseReplenishmentDTO.errorMessage, JsonRequestBehavior.AllowGet);

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

        public ActionResult GetListForReplenishmentData(string GeneralUnitsID)
        {
            var department = GetReplenishmentData(GeneralUnitsID);
            var result = (from s in department
                          select new
                          {
                              Vendor = s.Vendor,
                              ItemCount = s.ItemCount,
                              Price = s.Price,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<PurchaseReplenishment> GetReplenishmentData(string GeneralUnitsID)
        {
            PurchaseReplenishmentSearchRequest searchRequest = new PurchaseReplenishmentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            List<PurchaseReplenishment> ListPurchaseReplenishment = new List<PurchaseReplenishment>();
            IBaseEntityCollectionResponse<PurchaseReplenishment> baseEntityCollectionResponse = _PurchaseReplenishmentBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListPurchaseReplenishment = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListPurchaseReplenishment;
        }
        #endregion


        #region ----------------------Methods----------------------

        public ActionResult GetGeneralUnitsForItemmasterList(string CentreCode)
        {

            var UOMCodeDesc = GetGeneralUnitsForItemmaster(CentreCode);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UnitName

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<PurchaseReplenishmentViewModel> GetPurchaseReplenishment(out int TotalRecords, int GeneralUnitsID)
        {
            PurchaseReplenishmentSearchRequest searchRequest = new PurchaseReplenishmentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            searchRequest.GeneralUnitsID = GeneralUnitsID;
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = "Desc";

                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
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


            }
            List<PurchaseReplenishmentViewModel> listPurchaseReplenishmentViewModel = new List<PurchaseReplenishmentViewModel>();
            List<PurchaseReplenishment> listPurchaseReplenishment = new List<PurchaseReplenishment>();
            IBaseEntityCollectionResponse<PurchaseReplenishment> baseEntityCollectionResponse = _PurchaseReplenishmentBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseReplenishment = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (PurchaseReplenishment item in listPurchaseReplenishment)
                    {
                        PurchaseReplenishmentViewModel PurchaseReplenishmentViewModel = new PurchaseReplenishmentViewModel();
                        PurchaseReplenishmentViewModel.PurchaseReplenishmentDTO = item;
                        listPurchaseReplenishmentViewModel.Add(PurchaseReplenishmentViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPurchaseReplenishmentViewModel;
        }

        [NonAction]


        protected List<GeneralUnits> GetGeneralUnitsForItemmaster(string CentreCode)
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = new BaseEntityCollectionResponse<GeneralUnits>();

            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchList(searchRequest);
            }
            else if (Convert.ToInt32(Session["Store Manager:Entity"]) > 0)
            {
                if (Session["RoleID"] == null)
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchListByAdminRoleIDAndCentre(searchRequest);
            }

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }

        #endregion

        // AjaxHandler Method
        #region ------------------AjaxHandler----------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int GeneralUnitsID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<PurchaseReplenishmentViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.Vender";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.Vender Like '%" + param.sSearch + "%' or cte2.Price Like '%" + param.sSearch + "%' or cte2.ItemCount Like '%" + param.sSearch + "%'";

                        }
                        break;
                    case 1:
                        _sortBy = "cte2.ItemCount";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.Vender Like '%" + param.sSearch + "%' or cte2.Price Like '%" + param.sSearch + "%' or cte2.ItemCount Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "cte2.Price";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.Vender Like '%" + param.sSearch + "%' or cte2.Price Like '%" + param.sSearch + "%' or cte2.ItemCount Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                //filteredCountryMaster = new List<PurchaseReplenishmentViewModel>(); 

                if (GeneralUnitsID != 0)
                {
                    filteredCountryMaster = GetPurchaseReplenishment(out TotalRecords, GeneralUnitsID);
                }
                else
                {
                    filteredCountryMaster = new List<PurchaseReplenishmentViewModel>();
                    TotalRecords = 0;
                }


                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.VendorID), Convert.ToString(c.Vendor), Convert.ToString(c.ItemCount), Convert.ToString(c.Price), Convert.ToString(c.VendorNumber) };

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




        public ActionResult _Billing()
        {

            return View("/Views/Purchase/PurchaseReplenishment/_Billing.cshtml");
        }







    }
}