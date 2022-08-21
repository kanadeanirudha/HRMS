using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralPolicyRulesBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralPolicyRulesValidate(GeneralPolicyRules item);

        /// <summary>
        /// business rule interface of update record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralPolicyRulesValidate(GeneralPolicyRules item);

        /// <summary>
        /// business rule interface of dalete record of GeneralPolicyRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralPolicyRulesValidate(GeneralPolicyRules item);
    }
}

