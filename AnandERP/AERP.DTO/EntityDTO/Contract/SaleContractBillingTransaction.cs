using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractBillingTransaction : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public Int64 SaleContractMasterID
        {
            get; set;
        }
        public string ContractNumber
        {
            get; set;
        }
        public byte BillingType
        {
            get; set;
        }
        public Int64 SaleContractBillingSpanID
        {
            get;
            set;
        }
        public string SaleContractBillingSpanName
        {
            get;
            set;
        }
        public string CustomerMasterName
        {
            get; set;
        }
        public Int32 CustomerMasterID
        {
            get; set;
        }
        public string CustomerBranchMasterName
        {
            get; set;
        }
        public bool IsTaxExempted
        {
            get; set;
        }
        public byte ReasonForExemption
        {
            get; set;
        }
        public byte FixedBillingType
        {
            get; set;
        }
        public string TaxExemptionRemark { get; set; }
        public bool IsDisplayPurchaseDetails { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PurchaseOrderDate { get; set; }
        public string DateTimeOfSupply { get; set; }
        public string StartDate
        {
            get; set;
        }
        public string EndDate
        {
            get; set;
        }
        public Int64 SaleContractBillingTransactionDetailsID
        {
            get; set;
        }
        public bool IsBillGenerated
        {
            get; set;
        }
        public decimal TotalBillAmount
        {
            get; set;
        }
        public decimal RoundOffAmount
        {
            get; set;
        }
        public bool IsMaterialDeliveryCreated
        {
            get; set;
        }
        public bool IsMaterialDeliveryReceived
        {
            get; set;
        }
        public Int64 SaleContractRequirementDetailsID
        {
            get; set;
        }
        public Int32 ItemNumber
        {
            get; set;
        }
        public string ItemDescription
        {
            get; set;
        }
        public string ItemAssignedPeriod
        {
            get; set;
        }
        public string HSNCode
        {
            get; set;
        }
        public string UOMCode
        {
            get; set;
        }
        public decimal Quantity
        {
            get; set;
        }
        public decimal FixedQuantity
        {
            get; set;
        }
        public decimal OriginalQuantity
        {
            get; set;
        }
        public decimal Rate
        {
            get; set;
        }
        public decimal ShortExtraRate
        {
            get; set;
        }
        public Int16 GeneralTaxGroupMasterID
        {
            get; set;
        }
        public string GeneralTaxGroupMasterName
        {
            get; set;
        }
        public decimal TaxAmount
        {
            get; set;
        }
        public decimal TaxableAmount
        {
            get; set;
        }
        public decimal NetAmount
        {
            get; set;
        }
        public decimal TaxRate
        {
            get; set;
        }
        public bool IsOtherState
        {
            get; set;
        }
        public string TaxRateList
        {
            get; set;
        }
        public string TaxList
        {
            get; set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string DeliveryMemoNumber
        {
            get; set;
        }
        public Int32 DeliveryMemoID
        {
            get; set;
        }
        public Int32 LocationID
        {
            get; set;
        }
        public string LocationName
        {
            get; set;
        }
        public string CustomerInvoiceNumber
        {
            get; set;
        }
        public Int32 SalesInvoiceMasterID
        {
            get; set;
        }
        public Int32 VariationMasterID
        {
            get; set;
        }
        public string VariationMasterName
        {
            get; set;
        }
        public byte SaleContractRequiredTypeID
        {
            get; set;
        }
        public bool IsInclusiveServiceCharges
        {
            get; set;
        }
        public bool IsServiceChargesAppliedToAddAmount
        {
            get; set;
        }
        public bool IsServiceChargesAppliedToServiceItem
        {
            get; set;
        }
        public bool IsServiceChargesAppliedToOverTime
        {
            get; set;
        }
        public byte ServiceChargesCalculateOn
        {
            get; set;
        }
        public byte ServiceChargesDependOn
        {
            get; set;
        }
        public decimal GrossAmountRate
        {
            get; set;
        }
        public decimal FixAmountPerManPowerRate
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

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string XMLStringBillingTransaction { get; set; }
        public string XMLstringForVouchar { get; set; }
        //ForPDF
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
        public string InvoiceTransactionDate
        { get; set; }
        public string HeadType
        { get; set; }
        public bool IsAllowance
        { get; set; }
        public byte TotalDays
        { get; set; }
        public decimal BasicAmount
        { get; set; }
        public decimal TotalAmount
        { get; set; }
        public decimal TotalSalary
        { get; set; }
        public decimal GrossAmount
        { get; set; }
        public int SaleContractManPowerItemID
        { get; set; }
        public string SaleContractManPowerItemName
        { get; set; }
        public decimal AllowanceDeductionAmount
        { get; set; }
        public string SaleContractManPowerItemList
        { get; set; }
        public int CustomerBranchMasterID
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
        public Int16 StateCode { get; set; }
        public Int16 BranchStateCode { get; set; }
        public string CustomerPinCode
        { get; set; }
        public string CustomerBranchPinCode
        { get; set; }

        public decimal TotalDaysSum
        { get; set; }
        public byte ComplianceType { get; set; }
        public decimal TotalOverTime { get; set; }
        public decimal OverTimeRate { get; set; }
        public decimal OverTimeAmount { get; set; }
        public decimal AdditionalAmount { get; set; }
        public byte SummaryFormat { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsMachine { get; set; }
    }
}
