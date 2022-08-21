using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveSessionBR
    {
        IValidateBusinessRuleResponse InsertLeaveSessionValidate(LeaveSession item);
        IValidateBusinessRuleResponse UpdateLeaveSessionValidate(LeaveSession item);
        IValidateBusinessRuleResponse DeleteLeaveSessionValidate(LeaveSession item);

        ////------------------------Leave Session Details--------------------------////
        IValidateBusinessRuleResponse InsertLeaveSessionDetailsValidate(LeaveSession item);
        IValidateBusinessRuleResponse UpdateLeaveSessionDetailsValidate(LeaveSession item);
        IValidateBusinessRuleResponse DeleteLeaveSessionDetailsValidate(LeaveSession item);

    }
}
