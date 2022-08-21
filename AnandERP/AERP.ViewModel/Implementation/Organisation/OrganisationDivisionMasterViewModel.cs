using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class OrganisationDivisionMasterViewModel : IOrganisationDivisionMasterViewModel
    {
        public OrganisationDivisionMasterViewModel()
        {
            OrganisationDivisionMasterDTO = new OrganisationDivisionMaster();
        }

        public OrganisationDivisionMaster OrganisationDivisionMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null && OrganisationDivisionMasterDTO.ID > 0) ? OrganisationDivisionMasterDTO.ID : new int();
            }
            set
            {
                OrganisationDivisionMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_DivisionDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DivisionDescriptionRequired")]
        public string DivisionDescription
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null) ? OrganisationDivisionMasterDTO.DivisionDescription : string.Empty;
            }
            set
            {
                OrganisationDivisionMasterDTO.DivisionDescription = value;
            }
        }

        [Display(Name = "DisplayName_DivShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DivShortCodeRequired")]
        public string DivShortCode
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null) ? OrganisationDivisionMasterDTO.DivShortCode : string.Empty;
            }
            set
            {
                OrganisationDivisionMasterDTO.DivShortCode = value;
            }
        }

        [Display(Name = "DisplayName_PrintShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PrintShortCodeRequired")]
        public string PrintShortCode
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null) ? OrganisationDivisionMasterDTO.PrintShortCode : string.Empty;
            }
            set
            {
                OrganisationDivisionMasterDTO.PrintShortCode = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null) ? OrganisationDivisionMasterDTO.IsUserDefined : false;
            }
            set
            {
                OrganisationDivisionMasterDTO.IsUserDefined = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null) ? OrganisationDivisionMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationDivisionMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null && OrganisationDivisionMasterDTO.CreatedBy > 0) ? OrganisationDivisionMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationDivisionMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null) ? OrganisationDivisionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationDivisionMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null && OrganisationDivisionMasterDTO.ModifiedBy.HasValue) ? OrganisationDivisionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationDivisionMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null && OrganisationDivisionMasterDTO.ModifiedDate.HasValue) ? OrganisationDivisionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationDivisionMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null && OrganisationDivisionMasterDTO.DeletedBy.HasValue) ? OrganisationDivisionMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationDivisionMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationDivisionMasterDTO != null && OrganisationDivisionMasterDTO.DeletedDate.HasValue) ? OrganisationDivisionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationDivisionMasterDTO.DeletedDate = value;
            }
        }

    }
}
