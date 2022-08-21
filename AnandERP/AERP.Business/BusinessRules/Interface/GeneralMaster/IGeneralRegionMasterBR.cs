using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralRegionMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralRegionMasterValidate(GeneralRegionMaster item);

        /// <summary>
        /// business rule interface of update record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralRegionMasterValidate(GeneralRegionMaster item);

        /// <summary>
        /// business rule interface of dalete record of General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralRegionMasterValidate(GeneralRegionMaster item);
    }
}

