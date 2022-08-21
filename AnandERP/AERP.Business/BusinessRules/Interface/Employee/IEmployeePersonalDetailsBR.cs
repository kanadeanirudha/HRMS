using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeePersonalDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeePersonalDetailsValidate(EmployeePersonalDetails item);
        IValidateBusinessRuleResponse UpdateEmployeePersonalDetailsValidate(EmployeePersonalDetails item);
        IValidateBusinessRuleResponse DeleteEmployeePersonalDetailsValidate(EmployeePersonalDetails item);
    }
}
