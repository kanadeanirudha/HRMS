using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeServiceDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeeServiceDetailsValidate(EmployeeServiceDetails item);
        IValidateBusinessRuleResponse UpdateEmployeeServiceDetailsValidate(EmployeeServiceDetails item);
        IValidateBusinessRuleResponse DeleteEmployeeServiceDetailsValidate(EmployeeServiceDetails item);
    }
}
