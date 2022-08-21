using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveAvailedViewModel : ILeaveAvailedViewModel
    {
        public LeaveAvailedViewModel()
        {
            LeaveAvailedDTO = new LeaveAvailed();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public LeaveAvailed LeaveAvailedDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.ID > 0) ? LeaveAvailedDTO.ID : new int();
            }
            set
            {
                LeaveAvailedDTO.ID = value;
            }
        }

        public int LeaveApprovedID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.LeaveApprovedID > 0) ? LeaveAvailedDTO.LeaveApprovedID : new int();
            }
            set
            {
                LeaveAvailedDTO.LeaveApprovedID = value;
            }
        }

       // [Display(Name = "DisplayName_LeaveAvailedFromDate", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveAvailedFromDateRequired")]
        public string LeaveAvailedFromDate
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveAvailedFromDate : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LeaveAvailedFromDate = value;
            }
        }

       // [Display(Name = "DisplayName_LeaveAvailedUptoDate", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveAvailedUptoDateRequired")]
        public string LeaveAvailedUptoDate
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveAvailedUptoDate : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LeaveAvailedUptoDate = value;
            }
        }

       // [Display(Name = "DisplayName_TotalFullDay", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalFullDayRequired")]
        public Int16 TotalFullDay
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TotalFullDay > 0) ? LeaveAvailedDTO.TotalFullDay : new Int16();
            }
            set
            {
                LeaveAvailedDTO.TotalFullDay = value;
            }
        }

        //[Display(Name = "DisplayName_TotalHalfDay", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalHalfDayRequired")]
        public Int16 TotalHalfDay
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TotalHalfDay > 0) ? LeaveAvailedDTO.TotalHalfDay : new Int16();
            }
            set
            {
                LeaveAvailedDTO.TotalHalfDay = value;
            }
        }

        // [Display(Name = "DisplayName_HalfLeaveStartStatus", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_HalfLeaveStartStatusRequired")]
        public string HalfLeaveStartStatus
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.HalfLeaveStartStatus : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.HalfLeaveStartStatus = value;
            }
        }

       // [Display(Name = "DisplayName_LeaveSummaryID", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveSummaryIDRequired")]
        public int LeaveSummaryID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.LeaveSummaryID > 0) ? LeaveAvailedDTO.LeaveSummaryID : new int();
            }
            set
            {
                LeaveAvailedDTO.LeaveSummaryID = value;
            }
        }

        // [Display(Name = "DisplayName_Remark", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RemarkRequired")]
        public string Remark
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.Remark : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.Remark = value;
            }
        }


        // [Display(Name = "DisplayName_LeaveStatus", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveStatusRequired")]
        public string LeaveStatus
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveStatus : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LeaveStatus = value;
            }
        }

        // [Display(Name = "DisplayName_LeaveAvailedFromDateOrganisation", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveAvailedFromDateOrganisationRequired")]
        public string LeaveAvailedFromDateOrganisation
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveAvailedFromDateOrganisation : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LeaveAvailedFromDateOrganisation = value;
            }
        }


        // [Display(Name = "DisplayName_LeaveAvailedUptoDateOrganisation", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveAvailedUptoDateOrganisationRequired")]
        public string LeaveAvailedUptoDateOrganisation
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveAvailedUptoDateOrganisation : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LeaveAvailedUptoDateOrganisation = value;
            }
        }

        // [Display(Name = "DisplayName_LeaveSummaryID", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveSummaryIDRequired")]
        public Int16 TotalFullDayOrganisation
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TotalFullDayOrganisation > 0) ? LeaveAvailedDTO.TotalFullDayOrganisation : new Int16();
            }
            set
            {
                LeaveAvailedDTO.TotalFullDayOrganisation = value;
            }
        }

        // [Display(Name = "DisplayName_TotalHalfDayOrganisation", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalHalfDayOrganisationRequired")]
        public Int16 TotalHalfDayOrganisation
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TotalHalfDayOrganisation > 0) ? LeaveAvailedDTO.TotalHalfDayOrganisation : new Int16();
            }
            set
            {
                LeaveAvailedDTO.TotalHalfDayOrganisation = value;
            }
        }

        // [Display(Name = "DisplayName_LeaveApplicationID", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveApplicationIDRequired")]
        public int LeaveApplicationID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.LeaveApplicationID > 0) ? LeaveAvailedDTO.LeaveApplicationID : new int();
            }
            set
            {
                LeaveAvailedDTO.LeaveApplicationID = value;
            }
        }

        public int LeaveMasterID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.LeaveMasterID > 0) ? LeaveAvailedDTO.LeaveMasterID : new int();
            }
            set
            {
                LeaveAvailedDTO.LeaveMasterID = value;
            }
        }
       
        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.CentreCode = value;
            }
        }

        public string CentreName
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.CentreName = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.IsActive : false;
            }
            set
            {
                LeaveAvailedDTO.IsActive = value;
            }
        }

        // [Display(Name = "DisplayName_LeaveCreditDetailsID", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCreditDetailsIDRequired")]
        public int LeaveCreditDetailsID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.LeaveCreditDetailsID > 0) ? LeaveAvailedDTO.LeaveCreditDetailsID : new int();
            }
            set
            {
                LeaveAvailedDTO.LeaveCreditDetailsID = value;
            }
        }

       // [Display(Name = "DisplayName_LeaveAvailedFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool LeaveAvailedFlag
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveAvailedFlag : false;
            }
            set
            {
                LeaveAvailedDTO.LeaveAvailedFlag = value;
            }
        }

        // [Display(Name = "DisplayName_LeaveCancelCreditID", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCancelCreditIDRequired")]
        public int LeaveCancelCreditID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.LeaveCreditDetailsID > 0) ? LeaveAvailedDTO.LeaveCancelCreditID : new int();
            }
            set
            {
                LeaveAvailedDTO.LeaveCancelCreditID = value;
            }
        }

        [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.IsDeleted : false;
            }
            set
            {
                LeaveAvailedDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.CreatedBy > 0) ? LeaveAvailedDTO.CreatedBy : new int();
            }
            set
            {
                LeaveAvailedDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveAvailedDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.ModifiedBy.HasValue) ? LeaveAvailedDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveAvailedDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveAvailedDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.DeletedBy.HasValue) ? LeaveAvailedDTO.DeletedBy : new int();
            }
            set
            {
                LeaveAvailedDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveAvailedDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string EntityLevel { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public bool IsActiveMember
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.IsActiveMember : false;
            }
            set
            {
                LeaveAvailedDTO.IsActiveMember = value;
            }
        }

        #region -------------- TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TaskNotificationMasterID > 0) ? LeaveAvailedDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                LeaveAvailedDTO.TaskNotificationMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string TaskCode
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.TaskCode : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.TaskCode = value;
            }
        }

        public int TaskNotificationDetailsID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TaskNotificationDetailsID > 0) ? LeaveAvailedDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                LeaveAvailedDTO.TaskNotificationDetailsID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.GeneralTaskReportingDetailsID > 0) ? LeaveAvailedDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                LeaveAvailedDTO.GeneralTaskReportingDetailsID = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.PersonID > 0) ? LeaveAvailedDTO.PersonID : new int();
            }
            set
            {
                LeaveAvailedDTO.PersonID = value;
            }
        }

        public int StageSequenceNumber
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.StageSequenceNumber > 0) ? LeaveAvailedDTO.StageSequenceNumber : new int();
            }
            set
            {
                LeaveAvailedDTO.StageSequenceNumber = value;
            }
        }

        public bool IsLastRecord
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.IsLastRecord : false;
            }
            set
            {
                LeaveAvailedDTO.IsLastRecord = value;
            }
        }
        
        #endregion

        #region -------------- Leave Request for Approval ---------------
        //[Display(Name = "DisplayName_LeaveDescription", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveDescriptionRequired")]
        public string LeaveDescription
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveDescription : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LeaveDescription = value;
            }
        }

        //[Display(Name = "DisplayName_LeaveReason", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveReasonRequired")]
        public string LeaveReason
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveReason : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LeaveReason = value;
            }
        }


        //[Display(Name = "DisplayName_LastApprovalStatus", ResourceType = typeof(AERP.Common.Resources))]       
        public string LastApprovalStatus
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LastApprovalStatus : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LastApprovalStatus = value;
            }
        }

        //[Display(Name = "DisplayName_Dates", ResourceType = typeof(AERP.Common.Resources))]       
        public string Dates
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.Dates : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.Dates = value;
            }
        }
        public Boolean ActionFlag
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.ActionFlag : false;
            }
            set
            {
                LeaveAvailedDTO.ActionFlag = value;
            }
        }


        //[Display(Name = "DisplayName_FullDayHalfDayFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool FullDayHalfDayFlag
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.FullDayHalfDayFlag : false;
            }
            set
            {
                LeaveAvailedDTO.FullDayHalfDayFlag = value;
            }
        }

        //[Display(Name = "DisplayName_HalfLeaveStatus", ResourceType = typeof(AERP.Common.Resources))]       
        public string HalfLeaveStatus
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.HalfLeaveStatus : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.HalfLeaveStatus = value;
            }
        }

        //[Display(Name = "DisplayName_ApprovalStatus", ResourceType = typeof(AERP.Common.Resources))]       
        public string ApprovalStatus
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.ApprovalStatus : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.ApprovalStatus = value;
            }
        }

        public int LeaveApplicationTransactionID
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.LeaveApplicationTransactionID > 0) ? LeaveAvailedDTO.LeaveApplicationTransactionID : new int();
            }
            set
            {
                LeaveAvailedDTO.LeaveApplicationTransactionID = value;
            }
        }

        public string SelectedIDs 
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.SelectedIDs  : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.SelectedIDs = value;
            }
        }
        public float TotalDays
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TotalDays > 0) ? LeaveAvailedDTO.TotalDays : new float();
            }
            set
            {
                LeaveAvailedDTO.TotalDays = value;
            }
        }
        public string LeaveTransactionHistoryStatus 
        {
            get
            {
                return (LeaveAvailedDTO != null) ? LeaveAvailedDTO.LeaveTransactionHistoryStatus : string.Empty;
            }
            set
            {
                LeaveAvailedDTO.LeaveTransactionHistoryStatus = value;
            }
        }
        public float TotalApprovedFullDay
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TotalApprovedFullDay > 0) ? LeaveAvailedDTO.TotalApprovedFullDay : new float();
            }
            set
            {
                LeaveAvailedDTO.TotalApprovedFullDay = value;
            }
        }
        public float TotalApprovedHalfDay
        {
            get
            {
                return (LeaveAvailedDTO != null && LeaveAvailedDTO.TotalApprovedHalfDay > 0) ? LeaveAvailedDTO.TotalApprovedHalfDay : new float();
            }
            set
            {
                LeaveAvailedDTO.TotalApprovedHalfDay = value;
            }
        }
        #endregion
    }
}
