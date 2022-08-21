using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public interface ILeaveAvailedViewModel
    {
        LeaveAvailed LeaveAvailedDTO
        {
            get;
            set;
        }

        #region ---------------- LeaveAvailed Properties-----------------
        int ID
        {
            get;
            set;
        }
         int LeaveApprovedID
        {
            get;
            set;
        }
         string LeaveAvailedFromDate
        {
            get;
            set;
        }
         string LeaveAvailedUptoDate
        {
            get;
            set;
        }
         Int16 TotalFullDay
        {
            get;
            set;
        }
         Int16 TotalHalfDay
        {
            get;
            set;
        }
         string HalfLeaveStartStatus
        {
            get;
            set;
        }
         int LeaveSummaryID
        {
            get;
            set;
        }
         string Remark
        {
            get;
            set;
        }
         string LeaveStatus
        {
            get;
            set;
        }
         string LeaveAvailedFromDateOrganisation
        {
            get;
            set;
        }
         string LeaveAvailedUptoDateOrganisation
        {
            get;
            set;
        }
         Int16 TotalFullDayOrganisation
        {
            get;
            set;
        }
         Int16 TotalHalfDayOrganisation
        {
            get;
            set;
        }
         int LeaveApplicationID
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }

         string CentreName
         {
             get;
             set;
         }
         bool IsActive
        {
            get;
            set;
        }
         int LeaveCreditDetailsID
        {
            get;
            set;
        }
         bool LeaveAvailedFlag
        {
            get;
            set;
        }
         int LeaveCancelCreditID
        {
            get;
            set;
        }
         bool IsDeleted
        {
            get;
            set;
        }
         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int? ModifiedBy
        {
            get;
            set;
        }
         DateTime? ModifiedDate
        {
            get;
            set;
        }
         int? DeletedBy
        {
            get;
            set;
        }
         DateTime? DeletedDate
        {
            get;
            set;
        }
        string EntityLevel { get; set; } 
        string errorMessage { get; set; }
        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        #endregion

        #region -------------- TaskNotification Properties---------------
        int TaskNotificationMasterID
        {
            get;
            set;
        }
        string TaskCode
        {
            get;
            set;
        }
        int TaskNotificationDetailsID
        {
            get;
            set;
        }
        int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        int PersonID
        {
            get;
            set;
        }
        int StageSequenceNumber
        {
            get;
            set;
        }
        bool IsLastRecord
        {
            get;
            set;
        }
        bool IsActiveMember
        {
            get;
            set;
        }
        #endregion

        #region --------------- Leave Request for Approval---------------
        string LeaveDescription
        {
            get;
            set;
        }
        string LeaveReason
        {
            get;
            set;
        }
        string LastApprovalStatus
        {
            get;
            set;
        }
        string Dates
        {
            get;
            set;
        }
        bool FullDayHalfDayFlag
        {
            get;
            set;
        }
        string HalfLeaveStatus
        {
            get;
            set;
        }
        string ApprovalStatus
        {
            get;
            set;
        }
        int LeaveApplicationTransactionID
        {
            get;
            set;
        }
        int LeaveMasterID
        {
            get;
            set;
        }
        string SelectedIDs 
        {
            get;
            set;
        }
       float TotalDays
        {
            get;
            set;
        }
       float TotalApprovedFullDay
        {
            get;
            set;
        }
       float TotalApprovedHalfDay
        {
            get;
            set;
        }
        
       string LeaveTransactionHistoryStatus
       {
           get;
           set;
       }
        #endregion
    }
}
