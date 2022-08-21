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
    public class CCRMComplaintLoggingMaster_WebAPI_BA : ICCRMComplaintLoggingMaster_WebAPI_BA
    {
        private ILogger _logException;
        private ICCRMComplaintLoggingMaster_WebAPI_DataProvider _ICCRMComplaintLoggingMaster_WebAPI_DataProvider;
        public CCRMComplaintLoggingMaster_WebAPI_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMComplaintLoggingMaster_WebAPI_DataProvider = new CCRMComplaintLoggingMaster_WebAPI_DataProvider();
        }

        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getComplaintLogsApi(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> UserMasterCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_ICCRMComplaintLoggingMaster_WebAPI_DataProvider != null)
                    UserMasterCollection = _ICCRMComplaintLoggingMaster_WebAPI_DataProvider.getComplaintLogsApi(item);
                else
                {
                    UserMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterCollection.Message.Add(new MessageDTO
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
            return UserMasterCollection;
        }

        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getComplaints(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> ComplaintCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_ICCRMComplaintLoggingMaster_WebAPI_DataProvider != null)
                    ComplaintCollection = _ICCRMComplaintLoggingMaster_WebAPI_DataProvider.getComplaints(item);
                else
                {
                    ComplaintCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ComplaintCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ComplaintCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ComplaintCollection;
        }

        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> getAllComplaints(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> UserMasterCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_ICCRMComplaintLoggingMaster_WebAPI_DataProvider != null)
                    UserMasterCollection = _ICCRMComplaintLoggingMaster_WebAPI_DataProvider.getAllComplaints(item);
                else
                {
                    UserMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterCollection.Message.Add(new MessageDTO
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
            return UserMasterCollection;
        }

    }
}
