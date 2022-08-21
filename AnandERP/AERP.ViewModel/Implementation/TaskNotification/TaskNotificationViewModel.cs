using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class TaskNotificationViewModel
    {
        public TaskNotificationViewModel()
        {
            TaskNotificationDTO = new TaskNotification();
            List<TaskNotification> RequestApprovalFieldMasterList = new List<TaskNotification>();
            List<TaskNotification> GeneralRequestApprovalFieldMasterList = new List<TaskNotification>();
            TaskCodeList = new List<Dashboard>();
        }
        public List<Dashboard> TaskCodeList { get; set; }
        public IEnumerable<SelectListItem> TaskCodeListItems { get { return new SelectList(TaskCodeList, "TaskCode", "TaskDescription"); } }
        public List<UserModuleMaster> ModuleList { get; set; }
        public List<TaskNotification> TaskNotificationContentList { get; set; }

        //public IEnumerable<SelectListItem> TaskCodeListItems { get { return new SelectList(ModuleList, "ModuleCode", "ModuleName"); } }

        public TaskNotification TaskNotificationDTO
        {
            get;
            set;
        }

        public List<TaskNotification> RequestApprovalFieldMasterList
        {
            get;
            set;
        }

        public List<TaskNotification> GeneralRequestApprovalFieldMasterList
        {
            get;
            set;
        }

        #region -------------- Deshboard Allocation ---------------

        public string AdminRoleCode
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.AdminRoleCode : string.Empty;
            }
            set
            {
                TaskNotificationDTO.AdminRoleCode = value;
            }
        }
        public int AdminRoleMasterID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.AdminRoleMasterID > 0) ? TaskNotificationDTO.AdminRoleMasterID : new int();
            }
            set
            {
                TaskNotificationDTO.AdminRoleMasterID = value;
            }
        }

        public int TaskNotificationContentDetailsID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.TaskNotificationContentDetailsID > 0) ? TaskNotificationDTO.TaskNotificationContentDetailsID : new int();
            }
            set
            {
                TaskNotificationDTO.TaskNotificationContentDetailsID = value;
            }
        }
        public string ModuleCode
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.ModuleCode : string.Empty;
            }
            set
            {
                TaskNotificationDTO.ModuleCode = value;
            }
        }
        public string ModuleName
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.ModuleName : string.Empty;
            }
            set
            {
                TaskNotificationDTO.ModuleName = value;
            }
        }

        public string ContentTitle
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.ContentTitle : string.Empty;
            }
            set
            {
                TaskNotificationDTO.ContentTitle = value;
            }
        }

        public bool ContentStatus
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.ContentStatus : false;
            }
            set
            {
                TaskNotificationDTO.ContentStatus = value;
            }
        }

        public int TaskNotificationAllocationID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.TaskNotificationAllocationID > 0) ? TaskNotificationDTO.TaskNotificationAllocationID : new int();
            }
            set
            {
                TaskNotificationDTO.TaskNotificationAllocationID = value;
            }
        }
        #endregion
        #region -------------- TaskNotificationMaster ---------------
        public int PersonID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.PersonID > 0) ? TaskNotificationDTO.PersonID : new int();
            }
            set
            {
                TaskNotificationDTO.PersonID = value;
            }
        }

        public string TaskCode
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.TaskCode : string.Empty;
            }
            set
            {
                TaskNotificationDTO.TaskCode = value;
            }
        }
        #endregion

        public string PurchaseRequirementNumber
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.PurchaseRequirementNumber : string.Empty;
            }
            set
            {
                TaskNotificationDTO.PurchaseRequirementNumber = value;
            }
        }
        public string PurchaseRequisitionNumber
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.PurchaseRequisitionNumber : string.Empty;
            }
            set
            {
                TaskNotificationDTO.PurchaseRequisitionNumber = value;
            }
        }
        public string TransDate
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.TransDate : string.Empty;
            }
            set
            {
                TaskNotificationDTO.TransDate = value;
            }
        }
        public int ApprovalStatus
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.ApprovalStatus > 0) ? TaskNotificationDTO.ApprovalStatus : new int();
            }
            set
            {
                TaskNotificationDTO.ApprovalStatus = value;
            }
        }

        //[Display(Name = "DisplayName_MenuCodeLink", ResourceType = typeof(AMS.Common.Resources))]
        public string MenuCodeLink
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.MenuCodeLink : string.Empty;
            }
            set
            {
                TaskNotificationDTO.MenuCodeLink = value;
            }
        }

        //[Display(Name = "DisplayName_Description", ResourceType = typeof(AMS.Common.Resources))]
        public string TaskDescription
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.TaskDescription : string.Empty;
            }
            set
            {
                TaskNotificationDTO.TaskDescription = value;
            }
        }

        public string Remark
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.Remark : string.Empty;
            }
            set
            {
                TaskNotificationDTO.Remark = value;
            }
        }

        public int TotalRecords
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.TotalRecords > 0) ? TaskNotificationDTO.TotalRecords : new int();
            }
            set
            {
                TaskNotificationDTO.TotalRecords = value;
            }
        }
        public int ColumnNumber
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.ColumnNumber > 0) ? TaskNotificationDTO.ColumnNumber : new int();
            }
            set
            {
                TaskNotificationDTO.ColumnNumber = value;
            }
        }
        public int StageSequenceNumber
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.StageSequenceNumber > 0) ? TaskNotificationDTO.StageSequenceNumber : new int();
            }
            set
            {
                TaskNotificationDTO.StageSequenceNumber = value;
            }
        }
        public int TaskNotificationMasterID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.TaskNotificationMasterID > 0) ? TaskNotificationDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                TaskNotificationDTO.TaskNotificationMasterID = value;
            }
        }

        public int GeneralTaskReportingMasterID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.GeneralTaskReportingMasterID > 0) ? TaskNotificationDTO.GeneralTaskReportingMasterID : new int();
            }
            set
            {
                TaskNotificationDTO.GeneralTaskReportingMasterID = value;
            }
        }
        public int TaskNotificationDetailsID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.TaskNotificationDetailsID > 0) ? TaskNotificationDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                TaskNotificationDTO.TaskNotificationDetailsID = value;
            }
        }

        public int ApprovedByUserID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.ApprovedByUserID > 0) ? TaskNotificationDTO.ApprovedByUserID : new int();
            }
            set
            {
                TaskNotificationDTO.ApprovedByUserID = value;
            }
        }

        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.GeneralTaskReportingDetailsID > 0) ? TaskNotificationDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                TaskNotificationDTO.GeneralTaskReportingDetailsID = value;
            }
        }
        public bool IsLastRecordFlag
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.IsLastRecordFlag : false;
            }
            set
            {
                TaskNotificationDTO.IsLastRecordFlag = value;
            }
        }
        public string ApplicationDate
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.ApplicationDate : string.Empty;
            }
            set
            {
                TaskNotificationDTO.ApplicationDate = value;
            }
        }
        public string Vendor
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.Vendor : string.Empty;
            }
            set
            {
                TaskNotificationDTO.Vendor = value;
            }
        }
        public bool IsEngaged
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.IsEngaged : false;
            }
            set
            {
                TaskNotificationDTO.IsEngaged = value;
            }
        }

        public int EngagedByUserID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.EngagedByUserID > 0) ? TaskNotificationDTO.EngagedByUserID : new int();
            }
            set
            {
                TaskNotificationDTO.EngagedByUserID = value;
            }
        }
        public string SectionDescription
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.SectionDescription : string.Empty;
            }
            set
            {
                TaskNotificationDTO.SectionDescription = value;
            }
        }
        public string SessionName
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.SessionName : string.Empty;
            }
            set
            {
                TaskNotificationDTO.SessionName = value;
            }
        }
        public int StudentID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.StudentID > 0) ? TaskNotificationDTO.StudentID : new int();
            }
            set
            {
                TaskNotificationDTO.StudentID = value;
            }
        }
        public string StudentName
        {
            get
            {
                return (TaskNotificationDTO != null) ? TaskNotificationDTO.StudentName : string.Empty;
            }
            set
            {
                TaskNotificationDTO.StudentName = value;
            }
        }
        public int FeeStructureApplicableHistoryID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.FeeStructureApplicableHistoryID > 0) ? TaskNotificationDTO.FeeStructureApplicableHistoryID : new int();
            }
            set
            {
                TaskNotificationDTO.FeeStructureApplicableHistoryID = value;
            }
        }
        public int FeeStructureMasterID
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.FeeStructureMasterID > 0) ? TaskNotificationDTO.FeeStructureMasterID : new int();
            }
            set
            {
                TaskNotificationDTO.FeeStructureMasterID = value;
            }
        }
        public decimal TotalFeeAmount
        {
            get
            {
                return (TaskNotificationDTO != null && TaskNotificationDTO.TotalFeeAmount > 0) ? TaskNotificationDTO.TotalFeeAmount : new decimal();
            }
            set
            {
                TaskNotificationDTO.TotalFeeAmount = value;
            }
        }


    }
}
