using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ICCRMEngineersGroupMasterBA
    {
        IBaseEntityResponse<CCRMEngineersGroupMaster> InsertCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item);
        IBaseEntityResponse<CCRMEngineersGroupMaster> InsertCCRMEngineersGroupDetails(CCRMEngineersGroupMaster item);
        IBaseEntityResponse<CCRMEngineersGroupMaster> UpdateCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item);
        IBaseEntityResponse<CCRMEngineersGroupMaster> DeleteCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item);
        IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetBySearch(CCRMEngineersGroupMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMasterSearchList(CCRMEngineersGroupMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetDropDownListforCCRMEngineersGroupMaster(CCRMEngineersGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<CCRMEngineersGroupMaster> SelectByID(CCRMEngineersGroupMaster item);
        IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMasterList(CCRMEngineersGroupMasterSearchRequest searchRequest);
    }
}

