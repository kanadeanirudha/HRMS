using AERP.Base.DTO;
using System;


namespace AERP.DTO
{
    public class AdminRoleMenuDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public int AdminRoleMasterID
        {
            get;
            set;
        }
        public string AdminRoleCode
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }
        public string MenuCode
        {
            get;
            set;
        }
      
        public DateTime EnableDate
        {
            get;
            set;
        }
        public DateTime DisableDate
        {
            get;
            set;
        }
        public string DisablePurpose
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
        public string DesignationType
        {
            get;
            set;
        }
        public string DesignationName
        {
            get;
            set;
        }
        public string ModuleName
        {
            get;
            set;
        }
        public int ModuleID
        {
            get;
            set;
        }
        public int MenuID
        {
            get;
            set;
        }
        public int ParentMenuID
        {
            get;
            set;
        }
        public string MenuName
        {
            get;
            set;
        }
        public bool Status
        {
            get;
            set;
        }
        public string SelectedTreeViewIDs
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public string VersionNumber { get; set; }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public string SyncType
        {
            get; set;
        }
        public string Entity
        {
            get; set;
        }
    }
}
