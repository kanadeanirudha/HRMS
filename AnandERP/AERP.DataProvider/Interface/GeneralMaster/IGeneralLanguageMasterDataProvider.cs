using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralLanguageMasterDataProvider
    {
        IBaseEntityResponse<GeneralLanguageMaster> InsertGeneralLanguageMaster(GeneralLanguageMaster item);
        IBaseEntityResponse<GeneralLanguageMaster> UpdateGeneralLanguageMaster(GeneralLanguageMaster item);
        IBaseEntityResponse<GeneralLanguageMaster> DeleteGeneralLanguageMaster(GeneralLanguageMaster item);
        IBaseEntityCollectionResponse<GeneralLanguageMaster> GetGeneralLanguageMasterBySearch(GeneralLanguageMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralLanguageMaster> GetGeneralLanguageMasterGetBySearchList(GeneralLanguageMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralLanguageMaster> GetGeneralLanguageMasterByID(GeneralLanguageMaster item);
    }
}
