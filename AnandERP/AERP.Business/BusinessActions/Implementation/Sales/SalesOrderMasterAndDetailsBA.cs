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
    public class SalesOrderMasterAndDetailsBA : ISalesOrderMasterAndDetailsBA
    {
        ISalesOrderMasterAndDetailsDataProvider _SalesOrderMasterAndDetailsDataProvider;
        ISalesOrderMasterAndDetailsBR _SalesOrderMasterAndDetailsBR;
        private ILogger _logException;
        public SalesOrderMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalesOrderMasterAndDetailsBR = new SalesOrderMasterAndDetailsBR();
            _SalesOrderMasterAndDetailsDataProvider = new SalesOrderMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of SalesOrderMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderMasterAndDetails> InsertSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesOrderMasterAndDetailsBR.InsertSalesOrderMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesOrderMasterAndDetailsDataProvider.InsertSalesOrderMasterAndDetails(item);
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
        /// Update a specific record  of SalesOrderMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderMasterAndDetails> UpdateSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesOrderMasterAndDetailsBR.UpdateSalesOrderMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesOrderMasterAndDetailsDataProvider.UpdateSalesOrderMasterAndDetails(item);
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
        /// Delete a selected record from SalesOrderMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderMasterAndDetails> DeleteSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesOrderMasterAndDetailsBR.DeleteSalesOrderMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesOrderMasterAndDetailsDataProvider.DeleteSalesOrderMasterAndDetails(item);
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
        /// Select all record from SalesOrderMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetBySearch(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> SalesOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
            try
            {
                if (_SalesOrderMasterAndDetailsDataProvider != null)
                    SalesOrderMasterAndDetailsCollection = _SalesOrderMasterAndDetailsDataProvider.GetSalesOrderMasterAndDetailsBySearch(searchRequest);
                else
                {
                    SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetSalesOrderMasterAndDetailsSearchList(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> SalesOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
            try
            {
                if (_SalesOrderMasterAndDetailsDataProvider != null)
                    SalesOrderMasterAndDetailsCollection = _SalesOrderMasterAndDetailsDataProvider.GetSalesOrderMasterAndDetailsSearchList(searchRequest);
                else
                {
                    SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from SalesOrderMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesOrderMasterAndDetails> SelectByID(SalesOrderMasterAndDetails item)
        {
            IBaseEntityResponse<SalesOrderMasterAndDetails> entityResponse = new BaseEntityResponse<SalesOrderMasterAndDetails>();
            try
            {
                entityResponse = _SalesOrderMasterAndDetailsDataProvider.GetSalesOrderMasterAndDetailsByID(item);
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

        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetDropDownListForSalesOrderMasterAndDetails(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> SalesOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
            try
            {
                if (_SalesOrderMasterAndDetailsDataProvider != null)
                    SalesOrderMasterAndDetailsCollection = _SalesOrderMasterAndDetailsDataProvider.GetDropDownListForSalesOrderMasterAndDetails(searchRequest);
                else
                {
                    SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetRecordForSaleseOrderPDF(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> SalesOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
            try
            {
                if (_SalesOrderMasterAndDetailsDataProvider != null)
                    SalesOrderMasterAndDetailsCollection = _SalesOrderMasterAndDetailsDataProvider.GetRecordForSaleseOrderPDF(searchRequest);
                else
                {
                    SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> ViewSalesOrderMasterDetailsListBySalesOrderMasterID(SalesOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> SalesOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesOrderMasterAndDetails>();
            try
            {
                if (_SalesOrderMasterAndDetailsDataProvider != null)
                    SalesOrderMasterAndDetailsCollection = _SalesOrderMasterAndDetailsDataProvider.ViewSalesOrderMasterDetailsListBySalesOrderMasterID(searchRequest);
                else
                {
                    SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesOrderMasterAndDetailsCollection;
        }

    }
}
