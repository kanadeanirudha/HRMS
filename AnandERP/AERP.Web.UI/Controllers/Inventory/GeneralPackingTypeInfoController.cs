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
    public class GeneralPackingTypeInfoController : BaseController
    {
        IGeneralPackingTypeInfoServiceAccess _GeneralPackingTypeInfoServiceAcess = null;
        IGeneralPackageTypeServiceAccess _GeneralPackageTypeServiceAccess = null;
        IInventoryUoMMasterServiceAccess _InventoryUoMMasterServiceAccess = null;
        IGeneralItemMasterServiceAccess _GeneralItemMasterServiceAccess = null;


        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralPackingTypeInfoController()
        {
            _GeneralPackingTypeInfoServiceAcess = new GeneralPackingTypeInfoServiceAccess();
            _GeneralPackageTypeServiceAccess = new GeneralPackageTypeServiceAccess();
            _InventoryUoMMasterServiceAccess = new InventoryUoMMasterServiceAccess();
            _GeneralItemMasterServiceAccess = new GeneralItemMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/GeneralPackingTypeInfo/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralPackingTypeInfoViewModel model = new GeneralPackingTypeInfoViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/GeneralPackingTypeInfo/List.cshtml", model);
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
            GeneralPackingTypeInfoViewModel model = new GeneralPackingTypeInfoViewModel();
            List<GeneralPackageType> GeneralPackageType = GetListGeneralPackageType();
            List<SelectListItem> GeneralPackageTypeList = new List<SelectListItem>();
            foreach (GeneralPackageType item in GeneralPackageType)
            {
                GeneralPackageTypeList.Add(new SelectListItem { Text = item.PackageType, Value = Convert.ToString(item.ID) });
            }
            ViewBag.InventoryRecipeList = new SelectList(GeneralPackageTypeList, "Value", "Text");





            return PartialView("/Views/Inventory_1/GeneralPackingTypeInfo/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPackingTypeInfoViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralPackingTypeInfoDTO != null)
                {
                    model.GeneralPackingTypeInfoDTO.ConnectionString = _connectioString;

                    model.GeneralPackingTypeInfoDTO.ItemCodeID = model.ItemCodeID;
                    model.GeneralPackingTypeInfoDTO.UomCode = model.UomCode;
                    model.GeneralPackingTypeInfoDTO.PackageTypeID = model.PackageTypeID;
                    model.GeneralPackingTypeInfoDTO.QuantityPerPackage = model.QuantityPerPackage;
                    model.GeneralPackingTypeInfoDTO.Height = model.Height;
                    model.GeneralPackingTypeInfoDTO.Length = model.Length;
                    model.GeneralPackingTypeInfoDTO.Width = model.Width;
                    model.GeneralPackingTypeInfoDTO.Weight = model.Weight;
                    model.GeneralPackingTypeInfoDTO.Volume = model.Volume;
                    model.GeneralPackingTypeInfoDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPackingTypeInfo> response = _GeneralPackingTypeInfoServiceAcess.InsertGeneralPackingTypeInfo(model.GeneralPackingTypeInfoDTO);

                    model.GeneralPackingTypeInfoDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralPackingTypeInfoDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(GeneralPackingTypeInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralPackingTypeInfoDTO != null)
                {
                    if (model != null && model.GeneralPackingTypeInfoDTO != null)
                    {
                        model.GeneralPackingTypeInfoDTO.ConnectionString = _connectioString;
                        //model.GeneralPackingTypeInfoDTO.GeneralPackingTypeInfoCode = model.GeneralPackingTypeInfoCode;
                        //model.GeneralPackingTypeInfoDTO.GeneralPackingTypeInfoDescription = model.GeneralPackingTypeInfoDescription;
                        //model.GeneralPackingTypeInfoDTO.IsRelatedTo = model.IsRelatedTo;
                        model.GeneralPackingTypeInfoDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralPackingTypeInfo> response = _GeneralPackingTypeInfoServiceAcess.UpdateGeneralPackingTypeInfo(model.GeneralPackingTypeInfoDTO);
                        model.GeneralPackingTypeInfoDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralPackingTypeInfoDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult ViewDetails(string ID)
        {
            try
            {
                GeneralPackingTypeInfoViewModel model = new GeneralPackingTypeInfoViewModel();
                model.GeneralPackingTypeInfoDTO = new GeneralPackingTypeInfo();
                model.GeneralPackingTypeInfoDTO.ID = Convert.ToInt16(ID);
                model.GeneralPackingTypeInfoDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralPackingTypeInfo> response = _GeneralPackingTypeInfoServiceAcess.SelectByID(model.GeneralPackingTypeInfoDTO);
                if (response != null && response.Entity != null)
                {
                    //model.GeneralPackingTypeInfoDTO.PackageType = response.Entity.PackageType;
                    model.GeneralPackingTypeInfoDTO.ItemDescription = response.Entity.ItemDescription;
                    model.GeneralPackingTypeInfoDTO.UomCode = response.Entity.UomCode;
                    model.GeneralPackingTypeInfoDTO.PackageType = response.Entity.PackageType;
                    model.GeneralPackingTypeInfoDTO.QuantityPerPackage = response.Entity.QuantityPerPackage;
                   
                }

                return PartialView("/Views/Inventory_1/GeneralPackingTypeInfo/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralPackingTypeInfo> response = null;
                GeneralPackingTypeInfo GeneralPackingTypeInfoDTO = new GeneralPackingTypeInfo();
                GeneralPackingTypeInfoDTO.ConnectionString = _connectioString;
                GeneralPackingTypeInfoDTO.ID = Convert.ToInt16(ID);
                GeneralPackingTypeInfoDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralPackingTypeInfoServiceAcess.DeleteGeneralPackingTypeInfo(GeneralPackingTypeInfoDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods

        public JsonResult GetUomCodeDetails(string term)
        {
            var data = GetUomCodeDetailsdata(term);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.UomCode,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<InventoryUoMMaster> GetUomCodeDetailsdata(string SearchKeyWord)
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;

            List<InventoryUoMMaster> listAccount = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }


        public JsonResult GetItemDescriptionDetails(string term)
        {
            var data = GetItemDescriptionDetailsdata(term);
            var result = (from r in data
                          select new
                          {
                              id = r.GeneralItemCodeID,
                              name = r.ItemDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<GeneralItemMaster> GetItemDescriptionDetailsdata(string SearchKeyWord)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;

            List<GeneralItemMaster> listAccount = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterServiceAccess.SearchListForGeneralPackingTypeInfo(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }

        protected List<GeneralPackageType> GetListGeneralPackageType()
        {
            GeneralPackageTypeSearchRequest searchRequest = new GeneralPackageTypeSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPackageType> listAdmin = new List<GeneralPackageType>();
            IBaseEntityCollectionResponse<GeneralPackageType> baseEntityCollectionResponse = _GeneralPackageTypeServiceAccess.GetGeneralPackageTypeSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }
      
        public IEnumerable<GeneralPackingTypeInfoViewModel> GetGeneralPackingTypeInfo(out int TotalRecords)
        {
            GeneralPackingTypeInfoSearchRequest searchRequest = new GeneralPackingTypeInfoSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
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
            List<GeneralPackingTypeInfoViewModel> listGeneralPackingTypeInfoViewModel = new List<GeneralPackingTypeInfoViewModel>();
            List<GeneralPackingTypeInfo> listGeneralPackingTypeInfo = new List<GeneralPackingTypeInfo>();
            IBaseEntityCollectionResponse<GeneralPackingTypeInfo> baseEntityCollectionResponse = _GeneralPackingTypeInfoServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPackingTypeInfo = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPackingTypeInfo item in listGeneralPackingTypeInfo)
                    {
                        GeneralPackingTypeInfoViewModel GeneralPackingTypeInfoViewModel = new GeneralPackingTypeInfoViewModel();
                        GeneralPackingTypeInfoViewModel.GeneralPackingTypeInfoDTO = item;
                        listGeneralPackingTypeInfoViewModel.Add(GeneralPackingTypeInfoViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPackingTypeInfoViewModel;
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

                IEnumerable<GeneralPackingTypeInfoViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.ItemDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or cte1.UomCOde Like '%" + param.sSearch + "%' or D.PackageType Like '%" + param.sSearch + "%' or cte1.QuantityPerPackage Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "cte1.UomCOde";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or cte1.UomCOde Like '%" + param.sSearch + "%' or D.PackageType Like '%" + param.sSearch + "%' or cte1.QuantityPerPackage Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "D.PackageType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //this "if" block is added for search functionality
                            _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or cte1.UomCOde Like '%" + param.sSearch + "%' or D.PackageType Like '%" + param.sSearch + "%' or cte1.QuantityPerPackage Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "cte1.QuantityPerPackage";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or cte1.UomCOde Like '%" + param.sSearch + "%' or D.PackageType Like '%" + param.sSearch + "%' or cte1.QuantityPerPackage Like '%" + param.sSearch + "%'";
                        }
                        break;
                  
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralPackingTypeInfo(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ItemDescription),Convert.ToString(c.UomCode), Convert.ToString(c.PackageType), Convert.ToString(c.QuantityPerPackage), Convert.ToString(c.ID) };

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