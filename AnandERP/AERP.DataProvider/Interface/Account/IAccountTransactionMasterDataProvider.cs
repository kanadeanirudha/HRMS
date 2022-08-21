using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
   public  interface IAccountTransactionMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetAccountTransactionMasterBySearch(AccountTransactionMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearchForEditView(AccountTransactionMasterSearchRequest searchRequest);
       
        /// <summary>
        /// data provider interface of select all record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetAccountList(AccountTransactionMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetVoucherDetailsForApproval(AccountTransactionMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of insert new record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionMaster> InsertAccountVoucherRequest(AccountTransactionMaster item);

        /// <summary>
        /// data provider interface of select one record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionMaster> GetAccountTransactionMasterByID(AccountTransactionMaster item);

        /// <summary>
        /// data provider interface of insert new record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionMaster> InsertAccountTransactionMaster(AccountTransactionMaster item);

        /// <summary>
        /// data provider interface of update record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionMaster> UpdateAccountTransactionMaster(AccountTransactionMaster item);

        /// <summary>
        /// data provider interface of dalete record of account transaction master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountTransactionMaster> DeleteAccountTransactionMaster(AccountTransactionMaster item);
    }
}
