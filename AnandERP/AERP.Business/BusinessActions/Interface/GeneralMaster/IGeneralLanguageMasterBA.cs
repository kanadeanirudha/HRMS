using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralLanguageMasterBA
    {
        IBaseEntityResponse<GeneralLanguageMaster> InsertGeneralLanguageMaster(GeneralLanguageMaster item);

        IBaseEntityResponse<GeneralLanguageMaster> UpdateGeneralLanguageMaster(GeneralLanguageMaster item);

        IBaseEntityResponse<GeneralLanguageMaster> DeleteGeneralLanguageMaster(GeneralLanguageMaster item);

        IBaseEntityCollectionResponse<GeneralLanguageMaster> GetBySearch(GeneralLanguageMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralLanguageMaster> GetBySearchList(GeneralLanguageMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralLanguageMaster> SelectByID(GeneralLanguageMaster item);
    }
}
