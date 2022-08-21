using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
    public class AccountSessionMasterReportViewModel : IAccountSessionMasterReportViewModel
    {
        public AccountSessionMasterReportViewModel()
        {
            AccountSessionMasterReportDTO = new AccountSessionMasterReport();
        }
        public AccountSessionMasterReport AccountSessionMasterReportDTO { get; set; }
        public Int16 ID
        {
            get
            {
                return (AccountSessionMasterReportDTO != null && AccountSessionMasterReportDTO.ID > 0) ? AccountSessionMasterReportDTO.ID : new Int16();
            }
            set
            {
                AccountSessionMasterReportDTO.ID = value;
            }
        }

        public string SessionName
        {
            get
            {
                return (AccountSessionMasterReportDTO != null) ? AccountSessionMasterReportDTO.SessionName : string.Empty;
            }
            set
            {
                AccountSessionMasterReportDTO.SessionName = value;
            }
        }
        public string SessionStartDatetime
        {
            get
            {
                return (AccountSessionMasterReportDTO != null) ? AccountSessionMasterReportDTO.SessionStartDatetime : string.Empty;
            }
            set
            {
                AccountSessionMasterReportDTO.SessionStartDatetime = value;
            }
        }

    
        public string SessionEndDatetime
        {
            get
            {
                return (AccountSessionMasterReportDTO != null) ? AccountSessionMasterReportDTO.SessionEndDatetime : string.Empty;
            }
            set
            {
                AccountSessionMasterReportDTO.SessionEndDatetime = value;
            }
        }
        public bool DefaultFlag
        {
            get
            {
                return (AccountSessionMasterReportDTO != null) ? AccountSessionMasterReportDTO.DefaultFlag : false;
            }
            set
            {
                AccountSessionMasterReportDTO.DefaultFlag = value;
            }
        }

    
        public string Account_System
        {
            get
            {
                return (AccountSessionMasterReportDTO != null) ? AccountSessionMasterReportDTO.Account_System : string.Empty;
            }
            set
            {
                AccountSessionMasterReportDTO.Account_System = value;
            }
        }

    
        public bool IsActive
        {
            get
            {
                return (AccountSessionMasterReportDTO != null) ? AccountSessionMasterReportDTO.IsActive : false;
            }
            set
            {
                AccountSessionMasterReportDTO.IsActive = value;
            }
        }

    }
}
