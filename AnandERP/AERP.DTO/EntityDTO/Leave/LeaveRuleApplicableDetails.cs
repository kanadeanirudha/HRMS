using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveRuleApplicableDetails : BaseDTO
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
        public string LeaveRuleMasterDescription
        {
            get;
            set;
        }
        public string CombinationRuleCode
        {
            get;
            set;
        }
        public int LeaveSessionID
        {
            get;
            set;
        }
        public int LeaveMasterID
        {
            get;
            set;
        }
        public int JobStatusID
        {
            get;
            set;
        }
        public int JobProfileID
        {
            get;
            set;
        }
        public string JobProfileDescription
        {
            get;
            set;
        }
        public string JobStatusDescription
        {
            get;
            set;
        }
        public string JobStatusCode
        {
            get;
            set;
        }
        public bool IsCurrentFlag
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public int StatusFlag
        {
            get;
            set;
        }
        public int TotalRecords
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
        public string LeaveSessionFromDate
        {
            get;
            set;
        }
        public string LeaveSessionUptoDate
        {
            get;
            set;
        }
        public string IDs
        {
            get;
            set;
        }
        public bool IsCurrentLeaveSession
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

        /////////////////////---------------Leave Rule Master Details-----------------///////////////////////

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
        public double MinLeavesAtTime
        {
            get;
            set;
        }
    }
}
