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
    public class CCRMCauseMaster_Web_API_BA : ICCRMCauseMaster_Web_API_BA
    {
        private ILogger _logException;
        private ICCRMCauseMaster_Web_API_DataProvider _ICCRMCauseMaster_Web_API_DataProvider;
        public CCRMCauseMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMCauseMaster_Web_API_DataProvider = new CCRMCauseMaster_Web_API_DataProvider();
        }
        public IBaseEntityCollectionResponse<CCRMCauseMaster> getCauseOnSearchApi(CCRMCauseMaster item)
        {
            IBaseEntityCollectionResponse<CCRMCauseMaster> CauseMasterCollection = new BaseEntityCollectionResponse<CCRMCauseMaster>();
            try
            {
                if (_ICCRMCauseMaster_Web_API_DataProvider != null)
                    CauseMasterCollection = _ICCRMCauseMaster_Web_API_DataProvider.getCauseOnSearchApi(item);
                else
                {
                    CauseMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CauseMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CauseMasterCollection.Message.Add(new MessageDTO
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
            return CauseMasterCollection;
        }
    }
}
