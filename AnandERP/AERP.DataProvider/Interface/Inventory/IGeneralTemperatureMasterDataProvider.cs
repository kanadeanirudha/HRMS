using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralTemperatureMasterDataProvider
    {
        IBaseEntityResponse<GeneralTemperatureMaster> InsertGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityResponse<GeneralTemperatureMaster> UpdateGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityResponse<GeneralTemperatureMaster> DeleteGeneralTemperatureMaster(GeneralTemperatureMaster item);
        IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterBySearch(GeneralTemperatureMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterSearchList(GeneralTemperatureMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterByID(GeneralTemperatureMaster item);
    }
}
