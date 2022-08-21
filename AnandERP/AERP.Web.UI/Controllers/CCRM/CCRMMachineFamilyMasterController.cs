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
    public class CCRMMachineFamilyMasterController : BaseController
    {

        ICCRMMachineFamilyMasterBA _CCRMMachineFamilyMasterBA = null;
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

        public CCRMMachineFamilyMasterController()
        {
            _CCRMMachineFamilyMasterBA = new CCRMMachineFamilyMasterBA();

        }
        #region Controller Methods
        // GET: CCRMMachineFamilyMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMMachineFamilyMaster/Index.cshtml");
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
                CCRMMachineFamilyMasterViewModel model = new CCRMMachineFamilyMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMMachineFamilyMaster/List.cshtml", model);
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
            CCRMMachineFamilyMasterViewModel model = new CCRMMachineFamilyMasterViewModel();

            return PartialView("/Views/CCRM/CCRMMachineFamilyMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMMachineFamilyMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMMachineFamilyMasterDTO != null)
                    {
                        model.CCRMMachineFamilyMasterDTO.ConnectionString = _connectioString;
                        model.CCRMMachineFamilyMasterDTO.MachineFamilyName = model.MachineFamilyName;
                        model.CCRMMachineFamilyMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMMachineFamilyMaster> response = _CCRMMachineFamilyMasterBA.InsertCCRMMachineFamilyMaster(model.CCRMMachineFamilyMasterDTO);
                        model.CCRMMachineFamilyMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMMachineFamilyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int16 id)
        {
            CCRMMachineFamilyMasterViewModel model = new CCRMMachineFamilyMasterViewModel();
            try
            {



                model.CCRMMachineFamilyMasterDTO = new CCRMMachineFamilyMaster();
                model.CCRMMachineFamilyMasterDTO.ID = id;
                model.CCRMMachineFamilyMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMMachineFamilyMaster> response = _CCRMMachineFamilyMasterBA.SelectByID(model.CCRMMachineFamilyMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMMachineFamilyMasterDTO.ID = response.Entity.ID;
                    model.CCRMMachineFamilyMasterDTO.MachineFamilyName = response.Entity.MachineFamilyName;
                }

                return PartialView("/Views/CCRM/CCRMMachineFamilyMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMMachineFamilyMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMMachineFamilyMasterDTO != null)
                    {
                        if (model != null && model.CCRMMachineFamilyMasterDTO != null)
                        {
                            model.CCRMMachineFamilyMasterDTO.ConnectionString = _connectioString;
                            model.CCRMMachineFamilyMasterDTO.MachineFamilyName = model.MachineFamilyName;
                            model.CCRMMachineFamilyMasterDTO.ID = model.ID;
                            model.CCRMMachineFamilyMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMMachineFamilyMaster> response = _CCRMMachineFamilyMasterBA.UpdateCCRMMachineFamilyMaster(model.CCRMMachineFamilyMasterDTO);
                            model.CCRMMachineFamilyMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMMachineFamilyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(Int16 ID)
        {
            CCRMMachineFamilyMasterViewModel model = new CCRMMachineFamilyMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMMachineFamilyMaster CCRMMachineFamilyMasterDTO = new CCRMMachineFamilyMaster();
                        CCRMMachineFamilyMasterDTO.ConnectionString = _connectioString;
                        CCRMMachineFamilyMasterDTO.ID = ID;
                        CCRMMachineFamilyMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMMachineFamilyMaster> response = _CCRMMachineFamilyMasterBA.DeleteCCRMMachineFamilyMaster(CCRMMachineFamilyMasterDTO);
                        model.CCRMMachineFamilyMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMMachineFamilyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMMachineFamilyMasterViewModel> GetCCRMMachineFamilyMaster(out int TotalRecords)
        {
            CCRMMachineFamilyMasterSearchRequest searchRequest = new CCRMMachineFamilyMasterSearchRequest();
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
            List<CCRMMachineFamilyMasterViewModel> listCCRMMachineFamilyMasterViewModel = new List<CCRMMachineFamilyMasterViewModel>();
            List<CCRMMachineFamilyMaster> listCCRMMachineFamilyMaster = new List<CCRMMachineFamilyMaster>();
            IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> baseEntityCollectionResponse = _CCRMMachineFamilyMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMachineFamilyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMMachineFamilyMaster item in listCCRMMachineFamilyMaster)
                    {
                        CCRMMachineFamilyMasterViewModel CCRMMachineFamilyMasterViewModel = new CCRMMachineFamilyMasterViewModel();
                        CCRMMachineFamilyMasterViewModel.CCRMMachineFamilyMasterDTO = item;
                        listCCRMMachineFamilyMasterViewModel.Add(CCRMMachineFamilyMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMMachineFamilyMasterViewModel;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMMachineFamilyMasterViewModel> filteredCCRMMachineFamilyMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or MachineFamilyName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "MachineFamilyName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or MachineFamilyName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMMachineFamilyMasterViewModel = GetCCRMMachineFamilyMaster(out TotalRecords);
            var records = filteredCCRMMachineFamilyMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.MachineFamilyName.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}