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
    public class CCRMEngineersGroupMasterController : BaseController
    {
        ICCRMEngineersGroupMasterBA _CCRMEngineersGroupMasterBA = null;
        IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CCRMEngineersGroupMasterController()
        {
            _CCRMEngineersGroupMasterBA = new CCRMEngineersGroupMasterBA();
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/CCRM/CCRMEngineersGroupMaster/Index.cshtml");
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
                CCRMEngineersGroupMasterViewModel model = new CCRMEngineersGroupMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMEngineersGroupMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult CreateGroup()
        {
            CCRMEngineersGroupMasterViewModel model = new CCRMEngineersGroupMasterViewModel();
            return PartialView("/Views/CCRM/CCRMEngineersGroupMaster/CreateGroup.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMEngineersGroupMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.CCRMEngineersGroupMasterDTO != null)
                {
                    model.CCRMEngineersGroupMasterDTO.ConnectionString = _connectioString;
                    model.CCRMEngineersGroupMasterDTO.GroupName = model.GroupName;
                    model.CCRMEngineersGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CCRMEngineersGroupMaster> response = _CCRMEngineersGroupMasterBA.InsertCCRMEngineersGroupMaster(model.CCRMEngineersGroupMasterDTO);

                    model.CCRMEngineersGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CCRMEngineersGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateEngineersGroupDetails(string IDs)
        {
            CCRMEngineersGroupMasterViewModel model = new CCRMEngineersGroupMasterViewModel();
            string[] IDsArray = IDs.Split('~');
            model.ID = Convert.ToInt32(IDsArray[1]);
            model.GroupName = IDsArray[0];
            return PartialView("/Views/CCRM/CCRMEngineersGroupMaster/CreateEngineersGroupDetails.cshtml", model);
        }
        [HttpPost]
        public ActionResult CreateGroup(CCRMEngineersGroupMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.CCRMEngineersGroupMasterDTO != null)
                {
                    model.CCRMEngineersGroupMasterDTO.ConnectionString = _connectioString;
                    model.CCRMEngineersGroupMasterDTO.GroupName = model.GroupName;
                    model.CCRMEngineersGroupMasterDTO.ID = model.ID;
                    model.CCRMEngineersGroupMasterDTO.EmployeeMasterID = model.EmployeeMasterID;
                    model.CCRMEngineersGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CCRMEngineersGroupMaster> response = _CCRMEngineersGroupMasterBA.InsertCCRMEngineersGroupDetails(model.CCRMEngineersGroupMasterDTO);

                    model.CCRMEngineersGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CCRMEngineersGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Edit(CCRMEngineersGroupMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.CCRMEngineersGroupMasterDTO != null)
                {
                    if (model != null && model.CCRMEngineersGroupMasterDTO != null)
                    {
                        model.CCRMEngineersGroupMasterDTO.ConnectionString = _connectioString;
                        model.CCRMEngineersGroupMasterDTO.GroupName = model.GroupName;
                        model.CCRMEngineersGroupMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMEngineersGroupMaster> response = _CCRMEngineersGroupMasterBA.UpdateCCRMEngineersGroupMaster(model.CCRMEngineersGroupMasterDTO);
                        model.CCRMEngineersGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.CCRMEngineersGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }



        public ActionResult Delete(int CCRMEngineersGroupDetailsID)
        {
            var errorMessage = string.Empty;
            if (CCRMEngineersGroupDetailsID > 0)
            {
                IBaseEntityResponse<CCRMEngineersGroupMaster> response = null;
                CCRMEngineersGroupMaster CCRMEngineersGroupMasterDTO = new CCRMEngineersGroupMaster();
                CCRMEngineersGroupMasterDTO.ConnectionString = _connectioString;
                CCRMEngineersGroupMasterDTO.CCRMEngineersGroupDetailsID = Convert.ToInt32(CCRMEngineersGroupDetailsID);
                CCRMEngineersGroupMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _CCRMEngineersGroupMasterBA.DeleteCCRMEngineersGroupMaster(CCRMEngineersGroupMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods

        [HttpPost]
        public JsonResult GetEmployeeeMasterSearchList(string term)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<EmpEmployeeMaster> listCustomerMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterBA.GetEmployeeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCustomerMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCustomerMaster
                          select new
                          {
                              EmployeeMasterID = r.ID,
                              EmployeeName = r.EmployeeFullName

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<CCRMEngineersGroupMasterViewModel> GetCCRMEngineersGroupMaster(out int TotalRecords)
        {
            CCRMEngineersGroupMasterSearchRequest searchRequest = new CCRMEngineersGroupMasterSearchRequest();
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
            List<CCRMEngineersGroupMasterViewModel> listCCRMEngineersGroupMasterViewModel = new List<CCRMEngineersGroupMasterViewModel>();
            List<CCRMEngineersGroupMaster> listCCRMEngineersGroupMaster = new List<CCRMEngineersGroupMaster>();
            IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> baseEntityCollectionResponse = _CCRMEngineersGroupMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMEngineersGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMEngineersGroupMaster item in listCCRMEngineersGroupMaster)
                    {
                        CCRMEngineersGroupMasterViewModel CCRMEngineersGroupMasterViewModel = new CCRMEngineersGroupMasterViewModel();
                        CCRMEngineersGroupMasterViewModel.CCRMEngineersGroupMasterDTO = item;
                        listCCRMEngineersGroupMasterViewModel.Add(CCRMEngineersGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMEngineersGroupMasterViewModel;
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

                IEnumerable<CCRMEngineersGroupMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.GroupName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "Concat(C.EmployeeFirstName,' ',C.EmployeeMiddleName,' ',C.EmployeeLastName) Like '%" + param.sSearch + "%' or A.GroupName Like '%" + param.sSearch + "%' or C.EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "EmployeeName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Concat(C.EmployeeFirstName,' ',C.EmployeeMiddleName,' ',C.EmployeeLastName) Like '%" + param.sSearch + "%' or A.GroupName Like '%" + param.sSearch + "%' or C.EmployeeCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "C.EmployeeCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Concat(C.EmployeeFirstName,' ',C.EmployeeMiddleName,' ',C.EmployeeLastName) Like '%" + param.sSearch + "%' or A.GroupName Like '%" + param.sSearch + "%' or C.EmployeeCode Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetCCRMEngineersGroupMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.GroupName), Convert.ToString(c.EmployeeCode), Convert.ToString(c.EmployeeMasterID), Convert.ToString(c.EmployeeName), Convert.ToString(c.ID), Convert.ToString(c.CCRMEngineersGroupDetailsID) };

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