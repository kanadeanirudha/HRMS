using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralTitleMasterViewModel : IGeneralTitleMasterViewModel
    {

        public GeneralTitleMasterViewModel()
        {


            GeneralTitleMasterDTO = new GeneralTitleMaster();
        }

        public GeneralTitleMaster GeneralTitleMasterDTO
        {
            get;
            set;
        }

        public List<GeneralTitleMaster> ListGeneralTitleMaster
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralTitleMasterDTO != null && GeneralTitleMasterDTO.ID > 0) ? GeneralTitleMasterDTO.ID : new int();
            }
            set
            {
                GeneralTitleMasterDTO.ID = value;
            }
        }

        [Display(Name = "Description")]
        [Required(ErrorMessage ="Description Required")]
        public string Description
        {
            get
            {
                return (GeneralTitleMasterDTO != null) ? GeneralTitleMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralTitleMasterDTO.Description = value;
            }
        }

        [Display(Name = "DisplayName_NameTitle")]
        [Required(ErrorMessage ="Title Name Required")]
        public string NameTitle
        {
            get
            {
                return (GeneralTitleMasterDTO != null) ? GeneralTitleMasterDTO.NameTitle : string.Empty;
            }
            set
            {
                GeneralTitleMasterDTO.NameTitle = value;
            }
        }
        [Display(Name = "Gender")]
        public string Gender
        {
            get
            {
                return (GeneralTitleMasterDTO != null) ? GeneralTitleMasterDTO.Gender : string.Empty;
            }
            set
            {
                GeneralTitleMasterDTO.Gender = value;
            }
        }

        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (GeneralTitleMasterDTO != null) ? GeneralTitleMasterDTO.IsActive : false;
            }
            set
            {
                GeneralTitleMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralTitleMasterDTO != null) ? GeneralTitleMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralTitleMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralTitleMasterDTO != null && GeneralTitleMasterDTO.CreatedBy > 0) ? GeneralTitleMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralTitleMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralTitleMasterDTO != null) ? GeneralTitleMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralTitleMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralTitleMasterDTO != null && GeneralTitleMasterDTO.ModifiedBy.HasValue) ? GeneralTitleMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralTitleMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralTitleMasterDTO != null && GeneralTitleMasterDTO.ModifiedDate.HasValue) ? GeneralTitleMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralTitleMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralTitleMasterDTO != null && GeneralTitleMasterDTO.DeletedBy.HasValue) ? GeneralTitleMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralTitleMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralTitleMasterDTO != null && GeneralTitleMasterDTO.DeletedDate.HasValue) ? GeneralTitleMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralTitleMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }

    }
}
