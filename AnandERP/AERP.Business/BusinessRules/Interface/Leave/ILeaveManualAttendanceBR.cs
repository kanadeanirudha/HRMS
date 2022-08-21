using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveManualAttendanceBR
    {
        IValidateBusinessRuleResponse InsertLeaveManualAttendanceValidate(LeaveManualAttendance item);
        IValidateBusinessRuleResponse UpdateLeaveManualAttendanceValidate(LeaveManualAttendance item);
        IValidateBusinessRuleResponse DeleteLeaveManualAttendanceValidate(LeaveManualAttendance item);
    }
}
