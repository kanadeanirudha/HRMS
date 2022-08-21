using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAccountMasterReportBA
    {
        /// <summary>
        /// business action interface of select all record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountMasterReport> GetBySearch(AccountMasterReportSearchRequest searchRequest);
    }

  
}
