using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class AdminSnPostsTransaction : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }

        public int DesignationID
        {
            get;
            set;
        }

        public int AdminSnPostID
        {
            get;
            set;
        }

        public int AdminSnPostIDOld
        {
            get;
            set;
        }

        public int NoOfPosts
        {
            get;
            set;
        }

        public string TransactionType
        {
            get;
            set;
        }

        public string PostType
        {
            get;
            set;
        }

        public string DesignationType
        {
            get;
            set;
        }

        public DateTime? SanctionDate
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }

        public string ApprovedBy
        {
            get;
            set;
        }

        public DateTime? ApprovalDate
        {
            get;
            set;
        }

        public string SpecialRemark
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

    }
}
