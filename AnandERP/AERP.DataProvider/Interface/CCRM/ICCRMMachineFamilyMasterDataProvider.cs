using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
   public interface ICCRMMachineFamilyMasterDataProvider
    {
        IBaseEntityResponse<CCRMMachineFamilyMaster> InsertCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item);
        IBaseEntityResponse<CCRMMachineFamilyMaster> UpdateCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item);
        IBaseEntityResponse<CCRMMachineFamilyMaster> DeleteCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item);
        IBaseEntityResponse<CCRMMachineFamilyMaster> GetCCRMMachineFamilyMasterByID(CCRMMachineFamilyMaster item);
        IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> GetCCRMMachineFamilyMasterBySearch(CCRMMachineFamilyMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> GetCCRMMachineFamilyMasterList(CCRMMachineFamilyMasterSearchRequest searchRequest);
    }
}
