using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralTemperatureMasterViewModel : IGeneralTemperatureMasterViewModel
    {

        public GeneralTemperatureMasterViewModel()
        {
            GeneralTemperatureMasterDTO = new GeneralTemperatureMaster();

        }



        public GeneralTemperatureMaster GeneralTemperatureMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null && GeneralTemperatureMasterDTO.ID > 0) ? GeneralTemperatureMasterDTO.ID : new Int16();
            }
            set
            {
                GeneralTemperatureMasterDTO.ID = value;
            }
        }

        public int GeneralTemperatureMasterID
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null && GeneralTemperatureMasterDTO.GeneralTemperatureMasterID > 0) ? GeneralTemperatureMasterDTO.GeneralTemperatureMasterID : new int();
            }
            set
            {
                GeneralTemperatureMasterDTO.GeneralTemperatureMasterID = value;
            }
        }



        [Display(Name = "Temperature Description")]
        public string TemperatureDescription
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.TemperatureDescription : string.Empty;
            }
            set
            {
                GeneralTemperatureMasterDTO.TemperatureDescription = value;
            }
        }

        [Display(Name = "Temperature Type")]
        public string TemperatureType
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.TemperatureType : string.Empty;
            }
            set
            {
                GeneralTemperatureMasterDTO.TemperatureType = value;
            }
        }
        [Display(Name = "Min Temperature")]
        public decimal TemperatureFrom
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.TemperatureFrom : new decimal();
            }
            set
            {
                GeneralTemperatureMasterDTO.TemperatureFrom = value;
            }
        }
        [Display(Name = "Max Temperature")]
        public decimal TemperatureUpto
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.TemperatureUpto : new decimal();
            }
            set
            {
                GeneralTemperatureMasterDTO.TemperatureUpto = value;
            }
        } 

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralTemperatureMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null && GeneralTemperatureMasterDTO.CreatedBy > 0) ? GeneralTemperatureMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralTemperatureMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralTemperatureMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralTemperatureMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralTemperatureMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralTemperatureMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralTemperatureMasterDTO != null) ? GeneralTemperatureMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralTemperatureMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

