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
    public class GeneralItemMarchandiseSubCategoryController : BaseController
    {
        IGeneralItemMarchandiseSubCategoryBA _GeneralItemMarchandiseSubCategoryBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralItemMarchandiseSubCategoryController()
        {
            _GeneralItemMarchandiseSubCategoryBA = new GeneralItemMarchandiseSubCategoryBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralItemMarchandiseSubCategory/Index.cshtml");
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
                GeneralItemMarchandiseSubCategoryViewModel model = new GeneralItemMarchandiseSubCategoryViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralItemMarchandiseSubCategory/List.cshtml", model);
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
            GeneralItemMarchandiseSubCategoryViewModel model = new GeneralItemMarchandiseSubCategoryViewModel();

            return PartialView("/Views/Inventory/GeneralItemMarchandiseSubCategory/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralItemMarchandiseSubCategoryViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralItemMarchandiseSubCategoryDTO != null)
                {
                    model.GeneralItemMarchandiseSubCategoryDTO.ConnectionString = _connectioString;
                    model.GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryName = model.MarchantiseSubCategoryName;
                    model.GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryCode = model.MarchantiseSubCategoryCode;
                    model.GeneralItemMarchandiseSubCategoryDTO.MerchandiseCategoryID = model.MerchandiseCategoryID;
                    model.GeneralItemMarchandiseSubCategoryDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralItemMarchandiseSubCategory> response = _GeneralItemMarchandiseSubCategoryBA.InsertGeneralItemMarchandiseSubCategory(model.GeneralItemMarchandiseSubCategoryDTO);

                    model.GeneralItemMarchandiseSubCategoryDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralItemMarchandiseSubCategoryDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {
            GeneralItemMarchandiseSubCategoryViewModel model = new GeneralItemMarchandiseSubCategoryViewModel();
            try
            {
                model.GeneralItemMarchandiseSubCategoryDTO = new GeneralItemMarchandiseSubCategory();
                model.GeneralItemMarchandiseSubCategoryDTO.ID = Convert.ToInt16(id);
                model.GeneralItemMarchandiseSubCategoryDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralItemMarchandiseSubCategory> response = _GeneralItemMarchandiseSubCategoryBA.SelectByID(model.GeneralItemMarchandiseSubCategoryDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMarchandiseSubCategoryDTO.ID = response.Entity.ID;
                    model.GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryName = response.Entity.MarchantiseSubCategoryName;
                    model.GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryCode = response.Entity.MarchantiseSubCategoryCode;
                    model.GeneralItemMarchandiseSubCategoryDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/GeneralItemMarchandiseSubCategory/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralItemMarchandiseSubCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralItemMarchandiseSubCategoryDTO != null)
                {
                    if (model != null && model.GeneralItemMarchandiseSubCategoryDTO != null)
                    {
                        model.GeneralItemMarchandiseSubCategoryDTO.ConnectionString = _connectioString;
                        model.GeneralItemMarchandiseSubCategoryDTO.ID = model.ID;
                        model.GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryName = model.MarchantiseSubCategoryName;
                        model.GeneralItemMarchandiseSubCategoryDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> response = _GeneralItemMarchandiseSubCategoryBA.UpdateGeneralItemMarchandiseSubCategory(model.GeneralItemMarchandiseSubCategoryDTO);
                        model.GeneralItemMarchandiseSubCategoryDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralItemMarchandiseSubCategoryDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        GeneralItemMarchandiseSubCategoryViewModel model = new GeneralItemMarchandiseSubCategoryViewModel();
        //        model.GeneralItemMarchandiseSubCategoryDTO = new GeneralItemMarchandiseSubCategory();
        //        model.GeneralItemMarchandiseSubCategoryDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralItemMarchandiseSubCategoryDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> response = _GeneralItemMarchandiseSubCategoryBA.SelectByID(model.GeneralItemMarchandiseSubCategoryDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralItemMarchandiseSubCategoryDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralItemMarchandiseSubCategoryDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralItemMarchandiseSubCategoryDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralItemMarchandiseSubCategoryDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralItemMarchandiseSubCategory/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralItemMarchandiseSubCategory> response = null;
                GeneralItemMarchandiseSubCategory GeneralItemMarchandiseSubCategoryDTO = new GeneralItemMarchandiseSubCategory();
                GeneralItemMarchandiseSubCategoryDTO.ConnectionString = _connectioString;
                GeneralItemMarchandiseSubCategoryDTO.ID = Convert.ToInt16(ID);
                GeneralItemMarchandiseSubCategoryDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemMarchandiseSubCategoryBA.DeleteGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategoryDTO);
                string errorMessageDis = string.Empty;
                string colorCode = string.Empty;
                string mode = string.Empty;
                if (response.Entity.ErrorCode == 77)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "danger";
                }
                else if (response.Entity.ErrorCode == 0)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "success";
                }
                string[] arrayList = { errorMessageDis, colorCode, mode };
                errorMessage = string.Join(",", arrayList);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralItemMarchandiseSubCategoryViewModel> GetGeneralItemMarchandiseSubCategory(out int TotalRecords)
        {
            GeneralItemMarchandiseSubCategorySearchRequest searchRequest = new GeneralItemMarchandiseSubCategorySearchRequest();
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
            List<GeneralItemMarchandiseSubCategoryViewModel> listGeneralItemMarchandiseSubCategoryViewModel = new List<GeneralItemMarchandiseSubCategoryViewModel>();
            List<GeneralItemMarchandiseSubCategory> listGeneralItemMarchandiseSubCategory = new List<GeneralItemMarchandiseSubCategory>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> baseEntityCollectionResponse = _GeneralItemMarchandiseSubCategoryBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMarchandiseSubCategory = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralItemMarchandiseSubCategory item in listGeneralItemMarchandiseSubCategory)
                    {
                        GeneralItemMarchandiseSubCategoryViewModel GeneralItemMarchandiseSubCategoryViewModel = new GeneralItemMarchandiseSubCategoryViewModel();
                        GeneralItemMarchandiseSubCategoryViewModel.GeneralItemMarchandiseSubCategoryDTO = item;
                        listGeneralItemMarchandiseSubCategoryViewModel.Add(GeneralItemMarchandiseSubCategoryViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralItemMarchandiseSubCategoryViewModel;
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

                IEnumerable<GeneralItemMarchandiseSubCategoryViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.MerchantiseSubCategoryName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MerchantiseSubCategoryName Like '%" + param.sSearch + "%' or A.MerchantiseSubCategoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.MerchantiseSubCategoryCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MerchantiseSubCategoryName Like '%" + param.sSearch + "%' or A.MerchantiseSubCategoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralItemMarchandiseSubCategory(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.MarchantiseSubCategoryName), Convert.ToString(c.MarchantiseSubCategoryCode), Convert.ToString(c.ID) };

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