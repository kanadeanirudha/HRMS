using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.Business.BusinessAction
{
   public interface ICCRMLocationTypeMasterBA
    {
        IBaseEntityResponse<CCRMLocationTypeMaster> InsertCCRMLocationTypeMaster(CCRMLocationTypeMaster item);

        IBaseEntityResponse<CCRMLocationTypeMaster> UpdateCCRMLocationTypeMaster(CCRMLocationTypeMaster item);
        IBaseEntityResponse<CCRMLocationTypeMaster> DeleteCCRMLocationTypeMaster(CCRMLocationTypeMaster item);
        IBaseEntityResponse<CCRMLocationTypeMaster> SelectByID(CCRMLocationTypeMaster item);
        IBaseEntityCollectionResponse<CCRMLocationTypeMaster> GetBySearch(CCRMLocationTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMLocationTypeMaster> GetCCRMLocationTypeMasterList(CCRMLocationTypeMasterSearchRequest searchRequest);
    }
}
