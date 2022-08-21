using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralEducationTypeMasterDataProvider
    {
        IBaseEntityCollectionResponse<GeneralEducationTypeMaster> GetGeneralEducationTypeMasterBySearch(GeneralEducationTypeMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralEducationTypeMaster> GetGeneralEducationTypeMasterGetBySearchList(GeneralEducationTypeMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralEducationTypeMaster> GetGeneralEducationTypeMasterByID(GeneralEducationTypeMaster item);

        IBaseEntityResponse<GeneralEducationTypeMaster> InsertGeneralEducationTypeMaster(GeneralEducationTypeMaster item);

        IBaseEntityResponse<GeneralEducationTypeMaster> UpdateGeneralEducationTypeMaster(GeneralEducationTypeMaster item);

        IBaseEntityResponse<GeneralEducationTypeMaster> DeleteGeneralEducationTypeMaster(GeneralEducationTypeMaster item);
    }
}
