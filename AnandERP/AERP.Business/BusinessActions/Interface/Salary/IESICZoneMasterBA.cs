using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IESICZoneMasterBA
    {
        IBaseEntityResponse<ESICZoneMaster> InsertESICZoneMaster(ESICZoneMaster item);
        IBaseEntityResponse<ESICZoneMaster> UpdateESICZoneMaster(ESICZoneMaster item);
        IBaseEntityResponse<ESICZoneMaster> DeleteESICZoneMaster(ESICZoneMaster item);
        IBaseEntityCollectionResponse<ESICZoneMaster> GetBySearch(ESICZoneMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ESICZoneMaster> GetESICZoneMasterSearchList(ESICZoneMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ESICZoneMaster> GetDropDownListforESICZoneMaster(ESICZoneMasterSearchRequest searchRequest);
        IBaseEntityResponse<ESICZoneMaster> SelectByID(ESICZoneMaster item);
    }
}

