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
    public class CCRMMIFMaster_Web_API_BA : ICCRMMIFMaster_Web_API_BA
    {
        private ILogger _logException;
        private ICCRMMIFMaster_Web_API_DataProvider _ICCRMMIFMaster_Web_API_DataProvider;
        public CCRMMIFMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMMIFMaster_Web_API_DataProvider = new CCRMMIFMaster_Web_API_DataProvider();
        }
        public IBaseEntityCollectionResponse<MIFMaster> getMIFMaster(MIFMaster item)
        {
            IBaseEntityCollectionResponse<MIFMaster> MIFMasterCollection = new BaseEntityCollectionResponse<MIFMaster>();
            try
            {
                if (_ICCRMMIFMaster_Web_API_DataProvider != null)
                    MIFMasterCollection = _ICCRMMIFMaster_Web_API_DataProvider.getMIFMaster(item);
                else
                {
                    MIFMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    MIFMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                MIFMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return MIFMasterCollection;
        }
    }
}
