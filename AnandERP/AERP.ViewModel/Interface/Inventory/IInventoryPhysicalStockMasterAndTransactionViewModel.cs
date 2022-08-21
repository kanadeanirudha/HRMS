using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryPhysicalStockMasterAndTransactionViewModel
    {
        InventoryPhysicalStockMasterAndTransaction InventoryPhysicalStockMasterAndTransactionDTO
        {
            get;
            set;
        }

         Int32 id
        {
            get;
            set;
        }
         Int32 InventoryPhysicalStockMasterId
        {
            get;
            set;
        }
         Int32 GeneralItemMasterID
         {
             get;
             set;
         }
         string TransactionDate
        {
            get;
            set;
        }
         string BarCode
         {
             get;
             set;
         }
         string ParameterXml
         {
             get;
             set;
         }
         string ItemDescription
         {
             get;
             set;
         }
         Int32 Balancesheet
        {
            get;
            set;
        }
         Int32 InventoryLocationMasterID
        {
            get;
            set;
        }

         decimal Count
         {
             get;
             set;
         }
         decimal TotalAmount
         {
             get;
             set;
         }
         decimal VariationAmount
        {
            get;
            set;
        }
        // Properties of InventoryPhysicalStockTransaction
         Int32 InventoryPhysicalStockTransactionID
        {
            get;
            set;
        }
         Int32 ItemNumber
        {
            get;
            set;
        }
         double PhysicalQty
         {
             get;
             set;
         }
         Int32 ItemBarCodeId
        {
            get;
            set;
        }
         decimal Rate
        {
            get;
            set;
        }

         bool ApprovedStatus
        {
            get;
            set;
        }
         string Remark
        {
            get;
            set;
        }
         int ApprovedBy
        {
            get;
            set;
        }
         DateTime ApprovedDate
        {
            get;
            set;
        }

         double ApprovedDumpQty
        {
            get;
            set;
        }
         double ApprovedShrinkQty
        {
            get;
            set;
        }
       string DumpQuantity
        {
            get;
            set;
        }
       string ShrinkQuantity
        {
            get;
            set;
        }
       string CurrentQty
        {
            get;
            set;
        }
        string Unit
        {
            get;
            set;
        }

        List<InventoryPhysicalStockMasterAndTransaction> InventoryPhysicalStockMasterAndTransactionList { get; set; }
        //Common Properties
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
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
