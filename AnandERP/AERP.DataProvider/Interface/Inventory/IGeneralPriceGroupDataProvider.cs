using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralPriceGroupDataProvider
    {
        IBaseEntityResponse<GeneralPriceGroup> InsertGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityResponse<GeneralPriceGroup> UpdateGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityResponse<GeneralPriceGroup> DeleteGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityCollectionResponse<GeneralPriceGroup> GetGeneralPriceGroupBySearch(GeneralPriceGroupSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPriceGroup> GetGeneralPriceGroupSearchList(GeneralPriceGroupSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceGroup> GetGeneralPriceGroupByID(GeneralPriceGroup item);
    }
}
