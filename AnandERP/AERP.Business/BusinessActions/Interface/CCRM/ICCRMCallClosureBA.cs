using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMCallClosureBA
    {
        IBaseEntityResponse<CCRMCallClosure> UpdateCCRMCallClosure(CCRMCallClosure item);
        IBaseEntityResponse<CCRMCallClosure> DeleteCCRMCallClosure(CCRMCallClosure item);
        IBaseEntityResponse<CCRMCallClosure> SelectByID(CCRMCallClosure item);
        IBaseEntityCollectionResponse<CCRMCallClosure> GetBySearch(CCRMCallClosureSearchRequest searchRequest);
    }
}
