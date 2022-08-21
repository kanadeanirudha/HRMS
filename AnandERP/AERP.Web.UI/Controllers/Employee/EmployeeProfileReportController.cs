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
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;

namespace AERP.Web.UI.Controllers.Employee
{
    public class EmployeeProfileReportController : BaseController
    {
        IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
        //IEmployeeLanguageDetailsBA _employeeLanguageDetailsBA = null;
        IEmployeePictureDetailsBA _employeePictureDetailsBA = null;
        //IEmployeeServiceDetailsBA _employeeServiceDetailsBA = null;
        //IEmployeeQualificationBA _EmployeeQualificationBA = null;
        //IEmployeeExperienceBA _EmployeeExperienceBA = null;
        //IEmployeeCourseSubjectTaughtBA _EmployeeCourseSubjectTaughtBA = null;
        //IEmployeeElectionNomineeBodyBA _EmployeeElectionNomineeBodyBA = null;
        //IEmployeePaperPresentBA _EmployeePaperPresentBA = null;
        //IEmployeePHdGuideRecognisationDetailsBA _EmployeePHdGuideRecognisationDetailsBA = null;
        //IEmployeeOtherCollegeSpecialLectureDetailsBA _EmployeeOtherCollegeSpecialLectureDetailsBA = null;
        //IEmployeeProjectWorksMasterBA _EmployeeProjectWorksMasterBA = null;
        //IEmployeeAssociatesProfessionalBodiesBA _EmployeeAssociatesProfessionalBodiesBA = null;
        //IEmployeePatentReceivedDetailsBA _EmployeePatentReceivedDetailsBA = null;
        //IEmployeePrizesWonDetailsBA _EmployeePrizesWonDetailsBA = null;
        //IEmployeeConsultancyMasterBA _EmployeeConsultancyMasterBA = null;
        //IEmployeeSpecializationResearchAreaDetailsBA _EmployeeSpecializationResearchAreaDetailsBA = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        //
        // GET: /EmployeeProfileReport/

        public EmployeeProfileReportController()
        {
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();
            _employeePictureDetailsBA = new EmployeePictureDetailsBA();
            //_employeeLanguageDetailsBA = new EmployeeLanguageDetailsBA();
            //_employeeServiceDetailsBA = new EmployeeServiceDetailsBA();
            //_EmployeeQualificationBA = new EmployeeQualificationBA();
            //_EmployeeExperienceBA = new EmployeeExperienceBA();
            //_EmployeeCourseSubjectTaughtBA = new EmployeeCourseSubjectTaughtBA();
            //_EmployeeElectionNomineeBodyBA = new EmployeeElectionNomineeBodyBA();
            //_EmployeePaperPresentBA = new EmployeePaperPresentBA();
            //_EmployeePHdGuideRecognisationDetailsBA = new EmployeePHdGuideRecognisationDetailsBA();
            //_EmployeeOtherCollegeSpecialLectureDetailsBA = new EmployeeOtherCollegeSpecialLectureDetailsBA();
            //_EmployeeProjectWorksMasterBA = new EmployeeProjectWorksMasterBA();
            //_EmployeeAssociatesProfessionalBodiesBA = new EmployeeAssociatesProfessionalBodiesBA();
            //_EmployeePatentReceivedDetailsBA = new EmployeePatentReceivedDetailsBA();
            //_EmployeePrizesWonDetailsBA = new EmployeePrizesWonDetailsBA();
            //_EmployeeConsultancyMasterBA = new EmployeeConsultancyMasterBA();
            //_EmployeeSpecializationResearchAreaDetailsBA = new EmployeeSpecializationResearchAreaDetailsBA();
        }


        public ActionResult ProfileReport(string EmployeeID)
        {
            ViewBag.EmployeeID = Convert.ToInt32(Session["CurrentEmployeeID"]);
            ViewBag.EmpID = EmployeeID;
            return View("/Views/Employee/EmployeeProfileReport/ProfileReport.cshtml");
        }

        public ActionResult ProfileReportOtherHeader()
        {

            //  Session["CurrentEmployeeID"] = Convert.ToString(EmployeeID);
            //--------------------------------------For Centre Code list---------------------------------//
            List<OrganisationStudyCentreMaster> _organisationStudyCentreMaster = GetListOrgStudyCentreMaster();
            List<SelectListItem> organisationStudyCentreMasterList = new List<SelectListItem>();
            foreach (OrganisationStudyCentreMaster item in _organisationStudyCentreMaster)
            {
                organisationStudyCentreMasterList.Add(new SelectListItem { Text = item.CentreName, Value = item.CentreCode.ToString() });
            }
            ViewBag.organisationStudyCentreMasterList = new SelectList(organisationStudyCentreMasterList, "Value", "Text");
            ViewData["CentreCodeList"] = new SelectList(organisationStudyCentreMasterList, "Value", "Text");
            //--------------------------------------For Department list---------------------------------//
            //List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster("1");
            List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
            //foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
            //{
            //    organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
            //}
            ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text");
            ViewData["DepartmentList"] = new SelectList(organisationDepartmentMasterList, "Value", "Text");
            //--------------------------------------For Employee list---------------------------------//
            //List<EmpEmployeeeMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster("1");
            List<SelectListItem> empEmployeeeMasterList = new List<SelectListItem>();
            //foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
            //{
            //    organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
            //}
            ViewBag.empEmployeeeMasterList = new SelectList(empEmployeeeMasterList, "Value", "Text");
            ViewData["EmployeeList"] = new SelectList(empEmployeeeMasterList, "Value", "Text");

            ViewBag.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            return View("/Views/Employee/EmployeeProfileReport/ProfileReportOtherHeader.cshtml");
        }

        public ActionResult ProfileReportOther(string EmployeeID)
        {
            Session["CurrentEmployeeID"] = Convert.ToString(EmployeeID);

            ViewBag.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            return View("/Views/Employee/EmployeeProfileReport/ProfileReportOther.cshtml");
        }

        public ActionResult Index(string EmployeeID)
        {

            return View("/Views/Employee/EmployeeProfileReport/Index.cshtml");
        }

        [HttpGet]
        public ActionResult _EmployeePictureDetails(int EmployeeID)
        {
            try
            {
                EmployeePictureDetailsViewModel employeePictureDetailsViewModel = new EmployeePictureDetailsViewModel();
                EmployeePictureDetails EmployeePictureDetailsDTO = new EmployeePictureDetails();
                employeePictureDetailsViewModel.EmployeePictureDetailsDTO.EmployeeID = EmployeeID;
                employeePictureDetailsViewModel.EmployeePictureDetailsDTO.ConnectionString = _connectioString;
                employeePictureDetailsViewModel.EmployeePictureDetailsDTO.EmployeeID = EmployeeID;
                IBaseEntityResponse<EmployeePictureDetails> response = _employeePictureDetailsBA.SelectByID(employeePictureDetailsViewModel.EmployeePictureDetailsDTO);
                if (response.Entity != null)
                {
                    employeePictureDetailsViewModel.EmployeePicture = response.Entity.EmployeePicture;
                    employeePictureDetailsViewModel.EmployeePicType = response.Entity.EmployeePicType;
                    employeePictureDetailsViewModel.EmployeePicFilename = response.Entity.EmployeePicFilename;
                    employeePictureDetailsViewModel.EmployeePicFileWidth = response.Entity.EmployeePicFileWidth;
                    employeePictureDetailsViewModel.EmployeePicFileHeight = response.Entity.EmployeePicFileHeight;
                    employeePictureDetailsViewModel.EmployeePicFileSize = response.Entity.EmployeePicFileSize;

                }
                return View("/Views/Employee/EmployeeProfileReport/_EmployeeProfilePicture.cshtml", employeePictureDetailsViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult PersonalInformation(int EmployeeID)
        {
            try
            {
                EmpEmployeeMasterViewModel empEmployeeMastermodel = new EmpEmployeeMasterViewModel();

                //For Name Title
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");

                //For MaritalStatus
                List<SelectListItem> EmpEmployeeMaster_EmployeeMaritalStatus = new List<SelectListItem>();
                ViewBag.EmpEmployeeMaster_EmployeeMaritalStatus = new SelectList(EmpEmployeeMaster_EmployeeMaritalStatus, "Value", "Text");
                List<SelectListItem> li_EmpEmployeeMaster_EmployeeMaritalStatus = new List<SelectListItem>();
                li_EmpEmployeeMaster_EmployeeMaritalStatus.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectMaritalStatus, });
                li_EmpEmployeeMaster_EmployeeMaritalStatus.Add(new SelectListItem { Text = Resources.DisplayName_UNMARRIED, Value = "U" });
                li_EmpEmployeeMaster_EmployeeMaritalStatus.Add(new SelectListItem { Text = Resources.DisplayName_MARRIED, Value = "M" });
                li_EmpEmployeeMaster_EmployeeMaritalStatus.Add(new SelectListItem { Text = Resources.DisplayName_DIVORCED, Value = "D" });
                ViewData["EmployeeMaritalStatus"] = li_EmpEmployeeMaster_EmployeeMaritalStatus;

                //List<SelectListItem> EmpEmployeeMaster_YesNo = new List<SelectListItem>();
                //ViewBag.EmpEmployeeMaster_IsNameChagedBefore = new SelectList(EmpEmployeeMaster_YesNo, "Value", "Text");
                //List<SelectListItem> li_EmpEmployeeMaster_YesNo = new List<SelectListItem>();
                //li_EmpEmployeeMaster_YesNo.Add(new SelectListItem { Text = "-- Select-- ", });
                //li_EmpEmployeeMaster_YesNo.Add(new SelectListItem { Text = "NO", Value = "N" });
                //li_EmpEmployeeMaster_YesNo.Add(new SelectListItem { Text = "YES", Value = "Y" });               
                //ViewData["YesNo"] = li_EmpEmployeeMaster_YesNo;

                //For Nationality
                //For Nationality

                List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
                List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in generalNationalityMasterList)
                {
                    generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");


                //model.ID = ID;
                TempData["EmployeeID"] = EmployeeID;
                ViewBag.EmployeeID = EmployeeID;
                Session["CurrentEmployeeID"] = Convert.ToString(EmployeeID);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = EmployeeID;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.SelectByID(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                empEmployeeMastermodel.EmployeeFullName = response.Entity.EmployeeFirstName + " " + response.Entity.EmployeeLastName;
                Session["EmployeeFullName"] = Convert.ToString(empEmployeeMastermodel.EmployeeFullName);

                empEmployeeMastermodel.EmployeeFirstName = response.Entity.EmployeeFirstName;
                empEmployeeMastermodel.EmployeeMiddleName = response.Entity.EmployeeMiddleName;
                empEmployeeMastermodel.EmployeeLastName = response.Entity.EmployeeLastName;
                empEmployeeMastermodel.ID = response.Entity.ID;
                empEmployeeMastermodel.NameTitle = response.Entity.NameTitle;
                empEmployeeMastermodel.EmployeeCode = response.Entity.EmployeeCode;
                empEmployeeMastermodel.EmailID = response.Entity.EmailID;
                empEmployeeMastermodel.OtherEmailID = response.Entity.OtherEmailID;
                empEmployeeMastermodel.Birthdate = response.Entity.Birthdate;
                empEmployeeMastermodel.NickName = response.Entity.NickName;
                empEmployeeMastermodel.MarritalStaus = response.Entity.MarritalStaus;
                empEmployeeMastermodel.IsNameChangedBefore = response.Entity.IsNameChangedBefore;
                empEmployeeMastermodel.PriorFirstName = response.Entity.PriorFirstName;
                empEmployeeMastermodel.PriorMiddleName = response.Entity.PriorMiddleName;
                empEmployeeMastermodel.PriorLastName = response.Entity.PriorLastName;
                empEmployeeMastermodel.EmployeeNameAsPerTC = response.Entity.EmployeeNameAsPerTC;
                empEmployeeMastermodel.NationalityID = response.Entity.NationalityID;
                empEmployeeMastermodel.Nationality = response.Entity.Nationality;
                empEmployeeMastermodel.EthanicRaceCode = response.Entity.EthanicRaceCode;
                empEmployeeMastermodel.IsEmployeeSmoker = response.Entity.IsEmployeeSmoker;
                empEmployeeMastermodel.CentreCode = response.Entity.CentreCode;
                empEmployeeMastermodel.DepartmentID = response.Entity.DepartmentID;
                empEmployeeMastermodel.DepartmentName = response.Entity.DepartmentName;
                empEmployeeMastermodel.EmployeeDesignationMasterID = response.Entity.EmployeeDesignationMasterID;
                empEmployeeMastermodel.EmployeeDesignation = response.Entity.EmployeeDesignation;
                empEmployeeMastermodel.JobProfileID = response.Entity.JobProfileID;
                empEmployeeMastermodel.BankACNumber = response.Entity.BankACNumber;
                empEmployeeMastermodel.PaymentMode = response.Entity.PaymentMode;
                //  empEmployeeMastermodel.DepartmentID = response.Entity.DepartmentID;
                //  empEmployeeMastermodel.EmployeeDesignationMasterID = response.Entity.EmployeeDesignationMasterID;
                empEmployeeMastermodel.SalaryGradeCode = response.Entity.SalaryGradeCode;
                empEmployeeMastermodel.JobProfileID = response.Entity.JobProfileID;
                empEmployeeMastermodel.JobProfileDescription = response.Entity.JobProfileDescription;
                empEmployeeMastermodel.JobStatusID = response.Entity.JobStatusID;
                empEmployeeMastermodel.JobStatus = response.Entity.JobStatus;
                empEmployeeMastermodel.JobStatusDescription = response.Entity.JobStatusDescription;
                empEmployeeMastermodel.JoiningDate = response.Entity.JoiningDate;
                empEmployeeMastermodel.AppointmentApprovalDate = response.Entity.AppointmentApprovalDate;
                empEmployeeMastermodel.ReasonOfLeaving = response.Entity.ReasonOfLeaving;
                empEmployeeMastermodel.IsLeave = response.Entity.IsLeave;
                empEmployeeMastermodel.DateOfLeaving = response.Entity.DateOfLeaving;
                empEmployeeMastermodel.DateOfRetirment = response.Entity.DateOfRetirment;
                empEmployeeMastermodel.TerminationDate = response.Entity.TerminationDate;
                empEmployeeMastermodel.EmployeeShiftApplicableMasterID = response.Entity.EmployeeShiftApplicableMasterID;
                empEmployeeMastermodel.PayScaleMstID = response.Entity.PayScaleMstID;
                empEmployeeMastermodel.BasicSalary = response.Entity.BasicSalary;
                empEmployeeMastermodel.ProvidentFundNumber = response.Entity.ProvidentFundNumber;
                empEmployeeMastermodel.ProvidentFundApplicableDate = response.Entity.ProvidentFundApplicableDate;
                empEmployeeMastermodel.PanNumber = response.Entity.PanNumber;
                empEmployeeMastermodel.BankACNumber = response.Entity.BankACNumber;
                empEmployeeMastermodel.AdharCardNumber = response.Entity.AdharCardNumber;
                empEmployeeMastermodel.SSNNumber = response.Entity.SSNNumber;
                empEmployeeMastermodel.SINNumber = response.Entity.SINNumber;
                empEmployeeMastermodel.DrivingLicenceNumber = response.Entity.DrivingLicenceNumber;
                empEmployeeMastermodel.DrivingLicenceExpireDate = response.Entity.DrivingLicenceExpireDate;
                empEmployeeMastermodel.ESINumber = response.Entity.ESINumber;


                return View("/Views/Employee/EmployeeProfileReport/PersonalInformation.cshtml", empEmployeeMastermodel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //[HttpGet]
        //public ActionResult _EmployeeQualificationDetails(int EmployeeID)
        //{
        //    EmployeeQualificationViewModel model = new EmployeeQualificationViewModel();
        //    model.EmployeeQualificationDTO.EmployeeID = EmployeeID;

        //    List<EmployeeQualification> employeeQualificationDetailsList = GetEmployeeQualification(EmployeeID);
        //    if (employeeQualificationDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeQualificationDetails = employeeQualificationDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }

        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeQualificationDetails.cshtml", model);
        //}

        //protected List<EmployeeQualification> GetEmployeeQualification(int EmployeeID)
        //{
        //    EmployeeQualificationSearchRequest searchRequest = new EmployeeQualificationSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    //  int SelectedEducationTypeID = 0;
        //    // bool isValid = EmployeeID;
        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "YearOfPassing";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "desc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeQualification> listEmployeeQualification = new List<EmployeeQualification>();
        //    IBaseEntityCollectionResponse<EmployeeQualification> baseEntityCollectionResponse = _EmployeeQualificationBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeQualification = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeQualification;
        //}

        //For Employee Specialization Research Area Details
        //[HttpGet]
        //public ActionResult _EmployeeSpecializationResearchAreaDetails(int EmployeeID)
        //{
        //    EmployeeSpecializationResearchAreaDetailsViewModel model = new EmployeeSpecializationResearchAreaDetailsViewModel();
        //    model.EmployeeSpecializationResearchAreaDetailsDTO.EmployeeID = EmployeeID;

        //    List<EmployeeSpecializationResearchAreaDetails> employeeSpecializationResearchAreaDetailsList = GetEmployeeSpecializationResearchAreaDetails(EmployeeID);
        //    if (employeeSpecializationResearchAreaDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeSpecializationResearchAreaDetails = employeeSpecializationResearchAreaDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeSpecializationResearchAreaDetails.cshtml", model);
        //}

        //protected List<EmployeeSpecializationResearchAreaDetails> GetEmployeeSpecializationResearchAreaDetails(int EmployeeID)
        //{
        //    EmployeeSpecializationResearchAreaDetailsSearchRequest searchRequest = new EmployeeSpecializationResearchAreaDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    //  int SelectedEducationTypeID = 0;
        //    // bool isValid = EmployeeID;
        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "SpecializationField";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeSpecializationResearchAreaDetails> listEmployeeSpecializationResearchAreaDetails = new List<EmployeeSpecializationResearchAreaDetails>();
        //    IBaseEntityCollectionResponse<EmployeeSpecializationResearchAreaDetails> baseEntityCollectionResponse = _EmployeeSpecializationResearchAreaDetailsBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeSpecializationResearchAreaDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeSpecializationResearchAreaDetails;
        //}


        //[HttpGet]
        //public ActionResult _EmployeeExperienceDetails(int EmployeeID)
        //{
        //    EmployeeExperienceViewModel model = new EmployeeExperienceViewModel();
        //    model.EmployeeExperienceDTO.EmployeeID = EmployeeID;

        //    List<EmployeeExperience> employeeExperienceDetailsList = GetEmployeeExperience(EmployeeID);
        //    if (employeeExperienceDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeExperienceDetails = employeeExperienceDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeExperienceDetails.cshtml", model);
        //}

        //protected List<EmployeeExperience> GetEmployeeExperience(int EmployeeID)
        //{
        //    EmployeeExperienceSearchRequest searchRequest = new EmployeeExperienceSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "ID";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeExperience> listEmployeeExperience = new List<EmployeeExperience>();
        //    IBaseEntityCollectionResponse<EmployeeExperience> baseEntityCollectionResponse = _EmployeeExperienceBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeExperience = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeExperience;
        //}


        //For Course/Subject taught
        //[HttpGet]
        //public ActionResult _CourseSubjectTaughtDetails(int EmployeeID)
        //{
        //    EmployeeCourseSubjectTaughtViewModel model = new EmployeeCourseSubjectTaughtViewModel();
        //    model.EmployeeCourseSubjectTaughtDTO.EmployeeID = EmployeeID;

        //    List<EmployeeCourseSubjectTaught> employeeCourseSubjectTaughtDetailsList = GetEmployeeCourseSubjectTaught(EmployeeID);
        //    if (employeeCourseSubjectTaughtDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeCourseSubjectTaughtDetails = employeeCourseSubjectTaughtDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_CourseSubjectTaughtDetails.cshtml", model);
        //}

        //protected List<EmployeeCourseSubjectTaught> GetEmployeeCourseSubjectTaught(int EmployeeID)
        //{
        //    EmployeeCourseSubjectTaughtSearchRequest searchRequest = new EmployeeCourseSubjectTaughtSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "ID";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeCourseSubjectTaught> listEmployeeCourseSubjectTaught = new List<EmployeeCourseSubjectTaught>();
        //    IBaseEntityCollectionResponse<EmployeeCourseSubjectTaught> baseEntityCollectionResponse = _EmployeeCourseSubjectTaughtBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeCourseSubjectTaught = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeCourseSubjectTaught;
        //}

        //For Membership of Learned Society 
        //[HttpGet]
        //public ActionResult _EmployeeElectionNomineeBodyDetails(int EmployeeID)
        //{
        //    EmployeeElectionNomineeBodyViewModel model = new EmployeeElectionNomineeBodyViewModel();
        //    model.EmployeeElectionNomineeBodyDTO.EmployeeID = EmployeeID;

        //    List<EmployeeElectionNomineeBody> employeeElectionNomineeBodyDetailsList = GetEmployeeElectionNomineeBody(EmployeeID);
        //    if (employeeElectionNomineeBodyDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeElectionNomineeBodyDetails = employeeElectionNomineeBodyDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeElectionNomineeBodyDetails.cshtml", model);
        //}

        //protected List<EmployeeElectionNomineeBody> GetEmployeeElectionNomineeBody(int EmployeeID)
        //{
        //    EmployeeElectionNomineeBodySearchRequest searchRequest = new EmployeeElectionNomineeBodySearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "ID";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeElectionNomineeBody> listEmployeeElectionNomineeBody = new List<EmployeeElectionNomineeBody>();
        //    IBaseEntityCollectionResponse<EmployeeElectionNomineeBody> baseEntityCollectionResponse = _EmployeeElectionNomineeBodyBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeElectionNomineeBody = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeElectionNomineeBody;
        //}

        //For Conference/ Symposium /Journal Paper / Books Published
        //[HttpGet]
        //public ActionResult _EmployeePaperPresentDetails(int EmployeeID)
        //{
        //    EmployeePaperPresentViewModel model = new EmployeePaperPresentViewModel();
        //    model.EmployeePaperPresentDTO.EmployeeID = EmployeeID;

        //    List<EmployeePaperPresent> employeePaperPresentDetailsList = GetEmployeePaperPresent(EmployeeID);
        //    if (employeePaperPresentDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeePaperPresentDetails = employeePaperPresentDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeePaperPresentDetails.cshtml", model);
        //}

        //protected List<EmployeePaperPresent> GetEmployeePaperPresent(int EmployeeID)
        //{
        //    EmployeePaperPresentSearchRequest searchRequest = new EmployeePaperPresentSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "GeneralLevel,EmployeeYear";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeePaperPresent> listEmployeePaperPresent = new List<EmployeePaperPresent>();
        //    IBaseEntityCollectionResponse<EmployeePaperPresent> baseEntityCollectionResponse = _EmployeePaperPresentBA.GetAppliedDetails(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeePaperPresent = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeePaperPresent;
        //}

        //For Ph. D. Thesis Guidence  
        //public ActionResult _EmployeePHdGuideRecognisationDetails(int EmployeeID)
        //{
        //    try
        //    {

        //        EmployeePHdGuideRecognisationDetailsViewModel model = new EmployeePHdGuideRecognisationDetailsViewModel();
        //        //List<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterList = GetListGeneralBoardUniversityMaster();
        //        //List<SelectListItem> GeneralBoardUniversityMaster = new List<SelectListItem>();
        //        //foreach (GeneralBoardUniversityMaster item in GeneralBoardUniversityMasterList)
        //        //{
        //        //    GeneralBoardUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
        //        //}
        //        model.EmployeePHdGuideRecognisationDetailsDTO.ConnectionString = _connectioString;
        //        model.EmployeePHdGuideRecognisationDetailsDTO.EmployeeID = EmployeeID;
        //        IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> response = _EmployeePHdGuideRecognisationDetailsBA.SelectByID(model.EmployeePHdGuideRecognisationDetailsDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            ViewBag.Data = 1;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.ID = response.Entity.ID;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.EmployeeID = response.Entity.EmployeeID;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalSubjectName = response.Entity.ApprovalSubjectName;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalFromDate = response.Entity.ApprovalFromDate; ;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.ApprovalUptoDate = response.Entity.ApprovalUptoDate;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalNumber = response.Entity.UniversityApprovalNumber;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalDate = response.Entity.UniversityApprovalDate; ;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.NoOfCandidateCompletedPHd = response.Entity.NoOfCandidateCompletedPHd;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.NumberOfCandidateRegistered = response.Entity.NumberOfCandidateRegistered;
        //            model.EmployeePHdGuideRecognisationDetailsDTO.Remarks = response.Entity.Remarks;
        //            //ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text", response.Entity.GeneralBoardUniversityID);
        //            model.EmployeePHdGuideRecognisationDetailsDTO.GeneralBoardUniversityID = response.Entity.GeneralBoardUniversityID;
        //        }
        //        //else
        //        //{
        //        //    ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text");
        //        //}

        //        List<EmployeePHdGuideRecognisationDetails> employeePHdGuideRecognisationDetailsList = GetEmployeePHdGuideStudentsDetails(model.EmployeePHdGuideRecognisationDetailsDTO.ID);
        //        if (employeePHdGuideRecognisationDetailsList.Count > 0)
        //        {
        //            ViewBag.DataOfStudent = 1;
        //            ViewBag.ListEmployeePHdGuideRecognisationDetails = employeePHdGuideRecognisationDetailsList;
        //        }
        //        else
        //        {
        //            ViewBag.DataOfStudent = 0;
        //        }

        //        model.EmployeeID = EmployeeID;
        //        return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeePHdGuideRecognisationDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //protected List<EmployeePHdGuideRecognisationDetails> GetEmployeePHdGuideStudentsDetails(int ID)
        //{
        //    EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest = new EmployeePHdGuideRecognisationDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.ID = ID;
        //    searchRequest.SortBy = "ApprovalStatus";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 200;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeePHdGuideRecognisationDetails> listEmployeePHdGuideRecognisationDetails = new List<EmployeePHdGuideRecognisationDetails>();
        //    IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> baseEntityCollectionResponse = _EmployeePHdGuideRecognisationDetailsBA.GetBySearchEmployeePHdGuideStudentsDetails(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeePHdGuideRecognisationDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeePHdGuideRecognisationDetails;
        //}

        //For Invited Lectures-Other College Special Lecture Details 
        //[HttpGet]
        //public ActionResult _EmployeeOtherCollegeSpecialLectureDetails(int EmployeeID)
        //{
        //    EmployeeOtherCollegeSpecialLectureDetailsViewModel model = new EmployeeOtherCollegeSpecialLectureDetailsViewModel();
        //    model.EmployeeOtherCollegeSpecialLectureDetailsDTO.EmployeeID = EmployeeID;

        //    List<EmployeeOtherCollegeSpecialLectureDetails> employeeOtherCollegeSpecialLectureDetailsList = GetEmployeeOtherCollegeSpecialLectureDetails(EmployeeID);
        //    if (employeeOtherCollegeSpecialLectureDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeOtherCollegeSpecialLectureDetails = employeeOtherCollegeSpecialLectureDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeOtherCollegeSpecialLectureDetails.cshtml", model);
        //}

        //protected List<EmployeeOtherCollegeSpecialLectureDetails> GetEmployeeOtherCollegeSpecialLectureDetails(int EmployeeID)
        //{
        //    EmployeeOtherCollegeSpecialLectureDetailsSearchRequest searchRequest = new EmployeeOtherCollegeSpecialLectureDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "TopicOfLecture";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeOtherCollegeSpecialLectureDetails> listEmployeeOtherCollegeSpecialLectureDetails = new List<EmployeeOtherCollegeSpecialLectureDetails>();
        //    IBaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails> baseEntityCollectionResponse = _EmployeeOtherCollegeSpecialLectureDetailsBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeOtherCollegeSpecialLectureDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeOtherCollegeSpecialLectureDetails;
        //}



        //For Project Work Details 
        //[HttpGet]
        //public ActionResult _EmployeeProjectWorkDetails(int EmployeeID)
        //{
        //    EmployeeProjectWorksMasterViewModel model = new EmployeeProjectWorksMasterViewModel();
        //    model.EmployeeProjectWorksMasterDTO.EmployeeID = EmployeeID;
        //    model.EmployeeProjectWorksMasterDTO.EmployeeID = EmployeeID;
        //    model.EmployeeProjectWorksMasterDTO.ConnectionString = _connectioString;
        //    IBaseEntityResponse<EmployeeProjectWorksMaster> response = _EmployeeProjectWorksMasterBA.SelectEmployeeCentreCode(model.EmployeeProjectWorksMasterDTO);
        //    model.CentreCode = response.Entity != null ? response.Entity.CentreCode : string.Empty;
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeProjectWorksMaster> employeeProjectWorksMasterDetailsList = GetEmployeeProjectWorksMasterDetails(EmployeeID, model.CentreCode);
        //    if (employeeProjectWorksMasterDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeProjectWorksMasterDetails = employeeProjectWorksMasterDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeProjectWorkDetails.cshtml", model);
        //}

        //protected List<EmployeeProjectWorksMaster> GetEmployeeProjectWorksMasterDetails(int EmployeeID, string centreCode)
        //{
        //    EmployeeProjectWorksMasterSearchRequest searchRequest = new EmployeeProjectWorksMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.CentreCode = centreCode;
        //    searchRequest.SortBy = "ProjectStatus";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "desc";


        //    List<EmployeeProjectWorksMaster> listEmployeeProjectWorksMaster = new List<EmployeeProjectWorksMaster>();
        //    IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> baseEntityCollectionResponse = _EmployeeProjectWorksMasterBA.GetAppliedDetails(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeProjectWorksMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeProjectWorksMaster;
        //}



        //For AssociatesProfessionalBodies Details 
        //[HttpGet]
        //public ActionResult _EmployeeAssociatesProfessionalBodiesDetails(int EmployeeID)
        //{
        //    EmployeeAssociatesProfessionalBodiesViewModel model = new EmployeeAssociatesProfessionalBodiesViewModel();
        //    model.EmployeeAssociatesProfessionalBodiesDTO.EmployeeID = EmployeeID;

        //    List<EmployeeAssociatesProfessionalBodies> employeeAssociatesProfessionalBodiesDetailsList = GetEmployeeAssociatesProfessionalBodiesDetails(EmployeeID);
        //    if (employeeAssociatesProfessionalBodiesDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeAssociatesProfessionalBodiesDetails = employeeAssociatesProfessionalBodiesDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeAssociatesProfessionalBodiesDetails.cshtml", model);
        //}

        //protected List<EmployeeAssociatesProfessionalBodies> GetEmployeeAssociatesProfessionalBodiesDetails(int EmployeeID)
        //{
        //    EmployeeAssociatesProfessionalBodiesSearchRequest searchRequest = new EmployeeAssociatesProfessionalBodiesSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "ActivityName";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeAssociatesProfessionalBodies> listEmployeeAssociatesProfessionalBodiesDetails = new List<EmployeeAssociatesProfessionalBodies>();
        //    IBaseEntityCollectionResponse<EmployeeAssociatesProfessionalBodies> baseEntityCollectionResponse = _EmployeeAssociatesProfessionalBodiesBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeAssociatesProfessionalBodiesDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeAssociatesProfessionalBodiesDetails;
        //}

        //For Patent Received Details 
        //[HttpGet]
        //public ActionResult _EmployeePatentReceivedDetails(int EmployeeID)
        //{
        //    EmployeePatentReceivedDetailsViewModel model = new EmployeePatentReceivedDetailsViewModel();
        //    model.EmployeePatentReceivedDetailsDTO.EmployeeID = EmployeeID;

        //    List<EmployeePatentReceivedDetails> employeePatentReceivedDetailsList = GetEmployeePatentReceivedDetails(EmployeeID);
        //    if (employeePatentReceivedDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeePatentReceivedDetails = employeePatentReceivedDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeePatentReceivedDetails.cshtml", model);
        //}

        //protected List<EmployeePatentReceivedDetails> GetEmployeePatentReceivedDetails(int EmployeeID)
        //{
        //    EmployeePatentReceivedDetailsSearchRequest searchRequest = new EmployeePatentReceivedDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "PatentApprovalStatus";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeePatentReceivedDetails> listEmployeePatentReceivedDetails = new List<EmployeePatentReceivedDetails>();
        //    IBaseEntityCollectionResponse<EmployeePatentReceivedDetails> baseEntityCollectionResponse = _EmployeePatentReceivedDetailsBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeePatentReceivedDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeePatentReceivedDetails;
        //}


        //For Prizes Won Details
        //[HttpGet]
        //public ActionResult _EmployeePrizesWonDetails(int EmployeeID)
        //{
        //    EmployeePrizesWonDetailsViewModel model = new EmployeePrizesWonDetailsViewModel();
        //    model.EmployeePrizesWonDetailsDTO.EmployeeID = EmployeeID;

        //    List<EmployeePrizesWonDetails> employeePrizesWonDetailsList = GetEmployeePrizesWonDetails(EmployeeID);
        //    if (employeePrizesWonDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeePrizesWonDetails = employeePrizesWonDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeePrizesWonDetails.cshtml", model);
        //}

        //protected List<EmployeePrizesWonDetails> GetEmployeePrizesWonDetails(int EmployeeID)
        //{
        //    EmployeePrizesWonDetailsSearchRequest searchRequest = new EmployeePrizesWonDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.SortBy = "PrizeName";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeePrizesWonDetails> listEmployeePrizesWonDetails = new List<EmployeePrizesWonDetails>();
        //    IBaseEntityCollectionResponse<EmployeePrizesWonDetails> baseEntityCollectionResponse = _EmployeePrizesWonDetailsBA.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeePrizesWonDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeePrizesWonDetails;
        //}


        //For Consultancy Details
        //[HttpGet]
        //public ActionResult _EmployeeConsultancyMasterDetails(int EmployeeID)
        //{
        //    EmployeeConsultancyMasterViewModel model = new EmployeeConsultancyMasterViewModel();

        //    model.EmployeeConsultancyMasterDTO.EmployeeID = EmployeeID;
        //    model.EmployeeConsultancyMasterDTO.ConnectionString = _connectioString;
        //    IBaseEntityResponse<EmployeeConsultancyMaster> response = _EmployeeConsultancyMasterBA.SelectEmployeeCentreCode(model.EmployeeConsultancyMasterDTO);
        //    model.CentreCode = response.Entity != null ? response.Entity.CentreCode : string.Empty;

        //    List<EmployeeConsultancyMaster> employeeConsultancyMasterDetailsList = GetEmployeeConsultancyMasterDetails(EmployeeID, model.CentreCode);
        //    if (employeeConsultancyMasterDetailsList.Count > 0)
        //    {
        //        ViewBag.Data = 1;
        //        ViewBag.ListEmployeeConsultancyMaster = employeeConsultancyMasterDetailsList;
        //    }
        //    else
        //    {
        //        ViewBag.Data = 0;
        //    }
        //    return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeConsultancyMasterDetails.cshtml", model);
        //}

        //protected List<EmployeeConsultancyMaster> GetEmployeeConsultancyMasterDetails(int EmployeeID, string CentreCode)
        //{
        //    EmployeeConsultancyMasterSearchRequest searchRequest = new EmployeeConsultancyMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    searchRequest.EmployeeID = EmployeeID;
        //    searchRequest.CentreCode = CentreCode;
        //    searchRequest.SortBy = "AssignmentFromDate";
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    //searchRequest.SearchType = 1;
        //    List<EmployeeConsultancyMaster> listEmployeeConsultancyMasterDetails = new List<EmployeeConsultancyMaster>();
        //    IBaseEntityCollectionResponse<EmployeeConsultancyMaster> baseEntityCollectionResponse = _EmployeeConsultancyMasterBA.GetAppliedDetails(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeConsultancyMasterDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeConsultancyMasterDetails;
        //}

        //For Office Details
        public ActionResult _EmployeeOfficeDetails(int EmployeeID)
        {
            try
            {
                EmpEmployeeMasterViewModel empEmployeeMastermodel = new EmpEmployeeMasterViewModel();


                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = EmployeeID;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.SelectByID(empEmployeeMastermodel.EmpEmployeeMasterDTO);

                if (response != null && response.Entity != null)
                {

                    empEmployeeMastermodel.EmployeeFullName = response.Entity.EmployeeFirstName + " " + response.Entity.EmployeeLastName;
                    Session["EmployeeFullName"] = Convert.ToString(empEmployeeMastermodel.EmployeeFullName);

                    if (response.Entity.JobProfileDescription != null || response.Entity.JobStatusDescription != null || response.Entity.JoiningDate != null || response.Entity.SSNNumber != null || response.Entity.ProvidentFundNumber != null || response.Entity.PanNumber != null || response.Entity.AdharCardNumber != null || response.Entity.DrivingLicenceNumber != null)
                    {
                        empEmployeeMastermodel.ID = response.Entity.ID;
                        empEmployeeMastermodel.JobProfileDescription = response.Entity.JobProfileDescription;
                        empEmployeeMastermodel.JobStatusDescription = response.Entity.JobStatusDescription;
                        //  empEmployeeMastermodel.JobStatus = response.Entity.JobStatus;
                        empEmployeeMastermodel.JoiningDate = response.Entity.JoiningDate;
                        empEmployeeMastermodel.SSNNumber = response.Entity.SSNNumber;
                        empEmployeeMastermodel.ProvidentFundNumber = response.Entity.ProvidentFundNumber;
                        empEmployeeMastermodel.PanNumber = response.Entity.PanNumber;
                        empEmployeeMastermodel.AdharCardNumber = response.Entity.AdharCardNumber;
                        empEmployeeMastermodel.DrivingLicenceNumber = response.Entity.DrivingLicenceNumber;

                        ViewBag.Data = 1;
                    }
                    else
                    {
                        ViewBag.Data = 0;
                    }
                }
                else
                {


                }

                return PartialView("~/Views/Employee/EmployeeProfileReport/_EmployeeOfficeDetails.cshtml", empEmployeeMastermodel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        //For Department dropdown according to centrecode
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDepartmentByCentreCode(string CentreCode)
        {
           // var CentreCode = "1";
            string[] splited;
            splited = CentreCode.Split(':');
            // _adminSnPostsBaseViewModel.SelectedCentreName = splited[1];
            CentreCode = splited[0];
            if (String.IsNullOrEmpty(CentreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CentreCode, out id);
            var departments = GetListOrganisationDepartmentMaster(CentreCode);
            var result = (from s in departments
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //For Employees dropdown according to centrecode and department
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetEmployeesByCentreCodeAndDeptID(string CentreCode, string DepartmentID)
        {
            string[] splited;
            splited = CentreCode.Split(':');
            // _adminSnPostsBaseViewModel.SelectedCentreName = splited[1];
            CentreCode = splited[0];
            if (String.IsNullOrEmpty(CentreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CentreCode, out id);

            var departments = GetListEmpEmployeeMaster(CentreCode, DepartmentID);
            var result = (from s in departments
                          select new
                          {
                              id = s.ID,
                              name = s.EmployeeFullName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        protected List<EmpEmployeeMaster> GetListEmpEmployeeMaster(string CentreCode, string DepartmentID)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.DepartmentID = Convert.ToInt32(DepartmentID);
            //searchRequest.SearchType = 1;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterBA.GetByCentreCodeAndDeptID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }

    }
}
