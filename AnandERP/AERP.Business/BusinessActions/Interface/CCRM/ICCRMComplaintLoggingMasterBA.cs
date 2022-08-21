using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
  public  interface ICCRMComplaintLoggingMasterBA
    {
        IBaseEntityResponse<CCRMComplaintLoggingMaster> InsertCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item);
        IBaseEntityResponse<CCRMComplaintLoggingMaster> UpdateCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item);
        IBaseEntityResponse<CCRMComplaintLoggingMaster> DeleteCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item);
        IBaseEntityResponse<CCRMComplaintLoggingMaster> SelectByID(CCRMComplaintLoggingMaster item);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetBySearch(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetListOfPriviousCallByID(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMCallerSearchList(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterSearchList(CCRMComplaintLoggingMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetDeviceToken(CCRMComplaintLoggingMasterSearchRequest item);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggedByList(CCRMComplaintLoggingMasterSearchRequest item);
    }
}
