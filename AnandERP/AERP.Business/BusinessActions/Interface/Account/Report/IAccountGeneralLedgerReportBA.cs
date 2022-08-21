using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IAccountGeneralLedgerReportBA
    {
       
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetBySearch(AccountGeneralLedgerReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetOtherLedgerBySearch(AccountGeneralLedgerReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountGeneralLedgerReport> SelectByID(AccountGeneralLedgerReport item);
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(AccountGeneralLedgerReportSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetByIndividualBalanceReportSearch(AccountGeneralLedgerReportSearchRequest searchRequest);
    }
}
