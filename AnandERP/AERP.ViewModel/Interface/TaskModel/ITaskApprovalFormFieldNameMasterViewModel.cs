using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface ITaskApprovalFormFieldNameMasterViewModel
    {
        TaskApprovalFormFieldNameMaster TaskApprovalFormFieldNameMasterDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        string FormName
        {
            get;
            set;
        }

        string TaskCode
        {
            get;
            set;
        }
        string ViewName
        {
            get;
            set;
        }
        string InsertUpdateProcedure
        {
            get;
            set;
        }
        
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        string errorMessage { get; set; }
        List<GeneralTaskModel>TaskCodeList { get; set; }
    }
}
