using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class UserMainMenuMaster : BaseDTO
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
        public int MenuInnerLevel
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

        public string MenuIconName
        {
            get;
            set;
        }
        public bool IsEnable
        {
            get;
            set;
        }
        public string DisableDate
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

        public string path
        {
            get;
            set;
        }

        public bool IsParent
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
