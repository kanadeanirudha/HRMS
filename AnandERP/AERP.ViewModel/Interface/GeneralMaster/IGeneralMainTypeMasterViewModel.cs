using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralMainTypeMasterViewModel
    {
        GeneralMainTypeMaster GeneralMainTypeMasterDTO
        {
            get;
            set;
        }
        //GeneralMainTypeMaster Table Property.
        int ID { get; set; }
        string TypeDesc { get; set; }
        string TypeShortDesc { get; set; }
        string RefTableEntity { get; set; }
        string RefTableEntityKey { get; set; }
        string MenuCode { get; set; }
        string ModuleCode { get; set; }

        //GeneralSubTypeMaster Table Property.
        int GeneralSubTypeMasterID { get; set; }
        int GeneralMainTypeMasterID { get; set; }
        string SubTypeDesc { get; set; }
        string SubShortDesc { get; set; }
        int AccountID { get; set; }        
        string RefTableEntityKeyValue { get; set; }
        string KeyCode { get; set; }
        int PersonTypeID { get; set; }


        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
        string errorMessage { get; set; }

        //Extra Property
        string TransactionType { get; set; }
    }
}
