using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAdminRoleApplicableDetailsViewModel
    {
        AdminRoleApplicableDetails AdminRoleApplicableDetailsDTO
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

         int EmployeeID
        {
            get;
            set;
        }

         string EmployeeName
         {
             get;
             set;
         }

         string CentreCode
         {
             get;
             set;
         }

         int DesignationID
        {
            get;
            set;
        }

         string WorkFromDate
        {
            get;
            set;
        }

         string WorkToDate
        {
            get;
            set;
        }

         string RoleType
        {
            get;
            set;
        }

         string Reason
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

    public interface IAdminRoleApplicableDetailsBaseViewModel
    {
        List<AdminRoleApplicableDetails> ListAdminRoleApplicableDetails
        {
            get;
            set;
        }

        List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
    }
}
