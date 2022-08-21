using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveCompensatoryWorkDayBR
    {
        IValidateBusinessRuleResponse InsertLeaveCompensatoryWorkDayValidate(LeaveCompensatoryWorkDay item);
        IValidateBusinessRuleResponse UpdateLeaveCompensatoryWorkDayValidate(LeaveCompensatoryWorkDay item);
        IValidateBusinessRuleResponse DeleteLeaveCompensatoryWorkDayValidate(LeaveCompensatoryWorkDay item);
    }
}
