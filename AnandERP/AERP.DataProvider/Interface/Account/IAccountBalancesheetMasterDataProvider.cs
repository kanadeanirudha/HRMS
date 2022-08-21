using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountBalancesheetMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetAccountBalancesheetMasterBySearch(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetAccountBalancesheetMasterList(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForAccountMasterSearchList(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface to select select Balancesheet for Multiple Select List in Account Master Form.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForMultipleSelectList(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> GetAccountBalancesheetMasterByID(AccountBalancesheetMaster item);

        /// <summary>
        /// data provider interface of insert new record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> InsertAccountBalancesheetMaster(AccountBalancesheetMaster item);

        /// <summary>
        /// data provider interface of update record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> UpdateAccountBalancesheetMaster(AccountBalancesheetMaster item);

        /// <summary>
        /// data provider interface of dalete record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> DeleteAccountBalancesheetMaster(AccountBalancesheetMaster item);


    }
}
