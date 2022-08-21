using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    interface IAccountNarrationMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account narration master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountNarrationMaster> GetAccountNarrationMasterBySearch(AccountNarrationMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account narration master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountNarrationMaster> GetAccountNarrationMasterByID(AccountNarrationMaster item);

        /// <summary>
        /// data provider interface of insert new record of account narration master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountNarrationMaster> InsertAccountNarrationMaster(AccountNarrationMaster item);

        /// <summary>
        /// data provider interface of update record of account narration master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountNarrationMaster> UpdateAccountNarrationMaster(AccountNarrationMaster item);

        /// <summary>
        /// data provider interface of dalete record of account narration master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountNarrationMaster> DeleteAccountNarrationMaster(AccountNarrationMaster item);
    }
}
