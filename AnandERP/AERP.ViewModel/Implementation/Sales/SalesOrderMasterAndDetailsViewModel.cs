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
    public class SalesOrderMasterAndDetailsViewModel : ISalesOrderMasterAndDetailsViewModel
    {

        public SalesOrderMasterAndDetailsViewModel()
        {


            SalesOrderMasterAndDetailsDTO = new SalesOrderMasterAndDetails();
            QuotationDetailsByEnquiryMasterID = new List<SalesOrderMasterAndDetails>();
            ListGetOrganisationDepartmentCentreAndRoleWise = new List<OrganisationDepartmentMaster>();
            ListGeneralUnits = new List<GeneralUnits>();
            ListGeneralUnitswithCentreCode = new List<GeneralUnits>();
            SalesOrderList = new List<SalesOrderMasterAndDetails>();
            TaxSummaryList = new List<GeneralTaxGroupMaster>();
        }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
        }
        public List<GeneralUnits> ListGeneralUnitswithCentreCode
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
        public IEnumerable<SelectListItem> ListGeneralUnitswithCentreCodeItems
        {
            get
            {
                return new SelectList(ListGeneralUnitswithCentreCode, "UnitIDwithCentreCode", "UnitName");
            }
        }
        public List<OrganisationDepartmentMaster> ListGetOrganisationDepartmentCentreAndRoleWise
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetOrganisationDepartmentCentreAndRoleWiseItems
        {
            get
            {
                return new SelectList(ListGetOrganisationDepartmentCentreAndRoleWise, "ID", "DepartmentName");
            }
        }
        public List<SalesOrderMasterAndDetails> QuotationDetailsByEnquiryMasterID { get; set; }
        public List<SalesOrderMasterAndDetails> SalesOrderList { get; set; }
        public List<GeneralTaxGroupMaster> TaxSummaryList { get; set; }
        public SalesOrderMasterAndDetails SalesOrderMasterAndDetailsDTO
        {
            get;
            set;
        }
        public int SalesOrderMasterID
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.SalesOrderMasterID > 0) ? SalesOrderMasterAndDetailsDTO.SalesOrderMasterID : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.SalesOrderMasterID = value;
            }
        }
        public int SalesQuotationMasterID
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.SalesQuotationMasterID > 0) ? SalesOrderMasterAndDetailsDTO.SalesQuotationMasterID : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.SalesQuotationMasterID = value;
            }
        }
        public int CustomerMasterID
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.CustomerMasterID > 0) ? SalesOrderMasterAndDetailsDTO.CustomerMasterID : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CustomerMasterID = value;
            }
        }
        public int CustomerBranchMasterID
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.CustomerBranchMasterID > 0) ? SalesOrderMasterAndDetailsDTO.CustomerBranchMasterID : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CustomerBranchMasterID = value;
            }
        }
        public int ContactPersonID
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.ContactPersonID > 0) ? SalesOrderMasterAndDetailsDTO.ContactPersonID : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.ContactPersonID = value;
            }
        }


        [Display(Name = "UOM")]
        public string UOM
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.UOM : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.UOM = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.Quantity > 0) ? SalesOrderMasterAndDetailsDTO.Quantity : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.Quantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.Rate > 0) ? SalesOrderMasterAndDetailsDTO.Rate : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.Rate = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.ItemNumber > 0) ? SalesOrderMasterAndDetailsDTO.ItemNumber : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.ItemNumber = value;
            }
        }

        public string QuotationNumber
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.QuotationNumber : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.QuotationNumber = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.ItemDescription = value;
            }
        }
        public byte Status
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.Status : new byte();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.Status = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.IsDeleted = value;
            }
        }
        public bool IsOther
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.IsOther : false;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.IsOther = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.CreatedBy > 0) ? SalesOrderMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        public int ModifiedBy
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.ModifiedBy > 0) ? SalesOrderMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.ModifiedDate = value;
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
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.XmlString : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.XmlString = value;
            }
        }
        public string SalesOrderNumber
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.SalesOrderNumber : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.SalesOrderNumber = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.CustomerName : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CustomerName = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Contact Person")]
        public string ContactPersonName
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.ContactPersonName : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.ContactPersonName = value;
            }
        }
        [Display(Name = "Store")]
        public int GeneralUnitsID
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.GeneralUnitsID > 0) ? SalesOrderMasterAndDetailsDTO.GeneralUnitsID : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.GeneralUnitsID = value;
            }
        }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TotalAmount > 0) ? SalesOrderMasterAndDetailsDTO.TotalAmount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TotalAmount = value;
            }
        }
        [Display(Name = "Total Purchase Bill Amount")]
        public decimal TotalPurchaseBillAmount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TotalPurchaseBillAmount > 0) ? SalesOrderMasterAndDetailsDTO.TotalPurchaseBillAmount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TotalPurchaseBillAmount = value;
            }
        }
        [Display(Name = "Total Purchase Tax Amount")]
        public decimal TotalPurchaseTaxAmount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TotalPurchaseTaxAmount > 0) ? SalesOrderMasterAndDetailsDTO.TotalPurchaseTaxAmount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TotalPurchaseTaxAmount = value;
            }
        }
        [Display(Name = "Total purchase Amount")]
        public decimal TotalPurchaseAmount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TotalPurchaseAmount > 0) ? SalesOrderMasterAndDetailsDTO.TotalPurchaseAmount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TotalPurchaseAmount = value;
            }
        }
        
        [Display(Name = "Total Bill Amount")]
        public decimal TotalBillAmount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TotalBillAmount > 0) ? SalesOrderMasterAndDetailsDTO.TotalBillAmount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TotalBillAmount = value;
            }
        }
        [Display(Name = "Total Tax Amount")]
        public decimal TotalTaxAmount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TotalTaxAmount > 0) ? SalesOrderMasterAndDetailsDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TotalTaxAmount = value;
            }
        }
        [Display(Name = "Tax Amount")]
        public decimal TaxAmount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TaxAmount > 0) ? SalesOrderMasterAndDetailsDTO.TaxAmount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TaxAmount = value;
            }
        }
        [Display(Name = "Tax Amount")]
        public decimal TaxableAmount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TaxableAmount > 0) ? SalesOrderMasterAndDetailsDTO.TaxableAmount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TaxableAmount = value;
            }
        }



        [Display(Name = "Credit Period")]
        public byte CreditPeriod
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.CreditPeriod > 0) ? SalesOrderMasterAndDetailsDTO.CreditPeriod : new byte();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CreditPeriod = value;
            }
        }
        [Display(Name = "Unit")]
        public int UnitMasterId
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.UnitMasterId > 0) ? SalesOrderMasterAndDetailsDTO.UnitMasterId : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.UnitMasterId = value;
            }
        }
        [Display(Name = "Title To")]
        public string TitleTo
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.TitleTo : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TitleTo = value;
            }
        }

        public int GeneralTaxGroupMasterID
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.GeneralTaxGroupMasterID > 0) ? SalesOrderMasterAndDetailsDTO.GeneralTaxGroupMasterID : new int();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.GeneralTaxGroupMasterID = value;
            }
        }
        public decimal TaxRate
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.TaxRate > 0) ? SalesOrderMasterAndDetailsDTO.TaxRate : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.TaxRate = value;
            }
        }
        public decimal PurchasePrice
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.PurchasePrice > 0) ? SalesOrderMasterAndDetailsDTO.PurchasePrice : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.PurchasePrice = value;
            }
        }
        public string PurchaseUoMCode
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.PurchaseUoMCode : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.PurchaseUoMCode = value;
            }
        }
        public decimal ConversionFactor
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.ConversionFactor > 0) ? SalesOrderMasterAndDetailsDTO.ConversionFactor : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.ConversionFactor = value;
            }
        }
        
        //Addistion to sales order

        public decimal Freight
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.Freight > 0) ? SalesOrderMasterAndDetailsDTO.Freight : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.Freight = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.Discount > 0) ? SalesOrderMasterAndDetailsDTO.Discount : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.Discount = value;
            }
        }
        public decimal ShippingHandling
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.ShippingHandling > 0) ? SalesOrderMasterAndDetailsDTO.ShippingHandling : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.ShippingHandling = value;
            }
        }
        public decimal Tradein
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.Tradein > 0) ? SalesOrderMasterAndDetailsDTO.Tradein : new decimal();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.Tradein = value;
            }
        }
        public string Flag
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.Flag : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.Flag = value;
            }
        }
        public string PurchaseOrderNumberClient
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.PurchaseOrderNumberClient : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.PurchaseOrderNumberClient = value;
            }
        }
        public string SalesOrderDate
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.SalesOrderDate : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.SalesOrderDate = value;
            }
        }
        public byte CustomerType
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null && SalesOrderMasterAndDetailsDTO.CustomerType > 0) ? SalesOrderMasterAndDetailsDTO.CustomerType : new byte();
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CustomerType = value;
            }
        }

        public bool CreatePR
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.CreatePR : false;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.CreatePR = value;
            }
        }
        [Display(Name ="Department")]
        public string SelectedDepartmentID
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.SelectedDepartmentID : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.SelectedDepartmentID = value;
            }
        }
        public string GeneralUnitsIDWithcentreCode
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.GeneralUnitsIDWithcentreCode : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.GeneralUnitsIDWithcentreCode = value;
            }
        }
        [Display(Name = "Month")]
        public string MonthName
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.MonthName : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.MonthName = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (SalesOrderMasterAndDetailsDTO != null) ? SalesOrderMasterAndDetailsDTO.MonthYear : string.Empty;
            }
            set
            {
                SalesOrderMasterAndDetailsDTO.MonthYear = value;
            }
        }

    }
}

