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
    public class InventoryAttributeMasterController : BaseController
    {
        IInventoryAttributeMasterBA _InventoryAttributeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryAttributeMasterController()
        {
            _InventoryAttributeMasterBA = new InventoryAttributeMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/InventoryAttributeMaster/Index.cshtml");
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
                InventoryAttributeMasterViewModel model = new InventoryAttributeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryAttributeMaster/List.cshtml", model);
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
            InventoryAttributeMasterViewModel model = new InventoryAttributeMasterViewModel();

            return PartialView("/Views/Inventory/InventoryAttributeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryAttributeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryAttributeMasterDTO != null)
                {
                    model.InventoryAttributeMasterDTO.ConnectionString = _connectioString;
                    model.InventoryAttributeMasterDTO.AttributeName = model.AttributeName;
                    model.InventoryAttributeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryAttributeMaster> response = _InventoryAttributeMasterBA.InsertInventoryAttributeMaster(model.InventoryAttributeMasterDTO);

                    model.InventoryAttributeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryAttributeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    InventoryAttributeMasterViewModel model = new InventoryAttributeMasterViewModel();
        //    try
        //    {
        //        model.InventoryAttributeMasterDTO = new InventoryAttributeMaster();
        //        model.InventoryAttributeMasterDTO.ID = id;
        //        model.InventoryAttributeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryAttributeMaster> response = _InventoryAttributeMasterBA.SelectByID(model.InventoryAttributeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryAttributeMasterDTO.ID = response.Entity.ID;
        //            model.InventoryAttributeMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.InventoryAttributeMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.InventoryAttributeMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

      
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            InventoryAttributeMasterViewModel model = new InventoryAttributeMasterViewModel();
            try
            {
                model.InventoryAttributeMasterDTO = new InventoryAttributeMaster();
                model.InventoryAttributeMasterDTO.ConnectionString = _connectioString;
                model.InventoryAttributeMasterID = ID;

                IBaseEntityResponse<InventoryAttributeMaster> response = _InventoryAttributeMasterBA.SelectByID(model.InventoryAttributeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryAttributeMasterDTO.InventoryAttributeMasterID = response.Entity.InventoryAttributeMasterID;
                    model.InventoryAttributeMasterDTO.AttributeName = response.Entity.AttributeName;
              
                }
                return PartialView("/Views/Inventory/InventoryAttributeMaster/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryAttributeMasterViewModel model)
        {
            try
            {
                if (model != null && model.InventoryAttributeMasterDTO != null)
                {
                    model.InventoryAttributeMasterDTO.ConnectionString = _connectioString;
                    model.InventoryAttributeMasterDTO.InventoryAttributeMasterID = model.InventoryAttributeMasterID;
                    model.InventoryAttributeMasterDTO.AttributeName = model.AttributeName;
                   

                    model.InventoryAttributeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryAttributeMaster> response = _InventoryAttributeMasterBA.UpdateInventoryAttributeMaster(model.InventoryAttributeMasterDTO);
                    model.InventoryAttributeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.InventoryAttributeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        InventoryAttributeMasterViewModel model = new InventoryAttributeMasterViewModel();
        //        model.InventoryAttributeMasterDTO = new InventoryAttributeMaster();
        //        model.InventoryAttributeMasterDTO.ID = Convert.ToInt16(ID);
        //        model.InventoryAttributeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryAttributeMaster> response = _InventoryAttributeMasterBA.SelectByID(model.InventoryAttributeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryAttributeMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.InventoryAttributeMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.InventoryAttributeMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.InventoryAttributeMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/InventoryAttributeMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<InventoryAttributeMaster> response = null;
                InventoryAttributeMaster InventoryAttributeMasterDTO = new InventoryAttributeMaster();
                InventoryAttributeMasterDTO.ConnectionString = _connectioString;
                InventoryAttributeMasterDTO.ID = Convert.ToInt32(ID);
                InventoryAttributeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryAttributeMasterBA.DeleteInventoryAttributeMaster(InventoryAttributeMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryAttributeMasterViewModel> GetInventoryAttributeMaster(out int TotalRecords)
        {
            InventoryAttributeMasterSearchRequest searchRequest = new InventoryAttributeMasterSearchRequest();
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
            List<InventoryAttributeMasterViewModel> listInventoryAttributeMasterViewModel = new List<InventoryAttributeMasterViewModel>();
            List<InventoryAttributeMaster> listInventoryAttributeMaster = new List<InventoryAttributeMaster>();
            IBaseEntityCollectionResponse<InventoryAttributeMaster> baseEntityCollectionResponse = _InventoryAttributeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryAttributeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryAttributeMaster item in listInventoryAttributeMaster)
                    {
                        InventoryAttributeMasterViewModel InventoryAttributeMasterViewModel = new InventoryAttributeMasterViewModel();
                        InventoryAttributeMasterViewModel.InventoryAttributeMasterDTO = item;
                        listInventoryAttributeMasterViewModel.Add(InventoryAttributeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryAttributeMasterViewModel;
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

                IEnumerable<InventoryAttributeMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.AttributeName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.AttributeName like '%'";
                            //_searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AttributeName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            //_searchBy = "A.ID Like '%" + param.sSearch + "%' or A.AttributeName Like '%" + param.sSearch + "%'";
                        }
                        break;
                    //case 1:
                    //    _sortBy = "A.AttributeName";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        // _searchBy = "A.MarchandiseGroupCode like '%'";
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    //        _searchBy = "A.ID Like '%" + param.sSearch + "%' or A.AttributeName Like '%" + param.sSearch + "%'";
                    //    }
                    //    break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetInventoryAttributeMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AttributeName), Convert.ToString(c.InventoryAttributeMasterID) };

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