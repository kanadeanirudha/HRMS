using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
  public  interface IAccountBankTransactionDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBankTransaction> GetAccountBankTransactionBySearch(AccountBankTransactionSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBankTransaction> GetAccountBankTransactionByID(AccountBankTransaction item);

        /// <summary>
        /// data provider interface of insert new record of account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBankTransaction> InsertAccountBankTransaction(AccountBankTransaction item);

        /// <summary>
        /// data provider interface of update record of account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBankTransaction> UpdateAccountBankTransaction(AccountBankTransaction item);

        /// <summary>
        /// data provider interface of dalete record of account bank transaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBankTransaction> DeleteAccountBankTransaction(AccountBankTransaction item);
    }
}
