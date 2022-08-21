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
    public class AccountCentreOpeningBalanceBA : IAccountCentreOpeningBalanceBA
    {
        IAccountCentreOpeningBalanceDataProvider _accCentreOpeningBalanceDataProvider;
        IAccountCentreOpeningBalanceBR _accCentreOpeningBalanceBR;
        private ILogger _logException;
        public AccountCentreOpeningBalanceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accCentreOpeningBalanceBR = new AccountCentreOpeningBalanceBR();
            _accCentreOpeningBalanceDataProvider = new AccountCentreOpeningBalanceDataProvider();
        }
        /// <summary>
        /// Create new record of AccountCentreOpeningBalance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCentreOpeningBalance> InsertAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            IBaseEntityResponse<AccountCentreOpeningBalance> entityResponse = new BaseEntityResponse<AccountCentreOpeningBalance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accCentreOpeningBalanceBR.InsertAccountCentreOpeningBalanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accCentreOpeningBalanceDataProvider.InsertAccountCentreOpeningBalance(item);
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
        /// Update a specific record  of AccountCentreOpeningBalance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCentreOpeningBalance> UpdateAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            IBaseEntityResponse<AccountCentreOpeningBalance> entityResponse = new BaseEntityResponse<AccountCentreOpeningBalance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accCentreOpeningBalanceBR.UpdateAccountCentreOpeningBalanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accCentreOpeningBalanceDataProvider.UpdateAccountCentreOpeningBalance(item);
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
        /// Delete a selected record from AccountCentreOpeningBalance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCentreOpeningBalance> DeleteAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            IBaseEntityResponse<AccountCentreOpeningBalance> entityResponse = new BaseEntityResponse<AccountCentreOpeningBalance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accCentreOpeningBalanceBR.DeleteAccountCentreOpeningBalanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accCentreOpeningBalanceDataProvider.DeleteAccountCentreOpeningBalance(item);
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
        /// Select all record from AccountCentreOpeningBalance table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetBySearch(AccountCentreOpeningBalanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCentreOpeningBalance> AccountCentreOpeningBalanceCollection = new BaseEntityCollectionResponse<AccountCentreOpeningBalance>();
            try
            {
                if (_accCentreOpeningBalanceDataProvider != null)
                    AccountCentreOpeningBalanceCollection = _accCentreOpeningBalanceDataProvider.GetAccountCentreOpeningBalanceBySearch(searchRequest);
                else
                {
                    AccountCentreOpeningBalanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountCentreOpeningBalanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountCentreOpeningBalanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountCentreOpeningBalanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountCentreOpeningBalanceCollection;
        }
        
        /// <summary>
        /// Select all record from AccountCentreOpeningBalance table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetBySearchIndividualAccount(AccountCentreOpeningBalanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCentreOpeningBalance> AccountCentreOpeningBalanceCollection = new BaseEntityCollectionResponse<AccountCentreOpeningBalance>();
            try
            {
                if (_accCentreOpeningBalanceDataProvider != null)
                    AccountCentreOpeningBalanceCollection = _accCentreOpeningBalanceDataProvider.GetBySearchIndividualAccount(searchRequest);
                else
                {
                    AccountCentreOpeningBalanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountCentreOpeningBalanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountCentreOpeningBalanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountCentreOpeningBalanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountCentreOpeningBalanceCollection;
        }

        /// <summary>
        /// Select a record from AccountCentreOpeningBalance table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCentreOpeningBalance> SelectByID(AccountCentreOpeningBalance item)
        {
            IBaseEntityResponse<AccountCentreOpeningBalance> entityResponse = new BaseEntityResponse<AccountCentreOpeningBalance>();
            try
            {
                entityResponse = _accCentreOpeningBalanceDataProvider.GetAccountCentreOpeningBalanceByID(item);
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
