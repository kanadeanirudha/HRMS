using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
	public interface ILeaveAttendanceSpecialRequestBR
	{
		IValidateBusinessRuleResponse InsertLeaveAttendanceSpecialRequestValidate(LeaveAttendanceSpecialRequest item);
		IValidateBusinessRuleResponse UpdateLeaveAttendanceSpecialRequestValidate(LeaveAttendanceSpecialRequest item);
		IValidateBusinessRuleResponse DeleteLeaveAttendanceSpecialRequestValidate(LeaveAttendanceSpecialRequest item);
	}
}
