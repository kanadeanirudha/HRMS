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
//using AERP.Web.UI.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using DocumentFormat.OpenXml.Validation;


namespace AERP.Web.UI.Controllers
{
    public class EmployeeInformationController : BaseController
    {
        IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
        //IEmployeeLanguageDetailsBA _employeeLanguageDetailsBA= null;
        IEmployeePictureDetailsBA _employeePictureDetailsBA = null;
        IEmployeeServiceDetailsBA _employeeServiceDetailsBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        int EmpCodeFlag;
        int FirstNameFlag;
        int LastNameFlag; int EmployeeCodeFlag;
        public EmployeeInformationController()
        {
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();
            _employeePictureDetailsBA = new EmployeePictureDetailsBA();
            //_employeeLanguageDetailsBA = new EmployeeLanguageDetailsBA();
            _employeeServiceDetailsBA = new EmployeeServiceDetailsBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0 || Convert.ToInt32(Session["HR Manager"]) > 0)
            {
                EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }
                return View("/Views/Employee/EmployeeInformation/Index.cshtml",model);
            }
            else
            {
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = null;
                if (Convert.ToInt32(Session["Admin Manager"]) > 0)
                {
                    listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                }
                else
                {
                    listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                }


                if (listAdminRoleApplicableDetails.Count > 0)
                {
                    return View("/Views/Employee/EmployeeInformation/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
        }

        public ActionResult List(string actionMode, string centerCode, string centreName)
        {
            try
            {
                EmpEmployeeMasterViewModel _empEmployeeMasterViewModel = new EmpEmployeeMasterViewModel();
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _empEmployeeMasterViewModel.CentreCode = splitCentreCode[0];
                    _empEmployeeMasterViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _empEmployeeMasterViewModel.CentreCode = centerCode;
                    _empEmployeeMasterViewModel.EntityLevel = null;
                }
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        _empEmployeeMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _empEmployeeMasterViewModel.EntityLevel = "Centre";

                    foreach (var b in _empEmployeeMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + "Centre";
                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                    }
                    else
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    }
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = null;
                    if (Convert.ToInt32(Session["Admin Manager"]) > 0)
                    {
                        listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    }
                    else
                    {
                        listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                    }
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        _empEmployeeMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _empEmployeeMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                    }
                }

                _empEmployeeMasterViewModel.CentreCode = centerCode;
                _empEmployeeMasterViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeeInformation/List.cshtml", _empEmployeeMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Profile(int ID)
        {
            try
            {
                EmpEmployeeMasterViewModel empEmployeeMastermodel = new EmpEmployeeMasterViewModel();
                //model.ID = ID;
                TempData["EmployeeID"] = ID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = ID;


                //IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.SelectByID(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                // empEmployeeMastermodel.EmployeeFirstName = response.Entity.EmployeeFirstName + " " + response.Entity.EmployeeLastName;
                // empEmployeeMastermodel.EmployeeLastName = response.Entity.EmployeeLastName;
                // empEmployeeMastermodel.ID = response.Entity.ID;
                return View("/Views/Employee/EmployeeInformation/PersonalInformationHome.cshtml", empEmployeeMastermodel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }



        [HttpGet]
        public ActionResult AddEmployee(string CentreCode, string CentreName)
        {
            try
            {
                EmpEmployeeMasterViewModel empEmployeeMastermodel = new EmpEmployeeMasterViewModel();
                string[] splitedCentreCode = CentreCode.Split(':');
                empEmployeeMastermodel.CentreCode = splitedCentreCode[0];
                // empEmployeeMastermodel.CentreName = splitedCentreCode[2];
                empEmployeeMastermodel.DepartmentID = Convert.ToInt32(splitedCentreCode[1]);

                //For Name Title
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");

                ////--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> _organisationStudyCentreMaster = GetListOrgStudyCentreMaster();
                List<SelectListItem> organisationStudyCentreMasterList = new List<SelectListItem>();
                foreach (OrganisationStudyCentreMaster item in _organisationStudyCentreMaster)
                {
                    if (empEmployeeMastermodel.CentreCode == item.CentreCode)
                    {
                        empEmployeeMastermodel.CentreName = item.CentreName;
                    }
                }
                // ViewBag.organisationStudyCentreMasterList = new SelectList(organisationStudyCentreMasterList, "Value", "Text");

                //----------------------For Employee designation master list---------------------------------//
                List<EmpDesignationMaster> empDesignationMasterList = GetListEmpDesignationMaster();
                List<SelectListItem> empDesignationMaster = new List<SelectListItem>();
                foreach (EmpDesignationMaster item in empDesignationMasterList)
                {
                    empDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.EmpDesignationMasterList = new SelectList(empDesignationMaster, "Value", "Text");


                //--------------------------------------For Department list---------------------------------//
                List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster(empEmployeeMastermodel.CentreCode);
                List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
                {
                    if (item.ID == empEmployeeMastermodel.DepartmentID)
                    {
                        //organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                        empEmployeeMastermodel.DepartmentName = item.DepartmentName;
                        empEmployeeMastermodel.CentrewiseDeptID = item.CentrewiseDepartmentID;
                    }
                }
                //  ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text", empEmployeeMastermodel.CentrewiseDeptID);

                return View("/Views/Employee/EmployeeInformation/AddEmployee.cshtml", empEmployeeMastermodel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpPost]
        public ActionResult AddEmployee(EmpEmployeeMasterViewModel empEmployeeMastermodel)
        {
            try
            {
                string[] splitedCentreCode = empEmployeeMastermodel.CentreCode.Split(':');
                empEmployeeMastermodel.EmpEmployeeMasterDTO.NameTitle = empEmployeeMastermodel.NameTitle;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.GenderCode = empEmployeeMastermodel.GenderCode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmailID = empEmployeeMastermodel.EmailID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeFirstName = empEmployeeMastermodel.EmployeeFirstName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeMiddleName = empEmployeeMastermodel.EmployeeMiddleName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeLastName = empEmployeeMastermodel.EmployeeLastName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.CentreCode = splitedCentreCode[0];
                empEmployeeMastermodel.EmpEmployeeMasterDTO.Birthdate = empEmployeeMastermodel.Birthdate;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeCode = empEmployeeMastermodel.EmployeeCode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.CentrewiseDeptID = empEmployeeMastermodel.CentrewiseDeptID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeDesignationMasterID = empEmployeeMastermodel.EmployeeDesignationMasterID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.InsertEmpEmployeeMaster(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + empEmployeeMastermodel);
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
                //return View("/Views/Shared/_EmployeePictureDetails.cshtml", employeePictureDetailsViewModel);
                return View("/Views/Shared/_EmployeePictureDetails.cshtml", employeePictureDetailsViewModel);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        //---------------------------------------Action Result for Saving Image to database-------------------------------------------------//
        // [Route("_EmployeePictureDetails")]
        [HttpPost]
        public ActionResult _EmployeePictureDetails(EmployeePictureDetailsViewModel employeePictureDetailsViewModel)
        {
            try
            {
                if (Request.Files["File"] != null)
                {
                    if (ModelState.IsValid)
                    {

                        HttpPostedFileBase file = Request.Files["File"];
                        employeePictureDetailsViewModel.EmployeePicture = ConvertToBytes(file);
                        //Check if all simple data annotations are valid

                        //Prepare the needed variables
                        Bitmap original = null;
                        var name = "newimagefile";
                        var errorField = string.Empty;

                        if (employeePictureDetailsViewModel.IsUrl)
                        {
                            errorField = "Url";
                            name = GetUrlFileName(employeePictureDetailsViewModel.Url);
                            original = GetImageFromUrl(employeePictureDetailsViewModel.Url);
                        }
                        else if (employeePictureDetailsViewModel.File != null) // model.IsFile
                        {
                            errorField = "File";
                            name = Path.GetFileNameWithoutExtension(employeePictureDetailsViewModel.File.FileName);
                            original = Bitmap.FromStream(employeePictureDetailsViewModel.File.InputStream) as Bitmap;
                            employeePictureDetailsViewModel.EmployeePicFilename = name;
                        }

                        //If we had success so far
                        if (original != null)
                        {
                            employeePictureDetailsViewModel.EmployeePictureDetailsDTO.EmployeeID = employeePictureDetailsViewModel.EmployeeID;
                            employeePictureDetailsViewModel.EmployeePictureDetailsDTO.EmployeePicType = employeePictureDetailsViewModel.File.ContentType;
                            employeePictureDetailsViewModel.EmployeePictureDetailsDTO.EmployeePicFileSize = employeePictureDetailsViewModel.File.ContentLength.ToString();
                            employeePictureDetailsViewModel.EmployeePictureDetailsDTO.EmployeePicFileWidth = employeePictureDetailsViewModel.Width.ToString();
                            employeePictureDetailsViewModel.EmployeePictureDetailsDTO.EmployeePicFileHeight = employeePictureDetailsViewModel.Height.ToString();
                            employeePictureDetailsViewModel.EmployeePictureDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                            employeePictureDetailsViewModel.EmployeePictureDetailsDTO.ConnectionString = _connectioString;
                            IBaseEntityResponse<EmployeePictureDetails> response = _employeePictureDetailsBA.InsertEmployeePictureDetails(employeePictureDetailsViewModel.EmployeePictureDetailsDTO);

                            return Redirect("/EmployeeInformation/PersonalInformationHome/" + employeePictureDetailsViewModel.EmployeeID);
                        }


                        else //Otherwise we add an error and return to the (previous) view with the model data
                            ModelState.AddModelError(errorField, "Your upload did not seem valid. Please try again using only correct images!");
                    }
                }
                else
                {
                    employeePictureDetailsViewModel.errorMessage = "Please select photo";
                    //  return PartialView("_EmployeePictureDetails", employeePictureDetailsViewModel);
                }
                return Redirect("/EmployeeInformation/PersonalInformationHome/" + employeePictureDetailsViewModel.EmployeeID);
                //return View(employeePictureDetailsViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult PersonalInformationHome(int ID)
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0 || Convert.ToInt32(Session["HR Manager"]) > 0 || (Convert.ToInt32(Session["PersonID"]) == ID))
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
                    li_EmpEmployeeMaster_EmployeeMaritalStatus.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectMaritalStatus, Value = "" });
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
                    TempData["EmployeeID"] = ID;
                    ViewBag.EmployeeID = ID;
                    Session["CurrentEmployeeID"] = Convert.ToString(ID);
                    empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                    empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = ID;
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
                    empEmployeeMastermodel.EthanicRaceCode = response.Entity.EthanicRaceCode;
                    empEmployeeMastermodel.IsEmployeeSmoker = response.Entity.IsEmployeeSmoker;
                    empEmployeeMastermodel.CentreCode = response.Entity.CentreCode;
                    empEmployeeMastermodel.DepartmentID = response.Entity.DepartmentID;
                    empEmployeeMastermodel.EmployeeDesignationMasterID = response.Entity.EmployeeDesignationMasterID;
                    empEmployeeMastermodel.JobProfileID = response.Entity.JobProfileID;
                    empEmployeeMastermodel.BankACNumber = response.Entity.BankACNumber;
                    empEmployeeMastermodel.IFSCCode = response.Entity.IFSCCode;
                    empEmployeeMastermodel.PaymentMode = response.Entity.PaymentMode;
                    empEmployeeMastermodel.DepartmentID = response.Entity.DepartmentID;
                    empEmployeeMastermodel.EmployeeDesignationMasterID = response.Entity.EmployeeDesignationMasterID;
                    empEmployeeMastermodel.SalaryGradeCode = response.Entity.SalaryGradeCode;
                    empEmployeeMastermodel.JobProfileID = response.Entity.JobProfileID;
                    empEmployeeMastermodel.JobStatusID = response.Entity.JobStatusID;
                    empEmployeeMastermodel.JobStatus = response.Entity.JobStatus;
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
                    empEmployeeMastermodel.MaidenFirstName = response.Entity.MaidenFirstName;
                    empEmployeeMastermodel.MaidenMiddleName = response.Entity.MaidenMiddleName;
                    empEmployeeMastermodel.MaidenLastName = response.Entity.MaidenLastName;
                    empEmployeeMastermodel.BankACNumber = response.Entity.BankACNumber;
                    empEmployeeMastermodel.AdharCardNumber = response.Entity.AdharCardNumber;
                    empEmployeeMastermodel.SSNNumber = response.Entity.SSNNumber == null ? response.Entity.SSNNumber : response.Entity.SSNNumber.TrimEnd();
                    empEmployeeMastermodel.SINNumber = response.Entity.SINNumber == null ? response.Entity.SINNumber : response.Entity.SINNumber.TrimEnd();
                    empEmployeeMastermodel.UANNumber = response.Entity.UANNumber == null ? response.Entity.UANNumber : response.Entity.UANNumber.TrimEnd();
                    //empEmployeeMastermodel.SINNumber = response.Entity.SINNumber.TrimEnd();
                    empEmployeeMastermodel.DrivingLicenceNumber = response.Entity.DrivingLicenceNumber;
                    empEmployeeMastermodel.DrivingLicenceExpireDate = response.Entity.DrivingLicenceExpireDate;
                    empEmployeeMastermodel.ESINumber = response.Entity.ESINumber;
                    empEmployeeMastermodel.CurrencyCode = response.Entity.CurrencyCode;
                    empEmployeeMastermodel.IMEI = response.Entity.IMEI;

                    if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0 || Convert.ToInt32(Session["HR Manager"]) > 0)
                    {
                        ViewBag.ListViewDisplayFlag = true;
                    }
                    else
                    {
                        int AdminRoleMasterID;
                        if (Session["RoleID"] == null)
                        {
                            AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                        }
                        else
                        {
                            AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                        }
                        List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = null;
                        if (Convert.ToInt32(Session["Admin Manager"]) > 0)
                        {
                            listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                        }
                        else
                        {
                            listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                        }
                        if (listAdminRoleApplicableDetails.Count > 0)
                        {
                            ViewBag.ListViewDisplayFlag = true;
                        }
                        else
                        {
                            ViewBag.ListViewDisplayFlag = false;
                        }
                    }

                    if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0 || Convert.ToInt32(Session["HR Manager"]) > 0)
                    {
                        ViewBag.IsFieldDisabled = "";
                    }
                    else
                    {
                        ViewBag.IsFieldDisabled = "disabled";
                    }

                    return View("/Views/Employee/EmployeeInformation/PersonalInformationHome.cshtml", empEmployeeMastermodel);
                }
                catch (Exception ex)
                {
                    _logException.Error(ex.Message);
                    throw;
                }
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult PersonalInformationHome(EmpEmployeeMasterViewModel empEmployeeMastermodel)
        {
            try
            {
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeCode = empEmployeeMastermodel.EmployeeCode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmailID = empEmployeeMastermodel.EmailID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.OtherEmailID = empEmployeeMastermodel.OtherEmailID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.NameTitle = empEmployeeMastermodel.NameTitle;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeFirstName = empEmployeeMastermodel.EmployeeFirstName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeMiddleName = empEmployeeMastermodel.EmployeeMiddleName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeLastName = empEmployeeMastermodel.EmployeeLastName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.NickName = empEmployeeMastermodel.NickName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.IsEmployeeSmoker = empEmployeeMastermodel.IsEmployeeSmoker;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EthanicRaceCode = empEmployeeMastermodel.EthanicRaceCode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.Birthdate = empEmployeeMastermodel.Birthdate;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.NationalityID = empEmployeeMastermodel.NationalityID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.GenderCode = empEmployeeMastermodel.GenderCode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.MarritalStaus = empEmployeeMastermodel.MarritalStaus;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeNameAsPerTC = empEmployeeMastermodel.EmployeeNameAsPerTC;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.MaidenFirstName = empEmployeeMastermodel.MaidenFirstName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.MaidenMiddleName = empEmployeeMastermodel.MaidenMiddleName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.MaidenLastName = empEmployeeMastermodel.MaidenLastName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.IsNameChangedBefore = empEmployeeMastermodel.IsNameChangedBefore;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.PriorFirstName = empEmployeeMastermodel.PriorFirstName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.PriorMiddleName = empEmployeeMastermodel.PriorMiddleName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.PriorLastName = empEmployeeMastermodel.PriorLastName;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = empEmployeeMastermodel.ID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.UpdateEmpEmployeeMasterPersonalInformation(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + empEmployeeMastermodel);
        }

        [HttpGet]
        public ActionResult EmployeeOfficeDetails(EmpEmployeeMasterViewModel empEmployeeMastermodel)
        {
            try
            {
                //EmpEmployeeMasterViewModel empEmployeeMastermodel = new EmpEmployeeMasterViewModel();


                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> _organisationStudyCentreMaster = GetListOrgStudyCentreMaster();
                List<SelectListItem> organisationStudyCentreMasterList = new List<SelectListItem>();
                foreach (OrganisationStudyCentreMaster item in _organisationStudyCentreMaster)
                {
                    organisationStudyCentreMasterList.Add(new SelectListItem { Text = item.CentreName, Value = item.CentreCode.ToString() });
                }
                ViewBag.organisationStudyCentreMasterList = new SelectList(organisationStudyCentreMasterList, "Value", "Text");


                //----------------------For Employee designation master list---------------------------------//
                List<EmpDesignationMaster> empDesignationMasterList = GetListEmpDesignationMaster();
                List<SelectListItem> empDesignationMaster = new List<SelectListItem>();
                foreach (EmpDesignationMaster item in empDesignationMasterList)
                {
                    empDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.EmpDesignationMasterList = new SelectList(empDesignationMaster, "Value", "Text");


                //-------------------------------------For Employee job profile list-----------------------------------------//
                List<GeneralJobProfile> generalJobProfileList = GetListGeneralJobProfile();
                List<SelectListItem> generalJobProfile = new List<SelectListItem>();
                foreach (GeneralJobProfile item in generalJobProfileList)
                {
                    generalJobProfile.Add(new SelectListItem { Text = item.JobProfileDescription, Value = item.ID.ToString() });
                }
                ViewBag.generalJobProfileList = new SelectList(generalJobProfile, "Value", "Text");


                //--------------------------------------For Employee job status list----------------------------------------//
                List<GeneralJobStatus> generalJobStatusList = GetListGeneralJobStatus();
                List<SelectListItem> generalJobStatus = new List<SelectListItem>();
                foreach (GeneralJobStatus item in generalJobStatusList)
                {
                    generalJobStatus.Add(new SelectListItem { Text = item.JobStatusDescription.ToUpper(), Value = item.ID.ToString() });
                }
                ViewBag.generalJobStatusList = new SelectList(generalJobStatus, "Value", "Text");



                //--------------------------------------For Employee payment mode----------------------------------------//
                List<SelectListItem> EmpEmployeeMaster_PaymentMode = new List<SelectListItem>();
                ViewBag.EmpEmployeeMaster_PaymentMode = new SelectList(EmpEmployeeMaster_PaymentMode, "Value", "Text");
                List<SelectListItem> li_EmpEmployeeMaster_PaymentMode = new List<SelectListItem>();
                li_EmpEmployeeMaster_PaymentMode.Add(new SelectListItem { Text = "-- Select Payment Mode--" });
                li_EmpEmployeeMaster_PaymentMode.Add(new SelectListItem { Text = "Daily Basis", Value = "D" });
                li_EmpEmployeeMaster_PaymentMode.Add(new SelectListItem { Text = "Fixed/Consolidated", Value = "C" });
                li_EmpEmployeeMaster_PaymentMode.Add(new SelectListItem { Text = "Period Basis", Value = "P" });
                li_EmpEmployeeMaster_PaymentMode.Add(new SelectListItem { Text = "Structure", Value = "S" });
                ViewData["PaymentMode"] = new SelectList(li_EmpEmployeeMaster_PaymentMode, "Value", "Text", empEmployeeMastermodel.PaymentMode);



                TempData["EmployeeID"] = empEmployeeMastermodel.ID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = empEmployeeMastermodel.ID;
                empEmployeeMastermodel.CentreCode = empEmployeeMastermodel.CentreCode;
                empEmployeeMastermodel.PaymentMode = empEmployeeMastermodel.PaymentMode;


                //--------------------------------------For Employee shift list----------------------------------------//
                List<EmployeeShiftMaster> employeeShiftMasterList = GetListEmployeeShiftMaster(empEmployeeMastermodel.CentreCode);
                List<SelectListItem> employeeShiftMaster = new List<SelectListItem>();
                employeeShiftMaster.Add(new SelectListItem { Text = "--Select Shift--", Value = "0" });
                foreach (EmployeeShiftMaster item in employeeShiftMasterList)
                {
                    employeeShiftMaster.Add(new SelectListItem { Text = item.EmployeeShiftDescription, Value = item.EmployeeShiftMasterID.ToString() });
                }

                ViewBag.employeeShiftMasterList = new SelectList(employeeShiftMaster, "Value", "Text");

                //--------------------------------------For Employee payment mode----------------------------------------//
                List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster(empEmployeeMastermodel.CentreCode);
                List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
                {
                    organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                }
                ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text", empEmployeeMastermodel.DepartmentID);

                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0 || Convert.ToInt32(Session["HR Manager"]) > 0)
                {
                    ViewBag.IsFieldDisabled = "";
                }
                else
                {
                    ViewBag.IsFieldDisabled = "disabled";
                }

                return View("/Views/Employee/EmployeeInformation/EmployeeOfficeDetails.cshtml", empEmployeeMastermodel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult UpdateEmployeeOfficeDetails(EmpEmployeeMasterViewModel empEmployeeMastermodel)
        {
            try
            {
                empEmployeeMastermodel.EmpEmployeeMasterDTO.CentreCode = empEmployeeMastermodel.CentreCode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.DepartmentID = empEmployeeMastermodel.DepartmentID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeDesignationMasterID = empEmployeeMastermodel.EmployeeDesignationMasterID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.SalaryGradeCode = empEmployeeMastermodel.SalaryGradeCode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.JobProfileID = empEmployeeMastermodel.JobProfileID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.JobStatusID = empEmployeeMastermodel.JobStatusID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.JobStatus = empEmployeeMastermodel.JobStatus;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.JoiningDate = empEmployeeMastermodel.JoiningDate;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.AppointmentApprovalDate = empEmployeeMastermodel.AppointmentApprovalDate;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ReasonOfLeaving = empEmployeeMastermodel.ReasonOfLeaving;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.IsLeave = empEmployeeMastermodel.IsLeave;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.DateOfLeaving = empEmployeeMastermodel.DateOfLeaving;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.DateOfRetirment = empEmployeeMastermodel.DateOfRetirment;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.TerminationDate = empEmployeeMastermodel.TerminationDate;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.EmployeeShiftApplicableMasterID = empEmployeeMastermodel.EmployeeShiftApplicableMasterID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.PayScaleMstID = empEmployeeMastermodel.PayScaleMstID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.BasicSalary = empEmployeeMastermodel.BasicSalary;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ProvidentFundNumber = empEmployeeMastermodel.ProvidentFundNumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ProvidentFundApplicableDate = empEmployeeMastermodel.ProvidentFundApplicableDate;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.UANNumber = empEmployeeMastermodel.UANNumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.PanNumber = empEmployeeMastermodel.PanNumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.BankACNumber = empEmployeeMastermodel.BankACNumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.IFSCCode = empEmployeeMastermodel.IFSCCode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.AdharCardNumber = empEmployeeMastermodel.AdharCardNumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.SSNNumber = empEmployeeMastermodel.SSNNumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.SINNumber = empEmployeeMastermodel.SINNumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.DrivingLicenceNumber = empEmployeeMastermodel.DrivingLicenceNumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.DrivingLicenceExpireDate = empEmployeeMastermodel.DrivingLicenceExpireDate;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.PaymentMode = empEmployeeMastermodel.PaymentMode;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ESINumber = empEmployeeMastermodel.ESINumber;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = empEmployeeMastermodel.ID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.UpdateEmpEmployeeMasterOfficeDetails(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + empEmployeeMastermodel);
        }

        [HttpGet]
        public ActionResult EmployeeServiceDetails(int EmployeeID)
        {
            EmployeeServiceDetailsViewModel EmployeeServiceDetailsViewModel = new EmployeeServiceDetailsViewModel();
            try
            {
                EmployeeServiceDetailsViewModel.EmployeeID = EmployeeID;
                return View("/Views/Employee/EmployeeInformation/EmployeeServiceDetails.cshtml", EmployeeServiceDetailsViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        // Get data for New entry of Service details
        [HttpGet]
        public ActionResult EmployeeServiceDetailsCreate(int EmployeeID)
        {
            EmployeeServiceDetailsViewModel EmployeeServiceDetailsViewModel = new EmployeeServiceDetailsViewModel();
            try
            {
                EmployeeServiceDetailsViewModel.EmployeeID = EmployeeID;

                List<SelectListItem> EmployeeServiceDetails_YesNo = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_YesNo = new SelectList(EmployeeServiceDetails_YesNo, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_YesNo = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = "No", Value = "N" });
                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = "Yes", Value = "Y" });
                //ViewData["YesNo"] = li_EmpolyeeServiceDetail_YesNo;


                List<SelectListItem> EmployeeServiceDetails_PromotionDemotionFlag = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_PromotionDemotionFlag = new SelectList(EmployeeServiceDetails_PromotionDemotionFlag, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_PromotionDemotionFlag = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Promotion", Value = "P" });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Demotion", Value = "D" });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Transfer", Value = "T" });


                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> _organisationStudyCentreMaster = GetListOrgStudyCentreMaster();
                List<SelectListItem> organisationStudyCentreMasterList = new List<SelectListItem>();
                foreach (OrganisationStudyCentreMaster item in _organisationStudyCentreMaster)
                {
                    organisationStudyCentreMasterList.Add(new SelectListItem { Text = item.CentreName, Value = item.CentreCode.ToString() });
                }
                ViewBag.organisationStudyCentreMasterList = new SelectList(organisationStudyCentreMasterList, "Value", "Text");


                //--------------------------------------For Designation list---------------------------------//
                List<EmpDesignationMaster> empDesignationMasterList = GetListEmpDesignationMaster();
                List<SelectListItem> empDesignationMaster = new List<SelectListItem>();
                foreach (EmpDesignationMaster item in empDesignationMasterList)
                {
                    empDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.EmpDesignationMaster = new SelectList(empDesignationMaster, "Value", "Text");

                //--------------------------------------For Nature of appointment list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_NatureOfAppoinment = new List<SelectListItem>();
                // ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_NatureOfAppoinment = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "TEMPORARY" });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "PERMANANT" });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = "Visiting", Value = "VISITING" });


                //--------------------------------------For University Approval type list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_UniversityApprovalType = new List<SelectListItem>();
                // ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_UniversityApprovalType = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "TEMPORARY" });
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "PERMANANT" });

                //--------------------------------------For Granted Promotion level list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_GrantedPromotionLevel = new List<SelectListItem>();
                // ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_GrantedPromotionLevel = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = "University", Value = "UNIVERSITY" });
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = "Institute", Value = "INSTITUTE" });

                //--------------------------------------For University/Board list---------------------------------//
                //List<GeneralBoardUniversityMaster> _generalBoardUniversityMaster = GetListGeneralBoardUniversityMaster();
                //List<SelectListItem> generalBoardUniversityMasterList = new List<SelectListItem>();
                //foreach (GeneralBoardUniversityMaster item in _generalBoardUniversityMaster)
                //{
                //    generalBoardUniversityMasterList.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                //}
                //ViewBag.generalBoardUniversityMasterList = new SelectList(generalBoardUniversityMasterList, "Value", "Text");


                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ConnectionString = _connectioString;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.EmployeeID = EmployeeID;
                IBaseEntityResponse<EmployeeServiceDetails> response = _employeeServiceDetailsBA.SelectByEmployeeID(EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO);
                if (response.Entity != null && response.Entity.IsCurrentFlag == true)
                {
                    EmployeeServiceDetailsViewModel.ID = response.Entity.ID;
                    EmployeeServiceDetailsViewModel.CurrentID = response.Entity.ID;
                    EmployeeServiceDetailsViewModel.OrderNumber = response.Entity.OrderNumber;
                    EmployeeServiceDetailsViewModel.OrderDate = response.Entity.OrderDate;
                    EmployeeServiceDetailsViewModel.AcceptedByEmployee = response.Entity.AcceptedByEmployee;
                    EmployeeServiceDetailsViewModel.PromotionDemotionFlag = response.Entity.PromotionDemotionFlag;
                    EmployeeServiceDetailsViewModel.PromotionDemotionDate = response.Entity.PromotionDemotionDate;
                    EmployeeServiceDetailsViewModel.PreviousPromotionDemotionDate = response.Entity.PreviousPromotionDemotionDate;
                    EmployeeServiceDetailsViewModel.EmployeeDesignationMasterID = response.Entity.EmployeeDesignationMasterID;
                    EmployeeServiceDetailsViewModel.DepartmentID = response.Entity.DepartmentID;
                    EmployeeServiceDetailsViewModel.ChargeTakingDate = response.Entity.ChargeTakingDate;
                    EmployeeServiceDetailsViewModel.OldDesignationID = response.Entity.OldDesignationID;
                    EmployeeServiceDetailsViewModel.OldDepartmentID = response.Entity.OldDepartmentID;
                    EmployeeServiceDetailsViewModel.OldDepartmentName = response.Entity.OldDepartmentName;
                    EmployeeServiceDetailsViewModel.CollegeApprovalDate = response.Entity.CollegeApprovalDate;
                    EmployeeServiceDetailsViewModel.UniversityApprovalDate = response.Entity.UniversityApprovalDate;
                    EmployeeServiceDetailsViewModel.CollegeApprovalNumber = response.Entity.CollegeApprovalNumber;
                    EmployeeServiceDetailsViewModel.UniversityApprovalNumber = response.Entity.UniversityApprovalNumber;
                    EmployeeServiceDetailsViewModel.NatureOfDuty = response.Entity.NatureOfDuty;
                    EmployeeServiceDetailsViewModel.BasicAmount = response.Entity.BasicAmount;
                    EmployeeServiceDetailsViewModel.ApprovedBy = response.Entity.ApprovedBy;
                    EmployeeServiceDetailsViewModel.NewGrade = response.Entity.NewGrade;
                    EmployeeServiceDetailsViewModel.NewPayscaleID = response.Entity.NewPayscaleID;
                    EmployeeServiceDetailsViewModel.NatureOfAppointment = response.Entity.NatureOfAppointment;
                    EmployeeServiceDetailsViewModel.UniversityApprovalType = response.Entity.UniversityApprovalType;
                    EmployeeServiceDetailsViewModel.GeneralBoardUniversityID = response.Entity.GeneralBoardUniversityID;
                    EmployeeServiceDetailsViewModel.SubjectForApproval = response.Entity.SubjectForApproval;
                    EmployeeServiceDetailsViewModel.GrantedPromotionDate = response.Entity.GrantedPromotionDate;
                    EmployeeServiceDetailsViewModel.GrantedPromotionDesignationID = response.Entity.GrantedPromotionDesignationID;
                    EmployeeServiceDetailsViewModel.GrantedPromotionLevel = response.Entity.GrantedPromotionLevel;
                    EmployeeServiceDetailsViewModel.CentreName = response.Entity.CentreName;
                    EmployeeServiceDetailsViewModel.CentreCode = response.Entity.CentreCode;
                    EmployeeServiceDetailsViewModel.OldCentreCode = response.Entity.OldCentreCode;
                    EmployeeServiceDetailsViewModel.IsActive = response.Entity.IsActive;
                    EmployeeServiceDetailsViewModel.IsCurrentFlag = response.Entity.IsCurrentFlag;
                    ViewBag.IsNewEmployee = 0;


                }
                else
                {
                    ViewBag.IsNewEmployee = 1;
                }

                ViewData["PromotionDemotionFlag"] = new SelectList(li_EmpolyeeServiceDetail_PromotionDemotionFlag, "Value", "Text", EmployeeServiceDetailsViewModel.PromotionDemotionFlag);

                ViewData["AcceptedByEmployee"] = new SelectList(li_EmpolyeeServiceDetail_YesNo, "Value", "Text", EmployeeServiceDetailsViewModel.AcceptedByEmployee);

                ViewData["NatureOfAppointment"] = new SelectList(li_EmpolyeeServiceDetail_NatureOfAppoinment, "Value", "Text", EmployeeServiceDetailsViewModel.NatureOfAppointment);

                ViewData["UniversityApprovalType"] = new SelectList(li_EmpolyeeServiceDetail_UniversityApprovalType, "Value", "Text", EmployeeServiceDetailsViewModel.UniversityApprovalType);

                ViewData["GrantedPromotionLevel"] = new SelectList(li_EmpolyeeServiceDetail_GrantedPromotionLevel, "Value", "Text", EmployeeServiceDetailsViewModel.GrantedPromotionLevel);


                //--------------------------------------For Deaprtment list---------------------------------//
                if (EmployeeServiceDetailsViewModel.CentreCode != null)
                {
                    List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster(EmployeeServiceDetailsViewModel.CentreCode);
                    List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                    foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
                    {
                        organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                    }
                    ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text");
                }
                else
                {
                    //List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster(null);
                    List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                    //foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
                    //{
                    //    organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.CentrewiseDepartmentID.ToString() });
                    //}
                    ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text");
                }


                return View("/Views/Employee/EmployeeInformation/EmployeeServiceDetailsCreate.cshtml", EmployeeServiceDetailsViewModel);
                //return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        // Post data for New entry of Service details either Promotion/Demotion
        [HttpPost]
        public ActionResult EmployeeServiceDetailsCreate(EmployeeServiceDetailsViewModel EmployeeServiceDetailsViewModel)
        {

            try
            {
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ID = EmployeeServiceDetailsViewModel.ID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.EmployeeID = EmployeeServiceDetailsViewModel.EmployeeID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OrderNumber = EmployeeServiceDetailsViewModel.OrderNumber;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.SequenceNumber = EmployeeServiceDetailsViewModel.SequenceNumber;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OrderDate = EmployeeServiceDetailsViewModel.OrderDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.AcceptedByEmployee = EmployeeServiceDetailsViewModel.AcceptedByEmployee;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.PromotionDemotionFlag = EmployeeServiceDetailsViewModel.PromotionDemotionFlag;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.PromotionDemotionDate = EmployeeServiceDetailsViewModel.PromotionDemotionDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.PreviousPromotionDemotionDate = EmployeeServiceDetailsViewModel.PreviousPromotionDemotionDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.EmployeeDesignationMasterID = EmployeeServiceDetailsViewModel.EmployeeDesignationMasterID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.DepartmentID = EmployeeServiceDetailsViewModel.DepartmentID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ChargeTakingDate = EmployeeServiceDetailsViewModel.ChargeTakingDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OldDesignationID = EmployeeServiceDetailsViewModel.OldDesignationID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OldDepartmentID = EmployeeServiceDetailsViewModel.OldDepartmentID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OldDepartmentName = EmployeeServiceDetailsViewModel.OldDepartmentName;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CollegeApprovalDate = EmployeeServiceDetailsViewModel.CollegeApprovalDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.UniversityApprovalDate = EmployeeServiceDetailsViewModel.UniversityApprovalDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CollegeApprovalNumber = EmployeeServiceDetailsViewModel.CollegeApprovalNumber;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.UniversityApprovalNumber = EmployeeServiceDetailsViewModel.UniversityApprovalNumber;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.NatureOfDuty = EmployeeServiceDetailsViewModel.NatureOfDuty;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.BasicAmount = EmployeeServiceDetailsViewModel.BasicAmount;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ApprovedBy = EmployeeServiceDetailsViewModel.ApprovedBy;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.NewGrade = EmployeeServiceDetailsViewModel.NewGrade;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.NewPayscaleID = EmployeeServiceDetailsViewModel.NewPayscaleID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.NatureOfAppointment = EmployeeServiceDetailsViewModel.NatureOfAppointment;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.UniversityApprovalType = EmployeeServiceDetailsViewModel.UniversityApprovalType;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.GeneralBoardUniversityID = EmployeeServiceDetailsViewModel.GeneralBoardUniversityID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.SubjectForApproval = EmployeeServiceDetailsViewModel.SubjectForApproval;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.GrantedPromotionDate = EmployeeServiceDetailsViewModel.GrantedPromotionDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.GrantedPromotionDesignationID = EmployeeServiceDetailsViewModel.GrantedPromotionDesignationID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.GrantedPromotionLevel = EmployeeServiceDetailsViewModel.GrantedPromotionLevel;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CentreName = EmployeeServiceDetailsViewModel.CentreName;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CentreCode = EmployeeServiceDetailsViewModel.CentreCode;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OldCentreCode = EmployeeServiceDetailsViewModel.OldCentreCode;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.IsActive = EmployeeServiceDetailsViewModel.IsActive;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.IsCurrentFlag = true;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EmployeeServiceDetails> response = _employeeServiceDetailsBA.InsertEmployeeServiceDetails(EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO);
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        // Get data for New entry of Service details
        [HttpGet]
        public ActionResult EmployeeServiceDetailsInfo(int ID)
        {
            EmployeeServiceDetailsViewModel EmployeeServiceDetailsViewModel = new EmployeeServiceDetailsViewModel();
            try
            {
                EmployeeServiceDetailsViewModel.ID = ID;

                List<SelectListItem> EmployeeServiceDetails_YesNo = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_YesNo = new SelectList(EmployeeServiceDetails_YesNo, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_YesNo = new List<SelectListItem>();


                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = "No", Value = "N" });
                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = "Yes", Value = "Y" });
                //ViewData["YesNo"] = li_EmpolyeeServiceDetail_YesNo;

                List<SelectListItem> EmployeeServiceDetails_PromotionDemotionFlag = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_PromotionDemotionFlag = new SelectList(EmployeeServiceDetails_PromotionDemotionFlag, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_PromotionDemotionFlag = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Promotion", Value = "P" });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Demotion", Value = "D" });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Transfer", Value = "T" });
                //    ViewData["PromotionDemotionFlag"] = li_EmpolyeeServiceDetail_PromotionDemotionFlag;


                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> _organisationStudyCentreMaster = GetListOrgStudyCentreMaster();
                List<SelectListItem> organisationStudyCentreMasterList = new List<SelectListItem>();
                foreach (OrganisationStudyCentreMaster item in _organisationStudyCentreMaster)
                {
                    organisationStudyCentreMasterList.Add(new SelectListItem { Text = item.CentreName, Value = item.CentreCode.ToString() });
                }
                ViewBag.organisationStudyCentreMasterList = new SelectList(organisationStudyCentreMasterList, "Value", "Text");


                //--------------------------------------For Designation list---------------------------------//
                List<EmpDesignationMaster> empDesignationMasterList = GetListEmpDesignationMaster();
                List<SelectListItem> empDesignationMaster = new List<SelectListItem>();
                foreach (EmpDesignationMaster item in empDesignationMasterList)
                {
                    empDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.EmpDesignationMaster = new SelectList(empDesignationMaster, "Value", "Text");

                //--------------------------------------For Nature of appointment list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_NatureOfAppoinment = new List<SelectListItem>();
                // ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_NatureOfAppoinment = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "TEMPORARY" });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "PERMANANT" });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = "VISITING", Value = "VISITING" });
                //    ViewData["NatureOfAppoinmentList"] = li_EmpolyeeServiceDetail_NatureOfAppoinment;


                //--------------------------------------For University Approval type list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_UniversityApprovalType = new List<SelectListItem>();
                // ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_UniversityApprovalType = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "TEMPORARY" });
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "PERMANANT" });
                //  ViewData["UniversityApprovalType"] = li_EmpolyeeServiceDetail_UniversityApprovalType;


                //--------------------------------------For Granted Promotion level list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_GrantedPromotionLevel = new List<SelectListItem>();
                // ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_GrantedPromotionLevel = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = "UNIVERSITY", Value = "UNIVERSITY" });
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = "INSTITUTE", Value = "INSTITUTE" });
                // ViewData["GrantedPromotionLevel"] = li_EmpolyeeServiceDetail_GrantedPromotionLevel;


                //--------------------------------------For University/Board list---------------------------------//
                //List<GeneralBoardUniversityMaster> _generalBoardUniversityMaster = GetListGeneralBoardUniversityMaster();
                //List<SelectListItem> generalBoardUniversityMasterList = new List<SelectListItem>();
                //foreach (GeneralBoardUniversityMaster item in _generalBoardUniversityMaster)
                //{
                //    generalBoardUniversityMasterList.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                //}
                //ViewBag.generalBoardUniversityMasterList = new SelectList(generalBoardUniversityMasterList, "Value", "Text");


                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ConnectionString = _connectioString;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ID = ID;
                IBaseEntityResponse<EmployeeServiceDetails> response = _employeeServiceDetailsBA.SelectByID(EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO);
                if (response.Entity != null && response.Entity.IsCurrentFlag == false)
                {
                    EmployeeServiceDetailsViewModel.ID = response.Entity.ID;
                    EmployeeServiceDetailsViewModel.EmployeeID = response.Entity.EmployeeID;
                    EmployeeServiceDetailsViewModel.CurrentID = response.Entity.ID;
                    EmployeeServiceDetailsViewModel.OrderNumber = response.Entity.OrderNumber;
                    EmployeeServiceDetailsViewModel.OrderDate = response.Entity.OrderDate;
                    EmployeeServiceDetailsViewModel.AcceptedByEmployee = response.Entity.AcceptedByEmployee;
                    EmployeeServiceDetailsViewModel.PromotionDemotionFlag = response.Entity.PromotionDemotionFlag;
                    EmployeeServiceDetailsViewModel.PromotionDemotionDate = response.Entity.PromotionDemotionDate;
                    EmployeeServiceDetailsViewModel.PreviousPromotionDemotionDate = response.Entity.PreviousPromotionDemotionDate;
                    EmployeeServiceDetailsViewModel.EmployeeDesignationMasterID = response.Entity.EmployeeDesignationMasterID;
                    EmployeeServiceDetailsViewModel.DepartmentID = response.Entity.DepartmentID;
                    EmployeeServiceDetailsViewModel.ChargeTakingDate = response.Entity.ChargeTakingDate;
                    EmployeeServiceDetailsViewModel.OldDesignationID = response.Entity.OldDesignationID;
                    EmployeeServiceDetailsViewModel.OldDepartmentID = response.Entity.OldDepartmentID;
                    EmployeeServiceDetailsViewModel.OldDepartmentName = response.Entity.OldDepartmentName;
                    EmployeeServiceDetailsViewModel.CollegeApprovalDate = response.Entity.CollegeApprovalDate;
                    EmployeeServiceDetailsViewModel.UniversityApprovalDate = response.Entity.UniversityApprovalDate;
                    EmployeeServiceDetailsViewModel.CollegeApprovalNumber = response.Entity.CollegeApprovalNumber;
                    EmployeeServiceDetailsViewModel.UniversityApprovalNumber = response.Entity.UniversityApprovalNumber;
                    EmployeeServiceDetailsViewModel.NatureOfDuty = response.Entity.NatureOfDuty;
                    EmployeeServiceDetailsViewModel.BasicAmount = response.Entity.BasicAmount;
                    EmployeeServiceDetailsViewModel.ApprovedBy = response.Entity.ApprovedBy;
                    EmployeeServiceDetailsViewModel.NewGrade = response.Entity.NewGrade;
                    EmployeeServiceDetailsViewModel.NewPayscaleID = response.Entity.NewPayscaleID;
                    EmployeeServiceDetailsViewModel.NatureOfAppointment = response.Entity.NatureOfAppointment;
                    EmployeeServiceDetailsViewModel.UniversityApprovalType = response.Entity.UniversityApprovalType;
                    EmployeeServiceDetailsViewModel.GeneralBoardUniversityID = response.Entity.GeneralBoardUniversityID;
                    EmployeeServiceDetailsViewModel.SubjectForApproval = response.Entity.SubjectForApproval;
                    EmployeeServiceDetailsViewModel.GrantedPromotionDate = response.Entity.GrantedPromotionDate;
                    EmployeeServiceDetailsViewModel.GrantedPromotionDesignationID = response.Entity.GrantedPromotionDesignationID;
                    EmployeeServiceDetailsViewModel.GrantedPromotionLevel = response.Entity.GrantedPromotionLevel;
                    EmployeeServiceDetailsViewModel.CentreName = response.Entity.CentreName;
                    EmployeeServiceDetailsViewModel.CentreCode = response.Entity.CentreCode;
                    EmployeeServiceDetailsViewModel.OldCentreCode = response.Entity.OldCentreCode;
                    EmployeeServiceDetailsViewModel.IsActive = response.Entity.IsActive;
                    EmployeeServiceDetailsViewModel.IsCurrentFlag = response.Entity.IsCurrentFlag;



                }


                ViewData["PromotionDemotionFlag"] = new SelectList(li_EmpolyeeServiceDetail_PromotionDemotionFlag, "Value", "Text", EmployeeServiceDetailsViewModel.PromotionDemotionFlag);

                ViewData["AcceptedByEmployee"] = new SelectList(li_EmpolyeeServiceDetail_YesNo, "Value", "Text", EmployeeServiceDetailsViewModel.AcceptedByEmployee);

                ViewData["NatureOfAppointment"] = new SelectList(li_EmpolyeeServiceDetail_NatureOfAppoinment, "Value", "Text", EmployeeServiceDetailsViewModel.NatureOfAppointment);

                ViewData["UniversityApprovalType"] = new SelectList(li_EmpolyeeServiceDetail_UniversityApprovalType, "Value", "Text", EmployeeServiceDetailsViewModel.UniversityApprovalType);

                ViewData["GrantedPromotionLevel"] = new SelectList(li_EmpolyeeServiceDetail_GrantedPromotionLevel, "Value", "Text", EmployeeServiceDetailsViewModel.GrantedPromotionLevel);


                //--------------------------------------For Deaprtment list---------------------------------//
                if (EmployeeServiceDetailsViewModel.CentreCode != null)
                {
                    List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster(EmployeeServiceDetailsViewModel.CentreCode);
                    List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                    foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
                    {
                        organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                    }
                    ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text");
                }
                else
                {
                    List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster(null);
                    List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                    foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
                    {
                        organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                    }
                    ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text");
                }


                return View("/Views/Employee/EmployeeInformation/EmployeeServiceDetailsInfo.cshtml", EmployeeServiceDetailsViewModel);
                //return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        // Get data for New entry of Service details
        [HttpGet]
        public ActionResult EmployeeServiceDetailsEdit(int EmployeeID)
        {
            EmployeeServiceDetailsViewModel EmployeeServiceDetailsViewModel = new EmployeeServiceDetailsViewModel();
            try
            {
                EmployeeServiceDetailsViewModel.EmployeeID = EmployeeID;

                List<SelectListItem> EmployeeServiceDetails_YesNo = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_YesNo = new SelectList(EmployeeServiceDetails_YesNo, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_YesNo = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = "No", Value = "N" });
                li_EmpolyeeServiceDetail_YesNo.Add(new SelectListItem { Text = "Yes", Value = "Y" });
                //    ViewData["YesNo"] = li_EmpolyeeServiceDetail_YesNo;

                List<SelectListItem> EmployeeServiceDetails_PromotionDemotionFlag = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_PromotionDemotionFlag = new SelectList(EmployeeServiceDetails_PromotionDemotionFlag, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_PromotionDemotionFlag = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Promotion", Value = "P" });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Demotion", Value = "D" });
                li_EmpolyeeServiceDetail_PromotionDemotionFlag.Add(new SelectListItem { Text = "Transfer", Value = "T" });
                //   ViewData["PromotionDemotionFlag"] = li_EmpolyeeServiceDetail_PromotionDemotionFlag;

                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> _organisationStudyCentreMaster = GetListOrgStudyCentreMaster();
                List<SelectListItem> organisationStudyCentreMasterList = new List<SelectListItem>();
                foreach (OrganisationStudyCentreMaster item in _organisationStudyCentreMaster)
                {
                    organisationStudyCentreMasterList.Add(new SelectListItem { Text = item.CentreName, Value = item.CentreCode.ToString() });
                }
                ViewBag.organisationStudyCentreMasterList = new SelectList(organisationStudyCentreMasterList, "Value", "Text");


                //--------------------------------------For Designation list---------------------------------//
                List<EmpDesignationMaster> empDesignationMasterList = GetListEmpDesignationMaster();
                List<SelectListItem> empDesignationMaster = new List<SelectListItem>();
                foreach (EmpDesignationMaster item in empDesignationMasterList)
                {
                    empDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.EmpDesignationMaster = new SelectList(empDesignationMaster, "Value", "Text");

                //--------------------------------------For Nature of appointment list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_NatureOfAppoinment = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_NatureOfAppoinment = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "TEMPORARY" });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "PERMANANT" });
                li_EmpolyeeServiceDetail_NatureOfAppoinment.Add(new SelectListItem { Text = "VISITING", Value = "VISITING" });
                //   ViewData["NatureOfAppoinmentList"] = li_EmpolyeeServiceDetail_NatureOfAppoinment;


                //--------------------------------------For University Approval type list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_UniversityApprovalType = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_UniversityApprovalType = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_TEMPORARY, Value = "TEMPORARY" });
                li_EmpolyeeServiceDetail_UniversityApprovalType.Add(new SelectListItem { Text = Resources.DisplayName_PERMANANT, Value = "PERMANANT" });
                //  ViewData["UniversityApprovalType"] = li_EmpolyeeServiceDetail_UniversityApprovalType;


                //--------------------------------------For Granted Promotion level list---------------------------------//
                List<SelectListItem> EmployeeServiceDetails_GrantedPromotionLevel = new List<SelectListItem>();
                ViewBag.EmpolyeeServiceDetail_NatureOfAppoinment = new SelectList(EmployeeServiceDetails_NatureOfAppoinment, "Value", "Text");
                List<SelectListItem> li_EmpolyeeServiceDetail_GrantedPromotionLevel = new List<SelectListItem>();
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = "UNIVERSITY", Value = "UNIVERSITY" });
                li_EmpolyeeServiceDetail_GrantedPromotionLevel.Add(new SelectListItem { Text = "INSTITUTE", Value = "INSTITUTE" });
                //     ViewData["GrantedPromotionLevel"] = li_EmpolyeeServiceDetail_GrantedPromotionLevel;


                //--------------------------------------For University/Board list---------------------------------//
                //List<GeneralBoardUniversityMaster> _generalBoardUniversityMaster = GetListGeneralBoardUniversityMaster();
                //List<SelectListItem> generalBoardUniversityMasterList = new List<SelectListItem>();
                //foreach (GeneralBoardUniversityMaster item in _generalBoardUniversityMaster)
                //{
                //    generalBoardUniversityMasterList.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                //}
                //ViewBag.generalBoardUniversityMasterList = new SelectList(generalBoardUniversityMasterList, "Value", "Text");


                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ConnectionString = _connectioString;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.EmployeeID = EmployeeID;
                IBaseEntityResponse<EmployeeServiceDetails> response = _employeeServiceDetailsBA.SelectByEmployeeID(EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO);
                if (response.Entity != null && response.Entity.IsCurrentFlag == true)
                {
                    EmployeeServiceDetailsViewModel.ID = response.Entity.ID;
                    EmployeeServiceDetailsViewModel.EmployeeID = response.Entity.EmployeeID;
                    EmployeeServiceDetailsViewModel.CurrentID = response.Entity.ID;
                    EmployeeServiceDetailsViewModel.OrderNumber = response.Entity.OrderNumber;
                    EmployeeServiceDetailsViewModel.OrderDate = response.Entity.OrderDate;
                    EmployeeServiceDetailsViewModel.AcceptedByEmployee = response.Entity.AcceptedByEmployee;
                    EmployeeServiceDetailsViewModel.PromotionDemotionFlag = response.Entity.PromotionDemotionFlag;
                    EmployeeServiceDetailsViewModel.PromotionDemotionDate = response.Entity.PromotionDemotionDate;
                    EmployeeServiceDetailsViewModel.PreviousPromotionDemotionDate = response.Entity.PreviousPromotionDemotionDate;
                    EmployeeServiceDetailsViewModel.EmployeeDesignationMasterID = response.Entity.EmployeeDesignationMasterID;
                    EmployeeServiceDetailsViewModel.DepartmentID = response.Entity.DepartmentID;
                    EmployeeServiceDetailsViewModel.ChargeTakingDate = response.Entity.ChargeTakingDate;
                    EmployeeServiceDetailsViewModel.OldDesignationID = response.Entity.OldDesignationID;
                    EmployeeServiceDetailsViewModel.OldDepartmentID = response.Entity.OldDepartmentID;
                    EmployeeServiceDetailsViewModel.OldDepartmentName = response.Entity.OldDepartmentName;
                    EmployeeServiceDetailsViewModel.CollegeApprovalDate = response.Entity.CollegeApprovalDate;
                    EmployeeServiceDetailsViewModel.UniversityApprovalDate = response.Entity.UniversityApprovalDate;
                    EmployeeServiceDetailsViewModel.CollegeApprovalNumber = response.Entity.CollegeApprovalNumber;
                    EmployeeServiceDetailsViewModel.UniversityApprovalNumber = response.Entity.UniversityApprovalNumber;
                    EmployeeServiceDetailsViewModel.NatureOfDuty = response.Entity.NatureOfDuty;
                    EmployeeServiceDetailsViewModel.BasicAmount = response.Entity.BasicAmount;
                    EmployeeServiceDetailsViewModel.ApprovedBy = response.Entity.ApprovedBy;
                    EmployeeServiceDetailsViewModel.NewGrade = response.Entity.NewGrade;
                    EmployeeServiceDetailsViewModel.NewPayscaleID = response.Entity.NewPayscaleID;
                    EmployeeServiceDetailsViewModel.NatureOfAppointment = response.Entity.NatureOfAppointment;
                    EmployeeServiceDetailsViewModel.UniversityApprovalType = response.Entity.UniversityApprovalType;
                    EmployeeServiceDetailsViewModel.GeneralBoardUniversityID = response.Entity.GeneralBoardUniversityID;
                    EmployeeServiceDetailsViewModel.SubjectForApproval = response.Entity.SubjectForApproval;
                    EmployeeServiceDetailsViewModel.GrantedPromotionDate = response.Entity.GrantedPromotionDate;
                    EmployeeServiceDetailsViewModel.GrantedPromotionDesignationID = response.Entity.GrantedPromotionDesignationID;
                    EmployeeServiceDetailsViewModel.GrantedPromotionLevel = response.Entity.GrantedPromotionLevel;
                    EmployeeServiceDetailsViewModel.CentreName = response.Entity.CentreName;
                    EmployeeServiceDetailsViewModel.CentreCode = response.Entity.CentreCode;
                    EmployeeServiceDetailsViewModel.OldCentreCode = response.Entity.OldCentreCode;
                    EmployeeServiceDetailsViewModel.IsActive = response.Entity.IsActive;
                    EmployeeServiceDetailsViewModel.IsCurrentFlag = response.Entity.IsCurrentFlag;



                }



                ViewData["PromotionDemotionFlag"] = new SelectList(li_EmpolyeeServiceDetail_PromotionDemotionFlag, "Value", "Text", EmployeeServiceDetailsViewModel.PromotionDemotionFlag);

                ViewData["AcceptedByEmployee"] = new SelectList(li_EmpolyeeServiceDetail_YesNo, "Value", "Text", EmployeeServiceDetailsViewModel.AcceptedByEmployee);

                ViewData["NatureOfAppointment"] = new SelectList(li_EmpolyeeServiceDetail_NatureOfAppoinment, "Value", "Text", EmployeeServiceDetailsViewModel.NatureOfAppointment);

                ViewData["UniversityApprovalType"] = new SelectList(li_EmpolyeeServiceDetail_UniversityApprovalType, "Value", "Text", EmployeeServiceDetailsViewModel.UniversityApprovalType);

                ViewData["GrantedPromotionLevel"] = new SelectList(li_EmpolyeeServiceDetail_GrantedPromotionLevel, "Value", "Text", EmployeeServiceDetailsViewModel.GrantedPromotionLevel);

                //--------------------------------------For Deaprtment list---------------------------------//
                if (EmployeeServiceDetailsViewModel.CentreCode != null)
                {
                    List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster(EmployeeServiceDetailsViewModel.CentreCode);
                    List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                    foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
                    {
                        organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                    }
                    ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text");
                }
                else
                {
                    List<OrganisationDepartmentMaster> _organisationDepartmentMaster = GetListOrganisationDepartmentMaster(null);
                    List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                    foreach (OrganisationDepartmentMaster item in _organisationDepartmentMaster)
                    {
                        organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                    }
                    ViewBag.organisationDepartmentMasterList = new SelectList(organisationDepartmentMasterList, "Value", "Text");
                }


                return View("/Views/Employee/EmployeeInformation/EmployeeServiceDetailsEdit.cshtml", EmployeeServiceDetailsViewModel);
                //return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        // Post data for New entry of Service details either Promotion/Demotion update
        [HttpPost]
        public ActionResult EmployeeServiceDetailsEdit(EmployeeServiceDetailsViewModel EmployeeServiceDetailsViewModel)
        {

            try
            {
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ID = EmployeeServiceDetailsViewModel.ID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.EmployeeID = EmployeeServiceDetailsViewModel.EmployeeID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OrderNumber = EmployeeServiceDetailsViewModel.OrderNumber;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OrderDate = EmployeeServiceDetailsViewModel.OrderDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.AcceptedByEmployee = EmployeeServiceDetailsViewModel.AcceptedByEmployee;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.PromotionDemotionFlag = EmployeeServiceDetailsViewModel.PromotionDemotionFlag;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.PromotionDemotionDate = EmployeeServiceDetailsViewModel.PromotionDemotionDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.PreviousPromotionDemotionDate = EmployeeServiceDetailsViewModel.PreviousPromotionDemotionDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.EmployeeDesignationMasterID = EmployeeServiceDetailsViewModel.EmployeeDesignationMasterID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.DepartmentID = EmployeeServiceDetailsViewModel.DepartmentID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ChargeTakingDate = EmployeeServiceDetailsViewModel.ChargeTakingDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OldDesignationID = EmployeeServiceDetailsViewModel.OldDesignationID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OldDepartmentID = EmployeeServiceDetailsViewModel.OldDepartmentID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OldDepartmentName = EmployeeServiceDetailsViewModel.OldDepartmentName;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CollegeApprovalDate = EmployeeServiceDetailsViewModel.CollegeApprovalDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.UniversityApprovalDate = EmployeeServiceDetailsViewModel.UniversityApprovalDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CollegeApprovalNumber = EmployeeServiceDetailsViewModel.CollegeApprovalNumber;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.UniversityApprovalNumber = EmployeeServiceDetailsViewModel.UniversityApprovalNumber;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.NatureOfDuty = EmployeeServiceDetailsViewModel.NatureOfDuty;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.BasicAmount = EmployeeServiceDetailsViewModel.BasicAmount;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ApprovedBy = EmployeeServiceDetailsViewModel.ApprovedBy;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.NewGrade = EmployeeServiceDetailsViewModel.NewGrade;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.NewPayscaleID = EmployeeServiceDetailsViewModel.NewPayscaleID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.NatureOfAppointment = EmployeeServiceDetailsViewModel.NatureOfAppointment;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.UniversityApprovalType = EmployeeServiceDetailsViewModel.UniversityApprovalType;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.GeneralBoardUniversityID = EmployeeServiceDetailsViewModel.GeneralBoardUniversityID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.SubjectForApproval = EmployeeServiceDetailsViewModel.SubjectForApproval;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.GrantedPromotionDate = EmployeeServiceDetailsViewModel.GrantedPromotionDate;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.GrantedPromotionDesignationID = EmployeeServiceDetailsViewModel.GrantedPromotionDesignationID;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.GrantedPromotionLevel = EmployeeServiceDetailsViewModel.GrantedPromotionLevel;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CentreName = EmployeeServiceDetailsViewModel.CentreName;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CentreCode = EmployeeServiceDetailsViewModel.CentreCode;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.OldCentreCode = EmployeeServiceDetailsViewModel.OldCentreCode;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.IsActive = EmployeeServiceDetailsViewModel.IsActive;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.IsCurrentFlag = true;
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EmployeeServiceDetails> response = _employeeServiceDetailsBA.UpdateEmployeeServiceDetails(EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO);
                EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(EmployeeServiceDetailsViewModel.EmployeeServiceDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        //[HttpGet]
        //public ActionResult EmployeeLanguageDetails(int EmployeeID)
        //{
        //    EmployeeLanguageDetailsViewModel employeeLanguageDetailsViewModel = new EmployeeLanguageDetailsViewModel();
        //    try
        //    {
        //        employeeLanguageDetailsViewModel.EmployeeID = EmployeeID;

        //        return View("/Views/Employee/EmployeeInformation/EmployeeLanguageDetails.cshtml", employeeLanguageDetailsViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult EmpEmployeeLanguageDetails(int EmployeeID, string SelectedIDs)
        //{
        //    EmployeeLanguageDetailsViewModel employeeLanguageDetailsViewModel = new EmployeeLanguageDetailsViewModel();
        //    try
        //    {
        //        employeeLanguageDetailsViewModel.EmployeeLanguageDetailsDTO.EmployeeID = EmployeeID;
        //        employeeLanguageDetailsViewModel.EmployeeLanguageDetailsDTO.SelectedIDs = SelectedIDs;
        //        employeeLanguageDetailsViewModel.EmployeeLanguageDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
        //        employeeLanguageDetailsViewModel.EmployeeLanguageDetailsDTO.ConnectionString = _connectioString;
        //        IBaseEntityResponse<EmployeeLanguageDetails> response = _employeeLanguageDetailsServiceAccess.InsertEmployeeLanguageDetails(employeeLanguageDetailsViewModel.EmployeeLanguageDetailsDTO);
        //        employeeLanguageDetailsViewModel.EmployeeLanguageDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //        return Json(employeeLanguageDetailsViewModel.EmployeeLanguageDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //    //return Redirect("/EmployeeInformation/PersonalInformationHome/" + empEmployeeMastermodel);
        //}

        [HttpGet]
        public ActionResult _ChangePassword(int ID)
        {
            try
            {
                EmpEmployeeMasterViewModel empEmployeeMastermodel = new EmpEmployeeMasterViewModel();
                //model.ID = ID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = ID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.GetCurrentPassword(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    empEmployeeMastermodel.EmpEmployeeMasterDTO.Password = response.Entity.Password;
                }

                return View("/Views/Employee/EmployeeInformation/ChangePassword.cshtml", empEmployeeMastermodel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult _ChangePasswordV2(int ID)
        {
            try
            {
                EmpEmployeeMasterViewModel empEmployeeMastermodel = new EmpEmployeeMasterViewModel();
                //model.ID = ID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = ID;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.GetCurrentPassword(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    empEmployeeMastermodel.EmpEmployeeMasterDTO.Password = response.Entity.Password;
                }

                return View("/Views/Employee/EmployeeInformation/ChangePasswordV2.cshtml", empEmployeeMastermodel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult _ChangePassword(EmpEmployeeMasterViewModel empEmployeeMastermodel)
        {
            try
            {

                empEmployeeMastermodel.EmpEmployeeMasterDTO.NewPassword = empEmployeeMastermodel.NewPassword;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = Convert.ToInt32(Session["UserId"]);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.InsertNewPassword(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + empEmployeeMastermodel);
        }

        [HttpPost]
        public ActionResult _ChangePasswordV2(EmpEmployeeMasterViewModel empEmployeeMastermodel)
        {
            try
            {

                empEmployeeMastermodel.EmpEmployeeMasterDTO.NewPassword = empEmployeeMastermodel.NewPassword;
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = Convert.ToInt32(Session["UserId"]);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.InsertNewPassword(empEmployeeMastermodel.EmpEmployeeMasterDTO);
                empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(empEmployeeMastermodel.EmpEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + empEmployeeMastermodel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCentrewiseDepartmentByCentreCode(string CentreCode)
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
            var departments = GetListOrganisationDepartmentMaster(CentreCode);
            var result = (from s in departments
                          select new
                          {
                              id = s.CentrewiseDepartmentID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDepartmentByCentreCode(string CentreCode)
        {
            if (CentreCode.Contains(':'))
            {
                string[] splited;
                splited = CentreCode.Split(':');

                // _adminSnPostsBaseViewModel.SelectedCentreName = splited[1];
                CentreCode = splited[0];
            }

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

        [HttpPost]
        public ActionResult Create(EmpEmployeeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmpEmployeeMasterDTO != null)
                    {
                        model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                        //  model.EmpEmployeeMasterDTO.ExperienceTypeDescription = model.ExperienceTypeDescription;
                        model.EmpEmployeeMasterDTO.IsActive = model.IsActive;
                        model.EmpEmployeeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.InsertEmpEmployeeMaster(model.EmpEmployeeMasterDTO);
                        model.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.EmpEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            try
            {
                model.EmpEmployeeMasterDTO = new EmpEmployeeMaster();
                model.EmpEmployeeMasterDTO.ID = id;
                model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.SelectByID(model.EmpEmployeeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmpEmployeeMasterDTO.ID = response.Entity.ID;
                    // model.EmpEmployeeMasterDTO.ExperienceTypeDescription = response.Entity.ExperienceTypeDescription;
                    model.EmpEmployeeMasterDTO.IsActive = response.Entity.IsActive;
                    model.EmpEmployeeMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmpEmployeeMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.EmpEmployeeMasterDTO != null)
                {
                    if (model != null && model.EmpEmployeeMasterDTO != null)
                    {
                        model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                        // model.EmpEmployeeMasterDTO.ExperienceTypeDescription = model.ExperienceTypeDescription;
                        model.EmpEmployeeMasterDTO.IsActive = model.IsActive;
                        model.EmpEmployeeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.UpdateEmpEmployeeMaster(model.EmpEmployeeMasterDTO);
                        model.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EmpEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            model.EmpEmployeeMasterDTO = new EmpEmployeeMaster();
            model.EmpEmployeeMasterDTO.ID = ID;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(EmpEmployeeMasterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    EmpEmployeeMaster EmpEmployeeMasterDTO = new EmpEmployeeMaster();
                    EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                    EmpEmployeeMasterDTO.ID = model.ID;
                    EmpEmployeeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.DeleteEmpEmployeeMaster(EmpEmployeeMasterDTO);
                    model.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.EmpEmployeeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //-----Code Releated to Export Excel file with data------
        public FileResult DownloadExcel(string CentreCode)
        {

            string FileName = "EmployeeMasterExcelUpload.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelFile(filePath);
            InsertExcelFile(filePath, CentreCode);
            string contentType = "application/vnd.ms-excel";
           // string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }
        public void CreateExcelFile(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Employee Details" };
                EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
                model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                model.EmpEmployeeMasterDTO.ExcelSheetName = "Employee Details";
                sheets.Append(sheet);
               // WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
               //// stylesPart.Stylesheet = GenerateStyleSheet();
               // stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }
        public void InsertExcelFile(string fileName,string CentreCode)
        {
            string[] HeaderData = new string[] { "Sr. No.", "Employee ID No.", "Name", "Working field", "Location", " Qualification","Designation", "Re Designation", "Dept", "Cader", "Gross  Earnings", "DOJ", "DOT", "DOL", "DOB", "Mobile No. ", "A/c No.", "BANK IFSC CODE", "PAN", "ADHAR", "ESIC", "PF", "UAN", "Marital Status","Gender" , "Date from", "Date To","Education type", "Institute", "Major" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F","G",",H","I","J","K","L","M","N","O","P","Q","R","S" };
            InsertTextInExcel(fileName, "", "A", 1);
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
            ESICMonthlyUploadingFileViewModel model = new ESICMonthlyUploadingFileViewModel();
            //uint index = 3;
            //model.ESICMonthlyUploadingFileList = GetESICMonthlyUploadingFileList(MonthName, MonthYear);
            //if (model.ESICMonthlyUploadingFileList.Count > 0)
            //{
            //    for (int i = 0; i < model.ESICMonthlyUploadingFileList.Count; i++)
            //    {
            //        InsertTextInExcel(fileName, model.ESICMonthlyUploadingFileList[i].ESICNumber, "A", index);
            //        InsertTextInExcel(fileName, model.ESICMonthlyUploadingFileList[i].EmployeeName, "B", index);
            //        InsertTextInExcel(fileName, Convert.ToString(model.ESICMonthlyUploadingFileList[i].WorkingDays), "C", index);
            //        InsertTextInExcel(fileName, Convert.ToString(model.ESICMonthlyUploadingFileList[i].TotalAmountofWages), "D", index);

            //        index++;
            //    }
            //}
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<EmpEmployeeMasterViewModel> GetEmpEmployeeMaster(out int TotalRecords, string CentreCode, string EntityLevel, string AdminRoleMasterID)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
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
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.EntityLevel = EntityLevel;
                    searchRequest.AdminRoleMasterID = AdminRoleMasterID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.EntityLevel = EntityLevel;
                    searchRequest.AdminRoleMasterID = AdminRoleMasterID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
                searchRequest.EntityLevel = EntityLevel;
                searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            }
            List<EmpEmployeeMasterViewModel> listEmpEmployeeMasterViewModel = new List<EmpEmployeeMasterViewModel>();
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmpEmployeeMaster item in listEmpEmployeeMaster)
                    {
                        EmpEmployeeMasterViewModel EmpEmployeeMasterViewModel = new EmpEmployeeMasterViewModel();
                        EmpEmployeeMasterViewModel.EmpEmployeeMasterDTO = item;
                        listEmpEmployeeMasterViewModel.Add(EmpEmployeeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmpEmployeeMasterViewModel;
        }

        //public IEnumerable<EmployeeLanguageDetailsViewModel> GetEmployeeLanguageDetails(int EmployeeID, out int TotalRecords)
        //{
        //    EmployeeLanguageDetailsSearchRequest searchRequest = new EmployeeLanguageDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.EmployeeID = EmployeeID;
        //    _actionMode = Convert.ToString(TempData["ActionMode"]);
        //    if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
        //    {
        //        if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
        //        {
        //            searchRequest.SortBy = "CreatedDate";
        //            searchRequest.StartRow = 0;
        //            searchRequest.EndRow = 10;
        //            searchRequest.SearchBy = string.Empty;
        //            searchRequest.SortDirection = "Desc";
        //        }
        //        if (actionModeEnum == ActionModeEnum.Update)
        //        {
        //            searchRequest.SortBy = "ModifiedDate";
        //            searchRequest.StartRow = 0;
        //            searchRequest.EndRow = 10;
        //            searchRequest.SearchBy = string.Empty;
        //            searchRequest.SortDirection = "Desc";
        //        }
        //    }
        //    else
        //    {
        //        searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
        //        searchRequest.StartRow = _startRow;
        //        searchRequest.EndRow = _startRow + _rowLength;
        //        searchRequest.SearchBy = _searchBy;
        //        searchRequest.SortDirection = _sortDirection;
        //    }
        //    List<EmployeeLanguageDetailsViewModel> listEmployeeLanguageDetailsViewModel = new List<EmployeeLanguageDetailsViewModel>();
        //    List<EmployeeLanguageDetails> listEmployeeLanguageDetails = new List<EmployeeLanguageDetails>();
        //    IBaseEntityCollectionResponse<EmployeeLanguageDetails> baseEntityCollectionResponse = _employeeLanguageDetailsServiceAccess.GetEmployeeLanguageDetailsByID(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeLanguageDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //            foreach (EmployeeLanguageDetails item in listEmployeeLanguageDetails)
        //            {
        //                EmployeeLanguageDetailsViewModel employeeLanguageDetailsViewModel = new EmployeeLanguageDetailsViewModel();
        //                employeeLanguageDetailsViewModel.EmployeeLanguageDetailsDTO = item;
        //                listEmployeeLanguageDetailsViewModel.Add(employeeLanguageDetailsViewModel);
        //            }
        //        }
        //    }
        //    TotalRecords = baseEntityCollectionResponse.TotalRecords;
        //    return listEmployeeLanguageDetailsViewModel;
        //}


        public IEnumerable<EmployeeServiceDetailsViewModel> GetEmployeeServiceDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeeServiceDetailsSearchRequest searchRequest = new EmployeeServiceDetailsSearchRequest();
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
            List<EmployeeServiceDetailsViewModel> listEmployeeServiceDetailsViewModel = new List<EmployeeServiceDetailsViewModel>();
            List<EmployeeServiceDetails> listEmployeeServiceDetails = new List<EmployeeServiceDetails>();
            IBaseEntityCollectionResponse<EmployeeServiceDetails> baseEntityCollectionResponse = _employeeServiceDetailsBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeServiceDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeServiceDetails item in listEmployeeServiceDetails)
                    {
                        EmployeeServiceDetailsViewModel employeeServiceDetailsViewModel = new EmployeeServiceDetailsViewModel();
                        employeeServiceDetailsViewModel.EmployeeServiceDetailsDTO = item;
                        listEmployeeServiceDetailsViewModel.Add(employeeServiceDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeServiceDetailsViewModel;
        }

        [NonAction]
        protected List<EmpEmployeeMaster> GetEmployeeList(string SearchKeyWord)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;

            List<EmpEmployeeMaster> listEmployees = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterBA.GetEmployeeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployees = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployees;
        }
        public static void InsertTextInExcel(string docName, string text, string Columns, uint rowID)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the text into the SharedStringTablePart.
                int index = InsertSharedStringItem(text, shareStringPart);

                // Insert a new worksheet.
                //WorksheetPart worksheetPart = InsertWorksheet(spreadSheet.WorkbookPart);

                Sheet sheet = spreadSheet.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                //Get the Worksheet instance.s
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;

                // Insert cell A1 into the new worksheet.
                Cell cell = InsertCellInWorksheet(Columns, rowID, worksheetPart);


                // Set the value of cell A1.
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);


                if (cell.CellReference.Value == "A1" || cell.CellReference.Value == "B1" || cell.CellReference.Value == "C1" || cell.CellReference.Value == "D1" || cell.CellReference.Value == "E1" || cell.CellReference.Value == "F1")
                {
                    cell.StyleIndex = 5;
                }

                // Save the new worksheet.
                
                worksheetPart.Worksheet.Save();
            }
        }


        [HttpGet]
        public ActionResult UploadEmployeeExcel(string centreCode)
        {
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            model.CentreCode = centreCode;
            model.ListGetOrganisationDepartmentCentreAndDepartmentWise = GetListOrganisationDepartmentMaster(centreCode);
            return PartialView("/Views/Employee/EmployeeInformation/UploadEmployeeExcel.cshtml", model);
        }

        [HttpPost]
        public ActionResult UploadEmployeeExcel(EmpEmployeeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.EmpEmployeeMasterDTO != null)
                {
                    UploadExcelForEmployeeAttendence();

                    model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                    model.EmpEmployeeMasterDTO.DepartmentID = model.DepartmentID;
                    model.EmpEmployeeMasterDTO.XMLString = xmlParameter;
                    model.EmpEmployeeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.InsertEmployeeMasterExcelUpload(model.EmpEmployeeMasterDTO);

                        model.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert); ;
                    }
                    else if (IsExcelValid == false)
                    {
                        model.EmpEmployeeMasterDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.EmpEmployeeMasterDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.EmpEmployeeMasterDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "EmployeeInformation");
                    //return Json(model.VendorMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                //  }
                else
                {
                    return Json("Please review your form");
                }


            }
            catch (Exception ex)
            {
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "EmployeeInformation");
            }
        }
        [HttpGet]
        public ActionResult DownloadEmployeeMasterExcel(string centreCode)
        {
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            List<SelectListItem> Details = new List<SelectListItem>();
            ViewBag.Details = new SelectList(Details, "Value", "Text");
            List<SelectListItem> li_Details = new List<SelectListItem>();

            li_Details.Add(new SelectListItem { Text = "Basic Details", Value = "0" });
            li_Details.Add(new SelectListItem { Text = "Family Details", Value = "1" });
                li_Details.Add(new SelectListItem { Text = "Education Details", Value = "2" });
                li_Details.Add(new SelectListItem { Text = "Experince Details", Value = "3" });
                li_Details.Add(new SelectListItem { Text = "Contact Details", Value = "4" });
                ViewData["Details"] = li_Details;
            
             model.CentreCode = centreCode;
            // model.ListGetOrganisationDepartmentCentreAndDepartmentWise = GetListOrganisationDepartmentMaster(centreCode);
            return PartialView("/Views/Employee/EmployeeInformation/DownloadEmployeeMasterExcel.cshtml", model);
        }
        [HttpPost]
        public ActionResult DownloadEmployeeMasterExcel(EmpEmployeeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.EmpEmployeeMasterDTO != null)
                {
                    //UploadExcelForEmployeeAttendence();

                    model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                    model.EmpEmployeeMasterDTO.CentreCode = model.CentreCode;
                    //model.EmpEmployeeMasterDTO.XMLString = xmlParameter;
                    model.EmpEmployeeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    //if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    //{
                    //    IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.InsertEmployeeMasterExcelUpload(model.EmpEmployeeMasterDTO);

                    //    model.EmpEmployeeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert); ;
                    //}
                    //else if (IsExcelValid == false)
                    //{
                    //    model.EmpEmployeeMasterDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    //}
                    //else if (xmlParameter == string.Empty || xmlParameter != null)
                    //{
                    //    model.EmpEmployeeMasterDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    //}

                    TempData["_errorMsg"] = model.EmpEmployeeMasterDTO.errorMessage;
                  //  xmlParameter = null;
                 //   IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "EmployeeInformation");
                    //return Json(model.VendorMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                //  }
                else
                {
                    return Json("Please review your form");
                }


            }
            catch (Exception ex)
            {
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "EmployeeInformation");
            }
        }
        #endregion

        public void UploadExcelForEmployeeAttendence()
        {
            string _ExcelFileXML = string.Empty;
            //   string XMLstring = string.Empty;
            var _comPath = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var ExcelFile = System.Web.HttpContext.Current.Request.Files["ExcelFile"];

                if (ExcelFile.ContentLength > 0)
                {
                    string extension = System.IO.Path.GetExtension(ExcelFile.FileName);
                    if (extension == ".xlsx")
                    {
                        _comPath = Server.MapPath("~") + "Content\\UploadedFiles\\UplodedExcel\\";
                        var myUniqueFileName = Guid.NewGuid();
                        string filePath = String.Concat(myUniqueFileName, ExcelFile.FileName);
                        filePath = string.Format("{0}{1}", _comPath, filePath);
                        if (!Directory.Exists(_comPath))
                        {
                            Directory.CreateDirectory(_comPath);
                        }
                        if (System.IO.File.Exists(filePath))
                            System.IO.File.Delete(filePath);

                        ExcelFile.SaveAs(filePath);
                        OpenXmlValidator validator = new OpenXmlValidator();

                        int count = 0;
                        foreach (ValidationErrorInfo error in validator.Validate(SpreadsheetDocument.Open(filePath, false)))
                        {
                            count++;
                        }
                        if (count <= 0)
                        {
                            xmlParameter = "<rows>";
                            //Open the Excel file in Read Mode using OpenXml.
                            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                            {
                                //Read the first Sheet from Excel file.
                                Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                                //Get the Worksheet instance.
                                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                                //Fetch all the rows present in the Worksheet.
                                // IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                                SheetData rows = worksheet.GetFirstChild<SheetData>();

                                System.Data.DataTable dt = new System.Data.DataTable();
                                //Loop through the Worksheet rows.
                                foreach (Cell cell in rows.ElementAt(0))
                                {
                                    if (
                                            // (GetCellValue(doc, cell)) == "" ||

                                            (GetCellValue(doc, cell)) == "Title" ||
                                        (GetCellValue(doc, cell)) == "First Name" ||
                                        (GetCellValue(doc, cell)) == "Middle Name" ||
                                        (GetCellValue(doc, cell)) == "Last Name" ||
                                         (GetCellValue(doc, cell)) == "Gender" ||
                                        (GetCellValue(doc, cell)) == "Employee Code" ||
                                         (GetCellValue(doc, cell)) == "Email Address" ||
                                        (GetCellValue(doc, cell)) == "Designation" ||
                                        (GetCellValue(doc, cell)) == "Birth Date"
                                       )
                                    {
                                        dt.Columns.Add(GetCellValue(doc, cell));
                                    }
                                    else
                                    {
                                        IsExcelValid = false;
                                        errorMessage = "Invalid excel column,warning";
                                        break;

                                    }

                                }

                                if ((IsExcelValid == true))
                                {

                                    //foreach (Cell cell in rows.ElementAt(1))
                                    //{
                                    //    dt.Columns.Add(GetCellValue(doc, cell));
                                    //}
                                    foreach (Row row in rows)
                                    {
                                        DataRow tempRow = dt.NewRow();
                                        int columnIndex = 0;
                                        foreach (Cell cell in row.Descendants<Cell>())
                                        {
                                            // Gets the column index of the cell with data

                                            int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));

                                            cellColumnIndex--; //zero based index
                                            if (columnIndex < cellColumnIndex)
                                            {
                                                do
                                                {
                                                    tempRow[columnIndex] = ""; //Insert blank data here;
                                                    columnIndex++;
                                                }
                                                while (columnIndex < cellColumnIndex);
                                            }
                                            tempRow[columnIndex] = GetCellValue(doc, cell);

                                            columnIndex++;
                                        }
                                        dt.Rows.Add(tempRow);
                                    }
                                    dt.Rows.RemoveAt(0); //...so i'm taking it out here.

                                    RemoveDuplicateRows(dt, "Employee Code");


                                    if (extension == ".xls" || extension == ".xlsx")
                                    {
                                        if (dt.Columns[0].ColumnName != "Title" ||
                                            dt.Columns[1].ColumnName != "First Name" ||
                                            dt.Columns[2].ColumnName != "Middle Name" ||
                                            dt.Columns[3].ColumnName != "Last Name" ||
                                            dt.Columns[4].ColumnName != "Gender" ||
                                            dt.Columns[5].ColumnName != "Employee Code" ||
                                            dt.Columns[6].ColumnName != "Email Address" ||
                                            dt.Columns[7].ColumnName != "Designation" ||
                                            dt.Columns[8].ColumnName != "Birth Date")
                                        {
                                            IsExcelValid = false;
                                            errorMessage = "Invalid excel column,warning";
                                        }
                                    }
                                    if (IsExcelValid == true)
                                    {
                                        long result;


                                        //while (dReader.Read())
                                        for (int i = 0; i < (dt.Rows.Count); i++)
                                        {

                                            if (dt.Rows[i]["Title"].ToString().Trim().Length >= 1 || dt.Rows[i]["First Name"].ToString().Trim().Length >= 1 || dt.Rows[i]["Middle Name"].ToString().Trim().Length >= 1 || dt.Rows[i]["Gender"].ToString().Trim().Length >= 1 || dt.Rows[i]["Employee Code"].ToString().Trim().Length >= 1 || dt.Rows[i]["Designation"].ToString().Trim().Length >= 1 || dt.Rows[i]["Birth Date"].ToString().Trim().Length >= 1 || dt.Rows[i]["Email Address"].ToString().Trim().Length >= 1)

                                            {

                                                string date = string.Empty;
                                                if (dt.Rows[i]["Birth Date"].ToString().Trim().Length >= 1)
                                                {
                                                    double d = double.Parse(dt.Rows[i]["Birth Date"].ToString());
                                                    DateTime conv = DateTime.FromOADate(d);
                                                    date = conv.ToString("yyyy-MM-dd");
                                                }
                                                 if (dt.Rows[i]["First Name"].ToString().Trim().Length < 1)
                                                {
                                                    xmlParameter = string.Empty;
                                                    FirstNameFlag = 1;
                                                    break;
                                                }
                                              
                                                 if (dt.Rows[i]["Employee Code"].ToString().Trim().Length < 1)
                                                {
                                                    xmlParameter = string.Empty;
                                                    EmployeeCodeFlag = 1;
                                                    errorMessage = "Please Insert Employee Code,warning";
                                                    break;
                                                }

                                                xmlParameter = xmlParameter + "<row><Title>" + dt.Rows[i]["Title"] + "</Title><FirstName>" + dt.Rows[i]["First Name"].ToString().Trim() + "</FirstName><MiddleName>" + dt.Rows[i]["Middle Name"].ToString().Trim() + "</MiddleName><LastName>" + dt.Rows[i]["Last Name"].ToString().Trim() + "</LastName><Gender>" + dt.Rows[i]["Gender"] + "</Gender><EmployeeCode>" + dt.Rows[i]["Employee Code"].ToString().Trim() + "</EmployeeCode><EmailAddress>" + dt.Rows[i]["Email Address"] + "</EmailAddress><Designation>" + dt.Rows[i]["Designation"].ToString().Trim() + "</Designation><BirthDate>" + date + "</BirthDate></row>";

                                            }
                                           

                                        }
                                    }
                                    if (xmlParameter.Length > 9)
                                    {
                                        xmlParameter = xmlParameter + "</rows>";
                                    }
                                    else
                                    {
                                        //if (EmpCodeFlag == 1)
                                        //{
                                        //    xmlParameter = string.Empty;
                                        //    errorMessage = "Please enter Emp Code,warning";
                                        //}
                                        //else
                                        if (FirstNameFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please enter First Name,warning";
                                        }

                                        else if (LastNameFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please enter Last Name,warning";
                                        }
                                        else if (EmployeeCodeFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please Select Employee Code,warning";
                                        }

                                        else
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "No data found in excel,warning";
                                        }

                                    }
                                }

                                else
                                {
                                    errorMessage = "The selected file does not appear to be an excel file,warning";
                                }
                                dt.Dispose();
                            }
                        }
                        else
                        {
                            errorMessage = "Excel file not selected,warning";
                        }
                    }
                    else
                    {
                        IsExcelValid = false;
                        errorMessage = "Please Upload Downloaded File,warning";
                    }

                    // excelConnection.Close();

                    // SQL Server Connection String

                }
                else
                {
                    IsExcelValid = false;
                    errorMessage = "Excel file not selected,warning";
                }
            }

        }


        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                //dTable.Rows.Remove(dRow);
                errorMessage = "Do not add same Data twice,#FFCC80";

            //Datatable which contains unique records will be return as output.

            return dTable;
        }


        public static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.

            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

        public static int? GetColumnIndexFromName(string columnName)
        {

            //return columnIndex;
            string name = columnName;
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }
            return number;
        }


        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return "";
            }
            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }



        #region Image methods
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        /// <summary>
        /// Gets the filename that is placed under a certain URL.
        /// </summary>
        /// <param name="url">The URL which should be investigated for a file name.</param>
        /// <returns>The file name.</returns>
        string GetUrlFileName(string url)
        {
            var parts = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var last = parts[parts.Length - 1];
            return Path.GetFileNameWithoutExtension(last);
        }

        /// <summary>
        /// Gets an image from the specified URL.
        /// </summary>
        /// <param name="url">The URL containing an image.</param>
        /// <returns>The image as a bitmap.</returns>
        Bitmap GetImageFromUrl(string url)
        {
            var buffer = 1024;
            Bitmap image = null;

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                return image;

            using (var ms = new MemoryStream())
            {
                var req = WebRequest.Create(url);

                using (var resp = req.GetResponse())
                {
                    using (var stream = resp.GetResponseStream())
                    {
                        var bytes = new byte[buffer];
                        var n = 0;

                        while ((n = stream.Read(bytes, 0, buffer)) != 0)
                            ms.Write(bytes, 0, n);
                    }
                }

                image = Bitmap.FromStream(ms) as Bitmap;
            }

            return image;
        }

        [HttpPost]
        public JsonResult GetEmployees(string term)
        {
            //var AdminRoleMasterID = Session["RoleID"].ToString();
            var data = GetEmployeeList(term);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.EmployeeFirstName + " " + r.EmployeeLastName,
                              //lastName=r.EmployeeLastName,
                              //personType = r.PersonType,
                              //subLedgerName = r.SubLedgerName,
                              //personId = r.PersonID,
                              //cashBankFlag = r.CashBankFlag
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        #endregion


        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string EntityLevel)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<EmpEmployeeMasterViewModel> filteredEmpEmployeeMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "DepartmentName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%' or A.DepartmentName Like '%" + param.sSearch + "%' or GenderCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "EmployeeCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%' or A.DepartmentID Like '%" + param.sSearch + "%'or GenderCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "DepartmentName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%' or A.DepartmentName Like '%" + param.sSearch + "%'or GenderCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "GenderCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%' or A.DepartmentID Like '%" + param.sSearch + "%'or GenderCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(CentreCode))
                {

                    string[] splitCentreCode = CentreCode.Split(':');
                    var centreCode = splitCentreCode[0];
                    var scopeIdentity = splitCentreCode[1];
                    var RoleID = "";
                    if (Session["UserType"].ToString() == "A")
                    {
                        RoleID = Convert.ToString(0);
                    }
                    else
                    {
                        RoleID = Session["RoleID"].ToString();
                    }
                    //centerCode = splitCentreCode[0];

                    filteredEmpEmployeeMaster = GetEmpEmployeeMaster(out TotalRecords, centreCode, EntityLevel, RoleID);
                }
                else
                {
                    filteredEmpEmployeeMaster = new List<EmpEmployeeMasterViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredEmpEmployeeMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.DepartmentID), Convert.ToString(c.EmployeeFirstName) + " " + Convert.ToString(c.EmployeeMiddleName) + " " + Convert.ToString(c.EmployeeLastName), Convert.ToString(c.EmployeeCode), Convert.ToString(c.DepartmentName), Convert.ToString(c.GenderCode), Convert.ToString(c.ID), Convert.ToString(c.DepartmentID), Convert.ToString(c.IsActive), Convert.ToString(c.IsLeave) };

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

        // AjaxHandlerEmpLanguageDetails Method
        //public ActionResult AjaxHandlerEmpLanguageDetails(JQueryDataTableParamModel param, int EmployeeID)
        //{

        //    int TotalRecords;
        //    var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
        //    string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

        //    IEnumerable<EmployeeLanguageDetailsViewModel> filteredEmployeeLanguageDetails;
        //    switch (Convert.ToInt32(sortColumnIndex))
        //    {
        //        case 0:
        //            _sortBy = "LanguageName";
        //            if (string.IsNullOrEmpty(param.sSearch))
        //            {
        //                _searchBy = string.Empty;
        //            }
        //            else
        //            {
        //                _searchBy = "LanguageName Like '%" + param.sSearch + "%' or Fluency Like '%" + param.sSearch + "%' or Competency Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
        //            }
        //            break;
        //        case 1:
        //            _sortBy = "Fluency";
        //            if (string.IsNullOrEmpty(param.sSearch))
        //            {
        //                _searchBy = string.Empty;
        //            }
        //            else
        //            {
        //                _searchBy = "LanguageName Like '%" + param.sSearch + "%' or Fluency Like '%" + param.sSearch + "%' or Competency Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
        //            }
        //            break;
        //        case 2:
        //            _sortBy = "Competency";
        //            if (string.IsNullOrEmpty(param.sSearch))
        //            {
        //                _searchBy = string.Empty;
        //            }
        //            else
        //            {
        //                _searchBy = "LanguageName Like '%" + param.sSearch + "%' or Fluency Like '%" + param.sSearch + "%' or Competency Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
        //            }
        //            break;

        //    }
        //    _sortDirection = sortDirection;
        //    _rowLength = param.iDisplayLength;
        //    _startRow = param.iDisplayStart;
        //    filteredEmployeeLanguageDetails = GetEmployeeLanguageDetails(EmployeeID, out TotalRecords);
        //    var records = filteredEmployeeLanguageDetails.Skip(0).Take(param.iDisplayLength);
        //    var result = from c in records
        //                 select new[] { 
        //                                                      Convert.ToString(c.LanguageID),
        //                                                      Convert.ToString(c.LanguageName),
        //                                                      Convert.ToString(c.CanRead),
        //                                                      Convert.ToString(c.CanWrite),
        //                                                      Convert.ToString(c.CanSpeak),
        //                                                      Convert.ToString(c.ID) 
        //                                                     };

        //    return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        //}


        // AjaxHandler EmployeeServiceDetails Method
        public ActionResult AjaxHandlerEmployeeServiceDetails(JQueryDataTableParamModel param, int EmployeeID)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeServiceDetailsViewModel> filteredEmployeeServiceDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.OrderNumber Like '%" + param.sSearch + "%' or C.DepartmentName Like '%" + param.sSearch + "%' or A.PromotionDemotionFlag Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "C.DepartmentName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.OrderNumber Like '%" + param.sSearch + "%' or C.DepartmentName Like '%" + param.sSearch + "%' or A.PromotionDemotionFlag Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.PromotionDemotionFlag";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.OrderNumber Like '%" + param.sSearch + "%' or C.DepartmentName Like '%" + param.sSearch + "%' or A.PromotionDemotionFlag Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeServiceDetails = GetEmployeeServiceDetails(EmployeeID, out TotalRecords);
            var records = filteredEmployeeServiceDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] {
                                                              Convert.ToString(c.OrderNumber),
                                                              Convert.ToString(c.DepartmentName),
                                                              Convert.ToString(c.EmployeeDesignation),
                                                              Convert.ToString(c.PromotionDemotionFlag),
                                                              Convert.ToString(c.IsCurrentFlag),
                                                              Convert.ToString(c.ID),
                                                              Convert.ToString(c.EmployeeID)
                                                             };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}