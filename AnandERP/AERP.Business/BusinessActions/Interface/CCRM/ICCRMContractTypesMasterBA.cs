using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
  public  interface ICCRMContractTypesMasterBA
    {
        IBaseEntityResponse<CCRMContractTypesMaster> InsertCCRMContractTypesMaster(CCRMContractTypesMaster item);
        IBaseEntityResponse<CCRMContractTypesMaster> InsertCCRMContractTypeDetails(CCRMContractTypesMaster item);
        IBaseEntityResponse<CCRMContractTypesMaster> UpdateCCRMContractTypesMaster(CCRMContractTypesMaster item);
        IBaseEntityResponse<CCRMContractTypesMaster> DeleteCCRMContractTypesMaster(CCRMContractTypesMaster item);
        IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetBySearch(CCRMContractTypesMasterSearchRequest searchRequest);
        
        IBaseEntityResponse<CCRMContractTypesMaster> SelectByID(CCRMContractTypesMaster item);
        IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetCCRMContractTypesMasterList(CCRMContractTypesMasterSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetGeneralCategoryMasterList(CCRMContractTypesMasterSearchRequest searchRequest);
    }
}
