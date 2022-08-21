using AERP.Base.DTO;
using AERP.Business.BusinessRules;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public class TaskNotificationBA : ITaskNotificationBA
    {
        ITaskNotificationDataProvider _TaskNotificationDataProvider;
        //ITaskNotificationBR _TaskNotificationBR;
        private ILogger _logException;
        public TaskNotificationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
         //   _TaskNotificationBR = new TaskNotificationBR();
            _TaskNotificationDataProvider = new TaskNotificationDataProvider();
        }
       
        /// <summary>
        /// Select all record from TaskNotification table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<TaskNotification> GetBySearchForTaskApproval(TaskNotificationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TaskNotification> TaskNotificationCollection = new BaseEntityCollectionResponse<TaskNotification>();
            try
            {
                if (_TaskNotificationDataProvider != null)
                    TaskNotificationCollection = _TaskNotificationDataProvider.GetTaskNotificationBySearch(searchRequest);
                else
                {
                    TaskNotificationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    TaskNotificationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                TaskNotificationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                TaskNotificationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TaskNotificationCollection;
        }

        public IBaseEntityCollectionResponse<TaskNotification> GetDashboardContentListByAdminRoleID(TaskNotificationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TaskNotification> TaskNotificationCollection = new BaseEntityCollectionResponse<TaskNotification>();
            try
            {
                if (_TaskNotificationDataProvider != null)
                    TaskNotificationCollection = _TaskNotificationDataProvider.GetDashboardContentListByAdminRoleID(searchRequest);
                else
                {
                    TaskNotificationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    TaskNotificationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                TaskNotificationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                TaskNotificationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TaskNotificationCollection;
        }

    }
}
