using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMBankMasterBA
    {
        IBaseEntityResponse<CCRMBankMaster> InsertCCRMBankMaster(CCRMBankMaster item);

        IBaseEntityResponse<CCRMBankMaster> UpdateCCRMBankMaster(CCRMBankMaster item);
        IBaseEntityResponse<CCRMBankMaster> DeleteCCRMBankMaster(CCRMBankMaster item);
        IBaseEntityResponse<CCRMBankMaster> SelectByID(CCRMBankMaster item);
        IBaseEntityCollectionResponse<CCRMBankMaster> GetBySearch(CCRMBankMasterSearchRequest searchRequest);
    }
}
