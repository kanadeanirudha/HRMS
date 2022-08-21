using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IEmpEmployeeMasterViewModel
    {
        EmpEmployeeMaster EmpEmployeeMasterDTO
        {
            get;
            set;
        }
         int ID
        {
            get;
            set;
        }
         string EmployeeCode
        {
            get;
            set;
        }
         string EmailID
        {
            get;
            set;
        }
         string OtherEmailID
        {
            get;
            set;
        }
         string NameTitle
        {
            get;
            set;
        }       
         string EmployeeFirstName
        {
            get;
            set;
        }
         string EmployeeMiddleName
        {
            get;
            set;
        }
         string EmployeeLastName
        {
            get;
            set;
        }
         string NickName
        {
            get;
            set;
        }
         bool IsEmployeeSmoker
        {
            get;
            set;
        }
         string EthanicRaceCode
        {
            get;
            set;
        }
         string Birthdate
        {
            get;
            set;
        }
         int NationalityID
        {
            get;
            set;
        }
         string GenderCode
        {
            get;
            set;
        }
         string MarritalStaus
        {
            get;
            set;
        }
         string SSNNumber
        {
            get;
            set;
        }
         string SINNumber
        {
            get;
            set;
        }
         string DrivingLicenceNumber
        {
            get;
            set;
        }
         string DrivingLicenceExpireDate
        {
            get;
            set;
        }
         string TelephoneNumber
        {
            get;
            set;
        }
         string MobileNumber
        {
            get;
            set;
        }
         string PanNumber
        {
            get;
            set;
        }
         string ESINumber
        {
            get;
            set;
        }
         string ProvidentFundNumber
        {
            get;
            set;
        }
         string ProvidentFundApplicableDate
        {
            get;
            set;
        }
         string BankACNumber
        {
            get;
            set;
        }
         int EmployeeShiftApplicableMasterID
        {
            get;
            set;
        }
         string SalaryGradeCode
        {
            get;
            set;
        }
         string JoiningDate
        {
            get;
            set;
        }
         string DateOfLeaving
        {
            get;
            set;
        }
         string DateOfRetirment
        {
            get;
            set;
        }
         int TerminationID
        {
            get;
            set;
        }
         string TerminationDate
        {
            get;
            set;
        }
         int DepartmentID
        {
            get;
            set;
        }
         int CentrewiseDeptID
        {
            get;
            set;
        }        
         int EmployeeDesignationMasterID
        {
            get;
            set;
        }
         int JobStatusID
        {
            get;
            set;
        }
         string JobStatus
        {
            get;
            set;
        }
         int JobProfileID
        {
            get;
            set;
        }
         decimal BasicSalary
        {
            get;
            set;
        }
         string UserRemark
        {
            get;
            set;
        }
         string ReasonOfLeaving
        {
            get;
            set;
        }
         string EmployeeType
        {
            get;
            set;
        }
         int PayScaleMstID
        {
            get;
            set;
        }
         string PaymentMode
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         string EmployeeNameAsPerTC
        {
            get;
            set;
        }
         string MaidenFirstName
        {
            get;
            set;
        }
         string MaidenMiddleName
        {
            get;
            set;
        }
         string MaidenLastName
        {
            get;
            set;
        }
         bool IsNameChangedBefore
        {
            get;
            set;
        }
         string PriorFirstName
        {
            get;
            set;
        }
         string PriorMiddleName
        {
            get;
            set;
        }
         string PriorLastName
        {
            get;
            set;
        }
         int BioMatrixEmployeeID
        {
            get;
            set;
        }
         string AdharCardNumber
        {
            get;
            set;
        }
         int EnquiryLevelID
        {
            get;
            set;
        }
         int ActiveCommissionID
        {
            get;
            set;
        }      
         string custom1
        {
            get;
            set;
        }
         string custom2
        {
            get;
            set;
        }
         string custom3
        {
            get;
            set;
        }
         string custom4
        {
            get;
            set;
        }
         string custom5
        {
            get;
            set;
        }
         bool IsActive
        {
            get;
            set;
        }
         string InActiveReason
        {
            get;
            set;
        }
         bool IsDeleted
        {
            get;
            set;
        }
         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int? ModifiedBy
        {
            get;
            set;
        }
         DateTime? ModifiedDate
        {
            get;
            set;
        }
         int? DeletedBy
        {
            get;
            set;
        }
         DateTime? DeletedDate
        {
            get;
            set;
        }
         string errorMessage
        {
            get;
            set;
        }

         string DepartmentName
         {
             get;
             set;
         }
         string CurrencyCode
         {
             get;
             set;
         }
    }

    public interface IEmpEmployeeMasterBaseViewModel
    {
        List<EmpEmployeeMaster> ListEmpEmployeeMaster
        {
            get;
            set;
        }

        List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }

         string CurrentPassword
        {
            get;
            set;
        }
         string NewPassword
        {
            get;
            set;
        }
    }
}
