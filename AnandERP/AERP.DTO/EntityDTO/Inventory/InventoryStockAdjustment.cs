using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryStockAdjustment : BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        public bool IsCurrentStock
        {
            get;
            set;
        }
        public string CurrentStockStatus
        {
            get;
            set;
        }
        public string XMLstring
        {
            get;
            set;
        }
        public string OrderUom
        {
            get;
            set;
        }
        public int InventoryPhysicalStockAdjustmentMasterID
        {
            get;
            set;
        }
        public int InventoryPhysicalStockAdjustmentID
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public int IssueFromLocationID
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public Int16 GeneralunitsID
        {
            get;
            set;
        }
        public double Rate
        {
            get;
            set;
        }
        public double LastPurchasePrice
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
        public string Convertion
        {
            get;
            set;
        }
        public string UOM
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public string LowerUom
        {
            get;
            set;
        }
        public double Quantity
        {
            get;
            set;
        }
        public double RecipeQuantity
        {
            get;
            set;
        }
        public decimal ConvFact
        {
            get;
            set;
        }
        public byte Action
        {
            get;
            set;
        }
        public string TransDate
        {
            get;
            set;
        }
        public decimal CorrectedStock
        {
            get;
            set;
        }
        public decimal TotalStock
        {
            get;
            set;
        }
        public decimal UnrestrictedStock
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
        public bool IsDeleted
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public string ParameterVoucherXmlForActionSample { get; set; }
        public string ParameterVoucherXmlForActionDamaged { get; set; }
        public string ParameterVoucherXmlForActionBlockedForInsp { get; set; }
        public string ParameterVoucherXmlForActionPIPostive { get; set; }
        public string ParameterVoucherXmlForActionPINegative { get; set; }
        public string ParameterVoucherXmlForActionWastage { get; set; }
        public string ParameterVoucherXmlForActionShrinkage { get; set; }
        public string ParameterVoucherXmlForActionBlockedForFreeBie { get; set; }

        public string ParameterVoucherXmlForActionManualConsumption { get; set; }
        public int InventoryRecipeMasterID
        {
            get;
            set;
        }
        public string RecipeTitle { get; set; }
        public string RecipeDescription { get; set; }
        public int PrimaryItemOutputID
        {
            get;
            set;
        }
        public int InventoryVariationMasterID
        {
            get;
            set;
        }
        public string RecipeVariationTitle { get; set; }
        public int IngridentItemnumber
        {
            get;
            set;
        }
        public decimal IngridentQty
        {
            get;
            set;
        }
        public string IngridentUomCode { get; set; }
        public decimal CurrentStockQty
        {
            get;
            set;
        }
        public string OrderingUOM { get; set; }
        public decimal OrderingunitConversionFactor
        {
            get;
            set;
        }
        public double BaseUomPrice
        {
            get;
            set;
        }
        public double ConsumptionPrice
        {
            get;
            set;
        }
        public byte ActionStatus
        {
            get;
            set;
        }
        //Batch
        public int BatchMasterID
        {
            get;
            set;
        }
        public string BatchNumber
        {
            get;
            set;
        }
        public string ExpiryDate
        {
            get;
            set;
        }
        public decimal BatchQuantity
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public byte SerialAndBatchManagedBy
        {
            get;
            set;
        }

    }
}
