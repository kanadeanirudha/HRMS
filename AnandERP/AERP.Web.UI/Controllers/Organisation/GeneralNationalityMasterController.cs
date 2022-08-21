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
    public class GeneralNationalityMasterController : BaseController
    {
        IGeneralNationalityMasterBA __genNationalityMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
          
        public GeneralNationalityMasterController()
        {
            __genNationalityMasterBA = new GeneralNationalityMasterBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/GeneralNationalityMaster/Index.cshtml");
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
            GeneralNationalityMasterViewModel model = new GeneralNationalityMasterViewModel();
            if (!string.IsNullOrEmpty(actionMode))
            {
                TempData["ActionMode"] = actionMode;
            }
            return PartialView("/Views/GeneralMaster/GeneralNationalityMaster/List.cshtml", model);
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
            GeneralNationalityMasterViewModel model = new GeneralNationalityMasterViewModel();
            return PartialView("/Views/GeneralMaster/GeneralNationalityMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(GeneralNationalityMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralNationalityMasterDTO != null)
                {
                    model.GeneralNationalityMasterDTO.ConnectionString = _connectioString;
                    model.GeneralNationalityMasterDTO.Description = model.Description;
                    model.GeneralNationalityMasterDTO.DefaultFlag = model.DefaultFlag;
                    model.GeneralNationalityMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                    IBaseEntityResponse<GeneralNationalityMaster> response = __genNationalityMasterBA.InsertGeneralNationalityMaster(model.GeneralNationalityMasterDTO);
                    model.GeneralNationalityMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.GeneralNationalityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralNationalityMasterViewModel model = new GeneralNationalityMasterViewModel();
            model.GeneralNationalityMasterDTO = new GeneralNationalityMaster();
            model.GeneralNationalityMasterDTO.ID = ID;
            model.GeneralNationalityMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralNationalityMaster> response = __genNationalityMasterBA.SelectByID(model.GeneralNationalityMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralNationalityMasterDTO.ID = response.Entity.ID;
                model.GeneralNationalityMasterDTO.Description = response.Entity.Description;
                model.GeneralNationalityMasterDTO.DefaultFlag = response.Entity.DefaultFlag;
                model.GeneralNationalityMasterDTO.IsUserDefined = response.Entity.IsUserDefined;   
            }
            return PartialView("/Views/GeneralMaster/GeneralNationalityMaster/Edit.cshtml",model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralNationalityMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralNationalityMasterDTO != null)
                {
                    if (model != null && model.GeneralNationalityMasterDTO != null)
                    {
                        model.GeneralNationalityMasterDTO.ConnectionString = _connectioString;
                        model.GeneralNationalityMasterDTO.Description = model.Description;
                        model.GeneralNationalityMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralNationalityMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);   
                        IBaseEntityResponse<GeneralNationalityMaster> response = __genNationalityMasterBA.UpdateGeneralNationalityMaster(model.GeneralNationalityMasterDTO);
                        model.GeneralNationalityMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralNationalityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        
        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            GeneralNationalityMasterViewModel model = new GeneralNationalityMasterViewModel();
            try
            {

                if (ID > 0)
                {
                    
                        GeneralNationalityMaster GeneralNationalityMasterDTO = new GeneralNationalityMaster();
                        GeneralNationalityMasterDTO.ConnectionString = _connectioString;
                        GeneralNationalityMasterDTO.ID = ID;
                        //GeneralNationalityMasterDTO.DeletedBy = model.DeletedBy;
                        GeneralNationalityMasterDTO.Description = model.Description;
                        GeneralNationalityMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralNationalityMaster> response = __genNationalityMasterBA.DeleteGeneralNationalityMaster(GeneralNationalityMasterDTO);
                        model.GeneralNationalityMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    return Json(model.GeneralNationalityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<GeneralNationalityMasterViewModel> GetGeneralNationalityMasterDetails(out int TotalRecords)
        {
            GeneralNationalityMasterSearchRequest searchRequest = new GeneralNationalityMasterSearchRequest();
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
            List<GeneralNationalityMasterViewModel> listGeneralNationalityMasterViewModel = new List<GeneralNationalityMasterViewModel>();
            List<GeneralNationalityMaster> listGeneralNationalityMaster = new List<GeneralNationalityMaster>();
            IBaseEntityCollectionResponse<GeneralNationalityMaster> baseEntityCollectionResponse = __genNationalityMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralNationalityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralNationalityMaster item in listGeneralNationalityMaster)
                    {
                        GeneralNationalityMasterViewModel _genNationalityMasterViewModel = new GeneralNationalityMasterViewModel();
                        _genNationalityMasterViewModel.GeneralNationalityMasterDTO = item;
                        listGeneralNationalityMasterViewModel.Add(_genNationalityMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralNationalityMasterViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
    
            IEnumerable<GeneralNationalityMasterViewModel> filteredGeneralNationalityMaster;
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
                        _searchBy = "Description Like '%" + param.sSearch + "%' or DefaultFlag Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DefaultFlag";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or DefaultFlag Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralNationalityMaster = GetGeneralNationalityMasterDetails(out TotalRecords);
            var records = filteredGeneralNationalityMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), c.DefaultFlag.ToString(), Convert.ToString(c.ID), c.IsUserDefined.ToString() };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


