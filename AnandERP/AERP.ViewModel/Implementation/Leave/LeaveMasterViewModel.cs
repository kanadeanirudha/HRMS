using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveMasterViewModel : ILeaveMasterViewModel
    {
        public LeaveMasterViewModel()
        {
            LeaveMasterDTO = new LeaveMaster();
        }

        public LeaveMaster LeaveMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.ID > 0) ? LeaveMasterDTO.ID : new int();
            }
            set
            {
                LeaveMasterDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AERP.Common.Resources))]
        
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string LeaveCode
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.LeaveCode : string.Empty;
            }
            set
            {
                LeaveMasterDTO.LeaveCode = value;
            }
        }
        [Display(Name = "DisplayName_LeaveTypeDesc", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveTypeDescRequired")]
        public string LeaveDescription
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.LeaveDescription : string.Empty;
            }
            set
            {
                LeaveMasterDTO.LeaveDescription = value;
            }
        }

        [Display(Name = "DisplayName_IsCarryForwardForNextYear", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsCarryForwardForNextYear
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsCarryForwardForNextYear : false;
            }
            set
            {
                LeaveMasterDTO.IsCarryForwardForNextYear = value;
            }
        }

        [Display(Name = "DisplayName_IsEnCash", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsEnCash
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsEnCash : false;
            }
            set
            {
                LeaveMasterDTO.IsEnCash = value;
            }
        }

        [Display(Name = "DisplayName_AttendanceNeeded", ResourceType = typeof(AERP.Common.Resources))]
        public bool AttendanceNeeded
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.AttendanceNeeded : false;
            }
            set
            {
                LeaveMasterDTO.AttendanceNeeded = value;
            }
        }

        [Display(Name = "DisplayName_DocumentsNeeded", ResourceType = typeof(AERP.Common.Resources))]
        public bool DocumentsNeeded
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.DocumentsNeeded : false;
            }
            set
            {
                LeaveMasterDTO.DocumentsNeeded = value;
            }
        }

        [Display(Name = "Need to Inform In Advance?")]
        public bool NeedToInformInAdvance
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.NeedToInformInAdvance : false;
            }
            set
            {
                LeaveMasterDTO.NeedToInformInAdvance = value;
            }
        }


        [Display(Name = "DisplayName_HalfDayFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool HalfDayFlag
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.HalfDayFlag : false;
            }
            set
            {
                LeaveMasterDTO.HalfDayFlag = value;
            }
        }

        [Display(Name = "DisplayName_LossOfPay", ResourceType = typeof(AERP.Common.Resources))]
        public bool LossOfPay
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.LossOfPay : false;
            }
            set
            {
                LeaveMasterDTO.LossOfPay = value;
            }
        }

         [Display(Name = "DisplayName_NoCredit", ResourceType = typeof(AERP.Common.Resources))]
        public bool NoCredit
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.NoCredit : false;
            }
            set
            {
                LeaveMasterDTO.NoCredit = value;
            }
        }

         [Display(Name = "DisplayName_MinServiceRequire", ResourceType = typeof(AERP.Common.Resources))]
        public bool MinServiceRequire
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.MinServiceRequire : false;
            }
            set
            {
                LeaveMasterDTO.MinServiceRequire = value;
            }
        }

         [Display(Name = "DisplayName_OnDuty", ResourceType = typeof(AERP.Common.Resources))]
        public bool OnDuty
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.OnDuty : false;
            }
            set
            {
                LeaveMasterDTO.OnDuty = value;
            }
        }
         [Display(Name = "Is Posted Once?")]
         public bool IsPostedOnce
         {
             get
             {
                 return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsPostedOnce : false;
             }
             set
             {
                 LeaveMasterDTO.IsPostedOnce = value;
             }
         }


        [Display(Name = "DisplayName_LeaveType", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveTypeRequired")]
        
        public string LeaveType
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.LeaveType : string.Empty;
            }
            set
            {
                LeaveMasterDTO.LeaveType = value;
            }
        }
        // [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsActive : false;
            }
            set
            {
                LeaveMasterDTO.IsActive = value;
            }
        }
        // [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsDeleted : false;
            }
            set
            {
                LeaveMasterDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.CreatedBy > 0) ? LeaveMasterDTO.CreatedBy : new int();
            }
            set
            {
                LeaveMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.ModifiedBy.HasValue) ? LeaveMasterDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.ModifiedDate.HasValue) ? LeaveMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.DeletedBy.HasValue) ? LeaveMasterDTO.DeletedBy : new int();
            }
            set
            {
                LeaveMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.DeletedDate.HasValue) ? LeaveMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }


        public string VersionNumber
        {

            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                LeaveMasterDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.LastSyncDate.HasValue) ? LeaveMasterDTO.LastSyncDate : null;
            }
            set
            {
                LeaveMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.SyncType : string.Empty;
            }
            set
            {
                LeaveMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.Entity : string.Empty;
            }
            set
            {
                LeaveMasterDTO.Entity = value;
            }
        }


        [Display(Name = "DisplayName_NumberOfLeaves", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NumberOfLeavesRequired")]
        public Int16 NumberOfLeaves
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.NumberOfLeaves > 0) ? LeaveMasterDTO.NumberOfLeaves : new Int16();
            }
            set
            {
                LeaveMasterDTO.NumberOfLeaves = value;
            }
        }

        [Display(Name = "DisplayName_MaxLeaveAtTime", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveAtTimeRequired")]
        public Int16 MaxLeaveAtTime
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.MaxLeaveAtTime > 0) ? LeaveMasterDTO.MaxLeaveAtTime : new Int16();
            }
            set
            {
                LeaveMasterDTO.MaxLeaveAtTime = value;
            }
        }

        [Display(Name = "DisplayName_MinimumLeaveEncash", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MinimumLeaveEncashRequired")]
        public int MinimumLeaveEncash
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.MinimumLeaveEncash > 0) ? LeaveMasterDTO.MinimumLeaveEncash : new int();
            }
            set
            {
                LeaveMasterDTO.MinimumLeaveEncash = value;
            }
        }

        [Display(Name = "DisplayName_MaxLeaveEncash", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveEncashRequired")]
        public int MaxLeaveEncash
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.MaxLeaveEncash > 0) ? LeaveMasterDTO.MaxLeaveEncash : new int();
            }
            set
            {
                LeaveMasterDTO.MaxLeaveEncash = value;
            }
        }

        [Display(Name = "DisplayName_MaxLeaveAccumulated", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveAccumlatedRequired")]
        public int MaxLeaveAccumulated
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.MaxLeaveAccumulated > 0) ? LeaveMasterDTO.MaxLeaveAccumulated : new int();
            }
            set
            {
                LeaveMasterDTO.MaxLeaveAccumulated = value;
            }
        }

        [Display(Name = "DisplayName_MinServiceRequiredInMonth", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MinServiceRequiredInMonthRequired")]
        public int MinServiceRequiredInMonth
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.MinServiceRequiredInMonth > 0) ? LeaveMasterDTO.MinServiceRequiredInMonth : new int();
            }
            set
            {
                LeaveMasterDTO.MinServiceRequiredInMonth = value;
            }
        }

        [Display(Name = "DisplayName_AttendDaysRequiredInMonth", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AttendDaysRequiredRequired")]
        public int AttendDaysRequired
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.AttendDaysRequired > 0) ? LeaveMasterDTO.AttendDaysRequired : new int();
            }
            set
            {
                LeaveMasterDTO.AttendDaysRequired = value;
            }
        }
        //[Display(Name = "DisplayName_CreditDependOn", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CreditDependOnRequired")]
        public string CreditDependOn
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.CreditDependOn : string.Empty;
            }
            set
            {
                LeaveMasterDTO.CreditDependOn = value;
            }
        }

        public Int16 DaysBeforeApplicationSubmitted
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.DaysBeforeApplicationSubmitted > 0) ? LeaveMasterDTO.DaysBeforeApplicationSubmitted : new Int16();
            }
            set
            {
                LeaveMasterDTO.DaysBeforeApplicationSubmitted = value;
            }
        }
        [Display(Name = "Maximum Accumulated")]
        [Required(ErrorMessage = "Days After Application Submitted should not be blank.")]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DayOfTheMonthRequired")]
        public Int16 DaysAfterApplicationSubmitted
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.DaysAfterApplicationSubmitted > 0) ? LeaveMasterDTO.DaysAfterApplicationSubmitted : new Int16();
            }
            set
            {
                LeaveMasterDTO.DaysAfterApplicationSubmitted = value;
            }
        }

    }
}
