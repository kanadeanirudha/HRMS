using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ICCRMComplaintLoggingMaster_WebAPI_DataProvider
    {
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getComplaintLogsApi(CCRMComplaintLoggingMaster item);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getComplaints(CCRMComplaintLoggingMaster item);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getAllComplaints(CCRMComplaintLoggingMaster item);
    }
}
