using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralCountryMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralCountryMasterValidate(GeneralCountryMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralCountryMasterValidate(GeneralCountryMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralCountryMasterValidate(GeneralCountryMaster item);
    }
}

