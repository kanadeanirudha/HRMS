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
    public class BarcodesController : BaseController
    {
        IGeneralItemMasterServiceAccess _GeneralItemMasterServiceAcess = null;
        IInventoryUoMMasterServiceAccess _InventoryUoMMasterServiceAccess = null;
        IInventoryUoMGroupAndDetailsServiceAccess _InventoryUoMGroupAndDetailsServiceAccess = null;
        
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public BarcodesController()
        {
            _GeneralItemMasterServiceAcess = new GeneralItemMasterServiceAccess();
            _InventoryUoMMasterServiceAccess = new InventoryUoMMasterServiceAccess();
            _InventoryUoMGroupAndDetailsServiceAccess = new InventoryUoMGroupAndDetailsServiceAccess();
           
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/Barcodes/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

             

                return PartialView("/Views/Inventory_1/Barcodes/List.cshtml", model);
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
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();

            string[] IDsArray = IDs.Split('~');

            model.GeneralItemMasterID = Convert.ToInt16(IDsArray[0]);
            model.ItemDescription = IDsArray[1];

            List<InventoryUoMGroupAndDetails> InventoryUoMGroupAndDetails = GetListInventoryUoMGroup();
            List<SelectListItem> InventoryUoMGroupAndDetailsList = new List<SelectListItem>();
            foreach (InventoryUoMGroupAndDetails item in InventoryUoMGroupAndDetails)
            {
                InventoryUoMGroupAndDetailsList.Add(new SelectListItem { Text = item.GroupCode, Value = Convert.ToString(item.GroupCode) });
            }
            ViewBag.InventoryUoMGroupAndDetailsList = new SelectList(InventoryUoMGroupAndDetailsList, "Value", "Text");

            //*******************************************************************************************************

            List<InventoryUoMMaster> InventoryUoMMaster = GetListInventoryUoMMasterForUomCode();
            List<SelectListItem> InventoryUoMMasterList = new List<SelectListItem>();
            foreach (InventoryUoMMaster item in InventoryUoMMaster)
            {
                InventoryUoMMasterList.Add(new SelectListItem { Text = item.UomCode, Value = Convert.ToString(item.UomCode) });
            }
            ViewBag.InventoryUoMMasterForUomCodeList = new SelectList(InventoryUoMMasterList, "Value", "Text");
            return PartialView("/Views/Inventory_1/Barcodes/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralItemMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralItemMasterDTO != null)
                {
                    model.GeneralItemMasterDTO.ConnectionString = _connectioString;
                    model.GeneralItemMasterDTO.GeneralItemCodeID = model.GeneralItemCodeID;
                    model.GeneralItemMasterDTO.GeneralItemMasterID = model.GeneralItemMasterID;
                    model.GeneralItemMasterDTO.ItemNumber = model.ItemNumber;
                    model.GeneralItemMasterDTO.ItemDescription = model.ItemDescription;
                    model.GeneralItemMasterDTO.UoMGroupCode = model.UoMGroupCode;
                    model.GeneralItemMasterDTO.UomCode = model.UomCode;
                    model.GeneralItemMasterDTO.BarCode = model.BarCode;
                    model.GeneralItemMasterDTO.IsDefault = model.IsDefault;
                    model.GeneralItemMasterDTO.IsBaseUom = model.IsBaseUom;
                    model.GeneralItemMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterServiceAcess.InsertGeneralItemBarcodes(model.GeneralItemMasterDTO);

                    model.GeneralItemMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralItemMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                IBaseEntityResponse<GeneralItemMaster> response = null;
                GeneralItemMaster GeneralItemMasterDTO = new GeneralItemMaster();
                GeneralItemMasterDTO.ConnectionString = _connectioString;
                GeneralItemMasterDTO.GeneralItemCodeID = ID;
                GeneralItemMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemMasterServiceAcess.DeleteGeneralItemBarcodes(GeneralItemMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

      
        


        #endregion

        // Non-Action Method
        #region Methods
        public JsonResult GetItemDescriptionDetails(string term)
        {
            var data = GetItemDescriptionDetailsdata(term);
            var result = (from r in data
                          select new
                          {
                              id = r.GeneralItemMasterID,
                            
                              ItemDescription = r.ItemDescription,
                              UomCode = r.UoMCode,
                              UoMGroupCode = r.UoMGroupCode,
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

        //Dropdown for General Item Merchantise Department
        protected List<InventoryUoMMaster> GetListInventoryUoMMasterForUomCode()
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryUoMMaster> ListInventoryUoMMasterForUomCode = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterServiceAccess.GetInventoryUoMMasterDropDownforUomCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMMasterForUomCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMMasterForUomCode;
        }


        protected List<InventoryUoMGroupAndDetails> GetListInventoryUoMGroup()
        {
            InventoryUoMGroupAndDetailsSearchRequest searchRequest = new InventoryUoMGroupAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryUoMGroupAndDetails> ListInventoryUoMGroup = new List<InventoryUoMGroupAndDetails>();
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> baseEntityCollectionResponse = _InventoryUoMGroupAndDetailsServiceAccess.GetInventoryUoMGroupAndDetailsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMGroup;
        }

        public IEnumerable<GeneralItemMasterViewModel> GetGeneralItemMaster(out int TotalRecords)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
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
            List<GeneralItemMasterViewModel> listGeneralItemMasterViewModel = new List<GeneralItemMasterViewModel>();
            List<GeneralItemMaster> listGeneralItemMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterServiceAcess.GetBarcodesBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralItemMaster item in listGeneralItemMaster)
                    {
                        GeneralItemMasterViewModel GeneralItemMasterViewModel = new GeneralItemMasterViewModel();
                        GeneralItemMasterViewModel.GeneralItemMasterDTO = item;
                        listGeneralItemMasterViewModel.Add(GeneralItemMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralItemMasterViewModel;
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

                IEnumerable<GeneralItemMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ItemNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ItemNumber Like '%" + param.sSearch + "%' or A.UomCode Like '%" + param.sSearch + "%' or  A.BarCode Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.UomCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ItemNumber Like '%" + param.sSearch + "%' or  A.UomCode Like '%" + param.sSearch + "%' or  A.BarCode Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "  A.BarCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ItemNumber Like '%" + param.sSearch + "%' or  A.UomCode Like '%" + param.sSearch + "%' or  A.BarCode Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralItemMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ItemNumber), Convert.ToString(c.ItemDescription), Convert.ToString(c.BarCode),Convert.ToString(c.IsDefault) , Convert.ToString(c.UomCode),  Convert.ToString(c.GeneralItemMasterID),Convert.ToString(c.GeneralItemCodeID) };

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