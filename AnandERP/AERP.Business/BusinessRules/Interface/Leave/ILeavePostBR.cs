using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeavePostBR
    {
        IValidateBusinessRuleResponse InsertLeavePostValidate(LeavePost item);
        IValidateBusinessRuleResponse UpdateLeavePostValidate(LeavePost item);
        IValidateBusinessRuleResponse DeleteLeavePostValidate(LeavePost item);
    }
}
