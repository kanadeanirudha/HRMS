using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveSessionDataProvider
    {
        IBaseEntityResponse<LeaveSession> InsertLeaveSession(LeaveSession item);
        IBaseEntityResponse<LeaveSession> UpdateLeaveSession(LeaveSession item);
        IBaseEntityResponse<LeaveSession> DeleteLeaveSession(LeaveSession item);
        IBaseEntityCollectionResponse<LeaveSession> GetLeaveSessionBySearch(LeaveSessionSearchRequest searchRequest);
        IBaseEntityResponse<LeaveSession> GetLeaveSessionByID(LeaveSession item);
        IBaseEntityResponse<LeaveSession> SelectByEmployeeIDAndCentreCode(LeaveSessionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<LeaveSession> GetByFromLeaveSessionID(LeaveSessionSearchRequest searchRequest);
      

        ////------------------------Leave Session Details--------------------------////
        IBaseEntityResponse<LeaveSession> InsertLeaveSessionDetails(LeaveSession item);
        IBaseEntityResponse<LeaveSession> UpdateLeaveSessionDetails(LeaveSession item);
        IBaseEntityResponse<LeaveSession> DeleteLeaveSessionDetails(LeaveSession item);
        IBaseEntityCollectionResponse<LeaveSession> GetLeaveSessionDetailsBySearch(LeaveSessionSearchRequest searchRequest);
        IBaseEntityResponse<LeaveSession> GetLeaveSessionDetailsByID(LeaveSession item);

    }
}
