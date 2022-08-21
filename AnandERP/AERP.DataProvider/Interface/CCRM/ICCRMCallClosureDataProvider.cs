using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
   public interface ICCRMCallClosureDataProvider
    {
        IBaseEntityResponse<CCRMCallClosure> UpdateCCRMCallClosure(CCRMCallClosure item);
        IBaseEntityResponse<CCRMCallClosure> DeleteCCRMCallClosure(CCRMCallClosure item);
        IBaseEntityResponse<CCRMCallClosure> GetCCRMCallClosureByID(CCRMCallClosure item);
        IBaseEntityCollectionResponse<CCRMCallClosure> GetCCRMCallClosureBySearch(CCRMCallClosureSearchRequest searchRequest);
    }
}
