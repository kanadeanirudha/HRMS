using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryPhysicalStockMasterAndTransactionViewModel : IInventoryPhysicalStockMasterAndTransactionViewModel
    {

        public InventoryPhysicalStockMasterAndTransactionViewModel()
        {
            InventoryPhysicalStockMasterAndTransactionDTO = new InventoryPhysicalStockMasterAndTransaction();
            LocationList = new List<InventoryLocationMaster_1>();

        }
        public List<InventoryLocationMaster_1> LocationList { get; set; }
        public List<InventoryPhysicalStockMasterAndTransaction> InventoryPhysicalStockMasterAndTransactionList { get; set; }
        public IEnumerable<SelectListItem> LocationListItems
        {
            get
            {
                return new SelectList(LocationList, "ID", "LocationName");
            }
        }

        public InventoryPhysicalStockMasterAndTransaction InventoryPhysicalStockMasterAndTransactionDTO
        {
            get;
            set;
        }
        [AllowHtml]
        public string ParameterXml
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.ParameterXml : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ParameterXml = value;
            }
        }
        public Int32 id
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.id > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.id : new Int32();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.id = value;
            }
        }
        public Int32 InventoryPhysicalStockMasterId
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.InventoryPhysicalStockMasterId > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.InventoryPhysicalStockMasterId : new Int32();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.InventoryPhysicalStockMasterId = value;
            }
        }

        public Int32 Balancesheet
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.Balancesheet > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.Balancesheet : new Int32();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.Balancesheet = value;
            }
        }
        public Int32 InventoryLocationMasterID
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.InventoryLocationMasterID > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.InventoryLocationMasterID : new Int32();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.InventoryLocationMasterID = value;
            }
        }
        public Int32 InventoryPhysicalStockTransactionID
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.InventoryPhysicalStockTransactionID > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.InventoryPhysicalStockTransactionID : new Int32();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.InventoryPhysicalStockTransactionID = value;
            }
        }
        public Int32 ItemNumber
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.ItemNumber > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.ItemNumber : new Int32();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ItemNumber = value;
            }
        }
        public Int32 ItemBarCodeId
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.ItemBarCodeId > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.ItemBarCodeId : new Int32();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ItemBarCodeId = value;
            }
        }
        public Int32 GeneralItemMasterID
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.GeneralItemMasterID > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.GeneralItemMasterID : new Int32();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.GeneralItemMasterID = value;
            }
        }

        public decimal VariationAmount
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.VariationAmount > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.VariationAmount : new decimal();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.VariationAmount = value;
            }
        }
         [Display(Name = "Item Count")]
        public decimal Count
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.Count > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.Count : new decimal();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.Count = value;
            }
        }
            [Display(Name = "Total Amount")]
        public decimal TotalAmount
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.TotalAmount > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.TotalAmount : new decimal();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.TotalAmount = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.Rate > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.Rate : new decimal();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.Rate = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.TransactionDate = value;
            }
        }
        public string BarCode
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.BarCode : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.BarCode = value;
            }
        }
         [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.ItemDescription : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ItemDescription = value;
            }
        }
        public DateTime ApprovedDate
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.ApprovedDate : DateTime.Now;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ApprovedDate = value;
            }
        }
         [Display(Name = "Status")]
        public bool ApprovedStatus
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.ApprovedStatus : false;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ApprovedStatus = value;
            }
        }
        public string Remark
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.Remark : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.Remark = value;
            }
        }
        public int ApprovedBy
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.ApprovedBy > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.ApprovedBy : new int();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ApprovedBy = value;
            }
        }
        public string Unit
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.Unit : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.Unit = value;
            }
        }
        [Display(Name = "Avail. Q")]
        public string CurrentQty
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.CurrentQty : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.CurrentQty = value;
            }
        }
        [Display(Name = "Actual Q")]
        public double PhysicalQty
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.PhysicalQty > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.PhysicalQty : new double();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.PhysicalQty = value;
            }
        }
        public double ApprovedDumpQty
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.ApprovedDumpQty > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.ApprovedDumpQty : new double();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ApprovedDumpQty = value;
            }
        }

        public double ApprovedShrinkQty
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.ApprovedShrinkQty > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.ApprovedShrinkQty : new double();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ApprovedShrinkQty = value;
            }
        }
         [Display(Name = "Dump Q")]
        public string DumpQuantity
        {
            get
            {

                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.DumpQuantity : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.DumpQuantity = value;
            }
        }
        [Display(Name = "Shrink Q")]
        public string ShrinkQuantity
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.ShrinkQuantity : string.Empty;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ShrinkQuantity = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.IsDeleted : false;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null && InventoryPhysicalStockMasterAndTransactionDTO.CreatedBy > 0) ? InventoryPhysicalStockMasterAndTransactionDTO.CreatedBy : new int();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.DeletedBy : new int();
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryPhysicalStockMasterAndTransactionDTO != null) ? InventoryPhysicalStockMasterAndTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryPhysicalStockMasterAndTransactionDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

