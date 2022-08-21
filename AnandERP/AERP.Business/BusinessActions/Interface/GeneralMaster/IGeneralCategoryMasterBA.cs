using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IGeneralCategoryMasterBA
    {
        IBaseEntityResponse<GeneralCategoryMaster> InsertCategory(GeneralCategoryMaster item);

        IBaseEntityResponse<GeneralCategoryMaster> UpdateCategory(GeneralCategoryMaster item);

        IBaseEntityResponse<GeneralCategoryMaster> DeleteCategory(GeneralCategoryMaster item);

        IBaseEntityCollectionResponse<GeneralCategoryMaster> GetBySearch(GeneralCategoryMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralCategoryMaster> GetBySearchList(GeneralCategoryMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralCategoryMaster> SelectByID(GeneralCategoryMaster item);
    }
}
