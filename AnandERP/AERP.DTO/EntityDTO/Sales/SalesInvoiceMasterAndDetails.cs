using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class SalesInvoiceMasterAndDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string TransactionDate
        {
            get; set;
        }
        public string CustomerInvoiceNumber
        {
            get; set;
        }
        public string CustomerName
        {
            get; set;
        }
        public int CustomerMasterID
        {
            get;
            set;
        }
        public int CustomerBranchMasterID
        {
            get;
            set;
        }

        public int AdminRoleID
        {
            get;
            set;
        }
        public decimal Amount
        {
            get;
            set;
        }

        public int SalesQuotationMasterID
        {
            get;
            set;
        }
        public int SalesOrderDeliveryMasterID
        {
            get;
            set;
        }
        public string DeliveryNumber
        {
            get; set;
        }

        public int SalesOrderMasterID
        {
            get;
            set;
        }
        public decimal TotalIInvoiceAmount
        {
            get;
            set;
        }
        public decimal Quantity
        {
            get;
            set;
        }
        public decimal NetAmount
        {
            get;
            set;
        }
        public decimal TaxAmount
        {
            get;
            set;
        }
        public decimal FreightAmount
        {
            get;
            set;
        }
        public decimal DiscountAmount
        {
            get;
            set;
        }
        public decimal BillAmount
        {
            get;
            set;
        }
        public int StorageLocationID
        {
            get;
            set;
        }
        public decimal RoundUpAmount
        {
            get;
            set;
        }
        public Int16 BalanceSheetID
        {
            get;
            set;
        }
        public decimal TotalTaxAmount
        {
            get; set;
        }
        public int GenTaxGroupMasterID
        {
            get; set;
        }

        public int GeneralItemCodeID
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public string SaleUomCode
        {
            get;
            set;
        }
        public string DisplayUOMCode
        {
            get; set;
        }
        public decimal InvoiceQuantity
        {
            get;
            set;
        }
        public decimal BaseUOMQuantity
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
        public decimal Rate
        {
            get;
            set;
        }
        public decimal DisplayRate
        {
            get;set;
        }
        public decimal TaxRate
        {
            get;
            set;
        }
        public string TaxGroupName
        { get; set; }
        public string  LocationName
        { get; set; }
        public string BaseUOMCode
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
        public bool IsOtherState
        {
            get;set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string SalesOrderDate
        {
            get; set;
        }
        public string SalesOrderNumber
        {
            get; set;
        }
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
        public string XMLstringForVouchar { get; set; }
        public string XMLstring{ get; set; }
        public string XMLstringForInvoice { get; set; }
        public int GeneralUnitsID { get; set; }

        public string CityName
        { get; set; }
        public string CountryName
        { get; set; }
        public string StateName
        { get; set; }
        public string BranchCityName
        { get; set; }
        public string BranchCountryName
        { get; set; }
        public string BranchStateName
        { get; set; }
        public string LogoPath
        { get; set; }
        public string CentreAddress1
        { get; set; }
        public string CentreAddress2
        { get; set; }
        public string CellPhone
        { get; set; }
        public string CentreName
        { get; set; }
        public string EmailID
        { get; set; }
        public string FaxNumber
        { get; set; }
        public string PhoneNumberOffice
        { get; set; }
        public string Website
        { get; set; }
        public string HSNCode
        { get; set; }
        public bool IsOther
        { get; set; }
        public string CustomerAddress
        { get; set; }
        public string CustomerBranchAddress
        { get; set; }
        public string Currency
        { get; set; }
        public string BranchName
        { get; set; }
        public string CustomerGSTNumber
        { get; set; }
        public string BranchGSTNumber
        { get; set; }
        public string DMNumber
        { get; set; }
        public string TaxRateList
        { get; set; }
        public string TaxList
        { get; set; }
        public string TaxAmountList
        { get; set; }
        public bool Isinvoiced
        { get; set; }
        public byte CustomerType
        { get; set; }
        public byte SerialAndBatchManagedBy
        { get; set; }
        public string NoOfCopies
        { get; set; }
        public Int16 StateCode { get; set; }
        public Int16 BranchStateCode { get; set; }
        public string CustomerPinCode
        { get; set; }
        public string CustomerBranchPinCode
        { get; set; }
        public string CINNumber
        { get; set; }
        public string GSTINNumber
        { get; set; }
        public string PanNumber
        { get; set; }
        public string PFNumber
        { get; set; }
        public string ESICNumber
        { get; set; }
        public string PrintingLineBelowLogo
        { get; set; }
        public string CentreSpecialization
        { get; set; }
        public bool IsServiceItem
        { get; set; }
        public string BillingDispalyName
        { get; set; }
        public byte InvoiceType
        { get; set; }
        public string PurchaseOrderNumberClient { get; set; }
        public bool IsTaxExempted { get; set; }
        public byte ReasonForExemption { get; set; }
        public string TaxExemptionRemark { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PurchaseOrderDate { get; set; }
        public string InvoiceDeductionName { get; set; }
        public decimal InvoiceDeductionAmount { get; set; }
        public bool IsCanceled { get; set; }
        public string BillingSpanEndDate { get; set; }
        public string DateTimeOfSupply { get; set; }
    }
}
