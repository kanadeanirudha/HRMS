using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public class InventoryCurrentStockPriceDrillReportBA : IInventoryCurrentStockPriceDrillReportBA
    {
        IInventoryCurrentStockPriceDrillReportDataProvider _InventoryCurrentStockPriceDrillReportDataProvider;
        private ILogger _logException;
        public InventoryCurrentStockPriceDrillReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryCurrentStockPriceDrillReportDataProvider = new InventoryCurrentStockPriceDrillReportDataProvider();
        }

        public IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByOrganisation(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> InventoryCurrentStockPriceDrillReportCollection = new BaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport>();
            try
            {
                if (_InventoryCurrentStockPriceDrillReportDataProvider != null)
                    InventoryCurrentStockPriceDrillReportCollection = _InventoryCurrentStockPriceDrillReportDataProvider.GetInventoryCurrentStockPriceDrillReportByOrganisation(searchRequest);
                else
                {
                    InventoryCurrentStockPriceDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCurrentStockPriceDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCurrentStockPriceDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCurrentStockPriceDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCurrentStockPriceDrillReportCollection;
        }
        //Item Master Missing Exaception Report
        public IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByCentre(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> InventoryCurrentStockPriceDrillReportCollection = new BaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport>();
            try
            {
                if (_InventoryCurrentStockPriceDrillReportDataProvider != null)
                    InventoryCurrentStockPriceDrillReportCollection = _InventoryCurrentStockPriceDrillReportDataProvider.GetInventoryCurrentStockPriceDrillReportByCentre(searchRequest);
                else
                {
                    InventoryCurrentStockPriceDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCurrentStockPriceDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCurrentStockPriceDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCurrentStockPriceDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCurrentStockPriceDrillReportCollection;
        }


        public IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByStore(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> InventoryCurrentStockPriceDrillReportCollection = new BaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport>();
            try
            {
                if (_InventoryCurrentStockPriceDrillReportDataProvider != null)
                    InventoryCurrentStockPriceDrillReportCollection = _InventoryCurrentStockPriceDrillReportDataProvider.GetInventoryCurrentStockPriceDrillReportByStore(searchRequest);
                else
                {
                    InventoryCurrentStockPriceDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCurrentStockPriceDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCurrentStockPriceDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCurrentStockPriceDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCurrentStockPriceDrillReportCollection;
        }


        public IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByArticle(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> InventoryCurrentStockPriceDrillReportCollection = new BaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport>();
            try
            {
                if (_InventoryCurrentStockPriceDrillReportDataProvider != null)
                    InventoryCurrentStockPriceDrillReportCollection = _InventoryCurrentStockPriceDrillReportDataProvider.GetInventoryCurrentStockPriceDrillReportByArticle(searchRequest);
                else
                {
                    InventoryCurrentStockPriceDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCurrentStockPriceDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCurrentStockPriceDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCurrentStockPriceDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCurrentStockPriceDrillReportCollection;
        }
    }
}
