using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISalaryDeductionMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionMaster(SalaryDeductionMaster item);

        /// <summary>
        /// business action interface of update record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionMaster(SalaryDeductionMaster item);

        /// <summary>
        /// business action interface of dalete record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionMaster(SalaryDeductionMaster item);

        /// <summary>
        /// business action interface of select all record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetBySearch(SalaryDeductionMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetBySearchList(SalaryDeductionMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryDeductionMaster> SelectByID(SalaryDeductionMaster item);

        IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionRules(SalaryDeductionMaster item);
        IBaseEntityResponse<SalaryDeductionMaster> SelectBySalaryDeductionRulesID(SalaryDeductionMaster item);
        IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionRules(SalaryDeductionMaster item);
        IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionRules(SalaryDeductionMaster item);
        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetDeductionRulesByDeductionMaster(SalaryDeductionMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetCalculateOnListForRules(SalaryDeductionMasterSearchRequest searchRequest); 
    }
}
