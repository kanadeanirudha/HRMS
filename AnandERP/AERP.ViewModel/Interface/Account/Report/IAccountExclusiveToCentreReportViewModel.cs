using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IAccountExclusiveToCentreReportViewModel
    {
        AccountExclusiveToCentreReport AccountExclusiveToCentreReportDTO
        {
            get;
            set;
        }
        //Int16 ID { get; set; }
        string AccountName { get; set; }
        string DebitCreditFlag { get; set; }
        string CashBankFlag { get; set; }
        bool ExclusivelyForCentre { get; set; }


        string GroupDescription { get; set; }
        string AlternetGroupName { get; set; }

    }
}
