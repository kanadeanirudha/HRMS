using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralItemCategoryMasterDataProvider
    {
        IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMaster(GeneralItemCategoryMaster item);
        IBaseEntityResponse<GeneralItemCategoryMaster> UpdateGeneralItemCategoryMaster(GeneralItemCategoryMaster item);
        IBaseEntityResponse<GeneralItemCategoryMaster> DeleteGeneralItemCategoryMaster(GeneralItemCategoryMaster item);
        IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterBySearch(GeneralItemCategoryMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterSearchList(GeneralItemCategoryMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterByID(GeneralItemCategoryMaster item);
        IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMasterExcel(GeneralItemCategoryMaster item);
        IBaseEntityResponse<GeneralItemCategoryMaster> GetGeneralItemByCategoryCode(GeneralItemCategoryMaster item);
        IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterGetBySearchList(GeneralItemCategoryMasterSearchRequest searchRequest);
    }
}
