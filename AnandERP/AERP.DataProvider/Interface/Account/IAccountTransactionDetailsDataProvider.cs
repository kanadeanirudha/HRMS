using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    interface IAccountTransactionDetailsDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account transaction details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountTransactionDetails> GetAccountTransactionDetailsBySearch(AccountTransactionDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account transaction details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionDetails> GetAccountTransactionDetailsByID(AccountTransactionDetails item);

        /// <summary>
        /// data provider interface of insert new record of account transaction details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionDetails> InsertAccountTransactionDetails(AccountTransactionDetails item);

        /// <summary>
        /// data provider interface of update record of account transaction details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionDetails> UpdateAccountTransactionDetails(AccountTransactionDetails item);

        /// <summary>
        /// data provider interface of dalete record of account transaction details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionDetails> DeleteAccountTransactionDetails(AccountTransactionDetails item);
    }
}
