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
    public class ServiceCallTypeMaster_Web_API_BA : IServiceCallTypeMaster_Web_API_BA
    {
        private ILogger _logException;
        private IServiceCallTypeMaster_Web_API_DataProvider _IServiceCallTypeMaster_Web_API_DataProvider;
        public ServiceCallTypeMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _IServiceCallTypeMaster_Web_API_DataProvider = new ServiceCallTypeMaster_Web_API_DataProvider();
        }
        public IBaseEntityCollectionResponse<CCRMServiceCallTypes> getServiceCallTypes(CCRMServiceCallTypes item)
        {
            IBaseEntityCollectionResponse<CCRMServiceCallTypes> CCRMServiceCallTypesCollection = new BaseEntityCollectionResponse<CCRMServiceCallTypes>();
            try
            {
                if (_IServiceCallTypeMaster_Web_API_DataProvider != null)
                    CCRMServiceCallTypesCollection = _IServiceCallTypeMaster_Web_API_DataProvider.getServiceCallTypes(item);
                else
                {
                    CCRMServiceCallTypesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMServiceCallTypesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMServiceCallTypesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMServiceCallTypesCollection;
        }
    }
}
