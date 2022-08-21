using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveLateMarkRulesDetailsDataProvider
    {
        IBaseEntityResponse<LeaveLateMarkRulesDetails> InsertLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item);
        IBaseEntityResponse<LeaveLateMarkRulesDetails> UpdateLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item);
        IBaseEntityResponse<LeaveLateMarkRulesDetails> DeleteLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item);
        IBaseEntityCollectionResponse<LeaveLateMarkRulesDetails> GetLeaveLateMarkRulesDetailsBySearch(LeaveLateMarkRulesDetailsSearchRequest searchRequest);
        IBaseEntityResponse<LeaveLateMarkRulesDetails> GetLeaveLateMarkRulesDetailsByID(LeaveLateMarkRulesDetails item);
    }
}
