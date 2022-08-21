using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralServiceMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralServiceMasterValidate(GeneralServiceMaster item);

        /// <summary>
        /// business rule interface of update record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralServiceMasterValidate(GeneralServiceMaster item);

        /// <summary>
        /// business rule interface of dalete record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralServiceMasterValidate(GeneralServiceMaster item);
    }
}

