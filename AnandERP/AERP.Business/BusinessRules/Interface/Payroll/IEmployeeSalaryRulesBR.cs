using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeSalaryRulesBR
    {
        /// <summary>
        /// business rule interface of insert new record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertEmployeeSalaryRulesValidate(EmployeeSalaryRules item);

        /// <summary>
        /// business rule interface of update record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateEmployeeSalaryRulesValidate(EmployeeSalaryRules item);

        /// <summary>
        /// business rule interface of dalete record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteEmployeeSalaryRulesValidate(EmployeeSalaryRules item);
    }
}

