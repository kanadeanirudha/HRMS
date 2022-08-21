using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMContractMasterBA
    {
        IBaseEntityResponse<CCRMContractMaster> InsertCCRMContractMaster(CCRMContractMaster item);
        IBaseEntityResponse<CCRMContractMaster> UpdateCCRMContractMaster(CCRMContractMaster item);
        IBaseEntityResponse<CCRMContractMaster> DeleteCCRMContractMaster(CCRMContractMaster item);
        IBaseEntityResponse<CCRMContractMaster> SelectByID(CCRMContractMaster item);
        IBaseEntityCollectionResponse<CCRMContractMaster> GetBySearch(CCRMContractMasterSearchRequest searchRequest);
    }
}
