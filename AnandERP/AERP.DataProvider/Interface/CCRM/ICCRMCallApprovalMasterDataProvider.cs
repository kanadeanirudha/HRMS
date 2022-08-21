using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
   public interface ICCRMCallApprovalMasterDataProvider
    {
        //IBaseEntityResponse<CCRMCallApprovalMaster> InsertCCRMCallApprovalMaster(CCRMCallApprovalMaster item);
        IBaseEntityResponse<CCRMCallApprovalMaster> UpdateCCRMCallApprovalMaster(CCRMCallApprovalMaster item);
        IBaseEntityResponse<CCRMCallApprovalMaster> DeleteCCRMCallApprovalMaster(CCRMCallApprovalMaster item);
        IBaseEntityResponse<CCRMCallApprovalMaster> GetCCRMCallApprovalMasterByID(CCRMCallApprovalMaster item);
        IBaseEntityCollectionResponse<CCRMCallApprovalMaster> GetCCRMCallApprovalMasterBySearch(CCRMCallApprovalMasterSearchRequest searchRequest);
    }
}
