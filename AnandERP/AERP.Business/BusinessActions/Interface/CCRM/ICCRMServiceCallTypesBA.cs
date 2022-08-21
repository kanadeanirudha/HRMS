using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMServiceCallTypesBA
    {
        IBaseEntityResponse<CCRMServiceCallTypes> InsertCCRMServiceCallTypes(CCRMServiceCallTypes item);

        IBaseEntityResponse<CCRMServiceCallTypes> UpdateCCRMServiceCallTypes(CCRMServiceCallTypes item);
        IBaseEntityResponse<CCRMServiceCallTypes> DeleteCCRMServiceCallTypes(CCRMServiceCallTypes item);
        IBaseEntityResponse<CCRMServiceCallTypes> SelectByID(CCRMServiceCallTypes item);
        IBaseEntityCollectionResponse<CCRMServiceCallTypes> GetBySearch(CCRMServiceCallTypesSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMServiceCallTypes> GetCCRMServiceCallTypesList(CCRMServiceCallTypesSearchRequest searchRequest);
    }
}
