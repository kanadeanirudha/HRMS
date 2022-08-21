using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
	public interface ILeaveShiftAllocateToCentreBR
	{
		IValidateBusinessRuleResponse InsertLeaveShiftAllocateToCentreValidate(LeaveShiftAllocateToCentre item);
		IValidateBusinessRuleResponse UpdateLeaveShiftAllocateToCentreValidate(LeaveShiftAllocateToCentre item);
		IValidateBusinessRuleResponse DeleteLeaveShiftAllocateToCentreValidate(LeaveShiftAllocateToCentre item);
	}
}
