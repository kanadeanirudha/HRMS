using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    interface IAccountFeeCentreWorkingDateDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account fee centre working date.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountFeeCentreWorkingDate> GetAccountFeeCentreWorkingDateBySearch(AccountFeeCentreWorkingDateSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account fee centre working date.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountFeeCentreWorkingDate> GetAccountFeeCentreWorkingDateByID(AccountFeeCentreWorkingDate item);

        /// <summary>
        /// data provider interface of insert new record of account fee centre working date.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountFeeCentreWorkingDate> InsertAccountFeeCentreWorkingDate(AccountFeeCentreWorkingDate item);

        /// <summary>
        /// data provider interface of update record of account fee centre working date.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountFeeCentreWorkingDate> UpdateAccountFeeCentreWorkingDate(AccountFeeCentreWorkingDate item);

        /// <summary>
        /// data provider interface of dalete record of account fee centre working date.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountFeeCentreWorkingDate> DeleteAccountFeeCentreWorkingDate(AccountFeeCentreWorkingDate item);
    }
}
