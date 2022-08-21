using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationCourseYearDetailsSearchRequest : Request
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
        public string ScopeIdentity
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
        public string Description
        {
            get;
            set;
        }
        public bool BranchActive
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
        public string NextCourseYearDetailID
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
        public string CourseYearCode
        {
            get;
            set;
        }
        public string DegreeName
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
        public string CourseYearID
        {
            get;
            set;
        }
        public String SearchWord { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
