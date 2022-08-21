using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralMapTypeOfAccountDataProvider
    {
        IBaseEntityResponse<GeneralMapTypeOfAccount> InsertGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item);
        IBaseEntityResponse<GeneralMapTypeOfAccount> UpdateGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item);
        IBaseEntityResponse<GeneralMapTypeOfAccount> DeleteGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item);
        IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GetGeneralMapTypeOfAccountBySearch(GeneralMapTypeOfAccountSearchRequest searchRequest);
        IBaseEntityResponse<GeneralMapTypeOfAccount> GetGeneralMapTypeOfAccountByID(GeneralMapTypeOfAccount item);
        IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GetByModuleCode(GeneralMapTypeOfAccountSearchRequest searchRequest);
    }
}
