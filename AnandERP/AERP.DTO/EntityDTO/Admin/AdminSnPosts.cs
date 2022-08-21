using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class AdminSnPosts : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int DesignationID
        {
            get;
            set;
        }

        public int NoOfPosts
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }

        public string DesignationType
        {
            get;
            set;
        }

        public string NomenAdminRoleCode
        {
            get;
            set;
        }

        public string PostType
        {
            get;
            set;
        }

        public string SactionedPostDescription
        {
            get;
            set;
        }
        
        public bool IsActive
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int? ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int? DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public int AdminSnPostsID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public int AdminRoleMasterID
        {
            get;
            set;
        }
    }
}
