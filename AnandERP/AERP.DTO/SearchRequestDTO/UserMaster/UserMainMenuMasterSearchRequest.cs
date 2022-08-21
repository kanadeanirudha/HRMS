using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class UserMainMenuMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int ModuleID
        {
            get;
            set;
        }
        public string ModuleName
        {
            get;
            set;
        }
        public string ModuleCode
        {
            get;
            set;
        }
        public string MenuCode
        {
            get;
            set;
        }
        public string MenuName
        {
            get;
            set;
        }
     
        public int ParentMenuID
        {
            get;
            set;
        }
        public int MenuDisplaySeqNo
        {
            get;
            set;
        }
        public string MenuVerNo
        {
            get;
            set;
        }
        public bool MenuInstalledFlag
        {
            get;
            set;
        }
        public string MenuLink
        {
            get;
            set;
        }
        public bool IsEnable
        {
            get;
            set;
        }
        public DateTime DisableDate
        {
            get;
            set;
        }
        public string RemarkAboutDisable
        {
            get;
            set;
        }
        public string MenuToolTip
        {
            get;
            set;
        }
        public string ParentMenuName
        {
            get;
            set;
        }
        public string ParentMenuCode
        {
            get;
            set;
        }
        public bool IsDeleted
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

        public string CentreCode
        {
            get;
            set;
        }
    }

}
