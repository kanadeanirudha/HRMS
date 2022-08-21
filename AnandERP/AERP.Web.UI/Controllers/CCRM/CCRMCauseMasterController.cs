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
using AERP.DataProvider;

namespace AERP.Web.UI.Controllers
{
    public class CCRMCauseMasterController : BaseController
    {
        ICCRMCauseMasterBA _CCRMCauseMasterBA = null;
        //IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public CCRMCauseMasterController()
        {
            _CCRMCauseMasterBA = new CCRMCauseMasterBA();
            //_empEmployeeMasterBA = new EmpEmployeeMasterBA();
        }
        // GET: CCRMCauseMaster
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/CCRM/CCRMCauseMaster/Index.cshtml");
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
                CCRMCauseMasterViewModel model = new CCRMCauseMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMCauseMaster/List.cshtml", model);
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
            CCRMCauseMasterViewModel model = new CCRMCauseMasterViewModel();
            return PartialView("/Views/CCRM/CCRMCauseMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMCauseMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.CCRMCauseMasterDTO != null)
                {
                    model.CCRMCauseMasterDTO.ConnectionString = _connectioString;
                    model.CCRMCauseMasterDTO.CauseTypeTitle = model.CauseTypeTitle;
                    model.CCRMCauseMasterDTO.CauseTypeCode = model.CauseTypeCode;
                    model.CCRMCauseMasterDTO.CauseTypeDescription = model.CauseTypeDescription;
                    model.CCRMCauseMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CCRMCauseMaster> response = _CCRMCauseMasterBA.InsertCCRMCauseType(model.CCRMCauseMasterDTO);

                    model.CCRMCauseMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CCRMCauseMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


                //  }
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
        public ActionResult CreateCCRMCauseMaster(string IDs)
        {
            CCRMCauseMasterViewModel model = new CCRMCauseMasterViewModel();
            string[] IDsArray = IDs.Split('~');
            model.ID = Convert.ToInt32(IDsArray[0]);
            model.CauseTypeTitle = IDsArray[1];
            model.CauseTypeCode = IDsArray[2];

            return PartialView("/Views/CCRM/CCRMCauseMaster/CreateCCRMCauseMaster.cshtml", model);
        }
        [HttpPost]
        public ActionResult CreateCCRMCauseMaster(CCRMCauseMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.CCRMCauseMasterDTO != null)
                {
                    model.CCRMCauseMasterDTO.ConnectionString = _connectioString;
                    model.CCRMCauseMasterDTO.CauseTitle = model.CauseTitle;
                    model.CCRMCauseMasterDTO.CauseCode = model.CauseCode;
                    model.CCRMCauseMasterDTO.CauseDescription = model.CauseDescription;
                    model.CCRMCauseMasterDTO.ID = model.ID;
                    model.CCRMCauseMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CCRMCauseMaster> response = _CCRMCauseMasterBA.InsertCCRMCauseMaster(model.CCRMCauseMasterDTO);

                    model.CCRMCauseMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CCRMCauseMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


                //  }
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
        public ActionResult Edit(Int32 id)
        {
            CCRMCauseMasterViewModel model = new CCRMCauseMasterViewModel();
            try
            {



                model.CCRMCauseMasterDTO = new CCRMCauseMaster();
                model.CCRMCauseMasterDTO.ID = id;
                model.CCRMCauseMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMCauseMaster> response = _CCRMCauseMasterBA.SelectByID(model.CCRMCauseMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMCauseMasterDTO.ID = response.Entity.ID;
                    model.CCRMCauseMasterDTO.CauseTypeTitle = response.Entity.CauseTypeTitle;
                    model.CCRMCauseMasterDTO.CauseTypeCode = response.Entity.CauseTypeCode;
                    model.CCRMCauseMasterDTO.CauseTypeDescription = response.Entity.CauseTypeDescription;
                }

                return PartialView("/Views/CCRM/CCRMCauseMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Edit(CCRMCauseMasterViewModel model)
        {
            try
            {

                if (model != null && model.CCRMCauseMasterDTO != null)
                {
                    if (model != null && model.CCRMCauseMasterDTO != null)
                    {
                        model.CCRMCauseMasterDTO.ConnectionString = _connectioString;
                        model.CCRMCauseMasterDTO.CauseTypeTitle = model.CauseTypeTitle;
                        model.CCRMCauseMasterDTO.CauseTypeCode = model.CauseTypeCode;
                        model.CCRMCauseMasterDTO.CauseTypeDescription = model.CauseTypeDescription;
                        model.CCRMCauseMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMCauseMaster> response = _CCRMCauseMasterBA.UpdateCCRMCauseType(model.CCRMCauseMasterDTO);
                        model.CCRMCauseMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.CCRMCauseMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }


            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Delete(int CCRMCauseMasterID)
        {
            var errorMessage = string.Empty;
            if (CCRMCauseMasterID > 0)
            {
                IBaseEntityResponse<CCRMCauseMaster> response = null;
                CCRMCauseMaster CCRMCauseMasterDTO = new CCRMCauseMaster();
                CCRMCauseMasterDTO.ConnectionString = _connectioString;
                CCRMCauseMasterDTO.CCRMCauseMasterID = Convert.ToInt32(CCRMCauseMasterID);
                CCRMCauseMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _CCRMCauseMasterBA.DeleteCCRMCauseMaster(CCRMCauseMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion
        // Non-Action Method
        #region Methods


        public IEnumerable<CCRMCauseMasterViewModel> GetCCRMCauseMaster(out int TotalRecords)
        {
            CCRMCauseMasterSearchRequest searchRequest = new CCRMCauseMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
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
            List<CCRMCauseMasterViewModel> listCCRMCauseMasterViewModel = new List<CCRMCauseMasterViewModel>();
            List<CCRMCauseMaster> listCCRMCauseMaster = new List<CCRMCauseMaster>();
            IBaseEntityCollectionResponse<CCRMCauseMaster> baseEntityCollectionResponse = _CCRMCauseMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCauseMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMCauseMaster item in listCCRMCauseMaster)
                    {
                        CCRMCauseMasterViewModel CCRMCauseMasterViewModel = new CCRMCauseMasterViewModel();
                        CCRMCauseMasterViewModel.CCRMCauseMasterDTO = item;
                        listCCRMCauseMasterViewModel.Add(CCRMCauseMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMCauseMasterViewModel;
        }
        public JsonResult GetCCRMCauseMasterSearchList(string term)
        {
            CCRMCauseMasterSearchRequest searchRequest = new CCRMCauseMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<CCRMCauseMaster> listCCRMCauseMaster = new List<CCRMCauseMaster>();
            IBaseEntityCollectionResponse<CCRMCauseMaster> baseEntityCollectionResponse = _CCRMCauseMasterBA.GetCCRMCauseMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMCauseMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCCRMCauseMaster
                          select new
                          {
                              ID = r.ID,
                              CauseCode = r.CauseCode,
                              CauseTitle = r.CauseTitle,


                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CCRMCauseMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.CauseTitle";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = " B.CauseTitle Like '%" + param.sSearch + "%' or B.CauseCode Like '%" + param.sSearch + "%'or B.CauseDescription Like '%" + param.sSearch + "%'or A.CauseTypeTitle Like '%" + param.sSearch + "%'or A.CauseTypeCode Like '%" + param.sSearch + "%'or A.CauseTypeDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.CauseCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.CauseTitle Like '%" + param.sSearch + "%' or B.CauseCode Like '%" + param.sSearch + "%'or B.CauseDescription Like '%" + param.sSearch + "%'or A.CauseTypeTitle Like '%" + param.sSearch + "%'or A.CauseTypeCode Like '%" + param.sSearch + "%'or A.CauseTypeDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "B.CauseDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.CauseTitle Like '%" + param.sSearch + "%' or B.CauseCode Like '%" + param.sSearch + "%'or B.CauseDescription Like '%" + param.sSearch + "%'or A.CauseTypeTitle Like '%" + param.sSearch + "%'or A.CauseTypeCode Like '%" + param.sSearch + "%'or A.CauseTypeDescription Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetCCRMCauseMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CauseTitle), Convert.ToString(c.CauseCode), Convert.ToString(c.CauseDescription), Convert.ToString(c.ID), Convert.ToString(c.CCRMCauseMasterID), Convert.ToString(c.CauseTypeTitle + " - " + c.CauseTypeCode), Convert.ToString(c.CauseTypeCode), Convert.ToString(c.CauseTypeDescription), Convert.ToString(c.CauseTypeTitle) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}