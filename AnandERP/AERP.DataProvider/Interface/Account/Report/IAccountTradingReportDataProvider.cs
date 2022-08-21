using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IAccountTradingReportDataProvider
    {

        IBaseEntityCollectionResponse<AccountTradingReport> GetAccountTradingReportBySearch(AccountTradingReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountTradingReport> GetAccountTradingReportByID(AccountTradingReport item);
    }
}
 