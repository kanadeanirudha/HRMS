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
    public class CCRMActionMaster_Web_API_BA : ICCRMActionMaster_Web_API_BA
    {
        private ILogger _logException;
        private ICCRMActionMaster_Web_API_DataProvider _ICCRMActionMaster_Web_API_DataProvider;
        public CCRMActionMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMActionMaster_Web_API_DataProvider = new CCRMActionMaster_Web_API_DataProvider();
        }
        public IBaseEntityCollectionResponse<CCRMActionMaster> getActionOnSearchApi(CCRMActionMaster item)
        {
            IBaseEntityCollectionResponse<CCRMActionMaster> ActionMasterCollection = new BaseEntityCollectionResponse<CCRMActionMaster>();
            try
            {
                if (_ICCRMActionMaster_Web_API_DataProvider != null)
                    ActionMasterCollection = _ICCRMActionMaster_Web_API_DataProvider.getActionOnSearchApi(item);
                else
                {
                    ActionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ActionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ActionMasterCollection.Message.Add(new MessageDTO
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
            return ActionMasterCollection;
        }
    }
}
