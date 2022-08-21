using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
	public interface ILeaveAttendanceExemptionBR
	{
		IValidateBusinessRuleResponse InsertLeaveAttendanceExemptionValidate(LeaveAttendanceExemption item);
		IValidateBusinessRuleResponse UpdateLeaveAttendanceExemptionValidate(LeaveAttendanceExemption item);
		IValidateBusinessRuleResponse DeleteLeaveAttendanceExemptionValidate(LeaveAttendanceExemption item);
	}
}
