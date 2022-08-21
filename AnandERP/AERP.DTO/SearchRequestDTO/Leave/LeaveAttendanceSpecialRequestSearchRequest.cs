using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveAttendanceSpecialRequestSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeAttendanceID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public bool AttendanceStatus
        {
            get;
            set;
        }
        public TimeSpan CommingTime
        {
            get;
            set;
        }
        public TimeSpan LeavingTime
        {
            get;
            set;
        }
        public string StatusFlag
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }
        public int ApprovedByUserID
        {
            get;
            set;
        }
        public int EmployeeShiftMasterID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string UpdatedInEmployeeAttendance
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

    }
}
