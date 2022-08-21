using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAccountCategoryMasterReportDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetAccountCategoryMasterReportBySearch(AccountCategoryMasterReportSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all category name list of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetAccountCategoryNameList(AccountCategoryMasterReportSearchRequest searchRequest);


        /// <summary>
        /// data provider interface of select one record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMasterReport> GetAccountCategoryMasterReportByID(AccountCategoryMasterReport item);


    }
}
