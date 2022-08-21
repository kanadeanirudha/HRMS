using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveLateMarkRulesDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string LateMarkRuleName
        {
            get;
            set;
        }
        public Int16 LateMarkCount
        {
            get;
            set;
        }
        public decimal NumberLeaveDeducted
        {
            get;
            set;
        }
        public int LeaveID1
        {
            get;
            set;
        }
        public int LeaveID2
        {
            get;
            set;
        }
        public int LeaveID3
        {
            get;
            set;
        }
        public int LeaveID4
        {
            get;
            set;
        }
        public int LeaveID5
        {
            get;
            set;
        }
        public bool IsActive
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
