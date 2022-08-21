using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base;
namespace AERP.DataProvider
{
   public interface ICCRMMIFMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item);
        //IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetailsContactDetails(CCRMMIFMasterAndDetails item);
        //IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetailsBranchDetails(CCRMMIFMasterAndDetails item);
        IBaseEntityResponse<CCRMMIFMasterAndDetails> UpdateCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item);
        IBaseEntityResponse<CCRMMIFMasterAndDetails> DeleteCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item);

        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsBySearch(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsByID(CCRMMIFMasterAndDetails item);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
       // IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCustomerBranchMasterSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetListOfOperatorByID(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFSerialNoSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFCallerNameSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMContractMasterSerialNoSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest);
    }
}
