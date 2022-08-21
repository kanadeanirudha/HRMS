using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.DataProvider
{
    public interface IGeneralReligionMasterDataProvider
    {
        IBaseEntityCollectionResponse<GeneralReligionMaster> GetGeneralReligionMasterBySearch(GeneralReligionMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralReligionMaster> GetGeneralReligionMasterByID(GeneralReligionMaster item);

        IBaseEntityResponse<GeneralReligionMaster> InsertGeneralReligionMaster(GeneralReligionMaster item);

        IBaseEntityResponse<GeneralReligionMaster> UpdateGeneralReligionMaster(GeneralReligionMaster item);

        IBaseEntityResponse<GeneralReligionMaster> DeleteGeneralReligionMaster(GeneralReligionMaster item);

        IBaseEntityCollectionResponse<GeneralReligionMaster> GetGeneralReligionMasterGetBySearchList(GeneralReligionMasterSearchRequest searchRequest);
    }
}
