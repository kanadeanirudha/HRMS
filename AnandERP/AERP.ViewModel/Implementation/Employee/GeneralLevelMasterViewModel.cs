using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralLevelMasterViewModel : IGeneralLevelMasterViewModel
    {

        public GeneralLevelMasterViewModel()
        {
            GeneralLevelMasterDTO = new GeneralLevelMaster();
        }

        public GeneralLevelMaster GeneralLevelMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralLevelMasterDTO != null && GeneralLevelMasterDTO.ID > 0) ? GeneralLevelMasterDTO.ID : new int();
            }
            set
            {
                GeneralLevelMasterDTO.ID = value;
            }
        }
        
        [Display(Name = "Level Name")]
        [Required(ErrorMessage ="Level Name Required")]
        public string Description
        {
            get
            {
                return (GeneralLevelMasterDTO != null) ? GeneralLevelMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralLevelMasterDTO.Description = value;
            }
        }

        public string Level
        {
            get
            {
                return (GeneralLevelMasterDTO != null) ? GeneralLevelMasterDTO.Level : string.Empty;
            }
            set
            {
                GeneralLevelMasterDTO.Level = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (GeneralLevelMasterDTO != null) ? GeneralLevelMasterDTO.IsActive : false;
            }
            set
            {
                GeneralLevelMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralLevelMasterDTO != null) ? GeneralLevelMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralLevelMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralLevelMasterDTO != null && GeneralLevelMasterDTO.CreatedBy > 0) ? GeneralLevelMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralLevelMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralLevelMasterDTO != null) ? GeneralLevelMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralLevelMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralLevelMasterDTO != null && GeneralLevelMasterDTO.ModifiedBy.HasValue) ? GeneralLevelMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralLevelMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralLevelMasterDTO != null && GeneralLevelMasterDTO.ModifiedDate.HasValue) ? GeneralLevelMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralLevelMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralLevelMasterDTO != null && GeneralLevelMasterDTO.DeletedBy.HasValue) ? GeneralLevelMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralLevelMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralLevelMasterDTO != null && GeneralLevelMasterDTO.DeletedDate.HasValue) ? GeneralLevelMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralLevelMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
    }
}


