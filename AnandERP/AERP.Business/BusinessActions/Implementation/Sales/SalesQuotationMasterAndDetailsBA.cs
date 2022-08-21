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
    public class SalesQuotationMasterAndDetailsBA : ISalesQuotationMasterAndDetailsBA
    {
        ISalesQuotationMasterAndDetailsDataProvider _SalesQuotationMasterAndDetailsDataProvider;
        ISalesQuotationMasterAndDetailsBR _SalesQuotationMasterAndDetailsBR;
        private ILogger _logException;
        public SalesQuotationMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalesQuotationMasterAndDetailsBR = new SalesQuotationMasterAndDetailsBR();
            _SalesQuotationMasterAndDetailsDataProvider = new SalesQuotationMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of SalesQuotationMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesQuotationMasterAndDetails> InsertSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item)
        {
            IBaseEntityResponse<SalesQuotationMasterAndDetails> entityResponse = new BaseEntityResponse<SalesQuotationMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesQuotationMasterAndDetailsBR.InsertSalesQuotationMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesQuotationMasterAndDetailsDataProvider.InsertSalesQuotationMasterAndDetails(item);
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
        /// Update a specific record  of SalesQuotationMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesQuotationMasterAndDetails> UpdateSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item)
        {
            IBaseEntityResponse<SalesQuotationMasterAndDetails> entityResponse = new BaseEntityResponse<SalesQuotationMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesQuotationMasterAndDetailsBR.UpdateSalesQuotationMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesQuotationMasterAndDetailsDataProvider.UpdateSalesQuotationMasterAndDetails(item);
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
        /// Delete a selected record from SalesQuotationMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesQuotationMasterAndDetails> DeleteSalesQuotationMasterAndDetails(SalesQuotationMasterAndDetails item)
        {
            IBaseEntityResponse<SalesQuotationMasterAndDetails> entityResponse = new BaseEntityResponse<SalesQuotationMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesQuotationMasterAndDetailsBR.DeleteSalesQuotationMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesQuotationMasterAndDetailsDataProvider.DeleteSalesQuotationMasterAndDetails(item);
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
        /// Select all record from SalesQuotationMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetBySearch(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> SalesQuotationMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
            try
            {
                if (_SalesQuotationMasterAndDetailsDataProvider != null)
                    SalesQuotationMasterAndDetailsCollection = _SalesQuotationMasterAndDetailsDataProvider.GetSalesQuotationMasterAndDetailsBySearch(searchRequest);
                else
                {
                    SalesQuotationMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesQuotationMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesQuotationMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesQuotationMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesQuotationMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetSalesQuotationMasterAndDetailsSearchList(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> SalesQuotationMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
            try
            {
                if (_SalesQuotationMasterAndDetailsDataProvider != null)
                    SalesQuotationMasterAndDetailsCollection = _SalesQuotationMasterAndDetailsDataProvider.GetSalesQuotationMasterAndDetailsSearchList(searchRequest);
                else
                {
                    SalesQuotationMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesQuotationMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesQuotationMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesQuotationMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesQuotationMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from SalesQuotationMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesQuotationMasterAndDetails> SelectByID(SalesQuotationMasterAndDetails item)
        {
            IBaseEntityResponse<SalesQuotationMasterAndDetails> entityResponse = new BaseEntityResponse<SalesQuotationMasterAndDetails>();
            try
            {
                entityResponse = _SalesQuotationMasterAndDetailsDataProvider.GetSalesQuotationMasterAndDetailsByID(item);
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

        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetQuotationMasterDetailsByEnquiryMaterID(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> CustomerMasterCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
            try
            {
                if (_SalesQuotationMasterAndDetailsDataProvider != null)
                    CustomerMasterCollection = _SalesQuotationMasterAndDetailsDataProvider.GetQuotationMasterDetailsByEnquiryMaterID(searchRequest);
                else
                {
                    CustomerMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CustomerMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CustomerMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CustomerMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CustomerMasterCollection;
        }
        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetUomWiseSalesPrice(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> CustomerMasterCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
            try
            {
                if (_SalesQuotationMasterAndDetailsDataProvider != null)
                    CustomerMasterCollection = _SalesQuotationMasterAndDetailsDataProvider.GetUomWiseSalesPrice(searchRequest);
                else
                {
                    CustomerMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CustomerMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CustomerMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CustomerMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CustomerMasterCollection;
        }
        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetItemNumberSearchListForCustomer(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> CustomerMasterCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
            try
            {
                if (_SalesQuotationMasterAndDetailsDataProvider != null)
                    CustomerMasterCollection = _SalesQuotationMasterAndDetailsDataProvider.GetItemNumberSearchListForCustomer(searchRequest);
                else
                {
                    CustomerMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CustomerMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CustomerMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CustomerMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CustomerMasterCollection;
        }
        public IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> GetQuotationMasterDetailsListByQuotationMasterID(SalesQuotationMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesQuotationMasterAndDetails> CustomerMasterCollection = new BaseEntityCollectionResponse<SalesQuotationMasterAndDetails>();
            try
            {
                if (_SalesQuotationMasterAndDetailsDataProvider != null)
                    CustomerMasterCollection = _SalesQuotationMasterAndDetailsDataProvider.GetQuotationMasterDetailsListByQuotationMasterID(searchRequest);
                else
                {
                    CustomerMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CustomerMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CustomerMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CustomerMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CustomerMasterCollection;
        }

    }
}
