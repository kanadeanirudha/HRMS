using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
	public interface ILeaveShiftAllocateToCentreDataProvider
	{
		IBaseEntityResponse<LeaveShiftAllocateToCentre> InsertLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> UpdateLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> DeleteLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityCollectionResponse<LeaveShiftAllocateToCentre> GetLeaveShiftAllocateToCentreBySearch(LeaveShiftAllocateToCentreSearchRequest searchRequest);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> GetLeaveShiftAllocateToCentreByID(LeaveShiftAllocateToCentre item);
	}
}
