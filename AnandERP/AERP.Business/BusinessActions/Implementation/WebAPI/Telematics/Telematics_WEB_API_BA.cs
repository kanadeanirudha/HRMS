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
    public class Telematics_WEB_API_BA : ITelematics_WEB_API_BA
    {
        private ILogger _logException;
        private ITelematics_WEB_API_DataProvider _ITelematics_WEB_API_DataProvider;
        public Telematics_WEB_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ITelematics_WEB_API_DataProvider = new Telematics_WEB_API_DataProvider();
        }
        public IBaseEntityResponse<SensorData> InsertTelematics(SensorData item)
        {
            IBaseEntityResponse<SensorData> entityResponse = new BaseEntityResponse<SensorData>();
            try
            {
                entityResponse = _ITelematics_WEB_API_DataProvider.InsertSensorData(item);
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
