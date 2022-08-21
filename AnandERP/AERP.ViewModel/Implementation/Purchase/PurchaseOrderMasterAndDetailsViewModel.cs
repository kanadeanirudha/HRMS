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
    public class PurchaseOrderMasterAndDetailsViewModel : IPurchaseOrderMasterAndDetailsViewModel
    {
        public PurchaseOrderMasterAndDetailsViewModel()
        {
            PurchaseOrderMasterAndDetailsDTO = new PurchaseOrderMasterAndDetails();           
            InventoryPurchaseRequirementListForRequisition = new List<PurchaseOrderMasterAndDetails>();
            PurchaseRequisitionList = new List<PurchaseOrderMasterAndDetails>();
            PurchaseOrderList = new List<PurchaseOrderMasterAndDetails>();
            TaxSummaryList = new List<GeneralTaxGroupMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGeneralUnits = new List<GeneralUnits>();
        }
        public List<PurchaseOrderMasterAndDetails> InventoryPurchaseRequirementListForRequisition { get; set; }      
        public PurchaseOrderMasterAndDetails PurchaseOrderMasterAndDetailsDTO { get; set; }
        public List<PurchaseOrderMasterAndDetails> PurchaseRequisitionList { get; set; }
        public List<PurchaseOrderMasterAndDetails> PurchaseOrderList { get; set; }
        public List<GeneralTaxGroupMaster> TaxSummaryList { get; set; }
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
        /// <summary>
        /// Properties for PurchaseOrderMasterAndDetails table
        /// </summary>
        public int ID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.ID > 0) ? PurchaseOrderMasterAndDetailsDTO.ID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ID = value;
            }
        }
        public int AdminRoleID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.AdminRoleID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.AdminRoleID = value;
            }
        }
        public int GeneralUnitsID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.GeneralUnitsID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.GeneralUnitsID = value;
            }
        }
        public int VendorPinCode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.VendorPinCode > 0) ? PurchaseOrderMasterAndDetailsDTO.VendorPinCode : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.VendorPinCode = value;
            }
        }
        public int PurchaseRequisitionMasterID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionMasterID > 0) ? PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionMasterID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionMasterID = value;
            }
        }
        public int VendorNumber
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionMasterID > 0) ? PurchaseOrderMasterAndDetailsDTO.VendorNumber : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.VendorNumber = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.CentreCode = value;
            }
        }
        public string Pincode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.Pincode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Pincode = value;
            }
        }
        [Display(Name = "Purchase Order Number")]
        public string PurchaseRequisitionNumber
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionNumber : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionNumber = value;
            }
        }
        public string Currency
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.Currency : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Currency = value;
            }
        }
        public string UnitName
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.UnitName : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.UnitName = value;
            }
        }
        public string LocationAddress
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.LocationAddress : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.LocationAddress = value;
            }
        }
        public string City
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.City : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.City = value;
            }
        }
        public string ReplishmentCode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.ReplishmentCode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ReplishmentCode = value;
            }
        }
        [Display(Name = "Vendor Address")]
        public string VendorAddress
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.VendorAddress : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.VendorAddress = value;
            }
        }

        [Display(Name = "Vendor Phone Number")]
        public string VendorPhoneNumber
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.VendorPhoneNumber : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.VendorPhoneNumber = value;
            }
        }

        [Display(Name = "Vendor Name")]
        public string VendorName
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.VendorName : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.VendorName = value;
            }
        }

        [Display(Name = "Purchase Order Number")]
        public string PurchaseOrderNumber
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.PurchaseOrderNumber : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PurchaseOrderNumber = value;
            }
        }

        [Display(Name = "Purchase Order Date")]
        public string PurchaseOrderDate
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.PurchaseOrderDate : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PurchaseOrderDate = value;
            }
        }

        public int VendorID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.VendorID > 0) ? PurchaseOrderMasterAndDetailsDTO.VendorID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.VendorID = value;
            }
        }

        public Int16 PurchaseOrderType
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.PurchaseOrderType > 0) ? PurchaseOrderMasterAndDetailsDTO.PurchaseOrderType : new Int16();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PurchaseOrderType = value;
            }
        }
        [Display(Name = "Purchase Order Type")]
        public string PurchaseOrderTypeDescription
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.PurchaseOrderTypeDescription : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PurchaseOrderTypeDescription = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.CreatedBy > 0) ? PurchaseOrderMasterAndDetailsDTO.CreatedBy : new short();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.ModifiedBy > 0) ? PurchaseOrderMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.IsDeleted = value;
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
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.PurchaseOrderDetailsID > 0) ? PurchaseOrderMasterAndDetailsDTO.PurchaseOrderDetailsID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PurchaseOrderDetailsID = value;
            }
        }

        public int PurchaseRequisitionDetailsID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionDetailsID > 0) ? PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionDetailsID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PurchaseRequisitionDetailsID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.ItemID > 0) ? PurchaseOrderMasterAndDetailsDTO.ItemID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ItemID = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.Quantity > 0) ? PurchaseOrderMasterAndDetailsDTO.Quantity : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Quantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.Rate > 0) ? PurchaseOrderMasterAndDetailsDTO.Rate : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Rate = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.DepartmentID > 0) ? PurchaseOrderMasterAndDetailsDTO.DepartmentID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.DepartmentID = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.DepartmentName : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.DepartmentName = value;
            }
        }

        [Display(Name = "Storage Location")]
        public int StorageLocationID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.StorageLocationID > 0) ? PurchaseOrderMasterAndDetailsDTO.StorageLocationID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.StorageLocationID = value;
            }
        }
        [Display(Name = "Issue Location")]
        public int IssueFromLocationID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.IssueFromLocationID > 0) ? PurchaseOrderMasterAndDetailsDTO.IssueFromLocationID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.IssueFromLocationID = value;
            }
        }
        public string FromUnitName
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.FromUnitName : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.FromUnitName = value;
            }
        }

        public string FromLocationAddress
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.FromLocationAddress : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.FromLocationAddress = value;
            }
        }

        public string FromCity
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.FromCity : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.FromCity = value;
            }
        }

        public string FromPincode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.FromPincode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.FromPincode = value;
            }
        }
        public string ExpectedDeliveryDate
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.ExpectedDeliveryDate : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ExpectedDeliveryDate = value;
            }
        }

        [Display(Name = "Priority")]
        public Int16 PriorityFlag
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.PriorityFlag > 0) ? PurchaseOrderMasterAndDetailsDTO.PriorityFlag : new Int16();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PriorityFlag = value;
            }
        }

      
        [Display(Name = " Item Name")]
        public string ItemName
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.ItemName : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ItemName = value;
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
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.LocationName : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.LocationName = value;
            }
        }
      
        [Display (Name="Total Amount")]
        public decimal Amount
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.Amount > 0) ? PurchaseOrderMasterAndDetailsDTO.Amount : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Amount = value;
            }
        }

        [Display (Name = "Vendor")]
        public string Vendor
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.Vendor : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Vendor = value;
            }
        }
        [Display(Name = "Vendor")]
        public bool IsOtherState
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.IsOtherState : false;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.IsOtherState = value;
            }
        }
        
        public int ItemCount
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.ItemCount > 0) ? PurchaseOrderMasterAndDetailsDTO.ItemCount : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ItemCount = value;
            }
        }

        public decimal Freight
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.Freight > 0) ? PurchaseOrderMasterAndDetailsDTO.Freight : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Freight = value;
            }
        }

        [Display(Name = "Shipping/Handling")]
        public decimal ShippingHandling
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.ShippingHandling > 0) ? PurchaseOrderMasterAndDetailsDTO.ShippingHandling : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ShippingHandling = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.Discount > 0) ? PurchaseOrderMasterAndDetailsDTO.Discount : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Discount = value;
            }
        }

        [Display(Name = "Total Tax Amount")]
        public decimal TotalTaxAmount
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.TotalTaxAmount > 0) ? PurchaseOrderMasterAndDetailsDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.TotalTaxAmount = value;
            }
        }
        [Display(Name = "Gross Amount")]
        public decimal GrossAmount
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.GrossAmount > 0) ? PurchaseOrderMasterAndDetailsDTO.GrossAmount : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.GrossAmount = value;
            }
        }
        public string PrintingLine1
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.PrintingLine1 : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PrintingLine1 = value;
            }
        }
        public string PrintingLine2
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.PrintingLine2 : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PrintingLine2 = value;
            }
        }
        public string PrintingLine3
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.PrintingLine3 : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PrintingLine3 = value;
            }
        }
        public string PrintingLine4
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.PrintingLine4 : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PrintingLine4 = value;
            }
        }
        public decimal TaxRate
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.TaxRate > 0) ? PurchaseOrderMasterAndDetailsDTO.TaxRate : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.TaxRate = value;
            }
        }

        public int ItemNumber
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.ItemNumber : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ItemNumber = value;
            }
        }
        public string BarCode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.BarCode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.BarCode = value;
            }
        }
        public int GeneralItemCodeID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.GeneralItemCodeID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.GeneralItemCodeID = value;
            }
        }
        public decimal BaseUOMQuantity
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.BaseUOMQuantity : new decimal();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.BaseUOMQuantity = value;
            }
        }
        public string BaseUOMCode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.BaseUOMCode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.BaseUOMCode = value;
            }
        }

        [Display(Name = "PO Status")]
        public Byte POStatus
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.POStatus : new byte();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.POStatus = value;
            }
        }
        public string LogoFileSize
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.LogoFileSize : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.LogoFileSize = value;
            }
        }
        [Display(Name = "DisplayName_Logo", ResourceType = typeof(AERP.Common.Resources))]
        public byte[] Logo
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.Logo : new byte[1];         //review this       
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Logo = value;
            }
        }


        public string LogoType
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.LogoType : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.LogoType = value;
            }
        }
        public string Convertion
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.Convertion : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.Convertion = value;
            }
        }
        [Display(Name = "UoM")]
        public string UnitCode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.UnitCode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.UnitCode = value;
            }
        }
        public string TaxRateList
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.TaxRateList : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.TaxRateList = value;
            }
        }
        public string TaxList
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.TaxList : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.TaxList = value;
            }
        }
        [Display(Name = "Centre Code")]
        public string SelectedCentreCode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.SelectedCentreCode = value;
            }
        }
        [Display(Name = "PO Rate")]
        public byte WithPORate
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.WithPORate > 0) ? PurchaseOrderMasterAndDetailsDTO.WithPORate : new byte();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.WithPORate = value;
            }
        }

        #region -------------- TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.TaskNotificationMasterID > 0) ? PurchaseOrderMasterAndDetailsDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.TaskNotificationMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string TaskCode
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.TaskCode : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.TaskCode = value;
            }
        }

        public int TaskNotificationDetailsID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.TaskNotificationDetailsID > 0) ? PurchaseOrderMasterAndDetailsDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.TaskNotificationDetailsID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.GeneralTaskReportingDetailsID > 0) ? PurchaseOrderMasterAndDetailsDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.GeneralTaskReportingDetailsID = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.PersonID > 0) ? PurchaseOrderMasterAndDetailsDTO.PersonID : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.PersonID = value;
            }
        }

        public int StageSequenceNumber
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null && PurchaseOrderMasterAndDetailsDTO.StageSequenceNumber > 0) ? PurchaseOrderMasterAndDetailsDTO.StageSequenceNumber : new int();
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.IsLastRecord : false;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.IsLastRecord = value;
            }
        }
        public string TransDate
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.TransDate : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.TransDate = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.XMLstring : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.XMLstring = value;
            }
        }
        public string ApprovedStatus
        {
            get
            {
                return (PurchaseOrderMasterAndDetailsDTO != null) ? PurchaseOrderMasterAndDetailsDTO.ApprovedStatus : string.Empty;
            }
            set
            {
                PurchaseOrderMasterAndDetailsDTO.ApprovedStatus = value;
            }
        }
        #endregion
    }
}
