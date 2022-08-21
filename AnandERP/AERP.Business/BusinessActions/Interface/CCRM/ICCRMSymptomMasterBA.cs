using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMSymptomMasterBA
    {

        IBaseEntityResponse<CCRMSymptomMaster> InsertCCRMSymptomMaster(CCRMSymptomMaster item);
        IBaseEntityResponse<CCRMSymptomMaster> InsertCCRMSymptomType(CCRMSymptomMaster item);
        IBaseEntityResponse<CCRMSymptomMaster> UpdateCCRMSymptomType(CCRMSymptomMaster item);
        IBaseEntityResponse<CCRMSymptomMaster> DeleteCCRMSymptomMaster(CCRMSymptomMaster item);
        IBaseEntityCollectionResponse<CCRMSymptomMaster> GetBySearch(CCRMSymptomMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMSymptomMaster> GetCCRMSymptomMasterSearchList(CCRMSymptomMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMSymptomMaster> GetDropDownListforCCRMSymptomMaster(CCRMSymptomMasterSearchRequest searchRequest);
        IBaseEntityResponse<CCRMSymptomMaster> SelectByID(CCRMSymptomMaster item);
    }
}
