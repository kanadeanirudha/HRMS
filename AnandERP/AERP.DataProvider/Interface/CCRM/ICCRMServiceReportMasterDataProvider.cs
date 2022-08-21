using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
    public interface ICCRMServiceReportMasterDataProvider
    {
        IBaseEntityResponse<CCRMServiceReportMaster> UpdateCCRMServiceReportMaster(CCRMServiceReportMaster item);
        IBaseEntityResponse<CCRMServiceReportMaster> DeleteCCRMServiceReportMaster(CCRMServiceReportMaster item);
        IBaseEntityResponse<CCRMServiceReportMaster> GetCCRMServiceReportMasterByID(CCRMServiceReportMaster item);
        IBaseEntityCollectionResponse<CCRMServiceReportMaster> GetCCRMServiceReportMasterBySearch(CCRMServiceReportMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMServiceReportMaster> GetListOfItemsByID(CCRMServiceReportMasterSearchRequest searchRequest);
    }
}
