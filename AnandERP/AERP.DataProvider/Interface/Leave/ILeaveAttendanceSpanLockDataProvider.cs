using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveAttendanceSpanLockDataProvider
    {
        IBaseEntityResponse<LeaveAttendanceSpanLock> InsertLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item);
        IBaseEntityResponse<LeaveAttendanceSpanLock> UpdateLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item);
        IBaseEntityResponse<LeaveAttendanceSpanLock> DeleteLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item);
        IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetLeaveAttendanceSpanLockBySearch(LeaveAttendanceSpanLockSearchRequest searchRequest);
        IBaseEntityResponse<LeaveAttendanceSpanLock> GetLeaveAttendanceSpanLockByID(LeaveAttendanceSpanLock item);
        IBaseEntityResponse<LeaveAttendanceSpanLock> SelectByCentreCode(LeaveAttendanceSpanLock item);
        IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetLeaveAttendanceSpanLockByCentreCode(LeaveAttendanceSpanLockSearchRequest searchRequest);
        IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetByCentreCodeDepartmentIDAndSalarySpanID(LeaveAttendanceSpanLockSearchRequest searchRequest);    
        
    }
}
