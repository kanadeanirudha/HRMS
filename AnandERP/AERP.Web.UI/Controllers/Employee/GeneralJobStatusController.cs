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
    public class GeneralJobStatusController : BaseController
    {
        IGeneralJobStatusBA _GeneralJobStatusBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralJobStatusController()
        {
            _GeneralJobStatusBA = new GeneralJobStatusBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Employee/GeneralJobStatus/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
               GeneralJobStatusViewModel model = new GeneralJobStatusViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/GeneralJobStatus/List.cshtml", model);
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
           GeneralJobStatusViewModel model = new GeneralJobStatusViewModel();
            return PartialView("/Views/Employee/GeneralJobStatus/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(GeneralJobStatusViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralJobStatusDTO != null)
                    {
                        model.GeneralJobStatusDTO.ConnectionString = _connectioString;
                        model.GeneralJobStatusDTO.JobStatusDescription = model.JobStatusDescription;
                        model.GeneralJobStatusDTO.JobStatusCode = model.JobStatusCode;
                        model.GeneralJobStatusDTO.IsActive = model.IsActive;
                        model.GeneralJobStatusDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralJobStatus> response = _GeneralJobStatusBA.InsertGeneralJobStatus(model.GeneralJobStatusDTO);
                        model.GeneralJobStatusDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralJobStatusDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
           GeneralJobStatusViewModel model = new GeneralJobStatusViewModel();
            model.GeneralJobStatusDTO = new GeneralJobStatus();
            model.GeneralJobStatusDTO.ID = ID;
            model.GeneralJobStatusDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralJobStatus> response = _GeneralJobStatusBA.SelectByID(model.GeneralJobStatusDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralJobStatusDTO.ID = response.Entity.ID;
                model.GeneralJobStatusDTO.JobStatusDescription = response.Entity.JobStatusDescription;
                model.GeneralJobStatusDTO.JobStatusCode = response.Entity.JobStatusCode;
                model.GeneralJobStatusDTO.IsActive = response.Entity.IsActive;
            }
            return PartialView("/Views/Employee/GeneralJobStatus/Edit.cshtml",model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralJobStatusViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralJobStatusDTO != null)
                    {
                        if (model != null && model.GeneralJobStatusDTO != null)
                        {
                            model.GeneralJobStatusDTO.ConnectionString = _connectioString;
                            model.GeneralJobStatusDTO.JobStatusDescription = model.JobStatusDescription;
                            model.GeneralJobStatusDTO.JobStatusCode = model.JobStatusCode;
                            model.GeneralJobStatusDTO.IsActive = model.IsActive;
                            model.GeneralJobStatusDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralJobStatus> response = _GeneralJobStatusBA.UpdateGeneralJobStatus(model.GeneralJobStatusDTO);
                            model.GeneralJobStatusDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralJobStatusDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralJobStatusViewModel model = new GeneralJobStatusViewModel();
            try
            {

                if (ID > 0)
                {
                    
                        GeneralJobStatus GeneralJobStatusDTO = new GeneralJobStatus();
                        GeneralJobStatusDTO.ConnectionString = _connectioString;
                        GeneralJobStatusDTO.ID = ID;
                        model.GeneralJobStatusDTO.JobStatusDescription = model.JobStatusDescription;
                        model.GeneralJobStatusDTO.JobStatusCode = model.JobStatusCode;
                        model.GeneralJobStatusDTO.IsActive = model.IsActive;
                        GeneralJobStatusDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralJobStatus> response = _GeneralJobStatusBA.DeleteGeneralJobStatus(GeneralJobStatusDTO);
                        //model.GeneralJobStatusDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                        model.GeneralJobStatusDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    return Json(model.GeneralJobStatusDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<GeneralJobStatusViewModel> GetGeneralJobStatusDetails(out int TotalRecords)
        {
           GeneralJobStatusSearchRequest searchRequest = new GeneralJobStatusSearchRequest();
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
            List<GeneralJobStatusViewModel> listGeneralJobStatusViewModel = new List<GeneralJobStatusViewModel>();
            List<GeneralJobStatus> listGeneralJobStatus = new List<GeneralJobStatus>();
            IBaseEntityCollectionResponse<GeneralJobStatus> baseEntityCollectionResponse = _GeneralJobStatusBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralJobStatus = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralJobStatus item in listGeneralJobStatus)
                    {
                       GeneralJobStatusViewModel _GeneralJobStatusViewModel = new GeneralJobStatusViewModel();
                        _GeneralJobStatusViewModel.GeneralJobStatusDTO = item;
                        listGeneralJobStatusViewModel.Add(_GeneralJobStatusViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralJobStatusViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralJobStatusViewModel> filteredGeneralJobStatus;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "JobStatusDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobStatusDescription Like '%" + param.sSearch + "%' or JobStatusCode Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "JobStatusCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobStatusDescription Like '%" + param.sSearch + "%' or JobStatusCode Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "IsActive";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobStatusDescription Like '%" + param.sSearch + "%' or JobStatusCode Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralJobStatus = GetGeneralJobStatusDetails(out TotalRecords);
            var records = filteredGeneralJobStatus.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.JobStatusDescription.ToString(),c.JobStatusCode.ToString(),c.IsActive.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


