
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralItemCategoryMasterBA
    {
        IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMaster(GeneralItemCategoryMaster item);
        IBaseEntityResponse<GeneralItemCategoryMaster> UpdateGeneralItemCategoryMaster(GeneralItemCategoryMaster item);
        IBaseEntityResponse<GeneralItemCategoryMaster> DeleteGeneralItemCategoryMaster(GeneralItemCategoryMaster item);
        IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetBySearch(GeneralItemCategoryMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterSearchList(GeneralItemCategoryMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemCategoryMaster> SelectByID(GeneralItemCategoryMaster item);
        IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMasterExcel(GeneralItemCategoryMaster item);
        IBaseEntityResponse<GeneralItemCategoryMaster> GetGeneralItemByCategoryCode(GeneralItemCategoryMaster item);
        IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetBySearchList(GeneralItemCategoryMasterSearchRequest searchRequest);
    }
}

