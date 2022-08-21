using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading.Tasks;
using AERP.DTO;

namespace AERP.ViewModel
{
    public class AccountCentreWiseBalanceSheetReportViewModel : IAccountCentreWiseBalanceSheetReportViewModel
    {
        public AccountCentreWiseBalanceSheetReportViewModel()
        {
            AccountCentreWiseBalanceSheetReportDTO = new AccountCentreWiseBalanceSheetReport();
        }
        public AccountCentreWiseBalanceSheetReport AccountCentreWiseBalanceSheetReportDTO { get; set; }
        public int AccBalsheetTypeID
        {
            get
            {
                return (AccountCentreWiseBalanceSheetReportDTO != null ) ? AccountCentreWiseBalanceSheetReportDTO.AccBalsheetTypeID : new int();
            }
            set
            {
                AccountCentreWiseBalanceSheetReportDTO.AccBalsheetTypeID = value;
            }
        }

        public string CentreName
        {
            get
            {
                return (AccountCentreWiseBalanceSheetReportDTO != null) ? AccountCentreWiseBalanceSheetReportDTO.CentreName : string.Empty;
            }
            set
            {
                AccountCentreWiseBalanceSheetReportDTO.CentreName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (AccountCentreWiseBalanceSheetReportDTO != null) ? AccountCentreWiseBalanceSheetReportDTO.CentreCode : string.Empty;
            }
            set
            {
                AccountCentreWiseBalanceSheetReportDTO.CentreCode = value;
            }
        }


        public string CentreSpecialization
        {
            get
            {
                return (AccountCentreWiseBalanceSheetReportDTO != null) ? AccountCentreWiseBalanceSheetReportDTO.CentreSpecialization : string.Empty;
            }
            set
            {
                AccountCentreWiseBalanceSheetReportDTO.CentreSpecialization = value;
            }
        }
        public string AccBalsheetCode
        {
            get
            {
                return (AccountCentreWiseBalanceSheetReportDTO != null) ? AccountCentreWiseBalanceSheetReportDTO.AccBalsheetCode : string.Empty;
            }
            set
            {
                AccountCentreWiseBalanceSheetReportDTO.AccBalsheetCode = value;
            }
        }


        public string AccBalsheetHeadDesc
        {
            get
            {
                return (AccountCentreWiseBalanceSheetReportDTO != null) ? AccountCentreWiseBalanceSheetReportDTO.AccBalsheetHeadDesc : string.Empty;
            }
            set
            {
                AccountCentreWiseBalanceSheetReportDTO.AccBalsheetHeadDesc = value;
            }
        }
        public string AccBalsheetTypeDesc
        {
            get
            {
                return (AccountCentreWiseBalanceSheetReportDTO != null) ? AccountCentreWiseBalanceSheetReportDTO.AccBalsheetTypeDesc : string.Empty;
            }
            set
            {
                AccountCentreWiseBalanceSheetReportDTO.AccBalsheetTypeDesc = value;
            }
        }
        public string AccBalsheetTypeCode
        {
            get
            {
                return (AccountCentreWiseBalanceSheetReportDTO != null) ? AccountCentreWiseBalanceSheetReportDTO.AccBalsheetTypeCode : string.Empty;
            }
            set
            {
                AccountCentreWiseBalanceSheetReportDTO.AccBalsheetTypeCode = value;
            }
        }

 

    }
}
