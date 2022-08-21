using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SalesOrderDeliveryMasterAndDetailsViewModel : ISalesOrderDeliveryMasterAndDetailsViewModel
    {

        public SalesOrderDeliveryMasterAndDetailsViewModel()
        {
            SalesOrderDeliveryMasterAndDetailsDTO = new SalesOrderDeliveryMasterAndDetails();
            SalesOrderDeliveryMasterAndDetailsListFromPO = new List<SalesOrderDeliveryMasterAndDetails>();
            SalesOrderDeliveryMasterAndDetailsList = new List<SalesOrderDeliveryMasterAndDetails>();
            ListGeneralUnits = new List<GeneralUnits>();
            SalesOrderDMList = new List<SalesOrderDeliveryMasterAndDetails>();
            TaxSummaryList = new List<GeneralTaxGroupMaster>();

        }
        public List<SalesOrderDeliveryMasterAndDetails> SalesOrderDeliveryMasterAndDetailsListFromPO { get; set; }
        public List<SalesOrderDeliveryMasterAndDetails> SalesOrderDeliveryMasterAndDetailsList { get; set; }
        public List<SalesOrderDeliveryMasterAndDetails> SalesOrderDMList { get; set; }
        public List<GeneralTaxGroupMaster> TaxSummaryList { get; set; }
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
        public SalesOrderDeliveryMasterAndDetails SalesOrderDeliveryMasterAndDetailsDTO
        {
            get;
            set;
        }
        public int SalesOrderMasterID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderMasterID = value;
            }
        }
        public int SalesOrderDeliveryMasterID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDeliveryMasterID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDeliveryMasterID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDeliveryMasterID = value;
            }
        }


        public int AdminRoleID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.AdminRoleID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.AdminRoleID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.AdminRoleID = value;
            }
        }

        [Display(Name = "Shippers Name")]
        public int GeneralShipperID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.GeneralShipperID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.GeneralShipperID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.GeneralShipperID = value;
            }
        }
        public int CustomerBranchMasterID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.CustomerBranchMasterID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.CustomerBranchMasterID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.CustomerBranchMasterID = value;
            }
        }
        public int ContactPersonID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.ContactPersonID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.ContactPersonID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ContactPersonID = value;
            }
        }
        public int CustomerMasterID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.CustomerMasterID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "UOM")]
        public string SalesUomCode
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.SalesUomCode : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.SalesUomCode = value;
            }
        }
        [Display(Name = "Dispatched Quantity")]
        public decimal DispatchedQuantity
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.DispatchedQuantity > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.DispatchedQuantity : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.DispatchedQuantity = value;
            }
        }
        public decimal ReceivedQuantity
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.ReceivedQuantity > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.ReceivedQuantity : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ReceivedQuantity = value;
            }
        }
        public decimal BaseUOMQuantity
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.BaseUOMQuantity > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.BaseUOMQuantity : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.BaseUOMQuantity = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.ItemNumber > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.ItemNumber : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ItemNumber = value;
            }
        }

        [Display(Name = "Delivery Number")]
        public string DeliveryNumber
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.DeliveryNumber : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.DeliveryNumber = value;
            }
        }
        [Display(Name = "DeliveryTransDate")]
        public string DeliveryTransDate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.DeliveryTransDate : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.DeliveryTransDate = value;
            }
        }
        [Display(Name = "SalesOrderDate")]
        public string SalesOrderDate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDate : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderDate = value;
            }
        }

        [Display(Name = "IsLocked")]
        public bool IsLocked
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.IsLocked : false;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.IsLocked = value;
            }
        }
        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.IsActive : false;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.IsActive = value;
            }
        }
        [Display(Name = "Is Complete")]
        public bool IsComplete
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.IsComplete : false;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.IsComplete = value;
            }
        }
        [Display(Name = "Country")]
        public int ShipToCountryID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.ShipToCountryID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.ShipToCountryID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ShipToCountryID = value;
            }
        }
        [Display(Name = "City")]
        public int ShipToCityID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.ShipToCityID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.ShipToCityID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ShipToCityID = value;
            }
        }
        [Display(Name = "Store")]
        public int GeneralUnitsID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.GeneralUnitsID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.GeneralUnitsID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.GeneralUnitsID = value;
            }
        }
        [Display(Name = "State")]
        public Int16 ShipToStateID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.ShipToStateID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.ShipToStateID : new Int16();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ShipToStateID = value;
            }
        }
        [Display(Name = "Vehical Number")]
        public string VehicalNumber
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.VehicalNumber : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.VehicalNumber = value;
            }
        }

        public string XmlString
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.XmlString : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.XmlString = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.CustomerName : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.CustomerName = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ItemDescription = value;
            }
        }
        [Display(Name = "Sales Order Number")]
        public string SalesOrderNumber
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderNumber : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.SalesOrderNumber = value;
            }
        }
        [Display(Name = "Ship To Address")]
        public string ShipToAddress
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.ShipToAddress : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ShipToAddress = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.CreatedBy > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.DeletedBy : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.TotalAmount > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.TotalAmount : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.TotalAmount = value;
            }
        }

        [Display(Name = "Total Bill Amount")]
        public decimal TotalBillAmount
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.TotalBillAmount > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.TotalBillAmount : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.TotalBillAmount = value;
            }
        }
        [Display(Name = "Total Tax Amount")]
        public decimal TotalTaxAmount
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.TotalTaxAmount > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.TotalTaxAmount = value;
            }
        }

        public decimal Freight
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.Freight > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.Freight : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.Freight = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.Discount > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.Discount : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.Discount = value;
            }
        }
        [Display(Name = "Shipping")]
        public decimal ShippingHandling
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.ShippingHandling > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.ShippingHandling : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ShippingHandling = value;
            }
        }
        public decimal Tradein
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.Tradein > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.Tradein : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.Tradein = value;
            }
        }
        public bool IsOther
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.IsOther : false;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.IsOther = value;
            }
        }
        [Display(Name = "Batch")]
        public string BatchNumber
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.BatchNumber : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.BatchNumber = value;
            }
        }
        [Display(Name = "Expiry Date")]
        public string ExpiryDate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.ExpiryDate : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ExpiryDate = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.Rate > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.Rate : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.Rate = value;
            }
        }
        [Display(Name = "Customer Type")]
        public byte CustomerType
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.CustomerType > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.CustomerType : new byte();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.CustomerType = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string BranchName
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.BranchName : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.BranchName = value;
            }
        }
        [Display(Name = "Contact Person Name")]
        public string ContactPersonName
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.ContactPersonName : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.ContactPersonName = value;
            }
        }
        public decimal TaxRate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.TaxRate > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.TaxRate : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.TaxRate = value;
            }
        }
        public int GenTaxGroupMasterID
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.GenTaxGroupMasterID > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.GenTaxGroupMasterID : new int();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.GenTaxGroupMasterID = value;
            }
        }

        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.SerialAndBatchManagedBy > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.SerialAndBatchManagedBy = value;
            }
        }
        [Display(Name = "DM Rate")]
        public byte WithDMRate
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.WithDMRate > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.WithDMRate : new byte();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.WithDMRate = value;
            }
        }
        [Display(Name = "Transportation Mode")]
        public string TransportationMode
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.TransportationMode : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.TransportationMode = value;
            }
        }

        [Display(Name = "Total Purchase Bill Amount")]
        public decimal TotalPurchaseBillAmount
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseBillAmount > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseBillAmount : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseBillAmount = value;
            }
        }
        [Display(Name = "Total Purchase Tax Amount")]
        public decimal TotalPurchaseTaxAmount
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseTaxAmount > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseTaxAmount : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseTaxAmount = value;
            }
        }
        [Display(Name = "Total purchase Amount")]
        public decimal TotalPurchaseAmount
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null && SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseAmount > 0) ? SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseAmount : new decimal();
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.TotalPurchaseAmount = value;
            }
        }

        public bool IsInvoiced
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.IsInvoiced : false;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.IsInvoiced = value;
            }
        }

        public bool IsCancelled
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.IsCancelled : false;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.IsCancelled = value;
            }
        }
        public string MonthName
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.MonthName : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.MonthName = value;
            }
        }
        public string MonthYear
        {
            get
            {
                return (SalesOrderDeliveryMasterAndDetailsDTO != null) ? SalesOrderDeliveryMasterAndDetailsDTO.MonthYear : string.Empty;
            }
            set
            {
                SalesOrderDeliveryMasterAndDetailsDTO.MonthYear = value;
            }
        }
    }
}

