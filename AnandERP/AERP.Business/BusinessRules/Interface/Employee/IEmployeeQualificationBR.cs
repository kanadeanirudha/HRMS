using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeQualificationBR
    {
        IValidateBusinessRuleResponse InsertEmployeeQualificationValidate(EmployeeQualification item);
        IValidateBusinessRuleResponse UpdateEmployeeQualificationValidate(EmployeeQualification item);
        IValidateBusinessRuleResponse DeleteEmployeeQualificationValidate(EmployeeQualification item);
    }
}
