using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeePaperPresentBR
    {
        IValidateBusinessRuleResponse InsertEmployeePaperPresentValidate(EmployeePaperPresent item);
        IValidateBusinessRuleResponse UpdateEmployeePaperPresentValidate(EmployeePaperPresent item);
        IValidateBusinessRuleResponse DeleteEmployeePaperPresentValidate(EmployeePaperPresent item);


        IValidateBusinessRuleResponse InsertEmployeePaperPresenterValidate(EmployeePaperPresent item);
        IValidateBusinessRuleResponse UpdateEmployeePaperPresenterValidate(EmployeePaperPresent item);
        IValidateBusinessRuleResponse DeleteEmployeePaperPresenterValidate(EmployeePaperPresent item);

    }
}
