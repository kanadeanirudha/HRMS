using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
  public  interface ICCRMBrokenCallReasonMasterDataProvider
    {
        IBaseEntityResponse<CCRMBrokenCallReasonMaster> InsertCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item);
        IBaseEntityResponse<CCRMBrokenCallReasonMaster> UpdateCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item);
        IBaseEntityResponse<CCRMBrokenCallReasonMaster> DeleteCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item);
        IBaseEntityResponse<CCRMBrokenCallReasonMaster> GetCCRMBrokenCallReasonMasterByID(CCRMBrokenCallReasonMaster item);
        IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> GetCCRMBrokenCallReasonMasterBySearch(CCRMBrokenCallReasonMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> GetCCRMBrokenCallReasonMasterList(CCRMBrokenCallReasonMasterSearchRequest searchRequest);
    }
}
