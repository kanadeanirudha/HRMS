using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISalaryAllowanceMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSalaryAllowanceMasterValidate(SalaryAllowanceMaster item);

        /// <summary>
        /// business rule interface of update record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSalaryAllowanceMasterValidate(SalaryAllowanceMaster item);

        /// <summary>
        /// business rule interface of dalete record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSalaryAllowanceMasterValidate(SalaryAllowanceMaster item);
    }
}

