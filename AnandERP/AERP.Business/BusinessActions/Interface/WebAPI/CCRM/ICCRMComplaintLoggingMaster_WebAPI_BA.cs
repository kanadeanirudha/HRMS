using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ICCRMComplaintLoggingMaster_WebAPI_BA
    {
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getComplaintLogsApi(CCRMComplaintLoggingMaster item);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getComplaints(CCRMComplaintLoggingMaster item);
        IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getAllComplaints(CCRMComplaintLoggingMaster item);
    }
}
