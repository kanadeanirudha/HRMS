using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    interface IAccountIndividualOpeningBalanceDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account individual opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountIndividualOpeningBalance> GetAccountIndividualOpeningBalanceBySearch(AccountIndividualOpeningBalanceSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account individual opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountIndividualOpeningBalance> GetAccountIndividualOpeningBalanceByID(AccountIndividualOpeningBalance item);

        /// <summary>
        /// data provider interface of insert new record of account individual opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountIndividualOpeningBalance> InsertAccountIndividualOpeningBalance(AccountIndividualOpeningBalance item);

        /// <summary>
        /// data provider interface of update record of account individual opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountIndividualOpeningBalance> UpdateAccountIndividualOpeningBalance(AccountIndividualOpeningBalance item);

        /// <summary>
        /// data provider interface of dalete record of account individual opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountIndividualOpeningBalance> DeleteAccountIndividualOpeningBalance(AccountIndividualOpeningBalance item);
    }
}
