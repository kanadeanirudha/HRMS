using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    interface IAccountPersonalMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account personal master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountPersonalMaster> GetAccountPersonalMasterBySearch(AccountPersonalMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account personal master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountPersonalMaster> GetAccountPersonalMasterByID(AccountPersonalMaster item);

        /// <summary>
        /// data provider interface of insert new record of account personal master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountPersonalMaster> InsertAccountPersonalMaster(AccountPersonalMaster item);

        /// <summary>
        /// data provider interface of update record of account personal master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountPersonalMaster> UpdateAccountPersonalMaster(AccountPersonalMaster item);

        /// <summary>
        /// data provider interface of dalete record of account personal master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountPersonalMaster> DeleteAccountPersonalMaster(AccountPersonalMaster item);
    }
}
