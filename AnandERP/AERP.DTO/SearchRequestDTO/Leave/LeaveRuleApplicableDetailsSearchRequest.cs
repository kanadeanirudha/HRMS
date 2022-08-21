using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveRuleApplicableDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int LeaveRuleMasterID
        {
            get;
            set;
        }
        public int LeaveSessionID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsCurrentFlag
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
        public string CentreCode
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
