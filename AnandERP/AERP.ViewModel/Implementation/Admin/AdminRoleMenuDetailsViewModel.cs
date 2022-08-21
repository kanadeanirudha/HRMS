using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AERP.ViewModel
{
    public class AdminRoleMenuDetailsBaseViewModel : IAdminRoleMenuDetailsBaseViewModel
    {

        public AdminRoleMenuDetailsBaseViewModel()
        {
            ListAdminRoleMenuDetails = new List<AdminRoleMenuDetails>();

            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListAdminSnPosts = new List<AdminSnPosts>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public List<AdminRoleMenuDetails> ListAdminRoleMenuDetails
        {
            get;
            set;
        }

        public List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
        }

        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }

        public List<AdminSnPosts> ListAdminSnPosts
        {
            get;
            set;
        }

        public string SelectedCentreNameforRoleMaster
        {
            get;
            set;
        }

        public string SelectedCentreCodeforRoleMaster
        {
            get;
            set;
        }

        public string SelectedDepartmentIDforRoleMaster
        {
            get;
            set;
        }


        public string SelectedAdminSnPostsID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListOrgStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrgStudyCentreMaster, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationDepartmentMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationDepartmentMaster, "ID", "DepartmentName");
            }

        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

    }
    public class AdminRoleMenuDetailsViewModel : IAdminRoleMenuDetailsViewModel
    {

        public AdminRoleMenuDetailsViewModel()
        {
            AdminRoleMenuDetailsDTO = new AdminRoleMenuDetails();

        }

        public AdminRoleMenuDetails AdminRoleMenuDetailsDTO { get; set; }

        public int ID
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null && AdminRoleMenuDetailsDTO.ID > 0) ? AdminRoleMenuDetailsDTO.ID : new int();
            }
            set
            {
                AdminRoleMenuDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null && AdminRoleMenuDetailsDTO.EmployeeID > 0) ? AdminRoleMenuDetailsDTO.EmployeeID : new int();
            }
            set
            {
                AdminRoleMenuDetailsDTO.EmployeeID = value;
            }
        }

        public int AdminRoleMasterID
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.AdminRoleMasterID : new int();
            }
            set
            {
                AdminRoleMenuDetailsDTO.AdminRoleMasterID = value;
            }
        }

        [Display(Name = "Role Code")]
        public string AdminRoleCode
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.AdminRoleCode : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.AdminRoleCode = value;
            }
        }

        public string MenuCode
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.MenuCode : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.MenuCode = value;
            }
        }

        public DateTime DisableDate
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.DisableDate : new DateTime();
            }
            set
            {
                AdminRoleMenuDetailsDTO.DisableDate = value;
            }
        }

        public DateTime EnableDate
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.EnableDate : new DateTime();
            }
            set
            {
                AdminRoleMenuDetailsDTO.EnableDate = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.IsActive : false;
            }
            set
            {
                AdminRoleMenuDetailsDTO.IsActive = value;
            }
        }

        public string DisablePurpose
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.DisablePurpose : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.DisablePurpose = value;
            }
        }




        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.IsDeleted : false;
            }
            set
            {
                AdminRoleMenuDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null && AdminRoleMenuDetailsDTO.CreatedBy > 0) ? AdminRoleMenuDetailsDTO.CreatedBy : new int();
            }
            set
            {
                AdminRoleMenuDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AdminRoleMenuDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null && AdminRoleMenuDetailsDTO.ModifiedBy.HasValue) ? AdminRoleMenuDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                AdminRoleMenuDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null && AdminRoleMenuDetailsDTO.ModifiedDate.HasValue) ? AdminRoleMenuDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AdminRoleMenuDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null && AdminRoleMenuDetailsDTO.DeletedBy.HasValue) ? AdminRoleMenuDetailsDTO.DeletedBy : new int();
            }
            set
            {
                AdminRoleMenuDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null && AdminRoleMenuDetailsDTO.DeletedDate.HasValue) ? AdminRoleMenuDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AdminRoleMenuDetailsDTO.DeletedDate = value;
            }
        }
        public string DesignationType
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.DesignationType : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.DesignationType = value;
            }
        }
        public string DesignationName
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.DesignationName : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.DesignationName = value;
            }
        }

        [Display(Name = "Module")]
        public int ModuleID
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.ModuleID : new int();
            }
            set
            {
                AdminRoleMenuDetailsDTO.ModuleID = value;
            }
        }

        public string ModuleName
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.ModuleName : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.ModuleName = value;
            }
        }
        public string SelectedTreeViewIDs
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.SelectedTreeViewIDs : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.SelectedTreeViewIDs = value;
            }
        }
        //public int ParentMenuID
        //{
        //    get
        //    {
        //        return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.ParentMenuID : new int();
        //    }
        //    set
        //    {
        //        AdminRoleMenuDetailsDTO.ParentMenuID = value;
        //    }
        //}
        public string CentreCodeWithName
        {
            get;
            set;
        }

        public string DepartmentIdWithName
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

        public IEnumerable<SelectListItem> ListOrgStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrgStudyCentreMaster, "CentreCode", "CentreName");
            }
        }

        public List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }

        public List<AdminRoleMenuDetails> ListDemo
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> AdminMenuDetailsListItems
        {
            get
            {
                return new SelectList(AdminMenuDetailsList, "ID", "TypeName");
            }
        }

        public List<AdminRoleMenuDetails> AdminMenuDetailsList
        {
            get;
            set;
        }

        public string VersionNumber
        {

            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.VersionNumber : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null && AdminRoleMenuDetailsDTO.LastSyncDate.HasValue) ? AdminRoleMenuDetailsDTO.LastSyncDate : null;
            }
            set
            {
                AdminRoleMenuDetailsDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.SyncType : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (AdminRoleMenuDetailsDTO != null) ? AdminRoleMenuDetailsDTO.Entity : string.Empty;
            }
            set
            {
                AdminRoleMenuDetailsDTO.Entity = value;
            }
        }
    }
}
