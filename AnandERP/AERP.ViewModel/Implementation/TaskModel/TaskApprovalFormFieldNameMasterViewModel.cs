using System;
using System.Collections.Generic;
using System.Linq;
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class TaskApprovalFormFieldNameMasterViewModel : ITaskApprovalFormFieldNameMasterViewModel
    {

        public TaskApprovalFormFieldNameMasterViewModel()
        {
            TaskApprovalFormFieldNameMasterDTO = new TaskApprovalFormFieldNameMaster();
            TaskCodeList = new List<GeneralTaskModel>();
           
        }
        public List<GeneralTaskModel> TaskCodeList { get; set; }
        public IEnumerable<SelectListItem> TaskCodeListItems{ get { return new SelectList(TaskCodeList, "TaskCode", "TaskName"); } }
    
        public TaskApprovalFormFieldNameMaster TaskApprovalFormFieldNameMasterDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null && TaskApprovalFormFieldNameMasterDTO.ID > 0) ? TaskApprovalFormFieldNameMasterDTO.ID : new Int32();
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.ID = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.XMLstring : string.Empty;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.XMLstring = value;
            }
        }
        public Int32 TaskApprovalFormFieldNameDetailsID
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.TaskApprovalFormFieldNameDetailsID : new Int32();
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.TaskApprovalFormFieldNameDetailsID = value;
            }
        }
        //Fields From TaskApprovalFormFieldNameMasterDetails
        public Int32 TaskApprovalFormFieldMasterId
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.TaskApprovalFormFieldMasterId : new Int32();
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.TaskApprovalFormFieldMasterId = value;
            }
        }
        [Required(ErrorMessage = "Form Name should not be blank.")]
        [Display(Name = "Form Name")]
        public string FormName
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.FormName : string.Empty;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.FormName = value;
            }
        }

        [Required(ErrorMessage = "Task Code should not be blank.")]
        [Display(Name = "Task Code")]
        public string TaskCode
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.TaskCode : string.Empty;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.TaskCode = value;
            }
        }
       
        [Required(ErrorMessage = "View Name should not be blank.")]
        [Display(Name = "View Name")]
        public string ViewName
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.ViewName : string.Empty;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.ViewName = value;
            }
        }
        [Required(ErrorMessage = "Insert Update Procedure should not be blank.")]
        [Display(Name = "Procedure")]
        public string InsertUpdateProcedure
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.InsertUpdateProcedure : string.Empty;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.InsertUpdateProcedure = value;
            }
        }
        [Required(ErrorMessage = "LableName should not be blank.")]
        [Display(Name = "LableName")]
        public string LableName         
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.LableName : string.Empty;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.LableName = value;
            }
        }
        [Required(ErrorMessage = "SequenceNumber should not be blank.")]
        [Display(Name = "SequenceNumber")]
        public Int16 SequenceNumber
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.SequenceNumber : new Int16();
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.SequenceNumber = value;
            }
        }
        [Required(ErrorMessage = "ColumnNumber should not be blank.")]
        [Display(Name = "ColumnNumber")]
        public Int16 ColumnNumber
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.ColumnNumber : new Int16();
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.ColumnNumber = value;
            }
        }
        [Required(ErrorMessage = "FieldName should not be blank.")]
        [Display(Name = "FieldName")]
        public String FieldName
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.FieldName : String.Empty;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.FieldName = value;
            }
        }
         [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null && TaskApprovalFormFieldNameMasterDTO.CreatedBy > 0) ? TaskApprovalFormFieldNameMasterDTO.CreatedBy : new int();
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.ModifiedBy : new int();
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.DeletedBy : new int();
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (TaskApprovalFormFieldNameMasterDTO != null) ? TaskApprovalFormFieldNameMasterDTO.IsDeleted : false;
            }
            set
            {
                TaskApprovalFormFieldNameMasterDTO.IsDeleted = value;
            }
        }

        public string errorMessage { get; set; }



       // public object TaskApprovalFormFieldNameDetailsID { get; set; }

        public string TaskApprovalFormFieldNameMasterID { get; set; }
    }
}


