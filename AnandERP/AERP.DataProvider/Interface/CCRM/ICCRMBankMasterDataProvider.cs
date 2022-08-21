using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
  public  interface ICCRMBankMasterDataProvider
    {
        IBaseEntityResponse<CCRMBankMaster> InsertCCRMBankMaster(CCRMBankMaster item);
        IBaseEntityResponse<CCRMBankMaster> UpdateCCRMBankMaster(CCRMBankMaster item);
        IBaseEntityResponse<CCRMBankMaster> DeleteCCRMBankMaster(CCRMBankMaster item);
        IBaseEntityResponse<CCRMBankMaster> GetCCRMBankMasterByID(CCRMBankMaster item);
        IBaseEntityCollectionResponse<CCRMBankMaster> GetCCRMBankMasterBySearch(CCRMBankMasterSearchRequest searchRequest);

    }
}
