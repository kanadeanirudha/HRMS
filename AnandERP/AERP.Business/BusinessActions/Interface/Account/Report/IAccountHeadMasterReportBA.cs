using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAccountHeadMasterReportBA
    {
        /// <summary>
        /// business action interface of select all record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> InsertAccountHeadMasterReport(AccountHeadMasterReport item);

        /// <summary>
        /// business action interface of select one record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> UpdateAccountHeadMasterReport(AccountHeadMasterReport item);

        /// <summary>
        /// business action interface of insert new record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> DeleteAccountHeadMasterReport(AccountHeadMasterReport item);

        /// <summary>
        /// business action interface of update record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountHeadMasterReport> GetAccountHeadMasterReportBySearch(AccountHeadMasterReportSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select head name list from account head master table.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountHeadMasterReport> GetAccountHeadNameList(AccountHeadMasterReportSearchRequest searchRequest);

        /// <summary>
        /// business action interface of dalete record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> GetAccountHeadMasterReportByID(AccountHeadMasterReport item);
    }
}
