using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;


namespace AERP.Business.BusinessAction
{
  public  interface ICCRMTonerRequestCallBA
    {
        IBaseEntityResponse<CCRMTonerRequestCall> InsertCCRMTonerRequestCall(CCRMTonerRequestCall item);
       // IBaseEntityResponse<CCRMTonerRequestCall> UpdateCCRMTonerRequestCall(CCRMTonerRequestCall item);
       // IBaseEntityResponse<CCRMTonerRequestCall> DeleteCCRMTonerRequestCall(CCRMTonerRequestCall item);
        IBaseEntityResponse<CCRMTonerRequestCall> SelectByID(CCRMTonerRequestCall item);
        IBaseEntityCollectionResponse<CCRMTonerRequestCall> GetBySearch(CCRMTonerRequestCallSearchRequest searchRequest);
         IBaseEntityCollectionResponse<CCRMTonerRequestCall> GetLastCallByModelNo(CCRMTonerRequestCallSearchRequest searchRequest);
        
    }
}
