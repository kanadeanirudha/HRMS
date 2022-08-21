using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralPreTablesForMainTypeMasterSearchRequest : Request
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
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }

        public string SearchBy
        {
            get;
            set;
        }

        public string SortDirection
        {
            get;
            set;
        }

        //-------------------Extra Property ---------------------
        public string ModuleName { get; set; }
        public string MenuName { get; set; }
        public string TableName { get; set; }
    }
}
