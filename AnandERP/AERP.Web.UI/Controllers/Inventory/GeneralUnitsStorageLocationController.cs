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
    public class GeneralUnitsStorageLocationController : BaseController
    {
        IGeneralUnitsStorageLocationBA _GeneralUnitsStorageLocationBA = null;
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

        public GeneralUnitsStorageLocationController()
        {
            _GeneralUnitsStorageLocationBA = new GeneralUnitsStorageLocationBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory/GeneralUnitStorageLocation/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralUnitStorageLocationViewModel model = new GeneralUnitStorageLocationViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralUnitStorageLocation/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string IDs)
        {
            GeneralUnitStorageLocationViewModel model = new GeneralUnitStorageLocationViewModel();

            string[] IDsArray = IDs.Split('~');
            model.GeneralUnitsID = Convert.ToInt16(IDsArray[0]);
            model.UnitName = IDsArray[1];
            return PartialView("/Views/Inventory/GeneralUnitStorageLocation/create.cshtml", model);



        }

        [HttpPost]
        public ActionResult Create(GeneralUnitStorageLocationViewModel model)
        {
            try
            {
              
                    if (model != null && model.GeneralUnitStorageLocationDTO != null)
                    {
                        model.GeneralUnitStorageLocationDTO.ConnectionString = _connectioString;
                        model.GeneralUnitStorageLocationDTO.GeneralUnitsID = model.GeneralUnitsID;
                        model.GeneralUnitStorageLocationDTO.ID = model.ID;
                        model.GeneralUnitStorageLocationDTO.XmlString = model.XmlString;
                        model.GeneralUnitStorageLocationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralUnitsStorageLocation> response = _GeneralUnitsStorageLocationBA.InsertGeneralUnitsStorageLocation(model.GeneralUnitStorageLocationDTO);

                        model.GeneralUnitStorageLocationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.GeneralUnitStorageLocationDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult ViewDetails(Int16 id)
        {
            GeneralUnitStorageLocationViewModel model = new GeneralUnitStorageLocationViewModel();
            try
            {
                model.GeneralUnitStorageLocationDTO = new GeneralUnitsStorageLocation();
                model.GeneralUnitStorageLocationDTO.ID = id;
                model.GeneralUnitStorageLocationDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralUnitsStorageLocation> response = _GeneralUnitsStorageLocationBA.SelectByID(model.GeneralUnitStorageLocationDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralUnitStorageLocationDTO.UnitName = response.Entity.UnitName;
                    model.GeneralUnitStorageLocationDTO.GeneralUnitsID = response.Entity.GeneralUnitsID;
                    model.GeneralUnitStorageLocationDTO.InventoryLocationMasterID = response.Entity.InventoryLocationMasterID;
                    model.GeneralUnitStorageLocationDTO.LocationName = response.Entity.LocationName;
                    model.GeneralUnitStorageLocationDTO.IsDefault = response.Entity.IsDefault;
                    model.GeneralUnitStorageLocationDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/GeneralUnitStorageLocation/View.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralUnitsStorageLocation> response = null;
                GeneralUnitsStorageLocation GeneralUnitStorageLocationDTO = new GeneralUnitsStorageLocation();
                GeneralUnitStorageLocationDTO.ConnectionString = _connectioString;
                GeneralUnitStorageLocationDTO.ID = ID;
                GeneralUnitStorageLocationDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralUnitsStorageLocationBA.DeleteGeneralUnitsStorageLocation(GeneralUnitStorageLocationDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        

        #endregion

        // Non-Action Method
        #region Methods
        [HttpPost]
        public JsonResult GetLocationList(string term, string GeneralUnitsID, string CentreCode)
        {
            var data = GetLocationListDetails(term, GeneralUnitsID, CentreCode);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.LocationName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<InventoryLocationMaster> GetLocationListDetails(string SearchKeyWord, string GeneralUnitsID, string CentreCode)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.CentreCode = CentreCode;

            List<InventoryLocationMaster> listLocation = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocation;
        }

        [HttpPost]
        public JsonResult CheckFocusOnAction(string actionOn, string data)
        {
            GeneralUnitStorageLocationViewModel model = new GeneralUnitStorageLocationViewModel();
            model.GeneralUnitStorageLocationDTO = new GeneralUnitsStorageLocation();
            model.GeneralUnitStorageLocationDTO.ActionOn = actionOn;
            var splitedData = data.Split('~');
            model.GeneralUnitStorageLocationDTO.ActionName = splitedData[0]; ;
            model.GeneralUnitStorageLocationDTO.GeneralUnitsID = Convert.ToInt16(splitedData[1]);
            model.GeneralUnitStorageLocationDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<GeneralUnitsStorageLocation> response = _GeneralUnitsStorageLocationBA.CheckFocusOnAction(model.GeneralUnitStorageLocationDTO);
            if (response != null && response.Entity != null)
            {
                model.GeneralUnitStorageLocationDTO.ActionID = response.Entity.ActionID;
                model.GeneralUnitStorageLocationDTO.IsDefaultCount = response.Entity.IsDefaultCount;
            }
            return Json(model.GeneralUnitStorageLocationDTO.ActionID + "~" + model.GeneralUnitStorageLocationDTO.IsDefaultCount, JsonRequestBehavior.AllowGet);
            //return Json(model.GeneralUnitStorageLocationDTO.ActionID, JsonRequestBehavior.AllowGet);
        }
       

        public IEnumerable<GeneralUnitStorageLocationViewModel> GetGeneralUnitsStorageLocation(out int TotalRecords)
        {
            GeneralUnitsStorageLocationSearchRequest searchRequest = new GeneralUnitsStorageLocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
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
            List<GeneralUnitStorageLocationViewModel> listGeneralUnitsStorageLocationViewModel = new List<GeneralUnitStorageLocationViewModel>();
            List<GeneralUnitsStorageLocation> listGeneralUnitsStorageLocation = new List<GeneralUnitsStorageLocation>();
            IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> baseEntityCollectionResponse = _GeneralUnitsStorageLocationBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralUnitsStorageLocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralUnitsStorageLocation item in listGeneralUnitsStorageLocation)
                    {
                        GeneralUnitStorageLocationViewModel _GeneralUnitsStorageLocationViewModel = new GeneralUnitStorageLocationViewModel();
                        _GeneralUnitsStorageLocationViewModel.GeneralUnitStorageLocationDTO = item;
                        listGeneralUnitsStorageLocationViewModel.Add(_GeneralUnitsStorageLocationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralUnitsStorageLocationViewModel;
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

                IEnumerable<GeneralUnitStorageLocationViewModel> filteredUnitType;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "UnitName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%' or A.LocationName Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "LocationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "UnitName Like '%" + param.sSearch + "%' or LocationName Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetGeneralUnitsStorageLocation(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] {Convert.ToString(c.GeneralUnitsID), Convert.ToString(c.UnitName), Convert.ToString(c.LocationName), Convert.ToString(c.IsDefault),Convert.ToString(c.ID)};

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