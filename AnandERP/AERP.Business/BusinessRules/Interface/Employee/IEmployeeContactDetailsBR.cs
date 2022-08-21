using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeContactDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeeContactDetailsValidate(EmployeeContactDetails item);
        IValidateBusinessRuleResponse UpdateEmployeeContactDetailsValidate(EmployeeContactDetails item);
        IValidateBusinessRuleResponse DeleteEmployeeContactDetailsValidate(EmployeeContactDetails item);
    }
}
