using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SaleSummaryDrillReport : BaseDTO
    {
        public Int16 ID
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
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public String Date
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

        public decimal TotalSale
        {
            get;
            set;

        }
        public decimal SalesReturnAmount
        {
            get;
            set;

        }
        public string BillFor { get; set; }
        public string BillNumber { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public string NextReport { get; set; }
    }
}
