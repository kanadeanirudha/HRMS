using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralExperienceTypeMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralExperienceTypeMasterValidate(GeneralExperienceTypeMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralExperienceTypeMasterValidate(GeneralExperienceTypeMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralExperienceTypeMasterValidate(GeneralExperienceTypeMaster item);
    }
}
