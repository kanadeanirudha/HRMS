using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeServiceDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int CurrentID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }

        public string EmployeeCode
        {
            get;
            set;
        }

        public int SequenceNumber
        {
            get;
            set;
        }
        public string OrderNumber
        {
            get;
            set;
        }
        public string OrderDate
        {
            get;
            set;
        }
        public string AcceptedByEmployee
        {
            get;
            set;
        }
        public string PromotionDemotionFlag
        {
            get;
            set;
        }
        public string PromotionDemotionDate
        {
            get;
            set;
        }
        public string PreviousPromotionDemotionDate
        {
            get;
            set;
        }
        public int EmployeeDesignationMasterID
        {
            get;
            set;
        }

        public string EmployeeDesignation
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string ChargeTakingDate
        {
            get;
            set;
        }
        public int OldDesignationID
        {
            get;
            set;
        }
        public string OldCentreCode
        {
            get;
            set;
        }
        public int OldDepartmentID
        {
            get;
            set;
        }
        public string OldDepartmentName
        {
            get;
            set;
        }
        public string CollegeApprovalDate
        {
            get;
            set;
        }
        public string UniversityApprovalDate
        {
            get;
            set;
        }
        public string CollegeApprovalNumber
        {
            get;
            set;
        }
        public string UniversityApprovalNumber
        {
            get;
            set;
        }
        public string NatureOfDuty
        {
            get;
            set;
        }
        public decimal BasicAmount
        {
            get;
            set;
        }
        public string ApprovedBy
        {
            get;
            set;
        }
        public decimal NewGrade
        {
            get;
            set;
        }
        public int NewPayscaleID
        {
            get;
            set;
        }
        public string NatureOfAppointment
        {
            get;
            set;
        }
        public string UniversityApprovalType
        {
            get;
            set;
        }
        public int GeneralBoardUniversityID
        {
            get;
            set;
        }
        public string SubjectForApproval
        {
            get;
            set;
        }
        public string GrantedPromotionDate
        {
            get;
            set;
        }
        public int GrantedPromotionDesignationID
        {
            get;
            set;
        }
        public string GrantedPromotionLevel
        {
            get;
            set;
        }
        public bool IsActive
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
        public string errorMessage { get; set; }

        public string CentreCode
        {
            get;
            set;
        }
        public bool IsCurrentFlag
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
    }
}
