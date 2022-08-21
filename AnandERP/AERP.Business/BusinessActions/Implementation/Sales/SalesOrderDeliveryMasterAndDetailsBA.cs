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
    public class SalesOrderDeliveryMasterAndDetailsBA : ISalesOrderDeliveryMasterAndDetailsBA
    {
        ISalesOrderDeliveryMasterAndDetailsDataProvider _SalesOrderDeliveryMasterAndDetailsDataProvider;
        ISalesOrderDeliveryMasterAndDetailsBR _SalesOrderDeliveryMasterAndDetailsBR;
        private ILogger _logException;
        public SalesOrderDeliveryMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalesOrderDeliveryMasterAndDetailsBR = new SalesOrderDeliveryMasterAndDetailsBR();
            _SalesOrderDeliveryMasterAndDetailsDataProvider = new SalesOrderDeliveryMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of SalesOrderDeliveryMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> InsertSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesOrderDeliveryMasterAndDetailsBR.InsertSalesOrderDeliveryMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesOrderDeliveryMasterAndDetailsDataProvider.InsertSalesOrderDeliveryMasterAndDetails(item);
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

        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> InsertSalesOrderDeliveryMasterAndDetailsForDirectDM(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesOrderDeliveryMasterAndDetailsBR.InsertSalesOrderDeliveryMasterAndDetailsForDirectDMValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesOrderDeliveryMasterAndDetailsDataProvider.InsertSalesOrderDeliveryMasterAndDetailsForDirectDM(item);
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
        /// Update a specific record  of SalesOrderDeliveryMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> UpdateSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesOrderDeliveryMasterAndDetailsBR.UpdateSalesOrderDeliveryMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesOrderDeliveryMasterAndDetailsDataProvider.UpdateSalesOrderDeliveryMasterAndDetails(item);
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
        /// Delete a selected record from SalesOrderDeliveryMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> DeleteSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesOrderDeliveryMasterAndDetailsBR.DeleteSalesOrderDeliveryMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesOrderDeliveryMasterAndDetailsDataProvider.DeleteSalesOrderDeliveryMasterAndDetails(item);
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
        /// Select all record from SalesOrderDeliveryMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetBySearch(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> SalesOrderDeliveryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                if (_SalesOrderDeliveryMasterAndDetailsDataProvider != null)
                    SalesOrderDeliveryMasterAndDetailsCollection = _SalesOrderDeliveryMasterAndDetailsDataProvider.GetSalesOrderDeliveryMasterAndDetailsBySearch(searchRequest);
                else
                {
                    SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderDeliveryMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetSalesOrderDeliveryMasterAndDetailsSearchList(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> SalesOrderDeliveryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                if (_SalesOrderDeliveryMasterAndDetailsDataProvider != null)
                    SalesOrderDeliveryMasterAndDetailsCollection = _SalesOrderDeliveryMasterAndDetailsDataProvider.GetSalesOrderDeliveryMasterAndDetailsSearchList(searchRequest);
                else
                {
                    SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderDeliveryMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from SalesOrderDeliveryMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> SelectByID(SalesOrderDeliveryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                entityResponse = _SalesOrderDeliveryMasterAndDetailsDataProvider.GetSalesOrderDeliveryMasterAndDetailsByID(item);
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

        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoListBySalesOrder(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> SalesOrderDeliveryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                if (_SalesOrderDeliveryMasterAndDetailsDataProvider != null)
                    SalesOrderDeliveryMasterAndDetailsCollection = _SalesOrderDeliveryMasterAndDetailsDataProvider.GetDeliveryMemoListBySalesOrder(searchRequest);
                else
                {
                    SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderDeliveryMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoDetailsByID(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> SalesOrderDeliveryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                if (_SalesOrderDeliveryMasterAndDetailsDataProvider != null)
                    SalesOrderDeliveryMasterAndDetailsCollection = _SalesOrderDeliveryMasterAndDetailsDataProvider.GetDeliveryMemoDetailsByID(searchRequest);
                else
                {
                    SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderDeliveryMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetRecordForSaleseOrderDeliveryMemoPDF(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> SalesOrderDeliveryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
            try
            {
                if (_SalesOrderDeliveryMasterAndDetailsDataProvider != null)
                    SalesOrderDeliveryMasterAndDetailsCollection = _SalesOrderDeliveryMasterAndDetailsDataProvider.GetRecordForSaleseOrderDeliveryMemoPDF(searchRequest);
                else
                {
                    SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderDeliveryMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoNumberSearchList_ForSaleContract(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> SalesOrderDeliveryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails>();
            try 
            {
                if (_SalesOrderDeliveryMasterAndDetailsDataProvider != null)
                    SalesOrderDeliveryMasterAndDetailsCollection = _SalesOrderDeliveryMasterAndDetailsDataProvider.GetDeliveryMemoNumberSearchList_ForSaleContract(searchRequest);
                else
                {
                    SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderDeliveryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderDeliveryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderDeliveryMasterAndDetailsCollection;
        }
        
    }
}
