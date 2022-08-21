using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
  public  interface ICCRMActionMasterDataProvider
    {
        IBaseEntityResponse<CCRMActionMaster> InsertCCRMActionMaster(CCRMActionMaster item);
        IBaseEntityResponse<CCRMActionMaster> UpdateCCRMActionMaster(CCRMActionMaster item);
        IBaseEntityResponse<CCRMActionMaster> DeleteCCRMActionMaster(CCRMActionMaster item);
        IBaseEntityResponse<CCRMActionMaster> GetCCRMActionMasterByID(CCRMActionMaster item);
        IBaseEntityCollectionResponse<CCRMActionMaster> GetCCRMActionMasterBySearch(CCRMActionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMActionMaster> GetCCRMActionMasterSearchList(CCRMActionMasterSearchRequest searchRequest);
    }
}
