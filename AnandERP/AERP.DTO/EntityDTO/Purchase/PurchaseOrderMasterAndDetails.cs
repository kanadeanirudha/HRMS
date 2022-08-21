using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class PurchaseOrderMasterAndDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int AdminRoleID
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string Pincode
        {
            get;
            set;
        }
        public int PurchaseRequisitionMasterID
        {
            get;
            set;
        }
        public string PurchaseOrderNumber
        {
            get;
            set;
        }
        public string ReplishmentCode
        {
            get;
            set;
        }
        public string PurchaseOrderDate
        {
            get;
            set;
        }
        public string Currency
        {
            get;
            set;
        }
        public string UnitName
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
        public int VendorID
        {
            get;
            set;
        }
        public int VendorPinCode
        {
            get;
            set;
        }
        public Int16 PurchaseOrderType
        {
            get;
            set;
        }
        public string PurchaseOrderTypeDescription
        {
            get;
            set;
        }
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
        public decimal TotalTaxAmount
        {
            get;
            set;
        }
        public decimal GrossAmount
        {
            get;
            set;
        }
        public decimal TaxAmount
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

        //-------------------Purchase Order Details fields------------------------//
        public int PurchaseOrderDetailsID
        {
            get;
            set;
        }
        public int PurchaseRequisitionDetailsID
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
        public int IssueFromLocationID
        {
            get;
            set;
        }
        public string ExpectedDeliveryDate
        {
            get;
            set;
        }
        public Int16 PriorityFlag
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public decimal Amount
        {
            get;
            set;
        }
        public string Vendor
        {
            get;
            set;
        }
        public bool IsOtherState
        {
            get;set;
        }
        public int ItemCount
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string PurchaseRequisitionNumber
        {
            get;
            set;
        }
        public string PrintingLine1 { get; set; }
        public string PrintingLine2 { get; set; }
        public string PrintingLine3 { get; set; }
        public string PrintingLine4 { get; set; }

        public byte[] Logo
        {
            get;
            set;
        }

        public string LogoType
        {
            get;
            set;
        }
        public string LogoFileSize
        {
            get;
            set;
        }


        public decimal TaxRate { get; set; }
        public int GenTaxGroupMasterID { get; set; }

        //new Itemaster Feilds
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
        public Int16 Status
        {
            get;
            set;
        }
        public byte POStatus
        {
            get;
            set;
        }
        public bool CurrentDatedCheque
        {
            get;
            set;
        }
        public bool CashOnDelivery
        {
            get;
            set;
        }
        public bool Credit
        {
            get;
            set;
        }
        public string LogoPath { get; set; }
        public string TaxGroupName { get; set; }
        public string Convertion { get; set; }
        public string UnitCode { get; set; }
        public string TaxRateList { get; set; }
        public string TaxList { get; set; }
        public string SelectedCentreCode { get; set; }
        public byte WithPORate { get; set; }
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
        public string TransDate
        {
            get;
            set;
        }
        public string XMLstring
        {
            get;
            set;
        }
        public string ApprovedStatus
        {
            get;
            set;
        }
        #endregion
    }
}
