using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveRuleMasterDataProvider
    {
        IBaseEntityResponse<LeaveRuleMaster> InsertLeaveRuleMaster(LeaveRuleMaster item);
        IBaseEntityResponse<LeaveRuleMaster> UpdateLeaveRuleMaster(LeaveRuleMaster item);
        IBaseEntityResponse<LeaveRuleMaster> DeleteLeaveRuleMaster(LeaveRuleMaster item);
        IBaseEntityCollectionResponse<LeaveRuleMaster> GetLeaveRuleMasterBySearch(LeaveRuleMasterSearchRequest searchRequest);
        IBaseEntityResponse<LeaveRuleMaster> GetLeaveRuleMasterByID(LeaveRuleMaster item);
        IBaseEntityCollectionResponse<LeaveRuleMaster> GetLeaveRuleMasterByLeaveCode(LeaveRuleMasterSearchRequest searchRequest);
        IBaseEntityResponse<LeaveRuleMaster> GetLeaveDetails(LeaveRuleMaster item);
        IBaseEntityCollectionResponse<LeaveRuleMaster> LeaveRuleStatusGetByCentreAndEmployee(LeaveRuleMasterSearchRequest searchRequest);
        
    }
}
