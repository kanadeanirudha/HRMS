using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveLateMarkRulesDetailsViewModel : ILeaveLateMarkRulesDetailsViewModel
    {
        public LeaveLateMarkRulesDetailsViewModel()
        {
            LeaveLateMarkRulesDetailsDTO = new LeaveLateMarkRulesDetails();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public LeaveLateMarkRulesDetails LeaveLateMarkRulesDetailsDTO
        {
            get;
            set;
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
        public int ID
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null && LeaveLateMarkRulesDetailsDTO.ID > 0) ? LeaveLateMarkRulesDetailsDTO.ID : new int();
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_LateMarkCount", ResourceType = typeof(AERP.Common.Resources))]
        //[Display(Name = "Late Mark Count")]
        public Int16 LateMarkCount
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null && LeaveLateMarkRulesDetailsDTO.LateMarkCount > 0) ? LeaveLateMarkRulesDetailsDTO.LateMarkCount : new Int16();
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.LateMarkCount = value;
            }
        }

        [Display(Name = "DisplayName_NumberLeaveDeducted", ResourceType = typeof(AERP.Common.Resources))]
        //[Display(Name = "Deduction of Leave")]
        public decimal NumberLeaveDeducted
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null && LeaveLateMarkRulesDetailsDTO.NumberLeaveDeducted > 0) ? LeaveLateMarkRulesDetailsDTO.NumberLeaveDeducted : new decimal();
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.NumberLeaveDeducted = value;
            }
        }
        //  [Required(ErrorMessage = "Late Mark Rule Name should not be blank")]
        //[Display(Name = "Late Mark Rule Name")]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveLateMarkRuleNameRequired")]
        [Display(Name = "DisplayName_LeaveLateMarkRuleName", ResourceType = typeof(AERP.Common.Resources))]
        public string LateMarkRuleName
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.LateMarkRuleName : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.LateMarkRuleName = value;
            }
        }
        public string LeaveDetails
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.LeaveDetails : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.LeaveDetails = value;
            }
        }


        // [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.CentreCode = value;
            }
        }
        public string EntityLevel
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.EntityLevel : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.EntityLevel = value;
            }
        }
        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.CentreName = value;
            }
        }

       
        //[Display(Name = "Leave Deduction Priority")]
        //[Required(ErrorMessage = "Please Select Leave Deduction Priority")]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveDeductionPriorityRequired")]
        [Display(Name = "DisplayName_LeaveDeductionPriority", ResourceType = typeof(AERP.Common.Resources))]
        public int LeaveID1
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.LeaveID1 : new Int16();
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.LeaveID1 = value;
            }
        }
        public string LeaveID2
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.LeaveID2 : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.LeaveID2 = value;
            }
        }
        public string LeaveID3
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.LeaveID3 : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.LeaveID3 = value;
            }
        }
        public string LeaveID4
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.LeaveID4 : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.LeaveID4 = value;
            }
        }
        public string LeaveID5
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.LeaveID5 : string.Empty;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.LeaveID5 = value;
            }
        }



        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.IsActive : false;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.IsActive = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.IsDeleted : false;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.IsDeleted = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null && LeaveLateMarkRulesDetailsDTO.CreatedBy > 0) ? LeaveLateMarkRulesDetailsDTO.CreatedBy : new int();
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null && LeaveLateMarkRulesDetailsDTO.ModifiedBy.HasValue) ? LeaveLateMarkRulesDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null && LeaveLateMarkRulesDetailsDTO.DeletedBy.HasValue) ? LeaveLateMarkRulesDetailsDTO.DeletedBy : new int();
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (LeaveLateMarkRulesDetailsDTO != null) ? LeaveLateMarkRulesDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveLateMarkRulesDetailsDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }



    }
}
