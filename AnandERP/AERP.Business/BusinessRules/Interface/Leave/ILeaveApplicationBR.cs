using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveApplicationBR
    {
        IValidateBusinessRuleResponse InsertLeaveApplicationValidate(LeaveApplication item);
        IValidateBusinessRuleResponse UpdateLeaveApplicationValidate(LeaveApplication item);
        IValidateBusinessRuleResponse DeleteLeaveApplicationValidate(LeaveApplication item);

        //--------------- LeaveApplicationCancel ---------------------
        //IValidateBusinessRuleResponse InsertLeaveApplicationCancelValidate(LeaveApplication item);
        //IValidateBusinessRuleResponse UpdateLeaveApplicationCancelValidate(LeaveApplication item);
        //IValidateBusinessRuleResponse DeleteLeaveApplicationCancelValidate(LeaveApplication item);
    }
}
