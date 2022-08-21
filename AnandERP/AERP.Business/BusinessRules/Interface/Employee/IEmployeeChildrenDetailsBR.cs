using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeeChildrenDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeeChildrenDetailsValidate(EmployeeChildrenDetails item);
        IValidateBusinessRuleResponse UpdateEmployeeChildrenDetailsValidate(EmployeeChildrenDetails item);
        IValidateBusinessRuleResponse DeleteEmployeeChildrenDetailsValidate(EmployeeChildrenDetails item);
    }
}
