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
    public class GeneralPurchaseGroupMasterController : BaseController
    {
        IGeneralPurchaseGroupMasterBA _GeneralPurchaseGroupMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralPurchaseGroupMasterController()
        {
            _GeneralPurchaseGroupMasterBA = new GeneralPurchaseGroupMasterBA();
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralPurchaseGroupMaster/Index.cshtml");
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
                GeneralPurchaseGroupMasterViewModel model = new GeneralPurchaseGroupMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralPurchaseGroupMaster/List.cshtml", model);
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
            GeneralPurchaseGroupMasterViewModel model = new GeneralPurchaseGroupMasterViewModel();
            return PartialView("/Views/Inventory/GeneralPurchaseGroupMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPurchaseGroupMasterViewModel model)
        {
            try
            {
                if (model != null && model.GeneralPurchaseGroupMasterDTO != null)
                {
                    model.GeneralPurchaseGroupMasterDTO.ConnectionString = _connectioString;
                    model.GeneralPurchaseGroupMasterDTO.PurchaseGroupName = model.PurchaseGroupName;
                    model.GeneralPurchaseGroupMasterDTO.PurchaseGroupCode = model.PurchaseGroupCode;
                    model.GeneralPurchaseGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPurchaseGroupMaster> response = _GeneralPurchaseGroupMasterBA.InsertGeneralPurchaseGroupMaster(model.GeneralPurchaseGroupMasterDTO);
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

        public ActionResult Delete(GeneralPurchaseGroupMasterViewModel model)
        {
            var errorMessage = string.Empty;
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    GeneralPurchaseGroupMaster GeneralPurchaseGroupMasterDTO = new GeneralPurchaseGroupMaster();
                    GeneralPurchaseGroupMasterDTO.ConnectionString = _connectioString;
                    GeneralPurchaseGroupMasterDTO.ID = model.ID;
                    GeneralPurchaseGroupMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPurchaseGroupMaster> response = _GeneralPurchaseGroupMasterBA.DeleteGeneralPurchaseGroupMaster(GeneralPurchaseGroupMasterDTO);
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

        public IEnumerable<GeneralPurchaseGroupMaster> GetGeneralPurchaseGroupMaster(out int TotalRecords)
        {
            GeneralPurchaseGroupMasterSearchRequest searchRequest = new GeneralPurchaseGroupMasterSearchRequest();
            List<GeneralPurchaseGroupMaster> listGeneralPurchaseGroupMaster = new List<GeneralPurchaseGroupMaster>();
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

            IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> baseEntityCollectionResponse = _GeneralPurchaseGroupMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPurchaseGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPurchaseGroupMaster;
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
                string sortDirection = Convert.ToString(Request["sSortDir_0"]);

                IEnumerable<GeneralPurchaseGroupMaster> filteredGeneralPurchaseGroupMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "PurchaseGroupName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PurchaseGroupName Like '%" + param.sSearch + "%' or PurchaseGroupCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "PurchaseGroupCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PurchaseGroupName Like '%" + param.sSearch + "%' or PurchaseGroupCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                filteredGeneralPurchaseGroupMaster = GetGeneralPurchaseGroupMaster(out TotalRecords);

                if ((filteredGeneralPurchaseGroupMaster.Count()) == 0)
                {
                    filteredGeneralPurchaseGroupMaster = new List<GeneralPurchaseGroupMaster>();
                    TotalRecords = 0;
                }

                var records = filteredGeneralPurchaseGroupMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.ID.ToString(), c.PurchaseGroupName.ToString(), Convert.ToString(c.PurchaseGroupCode) };
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
