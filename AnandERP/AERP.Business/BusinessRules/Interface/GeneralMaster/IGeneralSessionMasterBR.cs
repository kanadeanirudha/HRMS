using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralSessionMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralSessionMasterValidate(GeneralSessionMaster item);

        /// <summary>
        /// business rule interface of update record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralSessionMasterValidate(GeneralSessionMaster item);

        /// <summary>
        /// business rule interface of dalete record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralSessionMasterValidate(GeneralSessionMaster item);
    }
}
