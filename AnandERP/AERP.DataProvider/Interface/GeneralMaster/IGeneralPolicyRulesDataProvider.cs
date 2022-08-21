using System;
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralPolicyRulesDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesBySearch(GeneralPolicyRulesSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesForPolicyRange(GeneralPolicyRulesSearchRequest searchRequest);
         
        /// <summary>
        /// data provider interface of select one record of GeneralPolicyRules.
        /// </summary> 
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesGetBySearchList(GeneralPolicyRulesSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>





        IBaseEntityResponse<GeneralPolicyRules> GetGeneralPolicyRulesByID(GeneralPolicyRules item);

        /// <summary>
        /// data provider interface of insert new record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyRules> InsertGeneralPolicyRules(GeneralPolicyRules item);

        /// <summary>
        /// data provider interface of update record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyRules> UpdateGeneralPolicyRules(GeneralPolicyRules item);

        /// <summary>
        /// data provider interface of dalete record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyRules> DeleteGeneralPolicyRules(GeneralPolicyRules item);

        IBaseEntityCollectionResponse<GeneralPolicyRules> GetPolicyAnswerByPolicyStatus(GeneralPolicyRulesSearchRequest searchRequest);

        IBaseEntityResponse<GeneralPolicyRules> GetPolicyApplicableStatus(GeneralPolicyRules item);

    }
}
