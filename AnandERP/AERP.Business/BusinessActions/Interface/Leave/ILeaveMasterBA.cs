using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ILeaveMasterBA
    {
        IBaseEntityResponse<LeaveMaster> InsertLeaveMaster(LeaveMaster item);
        IBaseEntityResponse<LeaveMaster> UpdateLeaveMaster(LeaveMaster item);
        IBaseEntityResponse<LeaveMaster> DeleteLeaveMaster(LeaveMaster item);
        IBaseEntityCollectionResponse<LeaveMaster> GetBySearch(LeaveMasterSearchRequest searchRequest);
        IBaseEntityResponse<LeaveMaster> SelectByID(LeaveMaster item);
        IBaseEntityCollectionResponse<LeaveMaster> GetBySearchList(LeaveMasterSearchRequest searchRequest);
        
    }
}
