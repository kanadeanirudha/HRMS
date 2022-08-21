using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveRuleMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int LeaveMasterID
        {
            get;
            set;
        }
        public string LeaveRuleDescription
        {
            get;
            set;
        }
        public Int16 NumberOfLeaves
        {
            get;
            set;
        }
        public Int16 MaxLeaveAtTime
        {
            get;
            set;
        }
        public int MinimumLeaveEncash
        {
            get;
            set;
        }
        public int MaxLeaveEncash
        {
            get;
            set;
        }
        public int MaxLeaveAccumlated
        {
            get;
            set;
        }
        public int MinServiceRequiredInMonth
        {
            get;
            set;
        }
        public int AttendDaysRequired
        {
            get;
            set;
        }
        public string CreditDependOn
        {
            get;
            set;
        }
        public int DayOfTheMonth
        {
            get;
            set;
        }
        public bool IsLocked
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public double MinLeavesAtTime
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int EmployeeID
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
        public string LeaveCode
        {
            get;
            set;
        }
    }
}
