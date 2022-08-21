using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAdminRoleMasterViewModel
    {
        AdminRoleMaster AdminRoleMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        int AdminSnPostID
        {
            get;
            set;
        }

             
         string SanctPostName
        {
            get;
            set;
        }

         string MonitoringLevel
        {
            get;
            set;
        }

         string AdminRoleCode
        {
            get;
            set;
        }

         string OthCentreLevel
        {
            get;
            set;
        }

         bool IsSuperUser
         {
             get;
             set;
         }

         bool IsAcadMgr
         {
             get;
             set;
         }

         bool IsEstMgr
         {
             get;
             set;
         }

         bool IsFinMgr
         {
             get;
             set;
         }

         string IsSuperUserSelf
        {
            get;
            set;
        }

         string IsAcadMgrSelf
        {
            get;
            set;
        }

         string IsEstMgrSelf
        {
            get;
            set;
        }

         string IsFinMgrSelf
        {
            get;
            set;
        }

         bool IsAdmMgr
        {
            get;
            set;
        }

         bool IsDefaultRole
        {
            get;
            set;
        }

         bool IsCopyForSame
        {
            get;
            set;
        }

         bool IsActive
        {
            get;
            set;
        }

         bool IsDeleted
        {
            get;
            set;
        }

         int CreatedBy
        {
            get;
            set;
        }

         DateTime CreatedDate
        {
            get;
            set;
        }

         int? ModifiedBy
        {
            get;
            set;
        }

         DateTime? ModifiedDate
        {
            get;
            set;
        }

         int? DeletedBy
        {
            get;
            set;
        }

         DateTime? DeletedDate
        {
            get;
            set;
        }

         string AdminSnPostsIDWithName
         {
             get;
             set;
         }

         string Designation
         {
             get;
             set;
         }

         string IDs
         {
             get;
             set;
         }

         string selectItemRightsIDs
         {
             get;
             set;
         }

         List<AdminRoleMaster> GetAll();
    }

    public interface IAdminRoleMasterBaseViewModel
    {
        List<AdminRoleMaster> ListAdminRoleMaster
        {
            get;
            set;
        }

        List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
        }

      
    }
}
