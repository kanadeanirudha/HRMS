using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.DataProvider
{
   public interface ICCRMServiceCallTypesDataProvider
    {
        IBaseEntityResponse<CCRMServiceCallTypes> InsertCCRMServiceCallTypes(CCRMServiceCallTypes item);
        IBaseEntityResponse<CCRMServiceCallTypes> UpdateCCRMServiceCallTypes(CCRMServiceCallTypes item);
        IBaseEntityResponse<CCRMServiceCallTypes> DeleteCCRMServiceCallTypes(CCRMServiceCallTypes item);
        IBaseEntityResponse<CCRMServiceCallTypes> GetCCRMServiceCallTypesByID(CCRMServiceCallTypes item);
        IBaseEntityCollectionResponse<CCRMServiceCallTypes> GetCCRMServiceCallTypesBySearch(CCRMServiceCallTypesSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMServiceCallTypes> GetCCRMServiceCallTypesList(CCRMServiceCallTypesSearchRequest searchRequest);
    }
}
