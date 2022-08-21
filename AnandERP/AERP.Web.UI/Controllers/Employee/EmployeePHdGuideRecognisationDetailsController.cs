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
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class EmployeePHdGuideRecognisationDetailsController : BaseController
    {
        IEmployeePHdGuideRecognisationDetailsServiceAccess _employeePHdGuideRecognisationDetailsServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeePHdGuideRecognisationDetailsController()
        {
            _employeePHdGuideRecognisationDetailsServiceAcess = new EmployeePHdGuideRecognisationDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeePHdGuideRecognisationDetails/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                EmployeePHdGuideRecognisationDetailsViewModel model = new EmployeePHdGuideRecognisationDetailsViewModel();
                List<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterList = GetListGeneralBoardUniversityMaster();
                List<SelectListItem> GeneralBoardUniversityMaster = new List<SelectListItem>();
                foreach (GeneralBoardUniversityMaster item in GeneralBoardUniversityMasterList)
                {
                    GeneralBoardUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                }
                model.EmployeePHdGuideRecognisationDetailsDTO.ConnectionString = _connectioString;
                model.EmployeePHdGuideRecognisationDetailsDTO.EmployeeID= EmployeeID;
                IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _employeePHdGuideRecognisationDetailsServiceAcess.SelectByID(model.EmployeePHdGuideRecognisationDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeePHdGuideRecognisationDetailsDTO.ID = response.Entity.ID;
                    model.EmployeePHdGuideRecognisationDetailsDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalSubjectName = response.Entity.ApprovalSubjectName;
                    model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalFromDate = response.Entity.ApprovalFromDate; ;
                    model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalUptoDate = response.Entity.ApprovalUptoDate;
                    model.EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalNumber = response.Entity.UniversityApprovalNumber;
                    model.EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalDate = response.Entity.UniversityApprovalDate; ;
                    model.EmployeePHdGuideRecognisationDetailsDTO.NoOfCandidateCompletedPHd = response.Entity.NoOfCandidateCompletedPHd;
                    model.EmployeePHdGuideRecognisationDetailsDTO.NumberOfCandidateRegistered = response.Entity.NumberOfCandidateRegistered;
                    model.EmployeePHdGuideRecognisationDetailsDTO.Remarks = response.Entity.Remarks;
                    ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text",response.Entity.GeneralBoardUniversityID);
                    model.EmployeePHdGuideRecognisationDetailsDTO.GeneralBoardUniversityID = response.Entity.GeneralBoardUniversityID;
                }
                else
                {
                    ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text");
                }
                model.EmployeeID = EmployeeID;
                return PartialView("~/Views/Employee/EmployeePHdGuideRecognisationDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult CreateEmployeePHdGuideRecognisationDetails( EmployeePHdGuideRecognisationDetailsViewModel model)
        {
            try
            {
                    if (model != null && model.EmployeePHdGuideRecognisationDetailsDTO != null)
                    {
                        model.EmployeePHdGuideRecognisationDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeePHdGuideRecognisationDetailsDTO.ID = model.ID;
                        model.EmployeePHdGuideRecognisationDetailsDTO.GeneralBoardUniversityID = model.GeneralBoardUniversityID; ;
                        model.EmployeePHdGuideRecognisationDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalSubjectName = model.ApprovalSubjectName;
                        model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalFromDate = model.ApprovalFromDate;
                        model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalUptoDate = model.ApprovalUptoDate; ;
                        model.EmployeePHdGuideRecognisationDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalNumber = model.UniversityApprovalNumber;
                        model.EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalDate = model.UniversityApprovalDate;
                        model.EmployeePHdGuideRecognisationDetailsDTO.NumberOfCandidateRegistered = model.NumberOfCandidateRegistered;
                        model.EmployeePHdGuideRecognisationDetailsDTO.NoOfCandidateCompletedPHd = model.NoOfCandidateCompletedPHd;
                        model.EmployeePHdGuideRecognisationDetailsDTO.Remarks = !string.IsNullOrEmpty(model.Remarks) ? model.Remarks : string.Empty ;
                        model.EmployeePHdGuideRecognisationDetailsDTO.IsActive = true;
                        model.EmployeePHdGuideRecognisationDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        
                        if (model.ID == 0)
                        {
                            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _employeePHdGuideRecognisationDetailsServiceAcess.InsertEmployeePHdGuideRecognisationDetails(model.EmployeePHdGuideRecognisationDetailsDTO);
                            model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                            model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage = model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage +"~"+( (response.Entity != null) ? response.Entity.ID : 0);
                        }
                        else if (model.ID > 0)
                        {
                            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _employeePHdGuideRecognisationDetailsServiceAcess.InsertEmployeePHdGuideRecognisationDetails(model.EmployeePHdGuideRecognisationDetailsDTO);
                            model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                            model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage = model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage + "~" + ((response.Entity != null) ? response.Entity.ID : 0);
                        }
                        return Json(model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]   // Create Action Method is used for Insert as well as Update operation
        public ActionResult Create(int EmpStuPhdDetID)
        {
            try
            {
                EmployeePHdGuideRecognisationDetailsViewModel model = new EmployeePHdGuideRecognisationDetailsViewModel();
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = Resources.DisplayName_InProcess, Value = "Inprocess" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Approved, Value = "Approved" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Rejected, Value = "Rejected" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Awarded, Value = "Awarded" });
                if (EmpStuPhdDetID > 0)
                {
                    //for update
                    model.EmployeePHdGuideRecognisationDetailsDTO.ConnectionString = _connectioString;
                    model.EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID = EmpStuPhdDetID;
                    IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _employeePHdGuideRecognisationDetailsServiceAcess.SelectByIDEmployeePHdGuideStudentsDetails(model.EmployeePHdGuideRecognisationDetailsDTO);
                    if (response != null && response.Entity != null)
                    {
                        model.EmployeePHdGuideRecognisationDetailsDTO.ID = response.Entity.ID;
                        model.EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID = response.Entity.EmployeePHdGuideStudentsDetailsID;
                        model.EmployeePHdGuideRecognisationDetailsDTO.StudentName = response.Entity.StudentName;
                        model.EmployeePHdGuideRecognisationDetailsDTO.Synopsis = response.Entity.Synopsis; ;
                        model.EmployeePHdGuideRecognisationDetailsDTO.PersuingFromDate = response.Entity.PersuingFromDate;
                        model.EmployeePHdGuideRecognisationDetailsDTO.PersuingUptoDate = response.Entity.PersuingUptoDate;
                        model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalDate = response.Entity.ApprovalDate; ;
                        model.EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsRemarks = response.Entity.EmployeePHdGuideStudentsDetailsRemarks;
                        ViewData["ApprovalStatus"] = new SelectList(li, "Value", "Text", response.Entity.ApprovalStatus);
                    }
                }
                else
                {
                    //for insert
                    ViewData["ApprovalStatus"] = li;
                }
                return PartialView("/Views/Employee/EmployeePHdGuideRecognisationDetails/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(EmployeePHdGuideRecognisationDetailsViewModel model)
        {
            try
            {
               
                    if (model != null && model.EmployeePHdGuideRecognisationDetailsDTO != null)
                    {
                        model.EmployeePHdGuideRecognisationDetailsDTO.ConnectionString = _connectioString;

                        model.EmployeePHdGuideRecognisationDetailsDTO.ID = model.ID;
                        model.EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID = model.EmployeePHdGuideStudentsDetailsID;
                        model.EmployeePHdGuideRecognisationDetailsDTO.StudentName = model.StudentName;
                        model.EmployeePHdGuideRecognisationDetailsDTO.Synopsis = model.Synopsis; ;
                        model.EmployeePHdGuideRecognisationDetailsDTO.PersuingFromDate = model.PersuingFromDate;
                        model.EmployeePHdGuideRecognisationDetailsDTO.PersuingUptoDate = model.PersuingUptoDate;
                        model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalStatus = model.ApprovalStatus;
                        model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalDate = model.ApprovalDate; ;
                        model.EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsRemarks = !string.IsNullOrEmpty(model.EmployeePHdGuideStudentsDetailsRemarks) ? model.EmployeePHdGuideStudentsDetailsRemarks : string.Empty; 
                        model.EmployeePHdGuideRecognisationDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        if (model.EmployeePHdGuideStudentsDetailsID == 0)
                        {
                            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _employeePHdGuideRecognisationDetailsServiceAcess.InsertEmployeePHdGuideStudentsDetails(model.EmployeePHdGuideRecognisationDetailsDTO);
                            model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);                            
                        }
                        else if (model.EmployeePHdGuideStudentsDetailsID > 0)
                        {
                            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _employeePHdGuideRecognisationDetailsServiceAcess.InsertEmployeePHdGuideStudentsDetails(model.EmployeePHdGuideRecognisationDetailsDTO);
                            model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);                            
                        }
                        return Json(model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //public ActionResult Delete(int EmpStuPhdDetID)
        //{
        //    try
        //    {
        //        EmployeePHdGuideRecognisationDetailsViewModel model = new EmployeePHdGuideRecognisationDetailsViewModel();
        //        model.EmployeePHdGuideRecognisationDetailsDTO = new EmployeePHdGuideRecognisationDetails();
        //        model.EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID = EmpStuPhdDetID;
        //        return PartialView("/Views/Employee/EmployeePHdGuideRecognisationDetails/Delete.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeePHdGuideRecognisationDetailsViewModel model)
        //{
        //    try
        //    {
        //        if (model.EmployeePHdGuideStudentsDetailsID > 0)
        //        {
        //            EmployeePHdGuideRecognisationDetails EmployeePHdGuideRecognisationDetailsDTO = new EmployeePHdGuideRecognisationDetails();
        //            EmployeePHdGuideRecognisationDetailsDTO.ConnectionString = _connectioString;
        //            EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID = model.EmployeePHdGuideStudentsDetailsID;
        //            EmployeePHdGuideRecognisationDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _employeePHdGuideRecognisationDetailsServiceAcess.DeleteEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetailsDTO);
        //            model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            return Json(model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EmployeePHdGuideRecognisationDetailsViewModel model = new EmployeePHdGuideRecognisationDetailsViewModel();
            try
            {
                if (ID > 0)
                {
                    EmployeePHdGuideRecognisationDetails EmployeePHdGuideRecognisationDetailsDTO = new EmployeePHdGuideRecognisationDetails();
                    EmployeePHdGuideRecognisationDetailsDTO.ConnectionString = _connectioString;
                    EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID = ID;
                    EmployeePHdGuideRecognisationDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _employeePHdGuideRecognisationDetailsServiceAcess.DeleteEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetailsDTO);
                    model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.EmployeePHdGuideRecognisationDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Method
        #region Methods
        public IEnumerable<EmployeePHdGuideRecognisationDetailsViewModel> GetEmployeePHdGuideStudentsDetails(int ID,out int TotalRecords)
        {
            EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest = new EmployeePHdGuideRecognisationDetailsSearchRequest();
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
                    searchRequest.ID = ID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.ID = ID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.ID = ID;
            }
            List<EmployeePHdGuideRecognisationDetailsViewModel> listEmployeePHdGuideRecognisationDetailsViewModel = new List<EmployeePHdGuideRecognisationDetailsViewModel>();
            List<EmployeePHdGuideRecognisationDetails> listEmployeePHdGuideRecognisationDetails = new List<EmployeePHdGuideRecognisationDetails>();
            IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> baseEntityCollectionResponse = _employeePHdGuideRecognisationDetailsServiceAcess.GetBySearchEmployeePHdGuideStudentsDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeePHdGuideRecognisationDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeePHdGuideRecognisationDetails item in listEmployeePHdGuideRecognisationDetails)
                    {
                        EmployeePHdGuideRecognisationDetailsViewModel EmployeePHdGuideRecognisationDetailsViewModel = new EmployeePHdGuideRecognisationDetailsViewModel();
                        EmployeePHdGuideRecognisationDetailsViewModel.EmployeePHdGuideRecognisationDetailsDTO = item;
                        listEmployeePHdGuideRecognisationDetailsViewModel.Add(EmployeePHdGuideRecognisationDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeePHdGuideRecognisationDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int ID, int EmployeeID)
        {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<EmployeePHdGuideRecognisationDetailsViewModel> filteredEmployeePHdGuideStudentsDetails;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "StudentName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "StudentName Like '%" + param.sSearch + "%' or PersuingFromDate Like '%" + param.sSearch + "%' or PersuingUptoDate Like'%" + param.sSearch + "%'  or ApprovalStatus  Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "PersuingFromDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "StudentName Like '%" + param.sSearch + "%' or PersuingFromDate Like '%" + param.sSearch + "%' or PersuingUptoDate Like'%" + param.sSearch + "%'  or ApprovalStatus Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "PersuingUptoDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "StudentName Like '%" + param.sSearch + "%' or PersuingFromDate Like '%" + param.sSearch + "%' or PersuingUptoDate Like'%" + param.sSearch + "%'  or ApprovalStatus Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "ApprovalStatus";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "StudentName Like '%" + param.sSearch + "%' or PersuingFromDate Like '%" + param.sSearch + "%' or PersuingUptoDate Like'%" + param.sSearch + "%'  or ApprovalStatus Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredEmployeePHdGuideStudentsDetails = GetEmployeePHdGuideStudentsDetails(ID,out TotalRecords);
                var records = filteredEmployeePHdGuideStudentsDetails.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.StudentName), Convert.ToString(c.PersuingFromDate), Convert.ToString(c.PersuingUptoDate), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.EmployeePHdGuideStudentsDetailsID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}