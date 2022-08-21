using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmpEmployeeMasterViewModel : IEmpEmployeeMasterViewModel
    {

        public EmpEmployeeMasterViewModel()
        {
            EmpEmployeeMasterDTO = new EmpEmployeeMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            EmpEmployeeMasterListForImportExcel = new List<EmpEmployeeMaster>();
            ListGetOrganisationDepartmentCentreAndDepartmentWise = new List<OrganisationDepartmentMaster>();
        }
        public HttpPostedFileBase ExcelFile { get; set; }

        public List<OrganisationDepartmentMaster> ListGetOrganisationDepartmentCentreAndDepartmentWise
        {
            get;
            set;
        }

        public EmpEmployeeMaster EmpEmployeeMasterDTO
        {
            get;
            set;
        }
        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
        public List<EmpEmployeeMaster> EmpEmployeeMasterListForImportExcel
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrganisationStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
            }
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListGetOrganisationDepartmentCentreAndDepartmentWiseItems
        {
            get
            {
                return new SelectList(ListGetOrganisationDepartmentCentreAndDepartmentWise, "ID", "DepartmentName");
            }
        }

        public int ID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.ID > 0) ? EmpEmployeeMasterDTO.ID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.ID = value;
            }
        }


        [Display(Name = "Employee Code")]
        //[Required(ErrorMessage = "Employee Code Required")]
        public string EmployeeCode
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeCode : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeCode = value;
            }
        }

        [Display(Name = "IMEI Number")]
        //[Required(ErrorMessage = "Employee Code Required")]
        public string IMEI
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.IMEI : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.IMEI = value;
            }
        }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage ="Email Address Required")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,15})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
        public string EmailID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmailID : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmailID = value;
            }
        }


        [Display(Name = "Other Email Address")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,15})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
        public string OtherEmailID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.OtherEmailID : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.OtherEmailID = value;
            }
        }


        [Display(Name = "Title")]
     //   [Required(ErrorMessage ="Title Required")]
        public string NameTitle
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.NameTitle : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.NameTitle = value;
            }
        }

        [Display(Name = "Employee Full Name")]
        public string EmployeeFullName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeFullName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeFullName = value;
            }
        }

        [Display(Name = "Employee First Name")]
        [Required(ErrorMessage ="Employee First Name Required")]
        public string EmployeeFirstName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeFirstName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeFirstName = value;
            }
        }

        [Display(Name = "Employee Middle Name")]
        public string EmployeeMiddleName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeMiddleName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeMiddleName = value;
            }
        }


        [Display(Name = "Employee Last Name")]
        //[Required(ErrorMessage ="Employee Last Name Required")]
        public string EmployeeLastName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeLastName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeLastName = value;
            }
        }


        [Display(Name = "Nick Name")]
        public string NickName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.NickName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.NickName = value;
            }
        }

        [Display(Name = "Is Employee Smoker")]
        public bool IsEmployeeSmoker
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.IsEmployeeSmoker : false;
            }
            set
            {
                EmpEmployeeMasterDTO.IsEmployeeSmoker = value;
            }
        }

        [Display(Name = "Ethanic Race Code")]
        public string EthanicRaceCode
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EthanicRaceCode : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EthanicRaceCode = value;
            }
        }

        [Display(Name = "Birth Date")]
        public string Birthdate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.Birthdate : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.Birthdate = value;
            }
        }

        [Display(Name = "Nationality")]
        public int NationalityID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.NationalityID > 0) ? EmpEmployeeMasterDTO.NationalityID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.NationalityID = value;
            }
        }

        [Display(Name = "Gender")]
        public string GenderCode
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.GenderCode : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.GenderCode = value;
            }
        }

        [Display(Name = "Marital Staus")]
        //[Required(ErrorMessage = "Marital Staus Required")]
        public string MarritalStaus
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.MarritalStaus : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.MarritalStaus = value;
            }
        }
        
        [Display(Name = "SSN Number")]
        //[RegularExpression("^\\d{3}-\\d{2}-\\d{4}$", ErrorMessage = "Please enter your SSN in the format 000-00-0000")]
        public string SSNNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.SSNNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.SSNNumber = value;
            }
        }

        [Display(Name = "SIN Number")]
        //[RegularExpression("^(\\d{3}-\\d{3}-\\d{3})|(\\d{3} \\d{3} \\d{3})|(\\d{9})$", ErrorMessage = "Please enter your SIN in the format 000 000 000")]
        public string SINNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.SINNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.SINNumber = value;
            }
        }
        
        [Display(Name = "Driving Licence Number")]
        public string DrivingLicenceNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.DrivingLicenceNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.DrivingLicenceNumber = value;
            }
        }

        [Display(Name = "Driving Licence Expiry Date")]
        public string DrivingLicenceExpireDate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.DrivingLicenceExpireDate : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.DrivingLicenceExpireDate = value;
            }
        }

        [Display(Name = "Telephone Number")]
        public string TelephoneNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.TelephoneNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.TelephoneNumber = value;
            }
        }

        [Display(Name = "Mobile Number")]
        public string MobileNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.MobileNumber = value;
            }
        }

        [Display(Name = "Pan Number")]
      //  [RegularExpression("[A-Z]{5}\\d{4}[A-Z]{1}", ErrorMessage = "Please enter your PAN number in the format AAAPL1234C")]
        public string PanNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.PanNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.PanNumber = value;
            }
        }

        [Display(Name = "ESI Number")]
        public string ESINumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.ESINumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.ESINumber = value;
            }
        }

        [Display(Name = "Provident Fund Number")]
        public string ProvidentFundNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.ProvidentFundNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.ProvidentFundNumber = value;
            }
        }

        [Display(Name = "Provident Fund Applicable Date")]
        public string ProvidentFundApplicableDate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.ProvidentFundApplicableDate : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.ProvidentFundApplicableDate = value;
            }
        }

        [Display(Name = "UAN Number")]
        public string UANNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.UANNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.UANNumber = value;
            }
        }
        
        [Display(Name = "Bank Account Number")]
        public string BankACNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.BankACNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.BankACNumber = value;
            }
        }

        [Display(Name = "Employee Shift")]
        public int EmployeeShiftApplicableMasterID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeShiftApplicableMasterID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeShiftApplicableMasterID = value;
            }
        }

        [Display(Name = "Salary Grade Code")]
        public string SalaryGradeCode
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.SalaryGradeCode : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.SalaryGradeCode = value;
            }
        }
        [Display(Name = "Joining Date")]
        public string JoiningDate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.JoiningDate : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.JoiningDate = value;
            }
        }

        [Display(Name = "Appointment Approval Date")]
        public string AppointmentApprovalDate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.AppointmentApprovalDate : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.AppointmentApprovalDate = value;
            }
        }

        
        [Display(Name = "Is Job Left")]
        public bool IsLeave
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.IsLeave : false;
            }
            set
            {
                EmpEmployeeMasterDTO.IsLeave = value;
            }
        }


        [Display(Name = "Date Of Leaving")]
        public string DateOfLeaving
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.DateOfLeaving : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.DateOfLeaving = value;
            }
        }


        [Display(Name = "Date Of Retirement")]
        public string DateOfRetirment
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.DateOfRetirment : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.DateOfRetirment = value;
            }
        }

        [Display(Name = "Termination")]
        public int TerminationID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.TerminationID > 0) ? EmpEmployeeMasterDTO.TerminationID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.TerminationID = value;
            }
        }

        [Display(Name = "Termination Date")]
        public string TerminationDate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.TerminationDate : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.TerminationDate = value;
            }
        }

        [Display(Name = "Department")]
        [Required(ErrorMessage ="Department Required")]
        public int DepartmentID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.DepartmentID > 0) ? EmpEmployeeMasterDTO.DepartmentID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.DepartmentID = value;
            }
        }

        [Display(Name = "Centrewise Department")]
        [Required(ErrorMessage ="Centrewise Department Required")]
        public int CentrewiseDeptID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.CentrewiseDeptID > 0) ? EmpEmployeeMasterDTO.CentrewiseDeptID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.CentrewiseDeptID = value;
            }
        }

        [Display(Name = "Designation")]
        [Required(ErrorMessage ="Designation Required")]
        public int EmployeeDesignationMasterID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.EmployeeDesignationMasterID > 0) ? EmpEmployeeMasterDTO.EmployeeDesignationMasterID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeDesignationMasterID = value;
            }
        }

        [Display(Name = "Job Status")]
        public int JobStatusID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.JobStatusID > 0) ? EmpEmployeeMasterDTO.JobStatusID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.JobStatusID = value;
            }
        }

        [Display(Name = "Job Status")]
        public string JobStatus
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.JobStatus : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.JobStatus = value;
            }
        }

        [Display(Name = "Job Profile")]
        public int JobProfileID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.JobProfileID > 0) ? EmpEmployeeMasterDTO.JobProfileID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.JobProfileID = value;
            }
        }
        [Display(Name = "Basic Salary")]
        public decimal BasicSalary
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.BasicSalary > 0) ? EmpEmployeeMasterDTO.BasicSalary : new decimal();
            }
            set
            {
                EmpEmployeeMasterDTO.BasicSalary = value;
            }
        }

        [Display(Name = "User Remark")]
        public string UserRemark
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.UserRemark : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.UserRemark = value;
            }
        }

        [Display(Name = "Reason Of Leaving")]
        public string ReasonOfLeaving
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.ReasonOfLeaving : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.ReasonOfLeaving = value;
            }
        }

        [Display(Name = "Employee Type")]
        public string EmployeeType
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeType : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeType = value;
            }
        }

        [Display(Name = "Pay Scale")]
        public int PayScaleMstID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.PayScaleMstID > 0) ? EmpEmployeeMasterDTO.PayScaleMstID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.PayScaleMstID = value;
            }
        }

        [Display(Name = "Payment Mode")]
        public string PaymentMode
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.PaymentMode : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.PaymentMode = value;
            }
        }


        [Display(Name = "Center")]
        [Required(ErrorMessage ="Centre Required")]
        public string CentreCode
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "Center")]
        public string CentreName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.CentreName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.CentreName = value;
            }
        }


        [Display(Name = "Employee Name As Per Aadhar Card")]
        public string EmployeeNameAsPerTC
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeNameAsPerTC : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeNameAsPerTC = value;
            }
        }


        [Display(Name = "Maiden First Name")]
        public string MaidenFirstName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.MaidenFirstName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.MaidenFirstName = value;
            }
        }


        [Display(Name = "Maiden Middle Name")]
        public string MaidenMiddleName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.MaidenMiddleName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.MaidenMiddleName = value;
            }
        }


        [Display(Name = "Maiden Last Name")]
        public string MaidenLastName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.MaidenLastName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.MaidenLastName = value;
            }
        }


        [Display(Name = "Is Name Changed Before")]
        public bool IsNameChangedBefore
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.IsNameChangedBefore : false;
            }
            set
            {
                EmpEmployeeMasterDTO.IsNameChangedBefore = value;
            }
        }


        [Display(Name = "Prior First Name")]
        public string PriorFirstName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.PriorFirstName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.PriorFirstName = value;
            }
        }


        [Display(Name = "Prior Middle Name")]
        public string PriorMiddleName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.PriorMiddleName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.PriorMiddleName = value;
            }
        }


        [Display(Name = "Prior Last Name")]
        public string PriorLastName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.PriorLastName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.PriorLastName = value;
            }
        }

        [Display(Name = "BioMatrixEmployeeID")]
        public int BioMatrixEmployeeID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.CreatedBy > 0) ? EmpEmployeeMasterDTO.BioMatrixEmployeeID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.BioMatrixEmployeeID = value;
            }
        }

        [Display(Name = "Adhar Card Number")]
        public string AdharCardNumber
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.AdharCardNumber : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.AdharCardNumber = value;
            }
        }

        [Display(Name = "Enquiry Level")]
        public int EnquiryLevelID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.EnquiryLevelID > 0) ? EmpEmployeeMasterDTO.EnquiryLevelID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.EnquiryLevelID = value;
            }
        }

        [Display(Name = "Active Commission")]
        public int ActiveCommissionID
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.ActiveCommissionID > 0) ? EmpEmployeeMasterDTO.ActiveCommissionID : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.ActiveCommissionID = value;
            }
        }

        [Display(Name = "DisplayName_custom1")]
        public string custom1
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.custom1 : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.custom1 = value;
            }
        }

        [Display(Name = "DisplayName_custom2")]
        public string custom2
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.custom2 : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.custom2 = value;
            }
        }

        [Display(Name = "DisplayName_custom3")]
        public string custom3
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.custom3 : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.custom3 = value;
            }
        }

        [Display(Name = "DisplayName_custom4")]
        public string custom4
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.custom4 : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.custom4 = value;
            }
        }

        [Display(Name = "DisplayName_custom5")]
        public string custom5
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.custom5 : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.custom5 = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.IsActive : false;
            }
            set
            {
                EmpEmployeeMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "InActive Reason")]
        public string InActiveReason
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.InActiveReason : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.InActiveReason = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.IsDeleted : false;
            }
            set
            {
                EmpEmployeeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.CreatedBy > 0) ? EmpEmployeeMasterDTO.CreatedBy : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmpEmployeeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.ModifiedBy.HasValue) ? EmpEmployeeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.ModifiedDate.HasValue) ? EmpEmployeeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmpEmployeeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.DeletedBy.HasValue) ? EmpEmployeeMasterDTO.DeletedBy : new int();
            }
            set
            {
                EmpEmployeeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmpEmployeeMasterDTO != null && EmpEmployeeMasterDTO.DeletedDate.HasValue) ? EmpEmployeeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmpEmployeeMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.DepartmentName : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.DepartmentName = value;
            }
        }


        // [Display(Name = "DisplayName_DepartmentName", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DepartmentNameRequired")]
        public string EmployeeDesignation
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmployeeDesignation : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmployeeDesignation = value;
            }
        }

        public string JobProfileDescription
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.JobProfileDescription : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.JobProfileDescription = value;
            }
        }

        public string JobStatusDescription
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.JobStatusDescription : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.JobStatusDescription = value;
            }
        }

        public string Nationality
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.Nationality : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.Nationality = value;
            }
        }

        public string CurrencyCode
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.CurrencyCode : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.CurrencyCode = value;
            }
        }

        public string EntityLevel
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EntityLevel : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EntityLevel = value;
            }
        }
        public string Password
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.Password : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.Password = value;
            }
        }
        [Display(Name = "Current Password")]
        // [Required(ErrorMessage = "Current Password should not be blank.")]
        public string CurrentPassword
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.CurrentPassword : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.CurrentPassword = value;
            }
        }
        [Display(Name = "New Password")]
        //[Required(ErrorMessage = "New Password should not be blank.")]
        public string NewPassword
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.NewPassword : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.NewPassword = value;
            }
        }
        [Display(Name = "Confirm Password")]
        // [Required(ErrorMessage = "Confirm Password should not be blank.")]
        public string ConfirmPassword
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.ConfirmPassword : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.ConfirmPassword = value;
            }
        }
        
        public string EmplyeeExperienceList
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.EmplyeeExperienceList : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.EmplyeeExperienceList = value;
            }
        }

        [Display(Name = "IFSC Code")]
        //   [Required(ErrorMessage ="Title Required")]
        public string IFSCCode
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.IFSCCode : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.IFSCCode = value;
            }
        }
        public string Details
        {
            get
            {
                return (EmpEmployeeMasterDTO != null) ? EmpEmployeeMasterDTO.Details : string.Empty;
            }
            set
            {
                EmpEmployeeMasterDTO.Details = value;
            }
        }
    }


}
