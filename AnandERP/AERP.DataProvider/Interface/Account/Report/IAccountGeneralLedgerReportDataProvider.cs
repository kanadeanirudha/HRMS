using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IAccountGeneralLedgerReportDataProvider
    {
       
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetAccountGeneralLedgerReportBySearch(AccountGeneralLedgerReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetOtherLedgerBySearch(AccountGeneralLedgerReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountGeneralLedgerReport> GetAccountGeneralLedgerReportByID(AccountGeneralLedgerReport item);
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(AccountGeneralLedgerReportSearchRequest searchRequest);


        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetByIndividualBalanceReportSearch(AccountGeneralLedgerReportSearchRequest searchRequest);

    }
}
