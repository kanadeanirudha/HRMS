using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountChequeBookMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountChequeBookMaster> GetAccountChequeBookMasterBySearch(AccountChequeBookMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> GetAccountChequeBookMasterByID(AccountChequeBookMaster item);

        /// <summary>
        /// data provider interface of select one record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> GetChequeFromNoByAccountID(AccountChequeBookMaster item);

        /// <summary>
        /// data provider interface of insert new record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> InsertAccountChequeBookMaster(AccountChequeBookMaster item);

        /// <summary>
        /// data provider interface of update record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> UpdateAccountChequeBookMaster(AccountChequeBookMaster item);

        /// <summary>
        /// data provider interface of dalete record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> DeleteAccountChequeBookMaster(AccountChequeBookMaster item);
    }
}
