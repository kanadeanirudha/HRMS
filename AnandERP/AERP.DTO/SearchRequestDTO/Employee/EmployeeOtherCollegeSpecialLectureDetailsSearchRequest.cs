using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeOtherCollegeSpecialLectureDetailsSearchRequest : Request
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
        public string InstituteName
        {
            get;
            set;
        }
        public string InstituteAddress
        {
            get;
            set;
        }
        public string TopicOfLecture
        {
            get;
            set;
        }
        public string DateOfLectureDelivered
        {
            get;
            set;
        }
        public string Remarks
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
