using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveMasterSearchRequest : Request
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
        public bool IsCarryForwardForNextYear
        {
            get;
            set;
        }
        public bool IsEnCash
        {
            get;
            set;
        }
        public bool AttendanceNeeded
        {
            get;
            set;
        }
        public bool DocumentsNeeded
        {
            get;
            set;
        }
        public bool HalfDayFlag
        {
            get;
            set;
        }
        public bool LossOfPay
        {
            get;
            set;
        }
        public bool NoCredit
        {
            get;
            set;
        }
        public bool MinServiceRequire
        {
            get;
            set;
        }
        public bool OnDuty
        {
            get;
            set;
        }
        public bool IsPostedOnce
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
    }
}
