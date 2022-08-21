using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IUserModuleMasterViewModel
    {
        UserModuleMaster UserModuleMasterDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        string ModuleCode
        {
            get;
            set;
        }
        string ModuleName
        {
            get;
            set;
        }
        bool ModuleInstalledFlag
        {
            get;
            set;
        }
        bool ModuleActiveFlag
        {
            get;
            set;
        }
        int ModuleSeqNumber
        {
            get;
            set;
        }
        string ModuleRelatedWith
        {
            get;
            set;
        }
        string ModuleTooltip
        {
            get;
            set;
        }
        string ModuleIconName
        {
            get;
            set;
        }
        string ModuleIconPath
        {
            get;
            set;
        }
        string ModuleFormName
        {
            get;
            set;
        }

    }
    public interface IUserModuleMasterBaseViewModel
    {

    }
}
