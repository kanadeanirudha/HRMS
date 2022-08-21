using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ILeaveApplicationBA
    {
        IBaseEntityResponse<LeaveApplication> InsertLeaveApplication(LeaveApplication item);
        IBaseEntityResponse<LeaveApplication> UpdateLeaveApplication(LeaveApplication item);
        IBaseEntityResponse<LeaveApplication> DeleteLeaveApplication(LeaveApplication item);
        IBaseEntityCollectionResponse<LeaveApplication> GetBySearch(LeaveApplicationSearchRequest searchRequest);
        IBaseEntityResponse<LeaveApplication> SelectByID(LeaveApplication item);
        IBaseEntityCollectionResponse<LeaveApplication> GetLeaveSummaryByEmployeeID(LeaveApplicationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationStatusByEmployeeID(LeaveApplicationSearchRequest searchRequest);

        //--------------- LeaveApplicationCancel ---------------------

        IBaseEntityResponse<LeaveApplication> InsertLeaveApplicationCancel(LeaveApplication item);
        IBaseEntityResponse<LeaveApplication> UpdateLeaveApplicationCancel(LeaveApplication item);
        IBaseEntityResponse<LeaveApplication> DeleteLeaveApplicationCancel(LeaveApplication item);
        IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationCancelBySearch(LeaveApplicationSearchRequest searchRequest);
        IBaseEntityResponse<LeaveApplication> SelectLeaveApplicationCancelByID(LeaveApplication item);
        IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationCancelViewDetails(LeaveApplicationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationApprocedPendingStatus_SearchList(LeaveApplicationSearchRequest searchRequest);

        IBaseEntityCollectionResponse<LeaveApplication> GetEmployeeBalanceLeave(LeaveApplicationSearchRequest searchRequest);

    }
}
