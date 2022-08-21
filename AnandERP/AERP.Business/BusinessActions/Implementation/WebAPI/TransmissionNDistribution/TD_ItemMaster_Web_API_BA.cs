using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.Common;
using AERP.DataProvider;

namespace AERP.Business.BusinessAction
{
    public class TD_ItemMaster_Web_API_BA : ITD_ItemMaster_Web_API_BA
    {
        private ILogger _logException;
        private ITD_ItemMaster_Web_API_DataProvider _ITD_ItemMaster_Web_API_DataProvider;
        public TD_ItemMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ITD_ItemMaster_Web_API_DataProvider = new TD_ItemMaster_Web_API_DataProvider();
        }

        public IBaseEntityCollectionResponse<ItemMaster> getItems(ItemMaster item)
        {
            IBaseEntityCollectionResponse<ItemMaster> ItemMasterCollection = new BaseEntityCollectionResponse<ItemMaster>();
            try
            {
                if (_ITD_ItemMaster_Web_API_DataProvider != null)
                    ItemMasterCollection = _ITD_ItemMaster_Web_API_DataProvider.getItems(item);
                else
                {
                    ItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ItemMasterCollection.Message.Add(new MessageDTO
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
            return ItemMasterCollection;
        }
    }
}
