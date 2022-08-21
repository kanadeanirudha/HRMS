using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralJobProfileViewModel
    {

        public GeneralJobProfileViewModel()
        {
            GeneralJobProfileDTO = new GeneralJobProfile();
        }

        public GeneralJobProfile GeneralJobProfileDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.ID > 0) ? GeneralJobProfileDTO.ID : new int();
            }
            set
            {
                GeneralJobProfileDTO.ID = value;
            }
        }


        [Display(Name = "Job Profile Description")]
        [Required(ErrorMessage ="Job Profile Description Required")]
        public string JobProfileDescription
        {
            get
            {
                return (GeneralJobProfileDTO != null) ? GeneralJobProfileDTO.JobProfileDescription : string.Empty;
            }
            set
            {
                GeneralJobProfileDTO.JobProfileDescription = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (GeneralJobProfileDTO != null) ? GeneralJobProfileDTO.IsActive : false;
            }
            set
            {
                GeneralJobProfileDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralJobProfileDTO != null) ? GeneralJobProfileDTO.IsDeleted : false;
            }
            set
            {
                GeneralJobProfileDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.CreatedBy > 0) ? GeneralJobProfileDTO.CreatedBy : new int();
            }
            set
            {
                GeneralJobProfileDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralJobProfileDTO != null) ? GeneralJobProfileDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralJobProfileDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.ModifiedBy.HasValue) ? GeneralJobProfileDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralJobProfileDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.ModifiedDate.HasValue) ? GeneralJobProfileDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralJobProfileDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.DeletedBy.HasValue) ? GeneralJobProfileDTO.DeletedBy : new int();
            }
            set
            {
                GeneralJobProfileDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.DeletedDate.HasValue) ? GeneralJobProfileDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralJobProfileDTO.DeletedDate = value;
            }
        }

        public string SelectedCountryID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
