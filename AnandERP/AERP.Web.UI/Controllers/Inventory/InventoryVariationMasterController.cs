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
    public class InventoryVariationMasterController : BaseController
    {
        IInventoryVariationMasterServiceAccess _InventoryVariationMasterServiceAcess = null;
        IInventoryRecipeMasterServiceAccess _InventoryRecipeMasterServiceAccess = null;
        
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryVariationMasterController()
        {
            _InventoryVariationMasterServiceAcess = new InventoryVariationMasterServiceAccess();
            _InventoryRecipeMasterServiceAccess = new InventoryRecipeMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/InventoryVariationMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                InventoryVariationMasterViewModel model = new InventoryVariationMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/InventoryVariationMaster/List.cshtml", model);
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
            InventoryVariationMasterViewModel model = new InventoryVariationMasterViewModel();

            List<InventoryRecipeMaster> InventoryRecipeMaster = GetListInventoryRecipeMaster();
            List<SelectListItem> InventoryRecipeMasterList = new List<SelectListItem>();
            foreach (InventoryRecipeMaster item in InventoryRecipeMaster)
            {
                InventoryRecipeMasterList.Add(new SelectListItem { Text = item.Title, Value = Convert.ToString(item.ID) });
            }
            ViewBag.InventoryRecipeList = new SelectList(InventoryRecipeMasterList, "Value", "Text");



            return PartialView("/Views/Inventory_1/InventoryVariationMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryVariationMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryVariationMasterDTO != null)
                {
                    model.InventoryVariationMasterDTO.ConnectionString = _connectioString;
                    model.InventoryVariationMasterDTO.ID = model.ID;
                    model.InventoryVariationMasterDTO.InventoryRecipeMasterId = model.InventoryRecipeMasterId;
                    model.InventoryVariationMasterDTO.RecipeVariationTitle = model.RecipeVariationTitle;
                    model.InventoryVariationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryVariationMaster> response = _InventoryVariationMasterServiceAcess.InsertInventoryVariationMaster(model.InventoryVariationMasterDTO);

                    model.InventoryVariationMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryVariationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    InventoryVariationMasterViewModel model = new InventoryVariationMasterViewModel();
        //    try
        //    {
        //        model.InventoryVariationMasterDTO = new InventoryVariationMaster();
        //        model.InventoryVariationMasterDTO.ID = id;
        //        model.InventoryVariationMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryVariationMaster> response = _InventoryVariationMasterServiceAcess.SelectByID(model.InventoryVariationMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryVariationMasterDTO.ID = response.Entity.ID;
        //            model.InventoryVariationMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.InventoryVariationMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.InventoryVariationMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(InventoryVariationMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryVariationMasterDTO != null)
                {
                    if (model != null && model.InventoryVariationMasterDTO != null)
                    {
                        model.InventoryVariationMasterDTO.ConnectionString = _connectioString;
                        //model.InventoryVariationMasterDTO.MerchantiseCategoryName = model.MerchantiseCategoryName;
                        //// model.InventoryVariationMasterDTO.SeqNo = model.SeqNo;
                        //model.InventoryVariationMasterDTO.MerchantiseCategoryCode = model.MerchantiseCategoryCode;
                        //model.InventoryVariationMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.InventoryVariationMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryVariationMaster> response = _InventoryVariationMasterServiceAcess.UpdateInventoryVariationMaster(model.InventoryVariationMasterDTO);
                        model.InventoryVariationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.InventoryVariationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult ViewDetails(Int16 ID)
        {
            InventoryVariationMasterViewModel model = new InventoryVariationMasterViewModel();
            try
            {
                model.InventoryVariationMasterDTO = new InventoryVariationMaster();
                model.InventoryVariationMasterDTO.ID = Convert.ToByte(ID);
                model.InventoryVariationMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryVariationMaster> response = _InventoryVariationMasterServiceAcess.SelectByID(model.InventoryVariationMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryVariationMasterDTO.ID = response.Entity.ID;
                    model.InventoryVariationMasterDTO.Title = response.Entity.Title;
                    model.InventoryVariationMasterDTO.Description = response.Entity.Description;
                    model.InventoryVariationMasterDTO.RecipeVariationTitle = response.Entity.RecipeVariationTitle;
                   

                    model.InventoryVariationMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory_1/InventoryVariationMaster/ViewDetails.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<InventoryVariationMaster> response = null;
                InventoryVariationMaster InventoryVariationMasterDTO = new InventoryVariationMaster();
                InventoryVariationMasterDTO.ConnectionString = _connectioString;
                InventoryVariationMasterDTO.ID = Convert.ToByte(ID);
                InventoryVariationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryVariationMasterServiceAcess.DeleteInventoryVariationMaster(InventoryVariationMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        protected List<InventoryRecipeMaster> GetListInventoryRecipeMaster()
        {
            InventoryRecipeMasterSearchRequest searchRequest = new InventoryRecipeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryRecipeMaster> listAdmin = new List<InventoryRecipeMaster>();
            IBaseEntityCollectionResponse<InventoryRecipeMaster> baseEntityCollectionResponse = _InventoryRecipeMasterServiceAccess.GetInventoryRecipeMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }
      
        public IEnumerable<InventoryVariationMasterViewModel> GetInventoryVariationMaster(out int TotalRecords)
        {
            InventoryVariationMasterSearchRequest searchRequest = new InventoryVariationMasterSearchRequest();
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
            List<InventoryVariationMasterViewModel> listInventoryVariationMasterViewModel = new List<InventoryVariationMasterViewModel>();
            List<InventoryVariationMaster> listInventoryVariationMaster = new List<InventoryVariationMaster>();
            IBaseEntityCollectionResponse<InventoryVariationMaster> baseEntityCollectionResponse = _InventoryVariationMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryVariationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryVariationMaster item in listInventoryVariationMaster)
                    {
                        InventoryVariationMasterViewModel InventoryVariationMasterViewModel = new InventoryVariationMasterViewModel();
                        InventoryVariationMasterViewModel.InventoryVariationMasterDTO = item;
                        listInventoryVariationMasterViewModel.Add(InventoryVariationMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryVariationMasterViewModel;
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

                IEnumerable<InventoryVariationMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.Title";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           
                            _searchBy = string.Empty;
                        }
                        else
                        {
                           
                            _searchBy = "B.Title Like '%" + param.sSearch + "%' or B.Description Like '%" + param.sSearch + "%'or A.RecipeVariationTitle Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "B.Description";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                          
                            _searchBy = string.Empty;
                        }
                        else
                        {
                          
                            _searchBy = "B.Title Like '%" + param.sSearch + "%' or B.Description Like '%" + param.sSearch + "%'or A.RecipeVariationTitle Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.RecipeVariationTitle";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                         
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.Title Like '%" + param.sSearch + "%' or B.Description Like '%" + param.sSearch + "%'or A.RecipeVariationTitle Like '%" + param.sSearch + "%'";
                        }
                        break;
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetInventoryVariationMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.Title), Convert.ToString(c.Description), Convert.ToString(c.RecipeVariationTitle), Convert.ToString(c.ID) };

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