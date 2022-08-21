using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeEnterpriseReportSearchRequest : Request
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
        public int DoctorateCount
        {
            get;
            set;
        }
        public int PGCount
        {
            get;
            set;
        }
        public int ExperienceCount
        {
            get;
            set;
        }
        public int SpecializationCount
        {
            get;
            set;
        }
        public int JournalPaper
        {
            get;
            set;
        }
        public int MainAuthor
        {
            get;
            set;
        }
        public int CoAuthor
        {
            get;
            set;
        }
        public int ConferenceCount
        {
            get;
            set;
        }
        public int PublishedBookCount
        {
            get;
            set;
        }
        public int SynopsisCount
        {
            get;
            set;
        }
        public int Project
        {
            get;
            set;
        }
        public int ElectedBodyMemberCount
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

    }
}
