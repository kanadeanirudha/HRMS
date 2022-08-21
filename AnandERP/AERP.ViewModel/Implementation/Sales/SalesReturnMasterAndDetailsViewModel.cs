using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SalesReturnMasterAndDetailsViewModel 
    {

        public SalesReturnMasterAndDetailsViewModel()
        {
            SalesReturnMasterAndDetailsDTO = new SalesReturnMasterAndDetails();

        }



        public SalesReturnMasterAndDetails SalesReturnMasterAndDetailsDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null && SalesReturnMasterAndDetailsDTO.ID > 0) ? SalesReturnMasterAndDetailsDTO.ID : new Int16();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ID = value;
            }
        }
        [Display(Name ="Customer Name")]
        public int CustomerMasterID
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null && SalesReturnMasterAndDetailsDTO.CustomerMasterID > 0) ? SalesReturnMasterAndDetailsDTO.CustomerMasterID : new int();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Branch Name")]
        public int CustomerBranchMasterID
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null && SalesReturnMasterAndDetailsDTO.CustomerBranchMasterID > 0) ? SalesReturnMasterAndDetailsDTO.CustomerBranchMasterID : new int();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Transaction Date")]
        public string TransactionDate
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.TransactionDate : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.TransactionDate = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.CustomerName : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.CustomerName = value;
            }
        }
        [Display(Name = "Customer Branch Name")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Customer Type")]
        public byte CustomerType
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.CustomerType : new byte();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.CustomerType = value;
            }
        }
        

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.IsActive : false;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null && SalesReturnMasterAndDetailsDTO.CreatedBy > 0) ? SalesReturnMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.DeletedBy : new int();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        public string ItemNumber
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.ItemNumber : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ItemDescription = value;
            }
        }
        public decimal TaxAmount
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.TaxAmount : new decimal();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.TaxAmount = value;
            }
        }


        public Int32 TaxInPercentage
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.TaxInPercentage : new Int32();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.TaxInPercentage = value;
            }
        }
        public Int32 GenTaxGroupMasterId
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.GenTaxGroupMasterId : new Int32();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.GenTaxGroupMasterId = value;
            }
        }
        [Required(ErrorMessage = "Please Enter Quantity.")]
        public decimal Quantity
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null && SalesReturnMasterAndDetailsDTO.Quantity > 0) ? SalesReturnMasterAndDetailsDTO.Quantity : new decimal();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.Quantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null && SalesReturnMasterAndDetailsDTO.Rate > 0) ? SalesReturnMasterAndDetailsDTO.Rate : new decimal();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.Rate = value;
            }
        }
        [Display(Name ="Batch")]
        public string BatchNumber
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.BatchNumber : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.BatchNumber = value;
            }
        }
        public string ExpiryDate
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.ExpiryDate : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ExpiryDate = value;
            }
        }
        [Display(Name ="UOM")]
        public string UOMCode
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.UOMCode : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.UOMCode = value;
            }
        }
        public string BaseUOMCode
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.BaseUOMCode : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.BaseUOMCode = value;
            }
        }
        public decimal BaseUOMQuantity
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null && SalesReturnMasterAndDetailsDTO.BaseUOMQuantity > 0) ? SalesReturnMasterAndDetailsDTO.BaseUOMQuantity : new decimal();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.BaseUOMQuantity = value;
            }
        }
        public string ParameterXml
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.ParameterXml : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ParameterXml = value;
            }
        }
        public string ParameterVoucherXml
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.ParameterVoucherXml : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ParameterVoucherXml = value;
            }
        }
        public string TaxList
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.TaxList : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.TaxList = value;
            }
        }
        public string TaxRateList
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.TaxRateList : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.TaxRateList = value;
            }
        }
        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.SerialAndBatchManagedBy = value;
            }
        }

        [Display (Name ="Invoice No.")]
        public string SalesInvoiceNumber
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.SalesInvoiceNumber : string.Empty;
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.SalesInvoiceNumber = value;
            }
        }
        public Int32 SalesInvoiceMasterID
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null) ? SalesReturnMasterAndDetailsDTO.SalesInvoiceMasterID : new Int32();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.SalesInvoiceMasterID = value;
            }
        }
        public decimal ReceivedQuantity
        {
            get
            {
                return (SalesReturnMasterAndDetailsDTO != null && SalesReturnMasterAndDetailsDTO.ReceivedQuantity > 0) ? SalesReturnMasterAndDetailsDTO.ReceivedQuantity : new decimal();
            }
            set
            {
                SalesReturnMasterAndDetailsDTO.ReceivedQuantity = value;
            }
        }
        

    }
}

