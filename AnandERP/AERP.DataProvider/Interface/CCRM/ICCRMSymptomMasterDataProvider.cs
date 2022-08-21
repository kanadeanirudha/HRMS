using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
  public  interface ICCRMSymptomMasterDataProvider
    {
        IBaseEntityResponse<CCRMSymptomMaster> InsertCCRMSymptomMaster(CCRMSymptomMaster item);
        IBaseEntityResponse<CCRMSymptomMaster> InsertCCRMSymptomType(CCRMSymptomMaster item);
        IBaseEntityResponse<CCRMSymptomMaster> UpdateCCRMSymptomType(CCRMSymptomMaster item);
        IBaseEntityResponse<CCRMSymptomMaster> DeleteCCRMSymptomMaster(CCRMSymptomMaster item);
        IBaseEntityCollectionResponse<CCRMSymptomMaster> GetCCRMSymptomMasterBySearch(CCRMSymptomMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMSymptomMaster> GetCCRMSymptomMasterSearchList(CCRMSymptomMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMSymptomMaster> GetDropDownListforCCRMSymptomMaster(CCRMSymptomMasterSearchRequest searchRequest);
        IBaseEntityResponse<CCRMSymptomMaster> GetCCRMSymptomTypeByID(CCRMSymptomMaster item);
    }
}
