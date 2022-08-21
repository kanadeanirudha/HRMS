using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeeElectionNomineeBodyBR
    {
        IValidateBusinessRuleResponse InsertEmployeeElectionNomineeBodyValidate(EmployeeElectionNomineeBody item);
        IValidateBusinessRuleResponse UpdateEmployeeElectionNomineeBodyValidate(EmployeeElectionNomineeBody item);
        IValidateBusinessRuleResponse DeleteEmployeeElectionNomineeBodyValidate(EmployeeElectionNomineeBody item);
    }
}
