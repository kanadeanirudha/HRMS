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
    public class CCRMFeedbackMasterController : BaseController
    {

        ICCRMFeedbackMasterBA _CCRMFeedbackMasterBA = null;
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

        public CCRMFeedbackMasterController()
        {
            _CCRMFeedbackMasterBA = new CCRMFeedbackMasterBA();

        }
        #region Controller Methods
        // GET: CCRMFeedbackMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMFeedbackMaster/Index.cshtml");
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
                CCRMFeedbackMasterViewModel model = new CCRMFeedbackMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMFeedbackMaster/List.cshtml", model);
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
            CCRMFeedbackMasterViewModel model = new CCRMFeedbackMasterViewModel();

            return PartialView("/Views/CCRM/CCRMFeedbackMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMFeedbackMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMFeedbackMasterDTO != null)
                    {
                        model.CCRMFeedbackMasterDTO.ConnectionString = _connectioString;

                        model.CCRMFeedbackMasterDTO.FeedbackName = model.FeedbackName;
                        model.CCRMFeedbackMasterDTO.FeedbackPoints = model.FeedbackPoints;
                        model.CCRMFeedbackMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMFeedbackMaster> response = _CCRMFeedbackMasterBA.InsertCCRMFeedbackMaster(model.CCRMFeedbackMasterDTO);
                        model.CCRMFeedbackMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMFeedbackMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMFeedbackMasterViewModel model = new CCRMFeedbackMasterViewModel();
            try
            {



                model.CCRMFeedbackMasterDTO = new CCRMFeedbackMaster();
                model.CCRMFeedbackMasterDTO.ID = id;
                model.CCRMFeedbackMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMFeedbackMaster> response = _CCRMFeedbackMasterBA.SelectByID(model.CCRMFeedbackMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMFeedbackMasterDTO.ID = response.Entity.ID;
                    model.CCRMFeedbackMasterDTO.FeedbackName = response.Entity.FeedbackName;
                    model.CCRMFeedbackMasterDTO.FeedbackPoints = response.Entity.FeedbackPoints;
                }

                return PartialView("/Views/CCRM/CCRMFeedbackMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMFeedbackMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMFeedbackMasterDTO != null)
                    {
                        if (model != null && model.CCRMFeedbackMasterDTO != null)
                        {
                            model.CCRMFeedbackMasterDTO.ConnectionString = _connectioString;
                            model.CCRMFeedbackMasterDTO.FeedbackName = model.FeedbackName;
                            model.CCRMFeedbackMasterDTO.FeedbackPoints = model.FeedbackPoints;
                            model.CCRMFeedbackMasterDTO.ID = model.ID;
                            model.CCRMFeedbackMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMFeedbackMaster> response = _CCRMFeedbackMasterBA.UpdateCCRMFeedbackMaster(model.CCRMFeedbackMasterDTO);
                            model.CCRMFeedbackMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMFeedbackMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMFeedbackMasterViewModel model = new CCRMFeedbackMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMFeedbackMaster CCRMFeedbackMasterDTO = new CCRMFeedbackMaster();
                        CCRMFeedbackMasterDTO.ConnectionString = _connectioString;
                        CCRMFeedbackMasterDTO.ID = ID;
                        CCRMFeedbackMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMFeedbackMaster> response = _CCRMFeedbackMasterBA.DeleteCCRMFeedbackMaster(CCRMFeedbackMasterDTO);
                        model.CCRMFeedbackMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMFeedbackMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMFeedbackMasterViewModel> GetCCRMFeedbackMaster(out int TotalRecords)
        {
            CCRMFeedbackMasterSearchRequest searchRequest = new CCRMFeedbackMasterSearchRequest();
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
            List<CCRMFeedbackMasterViewModel> listCCRMFeedbackMasterViewModel = new List<CCRMFeedbackMasterViewModel>();
            List<CCRMFeedbackMaster> listCCRMFeedbackMaster = new List<CCRMFeedbackMaster>();
            IBaseEntityCollectionResponse<CCRMFeedbackMaster> baseEntityCollectionResponse = _CCRMFeedbackMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMFeedbackMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMFeedbackMaster item in listCCRMFeedbackMaster)
                    {
                        CCRMFeedbackMasterViewModel CCRMFeedbackMasterViewModel = new CCRMFeedbackMasterViewModel();
                        CCRMFeedbackMasterViewModel.CCRMFeedbackMasterDTO = item;
                        listCCRMFeedbackMasterViewModel.Add(CCRMFeedbackMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMFeedbackMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMFeedbackMasterViewModel> filteredCCRMFeedbackMasterViewModel;

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
                        _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackName Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "FeedbackName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackName Like '%" + param.sSearch + "%'or FeedbackPoints Like '%" + param.sSearch + "%'";
                       // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "FeedbackPoints";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackName Like '%" + param.sSearch + "%'or  FeedbackPoints Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMFeedbackMasterViewModel = GetCCRMFeedbackMaster(out TotalRecords);
            var records = filteredCCRMFeedbackMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.FeedbackName.ToString(), Convert.ToString(c.ID),Convert.ToString(c.FeedbackPoints) };
          
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }


}