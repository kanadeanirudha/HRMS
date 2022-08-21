using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ITD_StatusMaster_Web_API_DataProvider
    {
        IBaseEntityCollectionResponse<StatusMaster> getStatus(StatusMaster item);
        IBaseEntityCollectionResponse<StatusMaster> getBrokenReason(StatusMaster item);
    }
}
