using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveSessionSearchRequest : Request
    {
        public int LeaveSessionID
        {
            get;
            set;
        }
        public string LeaveSessionName
        {
            get;
            set;
        }
        public DateTime LeaveSessionFromDate
        {
            get;
            set;
        }
        public DateTime LeaveSessionUptoDate
        {
            get;
            set;
        }
        public bool IsSessionLocked
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public bool IsCurrentLeaveSession
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
        public int EmployeeID
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

        ////------------------------Leave Session Details--------------------------////

        public int LeaveSessionDetailsID
        {
            get;
            set;
        }
        public int JobProfileID
        {
            get;
            set;
        }
        public string JobStatusCode
        {
            get;
            set;
        }
        public int Mode
        {
            get;
            set;
        }
    }
}
