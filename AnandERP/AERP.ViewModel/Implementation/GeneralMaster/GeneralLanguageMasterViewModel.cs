using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
   public  class GeneralLanguageMasterViewModel
    {
       public GeneralLanguageMasterViewModel()
        {
            GeneralLanguageMasterDTO = new GeneralLanguageMaster();
        }

       public GeneralLanguageMaster GeneralLanguageMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralLanguageMasterDTO != null && GeneralLanguageMasterDTO.ID > 0) ? GeneralLanguageMasterDTO.ID : new int();
            }
            set
            {
                GeneralLanguageMasterDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_LanguageName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LanguageNameRequired")]
        public string LanguageName
        {
            get
            {
                return (GeneralLanguageMasterDTO != null) ? GeneralLanguageMasterDTO.LanguageName  : string.Empty;
            }
            set
            {
                GeneralLanguageMasterDTO.LanguageName= value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralLanguageMasterDTO != null) ? GeneralLanguageMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralLanguageMasterDTO.IsUserDefined = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralLanguageMasterDTO != null) ? GeneralLanguageMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralLanguageMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralLanguageMasterDTO != null && GeneralLanguageMasterDTO.CreatedBy > 0) ? GeneralLanguageMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralLanguageMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralLanguageMasterDTO != null) ? GeneralLanguageMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralLanguageMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralLanguageMasterDTO != null && GeneralLanguageMasterDTO.ModifiedBy.HasValue) ? GeneralLanguageMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralLanguageMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralLanguageMasterDTO != null && GeneralLanguageMasterDTO.ModifiedDate.HasValue) ? GeneralLanguageMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralLanguageMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralLanguageMasterDTO != null && GeneralLanguageMasterDTO.DeletedBy.HasValue) ? GeneralLanguageMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralLanguageMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralLanguageMasterDTO != null && GeneralLanguageMasterDTO.DeletedDate.HasValue) ? GeneralLanguageMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralLanguageMasterDTO.DeletedDate = value;
            }
        }
    }
}
