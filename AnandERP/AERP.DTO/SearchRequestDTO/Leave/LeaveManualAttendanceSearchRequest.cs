using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveManualAttendanceSearchRequest : Request
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
        public string AttendanceDate
        {
            get;
            set;
        }
        public TimeSpan CheckInTime
        {
            get;
            set;
        }
        public TimeSpan CheckOutTime
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public int ApprovedByUSerID
        {
            get;
            set;
        }
        public bool IsWorkFlow
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

        public string CentreCode
        {
            get;
            set;
        }
    }
}
