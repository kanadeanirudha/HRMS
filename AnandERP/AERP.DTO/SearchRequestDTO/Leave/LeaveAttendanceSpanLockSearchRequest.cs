using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveAttendanceSpanLockSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string SpanFromDate
        {
            get;
            set;
        }
        public string SpanUptoDate
        {
            get;
            set;
        }
        public bool IsSpanLock
        {
            get;
            set;
        }
        public bool IsDescripancyRemoved
        {
            get;
            set;
        }
        public bool IsLateMarkProccessed
        {
            get;
            set;
        }
        public int TaskDoneByEmployee
        {
            get;
            set;
        }
        public string TaskDoneDate
        {
            get;
            set;
        }
        public int ApprovedByUserID
        {
            get;
            set;
        }
        public string CentreCode
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

        public int DepartmentID
        {
            get;
            set;
        }
        public int SalarySpanID
        {
            get;
            set;
        }
    }             
}
