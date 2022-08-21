using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AttendenceMonitoringSystemSearchRequest : Request
    {
        public string VersionNumber { get; set; }

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
        public string EmployeeCode
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string CentreCode
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
        public int FacultyCount
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string Ranking
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
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
        public int Level
        {
            get;
            set;
        }
        public int RoleID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UptoDate { get; set; }


    }
}
