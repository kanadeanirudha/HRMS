using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AccountCentreWiseBalanceSheetReportSearchRequest : Request
    {
        public Int16 ID
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

    }
}

