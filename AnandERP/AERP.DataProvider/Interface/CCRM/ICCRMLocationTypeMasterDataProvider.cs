using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
   public interface ICCRMLocationTypeMasterDataProvider
    {
        IBaseEntityResponse<CCRMLocationTypeMaster> InsertCCRMLocationTypeMaster(CCRMLocationTypeMaster item);
        IBaseEntityResponse<CCRMLocationTypeMaster> UpdateCCRMLocationTypeMaster(CCRMLocationTypeMaster item);
        IBaseEntityResponse<CCRMLocationTypeMaster> DeleteCCRMLocationTypeMaster(CCRMLocationTypeMaster item);
        IBaseEntityResponse<CCRMLocationTypeMaster> GetCCRMLocationTypeMasterByID(CCRMLocationTypeMaster item);
        IBaseEntityCollectionResponse<CCRMLocationTypeMaster> GetCCRMLocationTypeMasterBySearch(CCRMLocationTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMLocationTypeMaster> GetCCRMLocationTypeMasterList(CCRMLocationTypeMasterSearchRequest searchRequest);
    }
}
