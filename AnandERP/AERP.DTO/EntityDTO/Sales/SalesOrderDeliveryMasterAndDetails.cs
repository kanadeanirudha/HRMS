using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class SalesOrderDeliveryMasterAndDetails : BaseDTO
    {


        public Int32 AdminRoleID
        {
            get;
            set;
        }
        public Int32 SalesOrderDeliveryMasterID
        {
            get;
            set;
        }
        public Int32 SalesOrderDeliveryDetailsID
        {
            get;
            set;
        }
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
        public Int32 CustomerMasterID
        {
            get;
            set;
        }
        public string DeliveryNumber
        {
            get;
            set;
        }
        public string SalesOrderNumber
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }
        public string BranchName
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string DeliveryTransDate
        {
            get;
            set;
        }
        public string SalesOrderDate
        {
            get;
            set;
        }
        public bool IsLocked
        {
            get;
            set;
        }
        public int ShipToCityID
        {
            get;
            set;
        }
        public Int16 ShipToStateID
        {
            get;
            set;
        }
        public string ShipToAddress
        {
            get;
            set;
        }
        public string ShipperName
        {
            get;
            set;
        }
        public string VehicalNumber
        {
            get;
            set;
        }
        public int GeneralShipperID
        {
            get;
            set;

        }
        public decimal FrieghtCharges
        {
            get;
            set;
        }
        public bool IsInvoiced
        {
            get;
            set;
        }

        public int SaleMasterID
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public int CustomerBranchMasterID
        {
            get;
            set;
        }
        public int ContactPersonID
        {
            get;
            set;
        }
        public int GeneralItemCodeID
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public string SalesUomCode
        {
            get;
            set;
        }
        public decimal BaseUOMQuantity
        {
            get;
            set;
        }
        public string BaseUOMCode
        {
            get;
            set;
        }
        public decimal DispatchedQuantity
        {
            get;
            set;
        }
        public decimal SalesOrderQuantity
        {
            get;
            set;
        }
        
        public decimal TaxAmount
        {
            get;
            set;
        }
        public int GenTaxGroupMasterID
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
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
        public string UOM
        {
            get;
            set;
        }
        public decimal ReceivedQuantity
        {
            get;
            set;
        }
        public decimal RemainingQuantity
        {
            get;
            set;
        }
        public decimal TaxRate
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public decimal TaxableAmount
        {
            get;
            set;
        }
        public decimal NetAmount
        {
            get;
            set;
        }
        public bool IsComplete
        {
            get;
            set;
        }
        public int ShipToCountryID
        {
            get;
            set;
        }
        public byte SerialAndBatchManagedBy
        {
            get;
            set;
        }
        public string BatchNumber
        {
            get;set;
        }
        public decimal ConversionFactor
        {
            get; set;
        }
        public string XmlString
        {
            get; set;
        }
        public string HSNCode { get; set; }
        public string ExpiryDate { get; set;}
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
        public bool IsOther
        { get; set; }
        public string TaxGroupName { get; set; }
        public string TaxList { get; set; }
        public string TaxRateList { get; set; }
        public string AmountInWords { get; set; }
        public string BranchGSTNumber { get; set; }
        public string CustomerGSTNumber { get; set; }
        public byte CustomerType { get; set; }

        public string ContactPersonName { get; set; }
        public byte WithDMRate { get; set; }
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
        public decimal BaseUoMReceivedQuantity { get; set; }
        public decimal CurrentStockQty { get; set; }
        public string TransportationMode { get; set; }
        public string PurchaseOrderNumberClient { get; set; }
        public decimal PurchaseUOMConversion { get; set; }
        public decimal PurchasePrice { get; set; }

        public decimal TotalPurchaseAmount
        {
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
        public bool IsCancelled
        {
            get;set;
        }
        public string MonthName { get; set; }
        public string MonthYear { get; set; }
    }
}
