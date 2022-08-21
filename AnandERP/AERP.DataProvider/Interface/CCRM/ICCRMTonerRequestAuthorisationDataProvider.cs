using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
  public  interface ICCRMTonerRequestAuthorisationDataProvider
    {
        IBaseEntityResponse<CCRMTonerRequestAuthorisation> UpdateCCRMTonerRequestAuthorisation(CCRMTonerRequestAuthorisation item);
        IBaseEntityResponse<CCRMTonerRequestAuthorisation> DeleteCCRMTonerRequestAuthorisation(CCRMTonerRequestAuthorisation item);
        IBaseEntityResponse<CCRMTonerRequestAuthorisation> GetCCRMTonerRequestAuthorisationByID(CCRMTonerRequestAuthorisation item);
        IBaseEntityCollectionResponse<CCRMTonerRequestAuthorisation> GetCCRMTonerRequestAuthorisationBySearch(CCRMTonerRequestAuthorisationSearchRequest searchRequest);
    }
}
