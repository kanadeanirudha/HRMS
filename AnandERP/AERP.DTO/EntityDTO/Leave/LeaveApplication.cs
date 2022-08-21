using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveApplication : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string ApplicationCode
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public int LeaveMasterID
        {
            get;
            set;
        }
        public string SubmittedOnDate
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public Int16 TotalfullDaysLeave
        {
            get;
            set;
        }
        public string CancelDays
        {
            get;
            set;
        }
        public string LeaveTotalDay
        {
            get;
            set;
        }
        public Int16 TotalHalfDayLeave
        {
            get;
            set;
        }
        public string HalfLeaveStatus
        {
            get;
            set;
        }
        public string HalfLeaveStatusTr
        {
            get;
            set;
        }
        public string EmployeeRemark
        {
            get;
            set;
        }
        public bool DocumentRequire
        {
            get;
            set;
        }
        public string LeaveReason
        {
            get;
            set;
        }
        public byte LeavePriority
        {
            get;
            set;
        }
        public string ApplicationStatus
        {
            get;
            set;
        }
        public string ApprovalStatus
        {
            get;
            set;
        }
        public string FullDayHalfDayFlag
        {
            get;
            set;
        }
        public byte PendingAtApprovalLevel
        {
            get;
            set;
        }
        public int WorkModuleID
        {
            get;
            set;
        }
        public int LeaveSessionID
        {
            get;
            set;
        }
        public string LeaveSession
        {
            get;
            set;
        }
        public string CancelRemark
        {
            get;
            set;
        }
        public string ApplicationDate
        {
            get;
            set;
        }
        public Int16 SactionedFullDay
        {
            get;
            set;
        }
        public Int16 SactionedHalfDay
        {
            get;
            set;
        }
        public string SactionedHalfLeaveStatus
        {
            get;
            set;
        }
        public decimal TransferToLWP
        {
            get;
            set;
        }
        public int ApprovedByUser
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int LeaveRuleMasterID
        {
            get;
            set;
        }
        public int PendingJobSrNo
        {
            get;
            set;
        }
        public int PendingLevelSeqNumber
        {
            get;
            set;
        }
        public int SancWorkReportingMstID
        {
            get;
            set;
        }
        public int PendAtWorkReportingDetailID
        {
            get;
            set;
        }
        public string SactionFromDate
        {
            get;
            set;
        }
        public string SactionUptoDate
        {
            get;
            set;
        }
        public int AdminRoleMasterID
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
        public bool IsFirstHalf
        {
            get;
            set;
        }
        public bool IsSecondHalf
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
        public string NumberOfLeaves
        {
            get;
            set;
        }
        public double BalanceLeave
        {
            get;
            set;
        }
        public string TotalFullDayUtilized
        {
            get;
            set;
        }
        public string TotalHalfDayUtilized
        {
            get;
            set;
        }
        public string LeaveApplicationApprocedPendingStatusDetails
        {
            get;
            set;
        }
        public double IsCompensatory
        {
            get;
            set;
        }

        public int GeneralTaskApproverNotificationStatus
        {
            get;
            set;
        }
        public int GeneralTaskApproverNotification_InsertError
        {
            get;
            set;
        }
        public int TaskNotificationMaster_InsertError
        {
            get;
            set;
        }
        public int TaskNotificationMasterStatus
        {
            get;
            set;
        }
        public int TaskNotificationDetailsID
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public int LeaveApplicationTransactionHistoryID
        {
            get;
            set;
        }
        public int LeaveApplicationTransactionID
        {
            get;
            set;
        }
        public string LeaveDate
        {
            get;
            set;
        }
        public string FullDayHalfDayDetails
        {
            get;
            set;
        }
        public string LeaveApprovalStatus
        {
            get;
            set;
        }

        public int NumberOfApprovalStages
        {
            get;
            set;
        }
        public Int16 DaysBeforeApplicationSubmitted
        {
            get;
            set;
        }
        public int TotalRecords
        {
            get;
            set;
        }
        public int RowNumber
        {
            get;
            set;
        }
        
        public string SelectedIDs
        {
            get;
            set;
        }
        public string ApprovalStatusList
        {
            get;
            set;
        }

        /// <summary>
        /// fields for leave attached document//////////////////
        /// </summary>
        public int LeaveAttachedDocumentID            ////////ID for Leave Attached Document
        {
            get;
            set;
        }
        public int DocumentRequiredID
        {
            get;
            set;
        }
        public string DateOfSubmission
        {
            get;
            set;
        }
        public string FileName
        {
            get;
            set;
        }
        public bool DocumentCompulsaryFlag
        {
            get;
            set;
        }
        public bool DocumentRequiredFlag
        {
            get;
            set;
        }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string EntityLevel { get; set; }
        public string CentreName { get; set; }
        public string LeaveList { get; set; }

        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeLastName { get; set; }
        public string LeaveSessionName { get; set; }
        public int DOJAndCurrentSessionDifferenceInMonth { get; set; }

        public double TotalBalanceLeaves
        {
            get;
            set;
        }
    }
}
