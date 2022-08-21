using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface IDashboardViewModel
    {
        List<UserModuleMaster> ModuleList { get; set; }

        List<Dashboard> DashboardContentList { get; set; }

        List<Dashboard> TaskCodeList { get; set; }

        #region -------------- TaskNotificationMaster ---------------
        int PersonID
        {
            get;
            set;
        }

        string TaskCode
        {
            get;
            set;
        }
        #endregion
    }
}
