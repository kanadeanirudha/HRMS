using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    interface IAccountCentrewiseDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account centrewise.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCentrewise> GetAccountCentrewiseBySearch(AccountCentrewiseSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account centrewise.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCentrewise> GetAccountCentrewiseByID(AccountCentrewise item);

        /// <summary>
        /// data provider interface of insert new record of account centrewise.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCentrewise> InsertAccountCentrewise(AccountCentrewise item);

        /// <summary>
        /// data provider interface of update record of account centrewise.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCentrewise> UpdateAccountCentrewise(AccountCentrewise item);

        /// <summary>
        /// data provider interface of dalete record of account centrewise.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCentrewise> DeleteAccountCentrewise(AccountCentrewise item);
    }
}
