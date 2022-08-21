using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralItemMerchantiseDepartmentViewModel
    {
        GeneralItemMerchantiseDepartment GeneralItemMerchantiseDepartmentDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        string MerchantiseDepartmentName
        {
            get;
            set;
        }

        string MerchantiseDepartmentCode
        {
            get;
            set;
        }

        bool IsDeleted
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
        string errorMessage { get; set; }
    }
}
