using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class ESICZoneMasterViewModel 
    {

        public ESICZoneMasterViewModel()
        {
            ESICZoneMasterDTO = new ESICZoneMaster();

        }



        public ESICZoneMaster ESICZoneMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (ESICZoneMasterDTO != null && ESICZoneMasterDTO.ID > 0) ? ESICZoneMasterDTO.ID : new Int16();
            }
            set
            {
                ESICZoneMasterDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Zone Name Required")]
        [Display(Name = "Zone Name")]
        public string ZoneName
        {
            get
            {
                return (ESICZoneMasterDTO != null) ? ESICZoneMasterDTO.ZoneName : string.Empty;
            }
            set
            {
                ESICZoneMasterDTO.ZoneName = value;
            }
        }
        [Required(ErrorMessage = "Zone Code Required")]
        [Display(Name = "Zone Code")]
        public string ZoneCode
        {
            get
            {
                return (ESICZoneMasterDTO != null) ? ESICZoneMasterDTO.ZoneCode : string.Empty;
            }
            set
            {
                ESICZoneMasterDTO.ZoneCode = value;
            }
        }
        
  [Display(Name = "Is Default")]
        public bool IsDefault
        {
            get
            {
                return (ESICZoneMasterDTO != null) ? ESICZoneMasterDTO.IsDefault : false;
            }
            set
            {
                ESICZoneMasterDTO.IsDefault = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ESICZoneMasterDTO != null) ? ESICZoneMasterDTO.IsDeleted : false;
            }
            set
            {
                ESICZoneMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ESICZoneMasterDTO != null && ESICZoneMasterDTO.CreatedBy > 0) ? ESICZoneMasterDTO.CreatedBy : new int();
            }
            set
            {
                ESICZoneMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ESICZoneMasterDTO != null) ? ESICZoneMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ESICZoneMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (ESICZoneMasterDTO != null) ? ESICZoneMasterDTO.ModifiedBy : new int();
            }
            set
            {
                ESICZoneMasterDTO.ModifiedBy = value;
            }
        }

     

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (ESICZoneMasterDTO != null) ? ESICZoneMasterDTO.DeletedBy : new int();
            }
            set
            {
                ESICZoneMasterDTO.DeletedBy = value;
            }
        }

        public string errorMessage { get; set; }


    }
}

