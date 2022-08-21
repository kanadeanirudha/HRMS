using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{

    public class GeneralPeriodTypeMasterViewModel : IGeneralPeriodTypeMasterViewModel
    {
        public GeneralPeriodTypeMasterViewModel()
        {
            GeneralPeriodTypeMasterDTO = new GeneralPeriodTypeMaster();
        }
        public GeneralPeriodTypeMaster GeneralPeriodTypeMasterDTO {get;set;}

        public int GeneralPeriodTypeMasterID
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null && GeneralPeriodTypeMasterDTO.GeneralPeriodTypeMasterID > 0) ? GeneralPeriodTypeMasterDTO.GeneralPeriodTypeMasterID : new int();
            }
            set
            {
                GeneralPeriodTypeMasterDTO.GeneralPeriodTypeMasterID = value;
            }
        }

        [Required(ErrorMessage = "Period Type should not be blank.")]
        [Display(Name = "Period Type")]
        public string PeriodType
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null) ? GeneralPeriodTypeMasterDTO.PeriodType : string.Empty;
            }
            set
            {
                GeneralPeriodTypeMasterDTO.PeriodType = value;
            }
        }

        [Required(ErrorMessage = "Number of days should not be blank.")]
        [Display(Name = "Number Of Days")]
        public Int16 NumberOfDays
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null && GeneralPeriodTypeMasterDTO.NumberOfDays > 0) ? GeneralPeriodTypeMasterDTO.NumberOfDays : new Int16();
            }
            set
            {
                GeneralPeriodTypeMasterDTO.NumberOfDays = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null) ? GeneralPeriodTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralPeriodTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null && GeneralPeriodTypeMasterDTO.CreatedBy > 0) ? GeneralPeriodTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPeriodTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null) ? GeneralPeriodTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPeriodTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null) ? GeneralPeriodTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPeriodTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null) ? GeneralPeriodTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPeriodTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null) ? GeneralPeriodTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPeriodTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralPeriodTypeMasterDTO != null) ? GeneralPeriodTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPeriodTypeMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}
