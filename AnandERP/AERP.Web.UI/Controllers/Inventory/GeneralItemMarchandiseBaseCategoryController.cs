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
    public class GeneralItemMarchandiseBaseCategoryController : BaseController
    {
        IGeneralItemMarchandiseBaseCategoryBA _GeneralItemMarchandiseBaseCategoryBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralItemMarchandiseBaseCategoryController()
        {
            _GeneralItemMarchandiseBaseCategoryBA = new GeneralItemMarchandiseBaseCategoryBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralItemMarchandiseBaseCategory/Index.cshtml");
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
                GeneralItemMarchandiseBaseCategoryViewModel model = new GeneralItemMarchandiseBaseCategoryViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralItemMarchandiseBaseCategory/List.cshtml", model);
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
            GeneralItemMarchandiseBaseCategoryViewModel model = new GeneralItemMarchandiseBaseCategoryViewModel();

            return PartialView("/Views/Inventory/GeneralItemMarchandiseBaseCategory/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralItemMarchandiseBaseCategoryViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralItemMarchandiseBaseCategoryDTO != null)
                {
                    model.GeneralItemMarchandiseBaseCategoryDTO.ConnectionString = _connectioString;
                    model.GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryName = model.MarchandiseBaseCategoryName;
                    model.GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryCode = model.MarchandiseBaseCategoryCode;
                    model.GeneralItemMarchandiseBaseCategoryDTO.MarchandiseSubCategoryID = model.MarchandiseSubCategoryID;
                    model.GeneralItemMarchandiseBaseCategoryDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> response = _GeneralItemMarchandiseBaseCategoryBA.InsertGeneralItemMarchandiseBaseCategory(model.GeneralItemMarchandiseBaseCategoryDTO);

                    model.GeneralItemMarchandiseBaseCategoryDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralItemMarchandiseBaseCategoryDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralItemMarchandiseBaseCategoryViewModel model = new GeneralItemMarchandiseBaseCategoryViewModel();
            try
            {
                model.GeneralItemMarchandiseBaseCategoryDTO = new GeneralItemMarchandiseBaseCategory();
                model.GeneralItemMarchandiseBaseCategoryDTO.ID = Convert.ToInt16(id);
                model.GeneralItemMarchandiseBaseCategoryDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> response = _GeneralItemMarchandiseBaseCategoryBA.SelectByID(model.GeneralItemMarchandiseBaseCategoryDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMarchandiseBaseCategoryDTO.ID = response.Entity.ID;
                    model.GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryCode = response.Entity.MarchandiseBaseCategoryCode;
                    model.GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryName = response.Entity.MarchandiseBaseCategoryName;
                }
                return PartialView("/Views/Inventory/GeneralItemMarchandiseBaseCategory/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralItemMarchandiseBaseCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralItemMarchandiseBaseCategoryDTO != null)
                {
                    if (model != null && model.GeneralItemMarchandiseBaseCategoryDTO != null)
                    {
                        model.GeneralItemMarchandiseBaseCategoryDTO.ConnectionString = _connectioString;
                        model.GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryName = model.MarchandiseBaseCategoryName;
                        model.GeneralItemMarchandiseBaseCategoryDTO.ID = model.ID;
                        model.GeneralItemMarchandiseBaseCategoryDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> response = _GeneralItemMarchandiseBaseCategoryBA.UpdateGeneralItemMarchandiseBaseCategory(model.GeneralItemMarchandiseBaseCategoryDTO);
                        model.GeneralItemMarchandiseBaseCategoryDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralItemMarchandiseBaseCategoryDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        GeneralItemMarchandiseBaseCategoryViewModel model = new GeneralItemMarchandiseBaseCategoryViewModel();
        //        model.GeneralItemMarchandiseBaseCategoryDTO = new GeneralItemMarchandiseBaseCategory();
        //        model.GeneralItemMarchandiseBaseCategoryDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralItemMarchandiseBaseCategoryDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> response = _GeneralItemMarchandiseBaseCategoryBA.SelectByID(model.GeneralItemMarchandiseBaseCategoryDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralItemMarchandiseBaseCategoryDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralItemMarchandiseBaseCategoryDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralItemMarchandiseBaseCategoryDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralItemMarchandiseBaseCategoryDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralItemMarchandiseBaseCategory/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> response = null;
                GeneralItemMarchandiseBaseCategory GeneralItemMarchandiseBaseCategoryDTO = new GeneralItemMarchandiseBaseCategory();
                GeneralItemMarchandiseBaseCategoryDTO.ConnectionString = _connectioString;
                GeneralItemMarchandiseBaseCategoryDTO.ID = Convert.ToInt16(ID);
                GeneralItemMarchandiseBaseCategoryDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemMarchandiseBaseCategoryBA.DeleteGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategoryDTO);
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
        public IEnumerable<GeneralItemMarchandiseBaseCategoryViewModel> GetGeneralItemMarchandiseBaseCategory(out int TotalRecords)
        {
            GeneralItemMarchandiseBaseCategorySearchRequest searchRequest = new GeneralItemMarchandiseBaseCategorySearchRequest();
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
            List<GeneralItemMarchandiseBaseCategoryViewModel> listGeneralItemMarchandiseBaseCategoryViewModel = new List<GeneralItemMarchandiseBaseCategoryViewModel>();
            List<GeneralItemMarchandiseBaseCategory> listGeneralItemMarchandiseBaseCategory = new List<GeneralItemMarchandiseBaseCategory>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> baseEntityCollectionResponse = _GeneralItemMarchandiseBaseCategoryBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMarchandiseBaseCategory = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralItemMarchandiseBaseCategory item in listGeneralItemMarchandiseBaseCategory)
                    {
                        GeneralItemMarchandiseBaseCategoryViewModel GeneralItemMarchandiseBaseCategoryViewModel = new GeneralItemMarchandiseBaseCategoryViewModel();
                        GeneralItemMarchandiseBaseCategoryViewModel.GeneralItemMarchandiseBaseCategoryDTO = item;
                        listGeneralItemMarchandiseBaseCategoryViewModel.Add(GeneralItemMarchandiseBaseCategoryViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralItemMarchandiseBaseCategoryViewModel;
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

                IEnumerable<GeneralItemMarchandiseBaseCategoryViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.MarchandiseBaseCatgoryName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MarchandiseBaseCatgoryName Like '%" + param.sSearch + "%' or A.MarchandiseBaseCatgoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.MarchandiseBaseCatgoryCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.MarchandiseBaseCatgoryName Like '%" + param.sSearch + "%' or A.MarchandiseBaseCatgoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralItemMarchandiseBaseCategory(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.MarchandiseBaseCategoryName), Convert.ToString(c.MarchandiseBaseCategoryCode), Convert.ToString(c.ID) };

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