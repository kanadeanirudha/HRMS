using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveEmployeeApplicationStatusReportSearchRequest : Request
    {
        public string DepartmentName
        {
            get;
            set;
        }
        public string EmployeeFullName
        {
            get;
            set;
        }
      
        public string LeaveType
        {
            get;
            set;
        }
        public string ApplicationDate
        {
            get;
            set;
        }
        public string Dates
        {
            get;
            set;
        }
        public string ApprovalStatus
        {
            get;
            set;
        }
        public string FullDayHalfDayStatus
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }
        public string DepartmentIds
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
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
        public int EmployeeID
        {
            get;
            set;
        }
    }
}
