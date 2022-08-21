using AERP.Base.DTO;
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
    public class TD_ActivityMaster_Web_API_BA : ITD_ActivityMaster_Web_API_BA
    {
        private ILogger _logException;
        private ITD_ActivityMaster_Web_API_DataProvider _ITD_ActivityMaster_Web_API_DataProvider;
        public TD_ActivityMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ITD_ActivityMaster_Web_API_DataProvider = new TD_ActivityMaster_Web_API_DataProvider();
        }

        public IBaseEntityCollectionResponse<ActivityMaster> getActivities(ActivityMaster item)
        {
            IBaseEntityCollectionResponse<ActivityMaster> ActivityMasterCollection = new BaseEntityCollectionResponse<ActivityMaster>();
            try
            {
                if (_ITD_ActivityMaster_Web_API_DataProvider != null)
                    ActivityMasterCollection = _ITD_ActivityMaster_Web_API_DataProvider.getActivities(item);
                else
                {
                    ActivityMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ActivityMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ActivityMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ActivityMasterCollection;
        }

        public IBaseEntityCollectionResponse<SubActivitymaster> getSubActivities(SubActivitymaster item)
        {
            IBaseEntityCollectionResponse<SubActivitymaster> SubActivityMasterCollection = new BaseEntityCollectionResponse<SubActivitymaster>();
            try
            {
                if (_ITD_ActivityMaster_Web_API_DataProvider != null)
                    SubActivityMasterCollection = _ITD_ActivityMaster_Web_API_DataProvider.getSubActivities(item);
                else
                {
                    SubActivityMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SubActivityMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SubActivityMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SubActivityMasterCollection;
        }
    }
}
