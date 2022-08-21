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
    public class GeneralUnitMasterController : BaseController
    {
        IGeneralUnitMasterBA _GeneralUnitMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralUnitMasterController()
        {
            _GeneralUnitMasterBA = new GeneralUnitMasterBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
           
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/GeneralUnitMaster/Index.cshtml");
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
                GeneralUnitMasterViewModel model = new GeneralUnitMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralUnitMaster/List.cshtml", model);
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
            GeneralUnitMasterViewModel model = new GeneralUnitMasterViewModel();
            return PartialView("/Views/GeneralMaster/GeneralUnitMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(GeneralUnitMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralUnitMasterDTO != null)
                    {
                        model.GeneralUnitMasterDTO.ConnectionString = _connectioString;
                        model.GeneralUnitMasterDTO.UnitDescription = model.UnitDescription;
                        model.GeneralUnitMasterDTO.ShortCode = model.ShortCode;
                        model.GeneralUnitMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<GeneralUnitMaster> response = _GeneralUnitMasterBA.InsertGeneralUnitMaster(model.GeneralUnitMasterDTO);
                        model.GeneralUnitMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralUnitMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(byte ID)
        {
            GeneralUnitMasterViewModel model = new GeneralUnitMasterViewModel();
            model.GeneralUnitMasterDTO = new GeneralUnitMaster();
            model.GeneralUnitMasterDTO.ID = ID;
            model.GeneralUnitMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralUnitMaster> response = _GeneralUnitMasterBA.SelectByID(model.GeneralUnitMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralUnitMasterDTO.ID = response.Entity.ID;
                model.GeneralUnitMasterDTO.UnitDescription = response.Entity.UnitDescription;
                model.GeneralUnitMasterDTO.ShortCode = response.Entity.ShortCode;
            }
            return PartialView("/Views/GeneralMaster/GeneralUnitMaster/Edit.cshtml",model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralUnitMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralUnitMasterDTO != null)
                    {
                        if (model != null && model.GeneralUnitMasterDTO != null)
                        {
                            model.GeneralUnitMasterDTO.ConnectionString = _connectioString;
                            model.GeneralUnitMasterDTO.UnitDescription = model.UnitDescription;
                            model.GeneralUnitMasterDTO.ShortCode = model.ShortCode;
                            model.GeneralUnitMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralUnitMaster> response = _GeneralUnitMasterBA.UpdateGeneralUnitMaster(model.GeneralUnitMasterDTO);
                            model.GeneralUnitMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralUnitMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(byte ID)
        {
            GeneralUnitMasterViewModel model = new GeneralUnitMasterViewModel();
            model.GeneralUnitMasterDTO = new GeneralUnitMaster();
            model.GeneralUnitMasterDTO.ID = ID;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(GeneralUnitMasterViewModel model)
        {
            try
            {

                if (model.ID > 0)
                {
                    if (model != null && model.GeneralUnitMasterDTO != null)
                    {
                        GeneralUnitMaster GeneralUnitMasterDTO = new GeneralUnitMaster();
                        GeneralUnitMasterDTO.ConnectionString = _connectioString;
                        GeneralUnitMasterDTO.ID = model.ID;
                        GeneralUnitMasterDTO.DeletedBy = model.DeletedBy;
                        GeneralUnitMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralUnitMaster> response = _GeneralUnitMasterBA.DeleteGeneralUnitMaster(GeneralUnitMasterDTO);
                        model.GeneralUnitMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralUnitMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<GeneralUnitMasterViewModel> GetGeneralUnitMasterDetails(out int TotalRecords)
        {
            GeneralUnitMasterSearchRequest searchRequest = new GeneralUnitMasterSearchRequest();
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
            List<GeneralUnitMasterViewModel> listGeneralUnitMasterViewModel = new List<GeneralUnitMasterViewModel>();
            List<GeneralUnitMaster> listGeneralUnitMaster = new List<GeneralUnitMaster>();
            IBaseEntityCollectionResponse<GeneralUnitMaster> baseEntityCollectionResponse = _GeneralUnitMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralUnitMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralUnitMaster item in listGeneralUnitMaster)
                    {
                        GeneralUnitMasterViewModel _GeneralUnitMasterViewModel = new GeneralUnitMasterViewModel();
                        _GeneralUnitMasterViewModel.GeneralUnitMasterDTO = item;
                        listGeneralUnitMasterViewModel.Add(_GeneralUnitMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralUnitMasterViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralUnitMasterViewModel> filteredGeneralUnitMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "UnitDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "UnitDescription Like '%" + param.sSearch + "%' or ShortCode Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "UnitDescription Like '%" + param.sSearch + "%' or ShortCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralUnitMaster = GetGeneralUnitMasterDetails(out TotalRecords);
            var records = filteredGeneralUnitMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.UnitDescription), Convert.ToString(c.ShortCode), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


