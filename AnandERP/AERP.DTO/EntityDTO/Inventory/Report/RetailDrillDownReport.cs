using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class RetailDrillDownReport : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public Int32 GeneralUnitsID
        {
            get;
            set;
        }
        public Int32 GeneralUnitsId
        {
            get;
            set;
        }
        public int SRNo
        {
            get;
            set;
        }
        public String DateFrom
        {
            get;
            set;
        }
        public String DateTo
        {
            get;
            set;
        }
        public string CentreCode { get; set; }
        public string CentreName { get; set; }
        public String Granularity
        {
            get;
            set;
        }

        public string GroupDescription { get; set; }
        public string MarchandiseGroupCode { get; set; }
        public string MerchantiseDepartmentName { get; set; }
        public string MerchantiseDepartmentCode { get; set; }
        public string MerchantiseCategoryName { get; set; }
        public string MerchantiseCategoryCode { get; set; }
        public string MarchandiseSubCatgoryName { get; set; }
        public string MarchandiseSubCatgoryCode { get; set; }
        public string MarchandiseBaseCatgoryName { get; set; }
        public string MarchandiseBaseCatgoryCode { get; set; }
        // public string MarchandiseBaseCatgoryCode { get; set; }
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public string TransactionDateTime { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string UOMCode { get; set; }

        public decimal GRNQuantity { get; set; }
        public decimal SalesQuantity { get; set; }
        public decimal GRNSalesQuantity { get; set; }
        public decimal CurrentStock { get; set; }

        public int GeneralUnitKey { get; set; }
        public int GeneralItemMasterKey { get; set; }
        public string BaseUomCode { get; set; }
        public string ItemDisplayFromDate { get; set; }
        public string TransactionFromDate { get; set; }
        public decimal TotalSalesQuantity { get; set; }
        public string ItemCategoryCode { get; set; }
        public string UnitName { get; set; }
        public string UnitRelatedWith { get; set; }
        public decimal currentstockqty { get; set; }
        public decimal AverageDailySale { get; set; }
        public decimal DaysOfCover { get; set; }

        public string PaymentMode { get; set; }
        public string ModeOfPayment { get; set; }
        public Int32 GeneralUnitsID1
        {
            get;
            set;
        }

        public String Date
        {
            get;
            set;
        }
        public string BillNo
        {
            get;
            set;
        }
        public string Store
        {
            get;
            set;
        }
        public decimal Amount
        {
            get;
            set;
        }
        public string CounterName
        {
            get;
            set;
        }
        public decimal card
        {
            get;
            set;

        }
        public decimal cash
        {
            get;
            set;

        }
        public decimal TotalCard
        {
            get;
            set;

        }
        public decimal TotalAmount
        {
            get;
            set;

        }
        public decimal TotalCash
        {
            get;
            set;

        }
        public Int32 VendorNo { get; set; }
        public string VendorDescription { get; set; }
        public Int16 NoOfItemsOrderedInPO { get; set; }
        public Int16 NoOfItemsDelivered { get; set; }
        public Decimal ServiceLevel { get; set; }
        public Decimal Margin { get; set; }
        public string GeneralUnitsList { get; set; }
        public string GranularityList { get; set; }


        public decimal CashToday
        {
            get;
            set;

        }
        public decimal CashTillLast
        {
            get;
            set;

        }
        public decimal TotalCashSale
        {
            get;
            set;

        }
        public decimal CardToday
        {
            get;
            set;

        }
        public decimal CardTillLast
        {
            get;
            set;

        }
        public decimal TotalCardSale
        {
            get;
            set;

        }
        public decimal TotalSale
        {
            get;
            set;

        }
        public string DiscountInPercent
        {
            get;
            set;

        }

        public string type
        {
            get;
            set;
        }
        public decimal Discount
        {
            get;
            set;

        }
        public decimal NetAmount
        {
            get;
            set;

        }
        public string PromotionName
        {
            get;
            set;

        }
        //For Take Away Reports
        public decimal TakeAwaySaleAmount
        {
            get;
            set;

        }
        public Int32 TakeAwayNumberOfOrder
        {
            get;
            set;

        }
        public decimal FineDiningSaleAmount
        {
            get;
            set;

        }
        public Int32 FineDiningNumberOfOrder
        {
            get;
            set;

        }

        public Int32 TotalNumberOfSale
        {
            get;
            set;

        }

        public string BillNumber { get; set; }
        public decimal BillAmount { get; set; }
        public decimal TotalBillAmount { get; set; }
        public string GlobalInvoiceNumber { get; set; }
        public string LocalInvoiceNumber { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Item { get; set; }
        public decimal ConsumptionQuantity { get; set; }
        public decimal ConsumptionAmount { get; set; }
        public decimal WastageQuantity { get; set; }
        public decimal WastageAmount { get; set; }
        //For Consumption
        public string GranularityName { get; set; }
        public string GeneralUnitsName { get; set; }
        
        public decimal SaleReturnAmount
        {
            get;
            set;
        }
        public decimal SaleReturnQuantity
        {
            get;
            set;
        }

    }
}
