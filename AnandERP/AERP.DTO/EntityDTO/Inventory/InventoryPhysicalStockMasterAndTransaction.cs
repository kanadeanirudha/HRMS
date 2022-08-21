using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryPhysicalStockMasterAndTransaction : BaseDTO
    {
        //Properties of InventoryPhysicalStockMaster

        public Int32 id
        {
            get;
            set;
        }
        public Int32 InventoryPhysicalStockMasterId
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string ParameterXml
        {
            get;
            set;
        }
        public Int32 GeneralItemMasterID
        {
            get;
            set;
        }
        public Int32 Balancesheet
        {
            get;
            set;
        }
        public Int32 InventoryLocationMasterID
        {
            get;
            set;
        }
        public decimal Count
        {
            get;
            set;
        }
        public decimal TotalAmount
        {
            get;
            set;
        }

        public decimal VariationAmount
        {
            get;
            set;
        }
        // Properties of InventoryPhysicalStockTransaction
        public Int32 InventoryPhysicalStockTransactionID
        {
            get;
            set;
        }
        public Int32 ItemNumber
        {
            get;
            set;
        }
        public Int32 ItemBarCodeId
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }

        public bool ApprovedStatus
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }
        public string Unit
        {
            get;
            set;
        }
        public int ApprovedBy
        {
            get;
            set;
        }
        public DateTime ApprovedDate
        {
            get;
            set;
        }
        public string CurrentQty
        {
            get;
            set;
        }
        public double ApprovedDumpQty
        {
            get;
            set;
        }
         public double PhysicalQty
        {
            get;
            set;
        }

        public double ApprovedShrinkQty
        {
            get;
            set;
        }
        public string DumpQuantity
        {
            get;
            set;
        }
        public string ShrinkQuantity
        {
            get;
            set;
        }
        //Common Properties
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
    }
}
