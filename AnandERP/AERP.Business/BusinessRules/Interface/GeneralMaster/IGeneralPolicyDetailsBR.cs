using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralPolicyDetailsBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralPolicyDetailsValidate(GeneralPolicyDetails item);

        /// <summary>
        /// business rule interface of update record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralPolicyDetailsValidate(GeneralPolicyDetails item);

        /// <summary>
        /// business rule interface of dalete record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralPolicyDetailsValidate(GeneralPolicyDetails item);
    }
}

