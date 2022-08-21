using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralItemMerchantiseCategoryDataProvider
    {
        IBaseEntityResponse<GeneralItemMerchantiseCategory> InsertGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> UpdateGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> DeleteGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategoryBySearch(GeneralItemMerchantiseCategorySearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategorySearchList(GeneralItemMerchantiseCategorySearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategoryByID(GeneralItemMerchantiseCategory item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategoryCodeByDepartmentCode(GeneralItemMerchantiseCategorySearchRequest searchRequest);
    }
}
