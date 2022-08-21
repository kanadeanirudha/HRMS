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
    public class InventoryRecipeMenuCategoryController : BaseController
    {
        IInventoryRecipeMenuCategoryServiceAccess _InventoryRecipeMenuCategoryServiceAcess = null;
        IGeneralItemCategoryMasterServiceAccess _GeneralItemCategoryMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryRecipeMenuCategoryController()
        {
            _InventoryRecipeMenuCategoryServiceAcess = new InventoryRecipeMenuCategoryServiceAccess();
            _GeneralItemCategoryMasterServiceAccess = new GeneralItemCategoryMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/InventoryRecipeMenuCategory/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                InventoryRecipeMenuCategoryViewModel model = new InventoryRecipeMenuCategoryViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/InventoryRecipeMenuCategory/List.cshtml", model);
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
            InventoryRecipeMenuCategoryViewModel model = new InventoryRecipeMenuCategoryViewModel();

            List<SelectListItem> CategoryType = new List<SelectListItem>();
            ViewBag.CategoryType = new SelectList(CategoryType, "Value", "Text");
            List<SelectListItem> li_CategoryType = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });s
            li_CategoryType.Add(new SelectListItem { Text = "Restaurant", Value = "1" });
            li_CategoryType.Add(new SelectListItem { Text = "Retail", Value = "2" });
            li_CategoryType.Add(new SelectListItem { Text = "BOM", Value = "3" });
            ViewData["CategoryType"] = li_CategoryType;

            List<GeneralItemCategoryMaster> GeneralItemCategoryMaster = GetListGeneralItemCategoryMaster();
            List<SelectListItem> GeneralItemCategoryMasterList = new List<SelectListItem>();
            foreach (GeneralItemCategoryMaster item in GeneralItemCategoryMaster)
            {
                GeneralItemCategoryMasterList.Add(new SelectListItem { Text = item.ItemCategoryCode, Value = Convert.ToString(item.ItemCategoryCode) });
            }
            ViewBag.GeneralItemCategoryMasterList = new SelectList(GeneralItemCategoryMasterList, "Value", "Text");
            return PartialView("/Views/Inventory_1/InventoryRecipeMenuCategory/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryRecipeMenuCategoryViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                IBaseEntityResponse<InventoryRecipeMenuCategory> response = null;
                if (model != null && model.InventoryRecipeMenuCategoryDTO != null)
                {
                    model.InventoryRecipeMenuCategoryDTO.ConnectionString = _connectioString;
                    model.InventoryRecipeMenuCategoryDTO.MenuCategory = model.MenuCategory;
                    model.InventoryRecipeMenuCategoryDTO.MenuCategoryCode = model.MenuCategoryCode;
                    model.InventoryRecipeMenuCategoryDTO.CategoryType = model.CategoryType;
                    model.InventoryRecipeMenuCategoryDTO.ItemCategoryCode = model.ItemCategoryCode;
                    model.InventoryRecipeMenuCategoryDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    response = _InventoryRecipeMenuCategoryServiceAcess.InsertInventoryRecipeMenuCategory(model.InventoryRecipeMenuCategoryDTO);
                    if (response.Entity.ErrorCode == 77)
                    {
                        model.InventoryRecipeMenuCategoryDTO.errorMessage = "Only One Retail Category type can be added for Recipe Menu,warning";
                    }
                    else
                    {
                        model.InventoryRecipeMenuCategoryDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.InventoryRecipeMenuCategoryDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(Int16 id)
        {
            InventoryRecipeMenuCategoryViewModel model = new InventoryRecipeMenuCategoryViewModel();
            try
            {
                model.InventoryRecipeMenuCategoryDTO = new InventoryRecipeMenuCategory();
                model.InventoryRecipeMenuCategoryDTO.ID = id;
                model.InventoryRecipeMenuCategoryDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<InventoryRecipeMenuCategory> response = _InventoryRecipeMenuCategoryServiceAcess.SelectByID(model.InventoryRecipeMenuCategoryDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryRecipeMenuCategoryDTO.ID = response.Entity.ID;
                    model.InventoryRecipeMenuCategoryDTO.MenuCategory = response.Entity.MenuCategory;
                    model.InventoryRecipeMenuCategoryDTO.MenuCategoryCode = response.Entity.MenuCategoryCode;
                    model.InventoryRecipeMenuCategoryDTO.CategoryType = response.Entity.CategoryType;
                    model.InventoryRecipeMenuCategoryDTO.ItemCategoryCode = response.Entity.ItemCategoryCode;
                    model.InventoryRecipeMenuCategoryDTO.IsActive = response.Entity.IsActive;
                    model.InventoryRecipeMenuCategoryDTO.CreatedBy = response.Entity.CreatedBy;
                }

                List<SelectListItem> CategoryType = new List<SelectListItem>();
                ViewBag.CategoryType = new SelectList(CategoryType, "Value", "Text");
                List<SelectListItem> li_CategoryType = new List<SelectListItem>();
                li_CategoryType.Add(new SelectListItem { Text = "Restaurant", Value = "1" });
                li_CategoryType.Add(new SelectListItem { Text = "Retail", Value = "2" });
                li_CategoryType.Add(new SelectListItem { Text = "BOM", Value = "3" });
                ViewData["CategoryType"] = new SelectList(li_CategoryType, "Value", "Text", (model.InventoryRecipeMenuCategoryDTO.CategoryType).ToString().Trim());

                List<GeneralItemCategoryMaster> GeneralItemCategoryMaster = GetListGeneralItemCategoryMaster();
                List<SelectListItem> GeneralItemCategoryMasterList = new List<SelectListItem>();
                foreach (GeneralItemCategoryMaster item in GeneralItemCategoryMaster)
                {
                    GeneralItemCategoryMasterList.Add(new SelectListItem { Text = item.ItemCategoryCode, Value = Convert.ToString(item.ItemCategoryCode) });
                }
                ViewBag.GeneralItemCategoryMasterList = new SelectList(GeneralItemCategoryMasterList, "Value", "Text",(model.InventoryRecipeMenuCategoryDTO.ItemCategoryCode).ToString().Trim());

                return PartialView("/Views/Inventory_1/InventoryRecipeMenuCategory/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryRecipeMenuCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryRecipeMenuCategoryDTO != null)
                {
                    if (model != null && model.InventoryRecipeMenuCategoryDTO != null)
                    {
                        model.InventoryRecipeMenuCategoryDTO.ConnectionString = _connectioString;
                        model.InventoryRecipeMenuCategoryDTO.MenuCategory = model.MenuCategory;
                        model.InventoryRecipeMenuCategoryDTO.MenuCategoryCode = model.MenuCategoryCode;
                        model.InventoryRecipeMenuCategoryDTO.ItemCategoryCode = model.ItemCategoryCode;
                        model.InventoryRecipeMenuCategoryDTO.IsActive = model.IsActive;
                        model.InventoryRecipeMenuCategoryDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryRecipeMenuCategory> response = _InventoryRecipeMenuCategoryServiceAcess.UpdateInventoryRecipeMenuCategory(model.InventoryRecipeMenuCategoryDTO);
                        //model.InventoryRecipeMenuCategoryDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                //return Json(model.InventoryRecipeMenuCategoryDTO.errorMessage, JsonRequestBehavior.AllowGet);
                return Json(model, JsonRequestBehavior.AllowGet);
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
        //        InventoryRecipeMenuCategoryViewModel model = new InventoryRecipeMenuCategoryViewModel();
        //        model.InventoryRecipeMenuCategoryDTO = new InventoryRecipeMenuCategory();
        //        model.InventoryRecipeMenuCategoryDTO.ID = Convert.ToInt16(ID);
        //        model.InventoryRecipeMenuCategoryDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryRecipeMenuCategory> response = _InventoryRecipeMenuCategoryServiceAcess.SelectByID(model.InventoryRecipeMenuCategoryDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryRecipeMenuCategoryDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.InventoryRecipeMenuCategoryDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.InventoryRecipeMenuCategoryDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.InventoryRecipeMenuCategoryDTO.GenServiceRequiredID);

        //        return PartialView("/Views/InventoryRecipeMenuCategory/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<InventoryRecipeMenuCategory> response = null;
                InventoryRecipeMenuCategory InventoryRecipeMenuCategoryDTO = new InventoryRecipeMenuCategory();
                InventoryRecipeMenuCategoryDTO.ConnectionString = _connectioString;
                InventoryRecipeMenuCategoryDTO.ID = Convert.ToInt16(ID);
                InventoryRecipeMenuCategoryDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryRecipeMenuCategoryServiceAcess.DeleteInventoryRecipeMenuCategory(InventoryRecipeMenuCategoryDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        protected List<GeneralItemCategoryMaster> GetListGeneralItemCategoryMaster()
        {
            GeneralItemCategoryMasterSearchRequest searchRequest = new GeneralItemCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralItemCategoryMaster> listtGeneralPriceGroup = new List<GeneralItemCategoryMaster>();
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> baseEntityCollectionResponse = _GeneralItemCategoryMasterServiceAccess.GetGeneralItemCategoryMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }
        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryRecipeMenuCategoryViewModel> GetInventoryRecipeMenuCategory(out int TotalRecords)
        {
            InventoryRecipeMenuCategorySearchRequest searchRequest = new InventoryRecipeMenuCategorySearchRequest();
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
            List<InventoryRecipeMenuCategoryViewModel> listInventoryRecipeMenuCategoryViewModel = new List<InventoryRecipeMenuCategoryViewModel>();
            List<InventoryRecipeMenuCategory> listInventoryRecipeMenuCategory = new List<InventoryRecipeMenuCategory>();
            IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> baseEntityCollectionResponse = _InventoryRecipeMenuCategoryServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryRecipeMenuCategory = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryRecipeMenuCategory item in listInventoryRecipeMenuCategory)
                    {
                        InventoryRecipeMenuCategoryViewModel InventoryRecipeMenuCategoryViewModel = new InventoryRecipeMenuCategoryViewModel();
                        InventoryRecipeMenuCategoryViewModel.InventoryRecipeMenuCategoryDTO = item;
                        listInventoryRecipeMenuCategoryViewModel.Add(InventoryRecipeMenuCategoryViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryRecipeMenuCategoryViewModel;
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

                IEnumerable<InventoryRecipeMenuCategoryViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.MenuCategory";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MenuCategory Like '%" + param.sSearch + "%' or A.MenuCategoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.MenuCategoryCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MenuCategory Like '%" + param.sSearch + "%' or A.MenuCategoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.CategoryType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MenuCategory Like '%" + param.sSearch + "%' or A.MenuCategoryCode Like '%" + param.sSearch + "%' or A.CategoryType like '%"+param.sSearch+"%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetInventoryRecipeMenuCategory(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.MenuCategory), Convert.ToString(c.MenuCategoryCode), Convert.ToString(c.ID), Convert.ToString(c.CategoryType) };

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