using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class UserModuleMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string ModuleCode
        {
            get;
            set;
        }
        public string ModuleName
        {
            get;
            set;
        }
        public bool ModuleInstalledFlag
        {
            get;
            set;
        }
        public bool ModuleActiveFlag
        {
            get;
            set;
        }
        public bool ModuleSeqNumber
        {
            get;
            set;
        }
        public string ModuleRelatedWith
        {
            get;
            set;
        }
        public string ModuleTooltip
        {
            get;
            set;
        }
        public string ModuleIconName
        {
            get;
            set;
        }
        public string ModuleIconPath
        {
            get;
            set;
        }
        public string ModuleFormName
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
        public int AdminRoleMasterID
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
    }
}
