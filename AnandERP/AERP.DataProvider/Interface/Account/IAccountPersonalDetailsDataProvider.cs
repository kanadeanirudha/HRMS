using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    interface IAccountPersonalDetailsDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account personal details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountPersonalDetails> GetAccountPersonalDetailsBySearch(AccountPersonalDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account personal details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountPersonalDetails> GetAccountPersonalDetailsByID(AccountPersonalDetails item);

        /// <summary>
        /// data provider interface of insert new record of account personal details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountPersonalDetails> InsertAccountPersonalDetails(AccountPersonalDetails item);

        /// <summary>
        /// data provider interface of update record of account personal details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountPersonalDetails> UpdateAccountPersonalDetails(AccountPersonalDetails item);

        /// <summary>
        /// data provider interface of dalete record of account personal details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountPersonalDetails> DeleteAccountPersonalDetails(AccountPersonalDetails item);
    }
}
