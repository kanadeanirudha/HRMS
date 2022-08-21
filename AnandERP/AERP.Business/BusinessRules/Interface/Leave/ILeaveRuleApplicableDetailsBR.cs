using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveRuleApplicableDetailsBR
    {
        IValidateBusinessRuleResponse InsertLeaveRuleApplicableDetailsValidate(LeaveRuleApplicableDetails item);
        IValidateBusinessRuleResponse UpdateLeaveRuleApplicableDetailsValidate(LeaveRuleApplicableDetails item);
        IValidateBusinessRuleResponse DeleteLeaveRuleApplicableDetailsValidate(LeaveRuleApplicableDetails item);
    }
}
