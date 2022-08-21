
using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface ISupplierPayementMasterViewModel
    {
        SupplierPayementMaster SupplierPayementMasterDTO
        {
            get;
            set;
        }

        int ID
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
