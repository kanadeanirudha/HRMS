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
    public class AddCentreOpeningBalanceForInventoryController : BaseController
    {
        IAddCentreOpeningBalanceForInventoryBA _AddCentreOpeningBalanceForInventoryBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AddCentreOpeningBalanceForInventoryController()
        {
            _AddCentreOpeningBalanceForInventoryBA = new AddCentreOpeningBalanceForInventoryBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {

                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
                List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
                List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                foreach (InventoryLocationMaster item in locationMasterList)
                {
                    listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");

                return View("/Views/Inventory/AddCentreOpeningBalanceForInventory/Index.cshtml");
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
                AddCentreOpeningBalanceForInventoryViewModel model = new AddCentreOpeningBalanceForInventoryViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/AddCentreOpeningBalanceForInventory/List.cshtml", model);
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
            AddCentreOpeningBalanceForInventoryViewModel model = new AddCentreOpeningBalanceForInventoryViewModel();
            return PartialView("/Views/Inventory/AddCentreOpeningBalanceForInventory/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(AddCentreOpeningBalanceForInventoryViewModel model)
        {
            try
            {
                if (model != null && model.AddCentreOpeningBalanceForInventoryDTO != null)
                {
                    model.AddCentreOpeningBalanceForInventoryDTO.ConnectionString = _connectioString;
                    model.AddCentreOpeningBalanceForInventoryDTO.InventoryLocationMasterID = model.InventoryLocationMasterID;
                    model.AddCentreOpeningBalanceForInventoryDTO.XMLstring = model.XMLstring;
                    model.AddCentreOpeningBalanceForInventoryDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AddCentreOpeningBalanceForInventory> response = _AddCentreOpeningBalanceForInventoryBA.InsertAddCentreOpeningBalanceForInventory(model.AddCentreOpeningBalanceForInventoryDTO);
                    model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult Delete(AddCentreOpeningBalanceForInventoryViewModel model)
        {
            var errorMessage = string.Empty;
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    AddCentreOpeningBalanceForInventory AddCentreOpeningBalanceForInventoryDTO = new AddCentreOpeningBalanceForInventory();
                    AddCentreOpeningBalanceForInventoryDTO.ConnectionString = _connectioString;
                    AddCentreOpeningBalanceForInventoryDTO.ID = model.ID;
                    AddCentreOpeningBalanceForInventoryDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AddCentreOpeningBalanceForInventory> response = _AddCentreOpeningBalanceForInventoryBA.DeleteAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventoryDTO);
                    errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }


        #endregion


        // Non-Action Method
        #region Methods

        public IEnumerable<AddCentreOpeningBalanceForInventory> GetAddCentreOpeningBalanceForInventory(out int TotalRecords,int LocationID)
        {
            AddCentreOpeningBalanceForInventorySearchRequest searchRequest = new AddCentreOpeningBalanceForInventorySearchRequest();
            List<AddCentreOpeningBalanceForInventory> listAddCentreOpeningBalanceForInventory = new List<AddCentreOpeningBalanceForInventory>();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.InventoryLocationMasterID = LocationID;
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
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

            IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> baseEntityCollectionResponse = _AddCentreOpeningBalanceForInventoryBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAddCentreOpeningBalanceForInventory = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAddCentreOpeningBalanceForInventory;
        }
        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList(int AdminRoleID)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleID = AdminRoleID;
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterlistByAdminRole(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int LocationID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]);

                IEnumerable<AddCentreOpeningBalanceForInventory> filteredAddCentreOpeningBalanceForInventory;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ItemDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ItemDescription Like '%" + param.sSearch + "%' or A.ItemNumber Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                filteredAddCentreOpeningBalanceForInventory = GetAddCentreOpeningBalanceForInventory(out TotalRecords, LocationID);

                if ((filteredAddCentreOpeningBalanceForInventory.Count()) == 0)
                {
                    filteredAddCentreOpeningBalanceForInventory = new List<AddCentreOpeningBalanceForInventory>();
                    TotalRecords = 0;
                }

                var records = filteredAddCentreOpeningBalanceForInventory.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.ID.ToString(), c.ItemNumber.ToString(), Convert.ToString(c.ItemDescription), Convert.ToString(c.LocationName), Convert.ToString(c.InventoryLocationMasterID), Convert.ToString(c.BaseUomCode), Convert.ToString(c.OpeningBalanceQuantity), Convert.ToString(c.InventoryStockMasterID), Convert.ToString(c.StatusFlag), };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

    }
}
