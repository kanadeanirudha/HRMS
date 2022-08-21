using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeServiceDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
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
        public DateTime PromotionDemotionDate
        {
            get;
            set;
        }
        public DateTime PreviousPromotionDemotionDate
        {
            get;
            set;
        }
        public int EmployeeDesignationMasterID
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public DateTime ChargeTakingDate
        {
            get;
            set;
        }
        public int OldDesignationID
        {
            get;
            set;
        }
        public int OldDepartmentID
        {
            get;
            set;
        }
        public DateTime CollegeApprovalDate
        {
            get;
            set;
        }
        public DateTime UniversityApprovalDate
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
        public DateTime GrantedPromotionDate
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
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
