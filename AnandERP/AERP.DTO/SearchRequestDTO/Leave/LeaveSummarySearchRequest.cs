using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveSummarySearchRequest : Request
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
        public int LeaveMasterID
        {
            get;
            set;
        }
        public decimal BalanceLeave
        {
            get;
            set;
        }
        public int LeaveRuleMasterId
        {
            get;
            set;
        }
        public string ReasonForInsertion
        {
            get;
            set;
        }
        public bool IsCurrentStatus
        {
            get;
            set;
        }
        public int LeaveSessionID
        {
            get;
            set;
        }
        public decimal TotalFullDayUtilized
        {
            get;
            set;
        }
        public decimal TotalHalfDayUtilized
        {
            get;
            set;
        }
        public bool IsBalanceLeaveCarry
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int SummaryIDBFFrom
        {
            get;
            set;
        }
        public int SummeryIDCFTo
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
