using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    public class EmployeeCourseSubjectTaughtController : BaseController
    {
        IEmployeeCourseSubjectTaughtServiceAccess _EmployeeCourseSubjectTaughtServiceAccess  = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeCourseSubjectTaughtController()
        {
            _EmployeeCourseSubjectTaughtServiceAccess  = new EmployeeCourseSubjectTaughtServiceAccess();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeeCourseSubjectTaught/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                EmployeeCourseSubjectTaughtViewModel model = new EmployeeCourseSubjectTaughtViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                model.EmployeeCourseSubjectTaughtDTO.EmployeeID = EmployeeID;
                model.EmployeeCourseSubjectTaughtDTO.ConnectionString = _connectioString;
                model.EmployeeID = EmployeeID;
                return PartialView("~/Views/Employee/EmployeeCourseSubjectTaught/List.cshtml", model);
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
            EmployeeCourseSubjectTaughtViewModel model = new EmployeeCourseSubjectTaughtViewModel();
            return PartialView("/Views/Employee/EmployeeCourseSubjectTaught/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeCourseSubjectTaughtViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeCourseSubjectTaughtDTO != null)
                    {
                        model.EmployeeCourseSubjectTaughtDTO.ConnectionString = _connectioString;
                        model.EmployeeCourseSubjectTaughtDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeCourseSubjectTaughtDTO.SubjectName = model.SubjectName;
                        model.EmployeeCourseSubjectTaughtDTO.SubjectCode = model.SubjectCode;
                        model.EmployeeCourseSubjectTaughtDTO.IsActive = true;
                        model.EmployeeCourseSubjectTaughtDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<EmployeeCourseSubjectTaught> response = _EmployeeCourseSubjectTaughtServiceAccess .InsertEmployeeCourseSubjectTaught(model.EmployeeCourseSubjectTaughtDTO);
                        model.EmployeeCourseSubjectTaughtDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeCourseSubjectTaughtDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EmployeeCourseSubjectTaughtViewModel model = new EmployeeCourseSubjectTaughtViewModel();
            model.EmployeeCourseSubjectTaughtDTO = new EmployeeCourseSubjectTaught();
            model.EmployeeCourseSubjectTaughtDTO.ID = ID;
            model.EmployeeCourseSubjectTaughtDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeeCourseSubjectTaught> response = _EmployeeCourseSubjectTaughtServiceAccess .SelectByID(model.EmployeeCourseSubjectTaughtDTO);

            if (response != null && response.Entity != null)
            {

                model.EmployeeCourseSubjectTaughtDTO.ID = response.Entity.ID;
                model.EmployeeCourseSubjectTaughtDTO.EmployeeID = response.Entity.EmployeeID;
                model.EmployeeCourseSubjectTaughtDTO.SubjectName = response.Entity.SubjectName;
                model.EmployeeCourseSubjectTaughtDTO.SubjectCode = response.Entity.SubjectCode;
                model.EmployeeCourseSubjectTaughtDTO.IsActive = response.Entity.IsActive;
            }
            return PartialView("/Views/Employee/EmployeeCourseSubjectTaught/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeCourseSubjectTaughtViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeCourseSubjectTaughtDTO != null)
                    {
                        if (model != null && model.EmployeeCourseSubjectTaughtDTO != null)
                        {
                            model.EmployeeCourseSubjectTaughtDTO.ConnectionString = _connectioString;
                            model.EmployeeCourseSubjectTaughtDTO.ID = model.ID;
                            model.EmployeeCourseSubjectTaughtDTO.EmployeeID = model.EmployeeID;
                            model.EmployeeCourseSubjectTaughtDTO.SubjectName = model.SubjectName;
                            model.EmployeeCourseSubjectTaughtDTO.SubjectCode = model.SubjectCode;
                            model.EmployeeCourseSubjectTaughtDTO.IsActive = model.IsActive;
                            model.EmployeeCourseSubjectTaughtDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<EmployeeCourseSubjectTaught> response = _EmployeeCourseSubjectTaughtServiceAccess .UpdateEmployeeCourseSubjectTaught(model.EmployeeCourseSubjectTaughtDTO);
                            model.EmployeeCourseSubjectTaughtDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.EmployeeCourseSubjectTaughtDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    EmployeeCourseSubjectTaughtViewModel model = new EmployeeCourseSubjectTaughtViewModel();
        //    model.EmployeeCourseSubjectTaughtDTO = new EmployeeCourseSubjectTaught();
        //    model.EmployeeCourseSubjectTaughtDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeeCourseSubjectTaught/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(int ID)
        //{
        //    try
        //    {
        //        EmployeeCourseSubjectTaughtViewModel model = new EmployeeCourseSubjectTaughtViewModel();

        //        if (model.ID > 0)
        //        {
        //            if (model != null && model.EmployeeCourseSubjectTaughtDTO != null)
        //            {
        //                EmployeeCourseSubjectTaught EmployeeCourseSubjectTaughtDTO = new EmployeeCourseSubjectTaught();
        //                EmployeeCourseSubjectTaughtDTO.ConnectionString = _connectioString;
        //                EmployeeCourseSubjectTaughtDTO.ID = model.ID;
        //                EmployeeCourseSubjectTaughtDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<EmployeeCourseSubjectTaught> response = _EmployeeCourseSubjectTaughtServiceAccess .DeleteEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaughtDTO);
        //                model.EmployeeCourseSubjectTaughtDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            }
        //            return Json(model.EmployeeCourseSubjectTaughtDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                EmployeeCourseSubjectTaughtViewModel model = new EmployeeCourseSubjectTaughtViewModel();

                if (ID > 0)
                {
                    
                        EmployeeCourseSubjectTaught EmployeeCourseSubjectTaughtDTO = new EmployeeCourseSubjectTaught();
                        EmployeeCourseSubjectTaughtDTO.ConnectionString = _connectioString;
                        EmployeeCourseSubjectTaughtDTO.ID = ID;
                        EmployeeCourseSubjectTaughtDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeCourseSubjectTaught> response = _EmployeeCourseSubjectTaughtServiceAccess.DeleteEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaughtDTO);
                        model.EmployeeCourseSubjectTaughtDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    return Json(model.EmployeeCourseSubjectTaughtDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<EmployeeCourseSubjectTaughtViewModel> GetEmployeeCourseSubjectTaughtDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeeCourseSubjectTaughtSearchRequest searchRequest = new EmployeeCourseSubjectTaughtSearchRequest();
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
                    searchRequest.EmployeeID = EmployeeID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;
            }
            List<EmployeeCourseSubjectTaughtViewModel> listEmployeeCourseSubjectTaughtViewModel = new List<EmployeeCourseSubjectTaughtViewModel>();
            List<EmployeeCourseSubjectTaught> listEmployeeCourseSubjectTaught = new List<EmployeeCourseSubjectTaught>();
            IBaseEntityCollectionResponse<EmployeeCourseSubjectTaught> baseEntityCollectionResponse = _EmployeeCourseSubjectTaughtServiceAccess .GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeCourseSubjectTaught = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeCourseSubjectTaught item in listEmployeeCourseSubjectTaught)
                    {
                        EmployeeCourseSubjectTaughtViewModel _EmployeeCourseSubjectTaughtViewModel = new EmployeeCourseSubjectTaughtViewModel();
                        _EmployeeCourseSubjectTaughtViewModel.EmployeeCourseSubjectTaughtDTO = item;
                        listEmployeeCourseSubjectTaughtViewModel.Add(_EmployeeCourseSubjectTaughtViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeCourseSubjectTaughtViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param,int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeCourseSubjectTaughtViewModel> filteredEmployeeCourseSubjectTaught;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SubjectName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectName Like '%" + param.sSearch + "%' or SubjectCode Like '%" + param.sSearch +  "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SubjectCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectName Like '%" + param.sSearch + "%' or SubjectCode Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

            
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeCourseSubjectTaught = GetEmployeeCourseSubjectTaughtDetails(EmployeeID, out TotalRecords);
            var records = filteredEmployeeCourseSubjectTaught.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.SubjectName.ToString(), Convert.ToString(c.SubjectCode), Convert.ToString(c.EmployeeID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


