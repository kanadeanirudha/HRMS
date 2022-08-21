using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralItemMarchandiseGroupDataProvider
    {
        IBaseEntityResponse<GeneralItemMarchandiseGroup> InsertGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item);
        IBaseEntityResponse<GeneralItemMarchandiseGroup> UpdateGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item);
        IBaseEntityResponse<GeneralItemMarchandiseGroup> DeleteGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupBySearch(GeneralItemMarchandiseGroupSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupSearchList(GeneralItemMarchandiseGroupSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupByID(GeneralItemMarchandiseGroup item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupSearchListForCategory(GeneralItemMarchandiseGroupSearchRequest searchRequest);

    }
}
