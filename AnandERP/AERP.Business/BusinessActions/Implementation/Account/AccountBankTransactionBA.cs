using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public class AccountBankTransactionBA : IAccountBankTransactionBA
    {
        IAccountBankTransactionDataProvider _accBankTransactionDataProvider;
        IAccountBankTransactionBR _accBankTransactionBR;
        private ILogger _logException;
        public AccountBankTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accBankTransactionBR = new AccountBankTransactionBR();
            _accBankTransactionDataProvider = new AccountBankTransactionDataProvider();
        }
        /// <summary>
        /// Create new record of AccountBankTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBankTransaction> InsertAccountBankTransaction(AccountBankTransaction item)
        {
            IBaseEntityResponse<AccountBankTransaction> entityResponse = new BaseEntityResponse<AccountBankTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accBankTransactionBR.InsertAccountBankTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accBankTransactionDataProvider.InsertAccountBankTransaction(item);
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
        /// Update a specific record  of AccountBankTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBankTransaction> UpdateAccountBankTransaction(AccountBankTransaction item)
        {
            IBaseEntityResponse<AccountBankTransaction> entityResponse = new BaseEntityResponse<AccountBankTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accBankTransactionBR.UpdateAccountBankTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accBankTransactionDataProvider.UpdateAccountBankTransaction(item);
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
        /// Delete a selected record from AccountBankTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBankTransaction> DeleteAccountBankTransaction(AccountBankTransaction item)
        {
            IBaseEntityResponse<AccountBankTransaction> entityResponse = new BaseEntityResponse<AccountBankTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accBankTransactionBR.DeleteAccountBankTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accBankTransactionDataProvider.DeleteAccountBankTransaction(item);
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
        /// Select all record from AccountBankTransaction table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBankTransaction> GetBySearch(AccountBankTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountBankTransaction> AccountBankTransactionCollection = new BaseEntityCollectionResponse<AccountBankTransaction>();
            try
            {
                if (_accBankTransactionDataProvider != null)
                    AccountBankTransactionCollection = _accBankTransactionDataProvider.GetAccountBankTransactionBySearch(searchRequest);
                else
                {
                    AccountBankTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountBankTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountBankTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountBankTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountBankTransactionCollection;
        }
        /// <summary>
        /// Select a record from AccountBankTransaction table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBankTransaction> SelectByID(AccountBankTransaction item)
        {
            IBaseEntityResponse<AccountBankTransaction> entityResponse = new BaseEntityResponse<AccountBankTransaction>();
            try
            {
                entityResponse = _accBankTransactionDataProvider.GetAccountBankTransactionByID(item);
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
