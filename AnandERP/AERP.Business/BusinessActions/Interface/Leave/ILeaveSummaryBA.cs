using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ILeaveSummaryBA
    {
        IBaseEntityResponse<LeaveSummary> InsertLeaveSummary(LeaveSummary item);
        IBaseEntityResponse<LeaveSummary> UpdateLeaveSummary(LeaveSummary item);
        IBaseEntityResponse<LeaveSummary> DeleteLeaveSummary(LeaveSummary item);
        IBaseEntityCollectionResponse<LeaveSummary> GetBySearch(LeaveSummarySearchRequest searchRequest);
        IBaseEntityResponse<LeaveSummary> SelectByID(LeaveSummary item);
    }
}
