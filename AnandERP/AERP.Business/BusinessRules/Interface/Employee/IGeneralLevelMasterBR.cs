using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralLevelMasterBR
    {

        /// <summary>
        /// business rule interface of insert new record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralLevelMasterValidate(GeneralLevelMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralLevelMasterValidate(GeneralLevelMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralLevelMasterValidate(GeneralLevelMaster item);
    }
}
