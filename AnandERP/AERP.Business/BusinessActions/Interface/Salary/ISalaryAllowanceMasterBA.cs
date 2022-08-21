using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISalaryAllowanceMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryAllowanceMaster> InsertSalaryAllowanceMaster(SalaryAllowanceMaster item);

        /// <summary>
        /// business action interface of update record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryAllowanceMaster> UpdateSalaryAllowanceMaster(SalaryAllowanceMaster item);

        /// <summary>
        /// business action interface of dalete record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryAllowanceMaster> DeleteSalaryAllowanceMaster(SalaryAllowanceMaster item);

        /// <summary>
        /// business action interface of select all record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetBySearch(SalaryAllowanceMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetBySearchList(SalaryAllowanceMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryAllowanceMaster> SelectByID(SalaryAllowanceMaster item);

        IBaseEntityResponse<SalaryAllowanceMaster> InsertSalaryAllowanceRules(SalaryAllowanceMaster item);
        IBaseEntityResponse<SalaryAllowanceMaster> SelectBySalaryAllowanceRulesID(SalaryAllowanceMaster item);
        IBaseEntityResponse<SalaryAllowanceMaster> UpdateSalaryAllowanceRules(SalaryAllowanceMaster item);
        IBaseEntityResponse<SalaryAllowanceMaster> DeleteSalaryAllowanceRules(SalaryAllowanceMaster item);
        IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetAllowanceRulesByAllowanceMaster(SalaryAllowanceMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetCalculateOnListForRules(SalaryAllowanceMasterSearchRequest searchRequest);
    }
}
