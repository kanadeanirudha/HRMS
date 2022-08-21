using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralUnitMasterDataProvider
    {
        IBaseEntityResponse<GeneralUnitMaster> InsertGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityResponse<GeneralUnitMaster> UpdateGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityResponse<GeneralUnitMaster> DeleteGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityCollectionResponse<GeneralUnitMaster> GetGeneralUnitMasterBySearch(GeneralUnitMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralUnitMaster> GetGeneralUnitMasterBySearchList(GeneralUnitMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralUnitMaster> GetGeneralUnitMasterByID(GeneralUnitMaster item);
    }
}
