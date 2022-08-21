using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class InventoryUoMMasterViewModel : IInventoryUoMMasterViewModel
    {

        public InventoryUoMMasterViewModel()
        {
            InventoryUoMMasterDTO = new InventoryUoMMaster();
        }
        public InventoryUoMMaster InventoryUoMMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.ID > 0) ? InventoryUoMMasterDTO.ID : new Int16();
            }
            set
            {
                InventoryUoMMasterDTO.ID = value;
            }
        }
        public Int16 ItemNumber
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.ItemNumber > 0) ? InventoryUoMMasterDTO.ItemNumber : new Int16();
            }
            set
            {
                InventoryUoMMasterDTO.ItemNumber = value;
            }
        }
        public Int16 InventoryDimentionUnitMasterID
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.InventoryDimentionUnitMasterID > 0) ? InventoryUoMMasterDTO.InventoryDimentionUnitMasterID : new Int16();
            }
            set
            {
                InventoryUoMMasterDTO.InventoryDimentionUnitMasterID = value;
            }
        }
        public Int16 InventoryUoMMasterID
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.InventoryUoMMasterID > 0) ? InventoryUoMMasterDTO.InventoryUoMMasterID : new Int16();
            }
            set
            {
                InventoryUoMMasterDTO.InventoryUoMMasterID = value;
            }
        }
        [Required(ErrorMessage = "Decimal Places Upto should not be blank.")]
        [Display(Name = "Decimal Places Upto")]
        public Int16 DecimalPlacesUpto
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.DecimalPlacesUpto > 0) ? InventoryUoMMasterDTO.DecimalPlacesUpto : new Int16();
            }
            set
            {
                InventoryUoMMasterDTO.DecimalPlacesUpto = value;
            }
        }
        [Required(ErrorMessage = "Decimal Rounding should not be blank.")]
        [Display(Name = "Decimal Rounding")]
        public Int16 DecimalRounding
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.DecimalRounding > 0) ? InventoryUoMMasterDTO.DecimalRounding : new Int16();
            }
            set
            {
                InventoryUoMMasterDTO.DecimalRounding = value;
            }
        }
        public Int16 DimensionUnitMasterID
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.DimensionUnitMasterID > 0) ? InventoryUoMMasterDTO.DimensionUnitMasterID : new Int16();
            }
            set
            {
                InventoryUoMMasterDTO.DimensionUnitMasterID = value;
            }
        }
        [Required(ErrorMessage = "Uom Code should not be blank.")]
        [Display(Name = "Uom Code")]
        public string UomCode
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.UomCode : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.UomCode = value;
            }
        }
        [Required(ErrorMessage = "UoM Description should not be blank.")]
        [Display(Name = "UoM Description")]
        public string UoMDescription
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.UoMDescription : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.UoMDescription = value;
            }
        }
        [Required(ErrorMessage = "Commercial Description should not be blank.")]
        [Display(Name = "Commercial Description")]
        public string CommercialDescription
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.CommercialDescription : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.CommercialDescription = value;
            }
        }
        public string DimensionCode
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.DimensionCode : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.DimensionCode = value;
            }
        }

       
        public string DimensionDescription
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.DimensionDescription : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.DimensionDescription = value;
            }
        }
        [Required(ErrorMessage = "Additive Constant should not be blank.")]
        [Display(Name = "AdditiveConstant")]
        public string AdditiveConstant
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.AdditiveConstant : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.AdditiveConstant = value;
            }
        }
        [Required(ErrorMessage = "Convertion Factor should not be blank.")]
        [Display(Name = "Convertion Factor")]
        public decimal ConvertionFactor
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.ConvertionFactor > 0) ? InventoryUoMMasterDTO.ConvertionFactor : new decimal();
            }
            set
            {
                InventoryUoMMasterDTO.ConvertionFactor = value;
            }
        }
        [Required(ErrorMessage = "IsAlternativeUom should not be blank.")]
        [Display(Name = "Is Alternative Uom")]
        public bool IsAlternativeUom
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.IsAlternativeUom : false;
            }
            set
            {
                InventoryUoMMasterDTO.IsAlternativeUom = value;
            }
        }
        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryUoMMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.CreatedBy > 0) ? InventoryUoMMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryUoMMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryUoMMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryUoMMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryUoMMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryUoMMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryUoMMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

        public int GeneralItemCodeID
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.GeneralItemCodeID : new int();
            }
            set
            {
                InventoryUoMMasterDTO.GeneralItemCodeID = value;
            }
        }
        public string BarCode
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.BarCode : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.BarCode = value;
            }
        }

        public double Price
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.Price > 0) ? InventoryUoMMasterDTO.Price : new double();
            }
            set
            {
                InventoryUoMMasterDTO.Price = value;
            }
        }
    
    //Item master fields
        public bool IsBaseUom
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.IsBaseUom : false;
            }
            set
            {
                InventoryUoMMasterDTO.IsBaseUom = value;
            }
        }

        public double BaseQuantity
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.BaseQuantity > 0) ? InventoryUoMMasterDTO.BaseQuantity : new double();
            }
            set
            {
                InventoryUoMMasterDTO.BaseQuantity = value;
            }
        }
        public double ConversionFactor
        {
            get
            {
                return (InventoryUoMMasterDTO != null && InventoryUoMMasterDTO.ConversionFactor > 0) ? InventoryUoMMasterDTO.ConversionFactor : new double();
            }
            set
            {
                InventoryUoMMasterDTO.ConversionFactor = value;
            }
        }
        public string BaseUoMcode
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.BaseUoMcode : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.BaseUoMcode = value;
            }
        }

        public string GeneralItemCodeBaseUoM
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.GeneralItemCodeBaseUoM : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.GeneralItemCodeBaseUoM = value;
            }
        }
        public string LowerLevelUomCode
        {
            get
            {
                return (InventoryUoMMasterDTO != null) ? InventoryUoMMasterDTO.LowerLevelUomCode : string.Empty;
            }
            set
            {
                InventoryUoMMasterDTO.LowerLevelUomCode = value;
            }
        }
    }
}

