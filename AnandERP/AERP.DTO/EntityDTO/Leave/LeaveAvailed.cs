using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveAvailed : BaseDTO
    {
        
        #region -------------- Leave Availed Properties---------------
        public int ID
        {
            get;
            set;
        }
        public int LeaveApprovedID
        {
            get;
            set;
        }
        public string LeaveAvailedFromDate
        {
            get;
            set;
        }
        public string LeaveAvailedUptoDate
        {
            get;
            set;
        }
        public Int16 TotalFullDay
        {
            get;
            set;
        }
        public Int16 TotalHalfDay
        {
            get;
            set;
        }
        public string HalfLeaveStartStatus
        {
            get;
            set;
        }
        public int LeaveSummaryID
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }
        public string LeaveStatus
        {
            get;
            set;
        }
        public string LeaveAvailedFromDateOrganisation
        {
            get;
            set;
        }
        public string LeaveAvailedUptoDateOrganisation
        {
            get;
            set;
        }
        public Int16 TotalFullDayOrganisation
        {
            get;
            set;
        }
        public Int16 TotalHalfDayOrganisation
        {
            get;
            set;
        }
        public int LeaveApplicationID
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
        public int LeaveMasterID
        {
            get;
            set;
        }
        public Boolean ActionFlag
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public int LeaveCreditDetailsID
        {
            get;
            set;
        }
        public bool LeaveAvailedFlag
        {
            get;
            set;
        }
        public int LeaveCancelCreditID
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
        public string errorMessage
        {
            get;
            set;
        }
        #endregion

        #region ------------TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public int TaskNotificationDetailsID
        {
            get;
            set;
        }
        public int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public int StageSequenceNumber
        {
            get;
            set;
        }
        public bool IsLastRecord
        {
            get;
            set;
        }
        public bool IsActiveMember
        {
            get;
            set;
        }
        
        #endregion

        #region --------Leave Request for Approval Properties---------
        public string LeaveDescription
        {
            get;
            set;
        }       
        public string LeaveReason
        {
            get;
            set;
        }
        public string LastApprovalStatus
        {
            get;
            set;
        }
        public string Dates
        {
            get;
            set;
        }
        public bool FullDayHalfDayFlag
        {
            get;
            set;
        }
        public string HalfLeaveStatus
        {
            get;
            set;
        }
        public string ApprovalStatus
        {
            get;
            set;
        }
        public int LeaveApplicationTransactionID
        {
            get;
            set;
        }
        public string SelectedIDs 
        {
            get;
            set;
        }
        public float TotalDays
        {
            get;
            set;
        }
        public float TotalApprovedFullDay
        {
            get;
            set;
        }
        public float TotalApprovedHalfDay
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public string LeaveTransactionHistoryStatus
        {
            get;
            set;
        }
        #endregion
    }
}
