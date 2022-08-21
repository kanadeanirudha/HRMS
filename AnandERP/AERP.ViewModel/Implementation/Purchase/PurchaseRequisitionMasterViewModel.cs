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
    public class PurchaseRequisitionMasterViewModel : IPurchaseRequisitionMasterViewModel
    {
        public PurchaseRequisitionMasterViewModel()
        {
            PurchaseRequisitionMasterDTO = new PurchaseRequisitionMaster();
            PolicyAnswerByPolicyStatus = new List<GeneralPolicyRules>();
            InventoryPurchaseRequirementListForRequisition = new List<PurchaseRequisitionMaster>();
            RequirmentDatalistItemWise = new List<PurchaseRequisitionMaster>();
            PurchaseRequisitionMasterList = new List<PurchaseRequisitionMaster>();
            BelowStocksafetyLevelListForRequisition = new List<PurchaseRequisitionMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            TaxSummaryList = new List<GeneralTaxGroupMaster>();
        }
        public List<PurchaseRequisitionMaster> InventoryPurchaseRequirementListForRequisition { get; set; }
        public List<PurchaseRequisitionMaster> BelowStocksafetyLevelListForRequisition { get; set; }
        public List<PurchaseRequisitionMaster> PurchaseRequisitionMasterList { get; set; }
        public PurchaseRequisitionMaster PurchaseRequisitionMasterDTO { get; set; }
        public List<PurchaseRequisitionMaster> RequirmentDatalistItemWise { get; set; }
        public List<GeneralPolicyRules> PolicyAnswerByPolicyStatus { get; set; }
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
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }
        /// <summary>
        /// Properties for PurchaseRequisitionMaster table
        /// </summary>
        /// 
        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                PurchaseRequisitionMasterDTO.SerialAndBatchManagedBy = value;
            }
        }
        public int ID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.ID > 0) ? PurchaseRequisitionMasterDTO.ID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ID = value;
            }
        }
        public int AdminRoleID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.AdminRoleID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.AdminRoleID = value;
            }
        }
        public string Pincode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.Pincode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.Pincode = value;
            }
        }
        [Required(ErrorMessage = "Requirement No. should not be blank.")]
        [Display(Name = "Requirement No.")]
        public string PurchaseRequirementNumber
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PurchaseRequirementNumber : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PurchaseRequirementNumber = value;
            }
        }
        [Display(Name = "Conversion")]
        public string Convertion
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.Convertion : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.Convertion = value;
            }
        }
        public string ReplishmentCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.ReplishmentCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.ReplishmentCode = value;
            }
        }

        [Required(ErrorMessage = "Requisition No. should not be blank.")]
        [Display(Name = "Requisition No.")]
        public string PurchaseRequisitionNumber
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PurchaseRequisitionNumber : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PurchaseRequisitionNumber = value;
            }
        }
        [Required(ErrorMessage = "Transaction Date should not be blank.")]
        [Display(Name = " Transaction Date")]
        public string TransDate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.TransDate : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.TransDate = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.CreatedBy > 0) ? PurchaseRequisitionMasterDTO.CreatedBy : new short();
            }
            set
            {
                PurchaseRequisitionMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseRequisitionMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.ModifiedBy > 0) ? PurchaseRequisitionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseRequisitionMasterDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.IsDeleted : false;
            }
            set
            {
                PurchaseRequisitionMasterDTO.IsDeleted = value;
            }
        }
        public string errorMessage { get; set; }

        /// <summary>
        /// Properties for PurchaseRequirementDetails table
        /// </summary>
        public int PurchaseRequirementDetailsID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.PurchaseRequirementDetailsID > 0) ? PurchaseRequisitionMasterDTO.PurchaseRequirementDetailsID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.PurchaseRequirementDetailsID = value;
            }
        }

        public int PurchaseRequirementMasterID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.PurchaseRequirementMasterID > 0) ? PurchaseRequisitionMasterDTO.PurchaseRequirementMasterID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.PurchaseRequirementMasterID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.ItemID > 0) ? PurchaseRequisitionMasterDTO.ItemID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ItemID = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.Quantity > 0) ? PurchaseRequisitionMasterDTO.Quantity : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.Quantity = value;
            }
        }
        public decimal BatchQuantity
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.BatchQuantity > 0) ? PurchaseRequisitionMasterDTO.BatchQuantity : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.BatchQuantity = value;
            }
        }
        public decimal MinimumOrderquantity
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.MinimumOrderquantity > 0) ? PurchaseRequisitionMasterDTO.MinimumOrderquantity : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.MinimumOrderquantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.Rate > 0) ? PurchaseRequisitionMasterDTO.Rate : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.Rate = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.DepartmentID > 0) ? PurchaseRequisitionMasterDTO.DepartmentID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.DepartmentID = value;
            }
        }
         [Display(Name = "Department ")]
        public string DepartmentName
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.DepartmentName : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.DepartmentName = value;
            }
        }
        [Display(Name = "To Sub Location")]
        //Replace storage location to Sub Location
        public int StorageLocationID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.StorageLocationID > 0) ? PurchaseRequisitionMasterDTO.StorageLocationID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.StorageLocationID = value;
            }
        }
        [Display(Name = "Priority")]
        public Int16 PriorityFlag
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.PriorityFlag > 0) ? PurchaseRequisitionMasterDTO.PriorityFlag : new Int16();
            }
            set
            {
                PurchaseRequisitionMasterDTO.PriorityFlag = value;
            }
        }
        public string Priority
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.Priority : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.Priority = value;
            }
        }
        public Int16 PRStatus
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.PRStatus > 0) ? PurchaseRequisitionMasterDTO.PRStatus : new Int16();
            }
            set
            {
                PurchaseRequisitionMasterDTO.PRStatus = value;
            }
        }
        [Display(Name = " Item Name")]
        public string ItemName
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.ItemName : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.ItemName = value;
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
        [Display(Name = "PurchaseRequisitionType")]
        public Int16 PurchaseRequisitionType
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.PurchaseRequisitionType > 0) ? PurchaseRequisitionMasterDTO.PurchaseRequisitionType : new Int16();
            }
            set
            {
                PurchaseRequisitionMasterDTO.PurchaseRequisitionType = value;
            }
        }
        [Display(Name = "PurchaseRequisitionby")]
        public Int16 PurchaseRequisitionBy
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.PurchaseRequisitionBy > 0) ? PurchaseRequisitionMasterDTO.PurchaseRequisitionBy : new Int16();
            }
            set
            {
                PurchaseRequisitionMasterDTO.PurchaseRequisitionBy = value;
            }
        }
        [Display(Name = " Item Name")]
        public string PurchaseRequisitionBehaviour
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PurchaseRequisitionBehaviour : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PurchaseRequisitionBehaviour = value;
            }
        }
        public int ApprovedBy
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.ApprovedBy > 0) ? PurchaseRequisitionMasterDTO.ApprovedBy : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ApprovedBy = value;
            }
        }
        public string ApprovedDate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.ApprovedDate : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.ApprovedDate = value;
            }
        }
        public decimal ApprovedQuantity
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.ApprovedQuantity > 0) ? PurchaseRequisitionMasterDTO.ApprovedQuantity : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ApprovedQuantity = value;
            }
        }
        public string LocationName
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.LocationName : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.LocationName = value;
            }
        }
        public string LocationAddress
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.LocationAddress : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.LocationAddress = value;
            }
        }
        public string City
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.City : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.City = value;
            }
        }
        [Display(Name = "Vendor Address")]
        public string VendorAddress
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.VendorAddress : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.VendorAddress = value;
            }
        }

        [Display(Name = "Vendor Phone Number")]
        public string VendorPhoneNumber
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.VendorPhoneNumber : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.VendorPhoneNumber = value;
            }
        }

        [Display(Name = "Vendor Name")]
        public string VendorName
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.VendorName : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.VendorName = value;
            }
        }

        public Int16 ApprovedStatus
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.ApprovedStatus > 0) ? PurchaseRequisitionMasterDTO.ApprovedStatus : new Int16();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ApprovedStatus = value;
            }
        }
        public decimal MinIndentLevel
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.MinIndentLevel > 0) ? PurchaseRequisitionMasterDTO.MinIndentLevel : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.MinIndentLevel = value;
            }
        }
        public decimal IndendQuantity
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.IndendQuantity > 0) ? PurchaseRequisitionMasterDTO.IndendQuantity : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.IndendQuantity = value;
            }
        }
        [Display(Name = "Delivery Date")]
        public string ExpectedDeliveryDate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.ExpectedDeliveryDate : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.ExpectedDeliveryDate = value;
            }
        }
        public decimal Ammount
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.Ammount > 0) ? PurchaseRequisitionMasterDTO.Ammount : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.Ammount = value;
            }
        }
        public decimal AmmountIncludingTax
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.AmmountIncludingTax > 0) ? PurchaseRequisitionMasterDTO.AmmountIncludingTax : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.AmmountIncludingTax = value;
            }
        }
        public string Vendor
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.Vendor : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.Vendor = value;
            }
        }
        public int VendorID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.VendorID > 0) ? PurchaseRequisitionMasterDTO.VendorID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.VendorID = value;
            }
        }
        public int VendorNumber
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.PurchaseRequisitionMasterID > 0) ? PurchaseRequisitionMasterDTO.VendorNumber : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.VendorNumber = value;
            }
        }
        public string Currency
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.Currency : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.Currency = value;
            }
        }
        [Display(Name = "Automatic PO")]
        public bool IsOpenForPO
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.IsOpenForPO : false;
            }
            set
            {
                PurchaseRequisitionMasterDTO.IsOpenForPO = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.XMLstring : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.XMLstring = value;
            }
        }
        public int ItemCount
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.ItemCount > 0) ? PurchaseRequisitionMasterDTO.ItemCount : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ItemCount = value;
            }
        }
        //Feilds For Policy Applicable
        public int FieldValue
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.FieldValue > 0) ? PurchaseRequisitionMasterDTO.FieldValue : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.FieldValue = value;
            }
        }

        public string PolicyApplicableStatus
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PolicyApplicableStatus : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PolicyApplicableStatus = value;
            }

        }
        public string PolicyDefaultAnswer
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PolicyDefaultAnswer : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PolicyDefaultAnswer = value;
            }

        }
        public string PolicyCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PolicyCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PolicyCode = value;
            }

        }
        public string CenterCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.CenterCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.CenterCode = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "From Sub Location")]
        public int IssueFromLocationID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.IssueFromLocationID > 0) ? PurchaseRequisitionMasterDTO.IssueFromLocationID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.IssueFromLocationID = value;
            }
        }

        [Display(Name = "Tax")]
        public decimal TaxRate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.TaxRate > 0) ? PurchaseRequisitionMasterDTO.TaxRate : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.TaxRate = value;
            }
        }
        public int GenTaxGroupMasterID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.GenTaxGroupMasterID > 0) ? PurchaseRequisitionMasterDTO.GenTaxGroupMasterID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.GenTaxGroupMasterID = value;
            }
        }
        public decimal taxpercentage
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.taxpercentage > 0) ? PurchaseRequisitionMasterDTO.taxpercentage : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.taxpercentage = value;
            }
        }
        [Display(Name = "Unit")]
        public string UnitCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.UnitCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.UnitCode = value;
            }
        }
        public int UnitID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.UnitID > 0) ? PurchaseRequisitionMasterDTO.UnitID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.UnitID = value;
            }
        }
        public decimal GrossAmount
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.GrossAmount > 0) ? PurchaseRequisitionMasterDTO.GrossAmount : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.GrossAmount = value;
            }
        }
             [Display(Name = "Tax Amount")]
        public decimal TaxAmount
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.TaxAmount > 0) ? PurchaseRequisitionMasterDTO.TaxAmount : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.TaxAmount = value;
            }
        }
        public decimal Freight
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.Freight > 0) ? PurchaseRequisitionMasterDTO.Freight : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.Freight = value;
            }
        }
        public decimal ShippingHandling
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.ShippingHandling > 0) ? PurchaseRequisitionMasterDTO.ShippingHandling : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ShippingHandling = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.Discount > 0) ? PurchaseRequisitionMasterDTO.Discount : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.Discount = value;
            }
        }
        public string PrintingLine1
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PrintingLine1 : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PrintingLine1 = value;
            }
        }
        public string PrintingLine2
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PrintingLine2 : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PrintingLine2 = value;
            }
        }
        public string PrintingLine3
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PrintingLine3 : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PrintingLine3 = value;
            }
        }
        public string PrintingLine4
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PrintingLine4 : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PrintingLine4 = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.ItemNumber : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.ItemNumber = value;
            }
        }
        public string BarCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.BarCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.BarCode = value;
            }
        }
        public int GeneralItemCodeID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.GeneralItemCodeID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.GeneralItemCodeID = value;
            }
        }
        public int GeneralUnitsID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.GeneralUnitsID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.GeneralUnitsID = value;
            }
        }
        public decimal BaseUOMQuantity
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.BaseUOMQuantity : new decimal();
            }
            set
            {
                PurchaseRequisitionMasterDTO.BaseUOMQuantity = value;
            }
        }
        public string BaseUOMCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.BaseUOMCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.BaseUOMCode = value;
            }
        }
        public string PurchaseGroupCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.PurchaseGroupCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.PurchaseGroupCode = value;
            }
        }
        public string UnitName
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.UnitName : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.UnitName = value;
            }
        }
        public int VendorPinCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.VendorPinCode > 0) ? PurchaseRequisitionMasterDTO.VendorPinCode : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.VendorPinCode = value;
            }
        }

        public int StatusFlag
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.StatusFlag > 0) ? PurchaseRequisitionMasterDTO.StatusFlag : new short();
            }
            set
            {
                PurchaseRequisitionMasterDTO.StatusFlag = value;
            }
        }

        public string FromUnitName
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.FromUnitName : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.FromUnitName = value;
            }
        }

        public string FromLocationAddress
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.FromLocationAddress : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.FromLocationAddress = value;
            }
        }

        public string FromCity
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.FromCity : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.FromCity = value;
            }
        }

        public string FromPincode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.FromPincode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.FromPincode = value;
            }
        }
        public string TaxGroupName
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.TaxGroupName : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.TaxGroupName = value;
            }
        }
        public bool IsOtherState
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.IsOtherState : false;
            }
            set
            {
                PurchaseRequisitionMasterDTO.IsOtherState = value;
            }
        }

        [Display(Name = "Month")]
        public string MonthName
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.MonthName : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.MonthName = value;
            }
        }
        [Display(Name = "Year")]
        public string MonthYear
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.MonthYear : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.MonthYear = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.FromDate : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.UptoDate : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.UptoDate = value;
            }
        }
        #region -------------- TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.TaskNotificationMasterID > 0) ? PurchaseRequisitionMasterDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.TaskNotificationMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string TaskCode
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.TaskCode : string.Empty;
            }
            set
            {
                PurchaseRequisitionMasterDTO.TaskCode = value;
            }
        }

        public int TaskNotificationDetailsID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.TaskNotificationDetailsID > 0) ? PurchaseRequisitionMasterDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.TaskNotificationDetailsID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.GeneralTaskReportingDetailsID > 0) ? PurchaseRequisitionMasterDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.GeneralTaskReportingDetailsID = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.PersonID > 0) ? PurchaseRequisitionMasterDTO.PersonID : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.PersonID = value;
            }
        }

        public int StageSequenceNumber
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null && PurchaseRequisitionMasterDTO.StageSequenceNumber > 0) ? PurchaseRequisitionMasterDTO.StageSequenceNumber : new int();
            }
            set
            {
                PurchaseRequisitionMasterDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (PurchaseRequisitionMasterDTO != null) ? PurchaseRequisitionMasterDTO.IsLastRecord : false;
            }
            set
            {
                PurchaseRequisitionMasterDTO.IsLastRecord = value;
            }
        }
        #endregion
    }
}
