using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSemesterMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string OrgSemesterName
        {
            get;
            set;
        }
        public string SemesterType
        {
            get;
            set;
        }
        public string SemesterCode
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

        public object CourseYearID { get; set; }
    }
}
