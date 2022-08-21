using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class TillReport : BaseDTO
    {
        public Int16 ID
        { 
            get; 
            set; 
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public Int16 CounterId
        {
            get;
            set;
        }
        public Decimal TotalBillRetailCard
        {
            get;
            set;
        }
        public Decimal TotalBillRetailCash
        {
            get;
            set;
        }
        public Decimal TotalBillRestaurantCard
        {
            get;
            set;
        }
        public Decimal TotalBillRestaurantCash
        {
            get;
            set;
        }
        public Decimal TotalCardPayment
        {
            get;
            set;
        }
        public Decimal TotalCashPayment
        {
            get;
            set;
        }
        public Decimal TotalReatailPayment
        {
            get;
            set;
        }
        public Decimal TotalRestaurantPayment
        {
            get;
            set;
        }
        public Decimal CashReceived
        {
            get;
            set;
        }
        public Decimal DescripancyInCash
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
    }
}
