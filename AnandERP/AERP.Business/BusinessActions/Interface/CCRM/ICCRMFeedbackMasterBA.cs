using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
  public  interface ICCRMFeedbackMasterBA
    {
        IBaseEntityResponse<CCRMFeedbackMaster> InsertCCRMFeedbackMaster(CCRMFeedbackMaster item);

        IBaseEntityResponse<CCRMFeedbackMaster> UpdateCCRMFeedbackMaster(CCRMFeedbackMaster item);
        IBaseEntityResponse<CCRMFeedbackMaster> DeleteCCRMFeedbackMaster(CCRMFeedbackMaster item);
        IBaseEntityResponse<CCRMFeedbackMaster> SelectByID(CCRMFeedbackMaster item);
        IBaseEntityCollectionResponse<CCRMFeedbackMaster> GetBySearch(CCRMFeedbackMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMFeedbackMaster> GetCCRMFeedbackMasterList(CCRMFeedbackMasterSearchRequest searchRequest);
    }
}
