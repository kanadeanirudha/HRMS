using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralCounterMasterDataProvider
    {
        IBaseEntityResponse<GeneralCounterMaster> InsertGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityResponse<GeneralCounterMaster> UpdateGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityResponse<GeneralCounterMaster> DeleteGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityCollectionResponse<GeneralCounterMaster> GetGeneralCounterMasterBySearch(GeneralCounterMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralCounterMaster> GetGeneralCounterMasterSearchList(GeneralCounterMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralCounterMaster> GetGeneralCounterMasterByID(GeneralCounterMaster item);
    }
}
