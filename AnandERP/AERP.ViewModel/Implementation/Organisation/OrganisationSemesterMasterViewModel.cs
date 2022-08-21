using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class OrganisationSemesterMasterViewModel : IOrganisationSemesterMasterViewModel
    {
        public OrganisationSemesterMasterViewModel()
        {
            OrganisationSemesterMasterDTO = new OrganisationSemesterMaster();
        }

        public OrganisationSemesterMaster OrganisationSemesterMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null && OrganisationSemesterMasterDTO.ID > 0) ? OrganisationSemesterMasterDTO.ID : new int();
            }
            set
            {
                OrganisationSemesterMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_OrgSemesterName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OrgSemesterNameRequired")]
        public string OrgSemesterName
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null) ? OrganisationSemesterMasterDTO.OrgSemesterName : string.Empty;
            }
            set
            {
                OrganisationSemesterMasterDTO.OrgSemesterName = value;
            }
        }

        [Display(Name = "DisplayName_SemesterType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SemesterTypeRequired")]
        public string SemesterType
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null) ? OrganisationSemesterMasterDTO.SemesterType : string.Empty;
            }
            set
            {
                OrganisationSemesterMasterDTO.SemesterType = value;
            }
        }

        [Display(Name = "DisplayName_SemesterCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SemesterCodeRequired")]
        public string SemesterCode
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null) ? OrganisationSemesterMasterDTO.SemesterCode : string.Empty;
            }
            set
            {
                OrganisationSemesterMasterDTO.SemesterCode = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null) ? OrganisationSemesterMasterDTO.IsUserDefined: false;
            }
            set
            {
                OrganisationSemesterMasterDTO.IsUserDefined = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null) ? OrganisationSemesterMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationSemesterMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null && OrganisationSemesterMasterDTO.CreatedBy > 0) ? OrganisationSemesterMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSemesterMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null) ? OrganisationSemesterMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSemesterMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null && OrganisationSemesterMasterDTO.ModifiedBy.HasValue) ? OrganisationSemesterMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSemesterMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null && OrganisationSemesterMasterDTO.ModifiedDate.HasValue) ? OrganisationSemesterMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSemesterMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null && OrganisationSemesterMasterDTO.DeletedBy.HasValue) ? OrganisationSemesterMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSemesterMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSemesterMasterDTO != null && OrganisationSemesterMasterDTO.DeletedDate.HasValue) ? OrganisationSemesterMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSemesterMasterDTO.DeletedDate = value;
            }
        }

    }
}
