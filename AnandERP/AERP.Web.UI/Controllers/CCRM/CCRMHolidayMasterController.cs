using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System.Web.Mvc;
using System.Configuration;

namespace AERP.Web.UI.Controllers
{
    public class CCRMHolidayMasterController : BaseController
    {
        ICCRMHolidayMasterBA _CCRMHolidayMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CCRMHolidayMasterController()
        {
            _CCRMHolidayMasterBA = new CCRMHolidayMasterBA();

        }
        #region Controller Methods
        // GET: CCRMHolidayMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMHolidayMaster/Index.cshtml");
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
                CCRMHolidayMasterViewModel model = new CCRMHolidayMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMHolidayMaster/List.cshtml", model);
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
            CCRMHolidayMasterViewModel model = new CCRMHolidayMasterViewModel();

            return PartialView("/Views/CCRM/CCRMHolidayMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMHolidayMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMHolidayMasterDTO != null)
                    {
                        model.CCRMHolidayMasterDTO.ConnectionString = _connectioString;
                        
                        model.CCRMHolidayMasterDTO.HolidayDesc = model.HolidayDesc;
                        model.CCRMHolidayMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMHolidayMaster> response = _CCRMHolidayMasterBA.InsertCCRMHolidayMaster(model.CCRMHolidayMasterDTO);
                        model.CCRMHolidayMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMHolidayMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        // Non-Action Method
        #region Methods
        public IEnumerable<CCRMHolidayMasterViewModel> GetCCRMHolidayMaster(out int TotalRecords)
        {
            CCRMHolidayMasterSearchRequest searchRequest = new CCRMHolidayMasterSearchRequest();
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
            List<CCRMHolidayMasterViewModel> listCCRMHolidayMasterViewModel = new List<CCRMHolidayMasterViewModel>();
            List<CCRMHolidayMaster> listCCRMHolidayMaster = new List<CCRMHolidayMaster>();
            IBaseEntityCollectionResponse<CCRMHolidayMaster> baseEntityCollectionResponse = _CCRMHolidayMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMHolidayMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMHolidayMaster item in listCCRMHolidayMaster)
                    {
                        CCRMHolidayMasterViewModel CCRMHolidayMasterViewModel = new CCRMHolidayMasterViewModel();
                        CCRMHolidayMasterViewModel.CCRMHolidayMasterDTO = item;
                        listCCRMHolidayMasterViewModel.Add(CCRMHolidayMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMHolidayMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMHolidayMasterViewModel> filteredCCRMHolidayMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                
                case 0:
                    _sortBy = "HolidayDesc";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = " HolidayDesc Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMHolidayMasterViewModel = GetCCRMHolidayMaster(out TotalRecords);
            var records = filteredCCRMHolidayMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.HolidayDesc), Convert.ToString(c.ID)};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}