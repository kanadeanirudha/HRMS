using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveAvailedBR
    {
        IValidateBusinessRuleResponse InsertLeaveAvailedValidate(LeaveAvailed item);
        IValidateBusinessRuleResponse UpdateLeaveAvailedValidate(LeaveAvailed item);
        IValidateBusinessRuleResponse DeleteLeaveAvailedValidate(LeaveAvailed item);
    }
}
