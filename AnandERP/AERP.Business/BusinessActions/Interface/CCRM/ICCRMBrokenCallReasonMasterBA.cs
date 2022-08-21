using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMBrokenCallReasonMasterBA
    {
        IBaseEntityResponse<CCRMBrokenCallReasonMaster> InsertCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item);

        IBaseEntityResponse<CCRMBrokenCallReasonMaster> UpdateCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item);
        IBaseEntityResponse<CCRMBrokenCallReasonMaster> DeleteCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item);
        IBaseEntityResponse<CCRMBrokenCallReasonMaster> SelectByID(CCRMBrokenCallReasonMaster item);
        IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> GetBySearch(CCRMBrokenCallReasonMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> GetCCRMBrokenCallReasonMasterList(CCRMBrokenCallReasonMasterSearchRequest searchRequest);
    }
}
