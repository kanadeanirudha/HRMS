using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralCasteMasterDataProvider
    {
        IBaseEntityCollectionResponse<GeneralCasteMaster> GetGeneralCasteMasterBySearch(GeneralCasteMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralCasteMaster> GetGeneralCasteMasterByID(GeneralCasteMaster item);

        IBaseEntityResponse<GeneralCasteMaster> InsertGeneralCasteMaster(GeneralCasteMaster item);

        IBaseEntityResponse<GeneralCasteMaster> UpdateGeneralCasteMaster(GeneralCasteMaster item);

        IBaseEntityResponse<GeneralCasteMaster> DeleteGeneralCasteMaster(GeneralCasteMaster item);
        IBaseEntityCollectionResponse<GeneralCasteMaster> GetGeneralCasteMasterGetBySearchList(GeneralCasteMasterSearchRequest searchRequest);

    }
}
