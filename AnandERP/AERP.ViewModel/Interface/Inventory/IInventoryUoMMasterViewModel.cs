using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IInventoryUoMMasterViewModel
    {
        InventoryUoMMaster InventoryUoMMasterDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        Int16 ItemNumber
        {
            get;
            set;
        }
        Int16 InventoryDimentionUnitMasterID
        {
            get;
            set;
        }
        Int16 InventoryUoMMasterID
        {
            get;
            set;
        }
        Int16 DecimalPlacesUpto
        {
            get;
            set;
        }


        Int16 DecimalRounding
        {
            get;
            set;
        }
        string DimensionCode
        {
            get;
            set;
        }

        string DimensionDescription
        {
            get;
            set;
        }

        Int16 DimensionUnitMasterID
        {
            get;
            set;
        }
        string UomCode
        {
            get;
            set;
        }

        string UoMDescription
        {
            get;
            set;
        }

        string CommercialDescription
        {
            get;
            set;
        }
        string AdditiveConstant
        {
            get;
            set;
        }
        decimal ConvertionFactor
        {
            get;
            set;
        }
        bool IsAlternativeUom
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    //Item master fields
         string BarCode
        {
            get;
            set;
        }
         double Price
        {
            get;
            set;
        }
         string BaseUoMcode
        {
            get;
            set;
        }
         string GeneralItemCodeBaseUoM
        {
            get;
            set;
        }
         string LowerLevelUomCode
        {
            get;
            set;
        }
         double BaseQuantity
        {
            get;
            set;
        }
         double ConversionFactor
        {
            get;
            set;
        }
         bool IsBaseUom
        {
            get;
            set;
        }
       
         int GeneralItemCodeID
        {
            get;
            set;
        }
    
    }
}
