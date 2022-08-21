using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralRequestMasterViewModel
    {
        GeneralRequestMaster GeneralRequestMasterDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        string RequestCode
        {
            get;
            set;
        }

        string RequestDescription
        {
            get;
            set;
        }
        string MenuCode
        {
            get;
            set;
        }
        string RequestApprovalBasedTable
        {
            get;
            set;
        }
        string RequestApprovalParamPrimaryKey
        {
            get;
            set;
        }
        string LinkMenuCode
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
        //string MenuCode { get; set; }


        List<GeneralTaskModel> MenuCodeList { get; set; }
        List<GeneralTaskReportingDetails> TaskApprovalBasedTableList { get; set; }
    }

}
