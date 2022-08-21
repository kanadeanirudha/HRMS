using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class PurchaseReturnViewModel : IPurchaseReturnViewModel
    {

        public PurchaseReturnViewModel()
        {
            PurchaseReturnDTO = new PurchaseReturn();

        }

        public PurchaseReturn PurchaseReturnDTO
        {
            get;
            set;
        }
        public List<PurchaseReturn> PurchaseReturnList { get; set; }
        public Int32 ID
        {
            get
            {
                return (PurchaseReturnDTO != null && PurchaseReturnDTO.ID > 0) ? PurchaseReturnDTO.ID : new Int32();
            }
            set
            {
                PurchaseReturnDTO.ID = value;
            }
        }
        public Int32 BatchID
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.BatchID : new Int32();
            }
            set
            {
                PurchaseReturnDTO.BatchID = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.CentreCode : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.CentreCode = value;
            }
        }

       [Required(ErrorMessage = "Please select Vendor.")]
        public string vendor
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.vendor : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.vendor = value;
            }
        }
         [Required(ErrorMessage = "Please Enter Transaction Date.")]
         public string TransactionDate
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.TransactionDate : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.TransactionDate = value;
            }
        }
         public decimal BatchQuantity
         {
             get
             {
                 return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.BatchQuantity : new decimal();
             }
             set
             {
                 PurchaseReturnDTO.BatchQuantity = value;
             }
         }
         public decimal ReceivedQuantity
         {
             get
             {
                 return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.ReceivedQuantity : new decimal();
             }
             set
             {
                 PurchaseReturnDTO.ReceivedQuantity = value;
             }
         }
        public decimal TotalTaxAmount
        {
            get
            {
                return (PurchaseReturnDTO != null && PurchaseReturnDTO.TotalTaxAmount > 0) ? PurchaseReturnDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                PurchaseReturnDTO.TotalTaxAmount = value;
            }
        }

        public decimal RoundUpAmount
        {
            get
            {
                return (PurchaseReturnDTO != null && PurchaseReturnDTO.RoundUpAmount > 0) ? PurchaseReturnDTO.RoundUpAmount : new decimal();
            }
            set
            {
                PurchaseReturnDTO.RoundUpAmount = value;
            }
        }
        public decimal PurchaseReturnAmount
        {
            get
            {
                return (PurchaseReturnDTO != null && PurchaseReturnDTO.PurchaseReturnAmount > 0) ? PurchaseReturnDTO.PurchaseReturnAmount : new decimal();
            }
            set
            {
                PurchaseReturnDTO.PurchaseReturnAmount = value;
            }
        }
        

        public int VendorId
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.VendorId : new Int16();
            }
            set
            {
                PurchaseReturnDTO.VendorId = value;
            }
        }

        public Int16 BalanceSheetID
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.BalanceSheetID : new Int16();
            }
            set
            {
                PurchaseReturnDTO.BalanceSheetID = value;
            }
        }
        public Int16 LocationID
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.LocationID : new Int16();
            }
            set
            {
                PurchaseReturnDTO.LocationID = value;
            }
        }

        public Int32 PurchaseRetrunTransactionID
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.PurchaseRetrunTransactionID : new Int32();
            }
            set
            {
                PurchaseReturnDTO.PurchaseRetrunTransactionID = value;
            }
        }
        public string ItemNumber
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.ItemNumber : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.ItemNumber = value;
            }
        }
        //[Required(ErrorMessage = "Please Enter Examination Start Date.")]
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.ItemDescription : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.ItemDescription = value;
            }
        }
        //[Required(ErrorMessage = "Please Enter Examination Start Date.")]
        //[Display(Name = "Unit")]
        public string OrderUomCode
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.OrderUomCode : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.OrderUomCode = value;
            }
        }
        [Display(Name = "Unit")]
        public string UnitCode
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.UnitCode : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.UnitCode = value;
            }
        }
        public decimal TaxAmount
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.TaxAmount : new decimal();
            }
            set
            {
                PurchaseReturnDTO.TaxAmount = value;
            }
        }

       
        public Int32 TaxInPercentage
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.TaxInPercentage : new Int32();
            }
            set
            {
                PurchaseReturnDTO.TaxInPercentage = value;
            }
        }
        public Int32 GenTaxGroupMasterId
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.GenTaxGroupMasterId : new Int32();
            }
            set
            {
                PurchaseReturnDTO.GenTaxGroupMasterId = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Quantity.")]
        public decimal Quantity
        {
            get
            {
                return (PurchaseReturnDTO != null && PurchaseReturnDTO.Quantity > 0) ? PurchaseReturnDTO.Quantity : new decimal();
            }
            set
            {
                PurchaseReturnDTO.Quantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (PurchaseReturnDTO != null && PurchaseReturnDTO.Rate > 0) ? PurchaseReturnDTO.Rate : new decimal();
            }
            set
            {
                PurchaseReturnDTO.Rate = value;
            }
        }
        public string BatchNumber
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.BatchNumber : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.BatchNumber = value;
            }
        }
        public string ExpiryDate
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.ExpiryDate : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.ExpiryDate = value;
            }
        }
        public string UOMCode
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.UOMCode : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.UOMCode = value;
            }
        }
        public Int32 GeneralItemCodeID
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.GeneralItemCodeID : new Int32();
            }
            set
            {
                PurchaseReturnDTO.GeneralItemCodeID = value;
            }
        }
        [Display(Name = "PO Number")]
        public string PurchaseOrderNumber
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.PurchaseOrderNumber : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.PurchaseOrderNumber = value;
            }
        }
        [Display(Name = "GRN Number")]
        public string PurchaseGrnNumber
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.PurchaseGrnNumber : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.PurchaseGrnNumber = value;
            }
        }
        public string PurchaseReturnNumber
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.PurchaseReturnNumber : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.PurchaseReturnNumber = value;
            }
        }
        public Int32 VendorNumber
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.VendorNumber : new Int32();
            }
            set
            {
                PurchaseReturnDTO.VendorNumber = value;
            }
        }
        public string BaseUOMCode
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.BaseUOMCode : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.BaseUOMCode = value;
            }
        }
        public decimal BaseUOMQuantity
        {
            get
            {
                return (PurchaseReturnDTO != null && PurchaseReturnDTO.BaseUOMQuantity > 0) ? PurchaseReturnDTO.BaseUOMQuantity : new decimal();
            }
            set
            {
                PurchaseReturnDTO.BaseUOMQuantity = value;
            }
        }
        public int PurchaseGRNMasterID
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.PurchaseGRNMasterID : new Int16();
            }
            set
            {
                PurchaseReturnDTO.PurchaseGRNMasterID = value;
            }
        }
        public int PurchaseOrderMasterID
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.PurchaseOrderMasterID : new Int16();
            }
            set
            {
                PurchaseReturnDTO.PurchaseOrderMasterID = value;
            }
        }

        public string ParameterXml
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.ParameterXml : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.ParameterXml = value;
            }
        }
        public string ParameterVoucherXml
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.ParameterVoucherXml : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.ParameterVoucherXml = value;
            }
        }
        public string TaxList
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.TaxList : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.TaxList = value;
            }
        }
        public string TaxRateList
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.TaxRateList : string.Empty;
            }
            set
            {
                PurchaseReturnDTO.TaxRateList = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.IsDeleted : false;
            }
            set
            {
                PurchaseReturnDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (PurchaseReturnDTO != null && PurchaseReturnDTO.CreatedBy > 0) ? PurchaseReturnDTO.CreatedBy : new int();
            }
            set
            {
                PurchaseReturnDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseReturnDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseReturnDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseReturnDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.DeletedBy : new int();
            }
            set
            {
                PurchaseReturnDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                PurchaseReturnDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (PurchaseReturnDTO != null) ? PurchaseReturnDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                PurchaseReturnDTO.SerialAndBatchManagedBy = value;
            }
        }






    }
}

