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
    public class SalesReturnMasterAndDetailsBA : ISalesReturnMasterAndDetailsBA
    {
        ISalesReturnMasterAndDetailsDataProvider _SalesReturnMasterAndDetailsDataProvider;
        ISalesReturnMasterAndDetailsBR _SalesReturnMasterAndDetailsBR;
        private ILogger _logException;
        public SalesReturnMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalesReturnMasterAndDetailsBR = new SalesReturnMasterAndDetailsBR();
            _SalesReturnMasterAndDetailsDataProvider = new SalesReturnMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of SalesReturnMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesReturnMasterAndDetails> InsertSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item)
        {
            IBaseEntityResponse<SalesReturnMasterAndDetails> entityResponse = new BaseEntityResponse<SalesReturnMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesReturnMasterAndDetailsBR.InsertSalesReturnMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesReturnMasterAndDetailsDataProvider.InsertSalesReturnMasterAndDetails(item);
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
        /// Update a specific record  of SalesReturnMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesReturnMasterAndDetails> UpdateSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item)
        {
            IBaseEntityResponse<SalesReturnMasterAndDetails> entityResponse = new BaseEntityResponse<SalesReturnMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesReturnMasterAndDetailsBR.UpdateSalesReturnMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesReturnMasterAndDetailsDataProvider.UpdateSalesReturnMasterAndDetails(item);
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
        /// Delete a selected record from SalesReturnMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesReturnMasterAndDetails> DeleteSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item)
        {
            IBaseEntityResponse<SalesReturnMasterAndDetails> entityResponse = new BaseEntityResponse<SalesReturnMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesReturnMasterAndDetailsBR.DeleteSalesReturnMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesReturnMasterAndDetailsDataProvider.DeleteSalesReturnMasterAndDetails(item);
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
        /// Select all record from SalesReturnMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetBySearch(SalesReturnMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> SalesReturnMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesReturnMasterAndDetails>();
            try
            {
                if (_SalesReturnMasterAndDetailsDataProvider != null)
                    SalesReturnMasterAndDetailsCollection = _SalesReturnMasterAndDetailsDataProvider.GetSalesReturnMasterAndDetailsBySearch(searchRequest);
                else
                {
                    SalesReturnMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesReturnMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesReturnMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesReturnMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesReturnMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetSalesReturnMasterAndDetailsSearchList(SalesReturnMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> SalesReturnMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesReturnMasterAndDetails>();
            try
            {
                if (_SalesReturnMasterAndDetailsDataProvider != null)
                    SalesReturnMasterAndDetailsCollection = _SalesReturnMasterAndDetailsDataProvider.GetSalesReturnMasterAndDetailsSearchList(searchRequest);
                else
                {
                    SalesReturnMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesReturnMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesReturnMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesReturnMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesReturnMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from SalesReturnMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesReturnMasterAndDetails> SelectByID(SalesReturnMasterAndDetails item)
        {
            IBaseEntityResponse<SalesReturnMasterAndDetails> entityResponse = new BaseEntityResponse<SalesReturnMasterAndDetails>();
            try
            {
                entityResponse = _SalesReturnMasterAndDetailsDataProvider.GetSalesReturnMasterAndDetailsByID(item);
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

        public IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetDropDownListforSalesReturnMasterAndDetails(SalesReturnMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> SalesReturnMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesReturnMasterAndDetails>();
            try
            {
                if (_SalesReturnMasterAndDetailsDataProvider != null)
                    SalesReturnMasterAndDetailsCollection = _SalesReturnMasterAndDetailsDataProvider.GetDropDownListforSalesReturnMasterAndDetails(searchRequest);
                else
                {
                    SalesReturnMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesReturnMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesReturnMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesReturnMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesReturnMasterAndDetailsCollection;
        }
    }
}
