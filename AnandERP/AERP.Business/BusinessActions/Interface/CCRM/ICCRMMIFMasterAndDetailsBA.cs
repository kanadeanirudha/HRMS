using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
   public interface ICCRMMIFMasterAndDetailsBA
    {
        IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item);
        //IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetailsCustomerDetails(CCRMMIFMasterAndDetails item);
        //IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetailsMIFDetails(CCRMMIFMasterAndDetails item);
        IBaseEntityResponse<CCRMMIFMasterAndDetails> UpdateCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item);
        IBaseEntityResponse<CCRMMIFMasterAndDetails> DeleteCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetBySearch(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCustomerBranchMasterSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetListOfOperatorByID(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CCRMMIFMasterAndDetails> SelectByID(CCRMMIFMasterAndDetails item);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFSerialNoSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFCallerNameSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMContractMasterSerialNoSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);

    }
}
