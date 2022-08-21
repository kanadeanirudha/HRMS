using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralPackingTypeInfoViewModel : IGeneralPackingTypeInfoViewModel
    {

        public GeneralPackingTypeInfoViewModel()
        {
            GeneralPackingTypeInfoDTO = new GeneralPackingTypeInfo();

        }



        public GeneralPackingTypeInfo GeneralPackingTypeInfoDTO
        {
            get;
            set;
        }
        public int UomCodeId
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.UomCodeId > 0) ? GeneralPackingTypeInfoDTO.UomCodeId : new int();
            }
            set
            {
                GeneralPackingTypeInfoDTO.UomCodeId = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.ItemNumber > 0) ? GeneralPackingTypeInfoDTO.ItemNumber : new int();
            }
            set
            {
                GeneralPackingTypeInfoDTO.ItemNumber = value;
            }
        }
        public Int32 ID
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.ID > 0) ? GeneralPackingTypeInfoDTO.ID : new Int32();
            }
            set
            {
                GeneralPackingTypeInfoDTO.ID = value;
            }
        }
        public Int32 ItemCodeID
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.ItemCodeID > 0) ? GeneralPackingTypeInfoDTO.ItemCodeID : new Int32();
            }
            set
            {
                GeneralPackingTypeInfoDTO.ItemCodeID = value;
            }
        }
        public Int32 PackageTypeID
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.PackageTypeID > 0) ? GeneralPackingTypeInfoDTO.PackageTypeID : new Int32();
            }
            set
            {
                GeneralPackingTypeInfoDTO.PackageTypeID = value;
            }
        }
        public string PackageType
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.PackageType : string.Empty;
            }
            set
            {
                GeneralPackingTypeInfoDTO.PackageType = value;
            }
        }
        [Required(ErrorMessage = "Item Description should not be blank.")]
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.ItemDescription : string.Empty;
            }
            set
            {
                GeneralPackingTypeInfoDTO.ItemDescription = value;
            }
        }
        [Required(ErrorMessage = "Uom Code should not be blank.")]
        [Display(Name = "Uom Code")]
        public string UomCode
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.UomCode : string.Empty;
            }
            set
            {
                GeneralPackingTypeInfoDTO.UomCode = value;
            }
        }

        [Required(ErrorMessage = "Height should not be blank.")]
        [Display(Name = "Height")]
        public decimal Height
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.Height > 0) ? GeneralPackingTypeInfoDTO.Height : new decimal();
            }
            set
            {
                GeneralPackingTypeInfoDTO.Height = value;
            }
        }

        [Required(ErrorMessage = "Length should not be blank.")]
        [Display(Name = "Length")]
        public decimal Length
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.Length > 0) ? GeneralPackingTypeInfoDTO.Length : new decimal();
            }
            set
            {
                GeneralPackingTypeInfoDTO.Length = value;
            }
        }
        [Required(ErrorMessage = "Width should not be blank.")]
        [Display(Name = "Width")]
        public decimal Width
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.Width > 0) ? GeneralPackingTypeInfoDTO.Width : new decimal();
            }
            set
            {
                GeneralPackingTypeInfoDTO.Width = value;
            }
        }
        [Required(ErrorMessage = "Weight should not be blank.")]
        [Display(Name = "Weight")]
        public decimal Weight
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.Weight > 0) ? GeneralPackingTypeInfoDTO.Weight : new decimal();
            }
            set
            {
                GeneralPackingTypeInfoDTO.Weight = value;
            }
        }
        [Required(ErrorMessage = "Volume should not be blank.")]
        [Display(Name = "Volume")]
        public decimal Volume
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.Volume > 0) ? GeneralPackingTypeInfoDTO.Volume : new decimal();
            }
            set
            {
                GeneralPackingTypeInfoDTO.Volume = value;
            }
        }
        [Required(ErrorMessage = "Quantity Per Package should not be blank.")]
        [Display(Name = "Quantity Per Package")]
        public decimal QuantityPerPackage
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.QuantityPerPackage > 0) ? GeneralPackingTypeInfoDTO.QuantityPerPackage : new decimal();
            }
            set
            {
                GeneralPackingTypeInfoDTO.QuantityPerPackage = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.IsDeleted : false;
            }
            set
            {
                GeneralPackingTypeInfoDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null && GeneralPackingTypeInfoDTO.CreatedBy > 0) ? GeneralPackingTypeInfoDTO.CreatedBy : new int();
            }
            set
            {
                GeneralPackingTypeInfoDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralPackingTypeInfoDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralPackingTypeInfoDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralPackingTypeInfoDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.DeletedBy : new int();
            }
            set
            {
                GeneralPackingTypeInfoDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralPackingTypeInfoDTO != null) ? GeneralPackingTypeInfoDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralPackingTypeInfoDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

