using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;


namespace AMS.ViewModel
{
    public class OrganisationSectionMasterViewModel : IOrganisationSectionMasterViewModel
    {
        public OrganisationSectionMasterViewModel()
        {
            OrganisationSectionMasterDTO = new OrganisationSectionMaster();
        }

        public OrganisationSectionMaster OrganisationSectionMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationSectionMasterDTO != null && OrganisationSectionMasterDTO.ID > 0) ? OrganisationSectionMasterDTO.ID : new int();
            }
            set
            {
                OrganisationSectionMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_SectionName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SectionNameRequired")]
        public string SectionName
        {
            get
            {
                return (OrganisationSectionMasterDTO != null) ? OrganisationSectionMasterDTO.SectionName : string.Empty;
            }
            set
            {
                OrganisationSectionMasterDTO.SectionName = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (OrganisationSectionMasterDTO != null) ? OrganisationSectionMasterDTO.IsUserDefined : false;
            }
            set
            {
                OrganisationSectionMasterDTO.IsUserDefined= value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSectionMasterDTO != null) ? OrganisationSectionMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationSectionMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSectionMasterDTO != null && OrganisationSectionMasterDTO.CreatedBy > 0) ? OrganisationSectionMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSectionMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSectionMasterDTO != null) ? OrganisationSectionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSectionMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSectionMasterDTO != null && OrganisationSectionMasterDTO.ModifiedBy.HasValue) ? OrganisationSectionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSectionMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSectionMasterDTO != null && OrganisationSectionMasterDTO.ModifiedDate.HasValue) ? OrganisationSectionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSectionMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSectionMasterDTO != null && OrganisationSectionMasterDTO.DeletedBy.HasValue) ? OrganisationSectionMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSectionMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSectionMasterDTO != null && OrganisationSectionMasterDTO.DeletedDate.HasValue) ? OrganisationSectionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSectionMasterDTO.DeletedDate = value;
            }
        }

    }
}