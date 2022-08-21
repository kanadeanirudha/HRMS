using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeeOtherCollegeFinancialAssistanceDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeeOtherCollegeFinancialAssistanceDetailsValidate(EmployeeOtherCollegeFinancialAssistanceDetails item);
        IValidateBusinessRuleResponse UpdateEmployeeOtherCollegeFinancialAssistanceDetailsValidate(EmployeeOtherCollegeFinancialAssistanceDetails item);
        IValidateBusinessRuleResponse DeleteEmployeeOtherCollegeFinancialAssistanceDetailsValidate(EmployeeOtherCollegeFinancialAssistanceDetails item);
    }
}
