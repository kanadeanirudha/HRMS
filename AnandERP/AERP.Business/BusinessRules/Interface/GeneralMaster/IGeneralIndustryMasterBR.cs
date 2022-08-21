using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralIndustryMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralIndustryMasterValidate(GeneralIndustryMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralIndustryMasterValidate(GeneralIndustryMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralIndustryMasterValidate(GeneralIndustryMaster item);
    }
}

