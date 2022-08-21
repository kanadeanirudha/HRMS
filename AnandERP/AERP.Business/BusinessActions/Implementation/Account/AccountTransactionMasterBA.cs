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
    public class AccountTransactionMasterBA : IAccountTransactionMasterBA
    {
        IAccountTransactionMasterDataProvider _accTransactionMasterDataProvider;
        IAccountTransactionMasterBR _accTransactionMasterBR;
        private ILogger _logException;
        public AccountTransactionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accTransactionMasterBR = new AccountTransactionMasterBR();
            _accTransactionMasterDataProvider = new AccountTransactionMasterDataProvider();
        }
        /// <summary>
        /// Create new record of AccountTransactionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionMaster> InsertAccountTransactionMaster(AccountTransactionMaster item)
        {
            IBaseEntityResponse<AccountTransactionMaster> entityResponse = new BaseEntityResponse<AccountTransactionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accTransactionMasterBR.InsertAccountTransactionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accTransactionMasterDataProvider.InsertAccountTransactionMaster(item);
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
        /// Update a specific record  of AccountTransactionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionMaster> UpdateAccountTransactionMaster(AccountTransactionMaster item)
        {
            IBaseEntityResponse<AccountTransactionMaster> entityResponse = new BaseEntityResponse<AccountTransactionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accTransactionMasterBR.UpdateAccountTransactionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accTransactionMasterDataProvider.UpdateAccountTransactionMaster(item);
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
        /// Delete a selected record from AccountTransactionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionMaster> DeleteAccountTransactionMaster(AccountTransactionMaster item)
        {
            IBaseEntityResponse<AccountTransactionMaster> entityResponse = new BaseEntityResponse<AccountTransactionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accTransactionMasterBR.DeleteAccountTransactionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accTransactionMasterDataProvider.DeleteAccountTransactionMaster(item);
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
        /// Select all record from AccountTransactionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearch(AccountTransactionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTransactionMaster> AccountTransactionMasterCollection = new BaseEntityCollectionResponse<AccountTransactionMaster>();
            try
            {
                if (_accTransactionMasterDataProvider != null)
                    AccountTransactionMasterCollection = _accTransactionMasterDataProvider.GetAccountTransactionMasterBySearch(searchRequest);
                else
                {
                    AccountTransactionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTransactionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTransactionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTransactionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTransactionMasterCollection;
        }
        /// <summary>
        /// Select all record from AccountTransactionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetAccountList(AccountTransactionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTransactionMaster> AccountTransactionMasterCollection = new BaseEntityCollectionResponse<AccountTransactionMaster>();
            try
            {
                if (_accTransactionMasterDataProvider != null)
                    AccountTransactionMasterCollection = _accTransactionMasterDataProvider.GetAccountList(searchRequest);
                else
                {
                    AccountTransactionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTransactionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTransactionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTransactionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTransactionMasterCollection;
        }
        /// <summary>
        /// Select all record from AccountTransactionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearchForEditView(AccountTransactionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTransactionMaster> AccountTransactionMasterCollection = new BaseEntityCollectionResponse<AccountTransactionMaster>();
            try
            {
                if (_accTransactionMasterDataProvider != null)
                    AccountTransactionMasterCollection = _accTransactionMasterDataProvider.GetBySearchForEditView(searchRequest);
                else
                {
                    AccountTransactionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTransactionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTransactionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTransactionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTransactionMasterCollection;
        }
        /// <summary>
        /// Select a record from AccountTransactionMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionMaster> SelectByID(AccountTransactionMaster item)
        {
            IBaseEntityResponse<AccountTransactionMaster> entityResponse = new BaseEntityResponse<AccountTransactionMaster>();
            try
            {
                entityResponse = _accTransactionMasterDataProvider.GetAccountTransactionMasterByID(item);
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
        /// Create new record of AccountTransactionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTransactionMaster> InsertAccountVoucherRequest(AccountTransactionMaster item)
        {
            IBaseEntityResponse<AccountTransactionMaster> entityResponse = new BaseEntityResponse<AccountTransactionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accTransactionMasterBR.InsertAccountTransactionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accTransactionMasterDataProvider.InsertAccountVoucherRequest(item);
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
        /// Select all record from AccountTransactionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetVoucherDetailsForApproval(AccountTransactionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTransactionMaster> AccountTransactionMasterCollection = new BaseEntityCollectionResponse<AccountTransactionMaster>();
            try
            {
                if (_accTransactionMasterDataProvider != null)
                    AccountTransactionMasterCollection = _accTransactionMasterDataProvider.GetVoucherDetailsForApproval(searchRequest);
                else
                {
                    AccountTransactionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTransactionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTransactionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTransactionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTransactionMasterCollection;
        }
    }
}
