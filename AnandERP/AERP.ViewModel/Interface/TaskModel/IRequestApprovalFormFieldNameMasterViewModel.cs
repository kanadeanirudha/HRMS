using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IRequestApprovalFormFieldNameMasterViewModel
    {
        RequestApprovalFormFieldNameMaster RequestApprovalFormFieldNameMasterDTO
        {
            get;
            set;
        }

        Int32 RequestApprovalFormFieldNameMasterID
        {
            get;
            set;
        }
        string FormName
        {
            get;
            set;
        }

        string RequestCode
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
        List<GeneralRequestMaster> RequestCodeList { get; set; }
    }
}
