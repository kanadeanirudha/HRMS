using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class PurchaseRequirementMaster : BaseDTO
	{
        /// <summary>
        /// Properties for PurchaseRequirementMaster table
        /// </summary>
		public int ID
		{
			get;
			set;
		}
        public int GeneralItemCodeID
		{
			get;
			set;
		}
		public string PurchaseRequirementNumber
		{
			get;
			set;
		}
		public string TransDate
		{
			get;
			set;
		}
        public decimal MinimumOrderquantity
        {
            get;
            set;
        }
		public bool IsActive
		{
			get;
			set;
		}
        public Int16 Status
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
        /// Properties for PurchaseRequirementDetails table
        /// </summary>
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
		public decimal Rate
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
		public int DepartmentID
		{
			get;
			set;
		}
		public int StorageLocationID
		{
			get;
			set;
		}
		public Int16 PriorityFlag
		{
			get;
			set;
		}
        public Int16 ApprovedStatus
		{
			get;
			set;
		}
		public string Remark
		{
			get;
			set;
		}
		public int ApprovedBy
		{
			get;
			set;
		}
		public string ApprovedDate
		{
			get;
			set;
		}
		public decimal ApprovedQuantity
		{
			get;
			set;
		}
		public decimal DeliveredQuantity
		{
			get;
			set;
		}

        public string errorMessage
		{
			get;
			set;
		}
        public string EntityLevel
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string ItemName
        {
            get;
            set;
        }
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
        public string UomCode
        {
            get;
            set;
        }
        public int ItemCount
        {
            get;
            set;
        }
        public string ExpectedDate
        {
            get;
            set;
        }
        public string XMLstring { get; set; }
        public string LocationName
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
        public int UploadExcelID
        {
            get;
            set;
        }
        public string PolicyDefaultAnswerForExcel
        {
            get;
            set;
        }
        public Int16 FinancialYearID { get; set; }
        public string Description
        {
            get;
            set;
        }
        public string PurchaseGroupCode
        {
            get;
            set;
        }

        public bool BlockforProcurutment
        {
            get;
            set;
        }
        

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

