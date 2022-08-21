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
    public class CCRMServiceCallTypesController : BaseController
    {
        ICCRMServiceCallTypesBA _CCRMServiceCallTypesBA = null;
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

        public CCRMServiceCallTypesController()
        {
            _CCRMServiceCallTypesBA = new CCRMServiceCallTypesBA();

        }
        #region Controller Methods
        // GET: CCRMServiceCallTypes
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMServiceCallTypes/Index.cshtml");
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
                CCRMServiceCallTypesViewModel model = new CCRMServiceCallTypesViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMServiceCallTypes/List.cshtml", model);
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
            CCRMServiceCallTypesViewModel model = new CCRMServiceCallTypesViewModel();

            return PartialView("/Views/CCRM/CCRMServiceCallTypes/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMServiceCallTypesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMServiceCallTypesDTO != null)
                    {
                        model.CCRMServiceCallTypesDTO.ConnectionString = _connectioString;

                        model.CCRMServiceCallTypesDTO.CallTypeCode = model.CallTypeCode;
                        model.CCRMServiceCallTypesDTO.CallTypeName = model.CallTypeName;
                        model.CCRMServiceCallTypesDTO.ISCalculateResponceTime = model.ISCalculateResponceTime;
                        model.CCRMServiceCallTypesDTO.ISPMCall = model.ISPMCall;
                        model.CCRMServiceCallTypesDTO.ISServiceReportRequired = model.ISServiceReportRequired;
                        model.CCRMServiceCallTypesDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMServiceCallTypes> response = _CCRMServiceCallTypesBA.InsertCCRMServiceCallTypes(model.CCRMServiceCallTypesDTO);
                        model.CCRMServiceCallTypesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMServiceCallTypesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int32 id)
        {
            CCRMServiceCallTypesViewModel model = new CCRMServiceCallTypesViewModel();
            try
            {



                model.CCRMServiceCallTypesDTO = new CCRMServiceCallTypes();
                model.CCRMServiceCallTypesDTO.ID = id;
                model.CCRMServiceCallTypesDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMServiceCallTypes> response = _CCRMServiceCallTypesBA.SelectByID(model.CCRMServiceCallTypesDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMServiceCallTypesDTO.ID = response.Entity.ID;
                    model.CCRMServiceCallTypesDTO.CallTypeCode = response.Entity.CallTypeCode;
                    model.CCRMServiceCallTypesDTO.CallTypeName = response.Entity.CallTypeName;
                    model.CCRMServiceCallTypesDTO.ISCalculateResponceTime = response.Entity.ISCalculateResponceTime;
                    model.CCRMServiceCallTypesDTO.ISPMCall = response.Entity.ISPMCall;
                    model.CCRMServiceCallTypesDTO.ISServiceReportRequired = response.Entity.ISServiceReportRequired;
                }

                return PartialView("/Views/CCRM/CCRMServiceCallTypes/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMServiceCallTypesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMServiceCallTypesDTO != null)
                    {
                        if (model != null && model.CCRMServiceCallTypesDTO != null)
                        {
                            model.CCRMServiceCallTypesDTO.ConnectionString = _connectioString;
                            model.CCRMServiceCallTypesDTO.CallTypeCode = model.CallTypeCode;
                            model.CCRMServiceCallTypesDTO.CallTypeName = model.CallTypeName;
                            model.CCRMServiceCallTypesDTO.ISCalculateResponceTime = model.ISCalculateResponceTime;
                            model.CCRMServiceCallTypesDTO.ISPMCall = model.ISPMCall;
                            model.CCRMServiceCallTypesDTO.ISServiceReportRequired = model.ISServiceReportRequired;
                            model.CCRMServiceCallTypesDTO.ID = model.ID;
                            model.CCRMServiceCallTypesDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMServiceCallTypes> response = _CCRMServiceCallTypesBA.UpdateCCRMServiceCallTypes(model.CCRMServiceCallTypesDTO);
                            model.CCRMServiceCallTypesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMServiceCallTypesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(Int32 ID)
        {
            CCRMServiceCallTypesViewModel model = new CCRMServiceCallTypesViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMServiceCallTypes CCRMServiceCallTypesDTO = new CCRMServiceCallTypes();
                        CCRMServiceCallTypesDTO.ConnectionString = _connectioString;
                        CCRMServiceCallTypesDTO.ID = ID;
                        CCRMServiceCallTypesDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMServiceCallTypes> response = _CCRMServiceCallTypesBA.DeleteCCRMServiceCallTypes(CCRMServiceCallTypesDTO);
                        model.CCRMServiceCallTypesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMServiceCallTypesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMServiceCallTypesViewModel> GetCCRMServiceCallTypes(out int TotalRecords)
        {
            CCRMServiceCallTypesSearchRequest searchRequest = new CCRMServiceCallTypesSearchRequest();
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
            List<CCRMServiceCallTypesViewModel> listCCRMServiceCallTypesViewModel = new List<CCRMServiceCallTypesViewModel>();
            List<CCRMServiceCallTypes> listCCRMServiceCallTypes = new List<CCRMServiceCallTypes>();
            IBaseEntityCollectionResponse<CCRMServiceCallTypes> baseEntityCollectionResponse = _CCRMServiceCallTypesBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMServiceCallTypes = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMServiceCallTypes item in listCCRMServiceCallTypes)
                    {
                        CCRMServiceCallTypesViewModel CCRMServiceCallTypesViewModel = new CCRMServiceCallTypesViewModel();
                        CCRMServiceCallTypesViewModel.CCRMServiceCallTypesDTO = item;
                        listCCRMServiceCallTypesViewModel.Add(CCRMServiceCallTypesViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMServiceCallTypesViewModel;
        }
        #endregion
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMServiceCallTypesViewModel> filteredCCRMServiceCallTypesViewModel;

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
                        _searchBy = "ID Like '%" + param.sSearch + "%' or CallTypeCode Like '%" + param.sSearch + "%' or CallTypeName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CallTypeCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or CallTypeCode Like '%" + param.sSearch + "%'or CallTypeName Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "CallTypeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or CallTypeCode Like '%" + param.sSearch + "%'or  CallTypeName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMServiceCallTypesViewModel = GetCCRMServiceCallTypes(out TotalRecords);
            var records = filteredCCRMServiceCallTypesViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.CallTypeCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.CallTypeName),Convert.ToString(c.ISCalculateResponceTime),Convert.ToString(c.ISPMCall),Convert.ToString(c.ISServiceReportRequired) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}