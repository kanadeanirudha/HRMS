using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class PurchaseRequisitionMaster : BaseDTO
    {
        /// <summary>
        /// Properties for PurchaseRequisitionMaster table
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        public byte SerialAndBatchManagedBy
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public int PurchaseRequirementMasterID
        {
            get;
            set;
        }
        public string Pincode
        {
            get;
            set;
        }
        public string PurchaseRequirementNumber
        {
            get;
            set;
        }
        public string PurchaseRequisitionNumber
        {
            get;
            set;
        }
        public string PurchaseRequisitionBehaviour
        {
            get;
            set;
        }
        public string ReplishmentCode
        {
            get;
            set;
        }
        public string TransDate
        {
            get;
            set;
        }
        public Int16 PurchaseRequisitionType
        {
            get;
            set;
        }
        public Int16 PurchaseRequisitionBy
        {
            get;
            set;
        }
        public string Currency
        {
            get;
            set;
        }
        
        public int VendorID
        {
            get;
            set;
        }
        public string Vendor
        {
            get;
            set;
        }
        public string Convertion
        {
            get;
            set;
        }
        public bool IsOpenForPO
        {
            get;
            set;
        }
        public Int16 PRStatus
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public string FromUnitName
        {
            get;
            set;
        }
        public string FromLocationAddress
        {
            get;
            set;
        }
        public string FromCity
        {
            get;
            set;
        }
        public string FromPincode
        {
            get;
            set;
        }
        /// <summary>
        /// Properties for PurchaseRequisitionDetails table
        /// </summary>
        public int PurchaseRequisitionDetailsID
        {
            get;
            set;
        }
        public int PurchaseRequisitionMasterID
        {
            get;
            set;
        }
        public int PurchaseRequirementDetailsID
        {
            get;
            set;
        }
        
        public int ItemID
        {
            get;
            set;
        }
        public decimal Quantity
        {
            get;
            set;
        }
        public decimal BatchQuantity
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public int StorageLocationID
        {
            get;
            set;
        }
        public string ExpectedDeliveryDate
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
      
        public string ItemName
        {
            get;
            set;
        }
        public Int16 PriorityFlag
        {
            get;
            set;
        }
        public string Priority
        {
            get;
            set;
        }
        public decimal PoQuantityConfirmedByVendor
        {
            get;
            set;
        }

        // policy fields for backdated date or not
        public int FieldValue
        {
            get;
            set;
        }
        public string PolicyApplicableStatus
        {
            get;
            set;
        }
        public string PolicyDefaultAnswer
        {
            get;
            set;
        }
        public string PolicyCode
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CenterCode
        {
            get;
            set;
        }
        public Int16 ApprovedStatus
        {
            get;
            set;
        }
        public decimal ApprovedQuantity
        {
            get;
            set;
        }
        public int ApprovedBy
        {
            get;
            set;
        }
        public int AdminRoleID
        {
            get;
            set;
        }
        public string ApprovedDate
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public string LocationAddress
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public int VendorPinCode
        {
            get;
            set;
        }
        public int VendorNumber
        {
            get;
            set;
        }
        public string VendorName
        {
            get;
            set;
        }
        public string VendorAddress
        {
            get;
            set;
        }
        public string VendorPhoneNumber
        {
            get;
            set;
        }
        public decimal MinIndentLevel { get; set; }
        public decimal IndendQuantity { get; set; }
        public decimal Ammount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public string XMLstring { get; set; }
        public int ItemCount
        {
            get;
            set;
        }
        public int IssueFromLocationID
        {
            get;
            set;
        }
        public decimal TaxRate { get; set; }
        public int GenTaxGroupMasterID { get; set; }
        public decimal taxpercentage { get; set; }
        public int UnitID
        {
            get;
            set;
        }
        public string UnitCode
        {
            get;
            set;
        }
        public decimal AmmountIncludingTax { get; set; }
        public decimal Freight
        {
            get;
            set;
        }
        public decimal ShippingHandling	
        {
            get;
            set;
        }
        public decimal Discount
        {
            get;
            set;
        }
        public decimal ItemWiseTaxAmount
        {
            get;
            set;
        }
        public string PrintingLine1 { get; set; }
        public string PrintingLine2 { get; set; }
        public string PrintingLine3 { get; set; }
        public string PrintingLine4 { get; set; }

        public int ItemNumber
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public string OrderUomCode
        {
            get;
            set;
        }

        public int GeneralItemCodeID
        {
            get;
            set;
        }

        public decimal BaseUOMQuantity
        {
            get;
            set;
        }
        public string BaseUOMCode
        {
            get;
            set;
        }
        public string PurchaseGroupCode
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
        public int StatusFlag
        {
            get;
            set;
        }
        public decimal MinimumOrderquantity
        {
            get;
            set;
        }
        public double UomPurchasePrice
        {
            get;
            set;
        }
        public bool IsDefaultVendor
        {
            get;
            set;
        }
        public string TaxGroupName { get; set; }
        public bool IsOtherState { get; set; }
        public string CurrentStockQtyWithBaseUOM { get; set; }
        public decimal SalesOrderQuantity { get; set; }
        public decimal RequiredSaleQuantity { get; set; }
        public string SaleUoM{ get; set; }
        public string CustomerBranchName { get; set; }
        public string MonthName { get; set; }
        public string MonthYear { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }

        #region ------------TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public int TaskNotificationDetailsID
        {
            get;
            set;
        }
        public int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public int StageSequenceNumber
        {
            get;
            set;
        }
        public bool IsLastRecord
        {
            get;
            set;
        }
        #endregion
    }
}

