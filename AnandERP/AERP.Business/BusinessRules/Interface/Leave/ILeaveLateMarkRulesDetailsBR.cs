using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveLateMarkRulesDetailsBR
    {
        IValidateBusinessRuleResponse InsertLeaveLateMarkRulesDetailsValidate(LeaveLateMarkRulesDetails item);
        IValidateBusinessRuleResponse UpdateLeaveLateMarkRulesDetailsValidate(LeaveLateMarkRulesDetails item);
        IValidateBusinessRuleResponse DeleteLeaveLateMarkRulesDetailsValidate(LeaveLateMarkRulesDetails item);
    }
}
