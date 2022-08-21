using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveRuleApplicableDetailsViewModel : ILeaveRuleApplicableDetailsViewModel
    {
        public LeaveRuleApplicableDetailsViewModel()
        {
            LeaveRuleApplicableDetailsDTO = new LeaveRuleApplicableDetails();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListLeaveSession = new List<LeaveSession>();
        }
        public LeaveRuleApplicableDetails LeaveRuleApplicableDetailsDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.ID > 0) ? LeaveRuleApplicableDetailsDTO.ID : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_LeaveRuleMasterID", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveRuleMasterIDRequired")]
        public int LeaveRuleMasterID
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.LeaveRuleMasterID > 0) ? LeaveRuleApplicableDetailsDTO.LeaveRuleMasterID : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveRuleMasterID = value;
            }
        }

        public string CombinationRuleCode
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.CombinationRuleCode : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.CombinationRuleCode = value;
            }
        }
        [Display(Name = "DisplayName_LeaveRuleMasterDescription", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveRuleMasterDescriptionRequired")]
        public string LeaveRuleMasterDescription
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.LeaveRuleMasterDescription : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveRuleMasterDescription = value;
            }
        }

        public int LeaveSessionID
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.LeaveSessionID > 0) ? LeaveRuleApplicableDetailsDTO.LeaveSessionID : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveSessionID = value;
            }
        }

        //[Display(Name = "DisplayName_LeaveSessionName", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveSessionNameRequired")]
        public int LeaveMasterID
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.LeaveMasterID > 0) ? LeaveRuleApplicableDetailsDTO.LeaveMasterID : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveMasterID = value;
            }
        }

        [Display(Name = "DisplayName_JobStatus", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobStatusIDRequired")]
        public int JobStatusID
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.JobStatusID > 0) ? LeaveRuleApplicableDetailsDTO.JobStatusID : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.JobStatusID = value;
            }
        }

        [Display(Name = "DisplayName_JobProfileID", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobProfileIDRequired")]
        public int JobProfileID
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.JobProfileID > 0) ? LeaveRuleApplicableDetailsDTO.JobProfileID : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.JobProfileID = value;
            }
        }
        [Display(Name = "DisplayName_JobStatusCode", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobStatusCodeRequired")]
        public string JobStatusCode
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.JobStatusCode : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.JobStatusCode = value;
            }
        }
        public string JobProfileDescription
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.JobProfileDescription : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.JobProfileDescription = value;
            }
        }
        public string JobStatusDescription
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.JobStatusDescription : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.JobStatusDescription = value;
            }
        }

         [Display(Name = "DisplayName_IsCurrentLeaveSession", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsCurrentLeaveSession
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.IsCurrentLeaveSession : false;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.IsCurrentLeaveSession = value;
            }
        }
        [Display(Name = "DisplayName_IsCurrentFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsCurrentFlag
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.IsCurrentFlag : false;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.IsCurrentFlag = value;
            }
        }
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.IsActive : false;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.IsActive = value;
            }
        }
        public int StatusFlag
        {
            get
           {
               return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.StatusFlag > 0) ? LeaveRuleApplicableDetailsDTO.StatusFlag : new int();
           }
            set
           {
               LeaveRuleApplicableDetailsDTO.StatusFlag = value;
            }
        }
        public int TotalRecords
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.TotalRecords > 0) ? LeaveRuleApplicableDetailsDTO.TotalRecords : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.TotalRecords = value;
            }
        }
        [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.IsDeleted : false;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.CreatedBy > 0) ? LeaveRuleApplicableDetailsDTO.CreatedBy : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.ModifiedBy.HasValue) ? LeaveRuleApplicableDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.DeletedBy.HasValue) ? LeaveRuleApplicableDetailsDTO.DeletedBy : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.DeletedDate = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.CentreName = value;
            }
        }
        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.CentreCode = value;
            }
        }
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
        public string errorMessage { get; set; }
        public string EntityLevel { get; set; }

       
        public string IDs
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.IDs : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.IDs = value;
            }
        }
        public string LeaveSessionFromDate
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.LeaveSessionFromDate : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveSessionFromDate = value;
            }
        }
        public string LeaveSessionUptoDate
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.LeaveSessionUptoDate : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveSessionUptoDate = value;
            }
        }

        public List<LeaveSession> ListLeaveSession
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListLeaveSessionItems
        {
            get
            {

                return new SelectList(ListLeaveSession, "LeaveSessionID", "LeaveSessionName");
            }

        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }
        public string SelectedSessionID
        {
            get;
            set;
        }
        public string LeaveCode
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.LeaveCode : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveCode = value;
            }
        }
        public string LeaveDescription
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.LeaveDescription : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveDescription = value;
            }
        }

        //////////////////////////////-----------------Leave Rule MAster Details --------------------------//////////////////////////////

        [Display(Name = "DisplayName_LeaveRuleDescription", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveRuleDescriptionRequired")]
        public string LeaveRuleDescription
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.LeaveRuleDescription : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.LeaveRuleDescription = value;
            }
        }

        [Display(Name = "DisplayName_NumberOfLeaves", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NumberOfLeavesRequired")]
        public Int16 NumberOfLeaves
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.NumberOfLeaves > 0) ? LeaveRuleApplicableDetailsDTO.NumberOfLeaves : new Int16();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.NumberOfLeaves = value;
            }
        }

        [Display(Name = "DisplayName_MaxLeaveAtTime", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveAtTimeRequired")]
        public Int16 MaxLeaveAtTime
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.MaxLeaveAtTime > 0) ? LeaveRuleApplicableDetailsDTO.MaxLeaveAtTime : new Int16();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.MaxLeaveAtTime = value;
            }
        }

        [Display(Name = "DisplayName_MinimumLeaveEncash", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MinimumLeaveEncashRequired")]
        public int MinimumLeaveEncash
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.MinimumLeaveEncash > 0) ? LeaveRuleApplicableDetailsDTO.MinimumLeaveEncash : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.MinimumLeaveEncash = value;
            }
        }

        [Display(Name = "DisplayName_MaxLeaveEncash", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveEncashRequired")]
        public int MaxLeaveEncash
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.MaxLeaveEncash > 0) ? LeaveRuleApplicableDetailsDTO.MaxLeaveEncash : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.MaxLeaveEncash = value;
            }
        }

        [Display(Name = "DisplayName_MaxLeaveAccumulated", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxLeaveAccumlatedRequired")]
        public int MaxLeaveAccumulated
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.MaxLeaveAccumulated > 0) ? LeaveRuleApplicableDetailsDTO.MaxLeaveAccumulated : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.MaxLeaveAccumulated = value;
            }
        }

        [Display(Name = "DisplayName_MinServiceRequiredInMonth", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MinServiceRequiredInMonthRequired")]
        public int MinServiceRequiredInMonth
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.MinServiceRequiredInMonth > 0) ? LeaveRuleApplicableDetailsDTO.MinServiceRequiredInMonth : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.MinServiceRequiredInMonth = value;
            }
        }

        [Display(Name = "DisplayName_AttendDaysRequiredInMonth", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AttendDaysRequiredRequired")]
        public int AttendDaysRequired
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.AttendDaysRequired > 0) ? LeaveRuleApplicableDetailsDTO.AttendDaysRequired : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.AttendDaysRequired = value;
            }
        }
        // [Display(Name = "DisplayName_CreditDependOn", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CreditDependOnRequired")]
        public string CreditDependOn
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.CreditDependOn : string.Empty;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.CreditDependOn = value;
            }
        }

        [Display(Name = "DisplayName_DayOfTheMonth", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DayOfTheMonthRequired")]
        public int DayOfTheMonth
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null && LeaveRuleApplicableDetailsDTO.DayOfTheMonth > 0) ? LeaveRuleApplicableDetailsDTO.DayOfTheMonth : new int();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.DayOfTheMonth = value;
            }
        }

        [Display(Name = "DisplayName_IsLocked", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsLocked
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.IsLocked : false;
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.IsLocked = value;
            }
        }

        [Display(Name = "DisplayName_MinLeavesAtTime", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MinLeavesAtTimeRequired")]
        public double MinLeavesAtTime
        {
            get
            {
                return (LeaveRuleApplicableDetailsDTO != null) ? LeaveRuleApplicableDetailsDTO.MinLeavesAtTime : new double();
            }
            set
            {
                LeaveRuleApplicableDetailsDTO.MinLeavesAtTime = value;
            }
        }
    }
}
