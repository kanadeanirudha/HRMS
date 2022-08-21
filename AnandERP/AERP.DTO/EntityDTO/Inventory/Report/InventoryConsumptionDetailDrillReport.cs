using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryConsumptionDetailDrillReport : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string GroupDescription
        {
            get;
            set;
        }
        public string MerchandiseDepartmentName
        {
            get;
            set;
        }
        public string MerchandiseDepartmentCode
        {
            get;
            set;
        }
        public string MerchandiseCategoryName
        {
            get;
            set;
        }
        public string MerchandiseCategoryCode
        {
            get;
            set;
        }
        public string MerchandiseSubCategoryName
        {
            get;
            set;
        }
       
        public int ItemNumber
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public String Granularity
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
        public Int32 GeneralUnitsID
        {
            get;
            set;
        }


        public String Date
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }
        public object Granuality { get; set; }
        public String GeneralUnitsName
        {
            get;
            set;
        }
        public String GranularityName
        {
            get;
            set;
        }
      
        public string MarchandiseGroupCode { get; set; }
        public string MerchantiseDepartmentName { get; set; }
        public string MerchantiseDepartmentCode { get; set; }
        public string MerchantiseCategoryName { get; set; }
        public string MerchantiseCategoryCode { get; set; }
        public string MarchandiseSubCatgoryName { get; set; }
        public string MarchandiseSubCatgoryCode { get; set; }
        public string MarchandiseBaseCatgoryName { get; set; }
        public string MarchandiseBaseCatgoryCode { get; set; }
        public decimal ConsumptionQuantity { get; set; }
        public decimal ConsumptionBaseQuantity { get; set; }
        public decimal ConsumptionAmount { get; set; }
        public decimal SaleQuantity { get; set; }
        public decimal SaleAmount { get; set; }
        public decimal WastageQuantity { get; set; }
        public decimal WastageBaseQuantity { get; set; }
        public decimal WastageAmount { get; set; }
        
        public string TransactionDateTime { get; set; }
        public string UnitName { get; set; }
        public Int32 ProcessUnitID { get; set; }
        public string SelectedGeneralUnitsID { get; set; }
        public string ConsumptionUOM { get; set; }
        public string BaseUOM { get; set; }
        public string CentreName { get; set; }
        public string CentreCode { get; set; }
    }

}
