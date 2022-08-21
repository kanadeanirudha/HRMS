
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralTaxMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralTaxMasterValidate(GeneralTaxMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralTaxMasterValidate(GeneralTaxMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralTaxMasterValidate(GeneralTaxMaster item);
    }
}

