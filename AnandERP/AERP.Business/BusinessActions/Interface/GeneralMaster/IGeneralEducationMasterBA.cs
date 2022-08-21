using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IGeneralEducationMasterBA
    {
        IBaseEntityResponse<GeneralEducationMaster> InsertGeneralEducationMaster(GeneralEducationMaster item);

        IBaseEntityResponse<GeneralEducationMaster> UpdateGeneralEducationMaster(GeneralEducationMaster item);

        IBaseEntityResponse<GeneralEducationMaster> DeleteGeneralEducationMaster(GeneralEducationMaster item);

        IBaseEntityCollectionResponse<GeneralEducationMaster> GetBySearch(GeneralEducationMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralEducationMaster> SelectByID(GeneralEducationMaster item);

        IBaseEntityCollectionResponse<GeneralEducationMaster> GetByEducationTypeID(GeneralEducationMasterSearchRequest searchRequest);
    }
}
