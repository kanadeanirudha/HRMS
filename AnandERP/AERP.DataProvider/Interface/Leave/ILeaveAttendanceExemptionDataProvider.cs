using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
	public interface ILeaveAttendanceExemptionDataProvider
	{
		IBaseEntityResponse<LeaveAttendanceExemption> InsertLeaveAttendanceExemption(LeaveAttendanceExemption item);
		IBaseEntityResponse<LeaveAttendanceExemption> UpdateLeaveAttendanceExemption(LeaveAttendanceExemption item);
		IBaseEntityResponse<LeaveAttendanceExemption> DeleteLeaveAttendanceExemption(LeaveAttendanceExemption item);
		IBaseEntityCollectionResponse<LeaveAttendanceExemption> GetLeaveAttendanceExemptionBySearch(LeaveAttendanceExemptionSearchRequest searchRequest);
		IBaseEntityResponse<LeaveAttendanceExemption> GetLeaveAttendanceExemptionByID(LeaveAttendanceExemption item);
	}
}
