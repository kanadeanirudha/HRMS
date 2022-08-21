using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ITaskNotificationBA
    {
       
        IBaseEntityCollectionResponse<TaskNotification> GetBySearchForTaskApproval(TaskNotificationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<TaskNotification> GetDashboardContentListByAdminRoleID(TaskNotificationSearchRequest searchRequest);
        
    }
}

