using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMActionMasterBA
    {
        IBaseEntityResponse<CCRMActionMaster> InsertCCRMActionMaster(CCRMActionMaster item);
        IBaseEntityResponse<CCRMActionMaster> UpdateCCRMActionMaster(CCRMActionMaster item);
        IBaseEntityResponse<CCRMActionMaster> DeleteCCRMActionMaster(CCRMActionMaster item);
        IBaseEntityResponse<CCRMActionMaster> SelectByID(CCRMActionMaster item);
        IBaseEntityCollectionResponse<CCRMActionMaster> GetBySearch(CCRMActionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMActionMaster> GetCCRMActionMasterSearchList(CCRMActionMasterSearchRequest searchRequest);
    }
}
