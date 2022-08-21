using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IGeneralUnitMasterBA
    {
        IBaseEntityResponse<GeneralUnitMaster> InsertGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityResponse<GeneralUnitMaster> UpdateGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityResponse<GeneralUnitMaster> DeleteGeneralUnitMaster(GeneralUnitMaster item);
        IBaseEntityCollectionResponse<GeneralUnitMaster> GetBySearch(GeneralUnitMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralUnitMaster> GetBySearchList(GeneralUnitMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralUnitMaster> SelectByID(GeneralUnitMaster item);
    }
}
