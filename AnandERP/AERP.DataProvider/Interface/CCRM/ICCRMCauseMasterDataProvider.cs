using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
   public interface ICCRMCauseMasterDataProvider
    {
        IBaseEntityResponse<CCRMCauseMaster> InsertCCRMCauseMaster(CCRMCauseMaster item);
        IBaseEntityResponse<CCRMCauseMaster> InsertCCRMCauseType(CCRMCauseMaster item);
        IBaseEntityResponse<CCRMCauseMaster> UpdateCCRMCauseType(CCRMCauseMaster item);
        IBaseEntityResponse<CCRMCauseMaster> DeleteCCRMCauseMaster(CCRMCauseMaster item);
        IBaseEntityCollectionResponse<CCRMCauseMaster> GetCCRMCauseMasterBySearch(CCRMCauseMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMCauseMaster> GetCCRMCauseMasterSearchList(CCRMCauseMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMCauseMaster> GetDropDownListforCCRMCauseMaster(CCRMCauseMasterSearchRequest searchRequest);
        IBaseEntityResponse<CCRMCauseMaster> GetCCRMCauseTypeByID(CCRMCauseMaster item);
    }
}
