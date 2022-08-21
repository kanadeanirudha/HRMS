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
    public class EmployeeExperienceController : BaseController
    {
        IEmployeeExperienceBA _EmployeeExperienceBA = null;
        IGeneralExperienceTypeMasterBA _generalExperienceTypeMasterBA = null;
       
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeExperienceController()
        {
             _EmployeeExperienceBA = new EmployeeExperienceBA();
             _generalExperienceTypeMasterBA = new GeneralExperienceTypeMasterBA();
        }

        // Controller Methods
        public ActionResult Index(int EmployeeID, string EmployeeDetailsType)
        {
            ViewBag.EmployeeID = EmployeeID;
            ViewBag.EmployeeDetailsType = EmployeeDetailsType;

            return View("/Views/Employee/EmployeePersonal/QualificationIndex.cshtml");

        }

        public ActionResult EmployeeExperienceList(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeeExperienceViewModel model = new EmployeeExperienceViewModel();
                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeePersonalDetails/EmployeeExperienceList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult EmployeeExperienceCreate(int EmployeeID)
        {
            EmployeeExperienceViewModel model = new EmployeeExperienceViewModel();
            model.EmployeeID = EmployeeID;

            //--------------------------------------For Experience Type list---------------------------------//
            List<GeneralExperienceTypeMaster> GeneralExperienceTypeMasterList = GetListGeneralExperienceTypeMaster();
            List<SelectListItem> GeneralExperienceTypeMaster = new List<SelectListItem>();
            foreach (GeneralExperienceTypeMaster item in GeneralExperienceTypeMasterList)
            {
                GeneralExperienceTypeMaster.Add(new SelectListItem { Text = item.ExperienceTypeDescription, Value = item.ID.ToString() });
            }
            ViewBag.GeneralExperienceTypeMaster = new SelectList(GeneralExperienceTypeMaster, "Value", "Text");


            //--------------------------------------For Job Status Type list---------------------------------//
            List<GeneralJobStatus> GeneralJobStatusList = GetListGeneralJobStatus();
            List<SelectListItem> GeneralJobStatus = new List<SelectListItem>();
            foreach (GeneralJobStatus item in GeneralJobStatusList)
            {
                GeneralJobStatus.Add(new SelectListItem { Text = item.JobStatusDescription, Value = item.ID.ToString() });
            }
            ViewBag.GeneralJobStatus = new SelectList(GeneralJobStatus, "Value", "Text");


            //--------------------------------------For Board University list---------------------------------//
            //List<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterList = GetListGeneralBoardUniversityMaster();
            //List<SelectListItem> GeneralBoardUniversityMaster = new List<SelectListItem>();
            //foreach (GeneralBoardUniversityMaster item in GeneralBoardUniversityMasterList)
            //{
            //    GeneralBoardUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
            //}
            //ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text");

            //--------------------------------------For University Approval type list---------------------------------//
            List<SelectListItem> EmployeeServiceDetails_UniversityApprovalType = new List<SelectListItem>();
            // ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
            List<SelectListItem> li_EmpolyeeServiceDetail_UniversityApprovalType = new List<SelectListItem>();         
            li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "Temporary" });
            li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "Permanent" });
            ViewData["UniversityApprovalType"] = li_EmpolyeeServiceDetail_UniversityApprovalType;
                       
            
            return PartialView("~/Views/Employee/EmployeePersonalDetails/EmployeeExperienceCreate.cshtml", model);
        }

        [HttpPost]
        public ActionResult EmployeeExperienceCreate(EmployeeExperienceViewModel EmployeeExperienceViewModel)
        {
            try
            {
                EmployeeExperienceViewModel.EmployeeExperienceDTO.EmployeeID = EmployeeExperienceViewModel.EmployeeID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.PreviousOrganisationName = EmployeeExperienceViewModel.PreviousOrganisationName;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.PreviousOrganisationAddress = EmployeeExperienceViewModel.PreviousOrganisationAddress;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ExperienceFromYear = EmployeeExperienceViewModel.ExperienceFromYear;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ExperienceToYear = EmployeeExperienceViewModel.ExperienceToYear;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.Designation = EmployeeExperienceViewModel.Designation;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.GeneralExperienceTypeMasterID = EmployeeExperienceViewModel.GeneralExperienceTypeMasterID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.GeneralJobStatusID = EmployeeExperienceViewModel.GeneralJobStatusID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.NatureOfAppointment = EmployeeExperienceViewModel.NatureOfAppointment;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.LastPayDrawnPayScale = EmployeeExperienceViewModel.LastPayDrawnPayScale;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.AppointmentOrderDate = EmployeeExperienceViewModel.AppointmentOrderDate;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.AppointmentOrderNumber = EmployeeExperienceViewModel.AppointmentOrderNumber;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.GeneralBoardUniversityID = EmployeeExperienceViewModel.GeneralBoardUniversityID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.UniversityApprovalType = EmployeeExperienceViewModel.UniversityApprovalType;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.UniversityApprovalDate = EmployeeExperienceViewModel.UniversityApprovalDate;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.UniversityApprovalNumber = EmployeeExperienceViewModel.UniversityApprovalNumber;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.YearOfApproval = EmployeeExperienceViewModel.YearOfApproval;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.MonthOfApproval = EmployeeExperienceViewModel.MonthOfApproval;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.SubjectForApproval = EmployeeExperienceViewModel.SubjectForApproval;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.Remarks = EmployeeExperienceViewModel.Remarks;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.IsActive = true;  
                EmployeeExperienceViewModel.EmployeeExperienceDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ID = EmployeeExperienceViewModel.ID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeeExperience> response = _EmployeeExperienceBA.InsertEmployeeExperience(EmployeeExperienceViewModel.EmployeeExperienceDTO);
                EmployeeExperienceViewModel.EmployeeExperienceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(EmployeeExperienceViewModel.EmployeeExperienceDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + EmployeeExperienceViewModel);
        }

        [HttpGet]
        public ActionResult EmployeeExperienceEdit(int ID, string Mode)
        {
            //--------------------------------------For Experience Type list---------------------------------//
            List<GeneralExperienceTypeMaster> GeneralExperienceTypeMasterList = GetListGeneralExperienceTypeMaster();
            List<SelectListItem> GeneralExperienceTypeMaster = new List<SelectListItem>();
            foreach (GeneralExperienceTypeMaster item in GeneralExperienceTypeMasterList)
            {
                GeneralExperienceTypeMaster.Add(new SelectListItem { Text = item.ExperienceTypeDescription, Value = item.ID.ToString() });
            }

            //--------------------------------------For Job Status Type list---------------------------------//
            List<GeneralJobStatus> GeneralJobStatusList = GetListGeneralJobStatus();
            List<SelectListItem> GeneralJobStatus = new List<SelectListItem>();
            foreach (GeneralJobStatus item in GeneralJobStatusList)
            {
                GeneralJobStatus.Add(new SelectListItem { Text = item.JobStatusDescription, Value = item.ID.ToString() });
            }

            //--------------------------------------For Board University list---------------------------------//
            //List<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterList = GetListGeneralBoardUniversityMaster();
            //List<SelectListItem> GeneralBoardUniversityMaster = new List<SelectListItem>();
            //foreach (GeneralBoardUniversityMaster item in GeneralBoardUniversityMasterList)
            //{
            //    GeneralBoardUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
            //}          

            //--------------------------------------For University Approval type list---------------------------------//
            List<SelectListItem> EmployeeServiceDetails_UniversityApprovalType = new List<SelectListItem>();
            // ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
            List<SelectListItem> li_EmpolyeeServiceDetail_UniversityApprovalType = new List<SelectListItem>();
            li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
            li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "Temporary" });
            li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "Permanent" });
         
                        

            EmployeeExperienceViewModel model = new EmployeeExperienceViewModel();
            EmployeeExperience EmployeeExperienceDTO = new EmployeeExperience();
            model.EmployeeExperienceDTO.ConnectionString = _connectioString;
            model.EmployeeExperienceDTO.ID = ID;
            IBaseEntityResponse<EmployeeExperience> response = _EmployeeExperienceBA.SelectByID(model.EmployeeExperienceDTO);
            if (response.Entity != null)
            {
                model.ExperienceID = response.Entity.ID;
                model.EmployeeID = response.Entity.EmployeeID;
                model.ExperienceFromYear = response.Entity.ExperienceFromYear;
                model.ExperienceToYear = response.Entity.ExperienceToYear;
                model.ExperienceInMonth = response.Entity.ExperienceInMonth;
                model.PreviousOrganisationName = response.Entity.PreviousOrganisationName;
                model.PreviousOrganisationAddress = response.Entity.PreviousOrganisationAddress;
                model.Designation = response.Entity.Designation;
                model.Remarks = response.Entity.Remarks;
                model.GeneralExperienceTypeMasterID = response.Entity.GeneralExperienceTypeMasterID;
                model.LastPayDrawnPayScale = response.Entity.LastPayDrawnPayScale;
                model.NatureOfAppointment = response.Entity.NatureOfAppointment;
                model.GeneralJobStatusID = response.Entity.GeneralJobStatusID;
                model.AppointmentOrderNumber = response.Entity.AppointmentOrderNumber;
                model.AppointmentOrderDate = response.Entity.AppointmentOrderDate;
                model.UniversityApprovalNumber = response.Entity.UniversityApprovalNumber;
                model.UniversityApprovalDate = response.Entity.UniversityApprovalDate;
                model.GeneralBoardUniversityID = response.Entity.GeneralBoardUniversityID;
                model.SubjectForApproval = response.Entity.SubjectForApproval;
                model.UniversityApprovalType = response.Entity.UniversityApprovalType;
                model.MonthOfApproval = response.Entity.MonthOfApproval;
                model.YearOfApproval = response.Entity.YearOfApproval;
              

               
            }
            ViewBag.GeneralExperienceTypeMaster = new SelectList(GeneralExperienceTypeMaster, "Value", "Text", response.Entity.GeneralExperienceTypeMasterID);
            ViewBag.GeneralJobStatus = new SelectList(GeneralJobStatus, "Value", "Text", response.Entity.GeneralJobStatusID);
            //ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text", response.Entity.GeneralBoardUniversityID);
            ViewData["UniversityApprovalType"] =new SelectList (li_EmpolyeeServiceDetail_UniversityApprovalType, "Value","Text",response.Entity.UniversityApprovalType);
            return PartialView("~/Views/Employee/EmployeePersonalDetails/EmployeeExperienceEdit.cshtml", model);
        }

        [HttpPost]
        public ActionResult EmployeeExperienceEdit(EmployeeExperienceViewModel EmployeeExperienceViewModel)
        {
            try
            {
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ID = EmployeeExperienceViewModel.ID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.EmployeeID = EmployeeExperienceViewModel.EmployeeID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.PreviousOrganisationName = EmployeeExperienceViewModel.PreviousOrganisationName;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.PreviousOrganisationAddress = EmployeeExperienceViewModel.PreviousOrganisationAddress;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ExperienceFromYear = EmployeeExperienceViewModel.ExperienceFromYear;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ExperienceToYear = EmployeeExperienceViewModel.ExperienceToYear;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ExperienceInMonth = EmployeeExperienceViewModel.ExperienceInMonth;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.Designation = EmployeeExperienceViewModel.Designation;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.GeneralExperienceTypeMasterID = EmployeeExperienceViewModel.GeneralExperienceTypeMasterID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.GeneralJobStatusID = EmployeeExperienceViewModel.GeneralJobStatusID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.NatureOfAppointment = EmployeeExperienceViewModel.NatureOfAppointment;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.LastPayDrawnPayScale = EmployeeExperienceViewModel.LastPayDrawnPayScale;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.AppointmentOrderDate = EmployeeExperienceViewModel.AppointmentOrderDate;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.AppointmentOrderNumber = EmployeeExperienceViewModel.AppointmentOrderNumber;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.GeneralBoardUniversityID = EmployeeExperienceViewModel.GeneralBoardUniversityID;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.UniversityApprovalType = EmployeeExperienceViewModel.UniversityApprovalType;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.UniversityApprovalDate = EmployeeExperienceViewModel.UniversityApprovalDate;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.UniversityApprovalNumber = EmployeeExperienceViewModel.UniversityApprovalNumber;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.YearOfApproval = EmployeeExperienceViewModel.YearOfApproval;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.MonthOfApproval = EmployeeExperienceViewModel.MonthOfApproval;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.SubjectForApproval = EmployeeExperienceViewModel.SubjectForApproval;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.Remarks = EmployeeExperienceViewModel.Remarks;
                EmployeeExperienceViewModel.EmployeeExperienceDTO.IsActive = true;  
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                EmployeeExperienceViewModel.EmployeeExperienceDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeeExperience> response = _EmployeeExperienceBA.UpdateEmployeeExperience(EmployeeExperienceViewModel.EmployeeExperienceDTO);
                EmployeeExperienceViewModel.EmployeeExperienceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(EmployeeExperienceViewModel.EmployeeExperienceDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + EmployeeExperienceViewModel);
        }


        public ActionResult EmployeePersonalList(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeeExperienceViewModel model = new EmployeeExperienceViewModel();
                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeeExperience/PersonalList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        // Non-Action Method
        #region Methods   

        public IEnumerable<EmployeeExperienceViewModel> GetEmployeeExperience(int EmployeeID, out int TotalRecords)
        {
            EmployeeExperienceSearchRequest searchRequest = new EmployeeExperienceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = EmployeeID;
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
            List<EmployeeExperienceViewModel> listEmployeeExperienceViewModel = new List<EmployeeExperienceViewModel>();
            List<EmployeeExperience> listEmployeeExperience = new List<EmployeeExperience>();
            IBaseEntityCollectionResponse<EmployeeExperience> baseEntityCollectionResponse = _EmployeeExperienceBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeExperience = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeExperience item in listEmployeeExperience)
                    {
                        EmployeeExperienceViewModel EmployeeExperienceViewModel = new EmployeeExperienceViewModel();
                        EmployeeExperienceViewModel.EmployeeExperienceDTO = item;
                        listEmployeeExperienceViewModel.Add(EmployeeExperienceViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeExperienceViewModel;
        }

        protected List<GeneralExperienceTypeMaster> GetListGeneralExperienceTypeMaster()
        {
            GeneralExperienceTypeMasterSearchRequest searchRequest = new GeneralExperienceTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralExperienceTypeMaster> listGeneralExperienceTypeMaster = new List<GeneralExperienceTypeMaster>();
            IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> baseEntityCollectionResponse = _generalExperienceTypeMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralExperienceTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralExperienceTypeMaster;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandlerEmployeeExperience(JQueryDataTableParamModel param, int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeExperienceViewModel> filteredEmployeeExperience;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "PreviousOrganisationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PreviousOrganisationName Like '%" + param.sSearch + "%' or Designation Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "PreviousOrganisationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PreviousOrganisationName Like '%" + param.sSearch + "%' or Designation Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeExperience = GetEmployeeExperience(EmployeeID, out TotalRecords);
            var records = filteredEmployeeExperience.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.PreviousOrganisationName), Convert.ToString(c.Designation), Convert.ToString(c.GeneralExperienceType), Convert.ToString(c.ExperienceInMonth), Convert.ToString(c.GeneralJobStatus), Convert.ToString(c.ID), Convert.ToString(c.EmployeeID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}
