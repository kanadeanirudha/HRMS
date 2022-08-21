using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMBillTypeMasterBA
    {
        IBaseEntityResponse<CCRMBillTypeMaster> InsertCCRMBillTypeMaster(CCRMBillTypeMaster item);
        IBaseEntityResponse<CCRMBillTypeMaster> UpdateCCRMBillTypeMaster(CCRMBillTypeMaster item);
        IBaseEntityResponse<CCRMBillTypeMaster> DeleteCCRMBillTypeMaster(CCRMBillTypeMaster item);
        IBaseEntityResponse<CCRMBillTypeMaster> SelectByID(CCRMBillTypeMaster item);
        IBaseEntityCollectionResponse<CCRMBillTypeMaster> GetBySearch(CCRMBillTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMBillTypeMaster> GetCCRMBillTypeMasterList(CCRMBillTypeMasterSearchRequest searchRequest);
    }
}
