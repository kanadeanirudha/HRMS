using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryUoMMaster : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public Int16 InventoryDimentionUnitMasterID
        {
            get;
            set;
        }
        public Int16 ItemNumber
        {
            get;
            set;
        }
        public Int16 InventoryUoMMasterID
        {
            get;
            set;
        }
        public string UomCode
        {
            get;
            set;
        }

        public string UoMDescription
        {
            get;
            set;
        }

        public string CommercialDescription
        {
            get;
            set;
        }
        public string AdditiveConstant
        {
            get;
            set;
        }
        public Int16 DimensionUnitMasterID
        {
            get;
            set;
        }
        public Int16 DecimalPlacesUpto
        {
            get;
            set;
        }

        public Int16 DecimalRounding
        {
            get;
            set;
        }


        public decimal ConvertionFactor
        {
            get;
            set;
        }
        public bool IsAlternativeUom
        {
            get;
            set;
        }
        public string DimensionCode
        {
            get;
            set;
        }

        public string DimensionDescription
        {
            get;
            set;
        }

        //Feilds from GeneralUnitType//



        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string BarCode
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
        public string BaseUoMcode
        {
            get;
            set;
        }
        public string GeneralItemCodeBaseUoM
        {
            get;
            set;
        }
        public string LowerLevelUomCode
        {
            get;
            set;
        }
        public double BaseQuantity
        {
            get;
            set;
        }
        public double ConversionFactor
        {
            get;
            set;
        }
        public bool IsBaseUom
        {
            get;
            set;
        }
       
        public int GeneralItemCodeID
        {
            get;
            set;
        }
    }
}
