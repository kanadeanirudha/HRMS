using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IAccountCentreWiseBalanceSheetReportViewModel
    {
        AccountCentreWiseBalanceSheetReport AccountCentreWiseBalanceSheetReportDTO
        {
            get;
            set;
        }
         int AccBalsheetTypeID { get; set; }
         string CentreName { get; set; }
         string CentreCode { get; set; }
         string CentreSpecialization { get; set; }
         string AccBalsheetCode { get; set; }
         string AccBalsheetHeadDesc { get; set; }
         string AccBalsheetTypeCode { get; set; }
         string AccBalsheetTypeDesc { get; set; }

    }
}
