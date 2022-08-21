using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveManualAttendanceDataProvider
    {
        IBaseEntityResponse<LeaveManualAttendance> InsertLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityResponse<LeaveManualAttendance> UpdateLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityResponse<LeaveManualAttendance> DeleteLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityCollectionResponse<LeaveManualAttendance> GetLeaveManualAttendanceBySearch(LeaveManualAttendanceSearchRequest searchRequest);
        IBaseEntityResponse<LeaveManualAttendance> GetLeaveManualAttendanceByID(LeaveManualAttendance item);
    }
}
