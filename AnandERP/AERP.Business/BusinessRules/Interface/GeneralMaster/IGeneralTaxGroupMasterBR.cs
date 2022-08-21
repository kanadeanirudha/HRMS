using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralTaxGroupMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralTaxGroupMasterValidate(GeneralTaxGroupMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralTaxGroupMasterValidate(GeneralTaxGroupMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralTaxGroupMasterValidate(GeneralTaxGroupMaster item);
    }
}
