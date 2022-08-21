using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAdminRoleModuleAccessViewModel
    {
        AdminRoleModuleAccess AdminRoleModuleAccessDTO
        {
            get;
            set;
        } 

        int ID
        {
            get;
            set;
        }

        int AdminRoleDetailsID
        {
            get;
            set;
        }

        int DptBshtSecnStrID
        {
            get;
            set;
        }

        string AccessibleCentreCode
        {
            get;
            set;
        }

        DateTime? EnableDate
        {
            get;
            set;
        }

        DateTime? DisableDate
        {
            get;
            set;
        }

        string DisablePurpose
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

        int AdminRoleMasterID
        {
            get;
            set;
        }
    }
    public interface IAdminRoleModuleAccessBaseViewModel
    {
       

        List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
        }


    }
}
