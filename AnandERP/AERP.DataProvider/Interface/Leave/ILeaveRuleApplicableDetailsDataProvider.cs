using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveRuleApplicableDetailsDataProvider
    {
        IBaseEntityResponse<LeaveRuleApplicableDetails> InsertLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityResponse<LeaveRuleApplicableDetails> UpdateLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityResponse<LeaveRuleApplicableDetails> DeleteLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> GetLeaveRuleApplicableDetailsBySearch(LeaveRuleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> SelectByLeaveRuleMasterID(LeaveRuleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityResponse<LeaveRuleApplicableDetails> GetLeaveRuleApplicableDetailsByID(LeaveRuleApplicableDetails item);
    }
}
