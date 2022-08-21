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
    public class CCRMBrokenCallReasonMasterController : BaseController
    {
        ICCRMBrokenCallReasonMasterBA _CCRMBrokenCallReasonMasterBA = null;
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

        public CCRMBrokenCallReasonMasterController()
        {
            _CCRMBrokenCallReasonMasterBA = new CCRMBrokenCallReasonMasterBA();

        }
        #region Controller Methods
        // GET: CCRMBrokenCallReasonMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMBrokenCallReasonMaster/Index.cshtml");
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
                CCRMBrokenCallReasonMasterViewModel model = new CCRMBrokenCallReasonMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMBrokenCallReasonMaster/List.cshtml", model);
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
            CCRMBrokenCallReasonMasterViewModel model = new CCRMBrokenCallReasonMasterViewModel();

            return PartialView("/Views/CCRM/CCRMBrokenCallReasonMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMBrokenCallReasonMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMBrokenCallReasonMasterDTO != null)
                    {
                        model.CCRMBrokenCallReasonMasterDTO.ConnectionString = _connectioString;

                        model.CCRMBrokenCallReasonMasterDTO.ReasonCode = model.ReasonCode;
                        model.CCRMBrokenCallReasonMasterDTO.ReasonDescription = model.ReasonDescription;
                        model.CCRMBrokenCallReasonMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMBrokenCallReasonMaster> response = _CCRMBrokenCallReasonMasterBA.InsertCCRMBrokenCallReasonMaster(model.CCRMBrokenCallReasonMasterDTO);
                        model.CCRMBrokenCallReasonMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMBrokenCallReasonMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(byte id)
        {
            CCRMBrokenCallReasonMasterViewModel model = new CCRMBrokenCallReasonMasterViewModel();
            try
            {



                model.CCRMBrokenCallReasonMasterDTO = new CCRMBrokenCallReasonMaster();
                model.CCRMBrokenCallReasonMasterDTO.ID = id;
                model.CCRMBrokenCallReasonMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMBrokenCallReasonMaster> response = _CCRMBrokenCallReasonMasterBA.SelectByID(model.CCRMBrokenCallReasonMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMBrokenCallReasonMasterDTO.ID = response.Entity.ID;
                    model.CCRMBrokenCallReasonMasterDTO.ReasonCode = response.Entity.ReasonCode;
                    model.CCRMBrokenCallReasonMasterDTO.ReasonDescription = response.Entity.ReasonDescription;
                }

                return PartialView("/Views/CCRM/CCRMBrokenCallReasonMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMBrokenCallReasonMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMBrokenCallReasonMasterDTO != null)
                    {
                        if (model != null && model.CCRMBrokenCallReasonMasterDTO != null)
                        {
                            model.CCRMBrokenCallReasonMasterDTO.ConnectionString = _connectioString;
                            model.CCRMBrokenCallReasonMasterDTO.ReasonCode = model.ReasonCode;
                            model.CCRMBrokenCallReasonMasterDTO.ReasonDescription = model.ReasonDescription;
                            model.CCRMBrokenCallReasonMasterDTO.ID = model.ID;
                            model.CCRMBrokenCallReasonMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMBrokenCallReasonMaster> response = _CCRMBrokenCallReasonMasterBA.UpdateCCRMBrokenCallReasonMaster(model.CCRMBrokenCallReasonMasterDTO);
                            model.CCRMBrokenCallReasonMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMBrokenCallReasonMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(byte ID)
        {
            CCRMBrokenCallReasonMasterViewModel model = new CCRMBrokenCallReasonMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMBrokenCallReasonMaster CCRMBrokenCallReasonMasterDTO = new CCRMBrokenCallReasonMaster();
                        CCRMBrokenCallReasonMasterDTO.ConnectionString = _connectioString;
                        CCRMBrokenCallReasonMasterDTO.ID = ID;
                        CCRMBrokenCallReasonMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMBrokenCallReasonMaster> response = _CCRMBrokenCallReasonMasterBA.DeleteCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMasterDTO);
                        model.CCRMBrokenCallReasonMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMBrokenCallReasonMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMBrokenCallReasonMasterViewModel> GetCCRMBrokenCallReasonMaster(out int TotalRecords)
        {
            CCRMBrokenCallReasonMasterSearchRequest searchRequest = new CCRMBrokenCallReasonMasterSearchRequest();
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
            List<CCRMBrokenCallReasonMasterViewModel> listCCRMBrokenCallReasonMasterViewModel = new List<CCRMBrokenCallReasonMasterViewModel>();
            List<CCRMBrokenCallReasonMaster> listCCRMBrokenCallReasonMaster = new List<CCRMBrokenCallReasonMaster>();
            IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> baseEntityCollectionResponse = _CCRMBrokenCallReasonMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMBrokenCallReasonMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMBrokenCallReasonMaster item in listCCRMBrokenCallReasonMaster)
                    {
                        CCRMBrokenCallReasonMasterViewModel CCRMBrokenCallReasonMasterViewModel = new CCRMBrokenCallReasonMasterViewModel();
                        CCRMBrokenCallReasonMasterViewModel.CCRMBrokenCallReasonMasterDTO = item;
                        listCCRMBrokenCallReasonMasterViewModel.Add(CCRMBrokenCallReasonMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMBrokenCallReasonMasterViewModel;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMBrokenCallReasonMasterViewModel> filteredCCRMBrokenCallReasonMasterViewModel;

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
                        _searchBy = "ID Like '%" + param.sSearch + "%' or ReasonCode Like '%" + param.sSearch + "%' or ReasonDescription Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ReasonCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or ReasonCode Like '%" + param.sSearch + "%'or ReasonDescription Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "ReasonDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or ReasonCode Like '%" + param.sSearch + "%'or  ReasonDescription Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMBrokenCallReasonMasterViewModel = GetCCRMBrokenCallReasonMaster(out TotalRecords);
            var records = filteredCCRMBrokenCallReasonMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.ReasonCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.ReasonDescription) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}