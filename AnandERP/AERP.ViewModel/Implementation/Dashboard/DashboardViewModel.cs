using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class DashboardViewModel : IDashboardViewModel
    {
        public DashboardViewModel()
        {
            DashboardDTO = new Dashboard();
            List<Dashboard> RequestApprovalFieldMasterList = new List<Dashboard>();
            List<Dashboard> GeneralRequestApprovalFieldMasterList = new List<Dashboard>();
            TaskCodeList = new List<Dashboard>();
        }
        public List<Dashboard> TaskCodeList { get; set; }
        public IEnumerable<SelectListItem> TaskCodeListItems { get { return new SelectList(TaskCodeList, "TaskCode", "TaskDescription"); } }
        public List<UserModuleMaster> ModuleList { get; set; }
        public List<Dashboard> DashboardContentList { get; set; }
        
        //public IEnumerable<SelectListItem> TaskCodeListItems { get { return new SelectList(ModuleList, "ModuleCode", "ModuleName"); } }

    

        public List<Dashboard> RequestApprovalFieldMasterList
        {
            get;
            set;
        }

        public List<Dashboard> GeneralRequestApprovalFieldMasterList
        {
            get;
            set;
        }

        #region -------------- Deshboard Allocation ---------------

        public string AdminRoleCode
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.AdminRoleCode : string.Empty;
            }
            set
            {
                DashboardDTO.AdminRoleCode = value;
            }
        }
        public int AdminRoleMasterID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.AdminRoleMasterID > 0) ? DashboardDTO.AdminRoleMasterID : new int();
            }
            set
            {
                DashboardDTO.AdminRoleMasterID = value;
            }
        }

        public int DashboardContentDetailsID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.DashboardContentDetailsID > 0) ? DashboardDTO.DashboardContentDetailsID : new int();
            }
            set
            {
                DashboardDTO.DashboardContentDetailsID = value;
            }
        }
        public string ModuleCode
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.ModuleCode : string.Empty;
            }
            set
            {
                DashboardDTO.ModuleCode = value;
            }
        }
        public string ModuleName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.ModuleName : string.Empty;
            }
            set
            {
                DashboardDTO.ModuleName = value;
            }
        }

        public string ContentTitle
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.ContentTitle : string.Empty;
            }
            set
            {
                DashboardDTO.ContentTitle = value;
            }
        }

        public bool ContentStatus
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.ContentStatus : false;
            }
            set
            {
                DashboardDTO.ContentStatus = value;
            }
        }

        public int DashboardAllocationID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.DashboardAllocationID > 0) ? DashboardDTO.DashboardAllocationID : new int();
            }
            set
            {
                DashboardDTO.DashboardAllocationID = value;
            }
        }
        #endregion
        #region -------------- TaskNotificationMaster ---------------
        public int PersonID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.PersonID > 0) ? DashboardDTO.PersonID : new int();
            }
            set
            {
                DashboardDTO.PersonID = value;
            }
        }

        public string TaskCode
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.TaskCode : string.Empty;
            }
            set
            {
                DashboardDTO.TaskCode = value;
            }
        }
        #endregion

        public Dashboard DashboardDTO
        {
            get;
            set;
        }

      

        #region -------------- TaskNotificationMaster ---------------
        public int TaskNotificationMasterID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.TaskNotificationMasterID > 0) ? DashboardDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                DashboardDTO.TaskNotificationMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
       
        public int GeneralTaskReportingMasterID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.GeneralTaskReportingMasterID > 0) ? DashboardDTO.GeneralTaskReportingMasterID : new int();
            }
            set
            {
                DashboardDTO.GeneralTaskReportingMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_EntitytableName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EntitytableNameRequired")]
        public string EntitytableName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.EntitytableName : string.Empty;
            }
            set
            {
                DashboardDTO.EntitytableName = value;
            }
        }



        //[Display(Name = "DisplayName_EntityPKName", ResourceType = typeof(AMS.Common.Resources))]
        public string EntityPKName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.EntityPKName : string.Empty;
            }
            set
            {
                DashboardDTO.EntityPKName = value;
            }
        }

        public int EntityPKValue
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.EntityPKValue > 0) ? DashboardDTO.EntityPKValue : new int();
            }
            set
            {
                DashboardDTO.EntityPKValue = value;
            }
        }
        

        //[Display(Name = "DisplayName_PersonName", ResourceType = typeof(AMS.Common.Resources))]
        public string PersonName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.PersonName : string.Empty;
            }
            set
            {
                DashboardDTO.PersonName = value;
            }
        }

        //[Display(Name = "DisplayName_PersonType", ResourceType = typeof(AMS.Common.Resources))]
        public string PersonType
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.PersonType : string.Empty;
            }
            set
            {
                DashboardDTO.PersonType = value;
            }
        }

        //[Display(Name = "DisplayName_Status", ResourceType = typeof(AMS.Common.Resources))]
        public string Status
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.Status : string.Empty;
            }
            set
            {
                DashboardDTO.Status = value;
            }
        }

        public int LastApprovalStatus
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.LastApprovalStatus > 0) ? DashboardDTO.LastApprovalStatus : new int();
            }
            set
            {
                DashboardDTO.LastApprovalStatus = value;
            }
        }

        // [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.IsActive : false;
            }
            set
            {
                DashboardDTO.IsActive = value;
            }
        }
        // [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.IsDeleted : false;
            }
            set
            {
                DashboardDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.CreatedBy > 0) ? DashboardDTO.CreatedBy : new int();
            }
            set
            {
                DashboardDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                DashboardDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.ModifiedBy.HasValue) ? DashboardDTO.ModifiedBy : new int();
            }
            set
            {
                DashboardDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.ModifiedDate.HasValue) ? DashboardDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                DashboardDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.DeletedBy.HasValue) ? DashboardDTO.DeletedBy : new int();
            }
            set
            {
                DashboardDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.DeletedDate.HasValue) ? DashboardDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                DashboardDTO.DeletedDate = value;
            }
        }

        
        public string errorMessage { get; set; }

        public int ApplicationID { get; set; }


        public string FormName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.FormName : string.Empty;
            }
            set
            {
                DashboardDTO.FormName = value;
            }
        }

        public string Lable
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.Lable : string.Empty;
            }
            set
            {
                DashboardDTO.Lable = value;
            }
        }

        public string LableValue
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.LableValue : string.Empty;
            }
            set
            {
                DashboardDTO.LableValue = value;
            }
        }

        public bool IsEngaged
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.IsEngaged : false;
            }
            set
            {
                DashboardDTO.IsEngaged = value;
            }
        }

        public int EngagedByUserID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.EngagedByUserID > 0) ? DashboardDTO.EngagedByUserID : new int();
            }
            set
            {
                DashboardDTO.EngagedByUserID = value;
            }
        }
        [Display(Name = "DisplayName_AttendanceDate", ResourceType = typeof(AERP.Common.Resources))]
        public string AttendanceDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.AttendanceDate : string.Empty;
            }
            set
            {
                DashboardDTO.AttendanceDate = value;
            }
        }
        public string RequestedDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.RequestedDate : string.Empty;
            }
            set
            {
                DashboardDTO.RequestedDate = value;
            }
        }
        [Display(Name = "DisplayName_CheckInTime", ResourceType = typeof(AERP.Common.Resources))]
        public TimeSpan CheckInTime
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.CheckInTime : TimeSpan.Zero;
            }
            set
            {
                DashboardDTO.CheckInTime = value;
            }
        }
        [Display(Name = "DisplayName_CheckOutTime", ResourceType = typeof(AERP.Common.Resources))]
        public TimeSpan CheckOutTime
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.CheckOutTime : TimeSpan.Zero;
            }
            set
            {
                DashboardDTO.CheckOutTime = value;
            }
        }
        [Display(Name = "DisplayName_Reason", ResourceType = typeof(AERP.Common.Resources))]
        public string Reason
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.Reason : string.Empty;
            }
            set
            {
                DashboardDTO.Reason = value;
            }
        }
        public string LeaveAttendanceSpecialDesctiption
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.LeaveAttendanceSpecialDesctiption : string.Empty;
            }
            set
            {
                DashboardDTO.LeaveAttendanceSpecialDesctiption = value;
            }
        }
        #endregion

        #region -------------- TaskNotificationDetails ---------------

        public int TaskNotificationDetailsID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.TaskNotificationDetailsID > 0) ? DashboardDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                DashboardDTO.TaskNotificationDetailsID = value;
            }
        }

        public int ApprovedByUserID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.ApprovedByUserID > 0) ? DashboardDTO.ApprovedByUserID : new int();
            }
            set
            {
                DashboardDTO.ApprovedByUserID = value;
            }
        }

        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.GeneralTaskReportingDetailsID > 0) ? DashboardDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                DashboardDTO.GeneralTaskReportingDetailsID = value;
            }
        }
        public int NextGeneralTaskReportingDetailsID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.NextGeneralTaskReportingDetailsID > 0) ? DashboardDTO.NextGeneralTaskReportingDetailsID : new int();
            }
            set
            {
                DashboardDTO.NextGeneralTaskReportingDetailsID = value;
            }
        }
        // [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsLastRecordFlag
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.IsLastRecordFlag : false;
            }
            set
            {
                DashboardDTO.IsLastRecordFlag = value;
            }
        }

        //[Display(Name = "DisplayName_ApprovalStatus", ResourceType = typeof(AERP.Common.Resources))]
        public int ApprovalStatus
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.ApprovalStatus > 0) ? DashboardDTO.ApprovalStatus : new int();
            }
            set
            {
                DashboardDTO.ApprovalStatus = value;
            }
        }

        //[Display(Name = "DisplayName_MenuCodeLink", ResourceType = typeof(AMS.Common.Resources))]
        public string MenuCodeLink
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.MenuCodeLink : string.Empty;
            }
            set
            {
                DashboardDTO.MenuCodeLink = value;
            }
        }

        //[Display(Name = "DisplayName_Description", ResourceType = typeof(AMS.Common.Resources))]
        public string Description
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.Description : string.Empty;
            }
            set
            {
                DashboardDTO.Description = value;
            }
        }
        //[Required(ErrorMessage = "Remark should not be blank")]
        [Display(Name = "DisplayName_Remark", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RemarkRequired")]
        public string Remark
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.Remark : string.Empty;
            }
            set
            {
                DashboardDTO.Remark = value;
            }
        }

        public int TotalRecords
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.TotalRecords > 0) ? DashboardDTO.TotalRecords : new int();
            }
            set
            {
                DashboardDTO.TotalRecords = value;
            }
        }
        public int ColumnNumber
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.ColumnNumber > 0) ? DashboardDTO.ColumnNumber : new int();
            }
            set
            {
                DashboardDTO.ColumnNumber = value;
            }
        }
        public int StageSequenceNumber
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.StageSequenceNumber > 0) ? DashboardDTO.StageSequenceNumber : new int();
            }
            set
            {
                DashboardDTO.StageSequenceNumber = value;
            }
        }

        public bool IsLastRecord
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.IsLastRecord : false;
            }
            set
            {
                DashboardDTO.IsLastRecord = value;
            }
        }
        public string ApplicationDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.ApplicationDate : string.Empty;
            }
            set
            {
                DashboardDTO.ApplicationDate = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.FromDate : string.Empty;
            }
            set
            {
                DashboardDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.UptoDate : string.Empty;
            }
            set
            {
                DashboardDTO.UptoDate = value;
            }
        }
        public string TotalfullDaysLeave
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.TotalfullDaysLeave : string.Empty;
            }
            set
            {
                DashboardDTO.TotalfullDaysLeave = value;
            }
        }
        public string TotalHalfDayLeave
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.TotalHalfDayLeave : string.Empty;
            }
            set
            {
                DashboardDTO.TotalHalfDayLeave = value;
            }
        }
        public string TotalDays
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.TotalDays : string.Empty;
            }
            set
            {
                DashboardDTO.TotalDays = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.CentreCode : string.Empty;
            }
            set
            {
                DashboardDTO.CentreCode = value;
            }
        }
        public int LeaveMasterID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.LeaveMasterID > 0) ? DashboardDTO.LeaveMasterID : new int();
            }
            set
            {
                DashboardDTO.LeaveMasterID = value;
            }
        }
        public string XMLString
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.XMLString : string.Empty;
            }
            set
            {
                DashboardDTO.XMLString = value;
            }
        }
        public string IssueFromLocation
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.IssueFromLocation : string.Empty;
            }
            set
            {
                DashboardDTO.IssueFromLocation = value;
            }
        }
        public string IssueToLocation
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.IssueToLocation : string.Empty;
            }
            set
            {
                DashboardDTO.IssueToLocation = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.TransactionDate : string.Empty;
            }
            set
            {
                DashboardDTO.TransactionDate = value;
            }
        }
        public string LeaveDescription
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.LeaveDescription : string.Empty;
            }
            set
            {
                DashboardDTO.LeaveDescription = value;
            }
        }
        public int IssueOrPurchaseID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.IssueOrPurchaseID > 0) ? DashboardDTO.IssueOrPurchaseID : new int();
            }
            set
            {
                DashboardDTO.IssueOrPurchaseID = value;
            }
        }
        public int InvInwardMasterID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.InvInwardMasterID > 0) ? DashboardDTO.InvInwardMasterID : new int();
            }
            set
            {
                DashboardDTO.InvInwardMasterID = value;
            }
        }
        public bool IsActiveMember
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.IsActiveMember : false;
            }
            set
            {
                DashboardDTO.IsActiveMember = value;
            }
        }
        public string ApplicationStatus
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.ApplicationStatus : string.Empty;
            }
            set
            {
                DashboardDTO.ApplicationStatus = value;
            }
        }
        public string WorkingDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.WorkingDate : string.Empty;
            }
            set
            {
                DashboardDTO.WorkingDate = value;
            }
        }

        #endregion

        #region ------------------------ FSAA Task Properites---------------------------
        public int FeeStructureApplicableHistoryID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.FeeStructureApplicableHistoryID > 0) ? DashboardDTO.FeeStructureApplicableHistoryID : new int();
            }
            set
            {
                DashboardDTO.FeeStructureApplicableHistoryID = value;
            }
        }
        public int FeeStructureMasterID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.FeeStructureMasterID > 0) ? DashboardDTO.FeeStructureMasterID : new int();
            }
            set
            {
                DashboardDTO.FeeStructureMasterID = value;
            }
        }
        public decimal TotalFeeAmount
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.TotalFeeAmount > 0) ? DashboardDTO.TotalFeeAmount : new decimal();
            }
            set
            {
                DashboardDTO.TotalFeeAmount = value;
            }
        }
        public string SectionDescription
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.SectionDescription : string.Empty;
            }
            set
            {
                DashboardDTO.SectionDescription = value;
            }
        }
        public string SessionName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.SessionName : string.Empty;
            }
            set
            {
                DashboardDTO.SessionName = value;
            }
        }
        public int StudentID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.StudentID > 0) ? DashboardDTO.StudentID : new int();
            }
            set
            {
                DashboardDTO.StudentID = value;
            }
        }
        public string StudentName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.StudentName : string.Empty;
            }
            set
            {
                DashboardDTO.StudentName = value;
            }
        }


        ///----------------------------------------------------Extra Property----------------------------------

        public string LeaveType
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.LeaveType : string.Empty;
            }
            set
            {
                DashboardDTO.LeaveType = value;
            }
        }
        public int TotalLeaveDay
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.TotalLeaveDay > 0) ? DashboardDTO.TotalLeaveDay : new int();
            }
            set
            {
                DashboardDTO.TotalLeaveDay = value;
            }
        }
        public string PurchaseRequirementNumber
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.PurchaseRequirementNumber : string.Empty;
            }
            set
            {
                DashboardDTO.PurchaseRequirementNumber = value;
            }
        }
        public string PurchaseRequisitionNumber
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.PurchaseRequisitionNumber : string.Empty;
            }
            set
            {
                DashboardDTO.PurchaseRequisitionNumber = value;
            }
        }
        public string TransDate
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.TransDate : string.Empty;
            }
            set
            {
                DashboardDTO.TransDate = value;
            }
        }
        public string Vendor
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.Vendor : string.Empty;
            }
            set
            {
                DashboardDTO.Vendor = value;
            }
        }


        #endregion

        #region ------------------------ SSA Task Properites---------------------------
        public string ScholarShipDescription
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.ScholarShipDescription : string.Empty;
            }
            set
            {
                DashboardDTO.ScholarShipDescription = value;
            }
        }
        public Int16 ApproveStatus
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.ApproveStatus > 0) ? DashboardDTO.ApproveStatus : new Int16();
            }
            set
            {
                DashboardDTO.ApproveStatus = value;
            }
        }
        #endregion

        #region ------------------------ AVAR Task Properites---------------------------
        public int AccTransactionMainID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.AccTransactionMainID > 0) ? DashboardDTO.AccTransactionMainID : new int();
            }
            set
            {
                DashboardDTO.AccTransactionMainID = value;
            }
        }
        public string Narration
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.Narration : string.Empty;
            }
            set
            {
                DashboardDTO.Narration = value;
            }
        }
        public string VoucherNumber
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.VoucherNumber : string.Empty;
            }
            set
            {
                DashboardDTO.VoucherNumber = value;
            }
        }
        public decimal Amount
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.Amount > 0) ? DashboardDTO.Amount : new decimal();
            }
            set
            {
                DashboardDTO.Amount = value;
            }
        }
        #endregion

        #region ------------------------ ATRA Task Properites---------------------------
        public int AccountTransferRequestID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.AccountTransferRequestID > 0) ? DashboardDTO.AccountTransferRequestID : new int();
            }
            set
            {
                DashboardDTO.AccountTransferRequestID = value;
            }
        }
        public string AccountTransferRequestReason
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.AccountTransferRequestReason : string.Empty;
            }
            set
            {
                DashboardDTO.AccountTransferRequestReason = value;
            }
        }
        public string AccountName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.AccountName : string.Empty;
            }
            set
            {
                DashboardDTO.AccountName = value;
            }
        }
        public string AccountTransferRequestStatus
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.AccountTransferRequestStatus : string.Empty;
            }
            set
            {
                DashboardDTO.AccountTransferRequestStatus = value;
            }
        }
        public Int16 AccountType
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.AccountType > 0) ? DashboardDTO.AccountType : new Int16();
            }
            set
            {
                DashboardDTO.AccountType = value;
            }
        }
        public string OldSalesManName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.OldSalesManName : string.Empty;
            }
            set
            {
                DashboardDTO.OldSalesManName = value;
            }
        }
        public string RequestedSalesManName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.RequestedSalesManName : string.Empty;
            }
            set
            {
                DashboardDTO.RequestedSalesManName = value;
            }
        }

        #endregion

        #region ------------------------ General Request Properites---------------------------
        public int GeneralRequestTransactionID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.GeneralRequestTransactionID > 0) ? DashboardDTO.GeneralRequestTransactionID : new int();
            }
            set
            {
                DashboardDTO.GeneralRequestTransactionID = value;
            }
        }
        public string RequestDescription
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.RequestDescription : string.Empty;
            }
            set
            {
                DashboardDTO.RequestDescription = value;
            }
        }
        public string RequestsLinkMenuCode
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.RequestsLinkMenuCode : string.Empty;
            }
            set
            {
                DashboardDTO.RequestsLinkMenuCode = value;
            }
        }
        public string FromUserName
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.FromUserName : string.Empty;
            }
            set
            {
                DashboardDTO.FromUserName = value;
            }
        }
        public Int16 RequestsStatus
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.RequestsStatus > 0) ? DashboardDTO.RequestsStatus : new Int16();
            }
            set
            {
                DashboardDTO.RequestsStatus = value;
            }
        }
        public int PrimaryKeyValue
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.PrimaryKeyValue > 0) ? DashboardDTO.PrimaryKeyValue : new int();
            }
            set
            {
                DashboardDTO.PrimaryKeyValue = value;
            }
        }
        public string RequestCode
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.RequestCode : string.Empty;
            }
            set
            {
                DashboardDTO.RequestCode = value;
            }
        }

        #endregion

        #region ------------------------ Informative Notification Properites---------------------------
        public int NotificationTransactionID
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.NotificationTransactionID > 0) ? DashboardDTO.NotificationTransactionID : new int();
            }
            set
            {
                DashboardDTO.NotificationTransactionID = value;
            }
        }
        public string SubjectDescription
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.SubjectDescription : string.Empty;
            }
            set
            {
                DashboardDTO.SubjectDescription = value;
            }
        }
        public string BodyDescription
        {
            get
            {
                return (DashboardDTO != null) ? DashboardDTO.BodyDescription : string.Empty;
            }
            set
            {
                DashboardDTO.BodyDescription = value;
            }
        }
        public Int16 NotificationStatus
        {
            get
            {
                return (DashboardDTO != null && DashboardDTO.NotificationStatus > 0) ? DashboardDTO.NotificationStatus : new Int16();
            }
            set
            {
                DashboardDTO.NotificationStatus = value;
            }
        }

        #endregion

        #region -------------- Deshboard Allocation ---------------



        #endregion

    }
}
