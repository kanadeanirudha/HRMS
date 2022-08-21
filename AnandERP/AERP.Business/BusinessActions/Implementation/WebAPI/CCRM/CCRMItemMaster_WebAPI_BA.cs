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
    public class CCRMItemMaster_WebAPI_BA : ICCRMItemMaster_WebAPI_BA
    {
        private ILogger _logException;
        private ICCRMItemMaster_Web_API_DataProvider _ICCRMItemMaster_Web_API_DataProvider;
        public CCRMItemMaster_WebAPI_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMItemMaster_Web_API_DataProvider = new CCRMItemMaster_Web_API_DataProvider();
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> getItemOnSearchApi(GeneralItemMaster item)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> UserMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_ICCRMItemMaster_Web_API_DataProvider != null)
                    UserMasterCollection = _ICCRMItemMaster_Web_API_DataProvider.getItemOnSearchApi(item);
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
