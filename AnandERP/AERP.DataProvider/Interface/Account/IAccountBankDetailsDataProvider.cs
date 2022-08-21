using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    interface IAccountBankDetailsDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account bank details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBankDetails> GetAccountBankDetailsBySearch(AccountBankDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account bank details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBankDetails> GetAccountBankDetailsByID(AccountBankDetails item);

        /// <summary>
        /// data provider interface of insert new record of account bank details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBankDetails> InsertAccountBankDetails(AccountBankDetails item);

        /// <summary>
        /// data provider interface of update record of account bank details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBankDetails> UpdateAccountBankDetails(AccountBankDetails item);

        /// <summary>
        /// data provider interface of dalete record of account bank details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBankDetails> DeleteAccountBankDetails(AccountBankDetails item);
    }
}
