using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
   public interface ICCRMContractTypesMasterDataProvider
    {
        IBaseEntityResponse<CCRMContractTypesMaster> InsertCCRMContractTypesMaster(CCRMContractTypesMaster item);
        IBaseEntityResponse<CCRMContractTypesMaster> InsertCCRMContractTypeDetails(CCRMContractTypesMaster item);
        IBaseEntityResponse<CCRMContractTypesMaster> UpdateCCRMContractTypesMaster(CCRMContractTypesMaster item);
        IBaseEntityResponse<CCRMContractTypesMaster> DeleteCCRMContractTypesMaster(CCRMContractTypesMaster item);
        IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetCCRMContractTypesMasterBySearch(CCRMContractTypesMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetCCRMContractTypesMasterList(CCRMContractTypesMasterSearchRequest searchRequest);
        IBaseEntityResponse<CCRMContractTypesMaster> GetCCRMContractTypesMasterByID(CCRMContractTypesMaster item);

    }
}
