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
    public class CCRMAreaPatchMasterController : BaseController
    {
        ICCRMAreaPatchMasterBA _CCRMAreaPatchMasterBA = null;
        ICCRMEngineersGroupMasterBA _CCRMEngineersGroupMasterBA = null;
        IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
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

        public CCRMAreaPatchMasterController()
        {
            _CCRMAreaPatchMasterBA = new CCRMAreaPatchMasterBA();
            _CCRMEngineersGroupMasterBA = new CCRMEngineersGroupMasterBA();
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();

        }
        #region Controller Methods
        // GET: CCRMAreaPatchMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMAreaPatchMaster/Index.cshtml");
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
                CCRMAreaPatchMasterViewModel model = new CCRMAreaPatchMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMAreaPatchMaster/List.cshtml", model);
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
            CCRMAreaPatchMasterViewModel model = new CCRMAreaPatchMasterViewModel();
            //*********************Group*********************//
            List<CCRMEngineersGroupMaster> CCRMEngineersGroupMaster = GetCCRMEngineersGroupMaster();
            List<SelectListItem> CCRMEngineersGroupMasterList = new List<SelectListItem>();
            foreach (CCRMEngineersGroupMaster item in CCRMEngineersGroupMaster)
            {
                CCRMEngineersGroupMasterList.Add(new SelectListItem { Text = item.GroupName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMEngineersGroupMasterList = new SelectList(CCRMEngineersGroupMasterList, "Value", "Text", model.CCRMEngineersGroupMasterID);

            return PartialView("/Views/CCRM/CCRMAreaPatchMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMAreaPatchMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMAreaPatchMasterDTO != null)
                    {
                        model.CCRMAreaPatchMasterDTO.ConnectionString = _connectioString;

                        model.CCRMAreaPatchMasterDTO.AreaPatchName = model.AreaPatchName;
                        model.CCRMAreaPatchMasterDTO.EmployeeMasterID = model.EmployeeMasterID;
                        model.CCRMAreaPatchMasterDTO.CCRMEngineersGroupMasterID = model.CCRMEngineersGroupMasterID;
                        model.CCRMAreaPatchMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMAreaPatchMaster> response = _CCRMAreaPatchMasterBA.InsertCCRMAreaPatchMaster(model.CCRMAreaPatchMasterDTO);
                        model.CCRMAreaPatchMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMAreaPatchMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMAreaPatchMasterViewModel model = new CCRMAreaPatchMasterViewModel();
            //*********************Group*********************//
            List<CCRMEngineersGroupMaster> CCRMEngineersGroupMaster = GetCCRMEngineersGroupMaster();
            List<SelectListItem> CCRMEngineersGroupMasterList = new List<SelectListItem>();
            foreach (CCRMEngineersGroupMaster item in CCRMEngineersGroupMaster)
            {
                CCRMEngineersGroupMasterList.Add(new SelectListItem { Text = item.GroupName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMEngineersGroupMasterList = new SelectList(CCRMEngineersGroupMasterList, "Value", "Text", model.CCRMEngineersGroupMasterID);
            try
            {



                model.CCRMAreaPatchMasterDTO = new CCRMAreaPatchMaster();
                model.CCRMAreaPatchMasterDTO.ID = id;
                model.CCRMAreaPatchMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMAreaPatchMaster> response = _CCRMAreaPatchMasterBA.SelectByID(model.CCRMAreaPatchMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMAreaPatchMasterDTO.ID = response.Entity.ID;
                    model.CCRMAreaPatchMasterDTO.AreaPatchName = response.Entity.AreaPatchName;
                    model.CCRMAreaPatchMasterDTO.EmployeeMasterID = response.Entity.EmployeeMasterID;
                    model.CCRMAreaPatchMasterDTO.CCRMEngineersGroupMasterID = response.Entity.CCRMEngineersGroupMasterID;
                    model.CCRMAreaPatchMasterDTO.EmployeeName = response.Entity.EmployeeName;
                }

                return PartialView("/Views/CCRM/CCRMAreaPatchMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMAreaPatchMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMAreaPatchMasterDTO != null)
                    {
                        if (model != null && model.CCRMAreaPatchMasterDTO != null)
                        {
                            model.CCRMAreaPatchMasterDTO.ConnectionString = _connectioString;
                            model.CCRMAreaPatchMasterDTO.AreaPatchName = model.AreaPatchName;
                            model.CCRMAreaPatchMasterDTO.EmployeeMasterID = model.EmployeeMasterID;
                            model.CCRMAreaPatchMasterDTO.CCRMEngineersGroupMasterID = model.CCRMEngineersGroupMasterID;
                            model.CCRMAreaPatchMasterDTO.ID = model.ID;
                            model.CCRMAreaPatchMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMAreaPatchMaster> response = _CCRMAreaPatchMasterBA.UpdateCCRMAreaPatchMaster(model.CCRMAreaPatchMasterDTO);
                            model.CCRMAreaPatchMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMAreaPatchMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMAreaPatchMasterViewModel model = new CCRMAreaPatchMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMAreaPatchMaster CCRMAreaPatchMasterDTO = new CCRMAreaPatchMaster();
                        CCRMAreaPatchMasterDTO.ConnectionString = _connectioString;
                        CCRMAreaPatchMasterDTO.ID = ID;
                        CCRMAreaPatchMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMAreaPatchMaster> response = _CCRMAreaPatchMasterBA.DeleteCCRMAreaPatchMaster(CCRMAreaPatchMasterDTO);
                        model.CCRMAreaPatchMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMAreaPatchMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public JsonResult GetCCRMAreaPatchMasterSearchList(string term)
        {
            CCRMAreaPatchMasterSearchRequest searchRequest = new CCRMAreaPatchMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CCRMAreaPatchMaster> listCCRMAreaPatchMaster = new List<CCRMAreaPatchMaster>();
            IBaseEntityCollectionResponse<CCRMAreaPatchMaster> baseEntityCollectionResponse = _CCRMAreaPatchMasterBA.GetCCRMAreaPatchMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMAreaPatchMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMAreaPatchMaster
                          select new
                          {
                              ID = r.ID,
                              AreaPatchName = r.AreaPatchName,
                             
                            

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<CCRMAreaPatchMasterViewModel> GetCCRMAreaPatchMaster(out int TotalRecords)
        {
            CCRMAreaPatchMasterSearchRequest searchRequest = new CCRMAreaPatchMasterSearchRequest();
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
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<CCRMAreaPatchMasterViewModel> listCCRMAreaPatchMasterViewModel = new List<CCRMAreaPatchMasterViewModel>();
            List<CCRMAreaPatchMaster> listCCRMAreaPatchMaster = new List<CCRMAreaPatchMaster>();
            IBaseEntityCollectionResponse<CCRMAreaPatchMaster> baseEntityCollectionResponse = _CCRMAreaPatchMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMAreaPatchMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMAreaPatchMaster item in listCCRMAreaPatchMaster)
                    {
                        CCRMAreaPatchMasterViewModel CCRMAreaPatchMasterViewModel = new CCRMAreaPatchMasterViewModel();
                        CCRMAreaPatchMasterViewModel.CCRMAreaPatchMasterDTO = item;
                        listCCRMAreaPatchMasterViewModel.Add(CCRMAreaPatchMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMAreaPatchMasterViewModel;
        }
        protected List<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMaster()
        {
            CCRMEngineersGroupMasterSearchRequest searchRequest = new CCRMEngineersGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMEngineersGroupMaster> listCCRMEngineersGroupMaster = new List<CCRMEngineersGroupMaster>();
            IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> baseEntityCollectionResponse = _CCRMEngineersGroupMasterBA.GetCCRMEngineersGroupMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMEngineersGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMEngineersGroupMaster;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMAreaPatchMasterViewModel> filteredCCRMAreaPatchMasterViewModel;

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
                        _searchBy = " A.AreaPatchName Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%'or B.EmployeeLastName Like '%" + param.sSearch + "%'or C.GroupName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "AreaPatchName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = " A.AreaPatchName Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%'or B.EmployeeLastName Like '%" + param.sSearch + "%'or C.GroupName Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "EmployeeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = " A.AreaPatchName Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%'or B.EmployeeLastName Like '%" + param.sSearch + "%'or C.GroupName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "GroupName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = " A.AreaPatchName Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%' or B.EmployeeMiddleName Like '%" + param.sSearch + "%'or B.EmployeeLastName Like '%" + param.sSearch + "%'or C.GroupName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMAreaPatchMasterViewModel = GetCCRMAreaPatchMaster(out TotalRecords);
            var records = filteredCCRMAreaPatchMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.AreaPatchName.ToString(), Convert.ToString(c.ID), Convert.ToString(c.EmployeeMasterID), Convert.ToString(c.CCRMEngineersGroupMasterID), Convert.ToString(c.EmployeeName), Convert.ToString(c.GroupName) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}