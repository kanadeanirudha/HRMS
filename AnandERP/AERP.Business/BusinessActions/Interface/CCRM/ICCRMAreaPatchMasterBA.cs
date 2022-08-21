using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.Business.BusinessAction
{
   public interface ICCRMAreaPatchMasterBA
    {
        IBaseEntityResponse<CCRMAreaPatchMaster> InsertCCRMAreaPatchMaster(CCRMAreaPatchMaster item);
        IBaseEntityResponse<CCRMAreaPatchMaster> UpdateCCRMAreaPatchMaster(CCRMAreaPatchMaster item);
        IBaseEntityResponse<CCRMAreaPatchMaster> DeleteCCRMAreaPatchMaster(CCRMAreaPatchMaster item);
        IBaseEntityResponse<CCRMAreaPatchMaster> SelectByID(CCRMAreaPatchMaster item);
        IBaseEntityCollectionResponse<CCRMAreaPatchMaster> GetBySearch(CCRMAreaPatchMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMAreaPatchMaster> GetCCRMAreaPatchMasterSearchList(CCRMAreaPatchMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMAreaPatchMaster> GetCCRMAreaPatchMasterList(CCRMAreaPatchMasterSearchRequest searchRequest);
    }
}
