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
    public class PurchaseReturnController : BaseController
    {
        IPurchaseReturnBA _PurchaseReturnBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        IPurchaseRequisitionMasterBA _PurchaseRequisitionMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public PurchaseReturnController()
        {
            _PurchaseReturnBA = new PurchaseReturnBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
            _PurchaseRequisitionMasterBA = new PurchaseRequisitionMasterBA();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0)
            {
                try
                {
                    PurchaseReturnViewModel model = new PurchaseReturnViewModel();
                    int AdminRoleID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
                    List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                    foreach (InventoryLocationMaster item in locationMasterList)
                    {
                        listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");

                    return View("/Views/Purchase/PurchaseReturn/Index.cshtml", model);
                }
                catch (Exception ex)
                {
                    _logException.Error(ex.Message);
                    throw;
                }
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List()
        {
            PurchaseReturnViewModel model = new PurchaseReturnViewModel();
            return PartialView("/Views/Purchase/PurchaseReturn/List.cshtml", model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            PurchaseReturnViewModel model = new PurchaseReturnViewModel();
            int AdminRoleID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
            List<SelectListItem> listLocationMaster = new List<SelectListItem>();
            foreach (InventoryLocationMaster item in locationMasterList)
            {
                listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            return PartialView("/Views/Purchase/PurchaseReturn/Create.cshtml", model);
        }
        [HttpPost]
        public ActionResult Create(PurchaseReturnViewModel model)
        {
            try
            {
                if (model != null && model.PurchaseReturnDTO != null)
                {
                    model.PurchaseReturnDTO.ConnectionString = _connectioString;
                    model.PurchaseReturnDTO.VendorId = model.VendorId;
                    model.PurchaseReturnDTO.TransactionDate = model.TransactionDate;
                    model.PurchaseReturnDTO.LocationID = model.LocationID;
                    model.PurchaseReturnDTO.TotalTaxAmount = model.TotalTaxAmount;
                    model.PurchaseReturnDTO.RoundUpAmount = model.RoundUpAmount;
                    model.PurchaseReturnDTO.PurchaseReturnAmount = model.PurchaseReturnAmount;
                    model.PurchaseReturnDTO.ParameterVoucherXml = model.ParameterVoucherXml;
                    model.PurchaseReturnDTO.ParameterXml = model.ParameterXml;
                    model.PurchaseReturnDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseReturn> response = _PurchaseReturnBA.InsertPurchaseReturn(model.PurchaseReturnDTO);
                    model.PurchaseReturnDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.PurchaseReturnDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult View(int ID)
        {
            try
            {
                PurchaseReturnViewModel model = new PurchaseReturnViewModel();
                model.PurchaseReturnList = GetPurchaseReturnList(ID);
                if (model.PurchaseReturnList.Count > 0 && model.PurchaseReturnList != null)
                {
                    model.vendor = model.PurchaseReturnList[0].vendor;
                    model.TransactionDate = model.PurchaseReturnList[0].TransactionDate;
                    model.LocationID = model.PurchaseReturnList[0].LocationID;
                    model.TotalTaxAmount = model.PurchaseReturnList[0].TotalTaxAmount;
                    model.RoundUpAmount = model.PurchaseReturnList[0].RoundUpAmount;
                    model.PurchaseReturnAmount = model.PurchaseReturnList[0].PurchaseReturnAmount;
                }
                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
                List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
                List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                foreach (InventoryLocationMaster item in locationMasterList)
                {
                    listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text", (model.PurchaseReturnDTO.LocationID).ToString().Trim());
                return PartialView("/Views/Purchase/PurchaseReturn/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpPost]
        public JsonResult GetVendorSearchList(string SearchWord)
        {
            PurchaseReturnSearchRequest searchRequest = new PurchaseReturnSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchWord;
            searchRequest.SearchFor = "Vendor";

            List<PurchaseReturn> listPurchaseReturn = new List<PurchaseReturn>();
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollectionResponse = _PurchaseReturnBA.GetVendorSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseReturn = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listPurchaseReturn
                          select new
                          {
                              VendorId = r.VendorId,
                              vendor = r.vendor,
                              VendorNumber = r.VendorNumber,
                              CreditAmount = r.CreditAmount
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItemNumberSearchList(string SearchWord, int VendorNumber)
        {
            PurchaseReturnSearchRequest searchRequest = new PurchaseReturnSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchWord;
            searchRequest.VendorNumber = VendorNumber;
            searchRequest.SearchFor = "Item";

            List<PurchaseReturn> listPurchaseReturn = new List<PurchaseReturn>();
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollectionResponse = _PurchaseReturnBA.GetVendorSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseReturn = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listPurchaseReturn
                          select new
                          {
                              GeneralItemMasterID = r.GeneralItemMasterID,
                              ItemDescription = r.ItemDescription,
                              ItemNumber = r.ItemNumber,
                              GenTaxGroupMasterId = r.GenTaxGroupMasterId,
                              TaxInPercentage = r.TaxInPercentage,
                              SerialAndBatchManagedBy = r.SerialAndBatchManagedBy,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPurchaseOrderSearchList(string SearchWord, int VendorId, int ItemNumber, Int16 LocationID)
        {
            PurchaseReturnSearchRequest searchRequest = new PurchaseReturnSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchWord;
            searchRequest.VendorId = VendorId;
            searchRequest.ItemNumber = ItemNumber;
            searchRequest.LocationID = LocationID;
            searchRequest.SearchFor = "PurchaseOrder";

            List<PurchaseReturn> listPurchaseReturn = new List<PurchaseReturn>();
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollectionResponse = _PurchaseReturnBA.GetVendorSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseReturn = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listPurchaseReturn
                          select new
                          {
                              PurchaseOrderMasterID = r.PurchaseOrderMasterID,
                              PurchaseOrderNumber = r.PurchaseOrderNumber,
                              Rate = r.Rate,
                              OrderUomCode = r.OrderUomCode,
                              BaseUOMQuantity = r.BaseUOMQuantity,
                              BaseUOMCode = r.BaseUOMCode,
                              GeneralItemCodeID = r.GeneralItemCodeID,
                              TaxRateList = r.TaxRateList,
                              TaxList=r.TaxList,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPurchaseGRNSearchList(string SearchWord, int VendorId, int ItemNumber, Int16 LocationID, int PurchaseOrderMasterID)
        {
            PurchaseReturnSearchRequest searchRequest = new PurchaseReturnSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchWord;
            searchRequest.VendorId = VendorId;
            searchRequest.ItemNumber = ItemNumber;
            searchRequest.PurchaseOrderMasterID = PurchaseOrderMasterID;
            searchRequest.LocationID = LocationID;
            searchRequest.SearchFor = "PurchaseGRN";
            List<PurchaseReturn> listPurchaseReturn = new List<PurchaseReturn>();
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollectionResponse = _PurchaseReturnBA.GetVendorSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseReturn = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listPurchaseReturn
                          select new
                          {
                              PurchaseGRNMasterID = r.PurchaseGRNMasterID,
                              PurchaseGrnNumber = r.PurchaseGrnNumber,
                              Rate = r.Rate,
                              OrderUomCode = r.OrderUomCode,
                              BaseUOMQuantity = r.BaseUOMQuantity,
                              BaseUOMCode = r.BaseUOMCode,
                              ReceivedQuantity = r.ReceivedQuantity,
                              GenTaxGroupMasterId = r.GenTaxGroupMasterId,
                              TaxInPercentage = r.TaxInPercentage,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBatchNUmberSearchList(string SearchWord, int ItemNumber, int PurchaseGRNMasterID)
        {
            PurchaseReturnSearchRequest searchRequest = new PurchaseReturnSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchWord;
            searchRequest.ItemNumber = ItemNumber;
            searchRequest.PurchaseGRNMasterID = PurchaseGRNMasterID;
            searchRequest.SearchFor = "Batch";
            List<PurchaseReturn> listPurchaseReturn = new List<PurchaseReturn>();
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollectionResponse = _PurchaseReturnBA.GetVendorSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseReturn = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listPurchaseReturn
                          select new
                          {
                              BatchNumber = r.BatchNumber,
                              ExpiryDate = r.ExpiryDate,
                              BatchID = r.BatchID,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList(int AdminRoleID)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleID = AdminRoleID;
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterlistByAdminRole(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        [NonAction]
        protected List<PurchaseReturn> GetPurchaseReturnList(int ID)
        {
            PurchaseReturnSearchRequest searchRequest = new PurchaseReturnSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = ID;
            List<PurchaseReturn> listPurchaseReturn = new List<PurchaseReturn>();
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollectionResponse = _PurchaseReturnBA.GetPurchaseReturnDetailLists(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseReturn = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseReturn;
        }
        public ActionResult GetUoMCodeByItemNumber(string ItemNumber)
        {

            var UOMCodeDesc = GetUoMCodeByItemNumberList(ItemNumber);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UnitCode,
                              BaseUOMQuantity = s.BaseUOMQuantity,
                              Rate = s.UomPurchasePrice,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<PurchaseRequisitionMaster> GetUoMCodeByItemNumberList(string ItemNumber)
        {

            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);

            List<PurchaseRequisitionMaster> listOrganisationDepartmentMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterBA.GetUomDetailsForSTOWithPurchasePrice(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }
        public ActionResult GetUoMCodeByForPurchasePrice(string ItemNumber, string UoMCode, int PurchaseOrderMasterID)
        {

            var UOMCodeDesc = GetUoMCodeByForPurchasePriceList(ItemNumber, UoMCode, PurchaseOrderMasterID);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UnitCode,
                              BaseUOMQuantity = s.BaseUOMQuantity,
                              UomPurchasePrice = s.UomPurchasePrice,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<PurchaseReturn> GetUoMCodeByForPurchasePriceList(string ItemNumber, string UoMCode, int PurchaseOrderMasterID)
        {

            PurchaseReturnSearchRequest searchRequest = new PurchaseReturnSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);
            searchRequest.UnitCode = Convert.ToString(UoMCode);
            searchRequest.PurchaseOrderMasterID = Convert.ToInt32(PurchaseOrderMasterID);

            List<PurchaseReturn> listUoMCodeByForPurchasePrice = new List<PurchaseReturn>();
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollectionResponse = _PurchaseReturnBA.GetUomWisePurchasePrice(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUoMCodeByForPurchasePrice = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listUoMCodeByForPurchasePrice;
        }
        public IEnumerable<PurchaseReturnViewModel> GetPurchaseReturn(out int TotalRecords, int VendorId, string TransactionDate, int LocationID)
        {
            PurchaseReturnSearchRequest searchRequest = new PurchaseReturnSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.VendorId = VendorId;
            searchRequest.TransactionDate = TransactionDate;
            searchRequest.LocationID = LocationID;
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
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
            List<PurchaseReturnViewModel> listPurchaseReturnViewModel = new List<PurchaseReturnViewModel>();
            List<PurchaseReturn> listPurchaseReturn = new List<PurchaseReturn>();
            IBaseEntityCollectionResponse<PurchaseReturn> baseEntityCollectionResponse = _PurchaseReturnBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseReturn = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (PurchaseReturn item in listPurchaseReturn)
                    {
                        PurchaseReturnViewModel PurchaseReturnViewModel = new PurchaseReturnViewModel();
                        PurchaseReturnViewModel.PurchaseReturnDTO = item;
                        listPurchaseReturnViewModel.Add(PurchaseReturnViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPurchaseReturnViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int VendorId, string TransactionDate, int LocationID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<PurchaseReturnViewModel> filteredGroupDescription;
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

                            _searchBy = "A.PurchaseReturnNumber Like '%" + param.sSearch + "%'  or A.PurchaseReturnAmount Like '%" + param.sSearch + "%'";  //this if block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.PurchaseReturnNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.PurchaseReturnNumber Like '%" + param.sSearch + "%'  or A.PurchaseReturnAmount Like '%" + param.sSearch + "%'";  //this if block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.PurchaseReturnAmount";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.PurchaseReturnNumber Like '%" + param.sSearch + "%'  or A.PurchaseReturnAmount Like '%" + param.sSearch + "%'";  //this if block is added for search functionality
                        }
                        break;


                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetPurchaseReturn(out TotalRecords, VendorId, TransactionDate, LocationID);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.PurchaseReturnNumber), Convert.ToString(c.TransactionDate), Convert.ToString(c.TotalTaxAmount), Convert.ToString(c.RoundUpAmount), Convert.ToString(c.PurchaseReturnAmount), Convert.ToString(c.VendorId), Convert.ToString(c.BalanceSheetID), Convert.ToString(c.LocationID), Convert.ToString(c.PurchaseRetrunTransactionID), Convert.ToString(c.ItemNumber), Convert.ToString(c.TaxAmount), Convert.ToString(c.GenTaxGroupMasterId), Convert.ToString(c.ExpiryDate), Convert.ToString(c.BatchNumber), Convert.ToString(c.UOMCode), Convert.ToString(c.Quantity), Convert.ToString(c.Rate), Convert.ToString(c.GeneralItemCodeID), Convert.ToString(c.PurchaseOrderNumber), Convert.ToString(c.PurchaseGrnNumber), Convert.ToString(c.vendor) };

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