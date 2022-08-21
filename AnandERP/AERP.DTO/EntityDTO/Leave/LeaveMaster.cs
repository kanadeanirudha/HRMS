using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int LeaveApplicationTransactionID
        {
            get;
            set;
        }

        public string XML
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }
        public string LeaveApprovalStatus
        {
            get;
            set;
        }
        public string FullDayHalfDayDetails
        {
            get;
            set;
        }
        public string LeaveDate
        {
            get;
            set;
        }
        public string ApplicationDate
        {
            get;
            set;
        }
        public int LeaveSessionID
        {
            get;
            set;
        }

        public int LeaveApplicationID
        {
            get;
            set;
        }

        public string ApplicationCode
        {
            get;
            set;
        }
        public double BalanceLeave
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }

        public string LeaveCode
        {
            get;
            set;
        }

        public string CentreCode
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
        public bool NeedToInformInAdvance
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
        public string errorMessage { get; set; }

        public string VersionNumber { get; set; }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public string SyncType
        {
            get; set;
        }
        public string Entity
        {
            get; set;
        }

        public TimeSpan CheckInTime
        {
            get;
            set;
        }
        public TimeSpan CheckOutTime
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string AttendanceDate
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }

        
        public bool AttendanceStatus
        {
            get;
            set;
        }
        public string RequestedDate { get; set; }
        public TimeSpan CommingTime
        {
            get;
            set;
        }
        public TimeSpan LeavingTime
        {
            get;
            set;
        }
        public string StatusFlag
        {
            get;
            set;
        }

        
        public int ApprovedByUserID
        {
            get;
            set;
        }
        public int EmployeeShiftMasterID
        {
            get;
            set;
        }
        
    }
}
