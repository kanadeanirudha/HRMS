using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeSalaryTransactionBR
    {
        /// <summary>
        /// business rule interface of insert new record of EmployeeSalaryTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertEmployeeSalaryTransactionValidate(EmployeeSalaryTransaction item);

        /// <summary>
        /// business rule interface of update record of EmployeeSalaryTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateEmployeeSalaryTransactionValidate(EmployeeSalaryTransaction item);

        /// <summary>
        /// business rule interface of dalete record of EmployeeSalaryTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteEmployeeSalaryTransactionValidate(EmployeeSalaryTransaction item);
    }
}

