
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralQuestionTypeMasterBA
    {
        IBaseEntityResponse<GeneralQuestionTypeMaster> InsertGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityResponse<GeneralQuestionTypeMaster> UpdateGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityResponse<GeneralQuestionTypeMaster> DeleteGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item);
        IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetBySearch(GeneralQuestionTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetGeneralQuestionTypeMasterSearchList(GeneralQuestionTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralQuestionTypeMaster> SelectByID(GeneralQuestionTypeMaster item);
    }
}

