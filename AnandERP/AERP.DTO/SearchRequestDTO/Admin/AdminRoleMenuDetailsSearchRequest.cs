using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AdminRoleMenuDetailsSearchRequest : Request
    {
        public int ID
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
        public string SearchType
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
        public string CentreCode
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public int ModuleID
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
