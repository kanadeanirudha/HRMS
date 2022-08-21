using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAdminRoleMenuDetailsViewModel
    {

        AdminRoleMenuDetails AdminRoleMenuDetailsDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        int AdminRoleMasterID
        {
            get;
            set;
        }

        string AdminRoleCode
        {
            get;
            set;
        }
        string MenuCode
        {
            get;
            set;
        }
        DateTime EnableDate
        {
            get;
            set;
        }
        DateTime DisableDate
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

    }
    public interface IAdminRoleMenuDetailsBaseViewModel
    {


    }
}
