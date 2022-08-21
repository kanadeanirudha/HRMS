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
    public class CCRMCalenderMasterController : BaseController
    {
        ICCRMCalenderMasterBA _CCRMCalenderMasterBA = null;
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

        public CCRMCalenderMasterController()
        {
            _CCRMCalenderMasterBA = new CCRMCalenderMasterBA();
            _CCRMHolidayMasterBA = new CCRMHolidayMasterBA();
        }
        #region Controller Methods
        // GET: CCRMCalenderMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMCalenderMaster/Index.cshtml");
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
                CCRMCalenderMasterViewModel model = new CCRMCalenderMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMCalenderMaster/List.cshtml", model);
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
            CCRMCalenderMasterViewModel model = new CCRMCalenderMasterViewModel();
            //*********************CCRMHolidayMaster*********************//
            List<CCRMHolidayMaster> CCRMHolidayMaster = GetCCRMHolidayMaster();
            List<SelectListItem> CCRMHolidayMasterList = new List<SelectListItem>();
            foreach (CCRMHolidayMaster item in CCRMHolidayMaster)
            {
                CCRMHolidayMasterList.Add(new SelectListItem { Text = item.HolidayDesc, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMHolidayMasterList = new SelectList(CCRMHolidayMasterList, "Value", "Text", model.HolidayDesc);
            return PartialView("/Views/CCRM/CCRMCalenderMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMCalenderMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMCalenderMasterDTO != null)
                    {
                        model.CCRMCalenderMasterDTO.ConnectionString = _connectioString;
                     
                        model.CCRMCalenderMasterDTO.Date = model.Date;
                        model.CCRMCalenderMasterDTO.HolidayDesc = model.HolidayDesc;
                        model.CCRMCalenderMasterDTO.CalenderYear = model.CalenderYear;
                        model.CCRMCalenderMasterDTO.AllSundays = model.AllSundays;
                        model.CCRMCalenderMasterDTO.AllSaturday = model.AllSaturday;
                        model.CCRMCalenderMasterDTO.SATSUNDate = model.SATSUNDate;
                        model.CCRMCalenderMasterDTO.Day = model.Day;
                        model.CCRMCalenderMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMCalenderMaster> response = _CCRMCalenderMasterBA.InsertCCRMCalenderMaster(model.CCRMCalenderMasterDTO);
                        model.CCRMCalenderMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMCalenderMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMCalenderMasterViewModel> GetCCRMCalenderMaster(out int TotalRecords)
        {
            CCRMCalenderMasterSearchRequest searchRequest = new CCRMCalenderMasterSearchRequest();
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
            List<CCRMCalenderMasterViewModel> listCCRMCalenderMasterViewModel = new List<CCRMCalenderMasterViewModel>();
            List<CCRMCalenderMaster> listCCRMCalenderMaster = new List<CCRMCalenderMaster>();
            IBaseEntityCollectionResponse<CCRMCalenderMaster> baseEntityCollectionResponse = _CCRMCalenderMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCalenderMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMCalenderMaster item in listCCRMCalenderMaster)
                    {
                        CCRMCalenderMasterViewModel CCRMCalenderMasterViewModel = new CCRMCalenderMasterViewModel();
                        CCRMCalenderMasterViewModel.CCRMCalenderMasterDTO = item;
                        listCCRMCalenderMasterViewModel.Add(CCRMCalenderMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMCalenderMasterViewModel;
        }
        protected List<CCRMHolidayMaster> GetCCRMHolidayMaster()
        {
            CCRMHolidayMasterSearchRequest searchRequest = new CCRMHolidayMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMHolidayMaster> listCCRMHolidayMaster = new List<CCRMHolidayMaster>();
            IBaseEntityCollectionResponse<CCRMHolidayMaster> baseEntityCollectionResponse = _CCRMHolidayMasterBA.GetCCRMHolidayMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMHolidayMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMHolidayMaster;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMCalenderMasterViewModel> filteredCCRMCalenderMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Date";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Date Like '%" + param.sSearch + "%' or HolidayDesc Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "HolidayDesc";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Date Like '%" + param.sSearch + "%' or HolidayDesc Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMCalenderMasterViewModel = GetCCRMCalenderMaster(out TotalRecords);
            var records = filteredCCRMCalenderMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Date), Convert.ToString(c.ID), Convert.ToString(c.HolidayDesc), Convert.ToString(c.CalenderYear) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}