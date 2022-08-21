using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralPriceGroupViewModel : IGeneralPriceGroupViewModel
    {

        public GeneralPriceGroupViewModel()
        {
            GeneralPriceGroupDTO = new GeneralPriceGroup();

        }



        public GeneralPriceGroup GeneralPriceGroupDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralPriceGroupDTO != null && GeneralPriceGroupDTO.ID > 0) ? GeneralPriceGroupDTO.ID : new Int16();
            }
            set
            {
                GeneralPriceGroupDTO.ID = value;
            }
        }
         [Display(Name = "Related To")]
        public Int16 IsRelatedTo
        {
            get
            {
                return (GeneralPriceGroupDTO != null && GeneralPriceGroupDTO.IsRelatedTo > 0) ? GeneralPriceGroupDTO.IsRelatedTo : new Int16();
            }
            set
            {
                GeneralPriceGroupDTO.IsRelatedTo = value;
            }
        }

        [Required(ErrorMessage = "General Price Group Description should not be blank.")]
        [Display(Name = "General Price Group Description")]
        public string GeneralPriceGroupDescription
        {
            get
            {
                return (GeneralPriceGroupDTO != null) ? GeneralPriceGroupDTO.GeneralPriceGroupDescription : string.Empty;
            }
            set
            {
                GeneralPriceGroupDTO.GeneralPriceGroupDescription = value;
            }
        }

        [Required(ErrorMessage = "General Price Group Code should not be blank.")]
        [Display(Name = "General Price Group Code")]
        public string GeneralPriceGroupCode
        {
            get
            {
                return (GeneralPriceGroupDTO != null) ? GeneralPriceGroupDTO.GeneralPriceGroupCode : string.Empty;
            }
            set
            {
                GeneralPriceGroupDTO.GeneralPriceGroupCode = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPriceGroupDTO != null) ? GeneralPriceGroupDTO.IsDeleted : false;
            }
            set
            {
                GeneralPriceGroupDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPriceGroupDTO != null && GeneralPriceGroupDTO.CreatedBy > 0) ? GeneralPriceGroupDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPriceGroupDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPriceGroupDTO != null) ? GeneralPriceGroupDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPriceGroupDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralPriceGroupDTO != null) ? GeneralPriceGroupDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPriceGroupDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralPriceGroupDTO != null) ? GeneralPriceGroupDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPriceGroupDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralPriceGroupDTO != null) ? GeneralPriceGroupDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPriceGroupDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralPriceGroupDTO != null) ? GeneralPriceGroupDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPriceGroupDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

