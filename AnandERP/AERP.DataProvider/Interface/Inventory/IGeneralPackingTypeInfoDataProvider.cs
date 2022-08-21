using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralPackingTypeInfoDataProvider
    {
        IBaseEntityResponse<GeneralPackingTypeInfo> InsertGeneralPackingTypeInfo(GeneralPackingTypeInfo item);
        IBaseEntityResponse<GeneralPackingTypeInfo> UpdateGeneralPackingTypeInfo(GeneralPackingTypeInfo item);
        IBaseEntityResponse<GeneralPackingTypeInfo> DeleteGeneralPackingTypeInfo(GeneralPackingTypeInfo item);
        IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GetGeneralPackingTypeInfoBySearch(GeneralPackingTypeInfoSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GetGeneralPackingTypeInfoSearchList(GeneralPackingTypeInfoSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPackingTypeInfo> GetGeneralPackingTypeInfoByID(GeneralPackingTypeInfo item);
    }
}
