using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISalaryDeductionMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSalaryDeductionMasterValidate(SalaryDeductionMaster item);

        /// <summary>
        /// business rule interface of update record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSalaryDeductionMasterValidate(SalaryDeductionMaster item);

        /// <summary>
        /// business rule interface of dalete record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSalaryDeductionMasterValidate(SalaryDeductionMaster item);
    }
}

