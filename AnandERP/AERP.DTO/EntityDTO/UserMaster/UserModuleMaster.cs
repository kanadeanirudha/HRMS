using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class UserModuleMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string ModuleCode
        {
            get;
            set;
        }
        public string ModuleName
        {
            get;
            set;
        }
        public bool ModuleInstalledFlag
        {
            get;
            set;
        }
        public bool ModuleActiveFlag
        {
            get;
            set;
        }
        public int ModuleSeqNumber
        {
            get;
            set;
        }
        public string ModuleRelatedWith
        {
            get;
            set;
        }
        public string ModuleTooltip
        {
            get;
            set;
        }
        public string ModuleIconName
        {
            get;
            set;
        }
        public string ModuleIconPath
        {
            get;
            set;
        }
        public string ModuleFormName
        {
            get;
            set;
        }
        public string ModuleColorClass
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
        public int AdminRoleMasterID
        {
            get;
            set;
        }

        public string path
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
