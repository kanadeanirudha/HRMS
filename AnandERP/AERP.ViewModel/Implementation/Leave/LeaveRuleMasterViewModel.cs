using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveRuleMasterViewModel : ILeaveRuleMasterViewModel
    {
        public LeaveRuleMasterViewModel()
        {
            LeaveRuleMasterDTO = new LeaveRuleMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            employeeAccumulationMethod = new List<SelectListItem>();

        }
        public LeaveRuleMaster LeaveRuleMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.ID > 0) ? LeaveRuleMasterDTO.ID : new int();
            }
            set
            {
                LeaveRuleMasterDTO.ID = value;
            }
        }

        public int LeaveMasterID
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.LeaveMasterID > 0) ? LeaveRuleMasterDTO.LeaveMasterID : new int();
            }
            set
            {
                LeaveRuleMasterDTO.LeaveMasterID = value;
            }
        }

        [Display(Name = "DisplayName_LeaveDescription", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveDescriptionRequired")]
        public string LeaveDescription
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.LeaveDescription : string.Empty;
            }
            set
            {
                LeaveRuleMasterDTO.LeaveDescription = value;
            }
        }

        [Display(Name = "DisplayName_LeaveRuleDescription", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveRuleDescriptionRequired")]
        public string LeaveRuleDescription
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.LeaveRuleDescription : string.Empty;
            }
            set
            {
                LeaveRuleMasterDTO.LeaveRuleDescription = value;
            }
        }

        [Display(Name = "DisplayName_NumberOfLeaves", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NumberOfLeavesRequired")]
        public Int16 NumberOfLeaves
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.NumberOfLeaves > 0) ? LeaveRuleMasterDTO.NumberOfLeaves : new Int16();
            }
            set
            {
                LeaveRuleMasterDTO.NumberOfLeaves = value;
            }
        }
        
        [Display(Name = "DisplayName_MaxLeaveAtTime", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveAtTimeRequired")]
        public Int16 MaxLeaveAtTime
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.MaxLeaveAtTime > 0) ? LeaveRuleMasterDTO.MaxLeaveAtTime : new Int16();
            }
            set
            {
                LeaveRuleMasterDTO.MaxLeaveAtTime = value;
            }
        }

        [Display(Name = "DisplayName_MinimumLeaveEncash", ResourceType = typeof(AERP.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MinimumLeaveEncashRequired")]
        public int MinimumLeaveEncash
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.MinimumLeaveEncash > 0) ? LeaveRuleMasterDTO.MinimumLeaveEncash : new int();
            }
            set
            {
                LeaveRuleMasterDTO.MinimumLeaveEncash = value;
            }
        }

        [Display(Name = "DisplayName_MaxLeaveEncash", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveEncashRequired")]
        public int MaxLeaveEncash
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.MaxLeaveEncash > 0) ? LeaveRuleMasterDTO.MaxLeaveEncash : new int();
            }
            set
            {
                LeaveRuleMasterDTO.MaxLeaveEncash = value;
            }
        }

        [Display(Name = "DisplayName_MaxLeaveAccumulated", ResourceType = typeof(AERP.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveAccumlatedRequired")]
        public int MaxLeaveAccumulated
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.MaxLeaveAccumulated > 0) ? LeaveRuleMasterDTO.MaxLeaveAccumulated : new int();
            }
            set
            {
                LeaveRuleMasterDTO.MaxLeaveAccumulated = value;
            }
        }

        [Display(Name = "DisplayName_MinServiceRequiredInMonth", ResourceType = typeof(AERP.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MinServiceRequiredInMonthRequired")]
        public int MinServiceRequiredInMonth
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.MinServiceRequiredInMonth > 0) ? LeaveRuleMasterDTO.MinServiceRequiredInMonth : new int();
            }
            set
            {
                LeaveRuleMasterDTO.MinServiceRequiredInMonth = value;
            }
        }

        [Display(Name = "DisplayName_AttendDaysRequiredInMonth", ResourceType = typeof(AERP.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AttendDaysRequiredRequired")]
        public int AttendDaysRequired
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.AttendDaysRequired > 0) ? LeaveRuleMasterDTO.AttendDaysRequired : new int();
            }
            set
            {
                LeaveRuleMasterDTO.AttendDaysRequired = value;
            }
        }
         //[Display(Name = "DisplayName_CreditDependOn", ResourceType = typeof(AMS.Common.Resources))]
         //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CreditDependOnRequired")]
        public string CreditDependOn
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.CreditDependOn : string.Empty;
            }
            set
            {
                LeaveRuleMasterDTO.CreditDependOn = value;
            }
        }

        [Display(Name = "DisplayName_DayOfTheMonth", ResourceType = typeof(AERP.Common.Resources))]
          //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DayOfTheMonthRequired")]
        public int DayOfTheMonth
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.DayOfTheMonth > 0) ? LeaveRuleMasterDTO.DayOfTheMonth : new int();
            }
            set
            {
                LeaveRuleMasterDTO.DayOfTheMonth = value;
            }
        }
        [Display(Name = "DisplayName_DaysBeforeApplicationSubmitted", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessage = "Days Before Application Submitted should not be blank.")]
         //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DayOfTheMonthRequired")]
        public Int16 DaysBeforeApplicationSubmitted
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.DaysBeforeApplicationSubmitted > 0) ? LeaveRuleMasterDTO.DaysBeforeApplicationSubmitted : new Int16();
            }
            set
            {
                LeaveRuleMasterDTO.DaysBeforeApplicationSubmitted = value;
            }
        }
        [Display(Name = "Maximum Accumulated")]
        [Required(ErrorMessage = "Days After Application Submitted should not be blank.")]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DayOfTheMonthRequired")]
        public Int16 DaysAfterApplicationSubmitted
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.DaysAfterApplicationSubmitted > 0) ? LeaveRuleMasterDTO.DaysAfterApplicationSubmitted : new Int16();
            }
            set
            {
                LeaveRuleMasterDTO.DaysAfterApplicationSubmitted = value;
            }
        }
        [Display(Name = "Accumulated Period (months)")]
        [Required(ErrorMessage = "Accumulated Period (months) should not be blank.")]
        public Int16 NumberOfMonths
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.NumberOfMonths > 0) ? LeaveRuleMasterDTO.NumberOfMonths : new Int16();
            }
            set
            {
                LeaveRuleMasterDTO.NumberOfMonths = value;
            }
        }
        [Display(Name = "Accumulated Leaves")]
        [Required(ErrorMessage = "Accumulated Leaves should not be blank.")]
        public Int16 NumberOfAccumulatedLeaves
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.NumberOfAccumulatedLeaves > 0) ? LeaveRuleMasterDTO.NumberOfAccumulatedLeaves : new Int16();
            }
            set
            {
                LeaveRuleMasterDTO.NumberOfAccumulatedLeaves = value;
            }
        }
        [Display(Name = "Days After to Inform")]
        [Required(ErrorMessage = "Days After to Inform should not be blank.")]
         //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DayOfTheMonthRequired")]
        public Int16 LeaveApplicationSubmittedUptoDays
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.LeaveApplicationSubmittedUptoDays > 0) ? LeaveRuleMasterDTO.LeaveApplicationSubmittedUptoDays : new Int16();
            }
            set
            {
                LeaveRuleMasterDTO.LeaveApplicationSubmittedUptoDays = value;
            }
        }
         [Display(Name = "Is Leave Accumulate Periodically")]
        public bool IsLeaveAccumulatePeriodically
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.IsLeaveAccumulatePeriodically : false;
            }
            set
            {
                LeaveRuleMasterDTO.IsLeaveAccumulatePeriodically = value;
            }
        }
        [Display(Name = "DisplayName_IsLocked", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsLocked
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.IsLocked : false;
            }
            set
            {
                LeaveRuleMasterDTO.IsLocked = value;
            }
        }

        [Display(Name = "DisplayName_MinLeavesAtTime", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MinLeavesAtTimeRequired")]
        public double MinLeavesAtTime
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.MinLeavesAtTime : new double();
            }
            set
            {
                LeaveRuleMasterDTO.MinLeavesAtTime = value;
            }
        }
        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveRuleMasterDTO.CentreCode = value;
            }
        }

        public string CentreName
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveRuleMasterDTO.CentreName = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.IsActive : false;
            }
            set
            {
                LeaveRuleMasterDTO.IsActive = value;
            }
        }
        [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.IsDeleted : false;
            }
            set
            {
                LeaveRuleMasterDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.CreatedBy > 0) ? LeaveRuleMasterDTO.CreatedBy : new int();
            }
            set
            {
                LeaveRuleMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.ModifiedBy.HasValue) ? LeaveRuleMasterDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveRuleMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.DeletedBy.HasValue) ? LeaveRuleMasterDTO.DeletedBy : new int();
            }
            set
            {
                LeaveRuleMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string EntityLevel { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public List<SelectListItem> employeeAccumulationMethod
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

        [Display(Name = "Accumulation Method")]
        [Required(ErrorMessage = "Accumulation Method should not be blank.")]
        public Int16 AccumulationMethod
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.AccumulationMethod > 0) ? LeaveRuleMasterDTO.AccumulationMethod : new Int16();
            }
            set
            {
                LeaveRuleMasterDTO.AccumulationMethod = value;
            }
        }

        [Display(Name = "Leave Encash Formula")]
        public string LeaveEncashFormula
        {
            get
            {
                return (LeaveRuleMasterDTO != null) ? LeaveRuleMasterDTO.LeaveEncashFormula : string.Empty;
            }
            set
            {
                LeaveRuleMasterDTO.LeaveEncashFormula = value;
            }
        }
        [Display(Name = "Leave Month Ratio")]
        [Required(ErrorMessage = "Leave Month Ratio should not be blank.")]
        public decimal LeaveMonthRatio
        {
            get
            {
                return (LeaveRuleMasterDTO != null && LeaveRuleMasterDTO.LeaveMonthRatio > 0) ? LeaveRuleMasterDTO.LeaveMonthRatio : new decimal();
            }
            set
            {
                LeaveRuleMasterDTO.LeaveMonthRatio = value;
            }
        }

   
    }
}
