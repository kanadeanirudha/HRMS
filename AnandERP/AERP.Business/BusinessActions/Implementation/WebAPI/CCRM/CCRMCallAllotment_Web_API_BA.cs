using AERP.Base.DTO;
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
    public class CCRMCallAllotment_Web_API_BA : ICCRMCallAllotment_WebAPI_BA
    {
        private ILogger _logException;
        private ICCRMCallAllotment_Web_API_DataProvider _ICCRMCallAllotment_Web_API_DataProvider;
        public CCRMCallAllotment_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMCallAllotment_Web_API_DataProvider = new CCRMCallAllotment_Web_API_DataProvider();
        }
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> InsertCallAllotment(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityResponse<CCRMComplaintLoggingMaster> entityResponse = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
            try
            {
                entityResponse = _ICCRMCallAllotment_Web_API_DataProvider.InsertCallAllotment(item);
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
    }
}
