using System;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryConsumptionDetailDrillReportSearchRequest : BaseDTO
    {

        public String Granularity
        { get; 
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
        public String GroupDesciption
        {
            get;
            set;
        }
        public String DepartmentName
        {
            get;
            set;
        }
        public String CategoryName
        {
            get;
            set;
        }
        public String SubCategoryName
        {
            get;
            set;
        }
        public String BaseCategoryName
        {
            get;
            set;
        }
        public String ItemDescription
        {
            get;
            set;
        }
        public string MarchandiseGroupCode { get; set; }
        public string MerchantiseDepartmentName { get; set; }
        public string MerchandiseDepartmentName { get; set; }
        public string MerchantiseDepartmentCode { get; set; }
        public string MerchandiseDepartmentCode { get; set; }
        public string MerchantiseCategoryName { get; set; }
        public string MerchandiseCategoryName { get; set; }
        public string MerchantiseCategoryCode { get; set; }
        public string MerchandiseCategoryCode { get; set; }
        public string MarchandiseSubCatgoryName { get; set; }
        public string MarchandiseSubCatgoryCode { get; set; }
        public string MarchandiseBaseCatgoryName { get; set; }
        public string MarchandiseBaseCatgoryCode { get; set; }
        public string CentreCode { get; set; }
        public string CentreName { get; set; }
    }
}


       
       
    
