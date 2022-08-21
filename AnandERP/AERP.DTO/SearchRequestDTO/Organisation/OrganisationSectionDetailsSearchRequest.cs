using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSectionDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public int StandardID
        {
            get;
            set;
        }
        public int MediumID
        {
            get;
            set;
        }
        public int Duration
        {
            get;
            set;
        }
        public string Descriptions
        {
            get;
            set;
        }
        public int SectionID
        {
            get;
            set;
        }
        public bool SectionActive
        {
            get;
            set;
        }
        public int SectionCapacity
        {
            get;
            set;
        }
        public string ExamApplicable
        {
            get;
            set;
        }
        public string NextSectionDetailID
        {
            get;
            set;
        }
        public string ExamPattern
        {
            get;
            set;
        }
        public int NumberOfSemester
        {
            get;
            set;
        }
        public string SectionDetailCode
        {
            get;
            set;
        }
        public string DegreeName
        {
            get;
            set;
        }
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public int BranchDetID
        {
            get;
            set;
        }
        public int StandardNumber
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int CourseStartDetID
        {
            get;
            set;
        }
        public bool ActualExamPattern
        {
            get;
            set;
        }
        public string OrgShiftCode
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
        public int UniversityID
        {
            get;
            set;
        }
        public string ScopeIdentity
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
