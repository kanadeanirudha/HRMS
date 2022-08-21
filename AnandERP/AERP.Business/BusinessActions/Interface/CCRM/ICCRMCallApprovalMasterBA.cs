using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.Business.BusinessAction
{
   public interface ICCRMCallApprovalMasterBA
    {
        //IBaseEntityResponse<CCRMCallApprovalMaster> InsertCCRMCallApprovalMaster(CCRMCallApprovalMaster item);
        IBaseEntityResponse<CCRMCallApprovalMaster> UpdateCCRMCallApprovalMaster(CCRMCallApprovalMaster item);
        IBaseEntityResponse<CCRMCallApprovalMaster> DeleteCCRMCallApprovalMaster(CCRMCallApprovalMaster item);
        IBaseEntityResponse<CCRMCallApprovalMaster> SelectByID(CCRMCallApprovalMaster item);
        IBaseEntityCollectionResponse<CCRMCallApprovalMaster> GetBySearch(CCRMCallApprovalMasterSearchRequest searchRequest);
    }
}
