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
    public class SaleContractBillingTransactionBA : ISaleContractBillingTransactionBA
    {
        ISaleContractBillingTransactionDataProvider _SaleContractBillingTransactionDataProvider;
        private ILogger _logException;

        public SaleContractBillingTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractBillingTransactionDataProvider = new SaleContractBillingTransactionDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetSaleContractBillingTransactionBySearch(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> SaleContractBillingTransactionCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
            try
            {
                if (_SaleContractBillingTransactionDataProvider != null)
                    SaleContractBillingTransactionCollection = _SaleContractBillingTransactionDataProvider.GetSaleContractBillingTransactionBySearch(searchRequest);
                else
                {
                    SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractBillingTransactionCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetBillingTransactionForGeneration(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> SaleContractBillingTransactionCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
            try
            {
                if (_SaleContractBillingTransactionDataProvider != null)
                    SaleContractBillingTransactionCollection = _SaleContractBillingTransactionDataProvider.GetBillingTransactionForGeneration(searchRequest);
                else
                {
                    SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractBillingTransactionCollection;
        }

        public IBaseEntityResponse<SaleContractBillingTransaction> GenerateSaleContractInvoiceTransaction(SaleContractBillingTransaction item)
        {
            IBaseEntityResponse<SaleContractBillingTransaction> entityResponse = new BaseEntityResponse<SaleContractBillingTransaction>();
            try
            {
                if (_SaleContractBillingTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractBillingTransactionDataProvider.GenerateSaleContractInvoiceTransaction(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetBillingTransactionDetailsByID(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> SaleContractBillingTransactionCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
            try
            {
                if (_SaleContractBillingTransactionDataProvider != null)
                    SaleContractBillingTransactionCollection = _SaleContractBillingTransactionDataProvider.GetBillingTransactionDetailsByID(searchRequest);
                else
                {
                    SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractBillingTransactionCollection;
        }
        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetBillingTransactionDetailsByIDForInvoicePDF(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> SaleContractBillingTransactionCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
            try
            {
                if (_SaleContractBillingTransactionDataProvider != null)
                    SaleContractBillingTransactionCollection = _SaleContractBillingTransactionDataProvider.GetBillingTransactionDetailsByIDForInvoicePDF(searchRequest);
                else
                {
                    SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractBillingTransactionCollection;
        }
        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetSummerySheetForBillingTransactionDetails(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> SaleContractBillingTransactionCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
            try
            {
                if (_SaleContractBillingTransactionDataProvider != null)
                    SaleContractBillingTransactionCollection = _SaleContractBillingTransactionDataProvider.GetSummerySheetForBillingTransactionDetails(searchRequest);
                else
                {
                    SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractBillingTransactionCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractBillingTransaction> GetSummerySheetForBillingTransactionDetails_Second(SaleContractBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> SaleContractBillingTransactionCollection = new BaseEntityCollectionResponse<SaleContractBillingTransaction>();
            try
            {
                if (_SaleContractBillingTransactionDataProvider != null)
                    SaleContractBillingTransactionCollection = _SaleContractBillingTransactionDataProvider.GetSummerySheetForBillingTransactionDetails_Second(searchRequest);
                else
                {
                    SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractBillingTransactionCollection;
        }

        public IBaseEntityResponse<SaleContractBillingTransaction> CancelSaleContractInvoiceTransaction(SaleContractBillingTransaction item)
        {
            IBaseEntityResponse<SaleContractBillingTransaction> entityResponse = new BaseEntityResponse<SaleContractBillingTransaction>();
            try
            {
                if (_SaleContractBillingTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractBillingTransactionDataProvider.CancelSaleContractInvoiceTransaction(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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