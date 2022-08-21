using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IGeneralMapTypeOfAccountBA
    {
        IBaseEntityResponse<GeneralMapTypeOfAccount> InsertGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item);
        IBaseEntityResponse<GeneralMapTypeOfAccount> UpdateGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item);
        IBaseEntityResponse<GeneralMapTypeOfAccount> DeleteGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item);
        IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GetBySearch(GeneralMapTypeOfAccountSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GetByModuleCode(GeneralMapTypeOfAccountSearchRequest searchRequest);
        IBaseEntityResponse<GeneralMapTypeOfAccount> SelectByID(GeneralMapTypeOfAccount item);
    }
}
