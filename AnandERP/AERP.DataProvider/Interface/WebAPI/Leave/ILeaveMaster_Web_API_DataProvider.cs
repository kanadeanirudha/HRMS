using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ILeaveMaster_Web_API_DataProvider
    {
        IBaseEntityCollectionResponse<LeaveMaster> getLeaves(LeaveMaster item);

        IBaseEntityCollectionResponse<LeaveMaster> getVersionNumber(LeaveMaster item);
        
        IBaseEntityResponse<LeaveManualAttendance> InsertLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityResponse<LeaveAttendanceSpecialRequest> InsertSpecialLeaveAttendance(LeaveAttendanceSpecialRequest item);

        IBaseEntityCollectionResponse<LeaveMaster> GetManualAttendance(LeaveMaster item);
        IBaseEntityCollectionResponse<LeaveMaster> GetSpecialLeave(LeaveMaster item);
        IBaseEntityResponse<AddAttendance> AddAttendance(AddAttendance item);

        IBaseEntityResponse<LeaveMaster> InsertLeaveApplicationCancel(LeaveMaster item);

        IBaseEntityCollectionResponse<LeaveMaster> GetLeaveDetails(LeaveMaster item);

        IBaseEntityCollectionResponse<LeaveMaster> GetLeaveApplicationApprocedPendingStatus_SearchList(LeaveMaster item);



    }
}
