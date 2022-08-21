using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveMasterDataProvider
    {
        IBaseEntityResponse<LeaveMaster> InsertLeaveMaster(LeaveMaster item);
        IBaseEntityResponse<LeaveMaster> UpdateLeaveMaster(LeaveMaster item);
        IBaseEntityResponse<LeaveMaster> DeleteLeaveMaster(LeaveMaster item);
        IBaseEntityCollectionResponse<LeaveMaster> GetLeaveMasterBySearch(LeaveMasterSearchRequest searchRequest);
        IBaseEntityResponse<LeaveMaster> GetLeaveMasterByID(LeaveMaster item);
        IBaseEntityCollectionResponse<LeaveMaster> GetBySearchList(LeaveMasterSearchRequest searchRequest);
        
    }
}
