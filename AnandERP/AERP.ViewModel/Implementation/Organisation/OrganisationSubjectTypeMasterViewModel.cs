using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class OrganisationSubjectTypeMasterViewModel : IOrganisationSubjectTypeMasterViewModel
    {
        public OrganisationSubjectTypeMasterViewModel()
        {
            OrganisationSubjectTypeMasterDTO = new OrganisationSubjectTypeMaster();
        }

        public OrganisationSubjectTypeMaster OrganisationSubjectTypeMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null && OrganisationSubjectTypeMasterDTO.ID > 0) ? OrganisationSubjectTypeMasterDTO.ID : new Int16();
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_SubjectTypeName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectTypeNameRequired")]
        public string TypeName
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null) ? OrganisationSubjectTypeMasterDTO.TypeName : string.Empty;
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.TypeName = value;
            }
        }

        [Display(Name = "DisplayName_SubjectTypeShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectTypeShortCodeRequired")]
        public string TypeShortCode
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null) ? OrganisationSubjectTypeMasterDTO.TypeShortCode : string.Empty;
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.TypeShortCode = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null) ? OrganisationSubjectTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null && OrganisationSubjectTypeMasterDTO.CreatedBy > 0) ? OrganisationSubjectTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null) ? OrganisationSubjectTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null && OrganisationSubjectTypeMasterDTO.ModifiedBy.HasValue) ? OrganisationSubjectTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null && OrganisationSubjectTypeMasterDTO.ModifiedDate.HasValue) ? OrganisationSubjectTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null && OrganisationSubjectTypeMasterDTO.DeletedBy.HasValue) ? OrganisationSubjectTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSubjectTypeMasterDTO != null && OrganisationSubjectTypeMasterDTO.DeletedDate.HasValue) ? OrganisationSubjectTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectTypeMasterDTO.DeletedDate = value;
            }
        }

    }
}
