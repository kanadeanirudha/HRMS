using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ICCRMEngineersGroupMasterDataProvider
    {
        IBaseEntityResponse<CCRMEngineersGroupMaster> InsertCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item);
        IBaseEntityResponse<CCRMEngineersGroupMaster> InsertCCRMEngineersGroupDetails(CCRMEngineersGroupMaster item);
        IBaseEntityResponse<CCRMEngineersGroupMaster> UpdateCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item);
        IBaseEntityResponse<CCRMEngineersGroupMaster> DeleteCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item);
        IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMasterBySearch(CCRMEngineersGroupMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMasterSearchList(CCRMEngineersGroupMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetDropDownListforCCRMEngineersGroupMaster(CCRMEngineersGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMasterByID(CCRMEngineersGroupMaster item);
        IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMasterList(CCRMEngineersGroupMasterSearchRequest searchRequest);
    }
}
