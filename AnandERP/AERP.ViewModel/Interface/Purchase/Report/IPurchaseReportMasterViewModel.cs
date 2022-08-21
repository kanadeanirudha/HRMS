using AERP.DTO;
using System;
namespace AERP.ViewModel
{
     interface IPurchaseReportMasterViewModel
    {
        PurchaseReportMaster PurchaseReportMasterDTO { get; set; }
        /// <summary>
        /// Properties for PurchaseReportMaster table
        /// </summary>
         int ID
        {
            get;
            set;
        }
         decimal Quantity
        {
            get;
            set;
        }
         decimal Rate
        {
            get;
            set;
        }
         string ItemName
        {
            get;
            set;
        }
         string BarCode
        {
            get;
            set;
        }
         decimal OpeningBalanceQty
        {
            get;
            set;
        }
         decimal ClosingBalanceQty
        {
            get;
            set;
        }
         decimal CurrentStockQty
        {
            get;
            set;
        }
         string TransDate
        {
            get;
            set;
        }
        // decimal Quantity
        //{
        //    get;
        //    set;
        //}
         string BaseUOMCode
        {
            get;
            set;
        }

         string TransactionUOM
        {
            get;
            set;
        }
         decimal TransactionQuantity
        {
            get;
            set;
        }
         string MovementTypeCode
        {
            get;
            set;
        }
         string LocationName
        {
            get;
            set;
        }
         string ItemDescription
        {
            get;
            set;
        }
         string MovementType
        {
            get;
            set;
        }
         bool IsDeleted
        {
            get;
            set;
        }
         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int? ModifiedBy
        {
            get;
            set;
        }
         DateTime? ModifiedDate
        {
            get;
            set;
        }
        // int? DeletedBy
        //{
        //    get;
        //    set;
        //}
        // DateTime? DeletedDate
        //{
        //    get;
        //    set;
        //}
        
    }
}
