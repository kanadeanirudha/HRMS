using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class AdminRoleCentreRights : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int AdminRoleMasterID
        {
            get;
            set; 
        }

        public int AdminRoleMasterIDOld
        {
            get;
            set;
        }

        public string AdminRoleCode
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }

        public bool IsSuperUser
        {
            get;
            set;
        }

        public bool IsAcadMgr
        {
            get;
            set;
        }

        public bool IsEstMgr
        {
            get;
            set;
        }

        public bool IsFinMgr
        {
            get;
            set;
        }

        public bool IsAdmMgr
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
        public string errorMessage { get; set; }

        public int SuperUser
        {
            get;
            set;
        }

        public int AcadMgr
        {
            get;
            set;
        }

        public int EstMgr
        {
            get;
            set;
        }

        public int FinMgr
        {
            get;
            set;
        }

        public int AdmMgr
        {
            get;
            set;
        }
        public string RightName
        {
            get;
            set;
        }
        public Int16 AdminRoleRightTypeID
        {
            get;
            set;
        }
    }
}
