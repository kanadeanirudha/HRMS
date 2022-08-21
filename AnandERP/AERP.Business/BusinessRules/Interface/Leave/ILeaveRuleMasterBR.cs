using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveRuleMasterBR
    {
        IValidateBusinessRuleResponse InsertLeaveRuleMasterValidate(LeaveRuleMaster item);
        IValidateBusinessRuleResponse UpdateLeaveRuleMasterValidate(LeaveRuleMaster item);
        IValidateBusinessRuleResponse DeleteLeaveRuleMasterValidate(LeaveRuleMaster item);
    }
}
