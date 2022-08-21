using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSessionCryrAllocation : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public int SemesterMasterID
        {
            get;
            set;
        }
        public string SemesterType
        {
            get;
            set;
        }
        public int CourseYearSemesterID
        {
            get;
            set;
        }
        public int OrgSessionCourseYearAllocationID
        {
            get;
            set;
        }
        public string SemesterFromDate
        {
            get;
            set;
        }
        public string SemesterUptoDate
        {
            get;
            set;
        }
        public bool CurrentActiveSemesterFlag
        {
            get;
            set;
        }
        public int TotalExpectedWeeks
        {
            get;
            set;
        }
        public string PeriodStartDate
        {
            get;
            set;
        }
        public string PeriodEndDate
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

        public string BranchDescription     
        {
            get;
            set;
        }
        public string CourseYearCode
        {
            get;
            set;
        }
        public string OrgSemesterName
        {
            get;
            set;
        }
        public bool StatusFlag
        {
            get;
            set;
        }
        public bool OrgSessionCryrAllotStatus { get; set; }
        public string Current_CentreCode
        {
            get;
            set;
        }
         public int OrgSemesterMstID
        {
            get;
            set;
        }
         public int totalExpectedWeeks
         {
             get;
             set;
         }
         public string SessionName { get; set; }
    }
}
