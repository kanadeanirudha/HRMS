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
    public class CCRMActionMasterController : BaseController
    {
        ICCRMActionMasterBA _CCRMActionMasterBA = null;
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

        public CCRMActionMasterController()
        {
            _CCRMActionMasterBA = new CCRMActionMasterBA();

        }
        #region Controller Methods
        // GET: CCRMActionMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMActionMaster/Index.cshtml");
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
                CCRMActionMasterViewModel model = new CCRMActionMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMActionMaster/List.cshtml", model);
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
            CCRMActionMasterViewModel model = new CCRMActionMasterViewModel();
           
            return PartialView("/Views/CCRM/CCRMActionMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMActionMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMActionMasterDTO != null)
                    {
                        model.CCRMActionMasterDTO.ConnectionString = _connectioString;

                        model.CCRMActionMasterDTO.ActionCode = model.ActionCode;
                        model.CCRMActionMasterDTO.ActionTitle = model.ActionTitle;
                        model.CCRMActionMasterDTO.ActionDesciption = model.ActionDesciption;
                        model.CCRMActionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMActionMaster> response = _CCRMActionMasterBA.InsertCCRMActionMaster(model.CCRMActionMasterDTO);
                        model.CCRMActionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMActionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int32 id)
        {
            CCRMActionMasterViewModel model = new CCRMActionMasterViewModel();
            try
            {



                model.CCRMActionMasterDTO = new CCRMActionMaster();
                model.CCRMActionMasterDTO.ID = id;
                model.CCRMActionMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMActionMaster> response = _CCRMActionMasterBA.SelectByID(model.CCRMActionMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMActionMasterDTO.ID = response.Entity.ID;
                    model.CCRMActionMasterDTO.ActionCode = response.Entity.ActionCode;
                    model.CCRMActionMasterDTO.ActionTitle = response.Entity.ActionTitle;
                    model.CCRMActionMasterDTO.ActionDesciption = response.Entity.ActionDesciption;
                }

                return PartialView("/Views/CCRM/CCRMActionMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMActionMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMActionMasterDTO != null)
                    {
                        if (model != null && model.CCRMActionMasterDTO != null)
                        {
                            model.CCRMActionMasterDTO.ConnectionString = _connectioString;
                            model.CCRMActionMasterDTO.ActionCode = model.ActionCode;
                            model.CCRMActionMasterDTO.ActionTitle = model.ActionTitle;
                            model.CCRMActionMasterDTO.ActionDesciption = model.ActionDesciption;
                            model.CCRMActionMasterDTO.ID = model.ID;
                            model.CCRMActionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMActionMaster> response = _CCRMActionMasterBA.UpdateCCRMActionMaster(model.CCRMActionMasterDTO);
                            model.CCRMActionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMActionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMActionMasterViewModel model = new CCRMActionMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMActionMaster CCRMActionMasterDTO = new CCRMActionMaster();
                        CCRMActionMasterDTO.ConnectionString = _connectioString;
                        CCRMActionMasterDTO.ID = ID;
                        CCRMActionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMActionMaster> response = _CCRMActionMasterBA.DeleteCCRMActionMaster(CCRMActionMasterDTO);
                        model.CCRMActionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMActionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMActionMasterViewModel> GetCCRMActionMaster(out int TotalRecords)
        {
            CCRMActionMasterSearchRequest searchRequest = new CCRMActionMasterSearchRequest();
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
            List<CCRMActionMasterViewModel> listCCRMActionMasterViewModel = new List<CCRMActionMasterViewModel>();
            List<CCRMActionMaster> listCCRMActionMaster = new List<CCRMActionMaster>();
            IBaseEntityCollectionResponse<CCRMActionMaster> baseEntityCollectionResponse = _CCRMActionMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMActionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMActionMaster item in listCCRMActionMaster)
                    {
                        CCRMActionMasterViewModel CCRMActionMasterViewModel = new CCRMActionMasterViewModel();
                        CCRMActionMasterViewModel.CCRMActionMasterDTO = item;
                        listCCRMActionMasterViewModel.Add(CCRMActionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMActionMasterViewModel;
        }
        public JsonResult GetCCRMActionMasterSearchList(string term)
        {
            CCRMActionMasterSearchRequest searchRequest = new CCRMActionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CCRMActionMaster> listCCRMActionMaster = new List<CCRMActionMaster>();
            IBaseEntityCollectionResponse<CCRMActionMaster> baseEntityCollectionResponse = _CCRMActionMasterBA.GetCCRMActionMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMActionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMActionMaster
                          select new
                          {
                              ID = r.ID,
                              ActionCode = r.ActionCode,
                              ActionTitle = r.ActionTitle,


                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMActionMasterViewModel> filteredCCRMActionMasterViewModel;

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
                        _searchBy = "ID Like '%" + param.sSearch + "%' or ActionCode Like '%" + param.sSearch + "%' or ActionTitle Like '%" + param.sSearch + "%'or ActionDesciption Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ActionCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or ActionCode Like '%" + param.sSearch + "%' or ActionTitle Like '%" + param.sSearch + "%'or ActionDesciption Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "ActionTitle";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or ActionCode Like '%" + param.sSearch + "%' or ActionTitle Like '%" + param.sSearch + "%'or ActionDesciption Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "ActionDesciption";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or ActionCode Like '%" + param.sSearch + "%' or ActionTitle Like '%" + param.sSearch + "%'or ActionDesciption Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMActionMasterViewModel = GetCCRMActionMaster(out TotalRecords);
            var records = filteredCCRMActionMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.ActionCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.ActionTitle),Convert.ToString(c.ActionDesciption) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}