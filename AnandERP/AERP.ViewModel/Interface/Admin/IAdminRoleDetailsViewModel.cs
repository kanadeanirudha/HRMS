using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IAdminRoleDetailsViewModel
    {
        AdminRoleDetails AdminRoleDetailsDTO
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

        int AdminRoleMasterIDOld
        {
            get;
            set;
        }

        string AdminRoleCode
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
}
