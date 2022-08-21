using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAccountBalancesheetMasterBA
    {
        /// <summary>
        /// business action interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBySearch(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalanceSheetList(AccountBalancesheetMasterSearchRequest searchRequest);
        
        /// <summary>
        /// business action interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForAccountMasterSearchList(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface to select Balancesheet for Multiple Select List in Account Master Form.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForMultipleSelectList(AccountBalancesheetMasterSearchRequest searchRequest);


        /// <summary>
        /// business action interface of select one record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> SelectByID(AccountBalancesheetMaster item);

        /// <summary>
        /// business action interface of insert new record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> InsertAccBalsheetMaster(AccountBalancesheetMaster item);

        /// <summary>
        /// business action interface of update record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> UpdateAccBalsheetMaster(AccountBalancesheetMaster item);

        /// <summary>
        /// business action interface of dalete record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> DeleteAccBalsheetMaster(AccountBalancesheetMaster item);
    }
}
