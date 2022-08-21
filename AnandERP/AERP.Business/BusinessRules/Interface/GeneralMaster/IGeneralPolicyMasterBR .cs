using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralPolicyMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralPolicyMasterValidate(GeneralPolicyMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralPolicyMasterValidate(GeneralPolicyMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralPolicyMasterValidate(GeneralPolicyMaster item);
    }
}

