using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralCurrencyMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralCurrencyMasterValidate(GeneralCurrencyMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralCurrencyMasterValidate(GeneralCurrencyMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralCurrencyMasterValidate(GeneralCurrencyMaster item);
    }
}
