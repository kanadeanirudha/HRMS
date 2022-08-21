using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class SalesQuotationMasterAndDetails : BaseDTO
    {
        public Int32 SalesEnquiryMasterID
        {
            get;
            set;
        }
        public Int32 SaleEnquiryDetailsID
        {
            get;
            set;
        }
        public Int32 SalesQuotationMasterID
        {
            get;
            set;
        }
        public Int32 SalesQuotationDetailID
        {
            get;
            set;
        }
        public Int32 GeneralTaxGroupMasterID
        {
            get;
            set;
        }

        public Int32 CustomerMasterID
        {
            get;
            set;
        }
        public Int32 CustomerBranchMasterID
        {
            get;
            set;
        }
        public Int32 ContactPersonID
        {
            get;
            set;
        }
        

        public decimal Quantity

        {
            get; set;
        }
        public float Total
        {
            get; set;
        }
        public string UOM
        {
            get; set;
        }
        public int ItemNumber
        {
            get; set;
        }
        public decimal TaxRate
        {
            get; set;
        }
        public string ItemDescription
        {
            get; set;
        }

        public decimal Rate
        {
            get;
            set;
        }
        public string QuotationNumber
        {
            get; set;
        }
        public byte  Status
        {
            get; set;
        }
        public byte CustomerType
        {
            get; set;
        }
        public string EnquiryNumber
        {
            get; set;
        }
        public string CustomerName
        {
            get; set;
        }
        public string CustomerBranchMasterName
        {
            get; set;
        }
        public string ContactPersonName
        {
            get; set;
        }
        public int GeneralUnitsID
        {
            get;set;
        }
        public decimal TotalAmount
        {
            get; set;
        }
        public decimal TotalBillAmount
        {
            get; set;
        }
        public decimal TotalTaxAmount
        {
            get; set;
        }
        public byte CreditPeriod
        {
            get; set;
        }
        public string UnitMasterId
        {
            get; set;
        }
        public string TitleTo
        {
            get;set;
        }
        public string TaxGroupName
        { get; set; }

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
        public string XmlString { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxableAmount { get; set; }


        //Addition to sales  order
        public string PurchaseOrderNumberClient
        {
            get;
            set;
        }
        public string Flag
        {
            get;
            set;
        }
        public decimal Freight
        {
            get;
            set;
        }
        public decimal ShippingHandling
        {
            get;
            set;
        }
        public decimal Discount
        {
            get;
            set;
        }
        public decimal Tradein
        {
            get;
            set;
        }
        public byte SerialAndBatchManagedBy
        {
            get;set;
        }
        public string TaxRateList
        {
            get; set;
        }
        public string TaxList
        {
            get; set;
        }
        public string PurchaseUoMCode
        {
            get; set;
        }
       public decimal PurchasePrice {
            get; set;
        }
        public decimal ConversionFactor
        { get; set; }
        public bool IsTaxExempted { get; set; }
}
}
