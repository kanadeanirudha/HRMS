using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralEducationTypeMasterBA
    {
        IBaseEntityResponse<GeneralEducationTypeMaster> InsertGeneralEducationTypeMaster(GeneralEducationTypeMaster item);

        IBaseEntityResponse<GeneralEducationTypeMaster> UpdateGeneralEducationTypeMaster(GeneralEducationTypeMaster item);

        IBaseEntityResponse<GeneralEducationTypeMaster> DeleteGeneralEducationTypeMaster(GeneralEducationTypeMaster item);

        IBaseEntityCollectionResponse<GeneralEducationTypeMaster> GetBySearch(GeneralEducationTypeMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralEducationTypeMaster> GetBySearchList(GeneralEducationTypeMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralEducationTypeMaster> SelectByID(GeneralEducationTypeMaster item);

    }
}
