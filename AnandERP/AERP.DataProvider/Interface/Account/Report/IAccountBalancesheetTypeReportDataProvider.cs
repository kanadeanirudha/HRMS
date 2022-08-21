using System;
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountBalancesheetTypeReportDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetTypeReport> GetAccountBalancesheetTypeReportBySearch(AccountBalancesheetTypeReportSearchRequest searchRequest);


    }
}
