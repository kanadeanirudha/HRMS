using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class PurchaseReturn : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
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
        public string TransactionDate
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
        public decimal PurchaseReturnAmount
        {
            get;
            set;
        }

        public int VendorId
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

        public int PurchaseRetrunTransactionID
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
            get;set;
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
        public bool IsOtherState
        {
            get;
            set;
        }

        public string UOMCode
        {
            get;
            set;
        }
        public string UnitCode
        {
            get;
            set;
        }
        public int GeneralItemCodeID
        {
            get;
            set;
        }
        public string PurchaseOrderNumber
        {
            get;
            set;
        }
        public string PurchaseGrnNumber
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string vendor
        {
            get;
            set;
        }
        public int VendorNumber
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
        public int PurchaseOrderMasterID
        {
            get;
            set;
        }
        public int StorageLocationID
        {
            get;
            set;
        }
        public string OrderUomCode
        {
            get;
            set;
        }
        public int PurchaseGRNMasterID
        {
            get;
            set;
        }
        public string PurchaseReturnNumber
        {
            get;
            set;
        }
        public decimal BaseUOMQuantity
        {
            get;
            set;
        }
        public decimal ReceivedQuantity
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
        public bool IsDeleted
        {
            get;
            set;
        }
        public double UomPurchasePrice
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public byte SerialAndBatchManagedBy
        {
            get;
            set;
        }
        public decimal CreditAmount
        {
            get;
            set;
        }


    }
}
