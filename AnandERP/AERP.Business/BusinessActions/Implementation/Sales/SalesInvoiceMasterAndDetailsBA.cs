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
    public class SalesInvoiceMasterAndDetailsBA : ISalesInvoiceMasterAndDetailsBA
    {
        ISalesInvoiceMasterAndDetailsDataProvider _SalesInvoiceMasterAndDetailsDataProvider;
        ISalesInvoiceMasterAndDetailsBR _SalesInvoiceMasterAndDetailsBR;
        private ILogger _logException;
        public SalesInvoiceMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalesInvoiceMasterAndDetailsBR = new SalesInvoiceMasterAndDetailsBR();
            _SalesInvoiceMasterAndDetailsDataProvider = new SalesInvoiceMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of SalesInvoiceMasterAndDetails.s
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> InsertSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> entityResponse = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesInvoiceMasterAndDetailsBR.InsertSalesInvoiceMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesInvoiceMasterAndDetailsDataProvider.InsertSalesInvoiceMasterAndDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Update a specific record  of SalesInvoiceMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> UpdateSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> entityResponse = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesInvoiceMasterAndDetailsBR.UpdateSalesInvoiceMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesInvoiceMasterAndDetailsDataProvider.UpdateSalesInvoiceMasterAndDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Delete a selected record from SalesInvoiceMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> DeleteSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> entityResponse = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesInvoiceMasterAndDetailsBR.DeleteSalesInvoiceMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesInvoiceMasterAndDetailsDataProvider.DeleteSalesInvoiceMasterAndDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Select all record from SalesInvoiceMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetBySearch(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SalesInvoiceMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                if (_SalesInvoiceMasterAndDetailsDataProvider != null)
                    SalesInvoiceMasterAndDetailsCollection = _SalesInvoiceMasterAndDetailsDataProvider.GetSalesInvoiceMasterAndDetailsBySearch(searchRequest);
                else
                {
                    SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesInvoiceMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetBySearchForServiceItem(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SalesInvoiceMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                if (_SalesInvoiceMasterAndDetailsDataProvider != null)
                    SalesInvoiceMasterAndDetailsCollection = _SalesInvoiceMasterAndDetailsDataProvider.GetServiceInvoiceMasterAndDetailsBySearch(searchRequest);
                else
                {
                    SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesInvoiceMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from SalesInvoiceMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> SelectByID(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> entityResponse = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                entityResponse = _SalesInvoiceMasterAndDetailsDataProvider.GetSalesInvoiceMasterAndDetailsByID(item);
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
        /// <summary>
        /// Select a record from SalesInvoiceMasterAndDetails table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SelectBySalesOrderMasterID(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SalesInvoiceMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                if (_SalesInvoiceMasterAndDetailsDataProvider != null)
                    SalesInvoiceMasterAndDetailsCollection = _SalesInvoiceMasterAndDetailsDataProvider.SelectBySalesOrderMasterID(searchRequest);
                else
                {
                    SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesInvoiceMasterAndDetailsCollection;
        }


        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> ViewDetailsBySalesInvoiceMasterID(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SalesInvoiceMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                if (_SalesInvoiceMasterAndDetailsDataProvider != null)
                    SalesInvoiceMasterAndDetailsCollection = _SalesInvoiceMasterAndDetailsDataProvider.ViewDetailsBySalesInvoiceMasterID(searchRequest);
                else
                {
                    SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesInvoiceMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetRecordForSalesinvoiceOrderPDF(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SalesInvoiceMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                if (_SalesInvoiceMasterAndDetailsDataProvider != null)
                    SalesInvoiceMasterAndDetailsCollection = _SalesInvoiceMasterAndDetailsDataProvider.GetRecordForSalesinvoiceOrderPDF(searchRequest);
                else
                {
                    SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesInvoiceMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetRecordForServiceinvoiceOrderPDF(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SalesInvoiceMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                if (_SalesInvoiceMasterAndDetailsDataProvider != null)
                    SalesInvoiceMasterAndDetailsCollection = _SalesInvoiceMasterAndDetailsDataProvider.GetRecordForServiceinvoiceOrderPDF(searchRequest);
                else
                {
                    SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesInvoiceMasterAndDetailsCollection;
        }

        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> InsertDirectSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> entityResponse = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesInvoiceMasterAndDetailsBR.InsertDirectSalesInvoiceMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesInvoiceMasterAndDetailsDataProvider.InsertDirectSalesInvoiceMasterAndDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        public IBaseEntityResponse<SalesInvoiceMasterAndDetails> CancelSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item)
        {
            IBaseEntityResponse<SalesInvoiceMasterAndDetails> entityResponse = new BaseEntityResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesInvoiceMasterAndDetailsBR.InsertSalesInvoiceMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesInvoiceMasterAndDetailsDataProvider.CancelSalesInvoiceMasterAndDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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

        public IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetSalesInvoiceNumberSearchList(SalesInvoiceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SalesInvoiceMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesInvoiceMasterAndDetails>();
            try
            {
                if (_SalesInvoiceMasterAndDetailsDataProvider != null)
                    SalesInvoiceMasterAndDetailsCollection = _SalesInvoiceMasterAndDetailsDataProvider.GetSalesInvoiceNumberSearchList(searchRequest);
                else
                {
                    SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesInvoiceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesInvoiceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesInvoiceMasterAndDetailsCollection;
        }
    }
}
