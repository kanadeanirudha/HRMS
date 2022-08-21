using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralRelationshipTypeMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralRelationshipTypeMasterValidate(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralRelationshipTypeMasterValidate(GeneralRelationshipTypeMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralRelationshipTypeMasterValidate(GeneralRelationshipTypeMaster item);
    }
}
