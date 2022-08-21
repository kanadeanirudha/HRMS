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
    public class EmployeePatentReceivedDetailsController : BaseController
    {
        IEmployeePatentReceivedDetailsServiceAccess _EmployeePatentReceivedDetailsServiceAccess  = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeePatentReceivedDetailsController()
        {
            _EmployeePatentReceivedDetailsServiceAccess = new EmployeePatentReceivedDetailsServiceAccess();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeePatentReceivedDetails/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                EmployeePatentReceivedDetailsViewModel model = new EmployeePatentReceivedDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                model.EmployeePatentReceivedDetailsDTO.EmployeeID = EmployeeID;
                model.EmployeePatentReceivedDetailsDTO.ConnectionString = _connectioString;
                model.EmployeeID = EmployeeID;
                return PartialView("~/Views/Employee/EmployeePatentReceivedDetails/List.cshtml", model);
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
            EmployeePatentReceivedDetailsViewModel model = new EmployeePatentReceivedDetailsViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text =  Resources.DisplayName_InProcess, Value = "Inprocess" });
            li.Add(new SelectListItem { Text = Resources.DisplayName_Approved, Value = "Approved" });
            li.Add(new SelectListItem { Text = Resources.DisplayName_Rejected, Value = "Rejected" });
            ViewData["PatentApprovalStatus"] = li;
            return PartialView("/Views/Employee/EmployeePatentReceivedDetails/Create.cshtml", model);

        }


        [HttpPost]
        public ActionResult Create(EmployeePatentReceivedDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeePatentReceivedDetailsDTO != null)
                    {
                        model.EmployeePatentReceivedDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeePatentReceivedDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeePatentReceivedDetailsDTO.SubjectOfPatent = model.SubjectOfPatent;
                        model.EmployeePatentReceivedDetailsDTO.DateOfApplication = model.DateOfApplication;
                        model.EmployeePatentReceivedDetailsDTO.PatentApprovalStatus = model.PatentApprovalStatus;
                        model.EmployeePatentReceivedDetailsDTO.DateOfApproval = model.DateOfApproval;
                        model.EmployeePatentReceivedDetailsDTO.Remarks = !String.IsNullOrEmpty(model.Remarks) ? model.Remarks : string.Empty;
                        model.EmployeePatentReceivedDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<EmployeePatentReceivedDetails> response = _EmployeePatentReceivedDetailsServiceAccess .InsertEmployeePatentReceivedDetails(model.EmployeePatentReceivedDetailsDTO);
                        model.EmployeePatentReceivedDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeePatentReceivedDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = Resources.DisplayName_InProcess, Value = "Inprocess" });
            li.Add(new SelectListItem { Text = Resources.DisplayName_Approved, Value = "Approved" });
            li.Add(new SelectListItem { Text = Resources.DisplayName_Rejected, Value = "Rejected" });

            EmployeePatentReceivedDetailsViewModel model = new EmployeePatentReceivedDetailsViewModel();
            model.EmployeePatentReceivedDetailsDTO = new EmployeePatentReceivedDetails();
            model.EmployeePatentReceivedDetailsDTO.ID = ID;
            model.EmployeePatentReceivedDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeePatentReceivedDetails> response = _EmployeePatentReceivedDetailsServiceAccess .SelectByID(model.EmployeePatentReceivedDetailsDTO);

            if (response != null && response.Entity != null)
            {

                model.EmployeePatentReceivedDetailsDTO.ID = response.Entity.ID;
                model.EmployeePatentReceivedDetailsDTO.EmployeeID = response.Entity.EmployeeID;
                model.EmployeePatentReceivedDetailsDTO.SubjectOfPatent = response.Entity.SubjectOfPatent;
                model.EmployeePatentReceivedDetailsDTO.DateOfApplication = response.Entity.DateOfApplication;
                model.EmployeePatentReceivedDetailsDTO.DateOfApproval = response.Entity.DateOfApproval;
                model.EmployeePatentReceivedDetailsDTO.Remarks = response.Entity.Remarks;
                ViewData["PatentApprovalStatus"] = new SelectList(li, "Value", "Text", response.Entity.PatentApprovalStatus);
            }
            return PartialView("/Views/Employee/EmployeePatentReceivedDetails/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeePatentReceivedDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeePatentReceivedDetailsDTO != null)
                    {
                        if (model != null && model.EmployeePatentReceivedDetailsDTO != null)
                        {
                            model.EmployeePatentReceivedDetailsDTO.ConnectionString = _connectioString;
                            model.EmployeePatentReceivedDetailsDTO.ID = model.ID;
                            model.EmployeePatentReceivedDetailsDTO.EmployeeID = model.EmployeeID;
                            model.EmployeePatentReceivedDetailsDTO.SubjectOfPatent = model.SubjectOfPatent;
                            model.EmployeePatentReceivedDetailsDTO.DateOfApplication = model.DateOfApplication;
                            model.EmployeePatentReceivedDetailsDTO.PatentApprovalStatus = model.PatentApprovalStatus;
                            model.EmployeePatentReceivedDetailsDTO.DateOfApproval = model.DateOfApproval;
                            model.EmployeePatentReceivedDetailsDTO.Remarks = !String.IsNullOrEmpty(model.Remarks) ? model.Remarks : string.Empty;
                            model.EmployeePatentReceivedDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<EmployeePatentReceivedDetails> response = _EmployeePatentReceivedDetailsServiceAccess .UpdateEmployeePatentReceivedDetails(model.EmployeePatentReceivedDetailsDTO);
                            model.EmployeePatentReceivedDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.EmployeePatentReceivedDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    EmployeePatentReceivedDetailsViewModel model = new EmployeePatentReceivedDetailsViewModel();
        //    model.EmployeePatentReceivedDetailsDTO = new EmployeePatentReceivedDetails();
        //    model.EmployeePatentReceivedDetailsDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeePatentReceivedDetails/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeePatentReceivedDetailsViewModel model)
        //{
        //    try
        //    {

        //        if (model.ID > 0)
        //        {
        //            if (model != null && model.EmployeePatentReceivedDetailsDTO != null)
        //            {
        //                EmployeePatentReceivedDetails EmployeePatentReceivedDetailsDTO = new EmployeePatentReceivedDetails();
        //                EmployeePatentReceivedDetailsDTO.ConnectionString = _connectioString;
        //                EmployeePatentReceivedDetailsDTO.ID = model.ID;
        //                EmployeePatentReceivedDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<EmployeePatentReceivedDetails> response = _EmployeePatentReceivedDetailsServiceAccess .DeleteEmployeePatentReceivedDetails(EmployeePatentReceivedDetailsDTO);
        //                model.EmployeePatentReceivedDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            }
        //            return Json(model.EmployeePatentReceivedDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                EmployeePatentReceivedDetailsViewModel model = new EmployeePatentReceivedDetailsViewModel();
                if (ID > 0)
                {
                   
                        EmployeePatentReceivedDetails EmployeePatentReceivedDetailsDTO = new EmployeePatentReceivedDetails();
                        EmployeePatentReceivedDetailsDTO.ConnectionString = _connectioString;
                        EmployeePatentReceivedDetailsDTO.ID = ID;
                        EmployeePatentReceivedDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeePatentReceivedDetails> response = _EmployeePatentReceivedDetailsServiceAccess.DeleteEmployeePatentReceivedDetails(EmployeePatentReceivedDetailsDTO);
                        model.EmployeePatentReceivedDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    return Json(model.EmployeePatentReceivedDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<EmployeePatentReceivedDetailsViewModel> GetEmployeePatentReceivedDetailsDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeePatentReceivedDetailsSearchRequest searchRequest = new EmployeePatentReceivedDetailsSearchRequest();
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
            List<EmployeePatentReceivedDetailsViewModel> listEmployeePatentReceivedDetailsViewModel = new List<EmployeePatentReceivedDetailsViewModel>();
            List<EmployeePatentReceivedDetails> listEmployeePatentReceivedDetails = new List<EmployeePatentReceivedDetails>();
            IBaseEntityCollectionResponse<EmployeePatentReceivedDetails> baseEntityCollectionResponse = _EmployeePatentReceivedDetailsServiceAccess .GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeePatentReceivedDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeePatentReceivedDetails item in listEmployeePatentReceivedDetails)
                    {
                        EmployeePatentReceivedDetailsViewModel _EmployeePatentReceivedDetailsViewModel = new EmployeePatentReceivedDetailsViewModel();
                        _EmployeePatentReceivedDetailsViewModel.EmployeePatentReceivedDetailsDTO = item;
                        listEmployeePatentReceivedDetailsViewModel.Add(_EmployeePatentReceivedDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeePatentReceivedDetailsViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeePatentReceivedDetailsViewModel> filteredEmployeePatentReceivedDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SubjectOfPatent";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectOfPatent Like '%" + param.sSearch + "%' or DateOfApplication Like '%" + param.sSearch + "%'  or PatentApprovalStatus Like '%" + param.sSearch + "%'  or DateOfApproval Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DateOfApplication";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectOfPatent Like '%" + param.sSearch + "%' or DateOfApplication Like '%" + param.sSearch + "%'  or PatentApprovalStatus Like '%" + param.sSearch + "%'  or DateOfApproval Like '%" + param.sSearch + "%'";           //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "PatentApprovalStatus";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectOfPatent Like '%" + param.sSearch + "%' or DateOfApplication Like '%" + param.sSearch + "%'  or PatentApprovalStatus Like '%" + param.sSearch + "%'  or DateOfApproval Like '%" + param.sSearch + "%'";           //this "if" block is added for search functionality
                    }
                    break;

                case 3:
                    _sortBy = "DateOfApproval";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectOfPatent Like '%" + param.sSearch + "%' or DateOfApplication Like '%" + param.sSearch + "%'  or PatentApprovalStatus Like '%" + param.sSearch + "%'  or DateOfApproval Like '%" + param.sSearch + "%'";           //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeePatentReceivedDetails = GetEmployeePatentReceivedDetailsDetails(EmployeeID, out TotalRecords);
            var records = filteredEmployeePatentReceivedDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.SubjectOfPatent), Convert.ToString(c.DateOfApplication), Convert.ToString(c.PatentApprovalStatus), Convert.ToString(c.DateOfApproval), Convert.ToString(c.EmployeeID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


