using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeePrizesWonDetailsViewModel : IEmployeePrizesWonDetailsViewModel
    {

        public EmployeePrizesWonDetailsViewModel()
        {
            EmployeePrizesWonDetailsDTO = new EmployeePrizesWonDetails();
        }

        public EmployeePrizesWonDetails EmployeePrizesWonDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null && EmployeePrizesWonDetailsDTO.ID > 0) ? EmployeePrizesWonDetailsDTO.ID : new int();
            }
            set
            {
                EmployeePrizesWonDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeePrizesWonDetailsDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_GeneralLevelMasterID", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_GeneralLevelMasterIDRequired")]
        public int GeneralLevelMasterID
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.GeneralLevelMasterID : new int();
            }
            set
            {
                EmployeePrizesWonDetailsDTO.GeneralLevelMasterID = value;
            }
        }
        public string GeneralLevelName
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.GeneralLevelName : string.Empty;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.GeneralLevelName = value;
            }
        }
        [Display(Name = "DisplayName_PrizeName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PrizeNameRequired")]
        public string PrizeName
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.PrizeName : string.Empty;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.PrizeName = value;
            }
        }
        [Display(Name = "DisplayName_PrizeGivenBy", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PrizeGivenByRequired")]
        public string PrizeGivenBy
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.PrizeGivenBy : string.Empty;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.PrizeGivenBy = value;
            }
        }
        [Display(Name = "DisplayName_PrizeReceivingDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PrizeReceivingDateRequired")]
        public string PrizeReceivingDate
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.PrizeReceivingDate : string.Empty;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.PrizeReceivingDate = value;
            }
        }

        [Display(Name = "DisplayName_PrizeIssuingAuthority", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PrizeIssuingAuthorityRequired")]
        public string PrizeIssuingAuthority
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.PrizeIssuingAuthority : string.Empty;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.PrizeIssuingAuthority = value;
            }
        }


        [Display(Name = "DisplayName_Remarks", ResourceType = typeof(Resources))]
        public string Remark
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.Remark : string.Empty;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.Remark = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null && EmployeePrizesWonDetailsDTO.CreatedBy > 0) ? EmployeePrizesWonDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeePrizesWonDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null) ? EmployeePrizesWonDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null && EmployeePrizesWonDetailsDTO.ModifiedBy.HasValue) ? EmployeePrizesWonDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeePrizesWonDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null && EmployeePrizesWonDetailsDTO.ModifiedDate.HasValue) ? EmployeePrizesWonDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null && EmployeePrizesWonDetailsDTO.DeletedBy.HasValue) ? EmployeePrizesWonDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeePrizesWonDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePrizesWonDetailsDTO != null && EmployeePrizesWonDetailsDTO.DeletedDate.HasValue) ? EmployeePrizesWonDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePrizesWonDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

