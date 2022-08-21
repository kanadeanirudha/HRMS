using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISalaryDeductionMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetSalaryDeductionMasterBySearch(SalaryDeductionMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetSalaryDeductionMasterGetBySearchList(SalaryDeductionMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryDeductionMaster> GetSalaryDeductionMasterByID(SalaryDeductionMaster item);

        /// <summary>
        /// data provider interface of insert new record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionMaster(SalaryDeductionMaster item);

        /// <summary>
        /// data provider interface of update record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionMaster(SalaryDeductionMaster item);

        /// <summary>
        /// data provider interface of dalete record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionMaster(SalaryDeductionMaster item);
        IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionRules(SalaryDeductionMaster item);
        IBaseEntityResponse<SalaryDeductionMaster> SelectBySalaryDeductionRulesID(SalaryDeductionMaster item);
        IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionRules(SalaryDeductionMaster item);
        IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionRules(SalaryDeductionMaster item);
        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetDeductionRulesByDeductionMaster(SalaryDeductionMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetCalculateOnListForRules(SalaryDeductionMasterSearchRequest searchRequest);
    }
}
