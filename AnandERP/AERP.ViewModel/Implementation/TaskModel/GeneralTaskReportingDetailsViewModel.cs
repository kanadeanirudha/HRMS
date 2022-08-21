using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralTaskReportingDetailsViewModel : IGeneralTaskReportingDetailsViewModel
    {
        public GeneralTaskReportingDetailsViewModel()
        {
            GeneralTaskReportingDetailsDTO = new GeneralTaskReportingDetails();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            TaskApprovalBasedTableList = new List<GeneralTaskReportingDetails>();
            GeneralTaskModelList = new List<GeneralTaskReportingDetails>();
            //TaskApprovalParamPrimaryKeyList= new List<GeneralTaskReportingDetails>();
            //TaskApprovalKeyValueList = new List<GeneralTaskReportingDetails>();
        }
        public List<GeneralTaskReportingDetails> TaskReportingRoleIDsList { get; set; }
        public List<GeneralTaskReportingDetails> OrganisationDepartmentList { get; set; }
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
        public List<GeneralTaskReportingDetails> TaskApprovalBasedTableList
        {
            get;
            set;
        }
        public List<GeneralTaskReportingDetails> GeneralTaskModelList
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGeneralTaskModelListItems
        {
            get
            {
                return new SelectList(GeneralTaskModelList, "TaskCode", "TaskDescription");
            }
        }
        //public List<GeneralTaskReportingDetails> TaskApprovalParamPrimaryKeyList
        //{
        //    get;
        //    set;
        //}
        //public List<GeneralTaskReportingDetails> TaskApprovalKeyValueList
        //{
        //    get;
        //    set;
        //}
        public IEnumerable<SelectListItem> TaskApprovalBasedTableListItems { get { return new SelectList(TaskApprovalBasedTableList, "TableName", "TableName"); } }
        //public IEnumerable<SelectListItem> TaskApprovalParamPrimaryKeyListItems { get { return new SelectList(TaskApprovalParamPrimaryKeyList, "PrimaryKey", "PrimaryKey"); } }
        //public IEnumerable<SelectListItem> TaskApprovalKeyValueListItems { get { return new SelectList(TaskApprovalKeyValueList, "PrimaryKeyValue", "PrimaryKeyValue"); } }
        public GeneralTaskReportingDetails GeneralTaskReportingDetailsDTO
        {
            get;
            set;
        }
        public List<GeneralTaskReportingDetails> TaskApprovalKeyValueList
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListTaskApprovalKeyValue
        {
            get
            {
                return new SelectList(TaskApprovalKeyValueList, "ID", "DisplayField");
            }
        }
        //-------------------------------GeneralTaskReportingMaster ------------------------------------
        public int ID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.ID > 0) ? GeneralTaskReportingDetailsDTO.ID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.ID = value;
            }
        }
        
        [Display(Name = "Task Code")]
        [Required(ErrorMessage = "Task Code Required")]
        public string TaskCode
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.TaskCode : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskCode = value;
            }
        }
        
        [Display(Name = "Number Of Approval Stages")]
        [Required(ErrorMessage = "Number Of Approval Stages Required")]
        public int NumberOfApprovalStages
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.NumberOfApprovalStages > 0) ? GeneralTaskReportingDetailsDTO.NumberOfApprovalStages : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.NumberOfApprovalStages = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.CentreCode = value;
            }
        }
        
        [Display(Name = "Task Approval Based Table")]
        [Required(ErrorMessage = "Task Approval Based Table Required")]
        public string TaskApprovalBasedTable
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.TaskApprovalBasedTable : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskApprovalBasedTable = value;
            }
        }
        [Display(Name = "Task Approval primary Key")]
        [Required(ErrorMessage = "Task Approval primary Key Required")]
        public string TaskApprovalParamPrimaryKey
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.TaskApprovalParamPrimaryKey : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskApprovalParamPrimaryKey = value;
            }
        }
      
        public string TaskApprovalTableDisplayField
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.TaskApprovalTableDisplayField : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskApprovalTableDisplayField = value;
            }
        }
        [Display(Name = "DisplayName_TaskApprovalKeyValue")]


        public int TaskApprovalKeyValue
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.TaskApprovalKeyValue > 0) ? GeneralTaskReportingDetailsDTO.TaskApprovalKeyValue : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskApprovalKeyValue = value;
            }
        }
        [Display(Name = "DisplayName_ApprovalType")]
        public string ApprovalType
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.ApprovalType : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.ApprovalType = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.IsActive : false;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.IsDeleted : false;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.CreatedBy > 0) ? GeneralTaskReportingDetailsDTO.CreatedBy : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.ModifiedBy > 0) ? GeneralTaskReportingDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.DeletedBy > 0) ? GeneralTaskReportingDetailsDTO.DeletedBy : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.DeletedDate = value;
            }
        }

        //-------------------------------GeneralTaskReportingDetails  ------------------------------------
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.GeneralTaskReportingDetailsID > 0) ? GeneralTaskReportingDetailsDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.GeneralTaskReportingDetailsID = value;
            }
        }

        public int LastReportingRoleID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.LastReportingRoleID > 0) ? GeneralTaskReportingDetailsDTO.LastReportingRoleID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.LastReportingRoleID = value;
            }
        }
        public int StageSequenceNumber
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.StageSequenceNumber > 0) ? GeneralTaskReportingDetailsDTO.StageSequenceNumber : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.StageSequenceNumber = value;
            }
        }
        public int IsParallel
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.IsParallel > 0) ? GeneralTaskReportingDetailsDTO.IsParallel : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.IsParallel = value;
            }
        }
        [Display(Name = "Approval Authority")]
        public int TaskReportingRoleID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.TaskReportingRoleID > 0) ? GeneralTaskReportingDetailsDTO.TaskReportingRoleID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskReportingRoleID = value;
            }
        }
        [Display(Name = "Range From")]
        public int RangeFrom
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.RangeFrom > 0) ? GeneralTaskReportingDetailsDTO.RangeFrom : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.RangeFrom = value;
            }
        }
        [Display(Name = "Range Upto")]
        public int RangeUpto
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.RangeUpto > 0) ? GeneralTaskReportingDetailsDTO.RangeUpto : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.RangeUpto = value;
            }
        }
        public string RoleCentreCode
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.RoleCentreCode : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.RoleCentreCode = value;
            }
        }
        public int TaskAutoEscalationTime
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.TaskAutoEscalationTime > 0) ? GeneralTaskReportingDetailsDTO.TaskAutoEscalationTime : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskAutoEscalationTime = value;
            }
        }
        public string TaskAutoEscalationFlag
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.TaskAutoEscalationFlag : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskAutoEscalationFlag = value;
            }
        }
        public string UnitSpan
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.UnitSpan : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.UnitSpan = value;
            }
        }
        public bool IsLastStage
        {
            get;
            set;
        }

        //-------------------------------GeneralTaskIntiatedDetails  ------------------------------------  
        public int GeneralTaskIntiatedDetailsID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.GeneralTaskIntiatedDetailsID > 0) ? GeneralTaskReportingDetailsDTO.GeneralTaskIntiatedDetailsID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.GeneralTaskIntiatedDetailsID = value;
            }
        }
        [Display(Name = "Task Source Department")]
        public int DepartmentID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.DepartmentID > 0) ? GeneralTaskReportingDetailsDTO.DepartmentID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.DepartmentID = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.errorMessage : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.errorMessage = value;
            }
        }
        public string RoleName
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.RoleName : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.RoleName = value;
            }
        }
         [Display(Name = "Department")]
        public string DepartmentName
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.DepartmentName : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.DepartmentName = value;
            }
        }
         [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.EmployeeName : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.EmployeeName = value;
            }
        }

        [Display(Name = "HOD Reporting Manager Name")]
        public string LastReportingEmployeeName
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.LastReportingEmployeeName : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.LastReportingEmployeeName = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.EmployeeID > 0) ? GeneralTaskReportingDetailsDTO.EmployeeID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.EmployeeID = value;
            }
        }
        public int RoleID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.RoleID > 0) ? GeneralTaskReportingDetailsDTO.RoleID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.RoleID = value;
            }
        }

        [Display(Name = "Who will be authorised HOD if applied for leave")]
        public string HODAuthorizedEmployeeName
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.HODAuthorizedEmployeeName : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.HODAuthorizedEmployeeName = value;
            }
        }
        public int HODAuthorizedEmployeeID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.EmployeeID > 0) ? GeneralTaskReportingDetailsDTO.EmployeeID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.EmployeeID = value;
            }
        }
        public int HODAuthorizedEmployeeRoleID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.RoleID > 0) ? GeneralTaskReportingDetailsDTO.RoleID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.RoleID = value;
            }
        }

        public string EntityLevel
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.EntityLevel : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.EntityLevel = value;
            }
        }
        public string TableName
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.TableName : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TableName = value;
            }
        }
        public string PrimaryKey
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.PrimaryKey : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.PrimaryKey = value;
            }
        }
        public string PrimaryKeyValue
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.PrimaryKeyValue : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.PrimaryKeyValue = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.CentreName : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.CentreName = value;
            }
        }
        public string KeyValueXmlString
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.KeyValueXmlString : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.KeyValueXmlString = value;
            }
        }
        public string SelectedApprovalStageDetailsXMLstring
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.SelectedApprovalStageDetailsXMLstring : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.SelectedApprovalStageDetailsXMLstring = value;
            }
        }
        public int GeneralTaskReportingMasterID
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null && GeneralTaskReportingDetailsDTO.GeneralTaskReportingMasterID > 0) ? GeneralTaskReportingDetailsDTO.GeneralTaskReportingMasterID : new int();
            }
            set
            {
                GeneralTaskReportingDetailsDTO.GeneralTaskReportingMasterID = value;
            }
        }
        public string TaskDescription
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.TaskDescription : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskDescription = value;
            }
        }
        public string TaskApprovalTableDisplayFieldValue
        {
            get
            {
                return (GeneralTaskReportingDetailsDTO != null) ? GeneralTaskReportingDetailsDTO.TaskApprovalTableDisplayFieldValue : string.Empty;
            }
            set
            {
                GeneralTaskReportingDetailsDTO.TaskApprovalTableDisplayFieldValue = value;
            }
        }
    }
}
