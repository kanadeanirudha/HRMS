using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAccountCategoryMasterBA
    {
        /// <summary>
        /// business action interface of select all record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> InsertAccountCategoryMaster(AccountCategoryMaster item);

        /// <summary>
        /// business action interface of select one record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> UpdateAccountCategoryMaster(AccountCategoryMaster item);

        /// <summary>
        /// business action interface of insert new record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> DeleteAccountCategoryMaster(AccountCategoryMaster item);

        /// <summary>
        /// business action interface of update record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMaster> GetBySearch(AccountCategoryMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of update record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMaster> GetCategoryList(AccountCategoryMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of dalete record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> SelectByID(AccountCategoryMaster item);
    }
}
