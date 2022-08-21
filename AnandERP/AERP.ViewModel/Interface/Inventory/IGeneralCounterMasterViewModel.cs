using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralCounterMasterViewModel
    {
        GeneralCounterMaster GeneralCounterMasterDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        string CounterName
        {
            get;
            set;
        }

        string CounterCode
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
    }
}
