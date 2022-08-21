using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralPolicyRulesBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyRules> InsertGeneralPolicyRules(GeneralPolicyRules item);

        /// <summary>
        /// business action interface of update record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyRules> UpdateGeneralPolicyRules(GeneralPolicyRules item);

        /// <summary>
        /// business action interface of dalete record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralPolicyRules> DeleteGeneralPolicyRules(GeneralPolicyRules item);

        /// <summary>
        /// business action interface of select all record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetBySearch(GeneralPolicyRulesSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesForPolicyRange(GeneralPolicyRulesSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesGetBySearchList(GeneralPolicyRulesSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>


        IBaseEntityResponse<GeneralPolicyRules> SelectByID(GeneralPolicyRules item);

        IBaseEntityCollectionResponse<GeneralPolicyRules> GetPolicyAnswerByPolicyStatus(GeneralPolicyRulesSearchRequest searchRequest);

        IBaseEntityResponse<GeneralPolicyRules> GetPolicyApplicableStatus(GeneralPolicyRules item);
    }
}
