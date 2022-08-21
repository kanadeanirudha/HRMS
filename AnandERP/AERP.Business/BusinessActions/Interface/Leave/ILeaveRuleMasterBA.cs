using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ILeaveRuleMasterBA
    {
        IBaseEntityResponse<LeaveRuleMaster> InsertLeaveRuleMaster(LeaveRuleMaster item);
        IBaseEntityResponse<LeaveRuleMaster> UpdateLeaveRuleMaster(LeaveRuleMaster item);
        IBaseEntityResponse<LeaveRuleMaster> DeleteLeaveRuleMaster(LeaveRuleMaster item);
        IBaseEntityCollectionResponse<LeaveRuleMaster> GetBySearch(LeaveRuleMasterSearchRequest searchRequest);
        IBaseEntityResponse<LeaveRuleMaster> SelectByID(LeaveRuleMaster item);
        IBaseEntityCollectionResponse<LeaveRuleMaster> GetByLeaveCode(LeaveRuleMasterSearchRequest searchRequest);     
        IBaseEntityResponse<LeaveRuleMaster> GetLeaveDetails(LeaveRuleMaster item);
        IBaseEntityCollectionResponse<LeaveRuleMaster> LeaveRuleStatusGetByCentreAndEmployee(LeaveRuleMasterSearchRequest searchRequest);     
    }
}
