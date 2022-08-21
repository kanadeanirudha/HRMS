using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralOperatorRelatedRoleBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralOperatorRelatedRoleValidate(GeneralOperatorRelatedRole item);

        /// <summary>
        /// business rule interface of update record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralOperatorRelatedRoleValidate(GeneralOperatorRelatedRole item);

        /// <summary>
        /// business rule interface of dalete record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralOperatorRelatedRoleValidate(GeneralOperatorRelatedRole item);
    }
}
