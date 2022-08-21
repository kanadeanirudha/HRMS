using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;


namespace AERP.ViewModel
{
    public class SalesInvoiceMasterAndDetailsViewModel : ISalesInvoiceMasterAndDetailsViewModel
    {
        public SalesInvoiceMasterAndDetailsViewModel()
        {
            SalesInvoiceMasterAndDetailsDTO = new SalesInvoiceMasterAndDetails();
            InventoryPurchaseRequirementListForRequisition = new List<SalesInvoiceMasterAndDetails>();
            SalesinvoiceList = new List<SalesInvoiceMasterAndDetails>();
            PurchaseOrderList = new List<SalesInvoiceMasterAndDetails>();
            TaxSummaryList = new List<GeneralTaxGroupMaster>();
            ListGeneralUnits = new List<GeneralUnits>();
        }
        public List<SalesInvoiceMasterAndDetails> InventoryPurchaseRequirementListForRequisition { get; set; }
        public SalesInvoiceMasterAndDetails SalesInvoiceMasterAndDetailsDTO { get; set; }
        public List<SalesInvoiceMasterAndDetails> SalesinvoiceList { get; set; }
        public List<SalesInvoiceMasterAndDetails> PurchaseOrderList { get; set; }
        public List<GeneralTaxGroupMaster> TaxSummaryList { get; set; }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
        }
        /// <summary>
        /// Properties for SalesInvoiceMasterAndDetails table
        /// </summary>
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
            }
        }


        public int ID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.ID > 0) ? SalesInvoiceMasterAndDetailsDTO.ID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.ID = value;
            }
        }
        public int CustomerMasterID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.CustomerMasterID > 0) ? SalesInvoiceMasterAndDetailsDTO.CustomerMasterID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.CustomerMasterID = value;
            }
        }
        public int CustomerBranchMasterID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.CustomerBranchMasterID > 0) ? SalesInvoiceMasterAndDetailsDTO.CustomerBranchMasterID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.CustomerBranchMasterID = value;
            }
        }

        public int AdminRoleID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.AdminRoleID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.AdminRoleID = value;
            }
        }

        public int SalesQuotationMasterID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.SalesQuotationMasterID > 0) ? SalesInvoiceMasterAndDetailsDTO.SalesQuotationMasterID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.SalesQuotationMasterID = value;
            }
        }


        [Display(Name = "Sales Order Number")]
        public string SalesOrderNumber
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.SalesOrderNumber : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.SalesOrderNumber = value;
            }
        }

        [Display(Name = "Sales Order Date")]
        public string SalesOrderDate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.SalesOrderDate : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.SalesOrderDate = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.CustomerName : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.CustomerName = value;
            }
        }

        public string DeliveryNumber
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.DeliveryNumber : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.DeliveryNumber = value;
            }
        }
        [Display(Name = "Invoice Number")]
        public string CustomerInvoiceNumber
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.CustomerInvoiceNumber : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.CustomerInvoiceNumber = value;
            }
        }
        public bool IsOtherState
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.IsOtherState : false;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.IsOtherState = value;
            }
        }
        public int SalesOrderMasterID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.SalesOrderMasterID > 0) ? SalesInvoiceMasterAndDetailsDTO.SalesOrderMasterID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.SalesOrderMasterID = value;
            }
        }
        public int SalesOrderDeliveryMasterID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.SalesOrderDeliveryMasterID > 0) ? SalesInvoiceMasterAndDetailsDTO.SalesOrderDeliveryMasterID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.SalesOrderDeliveryMasterID = value;
            }
        }
        [Display(Name ="Quantity")]
        public decimal InvoiceQuantity
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.InvoiceQuantity > 0) ? SalesInvoiceMasterAndDetailsDTO.InvoiceQuantity : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.InvoiceQuantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.Rate > 0) ? SalesInvoiceMasterAndDetailsDTO.Rate : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.Rate = value;
            }
        }
        [Display(Name = "Display Rate")]
        public decimal DisplayRate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.DisplayRate : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.DisplayRate = value;
            }
        }
        
        [Display(Name = "Location")]
        public string LocationName
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.LocationName : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.LocationName = value;
            }
        }
        public string XMLstringForVouchar
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.XMLstringForVouchar : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.XMLstringForVouchar = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.XMLstring : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.XMLstring = value;
            }
        }
        public string XMLstringForInvoice
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.XMLstringForInvoice : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.XMLstringForInvoice = value;
            }
        }
        [Display(Name = "Store")]
        public int GeneralUnitsID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.GeneralUnitsID > 0) ? SalesInvoiceMasterAndDetailsDTO.GeneralUnitsID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.GeneralUnitsID = value;
            }
        }

        [Display(Name = "Total Amount")]
        public decimal Amount
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.Amount > 0) ? SalesInvoiceMasterAndDetailsDTO.Amount : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.Amount = value;
            }
        }
        [Display(Name = "Gross Amount")]
        public decimal BillAmount
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.BillAmount > 0) ? SalesInvoiceMasterAndDetailsDTO.BillAmount : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.BillAmount = value;
            }
        }
        [Display(Name = "Storage Location")]
        public int StorageLocationID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.StorageLocationID > 0) ? SalesInvoiceMasterAndDetailsDTO.StorageLocationID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.StorageLocationID = value;
            }
        }

        [Display(Name = "Item Number")]
        public int ItemNumber
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.ItemNumber > 0) ? SalesInvoiceMasterAndDetailsDTO.ItemNumber : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.ItemNumber = value;
            }
        }

        public decimal Freight
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.Freight > 0) ? SalesInvoiceMasterAndDetailsDTO.Freight : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.Freight = value;
            }
        }

        [Display(Name = "Shipping/Handling")]
        public decimal ShippingHandling
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.ShippingHandling > 0) ? SalesInvoiceMasterAndDetailsDTO.ShippingHandling : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.ShippingHandling = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.Discount > 0) ? SalesInvoiceMasterAndDetailsDTO.Discount : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.Discount = value;
            }
        }

        [Display(Name = "Total Tax Amount")]
        public decimal TotalTaxAmount
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.TotalTaxAmount > 0) ? SalesInvoiceMasterAndDetailsDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.TotalTaxAmount = value;
            }
        }


        public int CreatedBy
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.CreatedBy > 0) ? SalesInvoiceMasterAndDetailsDTO.CreatedBy : new short();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.ModifiedBy > 0) ? SalesInvoiceMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.IsDeleted = value;
            }
        }
        public string errorMessage { get; set; }

        /// <summary>
        /// Properties for PurchaseOrderDetails table
        /// </summary>
       

        public string SelectedDepartmentID
        {
            get;
            set;
        }
        public string SelectedDepartmentIDs
        {
            get;
            set;
        }

        public bool IsOther
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.IsOther : false;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.IsOther = value;
            }
        }
        public bool Isinvoiced
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.Isinvoiced : false;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.Isinvoiced = value;
            }
        }
        [Display(Name = "Is Service Item")]
        public bool IsServiceItem
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.IsServiceItem : false;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.IsServiceItem = value;
            }
        }
        
        [Display(Name = "UOM")]
        public string SaleUomCode
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.SaleUomCode : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.SaleUomCode = value;
            }
        }
        [Display(Name = "Display UOM Code")]
        public string DisplayUOMCode
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.DisplayUOMCode : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.DisplayUOMCode = value;
            }
        }
        
        [Display(Name = "Batch")]
        public string BatchNumber
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.BatchNumber : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.BatchNumber = value;
            }
        }
        [Display(Name = "Expiry Date")]
        public string ExpiryDate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.ExpiryDate : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.ExpiryDate = value;
            }
        }
        [Display(Name = "Branch")]
        public string BranchName
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.BranchName : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.BranchName = value;
            }
        }
        public byte CustomerType
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.CustomerType :new byte();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.CustomerType = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.ItemDescription = value;
            }
        }
        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.SerialAndBatchManagedBy = value;
            }
        }
        public int GenTaxGroupMasterID
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.GenTaxGroupMasterID > 0) ? SalesInvoiceMasterAndDetailsDTO.GenTaxGroupMasterID : new int();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.GenTaxGroupMasterID = value;
            }
        }
        [Display(Name = "Tax Rate")]
        public decimal TaxRate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.TaxRate > 0) ? SalesInvoiceMasterAndDetailsDTO.TaxRate : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.TaxRate = value;
            }
        }
        public string TaxList
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.TaxList : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.TaxList = value;
            }
        }
        public string TaxRateList
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.TaxRateList : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.TaxRateList = value;
            }
        }
        public string NoOfCopies
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.NoOfCopies : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.NoOfCopies = value;
            }
        }
        [Display(Name = "Billing Display Name")]
        public string BillingDispalyName
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.BillingDispalyName : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.BillingDispalyName = value;
            }
        }
        public byte InvoiceType
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.InvoiceType : new byte();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.InvoiceType = value;
            }
        }

        public bool IsTaxExempted
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.IsTaxExempted : false;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.IsTaxExempted = value;
            }
        }

        public byte ReasonForExemption
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.ReasonForExemption : new byte();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.ReasonForExemption = value;
            }
        }

        public string TaxExemptionRemark
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.TaxExemptionRemark : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.TaxExemptionRemark = value;
            }
        }
        [Display(Name ="Purchase Order Number")]
        public string PurchaseOrderNumber
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.PurchaseOrderNumber : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.PurchaseOrderNumber = value;
            }
        }
        [Display(Name = "Purchase Order Date")]
        public string PurchaseOrderDate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.PurchaseOrderDate : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.PurchaseOrderDate = value;
            }
        }
        [Display(Name = "Invoice Deduction Name")]
        public string InvoiceDeductionName
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.InvoiceDeductionName : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.InvoiceDeductionName = value;
            }
        }
        [Display(Name = "Invoice Deduction Amount")]
        public decimal InvoiceDeductionAmount
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null && SalesInvoiceMasterAndDetailsDTO.InvoiceDeductionAmount > 0) ? SalesInvoiceMasterAndDetailsDTO.InvoiceDeductionAmount : new decimal();
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.InvoiceDeductionAmount = value;
            }
        }

        [Display(Name = "IsCanceled")]
        public bool IsCanceled
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.IsCanceled : false;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.IsCanceled = value;
            }
        }

        [Display(Name = "Billing Span End Date")]
        public string BillingSpanEndDate
        {
            get
            {
                return (SalesInvoiceMasterAndDetailsDTO != null) ? SalesInvoiceMasterAndDetailsDTO.BillingSpanEndDate : string.Empty;
            }
            set
            {
                SalesInvoiceMasterAndDetailsDTO.BillingSpanEndDate = value;
            }
        }
    }
}
