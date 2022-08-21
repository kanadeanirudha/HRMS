using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class InventoryPhysicalStockMasterAndTransactionController : BaseController
    {
        IInventoryPhysicalStockMasterAndTransactionServiceAccess _InventoryPhysicalStockMasterAndTransactionServiceAccess = null;
        IInventoryLocationMaster_1ServiceAccess _InventoryLocationMaster_1ServiceAccess = null;
        IGeneralItemMasterServiceAccess _GeneralItemMasterServiceAcess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryPhysicalStockMasterAndTransactionController()
        {
            _InventoryPhysicalStockMasterAndTransactionServiceAccess = new InventoryPhysicalStockMasterAndTransactionServiceAccess();
            _InventoryLocationMaster_1ServiceAccess = new InventoryLocationMaster_1ServiceAccess();
              _GeneralItemMasterServiceAcess = new GeneralItemMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory_1/InventoryPhysicalStockMasterAndTransaction/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpGet]
        public ActionResult List(string selectedBalsheet, string InventoryLocationMasterID, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet) || Convert.ToString(Session["UserType"]) == "A")
                {
                    InventoryPhysicalStockMasterAndTransactionViewModel model = new InventoryPhysicalStockMasterAndTransactionViewModel();
                    model.LocationList = GetLocationList(selectedBalsheet);
                    model.InventoryLocationMasterID = !string.IsNullOrEmpty(InventoryLocationMasterID) ? Convert.ToInt32(InventoryLocationMasterID) : 0;
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/Inventory_1/InventoryPhysicalStockMasterAndTransaction/List.cshtml", model);
                }
                else
                {
                    return RedirectToActionPermanent("UnauthorizedAccess", "Home");
                }
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
            InventoryPhysicalStockMasterAndTransactionViewModel model = new InventoryPhysicalStockMasterAndTransactionViewModel();



            return PartialView("/Views/Inventory_1/InventoryPhysicalStockMasterAndTransaction/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryPhysicalStockMasterAndTransactionViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryPhysicalStockMasterAndTransactionDTO != null)
                {
                    model.InventoryPhysicalStockMasterAndTransactionDTO.ConnectionString = _connectioString;

                    model.InventoryPhysicalStockMasterAndTransactionDTO.TransactionDate = model.TransactionDate;
                    model.InventoryPhysicalStockMasterAndTransactionDTO.Balancesheet = model.Balancesheet;
                    model.InventoryPhysicalStockMasterAndTransactionDTO.InventoryLocationMasterID = model.InventoryLocationMasterID;
                    model.InventoryPhysicalStockMasterAndTransactionDTO.VariationAmount = model.VariationAmount;
                    model.InventoryPhysicalStockMasterAndTransactionDTO.ParameterXml = model.ParameterXml;
                    model.InventoryPhysicalStockMasterAndTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> response = _InventoryPhysicalStockMasterAndTransactionServiceAccess.InsertInventoryPhysicalStockMasterAndTransaction(model.InventoryPhysicalStockMasterAndTransactionDTO);

                    model.InventoryPhysicalStockMasterAndTransactionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryPhysicalStockMasterAndTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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



        [HttpPost]
        public ActionResult Edit(InventoryPhysicalStockMasterAndTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryPhysicalStockMasterAndTransactionDTO != null)
                {
                    if (model != null && model.InventoryPhysicalStockMasterAndTransactionDTO != null)
                    {
                        model.InventoryPhysicalStockMasterAndTransactionDTO.ConnectionString = _connectioString;
                        //model.InventoryPhysicalStockMasterAndTransactionDTO.InventoryPhysicalStockMasterAndTransactionCode = model.InventoryPhysicalStockMasterAndTransactionCode;
                        //model.InventoryPhysicalStockMasterAndTransactionDTO.InventoryPhysicalStockMasterAndTransactionDescription = model.InventoryPhysicalStockMasterAndTransactionDescription;
                        //model.InventoryPhysicalStockMasterAndTransactionDTO.IsRelatedTo = model.IsRelatedTo;
                        model.InventoryPhysicalStockMasterAndTransactionDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> response = _InventoryPhysicalStockMasterAndTransactionServiceAccess.UpdateInventoryPhysicalStockMasterAndTransaction(model.InventoryPhysicalStockMasterAndTransactionDTO);
                        model.InventoryPhysicalStockMasterAndTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.InventoryPhysicalStockMasterAndTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult ViewDetails(int id)
        {
            try
            {
                IInventoryPhysicalStockMasterAndTransactionViewModel model = new InventoryPhysicalStockMasterAndTransactionViewModel();
                model.InventoryPhysicalStockMasterAndTransactionList = GetInventoryStockDetails(id);
                return PartialView("/Views/Inventory_1/InventoryPhysicalStockMasterAndTransaction/ViewDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> response = null;
                InventoryPhysicalStockMasterAndTransaction InventoryPhysicalStockMasterAndTransactionDTO = new InventoryPhysicalStockMasterAndTransaction();
                InventoryPhysicalStockMasterAndTransactionDTO.ConnectionString = _connectioString;
                //InventoryPhysicalStockMasterAndTransactionDTO.ID = Convert.ToInt16(ID);
                InventoryPhysicalStockMasterAndTransactionDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryPhysicalStockMasterAndTransactionServiceAccess.DeleteInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransactionDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        protected List<InventoryPhysicalStockMasterAndTransaction> GetInventoryStockDetails(int id)
        {
            InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest = new InventoryPhysicalStockMasterAndTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.InventoryPhysicalStockTransactionId = id;
            List<InventoryPhysicalStockMasterAndTransaction> listDumpAndShrinkDetails = new List<InventoryPhysicalStockMasterAndTransaction>();
            IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> baseEntityCollectionResponse = _InventoryPhysicalStockMasterAndTransactionServiceAccess.GetInventoryStockDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listDumpAndShrinkDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listDumpAndShrinkDetails;
        }
        public JsonResult GetItemDescriptionDetails(string term)
        {
            var data = GetItemDescriptionDetailsdata(term);
            var result = (from r in data
                          select new
                          {

                              id = r.GeneralItemMasterID,

                              ItemDescription = r.ItemDescription,
                              UomCode = r.UomCode,
                              price = r.LastPurchasePrice,
                              barcodeid = r.GeneralItemCodeID,
                              itemnumber =r.ItemNumber,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<GeneralItemMaster> GetItemDescriptionDetailsdata(string SearchKeyWord)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;

            List<GeneralItemMaster> listAccount = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterServiceAcess.GetGeneralItemMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }


        ////Non-Action method to fetch list of location
        protected List<InventoryLocationMaster_1> GetLocationList(string balancesheet)
        {
            InventoryLocationMaster_1SearchRequest searchRequest = new InventoryLocationMaster_1SearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = Convert.ToInt16(balancesheet);
            List<InventoryLocationMaster_1> listLocationMaster = new List<InventoryLocationMaster_1>();
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> baseEntityCollectionResponse = _InventoryLocationMaster_1ServiceAccess.GetInventoryLocationMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }
        public IEnumerable<InventoryPhysicalStockMasterAndTransaction> GetInventoryPhysicalStockMasterAndTransaction(out int TotalRecords, string Balancesheet, string InventoryLocationMasterID)
        {
            List<InventoryPhysicalStockMasterAndTransaction> listInventoryPhysicalStockMasterAndTransaction = new List<InventoryPhysicalStockMasterAndTransaction>();
            InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest = new InventoryPhysicalStockMasterAndTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.Balancesheet = Convert.ToInt16(Balancesheet);
            searchRequest.InventoryLocationMasterID = Convert.ToInt16(InventoryLocationMasterID);
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
            IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> baseEntityCollectionResponse = _InventoryPhysicalStockMasterAndTransactionServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryPhysicalStockMasterAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryPhysicalStockMasterAndTransaction;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string Balancesheet, string InventoryLocationMasterID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<InventoryPhysicalStockMasterAndTransaction> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.TransactionDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.VariationAmount Like '%" + param.sSearch + "%' ";
                        }
                        break;
                    case 1:
                        _sortBy = "A.VariationAmount";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //this "if" block is added for search functionality
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.VariationAmount Like '%" + param.sSearch + "%' ";
                        }
                        break;
                   
                   
                    
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                
                if ((!string.IsNullOrEmpty(Balancesheet) || Convert.ToString(Session["UserType"]) == "A") && !string.IsNullOrEmpty(InventoryLocationMasterID))
                {
                    filteredGroupDescription = GetInventoryPhysicalStockMasterAndTransaction(out TotalRecords, Balancesheet, InventoryLocationMasterID);
                }
                else
                {
                    filteredGroupDescription = new List<InventoryPhysicalStockMasterAndTransaction>();
                    TotalRecords = 0;
                }


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.InventoryLocationMasterID), Convert.ToString(c.TransactionDate), Convert.ToString(c.VariationAmount), Convert.ToString(c.InventoryPhysicalStockMasterId) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");s
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}