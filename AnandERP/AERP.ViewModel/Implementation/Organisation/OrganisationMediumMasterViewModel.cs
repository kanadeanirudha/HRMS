using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class OrganisationMediumMasterViewModel : IOrganisationMediumMasterViewModel
    {
        public OrganisationMediumMasterViewModel()
        {
            OrganisationMediumMasterDTO = new OrganisationMediumMaster();
        }

        public OrganisationMediumMaster OrganisationMediumMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationMediumMasterDTO != null && OrganisationMediumMasterDTO.ID > 0) ? OrganisationMediumMasterDTO.ID : new int();
            }
            set
            {
                OrganisationMediumMasterDTO.ID = value;
            }
        }


        [Display(Name = "DisplayName_MediumDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MediumDescriptionRequired")]
        public string Description
        {
            get
            {
                return (OrganisationMediumMasterDTO != null) ? OrganisationMediumMasterDTO.Description : string.Empty;
            }
            set
            {
                OrganisationMediumMasterDTO.Description = value;
            }
        }

        [Display(Name = "DisplayName_MediumCodeShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MediumCodeShortCodeRequired")]
        public string CodeShortCode
        {
            get
            {
                return (OrganisationMediumMasterDTO != null) ? OrganisationMediumMasterDTO.CodeShortCode : string.Empty;
            }
            set
            {
                OrganisationMediumMasterDTO.CodeShortCode = value;
            }
        }

        [Display(Name = "DisplayName_PrintShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PrintShortCodeRequired")]
        public string PrintShortCode
        {
            get
            {
                return (OrganisationMediumMasterDTO != null) ? OrganisationMediumMasterDTO.PrintShortCode : string.Empty;
            }
            set
            {
                OrganisationMediumMasterDTO.PrintShortCode = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (OrganisationMediumMasterDTO != null) ? OrganisationMediumMasterDTO.IsUserDefined : false;
            }
            set
            {
                OrganisationMediumMasterDTO.IsUserDefined = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationMediumMasterDTO != null) ? OrganisationMediumMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationMediumMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationMediumMasterDTO != null && OrganisationMediumMasterDTO.CreatedBy > 0) ? OrganisationMediumMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationMediumMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationMediumMasterDTO != null) ? OrganisationMediumMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationMediumMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationMediumMasterDTO != null && OrganisationMediumMasterDTO.ModifiedBy.HasValue) ? OrganisationMediumMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationMediumMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationMediumMasterDTO != null && OrganisationMediumMasterDTO.ModifiedDate.HasValue) ? OrganisationMediumMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationMediumMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationMediumMasterDTO != null && OrganisationMediumMasterDTO.DeletedBy.HasValue) ? OrganisationMediumMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationMediumMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationMediumMasterDTO != null && OrganisationMediumMasterDTO.DeletedDate.HasValue) ? OrganisationMediumMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationMediumMasterDTO.DeletedDate = value;
            }
        }

    }
}
