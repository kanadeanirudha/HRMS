using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class SalesReturnMasterAndDetails : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public int CustomerMasterID
        {
            get;set;
        }
        public int CustomerBranchMasterID
        {
            get; set;
        }
        public string TransactionDate
        {
            get;set;
        }
        public string CustomerName
        {
            get; set;
        }
        public string CustomerBranchMasterName
        {
            get; set;
        }
        
        public byte CustomerType
        {
            get; set;
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
        public int BatchID
        {
            get;
            set;
        }
        public decimal BatchQuantity
        {
            get;
            set;
        }
        public string ExpiryDate
        {
            get;
            set;
        }
        public decimal TotalTaxAmount
        {
            get;
            set;
        }
        public decimal RoundUpAmount
        {
            get;
            set;
        }
        public decimal SalesReturnAmount
        {
            get;
            set;
        }
        public Int16 BalanceSheetID
        {
            get;
            set;
        }
        public Int16 LocationID
        {
            get;
            set;
        }
        public string ItemNumber
        {
            get;
            set;
        }
        public decimal TaxAmount
        {
            get;
            set;
        }
        public decimal NetAmount
        {
            get;
            set;
        }
        public string TaxRateList
        {
            get; set;
        }
        public string TaxList
        {
            get; set;
        }

        public int TaxInPercentage
        {
            get;
            set;
        }
        public int GenTaxGroupMasterId
        {
            get;
            set;
        }
        public decimal Quantity
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public string BatchNumber
        {
            get;
            set;
        }
        public string TaxGroupName
        {
            get;
            set;
        }
        public string UOMCode
        {
            get;
            set;
        }
        public int GeneralItemMasterID
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public int StorageLocationID
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
        public string ParameterXml
        {
            get;
            set;
        }
        public string ParameterVoucherXml
        {
            get;
            set;
        }
        public byte SerialAndBatchManagedBy
        {
            get;
            set;
        }
        public string SalesInvoiceNumber
        {
            get;
            set;
        }
        public int SalesInvoiceMasterID
        {
            get;
            set;
        }
        public decimal ReceivedQuantity
        {
            get;
            set;
        }
    }
}
