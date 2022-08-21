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

namespace AERP.Business.BusinessActions
{
    public class InventoryReportBA : IInventoryReportBA
    {
          IInventoryReportDataProvider _InventoryReportDataProvider;
        private ILogger _logException;
        public InventoryReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryReportDataProvider = new InventoryReportDataProvider();
        }

        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_PriceList(InventoryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReport> InventoryReportCollection = new BaseEntityCollectionResponse<InventoryReport>();
            try
            {
                if (_InventoryReportDataProvider != null)
                    InventoryReportCollection = _InventoryReportDataProvider.GetInventoryReportBySearch_PriceList(searchRequest);
                else
                {
                    InventoryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportCollection;
        }
       //Item Master Missing Exaception Report
        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ItemList(InventoryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReport> InventoryReportCollection = new BaseEntityCollectionResponse<InventoryReport>();
            try
            {
                if (_InventoryReportDataProvider != null)
                    InventoryReportCollection = _InventoryReportDataProvider.GetInventoryReportBySearch_ItemList(searchRequest);
                else
                {
                    InventoryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportCollection;
        }
        //for Inventory Article Expiry  Report
        public IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ArticleList(InventoryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReport> InventoryReportCollection = new BaseEntityCollectionResponse<InventoryReport>();
            try
            {
                if (_InventoryReportDataProvider != null)
                    InventoryReportCollection = _InventoryReportDataProvider.GetInventoryReportBySearch_ArticleList(searchRequest);
                else
                {
                    InventoryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportCollection;
        }

        public IBaseEntityCollectionResponse<InventoryReport> GetItemRequirementReportList(InventoryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReport> InventoryReportCollection = new BaseEntityCollectionResponse<InventoryReport>();
            try
            {
                if (_InventoryReportDataProvider != null)
                    InventoryReportCollection = _InventoryReportDataProvider.GetItemRequirementReportList(searchRequest);
                else
                {
                    InventoryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportCollection;
        }

        public IBaseEntityCollectionResponse<InventoryReport> GetItemHistoryReportList(InventoryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReport> InventoryReportCollection = new BaseEntityCollectionResponse<InventoryReport>();
            try
            {
                if (_InventoryReportDataProvider != null)
                    InventoryReportCollection = _InventoryReportDataProvider.GetItemHistoryReportList(searchRequest);
                else
                {
                    InventoryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportCollection;
        }
    }
}
