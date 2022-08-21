using AERP.Common;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AERP.ViewModel
{
    public class AdminRoleMasterBaseViewModel : IAdminRoleMasterBaseViewModel
    {
        public AdminRoleMasterBaseViewModel()
        {
            ListAdminRoleMaster = new List<AdminRoleMaster>();

            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListAdminSnPosts = new List<AdminSnPosts>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public List<AdminRoleMaster> ListAdminRoleMaster
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

    public class AdminRoleMasterViewModel : IAdminRoleMasterViewModel
    {
        private int _nextID = 1;
        public AdminRoleMasterViewModel()
        {
            AdminRoleMasterDTO = new AdminRoleMaster();
            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();

            if (ListDemo == null)
            {
                ListDemo = new List<AdminRoleMaster>();            
            }
            //Add(new AdminRoleMaster { ID = 1, AdminRoleCode = "G.H.Raisoni", IsSuperUserSelf = "selected", IsAcadMgrSelf = "", IsEstMgrSelf = "selected", IsFinMgrSelf = "", IsAdmMgr = true, checkStatus = "selected" });
            //Add(new AdminRoleMaster { ID = 2, AdminRoleCode = "J.D.Engg", IsSuperUserSelf = "", IsAcadMgrSelf = "selected", IsEstMgrSelf = "", IsFinMgrSelf = "", IsAdmMgr = true, checkStatus = "" });
            //Add(new AdminRoleMaster { ID = 3, AdminRoleCode = "V.K.D", IsSuperUserSelf = "selected", IsAcadMgrSelf = "", IsEstMgrSelf = "selected", IsFinMgrSelf = "selected", IsAdmMgr = false, checkStatus = "selected" });
            //Add(new AdminRoleMaster { ID = 4, AdminRoleCode = "RKNC", IsSuperUserSelf = "Checked", IsAcadMgrSelf = "", IsEstMgrSelf = "Checked", IsFinMgrSelf = "", IsAdmMgr = true, checkStatus = "" });
            //Add(new AdminRoleMaster { ID = 5, AdminRoleCode = "KNC", IsSuperUserSelf = "", IsAcadMgrSelf = "selected", IsEstMgrSelf = "", IsFinMgrSelf = "selected", IsAdmMgr = false, checkStatus = "Checked" });
         
        }

        public AdminRoleMaster Add(AdminRoleMaster item)
        {

            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            // TO DO : Code to save record into database
            item.ID = _nextID++;
            ListDemo.Add(item);

            return item;
        }
        public List<AdminRoleMaster> GetAll()
        {
            // TO DO : Code to get the list of all the records in database

          
            return ListDemo;

        }



        public AdminRoleMaster AdminRoleMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.ID > 0) ? AdminRoleMasterDTO.ID : new int();
            }
            set
            {
                AdminRoleMasterDTO.ID = value;
            }
        }

        public int AdminSnPostID
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.AdminSnPostID > 0) ? AdminRoleMasterDTO.AdminSnPostID : new int();
            }
            set
            {
                AdminRoleMasterDTO.AdminSnPostID = value;
            }
        }

        [Display(Name = "Post Name")]
        public string SanctPostName
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.SanctPostName : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.SanctPostName = value;
            }
        }

        [Display(Name = "Monitoring Level")]
        public string MonitoringLevel
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.MonitoringLevel : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.MonitoringLevel = value;
            }
        }

        [Display(Name = "Admin Role Code")]
        public string AdminRoleCode
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.AdminRoleCode : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.AdminRoleCode = value;
            }
        }

        [Display(Name = "Other Centre Level")]
        public string OthCentreLevel
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.OthCentreLevel : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.OthCentreLevel = value;
            }
        }

        [Display(Name = "IsSuperUser")]
        public bool IsSuperUser
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsSuperUser : false;
            }
            set
            {
                AdminRoleMasterDTO.IsSuperUser = value;
            }
        }

        [Display(Name = "IsAcadMgr")]
        public bool IsAcadMgr
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsAcadMgr : false;
            }
            set
            {
                AdminRoleMasterDTO.IsAcadMgr = value;
            }
        }

         [Display(Name = "IsEstMgr")]
        public bool IsEstMgr
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsEstMgr : false;
            }
            set
            {
                AdminRoleMasterDTO.IsEstMgr = value;
            }
        }

         [Display(Name = "IsFinMgr")]
        public bool IsFinMgr
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsFinMgr : false;
            }
            set
            {
                AdminRoleMasterDTO.IsFinMgr = value;
            }
        }

         [Display(Name = "IsSuperUser")]
        public string IsSuperUserSelf
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsSuperUserSelf : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.IsSuperUserSelf = value;
            }
        }

        [Display(Name = "IsAcadMgr")]
        public string IsAcadMgrSelf
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsAcadMgrSelf : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.IsAcadMgrSelf = value;
            }
        }


        [Display(Name = "IsEstMgr")]
        public string IsEstMgrSelf
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsEstMgrSelf : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.IsEstMgrSelf = value;
            }
        }

         [Display(Name = "IsFinMgr")]
        public string IsFinMgrSelf
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsFinMgrSelf : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.IsFinMgrSelf = value;
            }
        }

         [Display(Name = "IsAdmMgr")]
        public bool IsAdmMgr
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsAdmMgr : false;
            }
            set
            {
                AdminRoleMasterDTO.IsAdmMgr = value;
            }
        }

        [Display(Name = "Is Default Role?")]
        public bool IsDefaultRole
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsDefaultRole : false;
            }
            set
            {
                AdminRoleMasterDTO.IsDefaultRole = value;
            }
        }


        [Display(Name = "Is Copy For Same")]
        public bool IsCopyForSame
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsCopyForSame : false;
            }
            set
            {
                AdminRoleMasterDTO.IsCopyForSame = value;
            }
        }


         [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsActive : false;
            }
            set
            {
                AdminRoleMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsActive : false;
            }
            set
            {
                AdminRoleMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.CreatedBy > 0) ? AdminRoleMasterDTO.CreatedBy : new int();
            }
            set
            {
                AdminRoleMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AdminRoleMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.ModifiedBy.HasValue) ? AdminRoleMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AdminRoleMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.ModifiedDate.HasValue) ? AdminRoleMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AdminRoleMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.DeletedBy.HasValue) ? AdminRoleMasterDTO.DeletedBy : new int();
            }
            set
            {
                AdminRoleMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.DeletedDate.HasValue) ? AdminRoleMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AdminRoleMasterDTO.DeletedDate = value;
            }
        }

        [Display(Name = "Centre Name")]
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

      
        [Display(Name = "Post Name")]
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

        public List<AdminRoleMaster> ListDemo
        {
            get;
            set;
        }
        public List<AdminRoleMaster> DefaultRightsType
        {
            get;
            set;
        }
        
        public string checkStatus
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.checkStatus : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.checkStatus = value;
            }
        }

        public string Designation
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.Designation : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.Designation = value;
            }
        
        }

        public int NoOfPosts
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.NoOfPosts > 0) ? AdminRoleMasterDTO.NoOfPosts : new int();
            }
            set
            {
                AdminRoleMasterDTO.NoOfPosts = value;
            }
        }

        public string IDs
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.Designation : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.Designation = value;
            }

        }

        public string selectItemRightsIDs
        {
            get
            {
                return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.selectItemRightsIDs : string.Empty;
            }
            set
            {
                AdminRoleMasterDTO.selectItemRightsIDs = value;
            }

        }

        public int AdminRoleCentreRightsID
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.AdminRoleCentreRightsID > 0) ? AdminRoleMasterDTO.AdminRoleCentreRightsID : new int();
            }
            set
            {
                AdminRoleMasterDTO.AdminRoleCentreRightsID = value;
            }
        }

         public int AdminRoleMasterID
        {
            get
            {
                return (AdminRoleMasterDTO != null && AdminRoleMasterDTO.AdminRoleMasterID > 0) ? AdminRoleMasterDTO.AdminRoleMasterID : new int();
            }
            set
            {
                AdminRoleMasterDTO.AdminRoleCentreRightsID = value;
            }
        }

         [Display(Name = "Is Login Allow From Outside")]
         public bool IsLoginAllowFromOutside
         {
             get
             {
                 return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsLoginAllowFromOutside : false;
             }
             set
             {
                 AdminRoleMasterDTO.IsLoginAllowFromOutside = value;
             }
         }

         [Display(Name = "Is Attendace Allow From Outside")]
         public bool IsAttendaceAllowFromOutside
         {
             get
             {
                 return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.IsAttendaceAllowFromOutside : false;
             }
             set
             {
                 AdminRoleMasterDTO.IsAttendaceAllowFromOutside = value;
             }
         }
         public string DesignationType
         {
             get
             {
                 return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.DesignationType : string.Empty;
             }
             set
             {
                 AdminRoleMasterDTO.DesignationType = value;
             }

         }
          [Display(Name = "Role Name")]
         public string AdminRoleName
         {
             get
             {
                 return (AdminRoleMasterDTO != null) ? AdminRoleMasterDTO.AdminRoleName : string.Empty;
             }
             set
             {
                 AdminRoleMasterDTO.AdminRoleName = value;
             }

         }
        
    }
}
