using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;


namespace AMS.ViewModel
{
    public class PurchaseReportViewModel : IPurchaseReportViewModel
    {
        public PurchaseReportViewModel()
        {
            PurchaseReportDTO = new PurchaseReport();
            PolicyAnswerByPolicyStatus = new List<GeneralPolicyRules>();
            InventoryPurchaseRequirementListForRequisition = new List<PurchaseReport>();
            PurchaseReportList = new List<PurchaseReport>();
            BelowStocksafetyLevelListForRequisition = new List<PurchaseReport>();
        }
        public List<PurchaseReport> InventoryPurchaseRequirementListForRequisition { get; set; }
        public List<PurchaseReport> BelowStocksafetyLevelListForRequisition { get; set; }
        public List<PurchaseReport> PurchaseReportList { get; set; }
        public PurchaseReport PurchaseReportDTO { get; set; }
        public List<GeneralPolicyRules> PolicyAnswerByPolicyStatus { get; set; }
        /// <summary>
        /// Properties for PurchaseReport table
        /// </summary>
        public int ID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.ID > 0) ? PurchaseReportDTO.ID : new int();
            }
            set
            {
                PurchaseReportDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Requirement No. should not be blank.")]
        [Display(Name = "Requirement No.")]
        public string PurchaseRequirementNumber
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PurchaseRequirementNumber : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PurchaseRequirementNumber = value;
            }
        }
        [Display(Name = "Conversion")]
        public string Convertion
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.Convertion : string.Empty;
            }
            set
            {
                PurchaseReportDTO.Convertion = value;
            }
        }
        [Required(ErrorMessage = "Requisition No. should not be blank.")]
        [Display(Name = "Requisition No.")]
        public string PurchaseRequisitionNumber
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PurchaseRequisitionNumber : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PurchaseRequisitionNumber = value;
            }
        }
        [Required(ErrorMessage = "Transaction Date should not be blank.")]
        [Display(Name = " Transaction Date")]
        public string TransDate
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.TransDate : string.Empty;
            }
            set
            {
                PurchaseReportDTO.TransDate = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.CreatedBy > 0) ? PurchaseReportDTO.CreatedBy : new short();
            }
            set
            {
                PurchaseReportDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseReportDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.ModifiedBy > 0) ? PurchaseReportDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseReportDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseReportDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.IsDeleted : false;
            }
            set
            {
                PurchaseReportDTO.IsDeleted = value;
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
                return (PurchaseReportDTO != null && PurchaseReportDTO.PurchaseRequirementDetailsID > 0) ? PurchaseReportDTO.PurchaseRequirementDetailsID : new int();
            }
            set
            {
                PurchaseReportDTO.PurchaseRequirementDetailsID = value;
            }
        }

        public int PurchaseRequirementMasterID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.PurchaseRequirementMasterID > 0) ? PurchaseReportDTO.PurchaseRequirementMasterID : new int();
            }
            set
            {
                PurchaseReportDTO.PurchaseRequirementMasterID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.ItemID > 0) ? PurchaseReportDTO.ItemID : new int();
            }
            set
            {
                PurchaseReportDTO.ItemID = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.Quantity > 0) ? PurchaseReportDTO.Quantity : new decimal();
            }
            set
            {
                PurchaseReportDTO.Quantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.Rate > 0) ? PurchaseReportDTO.Rate : new decimal();
            }
            set
            {
                PurchaseReportDTO.Rate = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.DepartmentID > 0) ? PurchaseReportDTO.DepartmentID : new int();
            }
            set
            {
                PurchaseReportDTO.DepartmentID = value;
            }
        }
        [Display(Name = "Department ")]
        public string DepartmentName
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.DepartmentName : string.Empty;
            }
            set
            {
                PurchaseReportDTO.DepartmentName = value;
            }
        }
        [Display(Name = "Storage Location")]
        public int StorageLocationID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.StorageLocationID > 0) ? PurchaseReportDTO.StorageLocationID : new int();
            }
            set
            {
                PurchaseReportDTO.StorageLocationID = value;
            }
        }
        [Display(Name = "Priority")]
        public Int16 PriorityFlag
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.PriorityFlag > 0) ? PurchaseReportDTO.PriorityFlag : new Int16();
            }
            set
            {
                PurchaseReportDTO.PriorityFlag = value;
            }
        }
        public string Priority
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.Priority : string.Empty;
            }
            set
            {
                PurchaseReportDTO.Priority = value;
            }
        }
        public Int16 PRStatus
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.PRStatus > 0) ? PurchaseReportDTO.PRStatus : new Int16();
            }
            set
            {
                PurchaseReportDTO.PRStatus = value;
            }
        }
        [Display(Name = " Item Name")]
        public string ItemName
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.ItemName : string.Empty;
            }
            set
            {
                PurchaseReportDTO.ItemName = value;
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
                return (PurchaseReportDTO != null && PurchaseReportDTO.PurchaseRequisitionType > 0) ? PurchaseReportDTO.PurchaseRequisitionType : new Int16();
            }
            set
            {
                PurchaseReportDTO.PurchaseRequisitionType = value;
            }
        }
        [Display(Name = "PurchaseRequisitionby")]
        public Int16 PurchaseRequisitionBy
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.PurchaseRequisitionBy > 0) ? PurchaseReportDTO.PurchaseRequisitionBy : new Int16();
            }
            set
            {
                PurchaseReportDTO.PurchaseRequisitionBy = value;
            }
        }
        [Display(Name = " Item Name")]
        public string PurchaseRequisitionBehaviour
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PurchaseRequisitionBehaviour : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PurchaseRequisitionBehaviour = value;
            }
        }
        public int ApprovedBy
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.ApprovedBy > 0) ? PurchaseReportDTO.ApprovedBy : new int();
            }
            set
            {
                PurchaseReportDTO.ApprovedBy = value;
            }
        }
        public string ApprovedDate
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.ApprovedDate : string.Empty;
            }
            set
            {
                PurchaseReportDTO.ApprovedDate = value;
            }
        }
        public decimal ApprovedQuantity
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.ApprovedQuantity > 0) ? PurchaseReportDTO.ApprovedQuantity : new decimal();
            }
            set
            {
                PurchaseReportDTO.ApprovedQuantity = value;
            }
        }
        public string LocationName
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.LocationName : string.Empty;
            }
            set
            {
                PurchaseReportDTO.LocationName = value;
            }
        }
        public string LocationAddress
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.LocationAddress : string.Empty;
            }
            set
            {
                PurchaseReportDTO.LocationAddress = value;
            }
        }
        public string City
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.City : string.Empty;
            }
            set
            {
                PurchaseReportDTO.City = value;
            }
        }
        [Display(Name = "Vendor Address")]
        public string VendorAddress
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.VendorAddress : string.Empty;
            }
            set
            {
                PurchaseReportDTO.VendorAddress = value;
            }
        }

        [Display(Name = "Vendor Phone Number")]
        public string VendorPhoneNumber
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.VendorPhoneNumber : string.Empty;
            }
            set
            {
                PurchaseReportDTO.VendorPhoneNumber = value;
            }
        }

        [Display(Name = "Vendor Name")]
        public string VendorName
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.VendorName : string.Empty;
            }
            set
            {
                PurchaseReportDTO.VendorName = value;
            }
        }

        public Int16 ApprovedStatus
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.ApprovedStatus > 0) ? PurchaseReportDTO.ApprovedStatus : new Int16();
            }
            set
            {
                PurchaseReportDTO.ApprovedStatus = value;
            }
        }
        public decimal MinIndentLevel
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.MinIndentLevel > 0) ? PurchaseReportDTO.MinIndentLevel : new decimal();
            }
            set
            {
                PurchaseReportDTO.MinIndentLevel = value;
            }
        }
        public decimal IndendQuantity
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.IndendQuantity > 0) ? PurchaseReportDTO.IndendQuantity : new decimal();
            }
            set
            {
                PurchaseReportDTO.IndendQuantity = value;
            }
        }
        [Display(Name = "Delivery Date")]
        public string ExpectedDeliveryDate
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.ExpectedDeliveryDate : string.Empty;
            }
            set
            {
                PurchaseReportDTO.ExpectedDeliveryDate = value;
            }
        }
        public decimal Ammount
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.Ammount > 0) ? PurchaseReportDTO.Ammount : new decimal();
            }
            set
            {
                PurchaseReportDTO.Ammount = value;
            }
        }
        public decimal AmmountIncludingTax
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.AmmountIncludingTax > 0) ? PurchaseReportDTO.AmmountIncludingTax : new decimal();
            }
            set
            {
                PurchaseReportDTO.AmmountIncludingTax = value;
            }
        }
        public string Vendor
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.Vendor : string.Empty;
            }
            set
            {
                PurchaseReportDTO.Vendor = value;
            }
        }
        public int VendorID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.VendorID > 0) ? PurchaseReportDTO.VendorID : new int();
            }
            set
            {
                PurchaseReportDTO.VendorID = value;
            }
        }
        public int VendorNumber
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.PurchaseReportID > 0) ? PurchaseReportDTO.VendorNumber : new int();
            }
            set
            {
                PurchaseReportDTO.VendorNumber = value;
            }
        }
        public string Currency
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.Currency : string.Empty;
            }
            set
            {
                PurchaseReportDTO.Currency = value;
            }
        }
        [Display(Name = "Automatic PO")]
        public bool IsOpenForPO
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.IsOpenForPO : false;
            }
            set
            {
                PurchaseReportDTO.IsOpenForPO = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.XMLstring : string.Empty;
            }
            set
            {
                PurchaseReportDTO.XMLstring = value;
            }
        }
        public int ItemCount
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.ItemCount > 0) ? PurchaseReportDTO.ItemCount : new int();
            }
            set
            {
                PurchaseReportDTO.ItemCount = value;
            }
        }
        //Feilds For Policy Applicable
        public int FieldValue
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.FieldValue > 0) ? PurchaseReportDTO.FieldValue : new int();
            }
            set
            {
                PurchaseReportDTO.FieldValue = value;
            }
        }

        public string PolicyApplicableStatus
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PolicyApplicableStatus : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PolicyApplicableStatus = value;
            }

        }
        public string PolicyDefaultAnswer
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PolicyDefaultAnswer : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PolicyDefaultAnswer = value;
            }

        }
        public string PolicyCode
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PolicyCode : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PolicyCode = value;
            }

        }

        public string CentreCode
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.CentreCode : string.Empty;
            }
            set
            {
                PurchaseReportDTO.CentreCode = value;
            }
        }
        [Display(Name = "From Location")]
        public int IssueFromLocationID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.IssueFromLocationID > 0) ? PurchaseReportDTO.IssueFromLocationID : new int();
            }
            set
            {
                PurchaseReportDTO.IssueFromLocationID = value;
            }
        }

        [Display(Name = "Tax")]
        public decimal TaxRate
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.TaxRate > 0) ? PurchaseReportDTO.TaxRate : new decimal();
            }
            set
            {
                PurchaseReportDTO.TaxRate = value;
            }
        }
        public int GenTaxGroupMasterID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.GenTaxGroupMasterID > 0) ? PurchaseReportDTO.GenTaxGroupMasterID : new int();
            }
            set
            {
                PurchaseReportDTO.GenTaxGroupMasterID = value;
            }
        }
        public decimal taxpercentage
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.taxpercentage > 0) ? PurchaseReportDTO.taxpercentage : new decimal();
            }
            set
            {
                PurchaseReportDTO.taxpercentage = value;
            }
        }
        [Display(Name = "Unit")]
        public string UnitCode
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.UnitCode : string.Empty;
            }
            set
            {
                PurchaseReportDTO.UnitCode = value;
            }
        }
        public int UnitID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.UnitID > 0) ? PurchaseReportDTO.UnitID : new int();
            }
            set
            {
                PurchaseReportDTO.UnitID = value;
            }
        }
        public decimal GrossAmount
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.GrossAmount > 0) ? PurchaseReportDTO.GrossAmount : new decimal();
            }
            set
            {
                PurchaseReportDTO.GrossAmount = value;
            }
        }
        [Display(Name = "Tax Amount")]
        public decimal TaxAmount
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.TaxAmount > 0) ? PurchaseReportDTO.TaxAmount : new decimal();
            }
            set
            {
                PurchaseReportDTO.TaxAmount = value;
            }
        }
        public decimal Freight
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.Freight > 0) ? PurchaseReportDTO.Freight : new decimal();
            }
            set
            {
                PurchaseReportDTO.Freight = value;
            }
        }
        public decimal ShippingHandling
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.ShippingHandling > 0) ? PurchaseReportDTO.ShippingHandling : new decimal();
            }
            set
            {
                PurchaseReportDTO.ShippingHandling = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.Discount > 0) ? PurchaseReportDTO.Discount : new decimal();
            }
            set
            {
                PurchaseReportDTO.Discount = value;
            }
        }
        public string PrintingLine1
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PrintingLine1 : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PrintingLine1 = value;
            }
        }
        public string PrintingLine2
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PrintingLine2 : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PrintingLine2 = value;
            }
        }
        public string PrintingLine3
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PrintingLine3 : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PrintingLine3 = value;
            }
        }
        public string PrintingLine4
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PrintingLine4 : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PrintingLine4 = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.ItemNumber : new int();
            }
            set
            {
                PurchaseReportDTO.ItemNumber = value;
            }
        }
        public string BarCode
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.BarCode : string.Empty;
            }
            set
            {
                PurchaseReportDTO.BarCode = value;
            }
        }
        public int GeneralItemCodeID
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.GeneralItemCodeID : new int();
            }
            set
            {
                PurchaseReportDTO.GeneralItemCodeID = value;
            }
        }
        public decimal BaseUOMQuantity
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.BaseUOMQuantity : new decimal();
            }
            set
            {
                PurchaseReportDTO.BaseUOMQuantity = value;
            }
        }
        public string BaseUOMCode
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.BaseUOMCode : string.Empty;
            }
            set
            {
                PurchaseReportDTO.BaseUOMCode = value;
            }
        }
        public string PurchaseGroupCode
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.PurchaseGroupCode : string.Empty;
            }
            set
            {
                PurchaseReportDTO.PurchaseGroupCode = value;
            }
        }
        public string UnitName
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.UnitName : string.Empty;
            }
            set
            {
                PurchaseReportDTO.UnitName = value;
            }
        }
        public int VendorPinCode
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.VendorPinCode > 0) ? PurchaseReportDTO.VendorPinCode : new int();
            }
            set
            {
                PurchaseReportDTO.VendorPinCode = value;
            }
        }
        #region -------------- TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.TaskNotificationMasterID > 0) ? PurchaseReportDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                PurchaseReportDTO.TaskNotificationMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string TaskCode
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.TaskCode : string.Empty;
            }
            set
            {
                PurchaseReportDTO.TaskCode = value;
            }
        }

        public int TaskNotificationDetailsID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.TaskNotificationDetailsID > 0) ? PurchaseReportDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                PurchaseReportDTO.TaskNotificationDetailsID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.GeneralTaskReportingDetailsID > 0) ? PurchaseReportDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                PurchaseReportDTO.GeneralTaskReportingDetailsID = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.PersonID > 0) ? PurchaseReportDTO.PersonID : new int();
            }
            set
            {
                PurchaseReportDTO.PersonID = value;
            }
        }

        public int StageSequenceNumber
        {
            get
            {
                return (PurchaseReportDTO != null && PurchaseReportDTO.StageSequenceNumber > 0) ? PurchaseReportDTO.StageSequenceNumber : new int();
            }
            set
            {
                PurchaseReportDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.IsLastRecord : false;
            }
            set
            {
                PurchaseReportDTO.IsLastRecord = value;
            }
        }


        public string ReportList
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.ReportList : string.Empty;
            }
            set
            {
                PurchaseReportDTO.ReportList = value;
            }
        }

        public string Months
        {
            get
            {
                return (PurchaseReportDTO != null) ? PurchaseReportDTO.Months : string.Empty;
            }
            set
            {
                PurchaseReportDTO.Months = value;
            }
        }
        #endregion
    }
}
