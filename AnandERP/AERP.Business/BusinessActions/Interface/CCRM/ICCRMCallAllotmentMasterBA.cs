using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.Business.BusinessAction
{
   public interface ICCRMCallAllotmentMasterBA
    {
        //IBaseEntityResponse<CCRMCallAllotmentMaster> InsertCCRMCallAllotmentMaster(CCRMCallAllotmentMaster item);
        IBaseEntityResponse<CCRMCallAllotmentMaster> UpdateCCRMCallAllotmentMaster(CCRMCallAllotmentMaster item);
        IBaseEntityResponse<CCRMCallAllotmentMaster> DeleteCCRMCallAllotmentMaster(CCRMCallAllotmentMaster item);
        IBaseEntityResponse<CCRMCallAllotmentMaster> SelectByID(CCRMCallAllotmentMaster item);
        IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetBySearch(CCRMCallAllotmentMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetListPendingCallByID(CCRMCallAllotmentMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetCCRMCallAllotmentMasterList(CCRMCallAllotmentMasterSearchRequest searchRequest);
    }
}
