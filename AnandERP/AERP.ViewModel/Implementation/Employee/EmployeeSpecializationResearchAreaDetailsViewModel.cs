using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeSpecializationResearchAreaDetailsViewModel
    {

        public EmployeeSpecializationResearchAreaDetailsViewModel()
        {
            EmployeeSpecializationResearchAreaDetailsDTO = new EmployeeSpecializationResearchAreaDetails();
        }

        public EmployeeSpecializationResearchAreaDetails EmployeeSpecializationResearchAreaDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null && EmployeeSpecializationResearchAreaDetailsDTO.ID > 0) ? EmployeeSpecializationResearchAreaDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null && EmployeeSpecializationResearchAreaDetailsDTO.EmployeeID > 0) ? EmployeeSpecializationResearchAreaDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.EmployeeID = value;
            }
        }


        [Display(Name = "DisplayName_SpecializationField", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_SpecializationFieldRequired")]
        public string SpecializationField
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null) ? EmployeeSpecializationResearchAreaDetailsDTO.SpecializationField : string.Empty;
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.SpecializationField = value;
            }
        }

        [Display(Name = "DisplayName_ResearchArea", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ResearchAreaRequired")]
        public string ResearchArea
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null) ? EmployeeSpecializationResearchAreaDetailsDTO.ResearchArea : string.Empty;
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.ResearchArea = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null) ? EmployeeSpecializationResearchAreaDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null) ? EmployeeSpecializationResearchAreaDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null && EmployeeSpecializationResearchAreaDetailsDTO.CreatedBy > 0) ? EmployeeSpecializationResearchAreaDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null) ? EmployeeSpecializationResearchAreaDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null && EmployeeSpecializationResearchAreaDetailsDTO.ModifiedBy.HasValue) ? EmployeeSpecializationResearchAreaDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null && EmployeeSpecializationResearchAreaDetailsDTO.ModifiedDate.HasValue) ? EmployeeSpecializationResearchAreaDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null && EmployeeSpecializationResearchAreaDetailsDTO.DeletedBy.HasValue) ? EmployeeSpecializationResearchAreaDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeSpecializationResearchAreaDetailsDTO != null && EmployeeSpecializationResearchAreaDetailsDTO.DeletedDate.HasValue) ? EmployeeSpecializationResearchAreaDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeSpecializationResearchAreaDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}
