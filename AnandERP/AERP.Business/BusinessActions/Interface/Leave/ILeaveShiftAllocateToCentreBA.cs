using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
	public interface ILeaveShiftAllocateToCentreBA
	{
		IBaseEntityResponse<LeaveShiftAllocateToCentre> InsertLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> UpdateLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> DeleteLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityCollectionResponse<LeaveShiftAllocateToCentre> GetBySearch(LeaveShiftAllocateToCentreSearchRequest searchRequest);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> SelectByID(LeaveShiftAllocateToCentre item);
	}
}
