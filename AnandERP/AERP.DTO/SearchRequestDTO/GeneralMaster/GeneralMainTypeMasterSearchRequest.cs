using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralMainTypeMasterSearchRequest : Request
    {
        //GeneralMainTypeMaster Table Property.
        public int ID { get; set; }
        public string TypeDesc { get; set; }
        public string TypeShortDesc { get; set; }
        public string RefTableEntity { get; set; }
        public string RefTableEntityKey { get; set; }
        public string MenuCode { get; set; }
        public string ModuleCode { get; set; }

        //GeneralSubTypeMaster Table Property.
        public int GeneralSubTypeMasterID { get; set; }
        public int GeneralMainTypeMasterID { get; set; }
        public string SubTypeDesc { get; set; }
        public string SubShortDesc { get; set; }
        public int AccountID { get; set; }
        public int TransactionTypeID { get; set; }
        public string RefTableEntityKeyValue { get; set; }
        public string KeyCode { get; set; }
        public int PersonTypeID { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }

        //Extra Property.
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }

       
        public string TransactionType { get; set; }
        public string MenuName { get; set; }
        public string ModuleName { get; set; }
    }
}
