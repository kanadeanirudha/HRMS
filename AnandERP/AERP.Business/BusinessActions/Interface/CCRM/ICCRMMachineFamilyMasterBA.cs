using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.Business.BusinessAction
{
   public interface ICCRMMachineFamilyMasterBA
    {
        IBaseEntityResponse<CCRMMachineFamilyMaster> InsertCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item);

        IBaseEntityResponse<CCRMMachineFamilyMaster> UpdateCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item);
        IBaseEntityResponse<CCRMMachineFamilyMaster> DeleteCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item);
        IBaseEntityResponse<CCRMMachineFamilyMaster> SelectByID(CCRMMachineFamilyMaster item);
        IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> GetBySearch(CCRMMachineFamilyMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> GetCCRMMachineFamilyMasterList(CCRMMachineFamilyMasterSearchRequest searchRequest);
    }
}
