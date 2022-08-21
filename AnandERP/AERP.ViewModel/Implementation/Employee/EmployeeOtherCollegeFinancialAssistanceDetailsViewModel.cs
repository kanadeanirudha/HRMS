using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeOtherCollegeFinancialAssistanceDetailsViewModel : IEmployeeOtherCollegeFinancialAssistanceDetailsViewModel
    {

        public EmployeeOtherCollegeFinancialAssistanceDetailsViewModel()
        {
            EmployeeOtherCollegeFinancialAssistanceDetailsDTO = new EmployeeOtherCollegeFinancialAssistanceDetails();
        }

        public EmployeeOtherCollegeFinancialAssistanceDetails EmployeeOtherCollegeFinancialAssistanceDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null && EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ID > 0) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_FundingAgency", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FundingAgencyRequired")]
        public string FundingAgency
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.FundingAgency : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.FundingAgency = value;
            }
        }

        [Display(Name = "DisplayName_DateOfGrantReceived", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DateOfGrantReceivedRequired")]
        public string DateOfGrantReceived
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DateOfGrantReceived : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DateOfGrantReceived = value;
            }
        }

        [Display(Name = "DisplayName_AmountOfGrant", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AmountOfGrantRequired")]
        public decimal AmountOfGrant
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.AmountOfGrant : new decimal();
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.AmountOfGrant = value;
            }
        }

        [Display(Name = "DisplayName_PurposeOfGrant", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PurposeOfGrantRequired")]
        public string PurposeOfGrant
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.PurposeOfGrant : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.PurposeOfGrant = value;
            }
        }

        [Display(Name = "DisplayName_Remarks", ResourceType = typeof(AMS.Common.Resources))]
   
        public string Remarks
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.Remarks = value;
            }
        }
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null && EmployeeOtherCollegeFinancialAssistanceDetailsDTO.CreatedBy > 0) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null && EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ModifiedBy.HasValue) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null && EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ModifiedDate.HasValue) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null && EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DeletedBy.HasValue) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null && EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DeletedDate.HasValue) ? EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

