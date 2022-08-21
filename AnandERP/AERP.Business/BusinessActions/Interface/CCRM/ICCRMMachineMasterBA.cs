using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.Business.BusinessAction
{
  public  interface ICCRMMachineMasterBA
    {
        IBaseEntityResponse<CCRMMachineMaster> InsertCCRMMachineMaster(CCRMMachineMaster item);
        IBaseEntityResponse<CCRMMachineMaster> UpdateCCRMMachineMaster(CCRMMachineMaster item);
       // IBaseEntityResponse<CCRMMachineMaster> DeleteCCRMMachineMaster(CCRMMachineMaster item);
        IBaseEntityResponse<CCRMMachineMaster> SelectByID(CCRMMachineMaster item);
        IBaseEntityCollectionResponse<CCRMMachineMaster> GetBySearch(CCRMMachineMasterSearchRequest searchRequest);
    }
}
