using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
   public interface ICCRMBillTypeMasterDataProvider
    {
        IBaseEntityResponse<CCRMBillTypeMaster> InsertCCRMBillTypeMaster(CCRMBillTypeMaster item);
        IBaseEntityResponse<CCRMBillTypeMaster> UpdateCCRMBillTypeMaster(CCRMBillTypeMaster item);
        IBaseEntityResponse<CCRMBillTypeMaster> DeleteCCRMBillTypeMaster(CCRMBillTypeMaster item);
        IBaseEntityResponse<CCRMBillTypeMaster> GetCCRMBillTypeMasterByID(CCRMBillTypeMaster item);
        IBaseEntityCollectionResponse<CCRMBillTypeMaster> GetCCRMBillTypeMasterBySearch(CCRMBillTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMBillTypeMaster> GetCCRMBillTypeMasterList(CCRMBillTypeMasterSearchRequest searchRequest);
    }
}
