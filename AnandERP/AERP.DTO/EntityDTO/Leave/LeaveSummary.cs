using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveSummary : BaseDTO
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
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
