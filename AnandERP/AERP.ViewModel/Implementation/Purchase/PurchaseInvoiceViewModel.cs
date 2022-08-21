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
    public class PurchaseInvoiceViewModel : IPurchaseInvoiceViewModel
    {
        public PurchaseInvoiceViewModel()
        {
            PurchaseInvoiceDTO = new PurchaseInvoice();
            InventoryPurchaseRequirementListForRequisition = new List<PurchaseInvoice>();
            PurchaseRequisitionList = new List<PurchaseInvoice>();
            PurchaseOrderList = new List<PurchaseInvoice>();
            ListGeneralUnits = new List<GeneralUnits>();
            ListInventoryLocationMaster = new List<InventoryLocationMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<PurchaseInvoice> InventoryPurchaseRequirementListForRequisition { get; set; }
        public PurchaseInvoice PurchaseInvoiceDTO { get; set; }
        public List<PurchaseInvoice> PurchaseRequisitionList { get; set; }
        public List<PurchaseInvoice> PurchaseOrderList { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
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
        public List<InventoryLocationMaster> ListInventoryLocationMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListInventoryLocationMasterItems
        {
            get
            {
                return new SelectList(ListInventoryLocationMaster, "ID", "LocationName");
            }
        }
        /// <summary>
        /// Properties for PurchaseInvoice table
        /// </summary>
        public int ID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.ID > 0) ? PurchaseInvoiceDTO.ID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.ID = value;
            }
        }
        public int AdminRoleID
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.AdminRoleID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.AdminRoleID = value;
            }
        }

        public int PurchaseRequisitionMasterID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.PurchaseRequisitionMasterID > 0) ? PurchaseInvoiceDTO.PurchaseRequisitionMasterID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseRequisitionMasterID = value;
            }
        }
        [Display(Name = "Purchase Order Number")]
        public string PurchaseRequisitionNumber
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.PurchaseRequisitionNumber : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseRequisitionNumber = value;
            }
        }



        [Display(Name = "Purchase Order Number")]
        public string PurchaseOrderNumber
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.PurchaseOrderNumber : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseOrderNumber = value;
            }
        }

        [Display(Name = "Purchase Order Date")]
        public string PurchaseOrderDate
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.PurchaseOrderDate : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseOrderDate = value;
            }
        }
         [Display(Name = "Vendor Name")]
        public string VendorName
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.VendorName : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.VendorName = value;
            }
        }
        public int VendorID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.VendorID > 0) ? PurchaseInvoiceDTO.VendorID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.VendorID = value;
            }
        }
        public bool IsOtherState
        {
            get
            {
                return (PurchaseInvoiceDTO != null ) ? PurchaseInvoiceDTO.IsOtherState : false;
            }
            set
            {
                PurchaseInvoiceDTO.IsOtherState = value;
            }
        }
        public int PurchaseOrderMasterID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.PurchaseOrderMasterID > 0) ? PurchaseInvoiceDTO.PurchaseOrderMasterID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseOrderMasterID = value;
            }
        }
        public int PurchaseGRNMasterID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.PurchaseGRNMasterID > 0) ? PurchaseInvoiceDTO.PurchaseGRNMasterID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseGRNMasterID = value;
            }
        }
        public Int16 PurchaseOrderType
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.PurchaseOrderType > 0) ? PurchaseInvoiceDTO.PurchaseOrderType : new Int16();
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseOrderType = value;
            }
        }
        [Display(Name = "Purchase Order Type")]
        public string PurchaseOrderTypeDescription
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.PurchaseOrderTypeDescription : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseOrderTypeDescription = value;
            }
        }
        //public string PurchaseOrderNumber
        //{
        //    get
        //    {
        //        return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.PurchaseOrderNumber : string.Empty;
        //    }
        //    set
        //    {
        //        PurchaseInvoiceDTO.PurchaseOrderNumber = value;
        //    }
        //}
        public int CreatedBy
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.CreatedBy > 0) ? PurchaseInvoiceDTO.CreatedBy : new short();
            }
            set
            {
                PurchaseInvoiceDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseInvoiceDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.ModifiedBy > 0) ? PurchaseInvoiceDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseInvoiceDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseInvoiceDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.IsDeleted : false;
            }
            set
            {
                PurchaseInvoiceDTO.IsDeleted = value;
            }
        }
        public string errorMessage { get; set; }

        /// <summary>
        /// Properties for PurchaseOrderDetails table
        /// </summary>
        public int PurchaseOrderDetailsID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.PurchaseOrderDetailsID > 0) ? PurchaseInvoiceDTO.PurchaseOrderDetailsID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseOrderDetailsID = value;
            }
        }

        public int PurchaseRequisitionDetailsID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.PurchaseRequisitionDetailsID > 0) ? PurchaseInvoiceDTO.PurchaseRequisitionDetailsID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseRequisitionDetailsID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.ItemID > 0) ? PurchaseInvoiceDTO.ItemID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.ItemID = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.Quantity > 0) ? PurchaseInvoiceDTO.Quantity : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.Quantity = value;
            }
        }
        public decimal FocReceivedQuantity
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.FocReceivedQuantity : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.FocReceivedQuantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.Rate > 0) ? PurchaseInvoiceDTO.Rate : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.Rate = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.DepartmentID > 0) ? PurchaseInvoiceDTO.DepartmentID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.DepartmentID = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.DepartmentName : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.DepartmentName = value;
            }
        }
        public string GRNNumber
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.GRNNumber : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.GRNNumber = value;
            }
        }
        public string GRNTransDate
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.GRNTransDate : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.GRNTransDate = value;
            }
        }
        [Display(Name = "Storage Location")]
        public int StorageLocationID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.StorageLocationID > 0) ? PurchaseInvoiceDTO.StorageLocationID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.StorageLocationID = value;
            }
        }
        [Display(Name = "Issue Location")]
        public int IssueFromLocationID
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.IssueFromLocationID > 0) ? PurchaseInvoiceDTO.IssueFromLocationID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.IssueFromLocationID = value;
            }
        }
        [Display(Name = "Expected Delivery Date")]
        public string ExpectedDeliveryDate
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.ExpectedDeliveryDate : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.ExpectedDeliveryDate = value;
            }
        }

        [Display(Name = "Priority")]
        public Int16 PriorityFlag
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.PriorityFlag > 0) ? PurchaseInvoiceDTO.PriorityFlag : new Int16();
            }
            set
            {
                PurchaseInvoiceDTO.PriorityFlag = value;
            }
        }


        [Display(Name = " Item Name")]
        public string ItemName
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.ItemName : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.ItemName = value;
            }
        }

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

        public string LocationName
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.LocationName : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.LocationName = value;
            }
        }

        [Display(Name = "Total Amount")]
        public decimal Amount
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.Amount > 0) ? PurchaseInvoiceDTO.Amount : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.Amount = value;
            }
        }



        [Display(Name = "Vendor Invoice No.")]
        public string VendorInvoiceNo
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.VendorInvoiceNo : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.VendorInvoiceNo = value;
            }
        }



        public int ItemCount
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.ItemCount > 0) ? PurchaseInvoiceDTO.ItemCount : new int();
            }
            set
            {
                PurchaseInvoiceDTO.ItemCount = value;
            }
        }

        public decimal Freight
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.Freight > 0) ? PurchaseInvoiceDTO.Freight : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.Freight = value;
            }
        }

        [Display(Name = "Shipping/Handling")]
        public decimal ShippingHandling
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.ShippingHandling > 0) ? PurchaseInvoiceDTO.ShippingHandling : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.ShippingHandling = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.Discount > 0) ? PurchaseInvoiceDTO.Discount : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.Discount = value;
            }
        }

        [Display(Name = "Total Tax Amount")]
        public decimal TotalTaxAmount
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.TotalTaxAmount > 0) ? PurchaseInvoiceDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.TotalTaxAmount = value;
            }
        }
        
        public decimal TaxRate
        {
            get
            {
                return (PurchaseInvoiceDTO != null && PurchaseInvoiceDTO.TaxRate > 0) ? PurchaseInvoiceDTO.TaxRate : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.TaxRate = value;
            }
        }

        public int ItemNumber
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.ItemNumber : new int();
            }
            set
            {
                PurchaseInvoiceDTO.ItemNumber = value;
            }
        }
        public string BarCode
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.BarCode : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.BarCode = value;
            }
        }
        public int GeneralItemCodeID
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.GeneralItemCodeID : new int();
            }
            set
            {
                PurchaseInvoiceDTO.GeneralItemCodeID = value;
            }
        }
        public int GenTaxGroupMasterID
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.GenTaxGroupMasterID : new int();
            }
            set { PurchaseInvoiceDTO.GenTaxGroupMasterID = value; }
        }
        public decimal BaseUOMQuantity
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.BaseUOMQuantity : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.BaseUOMQuantity = value;
            }
        }
        public string BaseUOMCode
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.BaseUOMCode : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.BaseUOMCode = value;
            }
        }
        public string BatchNumber
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.BatchNumber : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.BatchNumber = value;
            }
        }
        public string ExpiryDate
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.ExpiryDate : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.ExpiryDate = value;
            }
        }
        public decimal TotalInvoiceAmount
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.TotalInvoiceAmount : new decimal();
            }
            set
            {
                PurchaseInvoiceDTO.TotalInvoiceAmount = value;
            }
        }
        public string XMLstringForVouchar
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.XMLstringForVouchar : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.XMLstringForVouchar = value;
            }
        }
        [Display(Name ="Centre Code")]
        public string SelectedCentreCode
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.SelectedCentreCode = value;
            }
        }
        [Display(Name ="Store")]
        public Int16 GeneralUnitsID
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.GeneralUnitsID : new short();
            }
            set
            {
                PurchaseInvoiceDTO.GeneralUnitsID = value;
            }
        }
        public string Convertion
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.Convertion : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.Convertion = value;
            }
        }
        [Display(Name ="UoM")]
        public string UnitCode
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.UnitCode : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.UnitCode = value;
            }
        }
        public string TaxRateList
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.TaxRateList : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.TaxRateList = value;
            }
        }
        public string TaxList
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.TaxList : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.TaxList = value;
            }
        }
        public string XmlStringForDirectinvoiceVoucher
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.XmlStringForDirectinvoiceVoucher : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.XmlStringForDirectinvoiceVoucher = value;
            }
        }
        public string PurchaseDetailsXML
        {
            get
            {
                return (PurchaseInvoiceDTO != null) ? PurchaseInvoiceDTO.PurchaseDetailsXML : string.Empty;
            }
            set
            {
                PurchaseInvoiceDTO.PurchaseDetailsXML = value;
            }
        }

    }
}
