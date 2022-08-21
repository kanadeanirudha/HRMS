using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class GeneralPreTablesForMainTypeMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string RefTableEntity
        {
            get;
            set;
        }
        public string RefTableEntityKey
        {
            get;
            set;
        }
        public string RefTableEntityDisplayKey
        {
            get;
            set;
        }
        public string MenuCode
        {
            get;
            set;
        }
        public string ModuleCode
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }


        //-------------------Extra Property ---------------------
        public string ModuleName { get; set; }
        public string MenuName { get; set; }
        public string TableName { get; set; }
        public string TablePrimeryKey { get; set; }
        public string DisplayField { get; set; }
    }
}
