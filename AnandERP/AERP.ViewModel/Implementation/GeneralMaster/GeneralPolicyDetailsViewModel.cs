using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralPolicyDetailsViewModel : IGeneralPolicyDetailsViewModel
    {

        public GeneralPolicyDetailsViewModel()
        {
           GeneralPolicyDetailsDTO = new GeneralPolicyDetails();
           ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();   
        }
        
        public GeneralPolicyDetails GeneralPolicyDetailsDTO
        {
            get;
            set;
        }
      
        public int ID
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null && GeneralPolicyDetailsDTO.ID > 0) ? GeneralPolicyDetailsDTO.ID : new int();
            }
            set
            {
               GeneralPolicyDetailsDTO.ID = value;
            }
        }
        //[Display(Name = "DisplayName_PolicyCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyCodeRequired")]
        [Required(ErrorMessage = "policy Code should not be blank.")]
        [Display(Name = "Policy Code:")]
        public string PolicyCode		
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.PolicyCode : string.Empty;
            }
            set
            {
               GeneralPolicyDetailsDTO.PolicyCode = value;
            }
        }

        //[Display(Name = "DisplayName_PolicyName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PolicyNameRequired")]
        [Required(ErrorMessage = "Policy Name should not be blank.")]
        [Display(Name = "Name:")]
        public string PolicyName		
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.PolicyName : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.PolicyName = value;
            }
        }

        [Required(ErrorMessage = "Policy Rule ID should not be blank.")]
        [Display(Name = "Policy Rule ID:")]
        public int GeneralPolicyRulesID
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null && GeneralPolicyDetailsDTO.GeneralPolicyRulesID > 0) ? GeneralPolicyDetailsDTO.GeneralPolicyRulesID: new int();
            }
            set
            {
                GeneralPolicyDetailsDTO.GeneralPolicyRulesID = value;
            }
        }
        [Required(ErrorMessage = "Centre Code should not be blank.")]
        [Display(Name = "Centre Code:")]
        public string CentreCode
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.CentreCode = value;
            }
        }

        public string CentreName
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.CentreName : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.CentreName = value;
            }
        }


        [Required(ErrorMessage = "Policy Answered should not be blank.")]
        [Display(Name = "Policy Answered:")]
        public string PolicyAnswered
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.PolicyAnswered : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.PolicyAnswered = value;
            }
        }
         public string PolicyQuestionDescription
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.PolicyQuestionDescription : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.PolicyQuestionDescription = value;
            }
         }
         public string PolicyDefaultAnswer
         {
             get
             {
                 return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.PolicyDefaultAnswer : string.Empty;
             }
             set
             {
                 GeneralPolicyDetailsDTO.PolicyDefaultAnswer = value;
             }
         }
        [Required(ErrorMessage = "Applicable From Date should not be blank.")]
        [Display(Name = "Applicable From Date:")]
        public string ApplicableFromDate
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.ApplicableFromDate : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.ApplicableFromDate = value;
            }
        }
        //[Required(ErrorMessage = "Applicable Upto Date should not be blank.")]
        [Display(Name = "Applicable Upto Date:")]
        public string ApplicableUptoDate
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.ApplicableUptoDate : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.ApplicableUptoDate = value;
            }
        }
        [Display(Name = "Applicable Upto Date:")]
        public string ApplicableUptoDate_Update
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.ApplicableUptoDate_Update : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.ApplicableUptoDate_Update = value;
            }
        }
        public string ApplicableFromDate1
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.ApplicableFromDate1 : string.Empty;
            }
            set
            {
                GeneralPolicyDetailsDTO.ApplicableFromDate1 = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.IsDeleted : false;
            }
            set
            {
                GeneralPolicyDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null && GeneralPolicyDetailsDTO.CreatedBy > 0) ? GeneralPolicyDetailsDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPolicyDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPolicyDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPolicyDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralPolicyDetailsDTO != null) ? GeneralPolicyDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPolicyDetailsDTO.DeletedDate = value;
            }
        }
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
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
       
        
    }
}

