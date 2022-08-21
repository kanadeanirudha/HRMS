using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralPriceListAndListLineViewModel : IGeneralPriceListAndListLineViewModel
    {

        public GeneralPriceListAndListLineViewModel()
        {
            GeneralPriceListAndListLineDTO = new GeneralPriceListAndListLine();
        }
        
        public GeneralPriceListAndListLine GeneralPriceListAndListLineDTO
        {
            get;
            set;
        }

        public Int16 GeneralPriceListID
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null && GeneralPriceListAndListLineDTO.GeneralPriceListID > 0) ? GeneralPriceListAndListLineDTO.GeneralPriceListID : new Int16();
            }
            set
            {
                GeneralPriceListAndListLineDTO.GeneralPriceListID = value;
            }
        }

        [Required(ErrorMessage = "Price List Name should not be blank.")]
        [Display(Name = "Price List Name")]
        public string PriceListName
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.PriceListName : string.Empty;
            }
            set
            {
                GeneralPriceListAndListLineDTO.PriceListName = value;
            }
        }
        public string BasePriceListname
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.BasePriceListname : string.Empty;
            }
            set
            {
                GeneralPriceListAndListLineDTO.BasePriceListname = value;
            }
        }
        public string GeneralPriceGroupCode
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.GeneralPriceGroupCode : string.Empty;
            }
            set
            {
                GeneralPriceListAndListLineDTO.GeneralPriceGroupCode = value;
            }
        }
        public string GeneralPriceGroupDescription
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.GeneralPriceGroupDescription : string.Empty;
            }
            set
            {
                GeneralPriceListAndListLineDTO.GeneralPriceGroupDescription = value;
            }
        }
        [Display(Name = "Is Root")]
        public bool IsRoot
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.IsRoot : false;
            }
            set
            {
                GeneralPriceListAndListLineDTO.IsRoot = value;
            }
        }
         [Display(Name = "Is Automatic Update")]
        public bool IsUpdationAutomatic
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.IsUpdationAutomatic : false;
            }
            set
            {
                GeneralPriceListAndListLineDTO.IsUpdationAutomatic = value;
            }
        }

        public Int16 GeneralPriceListLineID
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null && GeneralPriceListAndListLineDTO.GeneralPriceListLineID > 0) ? GeneralPriceListAndListLineDTO.GeneralPriceListLineID : new Int16();
            }
            set
            {
                GeneralPriceListAndListLineDTO.GeneralPriceListLineID = value;
            }
        }
        [Display(Name = "Base Prise List")]
        public Int16 BasePriseListID
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null && GeneralPriceListAndListLineDTO.BasePriseListID > 0) ? GeneralPriceListAndListLineDTO.BasePriseListID : new Int16();
            }
            set
            {
                GeneralPriceListAndListLineDTO.BasePriseListID = value;
            }
        }
        [Display(Name = "Factor")]
        public decimal Factor
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null && GeneralPriceListAndListLineDTO.Factor > 0) ? GeneralPriceListAndListLineDTO.Factor : new decimal();
            }
            set
            {
                GeneralPriceListAndListLineDTO.Factor = value;
            }
        }
        [Display(Name = "Rounding Method")]
        public Byte RoundingMethod
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null && GeneralPriceListAndListLineDTO.RoundingMethod > 0) ? GeneralPriceListAndListLineDTO.RoundingMethod : new byte();
            }
            set
            {
                GeneralPriceListAndListLineDTO.RoundingMethod = value;
            }
        }
         [Display(Name = "Valid From Date")]
        public string ValidFromDate
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.ValidFromDate : string.Empty;
            }
            set
            {
                GeneralPriceListAndListLineDTO.ValidFromDate = value;
            }
        }
        [Display(Name = "Valid Upto Date")]
        public string ValidUptoDate
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.ValidUptoDate : string.Empty;
            }
            set
            {
                GeneralPriceListAndListLineDTO.ValidUptoDate = value;
            }
        }
         [Display(Name = "Price Group")]
        public Int16 PriceGroupId
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null && GeneralPriceListAndListLineDTO.PriceGroupId > 0) ? GeneralPriceListAndListLineDTO.PriceGroupId : new Int16();
            }
            set
            {
                GeneralPriceListAndListLineDTO.PriceGroupId = value;
            }
        }
        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.IsActive : false;
            }
            set
            {
                GeneralPriceListAndListLineDTO.IsActive = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.IsDeleted : false;
            }
            set
            {
                GeneralPriceListAndListLineDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null && GeneralPriceListAndListLineDTO.CreatedBy > 0) ? GeneralPriceListAndListLineDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPriceListAndListLineDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPriceListAndListLineDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPriceListAndListLineDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPriceListAndListLineDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPriceListAndListLineDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPriceListAndListLineDTO.DeletedDate = value;
            }
        }
        public Int16 IsRootCount
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null && GeneralPriceListAndListLineDTO.IsRootCount > 0) ? GeneralPriceListAndListLineDTO.IsRootCount : new Int16();
            }
            set
            {
                GeneralPriceListAndListLineDTO.IsRootCount = value;
            }
        }
        [Display(Name = "Is Round")]
        public bool IsRounding
        {
            get
            {
                return (GeneralPriceListAndListLineDTO != null) ? GeneralPriceListAndListLineDTO.IsRounding : false;
            }
            set
            {
                GeneralPriceListAndListLineDTO.IsRounding = value;
            }
        }

        public string errorMessage { get; set; }

        public string EntityLevel { get; set; }
        
    }
}

