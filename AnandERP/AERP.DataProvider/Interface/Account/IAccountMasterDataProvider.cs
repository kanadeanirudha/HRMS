using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetAccountMasterBySearch(AccountMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetAccountList(AccountMasterSearchRequest searchRequest);

                /// <summary>
        /// data provider interface of select all record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetAccountListForReport(AccountMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select Surplus Deficit Flag List.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetSurplusDeficitList(AccountMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select Surplus Deficit Flag List.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetAlternateGroupList(AccountMasterSearchRequest searchRequest);
        
        /// <summary>
        /// data provider interface of select one record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountMaster> GetAccountMasterByID(AccountMaster item);

        /// <summary>
        /// data provider interface of insert new record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountMaster> InsertAccountMaster(AccountMaster item);

        /// <summary>
        /// data provider interface of update record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountMaster> UpdateAccountMaster(AccountMaster item);

        /// <summary>
        /// data provider interface of dalete record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountMaster> DeleteAccountMaster(AccountMaster item);

        IBaseEntityCollectionResponse<AccountMaster> GetAccountMasterSearchList(AccountMasterSearchRequest searchRequest);
    }

 
}
