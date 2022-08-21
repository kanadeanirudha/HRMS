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
    public class TD_ConsumerMaster_Web_API_BA : ITD_ConsumerMaster_Web_API_BA
    {
        private ILogger _logException;
        private ITD_ConsumerMaster_Web_API_DataProvider _ITD_ConsumerMaster_Web_API_DataProvider;
        public TD_ConsumerMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ITD_ConsumerMaster_Web_API_DataProvider = new TD_ConsumerMaster_Web_API_DataProvider();
        }

        public IBaseEntityCollectionResponse<ConsumerMaster> getConsumers(ConsumerMaster item)
        {
            IBaseEntityCollectionResponse<ConsumerMaster> ConsumerMasterCollection = new BaseEntityCollectionResponse<ConsumerMaster>();
            try
            {
                if (_ITD_ConsumerMaster_Web_API_DataProvider != null)
                    ConsumerMasterCollection = _ITD_ConsumerMaster_Web_API_DataProvider.getConsumers(item);
                else
                {
                    ConsumerMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ConsumerMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ConsumerMasterCollection.Message.Add(new MessageDTO
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
            return ConsumerMasterCollection;
        }

        public IBaseEntityResponse<ConsumerMaster> DeleteConsumer(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> entityResponse = new BaseEntityResponse<ConsumerMaster>();
            try
            {
                entityResponse = _ITD_ConsumerMaster_Web_API_DataProvider.DeleteConsumer(item);
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

        public IBaseEntityResponse<ConsumerMaster> UpdateConsumerLatLong(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> entityResponse = new BaseEntityResponse<ConsumerMaster>();
            try
            {
                entityResponse = _ITD_ConsumerMaster_Web_API_DataProvider.UpdateConsumerLatLong(item);
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

        public IBaseEntityResponse<ConsumerMaster> UpdateTappingPointLatLong(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> entityResponse = new BaseEntityResponse<ConsumerMaster>();
            try
            {
                entityResponse = _ITD_ConsumerMaster_Web_API_DataProvider.UpdateTappingPointLatLong(item);
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

        public IBaseEntityResponse<ConsumerMaster> AddConsumerRequirment(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> entityResponse = new BaseEntityResponse<ConsumerMaster>();
            try
            {
                entityResponse = _ITD_ConsumerMaster_Web_API_DataProvider.AddConsumerRequirment(item);
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

        public IBaseEntityResponse<ConsumerMaster> InsertImage(ConsumerMaster item)
        {
            IBaseEntityResponse<ConsumerMaster> entityResponse = new BaseEntityResponse<ConsumerMaster>();
            try
            {
                entityResponse = _ITD_ConsumerMaster_Web_API_DataProvider.InsertImage(item);
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

        public IBaseEntityCollectionResponse<ConsumerMaster> generateGroups(ConsumerMaster item)
        {
            IBaseEntityCollectionResponse<ConsumerMaster> ConsumerMasterCollection = new BaseEntityCollectionResponse<ConsumerMaster>();
            try
            {
                if (_ITD_ConsumerMaster_Web_API_DataProvider != null)
                    ConsumerMasterCollection = _ITD_ConsumerMaster_Web_API_DataProvider.generateGroups(item);
                else
                {
                    ConsumerMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ConsumerMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ConsumerMasterCollection.Message.Add(new MessageDTO
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
            return ConsumerMasterCollection;
        }
    }
}
