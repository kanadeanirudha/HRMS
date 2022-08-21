using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
   public interface ICCRMServiceMasterDataProvider
    {
        IBaseEntityResponse<CCRMServiceMaster> InsertCCRMServiceMaster(CCRMServiceMaster item);
        IBaseEntityResponse<CCRMServiceMaster> UpdateCCRMServiceMaster(CCRMServiceMaster item);
        IBaseEntityResponse<CCRMServiceMaster> DeleteCCRMServiceMaster(CCRMServiceMaster item);
        IBaseEntityResponse<CCRMServiceMaster> GetCCRMServiceMasterByID(CCRMServiceMaster item);
        IBaseEntityCollectionResponse<CCRMServiceMaster> GetCCRMServiceMasterBySearch(CCRMServiceMasterSearchRequest searchRequest);
    }
}
