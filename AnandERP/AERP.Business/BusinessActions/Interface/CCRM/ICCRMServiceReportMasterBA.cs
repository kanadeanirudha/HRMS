using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;


namespace AERP.Business.BusinessAction
{
    public interface ICCRMServiceReportMasterBA
    {
        IBaseEntityResponse<CCRMServiceReportMaster> UpdateCCRMServiceReportMaster(CCRMServiceReportMaster item);
        IBaseEntityResponse<CCRMServiceReportMaster> DeleteCCRMServiceReportMaster(CCRMServiceReportMaster item);
        IBaseEntityResponse<CCRMServiceReportMaster> SelectByID(CCRMServiceReportMaster item);
        IBaseEntityCollectionResponse<CCRMServiceReportMaster> GetBySearch(CCRMServiceReportMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMServiceReportMaster> GetListOfItemsByID(CCRMServiceReportMasterSearchRequest searchRequest);
    }
}
