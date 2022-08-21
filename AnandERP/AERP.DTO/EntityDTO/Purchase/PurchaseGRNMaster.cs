using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class PurchaseGRNMaster : BaseDTO
	{
        /// <summary>
        /// Properties for PurchaseGRNMaster table
        /// </summary>
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
        public int PurchaseOrderMasterID
        {
            get;
            set;
        }
        public int PurchaseOrderDetailID
        {
            get;
            set;
        }
        public string PurchaseOrderNumber
        {
            get;
            set;
        }
        public string PurchaseOrderDate
        {
            get;
            set;
        }
        public string LocationAddress
        {
            get;
            set;
        }
        public string Pincode
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string GRNNumber
		{
			get;
			set;
		}
        public bool Received { get; set; }
        public string GRNTransDate
        {
            get;
            set;
        }
        public bool IsLocked
        {
            get;
            set;
        }
        public string Vender
        {
            get;
            set;
        }
        public bool FOC
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
      
        /// <summary>
        /// Properties for PurchaseGRNDetails table
        /// </summary>
        public int PurchaseGRNDetailsID
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
        public decimal FOCReceivedQuantity
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
        public decimal ReceivedQuantity
		{
			get;
			set;
		}
        public decimal RemainingQuantity
        {
            get;
            set;
        }


        public int ReceivingLocationID
		{
			get;
			set;
		}
        public int StorageLocationID
        {
            get;
            set;
        }
        public string XMLstring { get; set; }
        public string XMLstringForVouchar { get; set; }
        public string StorageLocationName
        {
            get;
            set;
        }
        public string ReceivingLocationName
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }
        public bool Isexpiry
        {
            get;
            set;
        }
        public int BatchID
        {
            get;
            set;
        }
        public decimal BatchQuantity
        {
            get;
            set;
        }
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
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

        //New Itemmaster Feilds
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
        public byte SerialAndBatchManagedBy
        {
            get;
            set;
        }
        public decimal LockedGRNQuantity
        {
            get;
            set;
        }
        public bool GRNIsLockedStatusFlag
        {
            get;
            set;
        }
        public bool IsCompletePO
        {
            get;
            set;
        }
        public decimal DamagedQuantity
        {
            get;
            set;
        }
        public decimal GrossAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Freight { get; set; }
        public decimal ShippingHandling { get; set; }
        public string ShelfLife
        {
            get;
            set;
        }
        public string RemainingShelfLife
        {
            get;
            set;
        }
        public int VendorID
        {
            get;
            set;
        }
        public bool ReturnGoods
        {
            get;
            set;
        }

        //GRN PDF
        public string PrintingLine1 { get; set; }
        public string PrintingLine2 { get; set; }
        public string PrintingLine3 { get; set; }
        public string PrintingLine4 { get; set; }

        public string LogoPath
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
        public int VendorPinCode
        {
            get;
            set;
        }
        public string Currency
        {
            get;
            set;
        }
        public string PurchaseRequisitionNumber
        {
            get;
            set;
        }
        public string ExpectedDeliveryDate
        {
            get;
            set;
        }
        public decimal GRNAmount { get; set; }
        public decimal POAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal OrderQuantity
        {
            get;
            set;
        }
        public int PurchaseOrderType
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        
        // For PDF Location address
        public string ToUnitName
        {
            get;
            set;
        }
        public string ToCity
        {
            get;
            set;
        }
        public string Topincode
        {
            get;
            set;
        }
        public string ToLocationAddress
        {
            get;
            set;
        }
        public string ToLocationName
        {
            get;
            set;
        }
        public string FromLocationName
        {
            get;
            set;
        }
        public string FromUnitName
        {
            get;
            set;
        }
        public string FromCity
        {
            get;
            set;
        }
        public string Frompincode
        {
            get;
            set;
        }
        public string FromLocationAddress
        {
            get;
            set;
        }
        public string MonthName { get; set; }
        public string MonthYear { get; set; }
    }
}

