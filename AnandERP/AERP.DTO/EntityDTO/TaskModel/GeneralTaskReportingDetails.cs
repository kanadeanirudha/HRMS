using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class GeneralTaskReportingDetails : BaseDTO
	{
        //-------------------------------GeneralTaskReportingMaster ------------------------------------
		public int ID
		{
			get;
			set;
		}
		public string TaskCode
		{
			get;
			set;
		}

        public string HODAuthorizedEmployeeName
        {
            get;set;
        }
        public int HODAuthorizedEmployeeID
        {
            get;set;
        }
        public int HODAuthorizedEmployeeRoleID
        {
            get;set;
        }

        public int NumberOfApprovalStages
		{
			get;
			set;
		}
		public string CentreCode
		{
			get;
			set;
		}
        public string CentreName
		{
			get;
			set;
		}
        public string TaskDescription
		{
			get;
			set;
		}
		public string TaskApprovalBasedTable
		{
			get;
			set;
		}
        public string TaskApprovalTableDisplayField{get;set;}
		public string TaskApprovalParamPrimaryKey
		{
			get;
			set;
		}
		public int TaskApprovalKeyValue
		{
			get;
			set;
		}
		public string ApprovalType
		{
			get;
			set;
		}
		public bool IsActive
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

        //-------------------------------GeneralTaskReportingDetails  ------------------------------------
        public int GeneralTaskReportingDetailsID
		{
			get;
			set;
		}
		public int StageSequenceNumber
		{
			get;
			set;
		}
		public int IsParallel
		{
			get;
			set;
		}
		public int TaskReportingRoleID
		{
			get;
			set;
		}

        public int LastReportingRoleID
        {
            get;
            set;
        }

        public int RangeFrom
		{
			get;
			set;
		}
		public int RangeUpto
		{
			get;
			set;
		}
		public string RoleCentreCode
		{
			get;
			set;
		}
		public int TaskAutoEscalationTime
		{
			get;
			set;
		}
		public string TaskAutoEscalationFlag
		{
			get;
			set;
		}
		public string UnitSpan
		{
			get;
			set;
		}
		public bool IsLastStage
		{
			get;
			set;
		}

        //-------------------------------GeneralTaskIntiatedDetails  ------------------------------------  
        public int GeneralTaskIntiatedDetailsID
		{
			get;
			set;
		}
		public int DepartmentID
		{
			get;
			set;
		}

        public string errorMessage { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeName { get; set; }

        public string LastReportingEmployeeName { get; set; }
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string EntityLevel { get; set; }
        public string DisplayField { get; set; }
        public string KeyValueXmlString { get; set; }
        public string SelectedApprovalStageDetailsXMLstring { get; set; }
        public bool StatusFlag { get; set; }
        public int GeneralTaskReportingMasterID
		{
			get;
			set;
		}
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
        public string TaskApprovalTableDisplayFieldValue { get; set; }
        public int TaskNotificationDetailsID { get; set; }
        public int TaskNotificationMasterID { get; set; }

        public int TotalPendingRequest
        {
            get;
            set;
        }
	}
}

