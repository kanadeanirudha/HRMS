using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.DataProvider
{
  public  interface ICCRMFeedbackMasterDataProvider
    {
        IBaseEntityResponse<CCRMFeedbackMaster> InsertCCRMFeedbackMaster(CCRMFeedbackMaster item);
        IBaseEntityResponse<CCRMFeedbackMaster> UpdateCCRMFeedbackMaster(CCRMFeedbackMaster item);
        IBaseEntityResponse<CCRMFeedbackMaster> DeleteCCRMFeedbackMaster(CCRMFeedbackMaster item);
        IBaseEntityResponse<CCRMFeedbackMaster> GetCCRMFeedbackMasterByID(CCRMFeedbackMaster item);
        IBaseEntityCollectionResponse<CCRMFeedbackMaster> GetCCRMFeedbackMasterBySearch(CCRMFeedbackMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMFeedbackMaster> GetCCRMFeedbackMasterList(CCRMFeedbackMasterSearchRequest searchRequest);
    }
}
