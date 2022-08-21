using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveAttendanceSpanLockBR
    {
        IValidateBusinessRuleResponse InsertLeaveAttendanceSpanLockValidate(LeaveAttendanceSpanLock item);
        IValidateBusinessRuleResponse UpdateLeaveAttendanceSpanLockValidate(LeaveAttendanceSpanLock item);
        IValidateBusinessRuleResponse DeleteLeaveAttendanceSpanLockValidate(LeaveAttendanceSpanLock item);
    }
}
