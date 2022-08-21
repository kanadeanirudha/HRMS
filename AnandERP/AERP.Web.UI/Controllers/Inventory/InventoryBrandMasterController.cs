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
    public class InventoryBrandMasterController : BaseController
    {
        IInventoryBrandMasterBA _InventoryBrandMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryBrandMasterController()
        {
            _InventoryBrandMasterBA = new InventoryBrandMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/InventoryBrandMaster/Index.cshtml");
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
                InventoryBrandMasterViewModel model = new InventoryBrandMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryBrandMaster/List.cshtml", model);
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
            InventoryBrandMasterViewModel model = new InventoryBrandMasterViewModel();

            return PartialView("/Views/Inventory/InventoryBrandMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryBrandMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryBrandMasterDTO != null)
                {
                    model.InventoryBrandMasterDTO.ConnectionString = _connectioString;
                    model.InventoryBrandMasterDTO.BrandName = model.BrandName;
                    model.InventoryBrandMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryBrandMaster> response = _InventoryBrandMasterBA.InsertInventoryBrandMaster(model.InventoryBrandMasterDTO);

                    model.InventoryBrandMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryBrandMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            InventoryBrandMasterViewModel model = new InventoryBrandMasterViewModel();
            try
            {
                model.InventoryBrandMasterDTO = new InventoryBrandMaster();
                model.InventoryBrandMasterDTO.ID = id;
                model.InventoryBrandMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryBrandMaster> response = _InventoryBrandMasterBA.SelectByID(model.InventoryBrandMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryBrandMasterDTO.ID = response.Entity.ID;
                    model.InventoryBrandMasterDTO.BrandName = response.Entity.BrandName;
                    model.InventoryBrandMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/InventoryBrandMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryBrandMasterViewModel model)
        {

        try
            {
                if (model != null && model.InventoryBrandMasterDTO != null)
                {
                    model.InventoryBrandMasterDTO.ConnectionString = _connectioString;
                    model.InventoryBrandMasterDTO.BrandName = model.BrandName;
                    model.InventoryBrandMasterDTO.ID = model.ID;

                    model.InventoryBrandMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryBrandMaster> response = _InventoryBrandMasterBA.UpdateInventoryBrandMaster(model.InventoryBrandMasterDTO);
                    model.InventoryBrandMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.InventoryBrandMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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




        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        InventoryBrandMasterViewModel model = new InventoryBrandMasterViewModel();
        //        model.InventoryBrandMasterDTO = new InventoryBrandMaster();
        //        model.InventoryBrandMasterDTO.ID = Convert.ToInt16(ID);
        //        model.InventoryBrandMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryBrandMaster> response = _InventoryBrandMasterBA.SelectByID(model.InventoryBrandMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryBrandMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.InventoryBrandMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.InventoryBrandMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.InventoryBrandMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/InventoryBrandMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<InventoryBrandMaster> response = null;
                InventoryBrandMaster InventoryBrandMasterDTO = new InventoryBrandMaster();
                InventoryBrandMasterDTO.ConnectionString = _connectioString;
                InventoryBrandMasterDTO.InventoryBrandMasterID = Convert.ToInt32(ID);
                InventoryBrandMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryBrandMasterBA.DeleteInventoryBrandMaster(InventoryBrandMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryBrandMasterViewModel> GetInventoryBrandMaster(out int TotalRecords)
        {
            InventoryBrandMasterSearchRequest searchRequest = new InventoryBrandMasterSearchRequest();
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
            List<InventoryBrandMasterViewModel> listInventoryBrandMasterViewModel = new List<InventoryBrandMasterViewModel>();
            List<InventoryBrandMaster> listInventoryBrandMaster = new List<InventoryBrandMaster>();
            IBaseEntityCollectionResponse<InventoryBrandMaster> baseEntityCollectionResponse = _InventoryBrandMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryBrandMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryBrandMaster item in listInventoryBrandMaster)
                    {
                        InventoryBrandMasterViewModel InventoryBrandMasterViewModel = new InventoryBrandMasterViewModel();
                        InventoryBrandMasterViewModel.InventoryBrandMasterDTO = item;
                        listInventoryBrandMasterViewModel.Add(InventoryBrandMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryBrandMasterViewModel;
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

                IEnumerable<InventoryBrandMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.BrandName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.BrandName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            //_searchBy = "A.MarchandiseBaseCatgoryName Like '%" + param.sSearch + "%' or A.MarchandiseBaseCatgoryCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    //case 1:
                    //    _sortBy = "A.MarchandiseBaseCatgoryCode";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        _searchBy = "A.MarchandiseGroupCode like '%'";
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    //        _searchBy = "A.MarchandiseBaseCatgoryName Like '%" + param.sSearch + "%' or A.MarchandiseBaseCatgoryCode Like '%" + param.sSearch + "%'";
                    //    }
                    //    break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetInventoryBrandMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.BrandName),  Convert.ToString(c.InventoryBrandMasterID) };

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