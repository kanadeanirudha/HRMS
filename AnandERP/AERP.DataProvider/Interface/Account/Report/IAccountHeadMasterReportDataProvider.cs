using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountHeadMasterReportDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountHeadMasterReport> GetAccountHeadMasterReportBySearch(AccountHeadMasterReportSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all head name from account head master table.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountHeadMasterReport> GetAccountHeadNameList(AccountHeadMasterReportSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> GetAccountHeadMasterReportByID(AccountHeadMasterReport item);

        /// <summary>
        /// data provider interface of insert new record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> InsertAccountHeadMasterReport(AccountHeadMasterReport item);

        /// <summary>
        /// data provider interface of update record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> UpdateAccountHeadMasterReport(AccountHeadMasterReport item);

        /// <summary>
        /// data provider interface of dalete record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> DeleteAccountHeadMasterReport(AccountHeadMasterReport item);
    }
}
