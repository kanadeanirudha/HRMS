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
    public class CustomerMasterBA : ICustomerMasterBA
    {
        ICustomerMasterDataProvider _CustomerMasterDataProvider;
        ICustomerMasterBR _CustomerMasterBR;
        private ILogger _logException;
        public CustomerMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CustomerMasterBR = new CustomerMasterBR();
            _CustomerMasterDataProvider = new CustomerMasterDataProvider();
        }
        /// <summary>
        /// Create new record of CustomerMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CustomerMaster> InsertCustomerMaster(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> entityResponse = new BaseEntityResponse<CustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CustomerMasterBR.InsertCustomerMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CustomerMasterDataProvider.InsertCustomerMaster(item);
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
        /// Update a specific record  of CustomerMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityResponse<CustomerMaster> InsertCustomerMasterContactDetails(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> entityResponse = new BaseEntityResponse<CustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CustomerMasterBR.InsertCustomerMasterContactDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CustomerMasterDataProvider.InsertCustomerMasterContactDetails(item);
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
        public IBaseEntityResponse<CustomerMaster> InsertCustomerMasterBranchDetails(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> entityResponse = new BaseEntityResponse<CustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CustomerMasterBR.InsertCustomerMasterBranchDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CustomerMasterDataProvider.InsertCustomerMasterBranchDetails(item);
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
        public IBaseEntityResponse<CustomerMaster> UpdateCustomerMaster(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> entityResponse = new BaseEntityResponse<CustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CustomerMasterBR.UpdateCustomerMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CustomerMasterDataProvider.UpdateCustomerMaster(item);
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
        /// Delete a selected record from CustomerMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CustomerMaster> DeleteCustomerMaster(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> entityResponse = new BaseEntityResponse<CustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CustomerMasterBR.DeleteCustomerMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CustomerMasterDataProvider.DeleteCustomerMaster(item);
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
        /// Select all record from CustomerMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CustomerMaster> GetBySearch(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> CustomerMasterCollection = new BaseEntityCollectionResponse<CustomerMaster>();
            try
            {
                if (_CustomerMasterDataProvider != null)
                    CustomerMasterCollection = _CustomerMasterDataProvider.GetCustomerMasterBySearch(searchRequest);
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
        /// <summary>
        /// Select a record from CustomerMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CustomerMaster> SelectByID(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> entityResponse = new BaseEntityResponse<CustomerMaster>();
            try
            {
                entityResponse = _CustomerMasterDataProvider.GetCustomerMasterByID(item);
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

        public IBaseEntityCollectionResponse<CustomerMaster> GetCustomerMasterSearchList(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> CustomerMasterCollection = new BaseEntityCollectionResponse<CustomerMaster>();
            try
            {
                if (_CustomerMasterDataProvider != null)
                    CustomerMasterCollection = _CustomerMasterDataProvider.GetCustomerMasterSearchList(searchRequest);
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

        public IBaseEntityCollectionResponse<CustomerMaster> GetCustomerBranchMasterSearchList(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> CustomerMasterCollection = new BaseEntityCollectionResponse<CustomerMaster>();
            try
            {
                if (_CustomerMasterDataProvider != null)
                    CustomerMasterCollection = _CustomerMasterDataProvider.GetCustomerBranchMasterSearchList(searchRequest);
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
        public IBaseEntityCollectionResponse<CustomerMaster> GetCustomerContactDetailsSearchList(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> CustomerMasterCollection = new BaseEntityCollectionResponse<CustomerMaster>();
            try
            {
                if (_CustomerMasterDataProvider != null)
                    CustomerMasterCollection = _CustomerMasterDataProvider.GetCustomerContactDetilsSearchList(searchRequest);
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

        public IBaseEntityCollectionResponse<CustomerMaster> GetContactDetailsByCustomerMasterID(CustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CustomerMaster> CustomerMasterCollection = new BaseEntityCollectionResponse<CustomerMaster>();
            try
            {
                if (_CustomerMasterDataProvider != null)
                    CustomerMasterCollection = _CustomerMasterDataProvider.GetContactDetailsByCustomerMasterID(searchRequest);
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

        public IBaseEntityResponse<CustomerMaster> SelectByCustomerMasterID(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> entityResponse = new BaseEntityResponse<CustomerMaster>();
            try
            {
                entityResponse = _CustomerMasterDataProvider.GetCustomerMasterDetailsByCustomerMasterID(item);
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
        public IBaseEntityResponse<CustomerMaster> UpdateCustomerMasterByCustomerMasterID(CustomerMaster item)
        {
            IBaseEntityResponse<CustomerMaster> entityResponse = new BaseEntityResponse<CustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CustomerMasterBR.UpdateCustomerMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CustomerMasterDataProvider.UpdateCustomerMasterByCustomerMasterID(item);
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
    }
}

