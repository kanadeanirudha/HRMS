using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{

    public class GeneralCasteMasterBaseViewModel : IGeneralCasteMasterBaseViewModel
    {
        public GeneralCasteMasterBaseViewModel()
        {
            ListGeneralCasteMaster = new List<GeneralCasteMaster>();

            ListGeneralCategoryMaster = new List<GeneralCategoryMaster>();


        }

        public List<GeneralCasteMaster> ListGeneralCasteMaster
        {
            get;
            set;
        }

        public List<GeneralCategoryMaster> ListGeneralCategoryMaster
        {
            get;
            set;
        }

        public string SelectedCategoryID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralRegionMasterItems
        {
            get
            {
                return new SelectList(ListGeneralCategoryMaster, "CategoryID", "CategoryName");
            }
        }

    }

  public  class GeneralCasteMasterViewModel : IGeneralCasteMasterViewModel
    {
        public GeneralCasteMasterViewModel()
        {
            GeneralCasteMasterDTO = new GeneralCasteMaster();
        }

        public GeneralCasteMaster GeneralCasteMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralCasteMasterDTO != null && GeneralCasteMasterDTO.ID > 0) ? GeneralCasteMasterDTO.ID : new int();
            }
            set
            {
                GeneralCasteMasterDTO.ID = value;
            }
        }




        public int CategoryID
        {
            get
            {
                return (GeneralCasteMasterDTO != null) ? GeneralCasteMasterDTO.CategoryID : new int();
            }
            set
            {
                GeneralCasteMasterDTO.CategoryID = value;
            }
        }


       [Display(Name = "DisplayName_CategoryName", ResourceType = typeof(AMS.Common.Resources))]
        public string CategoryName
        {
            get
            {
                return (GeneralCasteMasterDTO != null) ? GeneralCasteMasterDTO.CategoryName : string.Empty;
            }
            set
            {
                GeneralCasteMasterDTO.CategoryName = value;
            }
        }

          [Display(Name = "DisplayName_Description", ResourceType = typeof(AMS.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DescriptionRequired")]
        public string Description
        {
            get
            {
                return (GeneralCasteMasterDTO != null) ? GeneralCasteMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralCasteMasterDTO.Description = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (GeneralCasteMasterDTO != null) ? GeneralCasteMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralCasteMasterDTO.IsUserDefined = value;
            }
        } 

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralCasteMasterDTO != null) ? GeneralCasteMasterDTO.IsDeleted: false;
            }
            set
            {
                GeneralCasteMasterDTO.IsDeleted= value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralCasteMasterDTO != null && GeneralCasteMasterDTO.CreatedBy > 0) ? GeneralCasteMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralCasteMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralCasteMasterDTO != null) ? GeneralCasteMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralCasteMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralCasteMasterDTO != null && GeneralCasteMasterDTO.ModifiedBy.HasValue) ? GeneralCasteMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralCasteMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralCasteMasterDTO != null && GeneralCasteMasterDTO.ModifiedDate.HasValue) ? GeneralCasteMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralCasteMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralCasteMasterDTO != null && GeneralCasteMasterDTO.DeletedBy.HasValue) ? GeneralCasteMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralCasteMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralCasteMasterDTO != null && GeneralCasteMasterDTO.DeletedDate.HasValue) ? GeneralCasteMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralCasteMasterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "DisplayName_CategoryName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CategoryNameRequired")]
        public string SelectedCategoryID
        {
            get;
            set;
        }
      [Display(Name="Cast name")]
      [Required(ErrorMessage = "Cast name should not blank.")]
        public string CastName
        {
            get
            {
                return (GeneralCasteMasterDTO != null) ? GeneralCasteMasterDTO.CastName : string.Empty;
            }
            set
            {
                GeneralCasteMasterDTO.CastName = value;
            }
        }
    }
}
