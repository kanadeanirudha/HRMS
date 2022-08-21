using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
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
    public class InventoryRateTransactionController : BaseController
    {
        IInventoryRateTransactionServiceAccess _InventoryRateTransactionServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryRateTransactionController()
        {
            _InventoryRateTransactionServiceAcess = new InventoryRateTransactionServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/InventoryRateTransaction/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                InventoryRateTransactionViewModel model = new InventoryRateTransactionViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/InventoryRateTransaction/List.cshtml", model);
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
            InventoryRateTransactionViewModel model = new InventoryRateTransactionViewModel();
          
                return PartialView("/Views/Inventory_1/InventoryRateTransaction/Create.cshtml", model);
                  }

        [HttpPost]
        public ActionResult Create(InventoryRateTransactionViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
               // {
                    if (model != null && model.InventoryRateTransactionDTO != null)
                    {
                        model.InventoryRateTransactionDTO.ConnectionString = _connectioString;
                        model.InventoryRateTransactionDTO.ItemNumber = model.ItemNumber;
                        model.InventoryRateTransactionDTO.ItemBarCodeId = model.ItemBarCodeId;
                        model.InventoryRateTransactionDTO.InventoryLocationMasterID = model.InventoryLocationMasterID;
                        model.InventoryRateTransactionDTO.BalancesheetID = model.BalancesheetID;
                        model.InventoryRateTransactionDTO.TransactionDate = model.TransactionDate;
                        model.InventoryRateTransactionDTO.PurchaseRate = model.PurchaseRate;
                        model.InventoryRateTransactionDTO.SaleRate = model.SaleRate;
                        model.InventoryRateTransactionDTO.EffectDueTo = model.EffectDueTo;
                        model.InventoryRateTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryRateTransaction> response = _InventoryRateTransactionServiceAcess.InsertInventoryRateTransaction(model.InventoryRateTransactionDTO);

                        model.InventoryRateTransactionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.InventoryRateTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        
        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<InventoryRateTransaction> response = null;
                InventoryRateTransaction InventoryRateTransactionDTO = new InventoryRateTransaction();
                InventoryRateTransactionDTO.ConnectionString = _connectioString;
                InventoryRateTransactionDTO.ID = Convert.ToInt32(ID);
                InventoryRateTransactionDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryRateTransactionServiceAcess.DeleteInventoryRateTransaction(InventoryRateTransactionDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
      

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryRateTransactionViewModel> GetInventoryRateTransaction(out int TotalRecords)
        {
            InventoryRateTransactionSearchRequest searchRequest = new InventoryRateTransactionSearchRequest();
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
            List<InventoryRateTransactionViewModel> listInventoryRateTransactionViewModel = new List<InventoryRateTransactionViewModel>();
            List<InventoryRateTransaction> listInventoryRateTransaction = new List<InventoryRateTransaction>();
            IBaseEntityCollectionResponse<InventoryRateTransaction> baseEntityCollectionResponse = _InventoryRateTransactionServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryRateTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryRateTransaction item in listInventoryRateTransaction)
                    {
                        InventoryRateTransactionViewModel InventoryRateTransactionViewModel = new InventoryRateTransactionViewModel();
                        InventoryRateTransactionViewModel.InventoryRateTransactionDTO = item;
                        listInventoryRateTransactionViewModel.Add(InventoryRateTransactionViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryRateTransactionViewModel;
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

                IEnumerable<InventoryRateTransactionViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ItemNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                           // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.ItemBarCodeId Like '%" + param.sSearch + "%' or A.ItemNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.ItemBarCodeId";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                          //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.ItemNumber Like '%" + param.sSearch + "%' or A.ItemBarCodeId Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.InventoryLocationMasterID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.ItemBarCodeId Like '%" + param.sSearch + "%' or A.InventoryLocationMasterID Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.BalancesheetID ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.InventoryLocationMasterID Like '%" + param.sSearch + "%' or A.BalancesheetID  Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "A.TransactionDate ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.BalancesheetID Like '%" + param.sSearch + "%' or A.TransactionDate  Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 5:
                        _sortBy = "A.PurchaseRate ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.PurchaseRate  Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 6:
                        _sortBy = "A.SaleRate ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.PurchaseRate Like '%" + param.sSearch + "%' or A.SaleRate  Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 7:
                        _sortBy = "A.EffectDueTo ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.SaleRate Like '%" + param.sSearch + "%' or A.EffectDueTo  Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetInventoryRateTransaction(out TotalRecords);
                
                
                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ItemNumber), Convert.ToString(c.ItemBarCodeId), Convert.ToString(c.InventoryLocationMasterID), Convert.ToString(c.BalancesheetID), Convert.ToString(c.TransactionDate), Convert.ToString(c.PurchaseRate), Convert.ToString(c.SaleRate),Convert.ToString(c.EffectDueTo),Convert.ToString(c.ID) };

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