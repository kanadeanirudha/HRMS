using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class OrganisationStandardMasterViewModel : IOrganisationStandardMasterViewModel
    {
        public OrganisationStandardMasterViewModel()
        {
            OrganisationStandardMasterDTO = new OrganisationStandardMaster();
        }

        public OrganisationStandardMaster OrganisationStandardMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationStandardMasterDTO != null && OrganisationStandardMasterDTO.ID > 0) ? OrganisationStandardMasterDTO.ID : new int();
            }
            set
            {
                OrganisationStandardMasterDTO.ID = value;
            }
        }


        [Display(Name = "DisplayName_StandardNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StandardNumberRequired")]
        public int StandardNumber
        {
            get
            {
                return (OrganisationStandardMasterDTO != null && OrganisationStandardMasterDTO.StandardNumber > 0) ? OrganisationStandardMasterDTO.StandardNumber : new int();
            }
            set
            {
                OrganisationStandardMasterDTO.StandardNumber = value;
            }
        }

        [Display(Name = "DisplayName_StandardDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StandardDescriptionRequired")]
        public string Description
        {
            get
            {
                return (OrganisationStandardMasterDTO != null) ? OrganisationStandardMasterDTO.Description : string.Empty;
            }
            set
            {
                OrganisationStandardMasterDTO.Description = value;
            }
        }

        [Display(Name = "DisplayName_StandardCodeShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StandardCodeShortCodeRequired")]
        public string CodeShortCode
        {
            get
            {
                return (OrganisationStandardMasterDTO != null) ? OrganisationStandardMasterDTO.CodeShortCode : string.Empty;
            }
            set
            {
                OrganisationStandardMasterDTO.CodeShortCode = value;
            }
        }

        [Display(Name = "DisplayName_PrintShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PrintShortCodeRequired")]
        public string PrintShortCode
        {
            get
            {
                return (OrganisationStandardMasterDTO != null) ? OrganisationStandardMasterDTO.PrintShortCode : string.Empty;
            }
            set
            {
                OrganisationStandardMasterDTO.PrintShortCode = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (OrganisationStandardMasterDTO != null) ? OrganisationStandardMasterDTO.IsUserDefined : false;
            }
            set
            {
                OrganisationStandardMasterDTO.IsUserDefined = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationStandardMasterDTO != null) ? OrganisationStandardMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationStandardMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationStandardMasterDTO != null && OrganisationStandardMasterDTO.CreatedBy > 0) ? OrganisationStandardMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationStandardMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationStandardMasterDTO != null) ? OrganisationStandardMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationStandardMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationStandardMasterDTO != null && OrganisationStandardMasterDTO.ModifiedBy.HasValue) ? OrganisationStandardMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationStandardMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationStandardMasterDTO != null && OrganisationStandardMasterDTO.ModifiedDate.HasValue) ? OrganisationStandardMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationStandardMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationStandardMasterDTO != null && OrganisationStandardMasterDTO.DeletedBy.HasValue) ? OrganisationStandardMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationStandardMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationStandardMasterDTO != null && OrganisationStandardMasterDTO.DeletedDate.HasValue) ? OrganisationStandardMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationStandardMasterDTO.DeletedDate = value;
            }
        }

    }
}
