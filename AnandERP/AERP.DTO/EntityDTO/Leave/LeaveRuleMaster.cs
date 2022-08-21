using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveRuleMaster : BaseDTO
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
        public string LeaveDescription
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
        public Int16 AccumulationMethod
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
        public int MaxLeaveAccumulated
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
        public string LeaveCode
        {
            get;
            set;
        }

        public string LeaveEncashFormula
        {
            get;
            set;
        }

        public decimal LeaveMonthRatio
        {
            get;
            set;
        }

        public bool LeaveStatus
        {
            get;
            set;
        }
        public int DayOfTheMonth
        {
            get;
            set;
        }
        public Int16 DaysBeforeApplicationSubmitted
        {
            get;
            set;
        }
        public Int16 DaysAfterApplicationSubmitted
        {
            get;
            set;
        }
        public Int16 NumberOfMonths
        {
            get;
            set;
        }
        public Int16 NumberOfAccumulatedLeaves
        {
            get;
            set;
        }
        public Int16 LeaveApplicationSubmittedUptoDays
        {
            get;
            set;
        }
        public bool IsLeaveAccumulatePeriodically
        {
            get;
            set;
        }
        public Int16 LeaveAttendanceSpanFromDayDiffecrence
        {
            get;
            set;
        }
        public Int16 PermitedDaysAfterLeaveCan
        {
            get;
            set;
        }
        public Int16 MaxDaysUpto
        {
            get;
            set;
        }
        public string LeaveAttendanceSpanFromDate
        {
            get;
            set;
        }
        public bool IsLocked
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
        public string CentreName
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
        public int LeaveSessionID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public double BalanceLeave
        {
            get;
            set;
        }
        public double IsCompensatory { get; set; }
        public bool DocumentCompulsaryFlag { get; set; }
        public bool DocumentRequiredFlag { get; set; }
        public int DocumentRequiredID { get; set; }
    }
}
