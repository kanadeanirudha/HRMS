using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IEmployeeExperienceBR
    {
        IValidateBusinessRuleResponse InsertEmployeeExperienceValidate(EmployeeExperience item);
        IValidateBusinessRuleResponse UpdateEmployeeExperienceValidate(EmployeeExperience item);
        IValidateBusinessRuleResponse DeleteEmployeeExperienceValidate(EmployeeExperience item);
    }
}
