using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeavePostViewModel : ILeavePostViewModel
    {
        public LeavePostViewModel()
        {
            LeavePostDTO = new LeavePost();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListFromLeaveSession = new List<LeaveSession>();
            ListToLeaveSession = new List<LeaveSession>();
        }

        public LeavePost LeavePostDTO
        {
            get;
            set;
        }

        public int LeaveMasterID
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.LeaveMasterID > 0) ? LeavePostDTO.LeaveMasterID : new int();
            }
            set
            {
                LeavePostDTO.LeaveMasterID = value;
            }
        }
        [Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string LeaveCode
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.LeaveCode : string.Empty;
            }
            set
            {
                LeavePostDTO.LeaveCode = value;
            }
        }
        [Display(Name = "DisplayName_LeaveDescription", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveDescriptionRequired")]
        public string LeaveDescription
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.LeaveDescription : string.Empty;
            }
            set
            {
                LeavePostDTO.LeaveDescription = value;
            }
        }

        public int LeaveRuleMasterID
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.LeaveRuleMasterID > 0) ? LeavePostDTO.LeaveRuleMasterID : new int();
            }
            set
            {
                LeavePostDTO.LeaveRuleMasterID = value;
            }
        }
        public int LeaveSessionID
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.LeaveSessionID > 0) ? LeavePostDTO.LeaveSessionID : new int();
            }
            set
            {
                LeavePostDTO.LeaveSessionID = value;
            }
        }
        public int DOJAndCurrentSessionDifferenceInMonth
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.DOJAndCurrentSessionDifferenceInMonth > 0) ? LeavePostDTO.DOJAndCurrentSessionDifferenceInMonth : new int();
            }
            set
            {
                LeavePostDTO.DOJAndCurrentSessionDifferenceInMonth = value;
            }
        }
        [Display(Name = "DisplayName_LeaveRuleDescription", ResourceType = typeof(AERP.Common.Resources))]
      //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveRuleDescriptionRequired")]
        public string LeaveRuleDescription
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.LeaveRuleDescription : string.Empty;
            }
            set
            {
                LeavePostDTO.LeaveRuleDescription = value;
            }
        }
        [Display(Name = "DisplayName_LeaveType", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveTypeRequired")]
        public string LeaveType
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.LeaveType : string.Empty;
            }
            set
            {
                LeavePostDTO.LeaveType = value;
            }
        }
        // [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.IsActive : false;
            }
            set
            {
                LeavePostDTO.IsActive = value;
            }
        }
        // [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.IsDeleted : false;
            }
            set
            {
                LeavePostDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.CreatedBy > 0) ? LeavePostDTO.CreatedBy : new int();
            }
            set
            {
                LeavePostDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeavePostDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.ModifiedBy.HasValue) ? LeavePostDTO.ModifiedBy : new int();
            }
            set
            {
                LeavePostDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.ModifiedDate.HasValue) ? LeavePostDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeavePostDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.DeletedBy.HasValue) ? LeavePostDTO.DeletedBy : new int();
            }
            set
            {
                LeavePostDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.DeletedDate.HasValue) ? LeavePostDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeavePostDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.CentreCode : string.Empty;
            }
            set
            {
                LeavePostDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.CentreName : string.Empty;
            }
            set
            {
                LeavePostDTO.CentreName = value;
            }
        }

        public int SelectedFromSessionID
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.SelectedFromSessionID > 0) ? LeavePostDTO.SelectedFromSessionID : new int();
            }
            set
            {
                LeavePostDTO.SelectedFromSessionID = value;
            }
        }
        public int SelectedToSessionID
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.SelectedToSessionID > 0) ? LeavePostDTO.SelectedToSessionID : new int();
            }
            set
            {
                LeavePostDTO.SelectedToSessionID = value;
            }
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<LeaveSession> ListFromLeaveSession
        {
            get;
            set;
        }
        public List<LeaveSession> ListToLeaveSession
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
        public IEnumerable<SelectListItem> ListFromLeaveSessionItems
        {
            get
            {

                return new SelectList(ListFromLeaveSession, "LeaveSessionID", "LeaveSessionName");
            }

        }
        public IEnumerable<SelectListItem> ListToLeaveSessionItems
        {
            get
            {

                return new SelectList(ListToLeaveSession, "LeaveSessionID", "LeaveSessionName");
            }

        }
             

        public string EntityLevel { get; set; }

        public int EmployeeID
        {
            get
            {
                return (LeavePostDTO != null && LeavePostDTO.EmployeeID > 0) ? LeavePostDTO.EmployeeID : new int();
            }
            set
            {
                LeavePostDTO.EmployeeID = value;
            }
        }
        [Display(Name = "DisplayName_EmployeeFirstName", ResourceType = typeof(AERP.Common.Resources))]
     //   [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeFirstNameRequired")]
        public string EmployeeFirstName
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.EmployeeFirstName : string.Empty;
            }
            set
            {
                LeavePostDTO.EmployeeFirstName = value;
            }
        }

        [Display(Name = "DisplayName_LeaveSessionName", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveSessionNameRequired")]
        public string LeaveSessionName
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.LeaveSessionName : string.Empty;
            }
            set
            {
                LeavePostDTO.LeaveSessionName = value;
            }
        }       
        [Display(Name = "DisplayName_EmployeeMiddleName", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeMiddleNameRequired")]
        public string EmployeeMiddleName
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.EmployeeMiddleName : string.Empty;
            }
            set
            {
                LeavePostDTO.EmployeeMiddleName = value;
            }
        }
        [Display(Name = "DisplayName_EmployeeLastName", ResourceType = typeof(AERP.Common.Resources))]
     //   [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeLastNameRequired")]
        public string EmployeeLastName
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.EmployeeLastName : string.Empty;
            }
            set
            {
                LeavePostDTO.EmployeeLastName = value;
            }
        }
       
        public string LeaveList
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.LeaveList : string.Empty;
            }
            set
            {
                LeavePostDTO.LeaveList = value;
            }
        }

        public string SelectedIDs
        {
            get
            {
                return (LeavePostDTO != null) ? LeavePostDTO.SelectedIDs : string.Empty;
            }
            set
            {
                LeavePostDTO.SelectedIDs = value;
            }
        }
               
    }
}
