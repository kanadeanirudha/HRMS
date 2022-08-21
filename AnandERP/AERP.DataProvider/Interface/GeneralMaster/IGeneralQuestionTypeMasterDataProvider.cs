using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralQuestionTypeMasterDataProvider
    {
        IBaseEntityResponse<GeneralQuestionTypeMaster> InsertGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityResponse<GeneralQuestionTypeMaster> UpdateGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityResponse<GeneralQuestionTypeMaster> DeleteGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetGeneralQuestionTypeMasterBySearch(GeneralQuestionTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetGeneralQuestionTypeMasterSearchList(GeneralQuestionTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralQuestionTypeMaster> GetGeneralQuestionTypeMasterByID(GeneralQuestionTypeMaster item);
    }
}
