using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;


namespace AERP.Business.BusinessAction
{
   public interface ICCRMTonerRequestAuthorisationBA
    {
        IBaseEntityResponse<CCRMTonerRequestAuthorisation> UpdateCCRMTonerRequestAuthorisation(CCRMTonerRequestAuthorisation item);
        IBaseEntityResponse<CCRMTonerRequestAuthorisation> DeleteCCRMTonerRequestAuthorisation(CCRMTonerRequestAuthorisation item);
        IBaseEntityResponse<CCRMTonerRequestAuthorisation> SelectByID(CCRMTonerRequestAuthorisation item);
        IBaseEntityCollectionResponse<CCRMTonerRequestAuthorisation> GetBySearch(CCRMTonerRequestAuthorisationSearchRequest searchRequest);
    }
}
