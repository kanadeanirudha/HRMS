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
    public class CCRMCallClosure_Web_API_BA : ICCRMCallClosure_Web_API_BA
    {
        private ILogger _logException;
        private ICCRMCallClosure_Web_API_DataProvider _ICCRMCallClosure_Web_API_DataProvider;
        public CCRMCallClosure_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMCallClosure_Web_API_DataProvider = new CCRMCallClosure_Web_API_DataProvider();
        }

        public IBaseEntityResponse<CCRMServiceReportMaster> InsertServiceReport(CCRMServiceReportMaster item)
        {
            IBaseEntityResponse<CCRMServiceReportMaster> entityResponse = new BaseEntityResponse<CCRMServiceReportMaster>();
            try
            {
                entityResponse = _ICCRMCallClosure_Web_API_DataProvider.InsertServiceReport(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityResponse<CCRMServiceReportMaster> InsertServiceReportImage(CCRMServiceReportMaster item)
        {
            IBaseEntityResponse<CCRMServiceReportMaster> entityResponse = new BaseEntityResponse<CCRMServiceReportMaster>();
            try
            {
                entityResponse = _ICCRMCallClosure_Web_API_DataProvider.InsertServiceReportImage(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityResponse<CCRMServiceReportMaster> InsertFeedBackImage(CCRMServiceReportMaster item)
        {
            IBaseEntityResponse<CCRMServiceReportMaster> entityResponse = new BaseEntityResponse<CCRMServiceReportMaster>();
            try
            {
                entityResponse = _ICCRMCallClosure_Web_API_DataProvider.InsertFeedBackImage(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityCollectionResponse<CCRMServiceReportMaster> itemHistory(CCRMServiceReportMaster item)
        {
            IBaseEntityCollectionResponse<CCRMServiceReportMaster> entityResponse = new BaseEntityCollectionResponse<CCRMServiceReportMaster>();
            try
            {
                if (_ICCRMCallClosure_Web_API_DataProvider != null)
                    entityResponse = _ICCRMCallClosure_Web_API_DataProvider.itemHistory(item);
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
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
            return entityResponse;
        }
    }
}
