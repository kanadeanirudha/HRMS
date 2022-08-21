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
    public class InventoryDimensionUnitMasterController : BaseController
    {
        IInventoryDimensionUnitMasterServiceAccess _InventoryDimensionUnitMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryDimensionUnitMasterController()
        {
            _InventoryDimensionUnitMasterServiceAcess = new InventoryDimensionUnitMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/InventoryDimensionUnitMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                InventoryDimensionUnitMasterViewModel model = new InventoryDimensionUnitMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/InventoryDimensionUnitMaster/List.cshtml", model);
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
            InventoryDimensionUnitMasterViewModel model = new InventoryDimensionUnitMasterViewModel();

            List<SelectListItem> DimensionCode = new List<SelectListItem>();
            ViewBag.DimensionCode = new SelectList(DimensionCode,"Value","Text");
            List<SelectListItem> li_DimensionCode = new List<SelectListItem>();
            li_DimensionCode.Add(new SelectListItem { Text = "Length", Value = "Length" });
            li_DimensionCode.Add(new SelectListItem { Text = "Height", Value = "Height" });
            li_DimensionCode.Add(new SelectListItem { Text = "Time", Value = "Time" });
            li_DimensionCode.Add(new SelectListItem { Text = "Electrical Current", Value = "Electrical Current" });
            li_DimensionCode.Add(new SelectListItem { Text = "Temprature", Value = "Temprature" });
            li_DimensionCode.Add(new SelectListItem { Text = "Molecular Mass", Value = "Molecular Mass" });
            li_DimensionCode.Add(new SelectListItem { Text = "Brightness", Value = "Brightness" });
            li_DimensionCode.Add(new SelectListItem { Text = "Each", Value = "Each" });

            ViewData["DimensionCode"] = li_DimensionCode;



            return PartialView("/Views/Inventory_1/InventoryDimensionUnitMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryDimensionUnitMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryDimensionUnitMasterDTO != null)
                {
                    model.InventoryDimensionUnitMasterDTO.ConnectionString = _connectioString;
                    model.InventoryDimensionUnitMasterDTO.ConnectionString = _connectioString;
                    model.InventoryDimensionUnitMasterDTO.DimensionCode = model.DimensionCode;
                    model.InventoryDimensionUnitMasterDTO.DimensionDescription = model.DimensionDescription;
                    model.InventoryDimensionUnitMasterDTO.SIUnit = model.SIUnit;
                    model.InventoryDimensionUnitMasterDTO.SIDescription = model.SIDescription;

                    model.InventoryDimensionUnitMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryDimensionUnitMaster> response = _InventoryDimensionUnitMasterServiceAcess.InsertInventoryDimensionUnitMaster(model.InventoryDimensionUnitMasterDTO);

                    model.InventoryDimensionUnitMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryDimensionUnitMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    InventoryDimensionUnitMasterViewModel model = new InventoryDimensionUnitMasterViewModel();
        //    try
        //    {
        //        model.InventoryDimensionUnitMasterDTO = new InventoryDimensionUnitMaster();
        //        model.InventoryDimensionUnitMasterDTO.ID = id;
        //        model.InventoryDimensionUnitMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryDimensionUnitMaster> response = _InventoryDimensionUnitMasterServiceAcess.SelectByID(model.InventoryDimensionUnitMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryDimensionUnitMasterDTO.ID = response.Entity.ID;
        //            model.InventoryDimensionUnitMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.InventoryDimensionUnitMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.InventoryDimensionUnitMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(InventoryDimensionUnitMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryDimensionUnitMasterDTO != null)
                {
                    if (model != null && model.InventoryDimensionUnitMasterDTO != null)
                    {
                        //model.InventoryDimensionUnitMasterDTO.ConnectionString = _connectioString;
                        // model.InventoryDimensionUnitMasterDTO.DimensionCode = model.DimensionCode;
                        //  model.InventoryDimensionUnitMasterDTO.DimensionDescription = model.DimensionDescription;
                        //  model.InventoryDimensionUnitMasterDTO.SIUnit = model.SIUnit;
                         model.InventoryDimensionUnitMasterDTO.SIDescription = model.SIDescription;
                        model.InventoryDimensionUnitMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryDimensionUnitMaster> response = _InventoryDimensionUnitMasterServiceAcess.UpdateInventoryDimensionUnitMaster(model.InventoryDimensionUnitMasterDTO);
                        model.InventoryDimensionUnitMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.InventoryDimensionUnitMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        InventoryDimensionUnitMasterViewModel model = new InventoryDimensionUnitMasterViewModel();
        //        model.InventoryDimensionUnitMasterDTO = new InventoryDimensionUnitMaster();
        //        model.InventoryDimensionUnitMasterDTO.ID = Convert.ToInt16(ID);
        //        model.InventoryDimensionUnitMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryDimensionUnitMaster> response = _InventoryDimensionUnitMasterServiceAcess.SelectByID(model.InventoryDimensionUnitMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryDimensionUnitMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.InventoryDimensionUnitMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.InventoryDimensionUnitMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.InventoryDimensionUnitMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/InventoryDimensionUnitMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<InventoryDimensionUnitMaster> response = null;
                InventoryDimensionUnitMaster InventoryDimensionUnitMasterDTO = new InventoryDimensionUnitMaster();
                InventoryDimensionUnitMasterDTO.ConnectionString = _connectioString;
                InventoryDimensionUnitMasterDTO.ID = Convert.ToInt16(ID);
                InventoryDimensionUnitMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryDimensionUnitMasterServiceAcess.DeleteInventoryDimensionUnitMaster(InventoryDimensionUnitMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryDimensionUnitMasterViewModel> GetInventoryDimensionUnitMaster(out int TotalRecords)
        {
            InventoryDimensionUnitMasterSearchRequest searchRequest = new InventoryDimensionUnitMasterSearchRequest();
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
            List<InventoryDimensionUnitMasterViewModel> listInventoryDimensionUnitMasterViewModel = new List<InventoryDimensionUnitMasterViewModel>();
            List<InventoryDimensionUnitMaster> listInventoryDimensionUnitMaster = new List<InventoryDimensionUnitMaster>();
            IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> baseEntityCollectionResponse = _InventoryDimensionUnitMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryDimensionUnitMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryDimensionUnitMaster item in listInventoryDimensionUnitMaster)
                    {
                        InventoryDimensionUnitMasterViewModel InventoryDimensionUnitMasterViewModel = new InventoryDimensionUnitMasterViewModel();
                        InventoryDimensionUnitMasterViewModel.InventoryDimensionUnitMasterDTO = item;
                        listInventoryDimensionUnitMasterViewModel.Add(InventoryDimensionUnitMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryDimensionUnitMasterViewModel;
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

                IEnumerable<InventoryDimensionUnitMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.DimensionCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.DimensionCode Like '%" + param.sSearch + "%' or A.DimensionDescription Like '%" + param.sSearch + "%' or A.SIUnit Like '%" + param.sSearch + "%' or A.SIDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.DimensionDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.DimensionCode Like '%" + param.sSearch + "%' or A.DimensionDescription Like '%" + param.sSearch + "%' or A.SIUnit Like '%" + param.sSearch + "%' or A.SIDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.SIUnit";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                          
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.DimensionCode Like '%" + param.sSearch + "%' or A.DimensionDescription Like '%" + param.sSearch + "%' or A.SIUnit Like '%" + param.sSearch + "%' or A.SIDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.SIDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.DimensionCode Like '%" + param.sSearch + "%' or A.DimensionDescription Like '%" + param.sSearch + "%' or A.SIUnit Like '%" + param.sSearch + "%' or A.SIDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetInventoryDimensionUnitMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.DimensionCode), Convert.ToString(c.DimensionDescription), Convert.ToString(c.SIUnit), Convert.ToString(c.SIDescription), Convert.ToString(c.ID) };

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