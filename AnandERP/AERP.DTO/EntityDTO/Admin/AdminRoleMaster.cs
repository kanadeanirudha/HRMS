using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class AdminRoleMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int AdminSnPostID
        {
            get;
            set;
        }

        public string SanctPostName
        {
            get;
            set;
        }

        public string MonitoringLevel
        {
            get;
            set;
        }

        public string AdminRoleCode
        {
            get;
            set;
        }

        public string OthCentreLevel
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

        public bool IsDefaultRole
        {
            get;
            set;
        }

        public bool IsCopyForSame
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

        public string checkStatus
        {
            get;
            set;
        }

        public string IsSuperUserSelf
        {
            get;
            set;
        }

        public string IsAcadMgrSelf
        {
            get;
            set;
        }

        public string IsEstMgrSelf
        {
            get;
            set;
        }

        public string IsFinMgrSelf
        {
            get;
            set;
        }

        public string IsAdmMgrSelf
        {
            get;
            set;
        }

        public int NoOfPosts
        {
            get;
            set;
        }

        public string NomenAdminRoleCode
        {
            get;
            set;
        }

        public string Designation
        {
            get;
            set;
        }

        public string IDs
        {
            get;
            set;
        }

        public string CentreCode                //-----Added for the purpose of if MonitoringLevel is Other then have to Select Other Centre
        {
            get;
            set;
        }

        public string CentreName                 //-----Added for the purpose of if MonitoringLevel is Other then have to Select Other Centre
        {
            get;
            set;
        }

        public int CentreId                             //-----Added for the purpose of if MonitoringLevel is Other then have to Select Other Centre
        {
            get;
            set;
        }

        public string selectItemRightsIDs
        {
            get;
            set;
        }
        public int AdminRoleCentreRightsID                             //-----Added for the purpose of if MonitoringLevel is Other then have to Select Other Centre
        {
            get;
            set;
        }

        public int AdminRoleMasterID                             //-----Added for the purpose of if MonitoringLevel is Other then have to Select Other Centre
        {
            get;
            set;
        }
        public int Status                             //-----Added for the purpose of success status of other centre rights insert success
        {
            get;
            set;
        }
        public int AdminRoleCentreRightsStatus                             //-----Added for the purpose of success status of other centre rights insert success
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public bool IsLoginAllowFromOutside { get; set; }
        public bool IsAttendaceAllowFromOutside { get; set; }
        public string DesignationType { get; set; }
        public string AdminRoleName { get; set; }

        public string RightName
        {
            get;
            set;
        }
        public Int16 AdminRoleRightTypeID
        {
            get; set;
        }
        public string RoleRightStatus
        {
            get;
            set;
        }
        public string AdminRoleDomainName
        {
            get; set;
        }
        public byte AdminRoleDomainID
        {
            get;set;
        }
        public bool StatusFlag
        {
            get;set;
        }
        public int AdminRoleDomainApplicableID
        {
            get;set;
        }
    }
}
