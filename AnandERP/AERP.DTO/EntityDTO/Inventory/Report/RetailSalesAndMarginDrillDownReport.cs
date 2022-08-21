using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class RetailSalesAndMarginDrillDownReport : BaseDTO
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
        public string GeneralUnitsName { get; set; }
        public string CentreName { get; set; }
        public string GranularityName { get; set; }
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

        public decimal PurchasePrice { get; set; }
        public decimal Margin { get; set; }
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
