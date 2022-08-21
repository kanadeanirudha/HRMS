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
    public class SalesQuotationMasterAndDetailsViewModel : ISalesQuotationMasterAndDetailsViewModel
    {

        public SalesQuotationMasterAndDetailsViewModel()
        {


            SalesQuotationMasterAndDetailsDTO = new SalesQuotationMasterAndDetails();
            QuotationDetailsByEnquiryMasterID = new List<SalesQuotationMasterAndDetails>();
            ListGeneralUnits = new List<GeneralUnits>();
        }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
            }
        }
        public List<SalesQuotationMasterAndDetails> QuotationDetailsByEnquiryMasterID { get; set; }
        public SalesQuotationMasterAndDetails SalesQuotationMasterAndDetailsDTO
        {
            get;
            set;
        }
        public int SalesEnquiryMasterID
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.SalesEnquiryMasterID > 0) ? SalesQuotationMasterAndDetailsDTO.SalesEnquiryMasterID : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.SalesEnquiryMasterID = value;
            }
        }
        public int SalesQuotationMasterID
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.SalesQuotationMasterID > 0) ? SalesQuotationMasterAndDetailsDTO.SalesQuotationMasterID : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.SalesQuotationMasterID = value;
            }
        }
        public int CustomerMasterID
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.CustomerMasterID > 0) ? SalesQuotationMasterAndDetailsDTO.CustomerMasterID : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.CustomerMasterID = value;
            }
        }
        public int CustomerBranchMasterID
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.CustomerBranchMasterID > 0) ? SalesQuotationMasterAndDetailsDTO.CustomerBranchMasterID : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.CustomerBranchMasterID = value;
            }
        }
        public int ContactPersonID
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.ContactPersonID > 0) ? SalesQuotationMasterAndDetailsDTO.ContactPersonID : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.ContactPersonID = value;
            }
        }


        [Display(Name = "UOM")]
        public string UOM
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.UOM : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.UOM = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.Quantity > 0) ? SalesQuotationMasterAndDetailsDTO.Quantity : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.Quantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.Rate > 0) ? SalesQuotationMasterAndDetailsDTO.Rate : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.Rate = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.ItemNumber > 0) ? SalesQuotationMasterAndDetailsDTO.ItemNumber : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.ItemNumber = value;
            }
        }
        
        public string QuotationNumber
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.QuotationNumber : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.QuotationNumber = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.ItemDescription = value;
            }
        }
        public byte Status
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.Status : new byte();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.Status = value;
            }
        }
        public byte CustomerType
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.CustomerType : new byte();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.CustomerType = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.IsDeleted = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.CreatedBy > 0) ? SalesQuotationMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        public int ModifiedBy
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.ModifiedBy > 0) ? SalesQuotationMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }

        public string XmlString
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.XmlString : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.XmlString = value;
            }
        }
        public string EnquiryNumber
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.EnquiryNumber : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.EnquiryNumber = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.CustomerName : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.CustomerName = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Contact Person")]
        public string ContactPersonName
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.ContactPersonName : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.ContactPersonName = value;
            }
        }
        [Display(Name = "Store")]
        public int GeneralUnitsID
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.GeneralUnitsID > 0) ? SalesQuotationMasterAndDetailsDTO.GeneralUnitsID : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.GeneralUnitsID = value;
            }
        }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.TotalAmount > 0) ? SalesQuotationMasterAndDetailsDTO.TotalAmount : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.TotalAmount = value;
            }
        }

        [Display(Name = "Total Bill Amount")]
        public decimal TotalBillAmount
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.TotalBillAmount > 0) ? SalesQuotationMasterAndDetailsDTO.TotalBillAmount : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.TotalBillAmount = value;
            }
        }
        [Display(Name = "Total Tax Amount")]
        public decimal TotalTaxAmount
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.TotalTaxAmount > 0) ? SalesQuotationMasterAndDetailsDTO.TotalTaxAmount: new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.TotalTaxAmount = value;
            }
        }
        [Display(Name = "Tax Amount")]
        public decimal TaxAmount
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.TaxAmount > 0) ? SalesQuotationMasterAndDetailsDTO.TaxAmount : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.TaxAmount = value;
            }
        }
        [Display(Name = "Tax Amount")]
        public decimal TaxableAmount
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.TaxableAmount > 0) ? SalesQuotationMasterAndDetailsDTO.TaxableAmount : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.TaxableAmount = value;
            }
        }
        


        [Display(Name = "Credit Period")]
        public byte CreditPeriod
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.CreditPeriod > 0) ? SalesQuotationMasterAndDetailsDTO.CreditPeriod : new byte();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.CreditPeriod = value;
            }
        }
     

        [Display(Name = "Unit")]
        public string UnitMasterId
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.UnitMasterId : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.UnitMasterId = value;
            }
        }
        [Display(Name = "Title To")]
        public string TitleTo
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.TitleTo : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.TitleTo = value;
            }
        }
       
        public int GeneralTaxGroupMasterID
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.GeneralTaxGroupMasterID > 0) ? SalesQuotationMasterAndDetailsDTO.GeneralTaxGroupMasterID : new int();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.GeneralTaxGroupMasterID = value;
            }
        }
        public decimal TaxRate
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.TaxRate > 0) ? SalesQuotationMasterAndDetailsDTO.TaxRate : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.TaxRate = value;
            }
        }

        //Addistion to sales order

        public decimal Freight
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.Freight > 0) ? SalesQuotationMasterAndDetailsDTO.Freight : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.Freight = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.Discount > 0) ? SalesQuotationMasterAndDetailsDTO.Discount : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.Discount = value;
            }
        }
        public decimal ShippingHandling
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.ShippingHandling > 0) ? SalesQuotationMasterAndDetailsDTO.ShippingHandling : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.ShippingHandling = value;
            }
        }
        public decimal Tradein
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null && SalesQuotationMasterAndDetailsDTO.Tradein > 0) ? SalesQuotationMasterAndDetailsDTO.Tradein : new decimal();
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.Tradein = value;
            }
        }
        public string Flag
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.Flag : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.Flag = value;
            }
        }
        public string PurchaseOrderNumberClient
        {
            get
            {
                return (SalesQuotationMasterAndDetailsDTO != null) ? SalesQuotationMasterAndDetailsDTO.PurchaseOrderNumberClient : string.Empty;
            }
            set
            {
                SalesQuotationMasterAndDetailsDTO.PurchaseOrderNumberClient = value;
            }
        }

    }
}

