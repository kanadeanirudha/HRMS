using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeavePostDataProvider
    {
        IBaseEntityResponse<LeavePost> InsertLeavePostAtOpening(LeavePost item);
        IBaseEntityResponse<LeavePost> UpdateLeavePost(LeavePost item);
        IBaseEntityResponse<LeavePost> DeleteLeavePost(LeavePost item);
        IBaseEntityCollectionResponse<LeavePost> GetLeavePostBySearch(LeavePostSearchRequest searchRequest);
        IBaseEntityResponse<LeavePost> GetLeavePostByID(LeavePost item);
        IBaseEntityResponse<LeavePost> InsertLeavePostAtYearEnd(LeavePost item);
        IBaseEntityCollectionResponse<LeavePost> GetLeaveSummaryAtTheYearEndBySearch(LeavePostSearchRequest searchRequest);
        
    }
}
