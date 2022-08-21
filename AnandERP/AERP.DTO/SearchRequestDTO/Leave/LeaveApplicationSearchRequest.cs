using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveApplicationSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string ApplicationCode
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public int LeaveMasterID
        {
            get;
            set;
        }
        public DateTime SubmittedOnDate
        {
            get;
            set;
        }
        public DateTime FromDate
        {
            get;
            set;
        }
        public DateTime UptoDate
        {
            get;
            set;
        }
        public Int16 TotalfullDaysLeave
        {
            get;
            set;
        }
        public Int16 TotalHalfDayLeave
        {
            get;
            set;
        }
        public string HalfLeaveStatus
        {
            get;
            set;
        }
        public string EmployeeRemark
        {
            get;
            set;
        }
        public bool DocumentRequire
        {
            get;
            set;
        }
        public string LeaveReason
        {
            get;
            set;
        }
        public byte LeavePriority
        {
            get;
            set;
        }
        public string ApplicationStatus
        {
            get;
            set;
        }
        public byte PendingAtApprovalLevel
        {
            get;
            set;
        }
        public int WorkModuleID
        {
            get;
            set;
        }
        public int LeaveSessionID
        {
            get;
            set;
        }
        public string CancelRemark
        {
            get;
            set;
        }
        public DateTime ApplicationDate
        {
            get;
            set;
        }
        public Int16 SactionedFullDay
        {
            get;
            set;
        }
        public Int16 SactionedHalfDay
        {
            get;
            set;
        }
        public string SactionedHalfLeaveStatus
        {
            get;
            set;
        }
        public decimal TransferToLWP
        {
            get;
            set;
        }
        public int ApprovedByUser
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public int LeaveRuleMasterID
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
        public string DepartmentID { get; set; }
    }
}
