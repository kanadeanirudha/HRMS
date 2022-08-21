using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmpEmployeeMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get;
            set;
        }

        public string IMEI
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }
        public string OtherEmailID
        {
            get;
            set;
        }
        public string NameTitle
        {
            get;
            set;
        }
        public string EmployeeFullName
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeMiddleName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
        public string NickName
        {
            get;
            set;
        }
        public bool IsEmployeeSmoker
        {
            get;
            set;
        }
        public string EthanicRaceCode
        {
            get;
            set;
        }
        public string Birthdate
        {
            get;
            set;
        }
        public int NationalityID
        {
            get;
            set;
        }
        public string GenderCode
        {
            get;
            set;
        }
        public string MarritalStaus
        {
            get;
            set;
        }
        public string SSNNumber
        {
            get;
            set;
        }
        public string SINNumber
        {
            get;
            set;
        }
        public string DrivingLicenceNumber
        {
            get;
            set;
        }
        public string DrivingLicenceExpireDate
        {
            get;
            set;
        }
        public string TelephoneNumber
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string PanNumber
        {
            get;
            set;
        }
        public string ESINumber
        {
            get;
            set;
        }
        public string ProvidentFundNumber
        {
            get;
            set;
        }
        public string ProvidentFundApplicableDate
        {
            get;
            set;
        }
        public string UANNumber
        {
            get;set;
        }
        public string BankACNumber
        {
            get;
            set;
        }
        public int EmployeeShiftApplicableMasterID
        {
            get;
            set;
        }
        public string SalaryGradeCode
        {
            get;
            set;
        }
        public string JoiningDate
        {
            get;
            set;
        }

        public string AppointmentApprovalDate
        {
            get;
            set;
        }

        public bool IsLeave
        {
            get;
            set;
        }

        public string DateOfLeaving
        {
            get;
            set;
        }
        public string DateOfRetirment
        {
            get;
            set;
        }
        public int TerminationID
        {
            get;
            set;
        }
        public string TerminationDate
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public int CentrewiseDeptID
        {
            get;
            set;
        }        
        public int EmployeeDesignationMasterID
        {
            get;
            set;
        }
        public int JobStatusID
        {
            get;
            set;
        }
        public string JobStatus
        {
            get;
            set;
        }
        public int JobProfileID
        {
            get;
            set;
        }
        public decimal BasicSalary
        {
            get;
            set;
        }
        public string UserRemark
        {
            get;
            set;
        }
        public string ReasonOfLeaving
        {
            get;
            set;
        }
        public string EmployeeType
        {
            get;
            set;
        }
        public int PayScaleMstID
        {
            get;
            set;
        }
        public string PaymentMode
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string DateOfBirth
        {
            get;
            set;
        }
        public string EmployeeNameAsPerTC
        {
            get;
            set;
        }
        public string MaidenFirstName
        {
            get;
            set;
        }
        public string MaidenMiddleName
        {
            get;
            set;
        }
        public string MaidenLastName
        {
            get;
            set;
        }
        public bool IsNameChangedBefore
        {
            get;
            set;
        }
        public string PriorFirstName
        {
            get;
            set;
        }
        public string PriorMiddleName
        {
            get;
            set;
        }
        public string PriorLastName
        {
            get;
            set;
        }
        public int BioMatrixEmployeeID
        {
            get;
            set;
        }
        public string AdharCardNumber
        {
            get;
            set;
        }
        public int EnquiryLevelID
        {
            get;
            set;
        }
        public int ActiveCommissionID
        {
            get;
            set;
        }       
        public string custom1
        {
            get;
            set;
        }
        public string custom2
        {
            get;
            set;
        }
        public string custom3
        {
            get;
            set;
        }
        public string custom4
        {
            get;
            set;
        }
        public string custom5
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string InActiveReason
        {
            get;
            set;
        }        
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }

        ///////////////////////////Additional fields/////////////////////////////////////////////
        public string DepartmentName
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public string EmployeeDesignation
        {
            get;
            set;
        }
        public string JobProfileDescription
        {
            get;
            set;
        }
        public string JobStatusDescription
        {
            get;
            set;
        }
        public string Nationality
        {
            get;
            set;
        }
        public string CurrencyCode
        {
            get;
            set;
        }
        public string EntityLevel
        {
            get;
            set;
        }
        public bool IsExemptedEmployee
        {
            get;
            set;
        }
        
        public int AdminRoleMasterID { get; set; }
        public string AdminRoleCode
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string CurrentPassword
        {
            get;
            set;
        }
        public string NewPassword
        {
            get;
            set;
        }
        public string ConfirmPassword
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }
         public string ExcelSheetName
        {
            get;set;
        }
        public string EmplyeeExperienceList
        {
            get; set;
        }
        public string EmployeeFamilyList
        {
            get; set;
        }

        public string NomineeName
        {
            get; set;
        }
        public string FromYear
        {
            get; set;
        }
        public string UptoYear
        {
            get; set;
        }
        public string NameOfInstitution
        {
            get; set;
        }
        public string SpecailisationIn
        {
            get; set;
        }
        public string YearOfPassing
        {
            get; set;
        }

        public string XMLString
        {
            get;
            set;
        }
        public string RightName
        {
            get; set;
        }
        public string IFSCCode
        {
            get; set;
        }
        public Int32 EmployeeID
        {
            get; set;
        }
        public string Details
        {
            get; set;
        }
    }
}
