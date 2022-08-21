using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeavePostSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string LeaveCode
        {
            get;
            set;
        }
        public string LeaveDescription
        {
            get;
            set;
        }
        public int LeaveRuleMasterID
        {
            get;
            set;
        }
        public string LeaveRuleDescription
        {
            get;
            set;
        }
        public string LeaveType
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
        public string EmployeeID
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeMiddleName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
        public string LeaveSessionName
        {
            get;
            set;
        }
        public int FromLeaveSessionID
        {
            get;
            set;
        }

        public int ToLeaveSessionID
        {
            get;
            set;
        }
    }
}
