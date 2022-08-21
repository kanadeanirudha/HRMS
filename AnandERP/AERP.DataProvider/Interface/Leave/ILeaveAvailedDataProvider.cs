using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveAvailedDataProvider
    {
        IBaseEntityResponse<LeaveAvailed> InsertLeaveAvailed(LeaveAvailed item);
        IBaseEntityResponse<LeaveAvailed> UpdateLeaveAvailed(LeaveAvailed item);
        IBaseEntityResponse<LeaveAvailed> DeleteLeaveAvailed(LeaveAvailed item);
        IBaseEntityCollectionResponse<LeaveAvailed> GetLeaveAvailedBySearch(LeaveAvailedSearchRequest searchRequest);
        IBaseEntityResponse<LeaveAvailed> GetLeaveAvailedByID(LeaveAvailed item);
        IBaseEntityCollectionResponse<LeaveAvailed> GetLeaveRequestForApproval_ByPersonID(LeaveAvailedSearchRequest searchRequest);
        
    }
}
