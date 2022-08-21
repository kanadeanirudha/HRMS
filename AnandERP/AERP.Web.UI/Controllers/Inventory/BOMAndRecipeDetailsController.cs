
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
    public class BOMAndRecipeDetailsController : BaseController
    {
        IGeneralItemMasterServiceAccess _GeneralItemMasterServiceAcess = null;
        IBOMAndRecipeDetailsServiceAccess _BOMAndRecipeDetailsServiceAcess = null;
        IInventoryUoMMasterServiceAccess _InventoryUoMMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public BOMAndRecipeDetailsController()
        {
            _BOMAndRecipeDetailsServiceAcess = new BOMAndRecipeDetailsServiceAccess();
            _GeneralItemMasterServiceAcess = new GeneralItemMasterServiceAccess();
            _InventoryUoMMasterServiceAccess = new InventoryUoMMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/BOMAndRecipeDetails/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                BOMAndRecipeDetailsViewModel model = new BOMAndRecipeDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/BOMAndRecipeDetails/List.cshtml", model);
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
            BOMAndRecipeDetailsViewModel model = new BOMAndRecipeDetailsViewModel();
            string[] IDsArray = IDs.Split('~');
            model.InventoryVariationMasterID = Convert.ToInt16(IDsArray[0]);
            model.RecipeVariationTitle = IDsArray[3];
            model.InventoryRecipeMasterTitle = IDsArray[2];
            model.InventoryRecipeMasterID = Convert.ToInt16(IDsArray[4]);

            BOMAndRecipeDetailsSearchRequest searchRequest = new BOMAndRecipeDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.InventoryVariationMasterID = Convert.ToInt16(IDsArray[0]);
            searchRequest.InventoryRecipeMasterID = Convert.ToInt16(IDsArray[4]);
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> baseEntityCollectionResponse = _BOMAndRecipeDetailsServiceAcess.SelectIngridentsByVarients(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.IngridentsListByVarients = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }

            List<InventoryUoMMaster> InventoryUoMMaster = GetListInventoryUoMMasterForUomCode();
            List<SelectListItem> InventoryUoMMasterList = new List<SelectListItem>();
            foreach (InventoryUoMMaster item in InventoryUoMMaster)
            {
                InventoryUoMMasterList.Add(new SelectListItem { Text = item.UomCode, Value = Convert.ToString(item.UomCode) });
            }
            ViewBag.InventoryUoMMasterForUomCodeList = new SelectList(InventoryUoMMasterList, "Value", "Text");

            return PartialView("/Views/Inventory_1/BOMAndRecipeDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(BOMAndRecipeDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.BOMAndRecipeDetailsDTO != null)
                {
                    model.BOMAndRecipeDetailsDTO.ConnectionString = _connectioString;
                    model.BOMAndRecipeDetailsDTO.XMLstring = model.XMLstring;
                    model.BOMAndRecipeDetailsDTO.InventoryVariationMasterID = model.InventoryVariationMasterID;
                    model.BOMAndRecipeDetailsDTO.InventoryRecipeMasterID = model.InventoryRecipeMasterID;
                    model.BOMAndRecipeDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.BOMAndRecipeDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<BOMAndRecipeDetails> response = _BOMAndRecipeDetailsServiceAcess.InsertBOMAndRecipeDetails(model.BOMAndRecipeDetailsDTO);

                    model.BOMAndRecipeDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.BOMAndRecipeDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    BOMAndRecipeDetailsViewModel model = new BOMAndRecipeDetailsViewModel();
        //    try
        //    {
        //        model.BOMAndRecipeDetailsDTO = new BOMAndRecipeDetails();
        //        model.BOMAndRecipeDetailsDTO.ID = id;
        //        model.BOMAndRecipeDetailsDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<BOMAndRecipeDetails> response = _BOMAndRecipeDetailsServiceAcess.SelectByID(model.BOMAndRecipeDetailsDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.BOMAndRecipeDetailsDTO.ID = response.Entity.ID;
        //            model.BOMAndRecipeDetailsDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.BOMAndRecipeDetailsDTO.GroupCode = response.Entity.GroupCode;
        //            model.BOMAndRecipeDetailsDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(BOMAndRecipeDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.BOMAndRecipeDetailsDTO != null)
                {
                    if (model != null && model.BOMAndRecipeDetailsDTO != null)
                    {
                        model.BOMAndRecipeDetailsDTO.ConnectionString = _connectioString;
                        //model.BOMAndRecipeDetailsDTO.GroupDescription = model.GroupDescription;
                        //// model.BOMAndRecipeDetailsDTO.SeqNo = model.SeqNo;
                        //model.BOMAndRecipeDetailsDTO.MarchandiseGroupCode = model.MarchandiseGroupCode;
                        //model.BOMAndRecipeDetailsDTO.DefaultFlag = model.DefaultFlag;
                        model.BOMAndRecipeDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<BOMAndRecipeDetails> response = _BOMAndRecipeDetailsServiceAcess.UpdateBOMAndRecipeDetails(model.BOMAndRecipeDetailsDTO);
                        model.BOMAndRecipeDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.BOMAndRecipeDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        BOMAndRecipeDetailsViewModel model = new BOMAndRecipeDetailsViewModel();
        //        model.BOMAndRecipeDetailsDTO = new BOMAndRecipeDetails();
        //        model.BOMAndRecipeDetailsDTO.ID = Convert.ToInt16(ID);
        //        model.BOMAndRecipeDetailsDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<BOMAndRecipeDetails> response = _BOMAndRecipeDetailsServiceAcess.SelectByID(model.BOMAndRecipeDetailsDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.BOMAndRecipeDetailsDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.BOMAndRecipeDetailsDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.BOMAndRecipeDetailsDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.BOMAndRecipeDetailsDTO.GenServiceRequiredID);

        //        return PartialView("/Views/BOMAndRecipeDetails/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<BOMAndRecipeDetails> response = null;
                BOMAndRecipeDetails BOMAndRecipeDetailsDTO = new BOMAndRecipeDetails();
                BOMAndRecipeDetailsDTO.ConnectionString = _connectioString;
                BOMAndRecipeDetailsDTO.InventoryRecipeFormulaDetailsID = Convert.ToInt16(ID);
                BOMAndRecipeDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _BOMAndRecipeDetailsServiceAcess.DeleteBOMAndRecipeDetails(BOMAndRecipeDetailsDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

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
        public ActionResult GetUoMCodeByItemNumber(string ItemNumber)
        {

            var UOMCodeDesc = GetUoMCodeByItemNumberList(ItemNumber);
            var result = (from s in UOMCodeDesc 
                          select new
                          {
                              id = s.ID,
                              name = s.UoMCode,
                              LowerLevelUomCode = s.LowerLevelUomCode,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<BOMAndRecipeDetails> GetUoMCodeByItemNumberList(string ItemNumber)
        {

            BOMAndRecipeDetailsSearchRequest searchRequest = new BOMAndRecipeDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);

            List<BOMAndRecipeDetails> listOrganisationDepartmentMaster = new List<BOMAndRecipeDetails>();
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> baseEntityCollectionResponse = _BOMAndRecipeDetailsServiceAcess.GetConsumptionUnitList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }


        public ActionResult GetUoMCodeWisePurchasePrice(string ItemNumber,string UoMCode)
        {

            var UOMCodeDesc = GetUoMCodeWisePurchasePriceList(ItemNumber, UoMCode);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              UomPurchasePrice = s.ConsumptionPrice,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<BOMAndRecipeDetails> GetUoMCodeWisePurchasePriceList(string ItemNumber, string UoMCode)
        {

            BOMAndRecipeDetailsSearchRequest searchRequest = new BOMAndRecipeDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);
            searchRequest.UomCode = UoMCode;
            List<BOMAndRecipeDetails> listOrganisationDepartmentMaster = new List<BOMAndRecipeDetails>();
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> baseEntityCollectionResponse = _BOMAndRecipeDetailsServiceAcess.GetUoMCodeWisePurchasePriceList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }

        [HttpPost]
        public JsonResult GetItemNumberSearchList(string term)
        {
            BOMAndRecipeDetailsSearchRequest searchRequest = new BOMAndRecipeDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<BOMAndRecipeDetails> listFeeSubType = new List<BOMAndRecipeDetails>();
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> baseEntityCollectionResponse = _BOMAndRecipeDetailsServiceAcess.GetItemsList(searchRequest);
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
                              id = r.GeneralItemMasterID,
                              name = r.ItemDescription,
                              ItemNumber = r.ItemNumber,
                              OrderUom = r.OrderUomCode,
                              PurchasePrice = r.PurchasePrice,
                              IsBOM = r.IsBOM,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<BOMAndRecipeDetailsViewModel> GetBOMAndRecipeDetails(out int TotalRecords)
        {
            BOMAndRecipeDetailsSearchRequest searchRequest = new BOMAndRecipeDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    //searchRequest.SortBy = "Cte2.CreatedDate";
                    searchRequest.SortBy = "Cte2.CreatedDate";
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
            List<BOMAndRecipeDetailsViewModel> listBOMAndRecipeDetailsViewModel = new List<BOMAndRecipeDetailsViewModel>();
            List<BOMAndRecipeDetails> listBOMAndRecipeDetails = new List<BOMAndRecipeDetails>();
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> baseEntityCollectionResponse = _BOMAndRecipeDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listBOMAndRecipeDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (BOMAndRecipeDetails item in listBOMAndRecipeDetails)
                    {
                        BOMAndRecipeDetailsViewModel BOMAndRecipeDetailsViewModel = new BOMAndRecipeDetailsViewModel();
                        BOMAndRecipeDetailsViewModel.BOMAndRecipeDetailsDTO = item;
                        listBOMAndRecipeDetailsViewModel.Add(BOMAndRecipeDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listBOMAndRecipeDetailsViewModel;
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

                IEnumerable<BOMAndRecipeDetailsViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "cte1.InventoryRecipeMasterID,cte2.InventoryVariationMasterID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "cte1.Description Like '%" + param.sSearch + "%' or cte2.ItemDescription Like '%" + param.sSearch + "%' or cte2.Quantity Like '%" + param.sSearch + "%' or cte2.UOMCode Like '%" + param.sSearch + "%' or cte1.RecipeVariationTitle Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "cte1.InventoryRecipeMasterID,cte2.InventoryVariationMasterID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "cte2.ItemDescription Like '%" + param.sSearch + "%' or cte2.Quantity Like '%" + param.sSearch + "%' or cte2.UOMCode Like '%" + param.sSearch + "%' or cte1.Description Like '%" + param.sSearch + "%' or cte1.RecipeVariationTitle Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "cte1.InventoryRecipeMasterID,cte2.Quantity";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "D.ItemDescription Like '%" + param.sSearch + "%' or C.Quantity Like '%" + param.sSearch + "%' or C.UOMCode Like '%" + param.sSearch + "%' or cte1.Description Like '%" + param.sSearch + "%' or cte1.RecipeVariationTitle Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "Cte2.WastageInPercentage";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "D.ItemDescription Like '%" + param.sSearch + "%' or C.Quantity Like '%" + param.sSearch + "%' or C.UOMCode Like '%" + param.sSearch + "%' or cte1.Description Like '%" + param.sSearch + "%' or cte1.RecipeVariationTitle Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "cte1.InventoryRecipeMasterID,cte2.InventoryVariationMasterID,cte2.UOMCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "D.ItemDescription Like '%" + param.sSearch + "%' or C.Quantity Like '%" + param.sSearch + "%' or C.UOMCode Like '%" + param.sSearch + "%' or cte1.Description Like '%" + param.sSearch + "%' or cte1.RecipeVariationTitle Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetBOMAndRecipeDetails(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.InventoryVariationMasterID), Convert.ToString(c.InventoryRecipeMasterTitle) + " " + "-" + " " + Convert.ToString(c.RecipeVariationTitle), Convert.ToString(c.ItemDescription), Convert.ToString(c.ID), Convert.ToString(c.Quantity), Convert.ToString(c.UoMCode), Convert.ToString(c.InventoryRecipeMasterTitle), Convert.ToString(c.RecipeVariationTitle), Convert.ToString(c.InventoryRecipeFormulaDetailsID), Convert.ToString(c.InventoryRecipeMasterID), Convert.ToString(c.WastageInPercentage) };

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