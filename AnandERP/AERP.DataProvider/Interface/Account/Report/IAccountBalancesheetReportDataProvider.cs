using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountBalancesheetReportDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of AccountBalancesheetReport.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetReport> GetAccountBalancesheetReportBySearch(AccountBalancesheetReportSearchRequest searchRequest);
    }
}
