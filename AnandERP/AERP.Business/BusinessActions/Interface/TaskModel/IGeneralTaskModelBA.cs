using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IGeneralTaskModelBA
    {
        IBaseEntityResponse<GeneralTaskModel> InsertGeneralTaskModel(GeneralTaskModel item);
        IBaseEntityResponse<GeneralTaskModel> UpdateGeneralTaskModel(GeneralTaskModel item);
        IBaseEntityResponse<GeneralTaskModel> DeleteGeneralTaskModel(GeneralTaskModel item);
        IBaseEntityCollectionResponse<GeneralTaskModel> GetBySearch(GeneralTaskModelSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralTaskModel> GetMenuCodeAndMenuLink(GeneralTaskModelSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralTaskModel> GetTaskCode(GeneralTaskModelSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTaskModel> SelectByID(GeneralTaskModel item);
    }
}
