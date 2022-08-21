using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryReport : BaseDTO
    {
        public bool IsPosted
        {
            get;
            set;
        }
        public String ItemNumber
        {
            get;
            set;
        }
        public String ItemName
        {
            get;
            set;
        }
        public decimal CostperOrderUnit
        {
            get;
            set;
        }
        public string HSNCode
        {
            get;set;
        }
        public String Site
        {
            get;
            set;
        }
        public String OrderUoM
        {
            get;
            set;
        }
        public String BaseUoM
        {
            get;
            set;
        }
        public String SalesUoM
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string UptoDate { get; set; }
        public string FromDate { get; set; }

        public Int32 GeneralItemMasterID
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
        public string ItemCategoryCode
        {
            get;
            set;
        }
        public string IsBaseUom
        {
            get;
            set;
        }


        public bool IsOrderingUnit
        {
            get;
            set;
        }

        public string IsSaleUnit
        {
            get;
            set;
        }
        public string GeneralVendorID
        {
            get;
            set;
        }
        public string Vendor
        {
            get;
            set;
        }
        public string Vender
        {
            get;
            set;
        }
        public string TaxGroupName
        {
            get;
            set;
        }
        public string PurchaseGroupCode
        {
            get;
            set;
        }
        public decimal SalesPrice
        {
            get;
            set;
        }
        public double LastPurchasePrice
        {
            get;
            set;
        }
        public double MinimumOrderQuantity
        {
            get;
            set;
        }
        public string PurchaseUomCode
        {
            get;
            set;
        }
        public string PurchaseUoMCode
        {
            get;
            set;
        }
        public string GeneralPurchaseGroupMasterID
        {
            get;
            set;
        }
        public string PurchaseGroup
        {
            get;
            set;
        }
        public String LeadTime
        {
            get;
            set;
        }
        public byte LeadTimeForVendor
        {
            get;
            set;
        }
        public string ShelfExpiryLife
        {
            get;
            set;
        }
        public string RemainingShelfLife
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public string Store
        {
            get;
            set;
        }
        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
        public string OrderingDay
        {
            get;
            set;
        }
        public string Orderingday
        {
            get;
            set;
        }
        public string delivaryDay
        {
            get;
            set;
        }
        public string DeliveryDay
        {
            get;
            set;
        }
        public string ItemDisplayFromDate { get; set; }
        public string itemDisplayUpto { get; set; }
        public byte ReorderPoint { get; set; }
        public byte SafetyStockDriven { get; set; }
        public string ReportFor { get; set; }
        public string ItemReportList { get; set; }
        public string BarCode
        {
            get;
            set;
        }

        public decimal ConversionFactor
        {
            get;
            set;
        }
        public string UomCode
        {
            get;
            set;
        }
        public string LowerLevelUomCode
        {
            get;
            set;
        }
        public string MainMenuItemName
        {
            get;
            set;
        }
        public string ArabicTransalation
        {
            get;
            set;
        }
        public string MenuCategory
        {
            get;
            set;
        }
        public string Definevariants
        {
            get;
            set;
        }
        public string BillingItemName
        {
            get;
            set;
        }
        public decimal MainMenuItemPrice
        {
            get;
            set;
        }
        public string RecipeVariationTitle
        {
            get;
            set;
        }
        public decimal VariationPrice
        {
            get;
            set;
        }

        //For Article Expiry Report
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string GeneralUnitsList { get; set; }
        public string ListAllUnits { get; set; }
        // public string ItemDescription { get; set; }
        public String VendorNumber
        {
            get;
            set;
        }
        public bool StatusFlag { get; set; }
        public string GeneralUnitsName { get; set; }
        public int BalanceDays
        {
            get;
            set;
        }
        public string RemainingDays
        {
            get;
            set;
        }
        public string CentreName { get; set; }
        public string CentreCode { get; set; }
        public string SalesOrderNumber { get; set; }
        public decimal RequiredQuantity { get; set; }
        public decimal DispatchedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public string CustomerMasterName { get; set; }
        public string CustomerBranchMasterName { get; set; }

        public string TransDate { get; set; }
        public decimal BaseQuantity { get; set; }
        public string LocationName { get; set; }
        public byte TransactionTypeId { get; set; }
        public string TransactionNumber { get; set; }
        public string VendorAndCustomer { get; set; }
    }
}
