using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ICCRMCallClosure_Web_API_DataProvider
    {
        IBaseEntityResponse<CCRMServiceReportMaster> InsertServiceReport(CCRMServiceReportMaster item);
        IBaseEntityResponse<CCRMServiceReportMaster> InsertServiceReportImage(CCRMServiceReportMaster item);
        IBaseEntityResponse<CCRMServiceReportMaster> InsertFeedBackImage(CCRMServiceReportMaster item);
        IBaseEntityCollectionResponse<CCRMServiceReportMaster> itemHistory(CCRMServiceReportMaster item);

    }
}
