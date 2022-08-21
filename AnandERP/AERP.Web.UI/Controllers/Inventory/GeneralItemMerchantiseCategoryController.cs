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
    public class GeneralItemMerchantiseCategoryController : BaseController
    {
        IGeneralItemMerchantiseCategoryBA _GeneralItemMerchantiseCategoryBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralItemMerchantiseCategoryController()
        {
            _GeneralItemMerchantiseCategoryBA = new GeneralItemMerchantiseCategoryBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralItemMerchantiseCategory/Index.cshtml");
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
                GeneralItemMerchantiseCategoryViewModel model = new GeneralItemMerchantiseCategoryViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralItemMerchantiseCategory/List.cshtml", model);
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
            GeneralItemMerchantiseCategoryViewModel model = new GeneralItemMerchantiseCategoryViewModel();

            return PartialView("/Views/Inventory/GeneralItemMerchantiseCategory/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralItemMerchantiseCategoryViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralItemMerchantiseCategoryDTO != null)
                {
                    model.GeneralItemMerchantiseCategoryDTO.ConnectionString = _connectioString;
                    model.GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryName = model.MerchantiseCategoryName;
                    model.GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryCode = model.MerchantiseCategoryCode;
                    model.GeneralItemMerchantiseCategoryDTO.MerchandiseDepartmentID = model.MerchandiseDepartmentID;
                    model.GeneralItemMerchantiseCategoryDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralItemMerchantiseCategory> response = _GeneralItemMerchantiseCategoryBA.InsertGeneralItemMerchantiseCategory(model.GeneralItemMerchantiseCategoryDTO);

                    model.GeneralItemMerchantiseCategoryDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralItemMerchantiseCategoryDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralItemMerchantiseCategoryViewModel model = new GeneralItemMerchantiseCategoryViewModel();
            try
            {
                model.GeneralItemMerchantiseCategoryDTO = new GeneralItemMerchantiseCategory();
                model.GeneralItemMerchantiseCategoryDTO.ID = Convert.ToInt16(id);
                model.GeneralItemMerchantiseCategoryDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralItemMerchantiseCategory> response = _GeneralItemMerchantiseCategoryBA.SelectByID(model.GeneralItemMerchantiseCategoryDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMerchantiseCategoryDTO.ID = response.Entity.ID;
                    model.GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryCode = response.Entity.MerchantiseCategoryCode;
                    model.GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryName = response.Entity.MerchantiseCategoryName;
                    model.GeneralItemMerchantiseCategoryDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/GeneralItemMerchantiseCategory/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralItemMerchantiseCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralItemMerchantiseCategoryDTO != null)
                {
                    if (model != null && model.GeneralItemMerchantiseCategoryDTO != null)
                    {
                        model.GeneralItemMerchantiseCategoryDTO.ConnectionString = _connectioString;
                        model.GeneralItemMerchantiseCategoryDTO.ID = model.ID;
                        model.GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryName = model.MerchantiseCategoryName;
                        model.GeneralItemMerchantiseCategoryDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemMerchantiseCategory> response = _GeneralItemMerchantiseCategoryBA.UpdateGeneralItemMerchantiseCategory(model.GeneralItemMerchantiseCategoryDTO);
                        model.GeneralItemMerchantiseCategoryDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralItemMerchantiseCategoryDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        GeneralItemMerchantiseCategoryViewModel model = new GeneralItemMerchantiseCategoryViewModel();
        //        model.GeneralItemMerchantiseCategoryDTO = new GeneralItemMerchantiseCategory();
        //        model.GeneralItemMerchantiseCategoryDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralItemMerchantiseCategoryDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralItemMerchantiseCategory> response = _GeneralItemMerchantiseCategoryBA.SelectByID(model.GeneralItemMerchantiseCategoryDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralItemMerchantiseCategoryDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralItemMerchantiseCategoryDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralItemMerchantiseCategoryDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralItemMerchantiseCategoryDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralItemMerchantiseCategory/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralItemMerchantiseCategory> response = null;
                GeneralItemMerchantiseCategory GeneralItemMerchantiseCategoryDTO = new GeneralItemMerchantiseCategory();
                GeneralItemMerchantiseCategoryDTO.ConnectionString = _connectioString;
                GeneralItemMerchantiseCategoryDTO.ID = Convert.ToInt16(ID);
                GeneralItemMerchantiseCategoryDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemMerchantiseCategoryBA.DeleteGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategoryDTO);
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
        public IEnumerable<GeneralItemMerchantiseCategoryViewModel> GetGeneralItemMerchantiseCategory(out int TotalRecords)
        {
            GeneralItemMerchantiseCategorySearchRequest searchRequest = new GeneralItemMerchantiseCategorySearchRequest();
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
            List<GeneralItemMerchantiseCategoryViewModel> listGeneralItemMerchantiseCategoryViewModel = new List<GeneralItemMerchantiseCategoryViewModel>();
            List<GeneralItemMerchantiseCategory> listGeneralItemMerchantiseCategory = new List<GeneralItemMerchantiseCategory>();
            IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> baseEntityCollectionResponse = _GeneralItemMerchantiseCategoryBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMerchantiseCategory = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralItemMerchantiseCategory item in listGeneralItemMerchantiseCategory)
                    {
                        GeneralItemMerchantiseCategoryViewModel GeneralItemMerchantiseCategoryViewModel = new GeneralItemMerchantiseCategoryViewModel();
                        GeneralItemMerchantiseCategoryViewModel.GeneralItemMerchantiseCategoryDTO = item;
                        listGeneralItemMerchantiseCategoryViewModel.Add(GeneralItemMerchantiseCategoryViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralItemMerchantiseCategoryViewModel;
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

                IEnumerable<GeneralItemMerchantiseCategoryViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.MerchantiseCategoryName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MerchantiseCategoryName Like '%" + param.sSearch + "%' or A.MerchantiseCategoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.MerchantiseCategoryCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MerchantiseCategoryName Like '%" + param.sSearch + "%' or A.MerchantiseCategoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralItemMerchantiseCategory(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.MerchantiseCategoryName), Convert.ToString(c.MerchantiseCategoryCode), Convert.ToString(c.ID) };

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