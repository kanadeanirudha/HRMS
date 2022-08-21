using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IGeneralCategoryMasterDataProvider
    {
        IBaseEntityCollectionResponse<GeneralCategoryMaster> GetCategoryBySearch(GeneralCategoryMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralCategoryMaster> GetCategoryBySearchList(GeneralCategoryMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralCategoryMaster> GetCategoryByID(GeneralCategoryMaster item);

        IBaseEntityResponse<GeneralCategoryMaster> InsertCategory(GeneralCategoryMaster item);

        IBaseEntityResponse<GeneralCategoryMaster> UpdateCategory(GeneralCategoryMaster item);
         
        IBaseEntityResponse<GeneralCategoryMaster> DeleteCategory(GeneralCategoryMaster item);
    }
}
