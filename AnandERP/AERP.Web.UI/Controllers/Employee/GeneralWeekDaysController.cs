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

namespace AERP.Web.UI.Controllers
{
    public class GeneralWeekDaysController : BaseController
    {
        IGeneralWeekDaysBA _GeneralWeekDaysBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralWeekDaysController()
        {
            _GeneralWeekDaysBA = new GeneralWeekDaysBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Employee/GeneralWeekDays/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralWeekDaysViewModel model = new GeneralWeekDaysViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/GeneralWeekDays/List.cshtml", model);
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
            GeneralWeekDaysViewModel model = new GeneralWeekDaysViewModel();
            return PartialView("/Views/Employee/GeneralWeekDays/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(GeneralWeekDaysViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralWeekDaysDTO != null)
                    {
                        model.GeneralWeekDaysDTO.ConnectionString = _connectioString;
                        model.GeneralWeekDaysDTO.WeekDescription = model.WeekDescription;
                        model.GeneralWeekDaysDTO.IsActive = true;
                        model.GeneralWeekDaysDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralWeekDays> response = _GeneralWeekDaysBA.InsertGeneralWeekDays(model.GeneralWeekDaysDTO);
                        model.GeneralWeekDaysDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralWeekDaysDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID)
        {
            GeneralWeekDaysViewModel model = new GeneralWeekDaysViewModel();
            model.GeneralWeekDaysDTO = new GeneralWeekDays();
            model.GeneralWeekDaysDTO.ID = ID;
            model.GeneralWeekDaysDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralWeekDays> response = _GeneralWeekDaysBA.SelectByID(model.GeneralWeekDaysDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralWeekDaysDTO.ID = response.Entity.ID;
                model.GeneralWeekDaysDTO.WeekDescription = response.Entity.WeekDescription;
                //model.GeneralWeekDaysDTO.IsActive = response.Entity.IsActive;
            }
            return PartialView("/Views/Employee/GeneralWeekDays/Edit.cshtml",model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralWeekDaysViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralWeekDaysDTO != null)
                    {
                        if (model != null && model.GeneralWeekDaysDTO != null)
                        {
                            model.GeneralWeekDaysDTO.ConnectionString = _connectioString;
                            model.GeneralWeekDaysDTO.WeekDescription = model.WeekDescription;
                            model.GeneralWeekDaysDTO.IsActive = true;
                            model.GeneralWeekDaysDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralWeekDays> response = _GeneralWeekDaysBA.UpdateGeneralWeekDays(model.GeneralWeekDaysDTO);
                            model.GeneralWeekDaysDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralWeekDaysDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        
        public ActionResult Delete(int ID)
        {
            GeneralWeekDaysViewModel model = new GeneralWeekDaysViewModel();
            try
            {

                if (ID > 0)
                {
                    if (model != null && model.GeneralWeekDaysDTO != null)
                    {
                        GeneralWeekDays GeneralWeekDaysDTO = new GeneralWeekDays();
                        GeneralWeekDaysDTO.ConnectionString = _connectioString;
                        GeneralWeekDaysDTO.ID = ID;
                        GeneralWeekDaysDTO.WeekDescription = model.WeekDescription;
                        GeneralWeekDaysDTO.IsActive = model.IsActive;
                        GeneralWeekDaysDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralWeekDays> response = _GeneralWeekDaysBA.DeleteGeneralWeekDays(GeneralWeekDaysDTO);
                        //model.GeneralWeekDaysDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                        model.GeneralWeekDaysDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralWeekDaysDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #endregion

        // Non-Action Methods
        #region Methods
        public IEnumerable<GeneralWeekDaysViewModel> GetGeneralWeekDaysDetails(out int TotalRecords)
        {
            GeneralWeekDaysSearchRequest searchRequest = new GeneralWeekDaysSearchRequest();
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
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<GeneralWeekDaysViewModel> listGeneralWeekDaysViewModel = new List<GeneralWeekDaysViewModel>();
            List<GeneralWeekDays> listGeneralWeekDays = new List<GeneralWeekDays>();
            IBaseEntityCollectionResponse<GeneralWeekDays> baseEntityCollectionResponse = _GeneralWeekDaysBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralWeekDays = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralWeekDays item in listGeneralWeekDays)
                    {
                        GeneralWeekDaysViewModel _GeneralWeekDaysViewModel = new GeneralWeekDaysViewModel();
                        _GeneralWeekDaysViewModel.GeneralWeekDaysDTO = item;
                        listGeneralWeekDaysViewModel.Add(_GeneralWeekDaysViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralWeekDaysViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralWeekDaysViewModel> filteredGeneralWeekDays;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "WeekDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WeekDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralWeekDays = GetGeneralWeekDaysDetails(out TotalRecords);
            var records = filteredGeneralWeekDays.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.WeekDescription.ToString(),c.IsActive.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


