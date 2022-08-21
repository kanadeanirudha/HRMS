using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralPolicyRulesViewModel : IGeneralPolicyRulesViewModel
    {

        public GeneralPolicyRulesViewModel()
        {
           GeneralPolicyRulesDTO = new GeneralPolicyRules();
           
        }
        public GeneralPolicyRules GeneralPolicyRulesDTO
        {
            get;
            set;
        }
       

        public int ID
        {
            get
            {
                return (GeneralPolicyRulesDTO != null && GeneralPolicyRulesDTO.ID > 0) ? GeneralPolicyRulesDTO.ID : new int();
            }
            set
            {
               GeneralPolicyRulesDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_PolicyCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyCodeRequired")]
       // [Required(ErrorMessage = "policy Code should not be blank.")]
      //  [Display(Name = "Code:")]
        public string PolicyCode		
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.PolicyCode : string.Empty;
            }
            set
            {
               GeneralPolicyRulesDTO.PolicyCode = value;
            }
        }
        [Display(Name = "Policy Name")]
        public string PolicyName
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.PolicyName : string.Empty;
            }
            set
            {
                GeneralPolicyRulesDTO.PolicyName = value;
            }
        }
        //[Display(Name = "DisplayName_PolicyName", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyNameRequired")]
        [Required(ErrorMessage = "Policy Question Description should not be blank.")]
        [Display(Name = "Policy Question Description")]
        public string PolicyQuestionDescription			
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.PolicyQuestionDescription : string.Empty;
            }
            set
            {
                GeneralPolicyRulesDTO.PolicyQuestionDescription = value;
            }
        }
       // [Display(Name = "DisplayName_PolicyDescription", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyDescriptionRequired")]
        [Required(ErrorMessage = "Policy range should not be blank.")]
        [Display(Name = "Policy Range:")]
        public string PolicyRange			
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.PolicyRange : string.Empty;
            }
            set
            {
                GeneralPolicyRulesDTO.PolicyRange = value;
            }
        }
       // [Display(Name = "DisplayName_PolicyRelatedToModuleCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyRelatedToModuleCodeRequired")]
        [Required(ErrorMessage = "Policy Default Answer should not be blank.")]
        [Display(Name = "Policy Default Answer:")]
        public string PolicyDefaultAnswer			
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.PolicyDefaultAnswer : string.Empty;
            }
            set
            {
                GeneralPolicyRulesDTO.PolicyDefaultAnswer = value;
            }
        }
       // [Display(Name = "DisplayName_PolicyApplicableStatus", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyApplicableStatusRequired")]
        [Required(ErrorMessage = "Policy Ans Type should not be blank.")]
        [Display(Name = "Policy Ans Type:")]
        public string PolicyAnsType		
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.PolicyAnsType : string.Empty;
            }
            set
            {
                GeneralPolicyRulesDTO.PolicyAnsType = value;
            }
        }
        [Required(ErrorMessage = "Range Separate By should not be blank.")]
        [Display(Name = "Range Separate By")]
        public string RangeSeparateBy	
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.RangeSeparateBy : string.Empty;
            }
            set
            {
                GeneralPolicyRulesDTO.RangeSeparateBy = value;
            }
        }
        public int PolicyMasterID
        {
            get
            {
                return (GeneralPolicyRulesDTO != null && GeneralPolicyRulesDTO.PolicyMasterID > 0) ? GeneralPolicyRulesDTO.PolicyMasterID : new int();
            }
            set
            {
                GeneralPolicyRulesDTO.PolicyMasterID = value;
            }
        }
        //public string PolicyMasterCode
        //{
        //    get
        //    {
        //        return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.PolicyMasterCode : string.Empty;
        //    }
        //    set
        //    {
        //        GeneralPolicyRulesDTO.PolicyMasterCode = value;
        //    }
        //}
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.IsDeleted : false;
            }
            set
            {
                GeneralPolicyRulesDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPolicyRulesDTO != null && GeneralPolicyRulesDTO.CreatedBy > 0) ? GeneralPolicyRulesDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPolicyRulesDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyRulesDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPolicyRulesDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyRulesDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPolicyRulesDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralPolicyRulesDTO != null) ? GeneralPolicyRulesDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyRulesDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
       
        
    }
}

