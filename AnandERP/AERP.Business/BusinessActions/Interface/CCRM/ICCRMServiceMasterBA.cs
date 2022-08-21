using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;


namespace AERP.Business.BusinessAction
{
   public interface ICCRMServiceMasterBA
    {
        IBaseEntityResponse<CCRMServiceMaster> InsertCCRMServiceMaster(CCRMServiceMaster item);
        IBaseEntityResponse<CCRMServiceMaster> UpdateCCRMServiceMaster(CCRMServiceMaster item);
        IBaseEntityResponse<CCRMServiceMaster> DeleteCCRMServiceMaster(CCRMServiceMaster item);
        IBaseEntityResponse<CCRMServiceMaster> SelectByID(CCRMServiceMaster item);
        IBaseEntityCollectionResponse<CCRMServiceMaster> GetBySearch(CCRMServiceMasterSearchRequest searchRequest);
    }
}
