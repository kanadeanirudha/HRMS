using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralWeekDaysViewModel : IGeneralWeekDaysViewModel
    {

        public GeneralWeekDaysViewModel()
        {


            GeneralWeekDaysDTO = new GeneralWeekDays();
        }

        public GeneralWeekDays GeneralWeekDaysDTO
        {
            get;
            set;
        }

        public List<GeneralWeekDays> ListGeneralWeekDays
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralWeekDaysDTO != null && GeneralWeekDaysDTO.ID > 0) ? GeneralWeekDaysDTO.ID : new int();
            }
            set
            {
                GeneralWeekDaysDTO.ID = value;
            }
        }

        [Display(Name = "Week Description")]
        [Required(ErrorMessage ="Week Description Required")]
        public string WeekDescription
        {
            get
            {
                return (GeneralWeekDaysDTO != null) ? GeneralWeekDaysDTO.WeekDescription : string.Empty;
            }
            set
            {
                GeneralWeekDaysDTO.WeekDescription = value;
            }
        }

       [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (GeneralWeekDaysDTO != null) ? GeneralWeekDaysDTO.IsActive : false;
            }
            set
            {
                GeneralWeekDaysDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralWeekDaysDTO != null) ? GeneralWeekDaysDTO.IsDeleted : false;
            }
            set
            {
                GeneralWeekDaysDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralWeekDaysDTO != null && GeneralWeekDaysDTO.CreatedBy > 0) ? GeneralWeekDaysDTO.CreatedBy : new int();
            }
            set
            {
                GeneralWeekDaysDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralWeekDaysDTO != null) ? GeneralWeekDaysDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralWeekDaysDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralWeekDaysDTO != null && GeneralWeekDaysDTO.ModifiedBy.HasValue) ? GeneralWeekDaysDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralWeekDaysDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralWeekDaysDTO != null && GeneralWeekDaysDTO.ModifiedDate.HasValue) ? GeneralWeekDaysDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralWeekDaysDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralWeekDaysDTO != null && GeneralWeekDaysDTO.DeletedBy.HasValue) ? GeneralWeekDaysDTO.DeletedBy : new int();
            }
            set
            {
                GeneralWeekDaysDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralWeekDaysDTO != null && GeneralWeekDaysDTO.DeletedDate.HasValue) ? GeneralWeekDaysDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralWeekDaysDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }

    }
}
