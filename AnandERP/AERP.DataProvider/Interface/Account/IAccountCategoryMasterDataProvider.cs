using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountCategoryMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMaster> GetAccountCategoryMasterBySearch(AccountCategoryMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all category name list of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMaster> GetAccountCategoryNameList(AccountCategoryMasterSearchRequest searchRequest);


        /// <summary>
        /// data provider interface of select one record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> GetAccountCategoryMasterByID(AccountCategoryMaster item);

        /// <summary>
        /// data provider interface of insert new record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> InsertAccountCategoryMaster(AccountCategoryMaster item);

        /// <summary>
        /// data provider interface of update record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> UpdateAccountCategoryMaster(AccountCategoryMaster item);

        /// <summary>
        /// data provider interface of dalete record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> DeleteAccountCategoryMaster(AccountCategoryMaster item);
    }
}
