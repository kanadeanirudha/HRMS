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
    public class SalesEnquiryMasterAndDetailsBA : ISalesEnquiryMasterAndDetailsBA
    {
        ISalesEnquiryMasterAndDetailsDataProvider _SalesEnquiryMasterAndDetailsDataProvider;
        ISalesEnquiryMasterAndDetailsBR _SalesEnquiryMasterAndDetailsBR;
        private ILogger _logException;
        public SalesEnquiryMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalesEnquiryMasterAndDetailsBR = new SalesEnquiryMasterAndDetailsBR();
            _SalesEnquiryMasterAndDetailsDataProvider = new SalesEnquiryMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of SalesEnquiryMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesEnquiryMasterAndDetailsBR.InsertSalesEnquiryMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesEnquiryMasterAndDetailsDataProvider.InsertSalesEnquiryMasterAndDetails(item);
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
        /// Update a specific record  of SalesEnquiryMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetailsContactDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesEnquiryMasterAndDetailsBR.InsertSalesEnquiryMasterAndDetailsContactDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesEnquiryMasterAndDetailsDataProvider.InsertSalesEnquiryMasterAndDetailsContactDetails(item);
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
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> InsertSalesEnquiryMasterAndDetailsBranchDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesEnquiryMasterAndDetailsBR.InsertSalesEnquiryMasterAndDetailsBranchDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesEnquiryMasterAndDetailsDataProvider.InsertSalesEnquiryMasterAndDetailsBranchDetails(item);
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
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> UpdateSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesEnquiryMasterAndDetailsBR.UpdateSalesEnquiryMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesEnquiryMasterAndDetailsDataProvider.UpdateSalesEnquiryMasterAndDetails(item);
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
        /// Delete a selected record from SalesEnquiryMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> DeleteSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesEnquiryMasterAndDetailsBR.DeleteSalesEnquiryMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesEnquiryMasterAndDetailsDataProvider.DeleteSalesEnquiryMasterAndDetails(item);
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
        /// Select all record from SalesEnquiryMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetBySearch(SalesEnquiryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> SalesEnquiryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                if (_SalesEnquiryMasterAndDetailsDataProvider != null)
                    SalesEnquiryMasterAndDetailsCollection = _SalesEnquiryMasterAndDetailsDataProvider.GetSalesEnquiryMasterAndDetailsBySearch(searchRequest);
                else
                {
                    SalesEnquiryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesEnquiryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesEnquiryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesEnquiryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesEnquiryMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from SalesEnquiryMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesEnquiryMasterAndDetails> SelectByID(SalesEnquiryMasterAndDetails item)
        {
            IBaseEntityResponse<SalesEnquiryMasterAndDetails> entityResponse = new BaseEntityResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                entityResponse = _SalesEnquiryMasterAndDetailsDataProvider.GetSalesEnquiryMasterAndDetailsByID(item);
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

        public IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetSalesEnquiryMasterAndDetailsSearchList(SalesEnquiryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> SalesEnquiryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                if (_SalesEnquiryMasterAndDetailsDataProvider != null)
                    SalesEnquiryMasterAndDetailsCollection = _SalesEnquiryMasterAndDetailsDataProvider.GetSalesEnquiryMasterAndDetailsSearchList(searchRequest);
                else
                {
                    SalesEnquiryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesEnquiryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesEnquiryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesEnquiryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesEnquiryMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetCustomerBranchMasterSearchList(SalesEnquiryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> SalesEnquiryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                if (_SalesEnquiryMasterAndDetailsDataProvider != null)
                    SalesEnquiryMasterAndDetailsCollection = _SalesEnquiryMasterAndDetailsDataProvider.GetCustomerBranchMasterSearchList(searchRequest);
                else
                {
                    SalesEnquiryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesEnquiryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesEnquiryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesEnquiryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesEnquiryMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> GetEnquiryDetailsByID(SalesEnquiryMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> SalesEnquiryMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalesEnquiryMasterAndDetails>();
            try
            {
                if (_SalesEnquiryMasterAndDetailsDataProvider != null)
                    SalesEnquiryMasterAndDetailsCollection = _SalesEnquiryMasterAndDetailsDataProvider.GetEnquiryDetailsByID(searchRequest);
                else
                {
                    SalesEnquiryMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesEnquiryMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesEnquiryMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesEnquiryMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesEnquiryMasterAndDetailsCollection;
        }
    }
}

