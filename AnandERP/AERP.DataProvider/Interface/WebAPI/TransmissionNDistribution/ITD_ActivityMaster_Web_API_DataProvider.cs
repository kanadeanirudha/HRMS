using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ITD_ActivityMaster_Web_API_DataProvider
    {
        IBaseEntityCollectionResponse<ActivityMaster> getActivities(ActivityMaster item);
        IBaseEntityCollectionResponse<SubActivitymaster> getSubActivities(SubActivitymaster item);

    }
}
