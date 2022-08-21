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
    public class GeneralEducationTypeMasterController : BaseController
    {
        IGeneralEducationTypeMasterBA _generalCategoryMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralEducationTypeMasterController()
        {
            _generalCategoryMasterBA = new GeneralEducationTypeMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/GeneralEducationTypeMaster/Index.cshtml");
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
                GeneralEducationTypeMasterViewModel model = new GeneralEducationTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralEducationTypeMaster/List.cshtml", model);
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
            GeneralEducationTypeMasterViewModel model = new GeneralEducationTypeMasterViewModel();
            return PartialView("/Views/GeneralMaster/GeneralEducationTypeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralEducationTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralEducationTypeMasterDTO != null)
                    {
                        model.GeneralEducationTypeMasterDTO.ConnectionString = _connectioString;
                        model.GeneralEducationTypeMasterDTO.Description = model.Description;
                        //  model.GeneralEducationTypeMasterDTO.EduSequenceNumber = model.EduSequenceNumber;
                        model.GeneralEducationTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralEducationTypeMaster> response = _generalCategoryMasterBA.InsertGeneralEducationTypeMaster(model.GeneralEducationTypeMasterDTO);
                        model.GeneralEducationTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralEducationTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {
            GeneralEducationTypeMasterViewModel model = new GeneralEducationTypeMasterViewModel();
            model.GeneralEducationTypeMasterDTO = new GeneralEducationTypeMaster();
            model.GeneralEducationTypeMasterDTO.ID = id;
            model.GeneralEducationTypeMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralEducationTypeMaster> response = _generalCategoryMasterBA.SelectByID(model.GeneralEducationTypeMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralEducationTypeMasterDTO.ID = response.Entity.ID;
                model.GeneralEducationTypeMasterDTO.Description = response.Entity.Description;
                model.GeneralEducationTypeMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                model.GeneralEducationTypeMasterDTO.EduSequenceNumber = response.Entity.EduSequenceNumber;
            }
            return PartialView("/Views/GeneralMaster/GeneralEducationTypeMaster/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralEducationTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralEducationTypeMasterDTO != null)
                    {
                        if (model != null && model.GeneralEducationTypeMasterDTO != null)
                        {
                            model.GeneralEducationTypeMasterDTO.ConnectionString = _connectioString;
                            model.GeneralEducationTypeMasterDTO.Description = model.Description;
                            // model.GeneralEducationTypeMasterDTO.EduSequenceNumber = model.EduSequenceNumber;
                            model.GeneralEducationTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralEducationTypeMaster> response = _generalCategoryMasterBA.UpdateGeneralEducationTypeMaster(model.GeneralEducationTypeMasterDTO);
                            model.GeneralEducationTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralEducationTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralEducationTypeMasterViewModel model = new GeneralEducationTypeMasterViewModel();
            try
            {
                //if (!ModelState.IsValid)
                //{
                if (ID > 0)
                {
                    GeneralEducationTypeMaster generalEducationTypeMasterDTO = new GeneralEducationTypeMaster();
                    generalEducationTypeMasterDTO.ConnectionString = _connectioString;
                    generalEducationTypeMasterDTO.ID = ID;
                    generalEducationTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralEducationTypeMaster> response = _generalCategoryMasterBA.DeleteGeneralEducationTypeMaster(generalEducationTypeMasterDTO);
                    model.GeneralEducationTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                return Json(model.GeneralEducationTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return Json("Please review your form");
                //}

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralEducationTypeMasterViewModel> GetGeneralEducationTypeMaster(out int TotalRecords)
        {
            GeneralEducationTypeMasterSearchRequest searchRequest = new GeneralEducationTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update 
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
            List<GeneralEducationTypeMasterViewModel> listGeneralEducationTypeMasterViewModel = new List<GeneralEducationTypeMasterViewModel>();
            List<GeneralEducationTypeMaster> listGeneralEducationTypeMaster = new List<GeneralEducationTypeMaster>();
            IBaseEntityCollectionResponse<GeneralEducationTypeMaster> baseEntityCollectionResponse = _generalCategoryMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralEducationTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralEducationTypeMaster item in listGeneralEducationTypeMaster)
                    {
                        GeneralEducationTypeMasterViewModel generalEducationTypeMasterViewModel = new GeneralEducationTypeMasterViewModel();
                        generalEducationTypeMasterViewModel.GeneralEducationTypeMasterDTO = item;
                        listGeneralEducationTypeMasterViewModel.Add(generalEducationTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralEducationTypeMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc

            IEnumerable<GeneralEducationTypeMasterViewModel> filteredGeneralEducationTypeMaster;
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
                        _searchBy = "Description Like '%" + param.sSearch + "%' or EduSequenceNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "EduSequenceNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or EduSequenceNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralEducationTypeMaster = GetGeneralEducationTypeMaster(out TotalRecords);
            var displayedData = filteredGeneralEducationTypeMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedData select new[] { c.Description.ToString(), c.EduSequenceNumber.ToString(), Convert.ToString(c.ID), c.IsUserDefined.ToString() };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
