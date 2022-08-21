using System;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class RetailDrillDownReportSearchRequest : BaseDTO
    {

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
        public string CentreCode { get; set; }
        public string CentreName { get; set; }
        public string MarchandiseGroupCode { get; set; }
        public string MerchantiseDepartmentCode { get; set; }
        public string MerchantiseCategoryCode { get; set; }
        public string MarchandiseSubCatgoryCode { get; set; }
        public string MarchandiseBaseCatgoryCode { get; set; }
        public string PaymentMode
        {
            get;
            set;
        }
        public string DiscountInPercent
        {
            get;
            set;

        }

        public String Date
        {
            get;
            set;
        }
        public decimal TotalSale
        {
            get;
            set;

        }

        public String BillNumber
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
    }
}





