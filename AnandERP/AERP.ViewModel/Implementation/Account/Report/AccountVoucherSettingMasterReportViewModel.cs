using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
    public class AccountVoucherSettingMasterReportViewModel : IAccountVoucherSettingMasterReportViewModel
    {
        public AccountVoucherSettingMasterReportViewModel()
        {
            AccountVoucherSettingMasterReportDTO = new AccountVoucherSettingMasterReport();
        }
        public AccountVoucherSettingMasterReport AccountVoucherSettingMasterReportDTO { get; set; }
        public int AccSessionID
        {
            get
            {
                return (AccountVoucherSettingMasterReportDTO != null) ? AccountVoucherSettingMasterReportDTO.AccSessionID : new int();
            }
            set
            {
                AccountVoucherSettingMasterReportDTO.AccSessionID = value;
            }
        }

        public string SessionName
        {
            get
            {
                return (AccountVoucherSettingMasterReportDTO != null) ? AccountVoucherSettingMasterReportDTO.SessionName : string.Empty;
            }
            set
            {
                AccountVoucherSettingMasterReportDTO.SessionName = value;
            }
        }
        public string TransactionType
        {
            get
            {
                return (AccountVoucherSettingMasterReportDTO != null) ? AccountVoucherSettingMasterReportDTO.TransactionType : string.Empty;
            }
            set
            {
                AccountVoucherSettingMasterReportDTO.TransactionType = value;
            }
        }


        public string TransactionTypeCode
        {
            get
            {
                return (AccountVoucherSettingMasterReportDTO != null) ? AccountVoucherSettingMasterReportDTO.TransactionTypeCode : string.Empty;
            }
            set
            {
                AccountVoucherSettingMasterReportDTO.TransactionTypeCode = value;
            }
        }



        public int VoucherNumber
        {
            get
            {
                return (AccountVoucherSettingMasterReportDTO != null) ? AccountVoucherSettingMasterReportDTO.VoucherNumber :new int();
            }
            set
            {
                AccountVoucherSettingMasterReportDTO.VoucherNumber = value;
            }
        }

    
        public bool IsActive
        {
            get
            {
                return (AccountVoucherSettingMasterReportDTO != null) ? AccountVoucherSettingMasterReportDTO.IsActive : false;
            }
            set
            {
                AccountVoucherSettingMasterReportDTO.IsActive = value;
            }
        }

    }
}
