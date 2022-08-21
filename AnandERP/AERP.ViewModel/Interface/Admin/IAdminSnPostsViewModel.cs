using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAdminSnPostsViewModel
    {
        AdminSnPosts AdminSnPostsDTO
        {
            get;
            set;
        }

       int ID
        {
            get;
            set;
        }

       int DesignationID
        {
            get;
            set;
        }

       int NoOfPosts
        {
            get;
            set;
        }

      int DepartmentID
        {
            get;
            set;
        }

       string CentreCode
        {
            get;
            set;
        }

      string DesignationType
        {
            get;
            set;
        }

        string NomenAdminRoleCode
        {
            get;
            set;
        }

       string PostType
        {
            get;
            set;
        }

       string SactionedPostDescription
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

    public interface IAdminSnPostsBaseViewModel
    {
        List<AdminSnPosts> ListAdminSnPosts
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
