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
    public class GeneralLevelMasterController : BaseController
    {
        IGeneralLevelMasterBA _GeneralLevelMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralLevelMasterController()
        {
            _GeneralLevelMasterBA = new GeneralLevelMasterBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Employee/GeneralLevelMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralLevelMasterViewModel model = new GeneralLevelMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/GeneralLevelMaster/List.cshtml", model);
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
            GeneralLevelMasterViewModel model = new GeneralLevelMasterViewModel();
            return PartialView("/Views/Employee/GeneralLevelMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(GeneralLevelMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralLevelMasterDTO != null)
                    {
                        model.GeneralLevelMasterDTO.ConnectionString = _connectioString;
                        model.GeneralLevelMasterDTO.Description = model.Description;
                        model.GeneralLevelMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralLevelMaster> response = _GeneralLevelMasterBA.InsertGeneralLevelMaster(model.GeneralLevelMasterDTO);
                        model.GeneralLevelMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralLevelMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralLevelMasterViewModel model = new GeneralLevelMasterViewModel();
            model.GeneralLevelMasterDTO = new GeneralLevelMaster();
            model.GeneralLevelMasterDTO.ID = ID;
            model.GeneralLevelMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralLevelMaster> response = _GeneralLevelMasterBA.SelectByID(model.GeneralLevelMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralLevelMasterDTO.ID = response.Entity.ID;
                model.GeneralLevelMasterDTO.Description = response.Entity.Description;
            }
            return PartialView("/Views/Employee/GeneralLevelMaster/Edit.cshtml",model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralLevelMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralLevelMasterDTO != null)
                    {
                        if (model != null && model.GeneralLevelMasterDTO != null)
                        {
                            model.GeneralLevelMasterDTO.ConnectionString = _connectioString;
                            model.GeneralLevelMasterDTO.Description = model.Description;
                            model.GeneralLevelMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralLevelMaster> response = _GeneralLevelMasterBA.UpdateGeneralLevelMaster(model.GeneralLevelMasterDTO);
                            model.GeneralLevelMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralLevelMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            try
            {
                GeneralLevelMasterViewModel model = new GeneralLevelMasterViewModel();
                if (ID > 0)
                {
                    if (model != null && model.GeneralLevelMasterDTO != null)
                    {
                        GeneralLevelMaster GeneralLevelMasterDTO = new GeneralLevelMaster();
                        GeneralLevelMasterDTO.ConnectionString = _connectioString;
                        GeneralLevelMasterDTO.ID = ID;
                        GeneralLevelMasterDTO.Description = model.Description;
                        GeneralLevelMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralLevelMaster> response = _GeneralLevelMasterBA.DeleteGeneralLevelMaster(GeneralLevelMasterDTO);
                        //model.GeneralLevelMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                        model.GeneralLevelMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralLevelMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<GeneralLevelMasterViewModel> GetGeneralLevelMasterDetails(out int TotalRecords)
        {
            GeneralLevelMasterSearchRequest searchRequest = new GeneralLevelMasterSearchRequest();
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
            List<GeneralLevelMasterViewModel> listGeneralLevelMasterViewModel = new List<GeneralLevelMasterViewModel>();
            List<GeneralLevelMaster> listGeneralLevelMaster = new List<GeneralLevelMaster>();
            IBaseEntityCollectionResponse<GeneralLevelMaster> baseEntityCollectionResponse = _GeneralLevelMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLevelMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralLevelMaster item in listGeneralLevelMaster)
                    {
                        GeneralLevelMasterViewModel _GeneralLevelMasterViewModel = new GeneralLevelMasterViewModel();
                        _GeneralLevelMasterViewModel.GeneralLevelMasterDTO = item;
                        listGeneralLevelMasterViewModel.Add(_GeneralLevelMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralLevelMasterViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralLevelMasterViewModel> filteredGeneralLevelMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
              
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralLevelMaster = GetGeneralLevelMasterDetails(out TotalRecords);
            var records = filteredGeneralLevelMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(),Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


