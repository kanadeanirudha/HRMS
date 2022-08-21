using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class PurchaseReportMaster : BaseDTO
    {
        /// <summary>
        /// Properties for PurchaseMaster table
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        public int VendorNumber
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
        public string ItemName
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public decimal OpeningBalanceQty
        {
            get;
            set;
        }
        public decimal ClosingBalanceQty
        {
            get;
            set;
        }
        public decimal CurrentStockQty
        {
            get;
            set;
        }
        public string TransDate
        {
            get;
            set;
        }
        //public decimal Quantity
        //{
        //    get;
        //    set;
        //}
        public string BaseUOMCode
        {
            get;
            set;
        }

        public string TransactionUOM
        {
            get;
            set;
        }
        public decimal TransactionQuantity
        {
            get;
            set;
        }
        
        public decimal Amount
        {
            get;
            set;
        }
        public string MovementTypeCode
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string MovementType
        {
            get;
            set;
        }
        public string PurchaseOrderNumber
        {
            get;
            set;
        }
        public string BatchNumber
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public int BalancesheetID
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public string LocationNameListXml
        {
            set;
            get;
        }
        public Byte TransactionTypeId
        {
            set;
            get;
        }
        //Oder Status
        public bool IsPosted
        {
            get;
            set;
        }
        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
        //public string ItemNumber
        //{
        //    get;
        //    set;
        //}
        //public string ItemDescription
        //{
        //    get;
        //    set;
        //}
        public string CurrentStock
        {
            get;
            set;
        }
        public string ReOrderPoint
        {
            get;
            set;
        }
        public string SafetyStock
        {
            get;
            set;
        }
        public string LastPOStatus
        {
            get;
            set;
        }
        public string BaseUomCode
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string GeneralUnitsName
        {
            get;
            set;
        }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public string SaleOrderQuantity { get; set; }
        public string PurchaseOrderQuantity { get; set; }
        public string PurchaseRequiredQuantity { get; set; }
    }
}

