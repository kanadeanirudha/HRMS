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
    public class SalesQuotationMasterAndDetailsController : BaseController
    {
        ISalesQuotationMasterAndDetailsBA _SalesQuotationMasterAndDetailsBA = null;
        IGeneralUnitsBA _GeneralUnitsBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalesQuotationMasterAndDetailsController()
        {
            _SalesQuotationMasterAndDetailsBA = new SalesQuotationMasterAndDetailsBA();
            _GeneralUnitsBA = new GeneralUnitsBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0 || Convert.ToInt32(Session["Store Manager"]) > 0) && IsApplied == true))

            {
                return View("/Views/Sales/SalesQuotationMasterAndDetails/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalesQuotationMasterAndDetailsViewModel model = new SalesQuotationMasterAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Sales/SalesQuotationMasterAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        public ActionResult CreateSalesQuotationByEnquiry(string SalesEnquiryMasterID, string GeneralUnitsID)
        {
            SalesQuotationMasterAndDetailsViewModel model = new SalesQuotationMasterAndDetailsViewModel();
            string CentreCode = string.Empty;
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);

            SalesQuotationMasterAndDetailsSearchRequest searchRequest = new SalesQuotationMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.SalesEnquiryMasterID = Convert.ToInt32(!string.IsNullOrEmpty(SalesEnquiryMasterID) ? SalesEnquiryMasterID : null);
            searchRequest.GeneralUnitsID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);

            //*********************Unit List*********************//
            List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
            List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
            foreach (GeneralUnitMaster item in GeneralUnitMaster)
            {
                GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text");

            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollectionResponse = _SalesQuotationMasterAndDetailsBA.GetQuotationMasterDetailsByEnquiryMaterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.QuotationDetailsByEnquiryMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                    model.CustomerName = model.QuotationDetailsByEnquiryMasterID[0].CustomerName;
                    model.CustomerBranchMasterName = model.QuotationDetailsByEnquiryMasterID[0].CustomerBranchMasterName;
                    model.ContactPersonName = model.QuotationDetailsByEnquiryMasterID[0].ContactPersonName;
                    model.TotalAmount = model.QuotationDetailsByEnquiryMasterID[0].TotalAmount;
                    model.CustomerMasterID = model.QuotationDetailsByEnquiryMasterID[0].CustomerMasterID;
                    model.CustomerBranchMasterID = model.QuotationDetailsByEnquiryMasterID[0].CustomerBranchMasterID;
                    model.ContactPersonID = model.QuotationDetailsByEnquiryMasterID[0].ContactPersonID;
                }
            }

            return PartialView("/Views/Sales/SalesQuotationMasterAndDetails/Create.cshtml", model);
        }


        public ActionResult Create(string SalesEnquiryMasterID, string GeneralUnitsID)
        {
            SalesQuotationMasterAndDetailsViewModel model = new SalesQuotationMasterAndDetailsViewModel();
            string CentreCode = string.Empty;
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
            return PartialView("/Views/Sales/SalesQuotationMasterAndDetails/CreateQuotationByEnquiry.cshtml", model);
        }

        public ActionResult CreateQuotation()
        {
            SalesQuotationMasterAndDetailsViewModel model = new SalesQuotationMasterAndDetailsViewModel();
            string CentreCode = string.Empty;
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);


            //*********************Unit List*********************//
            List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
            List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
            foreach (GeneralUnitMaster item in GeneralUnitMaster)
            {
                GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text");
            return PartialView("/Views/Sales/SalesQuotationMasterAndDetails/CreateQuotation.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateQuotation(SalesQuotationMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalesQuotationMasterAndDetailsDTO != null)
                {
                    model.SalesQuotationMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesQuotationMasterAndDetailsDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SalesQuotationMasterAndDetailsDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SalesQuotationMasterAndDetailsDTO.ContactPersonID = model.ContactPersonID;


                    model.SalesQuotationMasterAndDetailsDTO.CreditPeriod = model.CreditPeriod;
                    model.SalesQuotationMasterAndDetailsDTO.UnitMasterId = model.UnitMasterId;
                    model.SalesQuotationMasterAndDetailsDTO.TitleTo = model.TitleTo;
                    model.SalesQuotationMasterAndDetailsDTO.TotalAmount = model.TotalAmount;
                    model.SalesQuotationMasterAndDetailsDTO.TotalTaxAmount = model.TotalTaxAmount;
                    model.SalesQuotationMasterAndDetailsDTO.TotalBillAmount = model.TotalBillAmount;
                    model.SalesQuotationMasterAndDetailsDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.SalesQuotationMasterAndDetailsDTO.SalesQuotationMasterID = model.SalesQuotationMasterID;
                    model.SalesQuotationMasterAndDetailsDTO.XmlString = model.XmlString;

                    //Addition to Sales Order
                    model.SalesQuotationMasterAndDetailsDTO.PurchaseOrderNumberClient = model.PurchaseOrderNumberClient;
                    model.SalesQuotationMasterAndDetailsDTO.ShippingHandling = model.ShippingHandling;
                    model.SalesQuotationMasterAndDetailsDTO.Flag = model.Flag;
                    model.SalesQuotationMasterAndDetailsDTO.Discount = model.Discount;
                    model.SalesQuotationMasterAndDetailsDTO.Freight = model.Freight;
                    model.SalesQuotationMasterAndDetailsDTO.Tradein = model.Tradein;



                    model.SalesQuotationMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.SalesQuotationMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesQuotationMasterAndDetails> response = _SalesQuotationMasterAndDetailsBA.InsertSalesQuotationMasterAndDetails(model.SalesQuotationMasterAndDetailsDTO);

                    model.SalesQuotationMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesQuotationMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


                //  }
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

        public ActionResult Edit(string ID, string CustomerMasterID, string CustomerBranchID, string UnitID)
        {
            SalesQuotationMasterAndDetailsViewModel model = new SalesQuotationMasterAndDetailsViewModel();

            model.CustomerBranchMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerBranchID) ? CustomerBranchID : null);
            model.CustomerMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerMasterID) ? CustomerMasterID : null);
            model.SalesQuotationMasterID = Convert.ToInt32(!string.IsNullOrEmpty(ID) ? ID : null);


            SalesQuotationMasterAndDetailsSearchRequest searchRequest = new SalesQuotationMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.SalesQuotationMasterAndDetailsID = Convert.ToInt32(!string.IsNullOrEmpty(ID) ? ID : null);
            searchRequest.CustomerMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerMasterID) ? CustomerMasterID : null);
            searchRequest.CustomerBranchMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerBranchID) ? CustomerBranchID : null);
            searchRequest.GeneralUnitsID = Convert.ToInt32(!string.IsNullOrEmpty(UnitID) ? UnitID : null);


            //*********************Unit List*********************//
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollectionResponse = _SalesQuotationMasterAndDetailsBA.GetQuotationMasterDetailsListByQuotationMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.QuotationDetailsByEnquiryMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                    model.CustomerName = model.QuotationDetailsByEnquiryMasterID[0].CustomerName;
                    model.CustomerBranchMasterName = model.QuotationDetailsByEnquiryMasterID[0].CustomerBranchMasterName;
                    model.ContactPersonName = model.QuotationDetailsByEnquiryMasterID[0].ContactPersonName;
                    model.TotalAmount = model.QuotationDetailsByEnquiryMasterID[0].TotalAmount;
                    model.CustomerBranchMasterID = model.QuotationDetailsByEnquiryMasterID[0].CustomerBranchMasterID;
                    model.ContactPersonID = model.QuotationDetailsByEnquiryMasterID[0].ContactPersonID;
                    model.UnitMasterId = model.QuotationDetailsByEnquiryMasterID[0].UnitMasterId;
                    model.CreditPeriod = model.QuotationDetailsByEnquiryMasterID[0].CreditPeriod;
                    model.TitleTo = model.QuotationDetailsByEnquiryMasterID[0].TitleTo;

                }
            }
            string CentreCode = string.Empty;
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
            model.GeneralUnitsID = Convert.ToInt32(!string.IsNullOrEmpty(UnitID) ? UnitID : null);
            List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
            List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
            foreach (GeneralUnitMaster item in GeneralUnitMaster)
            {
                GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text", model.UnitMasterId);



            return PartialView("/Views/Sales/SalesQuotationMasterAndDetails/EditQuotation.cshtml", model);
        }


        [HttpPost]
        public ActionResult Edit(SalesQuotationMasterAndDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.SalesQuotationMasterAndDetailsDTO != null)
                {
                    if (model != null && model.SalesQuotationMasterAndDetailsDTO != null)
                    {
                        model.SalesQuotationMasterAndDetailsDTO.ConnectionString = _connectioString;
                        //model.SalesQuotationMasterAndDetailsDTO.TransactionType = model.TransactionType;

                        //model.SalesQuotationMasterAndDetailsDTO.IsActive = model.IsActive;

                        model.SalesQuotationMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<SalesQuotationMasterAndDetails> response = _SalesQuotationMasterAndDetailsBA.UpdateSalesQuotationMasterAndDetails(model.SalesQuotationMasterAndDetailsDTO);
                        model.SalesQuotationMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.SalesQuotationMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult ViewDetails(string ID, string CustomerMasterID, string CustomerBranchID, string UnitID)
        {

            SalesQuotationMasterAndDetailsViewModel model = new SalesQuotationMasterAndDetailsViewModel();

            model.CustomerBranchMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerBranchID) ? CustomerBranchID : null);
            model.CustomerMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerMasterID) ? CustomerMasterID : null);
            model.SalesQuotationMasterID = Convert.ToInt32(!string.IsNullOrEmpty(ID) ? ID : null);


            SalesQuotationMasterAndDetailsSearchRequest searchRequest = new SalesQuotationMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.SalesQuotationMasterAndDetailsID = Convert.ToInt32(!string.IsNullOrEmpty(ID) ? ID : null);
            searchRequest.CustomerMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerMasterID) ? CustomerMasterID : null);
            searchRequest.CustomerBranchMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerBranchID) ? CustomerBranchID : null);
            searchRequest.GeneralUnitsID = Convert.ToInt32(!string.IsNullOrEmpty(UnitID) ? UnitID : null);


            //*********************Unit List*********************//
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollectionResponse = _SalesQuotationMasterAndDetailsBA.GetQuotationMasterDetailsListByQuotationMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.QuotationDetailsByEnquiryMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                    model.CustomerName = model.QuotationDetailsByEnquiryMasterID[0].CustomerName;
                    model.CustomerBranchMasterName = model.QuotationDetailsByEnquiryMasterID[0].CustomerBranchMasterName;
                    model.ContactPersonName = model.QuotationDetailsByEnquiryMasterID[0].ContactPersonName;
                    model.TotalAmount = model.QuotationDetailsByEnquiryMasterID[0].TotalAmount;
                    model.CustomerBranchMasterID = model.QuotationDetailsByEnquiryMasterID[0].CustomerBranchMasterID;
                    model.UnitMasterId = model.QuotationDetailsByEnquiryMasterID[0].UnitMasterId;
                    model.CreditPeriod = model.QuotationDetailsByEnquiryMasterID[0].CreditPeriod;
                    model.TitleTo = model.QuotationDetailsByEnquiryMasterID[0].TitleTo;
                }
            }
            string CentreCode = string.Empty;
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
            model.GeneralUnitsID = Convert.ToInt32(!string.IsNullOrEmpty(UnitID) ? UnitID : null);
            List<GeneralUnitMaster> GeneralUnitMaster = GetListGeneralUnitMaster();
            List<SelectListItem> GeneralUnitMasterList = new List<SelectListItem>();
            foreach (GeneralUnitMaster item in GeneralUnitMaster)
            {
                GeneralUnitMasterList.Add(new SelectListItem { Text = item.UnitDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralUnitMasterList = new SelectList(GeneralUnitMasterList, "Value", "Text", model.UnitMasterId);



            return PartialView("/Views/Sales/SalesQuotationMasterAndDetails/ViewDetails.cshtml", model);
        }

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<SalesQuotationMasterAndDetails> response = null;
                SalesQuotationMasterAndDetails SalesQuotationMasterAndDetailsDTO = new SalesQuotationMasterAndDetails();
                SalesQuotationMasterAndDetailsDTO.ConnectionString = _connectioString;
                //  SalesQuotationMasterAndDetailsDTO.ID = Convert.ToInt16(ID);
                SalesQuotationMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalesQuotationMasterAndDetailsBA.DeleteSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetailsDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalesQuotationMasterAndDetailsViewModel> GetSalesQuotationMasterAndDetails(out int TotalRecords)
        {
            SalesQuotationMasterAndDetailsSearchRequest searchRequest = new SalesQuotationMasterAndDetailsSearchRequest();
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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
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
            }
            List<SalesQuotationMasterAndDetailsViewModel> listSalesQuotationMasterAndDetailsViewModel = new List<SalesQuotationMasterAndDetailsViewModel>();
            List<SalesQuotationMasterAndDetails> listSalesQuotationMasterAndDetails = new List<SalesQuotationMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollectionResponse = _SalesQuotationMasterAndDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesQuotationMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalesQuotationMasterAndDetails item in listSalesQuotationMasterAndDetails)
                    {
                        SalesQuotationMasterAndDetailsViewModel SalesQuotationMasterAndDetailsViewModel = new SalesQuotationMasterAndDetailsViewModel();
                        SalesQuotationMasterAndDetailsViewModel.SalesQuotationMasterAndDetailsDTO = item;
                        listSalesQuotationMasterAndDetailsViewModel.Add(SalesQuotationMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalesQuotationMasterAndDetailsViewModel;
        }

        public ActionResult GetSalePriceByUOMCode(string ItemNumber, string UOM, int GeneralUnitsID)
        {

            var UOMCodeDesc = GetSalePriceByUOMCodeList(ItemNumber, UOM, GeneralUnitsID);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              Rate = s.Rate,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetItemNumberSearchList(string term, string CustomerMasterID, string CustomerBranchMasterID, string GeneralUnitsID,string IsServiceItem)
        {
            SalesQuotationMasterAndDetailsSearchRequest searchRequest = new SalesQuotationMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.CustomerMasterID = Convert.ToInt32(CustomerMasterID);
            searchRequest.CustomerBranchMasterID = Convert.ToInt32(CustomerBranchMasterID);
            searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            searchRequest.IsServiceItem = Convert.ToBoolean(IsServiceItem);
            List<SalesQuotationMasterAndDetails> listFeeSubType = new List<SalesQuotationMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollectionResponse = _SalesQuotationMasterAndDetailsBA.GetItemNumberSearchListForCustomer(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              ItemNumber = r.ItemNumber,
                              ItemDescription = r.ItemDescription,
                              GeneralTaxGroupMasterID = r.GeneralTaxGroupMasterID,
                              TaxRate = r.TaxRate,
                              SerialAndBatchManagedBy = r.SerialAndBatchManagedBy,
                              TaxRateList = r.TaxRateList,
                              TaxList = r.TaxList,
                              PurchasePrice=r.PurchasePrice,
                              PurchaseUoMCode=r.PurchaseUoMCode,
                              ConversionFactor=r.ConversionFactor,
                              IsTaxExempted=r.IsTaxExempted,
                              TaxGroupName = r.TaxGroupName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<SalesQuotationMasterAndDetails> GetSalePriceByUOMCodeList(string ItemNumber, string UOM, int GeneralUnitsID)
        {

            SalesQuotationMasterAndDetailsSearchRequest searchRequest = new SalesQuotationMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);
            searchRequest.UOM = Convert.ToString(UOM);
            searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);

            List<SalesQuotationMasterAndDetails> listUoMCodeByForSalesPrice = new List<SalesQuotationMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> baseEntityCollectionResponse = _SalesQuotationMasterAndDetailsBA.GetUomWiseSalesPrice(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUoMCodeByForSalesPrice = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listUoMCodeByForSalesPrice;
        }

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
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalesQuotationMasterAndDetailsViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.CustomerMasterID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "Concat(B.FirstName,' ',B.MiddleName,' ',B.LastName) Like '%" + param.sSearch + "%' or A.EnquiryNumber Like '%" + param.sSearch + "%' or A.QuotationNumber Like '%" + param.sSearch + "%'or B.CompanyName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                    case 1:
                        _sortBy = "A.EnquiryNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Concat(B.FirstName,' ',B.MiddleName,' ',B.LastName) Like '%" + param.sSearch + "%' or A.EnquiryNumber Like '%" + param.sSearch + "%' or A.QuotationNumber Like '%" + param.sSearch + "%'or B.CompanyName Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.QuotationNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Concat(B.FirstName,' ',B.MiddleName,' ',B.LastName) Like '%" + param.sSearch + "%' or A.EnquiryNumber Like '%" + param.sSearch + "%' or A.QuotationNumber Like '%" + param.sSearch + "%'or B.CompanyName Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetSalesQuotationMasterAndDetails(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CustomerMasterID), Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.ContactPersonID), Convert.ToString(c.EnquiryNumber), Convert.ToString(c.SalesQuotationMasterID), Convert.ToString(c.CustomerName), Convert.ToString(c.QuotationNumber), Convert.ToString(c.Status), Convert.ToString(c.SalesEnquiryMasterID), Convert.ToString(c.GeneralUnitsID) };

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