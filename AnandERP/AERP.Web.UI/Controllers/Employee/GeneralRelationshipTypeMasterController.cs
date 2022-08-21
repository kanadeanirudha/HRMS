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
    public class GeneralRelationshipTypeMasterController : BaseController
    {
        IGeneralRelationshipTypeMasterBA _GeneralRelationshipTypeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralRelationshipTypeMasterController()
        {
            _GeneralRelationshipTypeMasterBA = new GeneralRelationshipTypeMasterBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Employee/GeneralRelationshipTypeMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralRelationshipTypeMasterViewModel model = new GeneralRelationshipTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/GeneralRelationshipTypeMaster/List.cshtml", model);
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
            GeneralRelationshipTypeMasterViewModel model = new GeneralRelationshipTypeMasterViewModel();
            return PartialView("/Views/Employee/GeneralRelationshipTypeMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(GeneralRelationshipTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralRelationshipTypeMasterDTO != null)
                    {
                        model.GeneralRelationshipTypeMasterDTO.ConnectionString = _connectioString;
                        model.GeneralRelationshipTypeMasterDTO.Description = model.Description;                     
                        model.GeneralRelationshipTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralRelationshipTypeMaster> response = _GeneralRelationshipTypeMasterBA.InsertGeneralRelationshipTypeMaster(model.GeneralRelationshipTypeMasterDTO);
                        model.GeneralRelationshipTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralRelationshipTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralRelationshipTypeMasterViewModel model = new GeneralRelationshipTypeMasterViewModel();
            model.GeneralRelationshipTypeMasterDTO = new GeneralRelationshipTypeMaster();
            model.GeneralRelationshipTypeMasterDTO.ID = ID;
            model.GeneralRelationshipTypeMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralRelationshipTypeMaster> response = _GeneralRelationshipTypeMasterBA.SelectByID(model.GeneralRelationshipTypeMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralRelationshipTypeMasterDTO.ID = response.Entity.ID;
                model.GeneralRelationshipTypeMasterDTO.Description = response.Entity.Description;    
            }
            return PartialView("/Views/Employee/GeneralRelationshipTypeMaster/Edit.cshtml",model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralRelationshipTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralRelationshipTypeMasterDTO != null)
                    {
                        if (model != null && model.GeneralRelationshipTypeMasterDTO != null)
                        {
                            model.GeneralRelationshipTypeMasterDTO.ConnectionString = _connectioString;
                            model.GeneralRelationshipTypeMasterDTO.Description = model.Description;
                            model.GeneralRelationshipTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralRelationshipTypeMaster> response = _GeneralRelationshipTypeMasterBA.UpdateGeneralRelationshipTypeMaster(model.GeneralRelationshipTypeMasterDTO);
                            model.GeneralRelationshipTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralRelationshipTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralRelationshipTypeMasterViewModel model = new GeneralRelationshipTypeMasterViewModel();
            try
            {

                if (ID > 0)
                {
                    if (model != null && model.GeneralRelationshipTypeMasterDTO != null)
                    {
                        GeneralRelationshipTypeMaster GeneralRelationshipTypeMasterDTO = new GeneralRelationshipTypeMaster();
                        GeneralRelationshipTypeMasterDTO.ConnectionString = _connectioString;
                        GeneralRelationshipTypeMasterDTO.ID = ID;
                        GeneralRelationshipTypeMasterDTO.Description = model.Description;
                        GeneralRelationshipTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralRelationshipTypeMaster> response = _GeneralRelationshipTypeMasterBA.DeleteGeneralRelationshipTypeMaster(GeneralRelationshipTypeMasterDTO);
                        //model.GeneralRelationshipTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                        model.GeneralRelationshipTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralRelationshipTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<GeneralRelationshipTypeMasterViewModel> GetGeneralRelationshipTypeMasterDetails(out int TotalRecords)
        {
            GeneralRelationshipTypeMasterSearchRequest searchRequest = new GeneralRelationshipTypeMasterSearchRequest();
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
            List<GeneralRelationshipTypeMasterViewModel> listGeneralRelationshipTypeMasterViewModel = new List<GeneralRelationshipTypeMasterViewModel>();
            List<GeneralRelationshipTypeMaster> listGeneralRelationshipTypeMaster = new List<GeneralRelationshipTypeMaster>();
            IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> baseEntityCollectionResponse = _GeneralRelationshipTypeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralRelationshipTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralRelationshipTypeMaster item in listGeneralRelationshipTypeMaster)
                    {
                        GeneralRelationshipTypeMasterViewModel _GeneralRelationshipTypeMasterViewModel = new GeneralRelationshipTypeMasterViewModel();
                        _GeneralRelationshipTypeMasterViewModel.GeneralRelationshipTypeMasterDTO = item;
                        listGeneralRelationshipTypeMasterViewModel.Add(_GeneralRelationshipTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralRelationshipTypeMasterViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralRelationshipTypeMasterViewModel> filteredGeneralRelationshipTypeMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = " Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = " Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
               
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralRelationshipTypeMaster = GetGeneralRelationshipTypeMasterDetails(out TotalRecords);
            var records = filteredGeneralRelationshipTypeMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


