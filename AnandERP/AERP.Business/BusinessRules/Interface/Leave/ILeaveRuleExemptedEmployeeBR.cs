using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveRuleExemptedEmployeeBR
    {
        IValidateBusinessRuleResponse InsertLeaveRuleExemptedEmployeeValidate(LeaveRuleExemptedEmployee item);
        IValidateBusinessRuleResponse UpdateLeaveRuleExemptedEmployeeValidate(LeaveRuleExemptedEmployee item);
        IValidateBusinessRuleResponse DeleteLeaveRuleExemptedEmployeeValidate(LeaveRuleExemptedEmployee item);
    }
}
