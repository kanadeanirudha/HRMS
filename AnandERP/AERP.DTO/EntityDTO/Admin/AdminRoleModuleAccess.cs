using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class AdminRoleModuleAccess : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int AdminRoleDetailsID
        {
            get;
            set;
        } 
               
        public int DptBshtSecnStrID
        {
            get;
            set;
        }

        public string AccessibleCentreCode
        {
            get;
            set;
        }

        public DateTime? EnableDate
        {
            get;
            set;
        }

        public DateTime? DisableDate
        {
            get;
            set;
        }

        public string DisablePurpose
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

        public string Designation
        {
            get;
            set;
        }

        public int NoOfPosts
        {
            get;
            set;
        }

        public string AdminRoleCode
        {
            get;
            set;
        }

        public int AdminRoleMasterID
        {
            get;
            set;
        }

        public string EntityType
        {
            get;
            set;
        }

        public string CentreName
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }
        
        public string DepartmentName
        {
            get;
            set;
        }

        public string DesignationType
        {
            get;
            set;
        }

        public int EntityID
        {
            get;
            set;
        }

        public string MonitoringLevel
        {
            get;
            set;
        }

        public string Entity
        {
            get;
            set;
        }

        public bool status
        {
            get;
            set;
        }
        
        public string IDs
        {
            get;
            set;
        }
        
        public string errorMessage { get; set; }
        
        public int Status
        {
            get;
            set;
        }
        public string EntitySourceName
        {
            get;
            set;
        }
        public Int32 SourceID
        {
            get;
            set;
        }
    }
}
