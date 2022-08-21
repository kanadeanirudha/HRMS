using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralPolicyMasterViewModel : IGeneralPolicyMasterViewModel
    {

        public GeneralPolicyMasterViewModel()
        {
           GeneralPolicyMasterDTO = new GeneralPolicyMaster();
           PolicyRelatedToModuleCodeList = new List<UserModuleMaster>();
        }
        public List<UserModuleMaster> PolicyRelatedToModuleCodeList { get; set; }
        public GeneralPolicyMaster GeneralPolicyMasterDTO
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> PolicyRelatedToModuleCodeListItems
        {
            get
            {
                return new SelectList(PolicyRelatedToModuleCodeList, "ModuleName", "ModuleCode");
            }
        }

        public int ID
        {
            get
            {
                return (GeneralPolicyMasterDTO != null && GeneralPolicyMasterDTO.ID > 0) ? GeneralPolicyMasterDTO.ID : new int();
            }
            set
            {
               GeneralPolicyMasterDTO.ID = value;
            }
        }
        //[Display(Name = "DisplayName_PolicyCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyCodeRequired")]
       [Required(ErrorMessage = "Policy Code should not be blank.")]
        [Display(Name = "Policy Code:")]
        public string PolicyCode		
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.PolicyCode : string.Empty;
            }
            set
            {
               GeneralPolicyMasterDTO.PolicyCode = value;
            }
        }

        //[Display(Name = "DisplayName_PolicyName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyNameRequired")]
       [Required(ErrorMessage = "Policy Name should not be blank.")]
       [Display(Name = "Policy Name:")]
        public string PolicyName		
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.PolicyName : string.Empty;
            }
            set
            {
                GeneralPolicyMasterDTO.PolicyName = value;
            }
        }
        //[Display(Name = "DisplayName_PolicyDescription", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyDescriptionRequired")]
       [Required(ErrorMessage = "Policy Description should not be blank.")]
       [Display(Name = "Policy Description:")]
        public string PolicyDescription		
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.PolicyDescription : string.Empty;
            }
            set
            {
                GeneralPolicyMasterDTO.PolicyDescription = value;
            }
        }
        //[Display(Name = "DisplayName_PolicyRelatedToModuleCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyRelatedToModuleCodeRequired")]
       [Required(ErrorMessage = "Related Code should not be blank.")]
       [Display(Name = "Related Code:")]
        public string PolicyRelatedToModuleCode		
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.PolicyRelatedToModuleCode : string.Empty;
            }
            set
            {
                GeneralPolicyMasterDTO.PolicyRelatedToModuleCode = value;
            }
        }
        [Display(Name = "DisplayName_PolicyApplicableStatus", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyApplicableStatusRequired")]
        //[Required(ErrorMessage = "Policy Applicable Status should not be blank.")]
        //[Display(Name = "Applicable Status:")]
        public string PolicyApplicableStatus	
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.PolicyApplicableStatus : string.Empty;
            }
            set
            {
                GeneralPolicyMasterDTO.PolicyApplicableStatus = value;
            }
        }
        [Display(Name = "DisplayName_IsPolicyActive", ResourceType = typeof(AMS.Common.Resources))]
        //[Display(Name = "Is Active:")]
        public bool IsPolicyActive
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.IsPolicyActive : false;
            }
            set
            {
                GeneralPolicyMasterDTO.IsPolicyActive = value;
            }
        }
        //Feilds From Table GeneralPolicyRules

        [Required(ErrorMessage = "Policy range should not be blank.")]
        [Display(Name = "Policy Range:")]
        public string PolicyRange
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.PolicyRange : string.Empty;
            }
            set
            {
                GeneralPolicyMasterDTO.PolicyRange = value;
            }
        }
        
        [Required(ErrorMessage = "Default Answer should not be blank.")]
        [Display(Name = "Default Answer:")]
        public string PolicyDefaultAnswer
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.PolicyDefaultAnswer : string.Empty;
            }
            set
            {
                GeneralPolicyMasterDTO.PolicyDefaultAnswer = value;
            }
        }
        
        [Required(ErrorMessage = "Policy Ans Type should not be blank.")]
        [Display(Name = "Policy Ans Type:")]
        public string PolicyAnsType
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.PolicyAnsType : string.Empty;
            }
            set
            {
                GeneralPolicyMasterDTO.PolicyAnsType = value;
            }
        }
        [Required(ErrorMessage = "Range Separate By should not be blank.")]
        [Display(Name = "Range Separate By")]
        public string RangeSeparateBy
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.RangeSeparateBy : string.Empty;
            }
            set
            {
                GeneralPolicyMasterDTO.RangeSeparateBy = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralPolicyMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPolicyMasterDTO != null && GeneralPolicyMasterDTO.CreatedBy > 0) ? GeneralPolicyMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPolicyMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPolicyMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPolicyMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralPolicyMasterDTO != null) ? GeneralPolicyMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
       
        
    }
}

