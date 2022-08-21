using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAccountMasterBA
    {
        /// <summary>
        /// business action interface of select all record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetBySearch(AccountMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all account name list by bank of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetAccountList(AccountMasterSearchRequest searchRequest);        

        /// <summary>
        /// business action interface of select all account name list by bank of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetAccountListForReport(AccountMasterSearchRequest searchRequest);                
        /// <summary>
        /// business action interface of select Surplus Deficit List.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetSurplusDeficitList(AccountMasterSearchRequest searchRequest);        
      
        /// <summary>
        /// business action interface of select Surplus Deficit List.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMaster> GetAlternateGroupList(AccountMasterSearchRequest searchRequest);  
        /// <summary>
        /// business action interface of select one record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountMaster> SelectByID(AccountMaster item);

        /// <summary>
        /// business action interface of insert new record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountMaster> InsertAccountMaster(AccountMaster item);

        /// <summary>
        /// business action interface of update record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountMaster> UpdateAccountMaster(AccountMaster item);

        /// <summary>
        /// business action interface of dalete record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountMaster> DeleteAccountMaster(AccountMaster item);

        IBaseEntityCollectionResponse<AccountMaster> GetAccountMasterSearchList(AccountMasterSearchRequest searchRequest); 
    }

  
}
