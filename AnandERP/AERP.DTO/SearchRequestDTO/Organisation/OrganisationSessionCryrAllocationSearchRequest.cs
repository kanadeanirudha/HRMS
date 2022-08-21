using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSessionCryrAllocationSearchRequest : Request
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
        public DateTime SemesterFromDate
        {
            get;
            set;
        }
        public DateTime SemesterUptoDate
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
        public DateTime PeriodStartDate
        {
            get;
            set;
        }
        public DateTime PeriodEndDate
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
        public string SearchType
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int Current_SessionID
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string ScopeIdentity { get; set; }
        public int AdminRoleMasterID
        {
            get;
            set;
        }        
    }
}
