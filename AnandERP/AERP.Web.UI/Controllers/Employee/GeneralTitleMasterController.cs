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
    public class GeneralTitleMasterController : BaseController
    {
        IGeneralTitleMasterBA _GeneralTitleMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralTitleMasterController()
        {
            _GeneralTitleMasterBA = new GeneralTitleMasterBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Employee/GeneralTitleMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralTitleMasterViewModel model = new GeneralTitleMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/GeneralTitleMaster/List.cshtml", model);
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
            GeneralTitleMasterViewModel model = new GeneralTitleMasterViewModel();
            return PartialView("/Views/Employee/GeneralTitleMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(GeneralTitleMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralTitleMasterDTO != null)
                    {
                        model.GeneralTitleMasterDTO.ConnectionString = _connectioString;
                        model.GeneralTitleMasterDTO.NameTitle = model.NameTitle;
                        model.GeneralTitleMasterDTO.Description = model.Description;
                        model.GeneralTitleMasterDTO.Gender = model.Gender;
                        model.GeneralTitleMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralTitleMaster> response = _GeneralTitleMasterBA.InsertGeneralTitleMaster(model.GeneralTitleMasterDTO);
                        model.GeneralTitleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralTitleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralTitleMasterViewModel model = new GeneralTitleMasterViewModel();
            model.GeneralTitleMasterDTO = new GeneralTitleMaster();
            model.GeneralTitleMasterDTO.ID = ID;
            model.GeneralTitleMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralTitleMaster> response = _GeneralTitleMasterBA.SelectByID(model.GeneralTitleMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralTitleMasterDTO.ID = response.Entity.ID;
                model.GeneralTitleMasterDTO.Description = response.Entity.Description;
                model.GeneralTitleMasterDTO.NameTitle = response.Entity.NameTitle;
                model.GeneralTitleMasterDTO.Gender = response.Entity.Gender;
            }
            return PartialView("/Views/Employee/GeneralTitleMaster/Edit.cshtml",model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralTitleMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralTitleMasterDTO != null)
                    {
                        if (model != null && model.GeneralTitleMasterDTO != null)
                        {
                            model.GeneralTitleMasterDTO.ConnectionString = _connectioString;
                            model.GeneralTitleMasterDTO.NameTitle = model.NameTitle;
                            model.GeneralTitleMasterDTO.Description = model.Description;
                            model.GeneralTitleMasterDTO.Gender = model.Gender;
                            model.GeneralTitleMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralTitleMaster> response = _GeneralTitleMasterBA.UpdateGeneralTitleMaster(model.GeneralTitleMasterDTO);
                            model.GeneralTitleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralTitleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralTitleMasterViewModel model = new GeneralTitleMasterViewModel();
            try
            {

                if (ID > 0)
                {
                    
                        GeneralTitleMaster GeneralTitleMasterDTO = new GeneralTitleMaster();
                        GeneralTitleMasterDTO.ConnectionString = _connectioString;
                        GeneralTitleMasterDTO.ID = ID;
                        GeneralTitleMasterDTO.Description = model.Description;
                        GeneralTitleMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralTitleMaster> response = _GeneralTitleMasterBA.DeleteGeneralTitleMaster(GeneralTitleMasterDTO);
                        model.GeneralTitleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    return Json(model.GeneralTitleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<GeneralTitleMasterViewModel> GetGeneralTitleMasterDetails(out int TotalRecords)
        {
            GeneralTitleMasterSearchRequest searchRequest = new GeneralTitleMasterSearchRequest();
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
            List<GeneralTitleMasterViewModel> listGeneralTitleMasterViewModel = new List<GeneralTitleMasterViewModel>();
            List<GeneralTitleMaster> listGeneralTitleMaster = new List<GeneralTitleMaster>();
            IBaseEntityCollectionResponse<GeneralTitleMaster> baseEntityCollectionResponse = _GeneralTitleMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTitleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralTitleMaster item in listGeneralTitleMaster)
                    {
                        GeneralTitleMasterViewModel _GeneralTitleMasterViewModel = new GeneralTitleMasterViewModel();
                        _GeneralTitleMasterViewModel.GeneralTitleMasterDTO = item;
                        listGeneralTitleMasterViewModel.Add(_GeneralTitleMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTitleMasterViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralTitleMasterViewModel> filteredGeneralTitleMaster;
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
                        _searchBy = "Description Like '%" + param.sSearch + "%' or NameTitle Like '%" + param.sSearch + "%' or Gender Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "NameTitle";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or NameTitle Like '%" + param.sSearch + "%' or Gender Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                //case 2:
                //    _sortBy = "Gender";
                //    if (string.IsNullOrEmpty(param.sSearch))
                //    {
                //        _searchBy = string.Empty;
                //    }
                //    else
                //    {
                //        _searchBy = "Description Like '%" + param.sSearch + "%' or NameTitle Like '%" + param.sSearch + "%' or Gender Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                //    }
                //    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralTitleMaster = GetGeneralTitleMasterDetails(out TotalRecords);
            var records = filteredGeneralTitleMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), c.NameTitle.ToString(),c.Gender.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


