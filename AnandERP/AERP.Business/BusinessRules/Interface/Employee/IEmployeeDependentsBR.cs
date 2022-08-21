using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeDependentsBR
    {
        IValidateBusinessRuleResponse InsertEmployeeDependentsValidate(EmployeeDependents item);
        IValidateBusinessRuleResponse UpdateEmployeeDependentsValidate(EmployeeDependents item);
        IValidateBusinessRuleResponse DeleteEmployeeDependentsValidate(EmployeeDependents item);
    }
}
