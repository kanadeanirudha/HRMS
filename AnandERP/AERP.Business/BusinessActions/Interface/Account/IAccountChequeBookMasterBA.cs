using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAccountChequeBookMasterBA
    {
        /// <summary>
        /// business action interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountChequeBookMaster> GetBySearch(AccountChequeBookMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> SelectByID(AccountChequeBookMaster item);

        /// <summary>
        /// business action interface of select one record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> SelectByAccountID(AccountChequeBookMaster item);


        /// <summary>
        /// business action interface of insert new record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> InsertAccountChequeBookMaster(AccountChequeBookMaster item);

        /// <summary>
        /// business action interface of update record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> UpdateAccountChequeBookMaster(AccountChequeBookMaster item);

        /// <summary>
        /// business action interface of dalete record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> DeleteAccountChequeBookMaster(AccountChequeBookMaster item);
    }
}
