using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationCourseYearSemesterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public int OrganisationSemesterMstID
        {
            get;
            set;
        }
        public string SemesterActiveFlag
        {
            get;
            set;
        }
        public string SemesterType
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
    }
}
