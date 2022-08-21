using AERP.Common;
using AERP.DTO;
using System;
using System.ComponentModel.DataAnnotations;


namespace AERP.ViewModel
{
    public class GeneralNationalityMasterViewModel : IGeneralNationalityMasterViewModel
    {
        public GeneralNationalityMasterViewModel()
        {
            GeneralNationalityMasterDTO = new GeneralNationalityMaster();
        }

        public GeneralNationalityMaster GeneralNationalityMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralNationalityMasterDTO != null && GeneralNationalityMasterDTO.ID > 0) ? GeneralNationalityMasterDTO.ID : new int();
            }
            set
            {
                GeneralNationalityMasterDTO.ID = value;
            }
        }
        [Display(Name = "Nationality Description")]
        [Required(ErrorMessage = "Nationality Description Required")]
        public string Description
        {
            get
            {
                return (GeneralNationalityMasterDTO != null) ? GeneralNationalityMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralNationalityMasterDTO.Description = value;
            }
        }

        [Display(Name = "Default Flag")]
        public bool DefaultFlag
        {
            get
            {
                return (GeneralNationalityMasterDTO != null) ? GeneralNationalityMasterDTO.DefaultFlag : false;
            }
            set
            {
                GeneralNationalityMasterDTO.DefaultFlag = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralNationalityMasterDTO != null) ? GeneralNationalityMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralNationalityMasterDTO.IsUserDefined = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralNationalityMasterDTO != null) ? GeneralNationalityMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralNationalityMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralNationalityMasterDTO != null && GeneralNationalityMasterDTO.CreatedBy > 0) ? GeneralNationalityMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralNationalityMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralNationalityMasterDTO != null) ? GeneralNationalityMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralNationalityMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralNationalityMasterDTO != null && GeneralNationalityMasterDTO.ModifiedBy.HasValue) ? GeneralNationalityMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralNationalityMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralNationalityMasterDTO != null && GeneralNationalityMasterDTO.ModifiedDate.HasValue) ? GeneralNationalityMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralNationalityMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralNationalityMasterDTO != null && GeneralNationalityMasterDTO.DeletedBy.HasValue) ? GeneralNationalityMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralNationalityMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralNationalityMasterDTO != null && GeneralNationalityMasterDTO.DeletedDate.HasValue) ? GeneralNationalityMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralNationalityMasterDTO.DeletedDate = value;
            }
        }

    }
}
