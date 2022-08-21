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
    public class CCRMCallTrack_Web_API_BA : ICCRMCallTrack_Web_API_BA
    {
        private ILogger _logException;
        private ICCRMCallTrack_Web_API_DataProvider _ICCRMCallTrack_Web_API_DataProvider;
        public CCRMCallTrack_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMCallTrack_Web_API_DataProvider = new CCRMCallTrack_Web_API_DataProvider();
        }
        public IBaseEntityResponse<CCRMCallTrack> InsertCallTrack(CCRMCallTrack item)
        {
            IBaseEntityResponse<CCRMCallTrack> entityResponse = new BaseEntityResponse<CCRMCallTrack>();
            try
            {
                entityResponse = _ICCRMCallTrack_Web_API_DataProvider.InsertCallTrack(item);
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
