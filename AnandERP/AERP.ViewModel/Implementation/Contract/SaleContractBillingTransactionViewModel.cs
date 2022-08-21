using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractBillingTransactionViewModel : ISaleContractBillingTransactionViewModel
    {

        public SaleContractBillingTransactionViewModel()
        {
            SaleContractBillingTransactionDTO = new SaleContractBillingTransaction();
            SaleContractBillingTransactionList = new List<SaleContractBillingTransaction>();
            TaxSummaryList = new List<GeneralTaxGroupMaster>();
        }
        public List<SaleContractBillingTransaction> SaleContractBillingTransactionList { get; set; }
        public List<GeneralTaxGroupMaster> TaxSummaryList { get; set; }
        public SaleContractBillingTransaction SaleContractBillingTransactionDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.ID > 0) ? SaleContractBillingTransactionDTO.ID : new Int64();
            }
            set
            {
                SaleContractBillingTransactionDTO.ID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.SaleContractMasterID > 0) ? SaleContractBillingTransactionDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractBillingTransactionDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Type")]
        public byte BillingType
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.BillingType > 0) ? SaleContractBillingTransactionDTO.BillingType : new byte();
            }
            set
            {
                SaleContractBillingTransactionDTO.BillingType = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.SaleContractBillingSpanID > 0) ? SaleContractBillingTransactionDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractBillingTransactionDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Customer")]
        public string CustomerMasterName
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Customer")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.CustomerMasterID : new Int32();
            }
            set
            {
                SaleContractBillingTransactionDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractBillingTransactionDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.CustomerBranchMasterName = value;
            }
        }
        
        public bool IsTaxExempted
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.IsTaxExempted: false;
            }
            set
            {
                SaleContractBillingTransactionDTO.IsTaxExempted = value;
            }
        }
        
        public byte ReasonForExemption
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.ReasonForExemption: new byte();
            }
            set
            {
                SaleContractBillingTransactionDTO.ReasonForExemption = value;
            }
        }
        [Display(Name = "Start Date")]
        public string StartDate
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.StartDate : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.StartDate = value;
            }
        }

        [Display(Name = "End Date")]
        public string EndDate
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.EndDate : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.EndDate = value;
            }
        }
        [Display(Name = "Billing Transaction ID")]
        public Int64 SaleContractBillingTransactionDetailsID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.SaleContractBillingTransactionDetailsID > 0) ? SaleContractBillingTransactionDTO.SaleContractBillingTransactionDetailsID : new Int64();
            }
            set
            {
                SaleContractBillingTransactionDTO.SaleContractBillingTransactionDetailsID = value;

            }
        }

        [Display(Name = "Is Bill Generated")]
        public bool IsBillGenerated
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null ) ? SaleContractBillingTransactionDTO.IsBillGenerated : false;
            }
            set
            {
                SaleContractBillingTransactionDTO.IsBillGenerated = value;
            }
        }

        [Display(Name = "Total Bill Amount")]
        public decimal TotalBillAmount
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.TotalBillAmount > 0) ? SaleContractBillingTransactionDTO.TotalBillAmount : new decimal();
            }
            set
            {
                SaleContractBillingTransactionDTO.TotalBillAmount = value;
            }
        }
        [Display(Name = "Round Off Amount")]
        public decimal RoundOffAmount
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.RoundOffAmount > 0) ? SaleContractBillingTransactionDTO.RoundOffAmount : new decimal();
            }
            set
            {
                SaleContractBillingTransactionDTO.RoundOffAmount = value;
            }
        }
        [Display(Name = "Is Material Delivery Created")]
        public bool IsMaterialDeliveryCreated
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.IsMaterialDeliveryCreated : false;
            }
            set
            {
                SaleContractBillingTransactionDTO.IsMaterialDeliveryCreated = value;
            }
        }
        [Display(Name = "Is Material Delivery Received")]
        public bool IsMaterialDeliveryReceived
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.IsMaterialDeliveryReceived : false;
            }
            set
            {
                SaleContractBillingTransactionDTO.IsMaterialDeliveryReceived = value;
            }
        }
        [Display(Name = "Requirement Details ID")]
        public Int64 SaleContractRequirementDetailsID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.SaleContractRequirementDetailsID : new Int64();
            }
            set
            {
                SaleContractBillingTransactionDTO.SaleContractRequirementDetailsID = value;
            }
        }
        [Display(Name = "Item Number")]
        public Int32 ItemNumber
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.ItemNumber : new Int32();
            }
            set
            {
                SaleContractBillingTransactionDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.ItemDescription :string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.ItemDescription = value;
            }
        }

        [Display(Name = "Quantity")]
        public decimal Quantity
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.Quantity : new decimal();
            }
            set
            {
                SaleContractBillingTransactionDTO.Quantity = value;
            }
        }
        [Display(Name = "Rate")]
        public decimal Rate
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.Rate : new decimal();
            }
            set
            {
                SaleContractBillingTransactionDTO.Rate = value;
            }
        }
        [Display(Name = "Tax Group")]
        public Int16 GeneralTaxGroupMasterID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.GeneralTaxGroupMasterID > 0) ? SaleContractBillingTransactionDTO.GeneralTaxGroupMasterID : new Int16();
            }
            set
            {
                SaleContractBillingTransactionDTO.GeneralTaxGroupMasterID = value;
            }
        }
        [Display(Name = "Tax Amount")]
        public decimal TaxAmount
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.TaxAmount : new decimal();
            }
            set
            {
                SaleContractBillingTransactionDTO.TaxAmount = value;
            }
        }
        [Display(Name = "Taxable Amount")]
        public decimal TaxableAmount
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.TaxableAmount : new decimal();
            }
            set
            {
                SaleContractBillingTransactionDTO.TaxableAmount = value;
            }
        }
        [Display(Name = "Amount")]
        public decimal NetAmount
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.NetAmount : new decimal();
            }
            set
            {
                SaleContractBillingTransactionDTO.NetAmount = value;
            }
        }
        [Display(Name = "Delivery Memo")]
        public string DeliveryMemoNumber
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.DeliveryMemoNumber : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.DeliveryMemoNumber = value;
            }
        }
        public Int32 DeliveryMemoID
        {

            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.DeliveryMemoID > 0) ? SaleContractBillingTransactionDTO.DeliveryMemoID : new Int32();
            }
            set
            {
                SaleContractBillingTransactionDTO.DeliveryMemoID = value;
            }
        }
        [Display(Name = "Location")]
        public Int32 LocationID
        {

            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.LocationID > 0) ? SaleContractBillingTransactionDTO.LocationID : new Int32();
            }
            set
            {
                SaleContractBillingTransactionDTO.LocationID = value;
            }
        }
        [Display(Name = "Location")]
        public string LocationName
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.LocationName : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.LocationName = value;
            }
        }
        [Display(Name = "Invoice Number")]
        public string CustomerInvoiceNumber
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.CustomerInvoiceNumber : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.CustomerInvoiceNumber = value;
            }
        }
        public Int32 SalesInvoiceMasterID
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.SalesInvoiceMasterID > 0) ? SaleContractBillingTransactionDTO.SalesInvoiceMasterID : new Int32();
            }
            set
            {
                SaleContractBillingTransactionDTO.SalesInvoiceMasterID = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.IsDeleted : false;
            }
            set
            {
                SaleContractBillingTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.CreatedBy > 0) ? SaleContractBillingTransactionDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractBillingTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractBillingTransactionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.ModifiedBy > 0) ? SaleContractBillingTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractBillingTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.ModifiedDate.HasValue) ? SaleContractBillingTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractBillingTransactionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.DeletedBy > 0) ? SaleContractBillingTransactionDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractBillingTransactionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null && SaleContractBillingTransactionDTO.DeletedDate.HasValue) ? SaleContractBillingTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractBillingTransactionDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLStringBillingTransaction { get; set; }
        public string XMLstringForVouchar { get; set; }
        public bool IsOtherState
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.IsOtherState : false;
            }
            set
            {
                SaleContractBillingTransactionDTO.IsOtherState = value;
            }
        }
        
        public string TaxExemptionRemark
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.TaxExemptionRemark : string.Empty;
            }
            set
            {
                SaleContractBillingTransactionDTO.TaxExemptionRemark = value;
            }
        }
        public byte SummaryFormat
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.SummaryFormat : new byte();
            }
            set
            {
                SaleContractBillingTransactionDTO.SummaryFormat = value;
            }
        }
        public bool IsCanceled
        {
            get
            {
                return (SaleContractBillingTransactionDTO != null) ? SaleContractBillingTransactionDTO.IsCanceled : false;
            }
            set
            {
                SaleContractBillingTransactionDTO.IsCanceled = value;
            }
        }
        
    }
}

