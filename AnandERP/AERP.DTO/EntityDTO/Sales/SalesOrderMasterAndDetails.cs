using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class SalesOrderMasterAndDetails : BaseDTO
    {
        public Int32 SalesOrderMasterID
        {
            get;
            set;
        }
        public Int32 SalesOrderDetailsID
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
        public byte Status
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
        public string SalesOrderNumber
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
            get; set;
        }
        public decimal TotalAmount
        {
            get; set;
        }
        public decimal TotalPurchaseAmount{
            get; set;
        }
        public decimal TotalPurchaseTaxAmount
        {
            get; set;
        }
        public decimal TotalPurchaseBillAmount
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
        public int UnitMasterId
        {
            get; set;
        }
        public string TitleTo
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
        public string XmlString { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public string TaxGroupName { get; set; }
        
        public decimal TaxableAmount { get; set; }
        public string SalesOrderDate
        { get; set; }


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
        public byte CustomerType
        {
            get;
            set;
        }
        public int IssueFromLocationID
        { get; set; }
        public string LocationName
        { get; set; }
        public string BarCode
        { get; set; }
        public string BaseUOMCode
        { get; set; }
        public string OrderUomCode
        { get; set; }
        public decimal BaseUOMQuantity
        { get; set; }
        public string CustomerAddress
        { get; set; }
        public string CustomerBranchAddress
        { get; set; }
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
        public string CustomerGSTNumber
        { get; set; }
        public string BranchGSTNumber
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
        public bool CreatePR
        { get; set; }
        public string SelectedDepartmentID
        {
            get;set;
        }
        public string GeneralUnitsIDWithcentreCode
        {
            get; set;
        }

        public string MonthName
        {
            get;set;
        }
        public string MonthYear
        {
            get; set;
        }
        public decimal PurchasePrice { get; set; }
        public string PurchaseUoMCode { get; set; }
        public decimal ConversionFactor { get; set; }
    }
}
