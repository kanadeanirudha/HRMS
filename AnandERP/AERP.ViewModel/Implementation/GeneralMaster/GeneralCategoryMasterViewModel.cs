using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;


namespace AMS.ViewModel
{
    public class GeneralCategoryMasterViewModel : IGeneralCategoryMasterViewModel
    {
        public GeneralCategoryMasterViewModel()
        {
            GeneralCategoryMasterDTO = new GeneralCategoryMaster();
        }

        public GeneralCategoryMaster GeneralCategoryMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralCategoryMasterDTO != null && GeneralCategoryMasterDTO.ID > 0) ? GeneralCategoryMasterDTO.ID : new int();
            }
            set
            {
                GeneralCategoryMasterDTO.ID = value;
            }
        }


        [Display(Name = "DisplayName_CategoryName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryNameRequired")]
        public string CategoryName
        {
            get
            {
                return (GeneralCategoryMasterDTO != null) ? GeneralCategoryMasterDTO.CategoryName : string.Empty;
            }
            set
            {
                GeneralCategoryMasterDTO.CategoryName= value;
            }
        }
        [Display(Name = "DisplayName_CategoryCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryCodeRequired")]
        public string CategoryCode
        {
            get
            {
                return (GeneralCategoryMasterDTO != null) ? GeneralCategoryMasterDTO.CategoryCode : string.Empty;
            }
            set
            {
                GeneralCategoryMasterDTO.CategoryCode = value;
            }
        }

        [Display(Name = "DisplayName_CategoryType", ResourceType = typeof(AMS.Common.Resources))]
      
        public string CategoryType
        {
            get
            {
                return (GeneralCategoryMasterDTO != null) ? GeneralCategoryMasterDTO.CategoryType : string.Empty;
            }
            set
            {
                GeneralCategoryMasterDTO.CategoryType  = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (GeneralCategoryMasterDTO != null) ? GeneralCategoryMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralCategoryMasterDTO.IsUserDefined = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralCategoryMasterDTO != null) ? GeneralCategoryMasterDTO.IsDeleted: false;
            }
            set
            {
                GeneralCategoryMasterDTO.IsDeleted= value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralCategoryMasterDTO != null && GeneralCategoryMasterDTO.CreatedBy > 0) ? GeneralCategoryMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralCategoryMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralCategoryMasterDTO != null) ? GeneralCategoryMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralCategoryMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralCategoryMasterDTO != null && GeneralCategoryMasterDTO.ModifiedBy.HasValue) ? GeneralCategoryMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralCategoryMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralCategoryMasterDTO != null && GeneralCategoryMasterDTO.ModifiedDate.HasValue) ? GeneralCategoryMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralCategoryMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralCategoryMasterDTO != null && GeneralCategoryMasterDTO.DeletedBy.HasValue) ? GeneralCategoryMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralCategoryMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralCategoryMasterDTO != null && GeneralCategoryMasterDTO.DeletedDate.HasValue) ? GeneralCategoryMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralCategoryMasterDTO.DeletedDate = value;
            }
        }

    }
}
