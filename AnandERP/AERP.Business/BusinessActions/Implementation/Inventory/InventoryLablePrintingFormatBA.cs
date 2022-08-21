using AERP.Base.DTO;
using AERP.Business.BusinessRules;
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
    public class InventoryLablePrintingFormatBA : IInventoryLablePrintingFormatBA
    {
          IInventoryLablePrintingFormatDataProvider _InventoryLablePrintingFormatDataProvider;
        private ILogger _logException;
        public InventoryLablePrintingFormatBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryLablePrintingFormatDataProvider = new InventoryLablePrintingFormatDataProvider();
        }

        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatByGeneralUnitsID(InventoryLablePrintingFormatSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLablePrintingFormat> InventoryLablePrintingFormatCollection = new BaseEntityCollectionResponse<InventoryLablePrintingFormat>();
            try
            {
                if (_InventoryLablePrintingFormatDataProvider != null)
                    InventoryLablePrintingFormatCollection = _InventoryLablePrintingFormatDataProvider.GetInventoryLablePrintingFormatByGeneralUnitsID(searchRequest);
                else
                {
                    InventoryLablePrintingFormatCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLablePrintingFormatCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLablePrintingFormatCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLablePrintingFormatCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLablePrintingFormatCollection;
        }
       //Item Master Missing Exaception Report
        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetInventoryLablePrintingFormatBySearch_ItemList(InventoryLablePrintingFormatSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLablePrintingFormat> InventoryLablePrintingFormatCollection = new BaseEntityCollectionResponse<InventoryLablePrintingFormat>();
            try
            {
                if (_InventoryLablePrintingFormatDataProvider != null)
                    InventoryLablePrintingFormatCollection = _InventoryLablePrintingFormatDataProvider.GetInventoryLablePrintingFormatBySearch_ItemList(searchRequest);
                else
                {
                    InventoryLablePrintingFormatCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLablePrintingFormatCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLablePrintingFormatCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLablePrintingFormatCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLablePrintingFormatCollection;
        }

        public IBaseEntityCollectionResponse<InventoryLablePrintingFormat> GetItemNumberList(InventoryLablePrintingFormatSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLablePrintingFormat> InventoryLablePrintingFormatCollection = new BaseEntityCollectionResponse<InventoryLablePrintingFormat>();
            try
            {
                if (_InventoryLablePrintingFormatDataProvider != null)
                    InventoryLablePrintingFormatCollection = _InventoryLablePrintingFormatDataProvider.GetItemNumberList(searchRequest);
                else
                {
                    InventoryLablePrintingFormatCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLablePrintingFormatCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLablePrintingFormatCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLablePrintingFormatCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLablePrintingFormatCollection;
        }
    }
}
