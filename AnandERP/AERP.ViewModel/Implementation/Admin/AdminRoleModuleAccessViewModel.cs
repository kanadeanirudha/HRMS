using AERP.Common;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AERP.ViewModel
{
    public class AdminRoleModuleAccessBaseViewModel : IAdminRoleModuleAccessBaseViewModel
    {
        public AdminRoleModuleAccessBaseViewModel()
        {
            ListAdminRoleModuleAccess = new List<AdminRoleModuleAccess>();

            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListAdminSnPosts = new List<AdminSnPosts>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public List<AdminRoleModuleAccess> ListAdminRoleModuleAccess
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


        public string SelectedCentreCodeforRoleMaster
        {
            get;
            set;
        }

        public string SelectedCentreNameforRoleMaster
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

        public IEnumerable<SelectListItem> ListAdminSnPostsItems
        {
            get
            {

                return new SelectList(ListAdminSnPosts, "AdminSnPostsID", "SactionedPostDescription");

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

    public class AdminRoleModuleAccessViewModel : IAdminRoleModuleAccessViewModel
    {

        public AdminRoleModuleAccessViewModel()
        {
            AdminRoleModuleAccessDTO = new AdminRoleModuleAccess();
            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            AccessibleCentreList = new List<AdminRoleModuleAccess>();
            EntityList = new List<AdminRoleModuleAccess>();
        }


        public AdminRoleModuleAccess AdminRoleModuleAccessDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.ID > 0) ? AdminRoleModuleAccessDTO.ID : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.ID = value;
            }
        }


        public string DepartmentName
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.DepartmentName : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.DepartmentName = value;
            }

        }

        public int AdminRoleDetailsID
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.AdminRoleDetailsID > 0) ? AdminRoleModuleAccessDTO.AdminRoleDetailsID : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.AdminRoleDetailsID = value;
            }
        }

        public int DptBshtSecnStrID
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.DptBshtSecnStrID > 0) ? AdminRoleModuleAccessDTO.DptBshtSecnStrID : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.DptBshtSecnStrID = value;
            }
        }

        [Display(Name = "Accessible Centre Code")]
        public string AccessibleCentreCode

        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.AccessibleCentreCode : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.AccessibleCentreCode = value;
            }
        }

        [Display(Name = "EnableDate")]
        public DateTime? EnableDate
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.EnableDate.HasValue) ? AdminRoleModuleAccessDTO.EnableDate : DateTime.Now;
            }
            set
            {
                AdminRoleModuleAccessDTO.EnableDate = value;
            }
        }

        [Display(Name = "DisableDate")]
        public DateTime? DisableDate
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.DisableDate.HasValue) ? AdminRoleModuleAccessDTO.DisableDate : DateTime.Now;
            }
            set
            {
                AdminRoleModuleAccessDTO.DisableDate = value;
            }
        }

        [Display(Name = "Disable Purpose")]
        public string DisablePurpose
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.DisablePurpose : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.DisablePurpose = value;
            }
        }
        
        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.IsActive : false;
            }
            set
            {
                AdminRoleModuleAccessDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.IsActive : false;
            }
            set
            {
                AdminRoleModuleAccessDTO.IsActive = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.CreatedBy > 0) ? AdminRoleModuleAccessDTO.CreatedBy : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AdminRoleModuleAccessDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.ModifiedBy.HasValue) ? AdminRoleModuleAccessDTO.ModifiedBy : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.ModifiedDate.HasValue) ? AdminRoleModuleAccessDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AdminRoleModuleAccessDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.DeletedBy.HasValue) ? AdminRoleModuleAccessDTO.DeletedBy : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.DeletedDate.HasValue) ? AdminRoleModuleAccessDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AdminRoleModuleAccessDTO.DeletedDate = value;
            }
        }

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

        public string AdminSnPostsIDWithName
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


        public string Designation
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.Designation : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.Designation = value;
            }

        }

        public int NoOfPosts
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.NoOfPosts > 0) ? AdminRoleModuleAccessDTO.NoOfPosts : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.NoOfPosts = value;
            }
        }

        public string IDs
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.Designation : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.Designation = value;
            }

        }
        [Display(Name = "Role Code")]
        public string AdminRoleCode
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.AdminRoleCode : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.AdminRoleCode = value;
            }

        }

        public int AdminRoleMasterID
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.AdminRoleMasterID > 0) ? AdminRoleModuleAccessDTO.AdminRoleMasterID : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.AdminRoleMasterID = value;
            }
        }

        public List<AdminRoleModuleAccess> AccessibleCentreList
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> AccessibleCentreListItems
        {
            get
            {
                return new SelectList(AccessibleCentreList, "CentreCode", "CentreName");
            }
        }

        public string CentreName
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.CentreName : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.CentreName = value;
            }

        }
        
        [Display(Name ="Designation Type")]
        public string DesignationType
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.DesignationType : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.DesignationType = value;
            }

        }

        public List<AdminRoleModuleAccess> EntityList
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> EntityListItems
        {
            get
            {
                return new SelectList(EntityList, "EntityID", "Entity");
            }
        }

        public string EntityType
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.EntityType : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.EntityType = value;
            }
        }

        public string Entity
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.Entity : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.Entity = value;
            }
        }

        public int EntityID
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null && AdminRoleModuleAccessDTO.EntityID > 0) ? AdminRoleModuleAccessDTO.EntityID : new int();
            }
            set
            {
                AdminRoleModuleAccessDTO.EntityID = value;
            }
        }

        public string MonitoringLevel
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.MonitoringLevel : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.MonitoringLevel = value;
            }
        }

        public bool status
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.status : false;
            }
            set
            {
                AdminRoleModuleAccessDTO.status = value;
            }
        }

        public Int32 SourceID
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.SourceID : new Int32();
            }
            set
            {
                AdminRoleModuleAccessDTO.SourceID = value;
            }
        }

        public string  EntitySourceName
        {
            get
            {
                return (AdminRoleModuleAccessDTO != null) ? AdminRoleModuleAccessDTO.EntitySourceName : string.Empty;
            }
            set
            {
                AdminRoleModuleAccessDTO.EntitySourceName = value;
            }
        }

    }
}
