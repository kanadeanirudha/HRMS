using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;


namespace AERP.DataProvider
{
   public interface ICCRMComplaintLoggingMasterDataProvider
    {
        IBaseEntityResponse<CCRMComplaintLoggingMaster> InsertCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item);
        IBaseEntityResponse<CCRMComplaintLoggingMaster> UpdateCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item);
        IBaseEntityResponse<CCRMComplaintLoggingMaster> DeleteCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item);
        IBaseEntityResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterByID(CCRMComplaintLoggingMaster item);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterBySearch(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetListOfPriviousCallByID(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMCallerSearchList(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterSearchList(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetDeviceToken(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggedByList(CCRMComplaintLoggingMasterSearchRequest searchRequest);
    }
}
