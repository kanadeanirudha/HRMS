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
    public class AccountTransactionTypeMasterBA : IAccountTransactionTypeMasterBA
    {
        IAccountTransactionTypeMasterDataProvider _accTransactionTypeMasterDataProvider;
        IAccountTransactionTypeMasterBR _accTransactionTypeMasterBR;
        private ILogger _logException;
        public AccountTransactionTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accTransactionTypeMasterBR = new AccountTransactionTypeMasterBR();
            _accTransactionTypeMasterDataProvider = new AccountTransactionTypeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of AccountTransactionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionTypeMaster> InsertAccountTransactionTypeMaster(AccountTransactionTypeMaster item)
        {
            IBaseEntityResponse<AccountTransactionTypeMaster> entityResponse = new BaseEntityResponse<AccountTransactionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accTransactionTypeMasterBR.InsertAccountTransactionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accTransactionTypeMasterDataProvider.InsertAccountTransactionTypeMaster(item);
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
        /// Update a specific record  of AccountTransactionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionTypeMaster> UpdateAccountTransactionTypeMaster(AccountTransactionTypeMaster item)
        {
            IBaseEntityResponse<AccountTransactionTypeMaster> entityResponse = new BaseEntityResponse<AccountTransactionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accTransactionTypeMasterBR.UpdateAccountTransactionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accTransactionTypeMasterDataProvider.UpdateAccountTransactionTypeMaster(item);
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
        /// Delete a selected record from AccountTransactionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionTypeMaster> DeleteAccountTransactionTypeMaster(AccountTransactionTypeMaster item)
        {
            IBaseEntityResponse<AccountTransactionTypeMaster> entityResponse = new BaseEntityResponse<AccountTransactionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accTransactionTypeMasterBR.DeleteAccountTransactionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accTransactionTypeMasterDataProvider.DeleteAccountTransactionTypeMaster(item);
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
        /// Select all record from AccountTransactionTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetBySearch(AccountTransactionTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTransactionTypeMaster> AccountTransactionTypeMasterCollection = new BaseEntityCollectionResponse<AccountTransactionTypeMaster>();
            try
            {
                if (_accTransactionTypeMasterDataProvider != null)
                    AccountTransactionTypeMasterCollection = _accTransactionTypeMasterDataProvider.GetAccountTransactionTypeMasterBySearch(searchRequest);
                else
                {
                    AccountTransactionTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTransactionTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTransactionTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTransactionTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTransactionTypeMasterCollection;
        }
        /// <summary>
        /// Select all record from AccountTransactionTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetTransactionTypeSearchList(AccountTransactionTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTransactionTypeMaster> AccountTransactionTypeMasterCollection = new BaseEntityCollectionResponse<AccountTransactionTypeMaster>();
            try
            {
                if (_accTransactionTypeMasterDataProvider != null)
                    AccountTransactionTypeMasterCollection = _accTransactionTypeMasterDataProvider.GetTransactionTypeSearchList(searchRequest);
                else
                {
                    AccountTransactionTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTransactionTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTransactionTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTransactionTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTransactionTypeMasterCollection;
        }
        /// <summary>
        /// Select a record from AccountTransactionTypeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionTypeMaster> SelectByID(AccountTransactionTypeMaster item)
        {
            IBaseEntityResponse<AccountTransactionTypeMaster> entityResponse = new BaseEntityResponse<AccountTransactionTypeMaster>();
            try
            {
                entityResponse = _accTransactionTypeMasterDataProvider.GetAccountTransactionTypeMasterByID(item);
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

        public IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetTransactionTypeList(AccountTransactionTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTransactionTypeMaster> AccountTransactionTypeMasterCollection = new BaseEntityCollectionResponse<AccountTransactionTypeMaster>();
            try
            {
                if (_accTransactionTypeMasterDataProvider != null)
                    AccountTransactionTypeMasterCollection = _accTransactionTypeMasterDataProvider.GetTransactionTypeList(searchRequest);
                else
                {
                    AccountTransactionTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTransactionTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTransactionTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTransactionTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTransactionTypeMasterCollection;
        }
    }
}
