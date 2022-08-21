using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountBalancesheetTypeMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> GetAccountBalancesheetTypeMasterBySearch(AccountBalancesheetTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetTypeMaster> GetAccountBalancesheetTypeMasterByID(AccountBalancesheetTypeMaster item);

        /// <summary>
        /// data provider interface of insert new record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetTypeMaster> InsertAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item);

        /// <summary>
        /// data provider interface of update record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetTypeMaster> UpdateAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item);

        /// <summary>
        /// data provider interface of dalete record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetTypeMaster> DeleteAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item);
    }
}
