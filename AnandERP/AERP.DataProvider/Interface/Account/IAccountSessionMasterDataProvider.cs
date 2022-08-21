using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
  public  interface IAccountSessionMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account session master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountSessionMaster> GetAccountSessionMasterBySearch(AccountSessionMasterSearchRequest searchRequest);
        /// <summary>
        /// data provider interface of select all record of account session master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountSessionMaster> GetAccountSessionList(AccountSessionMasterSearchRequest searchRequest);      

        /// <summary>
        /// data provider interface of select one record of account session master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountSessionMaster> GetAccountSessionMasterByID(AccountSessionMaster item);

        /// <summary>
        /// data provider interface of select one record of account session master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountSessionMaster> GetCurrentAccountSession(AccountSessionMaster item);


        /// <summary>
        /// data provider interface of insert new record of account session master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountSessionMaster> InsertAccountSessionMaster(AccountSessionMaster item);

        /// <summary>
        /// data provider interface of update record of account session master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountSessionMaster> UpdateAccountSessionMaster(AccountSessionMaster item);

        /// <summary>
        /// data provider interface of dalete record of account session master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountSessionMaster> DeleteAccountSessionMaster(AccountSessionMaster item);
        IBaseEntityResponse<AccountSessionMaster> InsertAccountYearEndJob(AccountSessionMaster item);
        IBaseEntityResponse<AccountSessionMaster> GetCurrentAccountSession_AccountYearEnd(AccountSessionMaster item);
        IBaseEntityCollectionResponse<AccountSessionMaster> GetCentreWiseBalncesheetForYearEndJobList(AccountSessionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountSessionMaster> GetAccountSessionMasterSelectList(AccountSessionMasterSearchRequest searchRequest);

    }
}
