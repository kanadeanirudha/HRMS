using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;


namespace AERP.DataProvider
{
   public interface ICCRMTonerRequestCallDataProvider
    {
        IBaseEntityResponse<CCRMTonerRequestCall> InsertCCRMTonerRequestCall(CCRMTonerRequestCall item);
      //  IBaseEntityResponse<CCRMTonerRequestCall> UpdateCCRMTonerRequestCall(CCRMTonerRequestCall item);
      //  IBaseEntityResponse<CCRMTonerRequestCall> DeleteCCRMTonerRequestCall(CCRMTonerRequestCall item);
        IBaseEntityResponse<CCRMTonerRequestCall> GetCCRMTonerRequestCallByID(CCRMTonerRequestCall item);
        IBaseEntityCollectionResponse<CCRMTonerRequestCall> GetCCRMTonerRequestCallBySearch(CCRMTonerRequestCallSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMTonerRequestCall> GetLastCallByModelNo(CCRMTonerRequestCallSearchRequest searchRequest);
    }
}
