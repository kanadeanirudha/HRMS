using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class Dashboard : BaseDTO
    {
        #region -------------- Dashboard ---------------

        public string ContentCode
        {
            get;
            set;
        }
        public string ContentTitle
        {
            get;
            set;
        }
        public int AdminRoleMasterID
        {
            get;set;
        }
        public int ID
        {
            get;
            set;
        }
        #endregion

        #region ------------------------ Dashboard Allocation---------------------------

        public string AdminRoleCode
        {
            get; set;
        }
        public int DashboardContentDetailsID
        {
            get; set;
        }
        public string ModuleCode
        {
            get; set;
        }
        public string ModuleName
        {
            get; set;
        }
        public int DashboardAllocationID
        {
            get; set;
        }
        public bool ContentStatus
        {
            get; set;
        }
        #endregion
        #region -------------- TaskNotificationMaster ---------------
        public int PersonID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public string TaskDescription
        {
            get;
            set;
        }
        #endregion
        public string errorMessage
        {
            get;
            set;
        }
        public int CreatedBy { get; set; }
        public int? DeletedBy { get; set; }


       
        

        #region -------------- TaskNotificationMaster ---------------

        public int TaskNotificationMasterID
        {
            get;
            set;
        }
        public int ApprovedByUserID
        {
            get;
            set;
        }

        
        public int GeneralTaskReportingMasterID
        {
            get;
            set;
        }
        public string EntitytableName
        {
            get;
            set;
        }
        public string EntityPKName
        {
            get;
            set;
        }
        public int EntityPKValue
        {
            get;
            set;
        }
        
        public string PersonType
        {
            get;
            set;
        }
        public string PersonName
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public int LastApprovalStatus
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
       
        public DateTime? DeletedDate
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

        #region -------------- TaskNotificationDetails ---------------
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
        public int NextGeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public bool IsLastRecordFlag
        {
            get;
            set;
        }
        public int ApprovalStatus
        {
            get;
            set;
        }
        public string MenuCodeLink
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string FormName
        {
            get;
            set;
        }
        public string Lable
        {
            get;
            set;
        }
        public string LableValue
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }
        public int TotalRecords
        {
            get;
            set;
        }
        public int ColumnNumber
        {
            get;
            set;
        }
        public string ApplicationDate
        {
            get;
            set;
        }
      
        public bool IsEngaged
        {
            get;
            set;
        }
        public int EngagedByUserID
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public string TotalfullDaysLeave
        {
            get;
            set;
        }
        public string TotalHalfDayLeave
        {
            get;
            set;
        }
        public string TotalDays
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int LeaveMasterID
        {
            get;
            set;
        }
        public string XMLString
        {
            get;
            set;
        }
     
        public string IssueFromLocation
        {
            get;
            set;
        }
        public string IssueToLocation
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public int IssueOrPurchaseID
        {
            get;
            set;
        }
        public int InvInwardMasterID
        {
            get;
            set;
        }
        public bool IsActiveMember
        {
            get;
            set;
        }
        public string LeaveDescription
        {
            get;
            set;
        }
        public string ApplicationStatus
        {
            get;
            set;
        }
        public string WorkingDate
        {
            get;
            set;
        }

        public string AttendanceDate
        {
            get;
            set;
        }
        public TimeSpan CheckInTime
        {
            get;
            set;
        }
        public TimeSpan CheckOutTime
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }
        public string LeaveAttendanceSpecialDesctiption
        {
            get;
            set;
        }
        public string RequestedDate
        {
            get;
            set;
        }
        #endregion

        #region ------------------------ FSAA Task Properites---------------------------
        public int FeeStructureApplicableHistoryID
        {
            get;
            set;
        }
        public int FeeStructureMasterID
        {
            get;
            set;
        }
        public decimal TotalFeeAmount
        {
            get;
            set;
        }
        public string SectionDescription
        {
            get;
            set;
        }
        public string SessionName
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public string StudentName
        {
            get;
            set;
        }
        public string LeaveType { get; set; }
        public int TotalLeaveDay { get; set; }
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
        public string TransDate
        {
            get;
            set;
        }
        public string Vendor
        {
            get;
            set;
        }

        #endregion

        #region ------------------------ SSA Task Properites---------------------------
        public int ScholarShipAllocationID
        {
            get;
            set;
        }
        public Int16 ApproveStatus
        {
            get;
            set;
        }

        public string ScholarSheepDocumentNumber
        {
            get;
            set;
        }
        public string ScholarShipDescription
        {
            get;
            set;
        }
        #endregion 

        #region ------------------------ AVAR Task Properites---------------------------
        public int AccTransactionMainID
        {
            get;
            set;
        }
        public string Narration
        {
            get;
            set;
        }
        public string VoucherNumber
        {
            get;
            set;
        }
        public decimal Amount
        {
            get;
            set;
        }

        #endregion

        #region ------------------------ ATRA Task Properites---------------------------
        public int AccountTransferRequestID
        {
            get;
            set;
        }
        public string AccountTransferRequestReason
        {
            get;
            set;
        }
        public string AccountTransferRequestStatus
        {
            get;
            set;
        }
        public string AccountName
        {
            get;
            set;
        }
        public Int16 AccountType
        {
            get;
            set;
        }
        public string OldSalesManName
        {
            get;
            set;
        }
        public string RequestedSalesManName
        {
            get;
            set;
        }

        #endregion 

        #region ------------------------ General Request Properites---------------------------
        public int GeneralRequestTransactionID
        {
            get;
            set;
        }
        public string RequestCode
        {
            get;
            set;
        }
        public int FromPersonID
        {
            get;
            set;
        }
        public int PrimaryKeyValue
        {
            get;
            set;
        }
        public Int16 RequestsStatus
        {
            get;
            set;
        }
        public string RequestsMenuCode
        {
            get;
            set;
        }
        public string RequestsLinkMenuCode
        {
            get;
            set;
        }
        public string RequestApprovalBasedTable
        {
            get;
            set;
        }
        public string RequestApprovalParamPrimaryKey
        {
            get;
            set;
        }
        public string RequestDescription
        {
            get;
            set;
        }
        public string FromUserName
        {
            get;
            set;
        }
        #endregion 

        #region ------------------------ Informative Notification Properites---------------------------
        public int NotificationTransactionID
        {
            get;
            set;
        }
        public string SubjectDescription
        {
            get;
            set;
        }
        public string BodyDescription
        {
            get;
            set;
        }
        public Int16 NotificationStatus
        {
            get;
            set;
        }
        #endregion 

      
    }
}
