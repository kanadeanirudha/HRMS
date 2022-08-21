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
    public class GeneralEducationMasterController : BaseController
    {
        IGeneralEducationMasterBA _generalEducationMasterBA = null;
        private readonly ILogger _logException;
        IGeneralEducationMasterBaseViewModel _generalEducationMasterBaseViewModel = null;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralEducationMasterController()
        {
            _generalEducationMasterBA = new GeneralEducationMasterBA();
            _generalEducationMasterBaseViewModel = new GeneralEducationMasterBaseViewModel();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/GeneralEducationMaster/Index.cshtml");
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
                GeneralEducationMasterViewModel model = new GeneralEducationMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralEducationMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string EducationTypeMaster)
        {
            GeneralEducationMasterViewModel model = new GeneralEducationMasterViewModel();
            try
            {
                List<GeneralEducationTypeMaster> GeneralEducationTypeMasterList = GetListGeneralEducationTypeMaster();
                List<SelectListItem> GeneralEducationTypeMaster = new List<SelectListItem>();
                foreach (GeneralEducationTypeMaster item in GeneralEducationTypeMasterList)
                {
                    GeneralEducationTypeMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralEducationTypeMaster = new SelectList(GeneralEducationTypeMaster, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView("/Views/GeneralMaster/GeneralEducationMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralEducationMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralEducationMasterDTO != null)
                    {
                        model.GeneralEducationMasterDTO.ConnectionString = _connectioString;
                        model.GeneralEducationMasterDTO.Description = model.Description;
                        model.GeneralEducationMasterDTO.EducationTypeID = model.EducationTypeID;
                        model.GeneralEducationMasterDTO.NumberOfYears = model.NumberOfYears;
                        model.GeneralEducationMasterDTO.Unit = model.Unit;
                        model.GeneralEducationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralEducationMaster> response = _generalEducationMasterBA.InsertGeneralEducationMaster(model.GeneralEducationMasterDTO);
                        model.GeneralEducationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralEducationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GeneralEducationMasterViewModel model = new GeneralEducationMasterViewModel();
            try
            {
                List<GeneralEducationTypeMaster> GeneralEducationTypeMasterList = GetListGeneralEducationTypeMaster();
                List<SelectListItem> GeneralEducationTypeMaster = new List<SelectListItem>();
                foreach (GeneralEducationTypeMaster item in GeneralEducationTypeMasterList)
                {
                    GeneralEducationTypeMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                model.GeneralEducationMasterDTO = new GeneralEducationMaster();
                model.GeneralEducationMasterDTO.ID = id;
                model.GeneralEducationMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralEducationMaster> response = _generalEducationMasterBA.SelectByID(model.GeneralEducationMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralEducationMasterDTO.ID = response.Entity.ID;
                    model.GeneralEducationMasterDTO.Description = response.Entity.Description;
                    model.GeneralEducationMasterDTO.EducationTypeID = response.Entity.EducationTypeID;
                    model.GeneralEducationMasterDTO.NumberOfYears = response.Entity.NumberOfYears;
                    model.GeneralEducationMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.GeneralEducationMasterDTO.Unit = response.Entity.Unit;
                    ViewBag.GeneralEducationTypeMaster = new SelectList(GeneralEducationTypeMaster, "Value", "Text", response.Entity.EducationTypeID.ToString());
                }
                return PartialView("/Views/GeneralMaster/GeneralEducationMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection Collection, GeneralEducationMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralEducationMasterDTO != null)
                    {
                        if (model != null && model.GeneralEducationMasterDTO != null)
                        {
                            model.GeneralEducationMasterDTO.ConnectionString = _connectioString;
                            model.GeneralEducationMasterDTO.Description = model.Description;
                            model.GeneralEducationMasterDTO.EducationTypeID = Convert.ToInt32(model.EducationTypeID);
                            model.GeneralEducationMasterDTO.NumberOfYears = model.NumberOfYears;
                            model.GeneralEducationMasterDTO.Unit = model.Unit;
                            model.GeneralEducationMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                            IBaseEntityResponse<GeneralEducationMaster> response = _generalEducationMasterBA.UpdateGeneralEducationMaster(model.GeneralEducationMasterDTO);
                            model.GeneralEducationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralEducationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult Delete(int ID)
        {
            GeneralEducationMasterViewModel model = new GeneralEducationMasterViewModel();
            if (ID > 0)
            {
                if (ID > 0)
                {
                    GeneralEducationMaster generalEducationMasterDTO = new GeneralEducationMaster();
                    generalEducationMasterDTO.ConnectionString = _connectioString;
                    generalEducationMasterDTO.ID = ID;
                    generalEducationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralEducationMaster> response = _generalEducationMasterBA.DeleteGeneralEducationMaster(generalEducationMasterDTO);
                    model.GeneralEducationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                return Json(model.GeneralEducationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralEducationMasterViewModel> GetGeneralEducationMaster(out int TotalRecords)
        {
            GeneralEducationMasterSearchRequest searchRequest = new GeneralEducationMasterSearchRequest();
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
            List<GeneralEducationMasterViewModel> listGeneralEducationMasterViewModel = new List<GeneralEducationMasterViewModel>();
            List<GeneralEducationMaster> listGeneralEducationMaster = new List<GeneralEducationMaster>();
            IBaseEntityCollectionResponse<GeneralEducationMaster> baseEntityCollectionResponse = _generalEducationMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralEducationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralEducationMaster item in listGeneralEducationMaster)
                    {
                        GeneralEducationMasterViewModel orgStreamMasterViewModel = new GeneralEducationMasterViewModel();
                        orgStreamMasterViewModel.GeneralEducationMasterDTO = item;
                        listGeneralEducationMasterViewModel.Add(orgStreamMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralEducationMasterViewModel;
        }
        #endregion    

        // AjaxHandler Method
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc

            IEnumerable<GeneralEducationMasterViewModel> filteredGeneralEducationMaster;
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
                        _searchBy = "Description Like '%" + param.sSearch + "%' or NumberOfYears Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "NumberOfYears";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or NumberOfYears Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralEducationMaster = GetGeneralEducationMaster(out TotalRecords);
            var displayedData = filteredGeneralEducationMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedData select new[] { c.Description.ToString(), c.NumberOfYears.ToString() + " " + c.Unit.ToString(), Convert.ToString(c.ID), c.IsUserDefined.ToString() };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}











