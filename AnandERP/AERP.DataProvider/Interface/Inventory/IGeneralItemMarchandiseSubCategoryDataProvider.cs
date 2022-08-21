using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralItemMarchandiseSubCategoryDataProvider
    {
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> InsertGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> UpdateGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> DeleteGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMarchandiseSubCategoryBySearch(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMarchandiseSubCategorySearchList(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMarchandiseSubCategoryByID(GeneralItemMarchandiseSubCategory item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMerchantiseSubCategoryCodeByDepartmentCode(GeneralItemMarchandiseSubCategorySearchRequest searchRequest);
    }
}
