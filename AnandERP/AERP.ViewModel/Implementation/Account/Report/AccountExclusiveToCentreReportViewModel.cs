using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
    public class AccountExclusiveToCentreReportViewModel : IAccountExclusiveToCentreReportViewModel
    {
        public AccountExclusiveToCentreReportViewModel()
        {
            AccountExclusiveToCentreReportDTO = new AccountExclusiveToCentreReport();
        }
        public AccountExclusiveToCentreReport AccountExclusiveToCentreReportDTO { get; set; }


        public string AccountName
        {
            get
            {
                return (AccountExclusiveToCentreReportDTO != null) ? AccountExclusiveToCentreReportDTO.AccountName : string.Empty;
            }
            set
            {
                AccountExclusiveToCentreReportDTO.AccountName = value;
            }
        }
        public string DebitCreditFlag
        {
            get
            {
                return (AccountExclusiveToCentreReportDTO != null) ? AccountExclusiveToCentreReportDTO.DebitCreditFlag : string.Empty;
            }
            set
            {
                AccountExclusiveToCentreReportDTO.DebitCreditFlag = value;
            }
        }


        public string CashBankFlag
        {
            get
            {
                return (AccountExclusiveToCentreReportDTO != null) ? AccountExclusiveToCentreReportDTO.CashBankFlag : string.Empty;
            }
            set
            {
                AccountExclusiveToCentreReportDTO.CashBankFlag = value;
            }
        }



        public string GroupDescription
        {
            get
            {
                return (AccountExclusiveToCentreReportDTO != null) ? AccountExclusiveToCentreReportDTO.GroupDescription : string.Empty;
            }
            set
            {
                AccountExclusiveToCentreReportDTO.GroupDescription = value;
            }
        }

        public string AlternetGroupName
        {
            get
            {
                return (AccountExclusiveToCentreReportDTO != null) ? AccountExclusiveToCentreReportDTO.AlternetGroupName : string.Empty;
            }
            set
            {
                AccountExclusiveToCentreReportDTO.AlternetGroupName = value;
            }
        }
        public bool ExclusivelyForCentre
        {
            get
            {
                return (AccountExclusiveToCentreReportDTO != null) ? AccountExclusiveToCentreReportDTO.ExclusivelyForCentre : false;
            }
            set
            {
                AccountExclusiveToCentreReportDTO.ExclusivelyForCentre = value;
            }
        }

    }
}
