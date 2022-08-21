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
    public class AccountChequeBookMasterBA: IAccountChequeBookMasterBA
    {
        IAccountChequeBookMasterDataProvider _accountChequeBookMasterDataProvider;
        IAccountChequeBookMasterBR _accountChequeBookMasterBR;
        private ILogger _logException;

        public AccountChequeBookMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountChequeBookMasterBR = new AccountChequeBookMasterBR();
            _accountChequeBookMasterDataProvider = new AccountChequeBookMasterDataProvider();
        }

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountChequeBookMaster> GetBySearch(AccountChequeBookMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountChequeBookMaster> AccountChequeBookMasterCollection = new BaseEntityCollectionResponse<AccountChequeBookMaster>();
            try
            {
                if (_accountChequeBookMasterDataProvider != null)
                {
                    AccountChequeBookMasterCollection = _accountChequeBookMasterDataProvider.GetAccountChequeBookMasterBySearch(searchRequest);
                }
                else
                {
                    AccountChequeBookMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountChequeBookMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountChequeBookMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountChequeBookMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountChequeBookMasterCollection;
        }

        /// <summary>
        /// Select a record from Account Balance Sheet Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> SelectByID(AccountChequeBookMaster item)
        {

            IBaseEntityResponse<AccountChequeBookMaster> entityResponse = new BaseEntityResponse<AccountChequeBookMaster>();
            try
            {
                entityResponse = _accountChequeBookMasterDataProvider.GetAccountChequeBookMasterByID(item);
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
        /// Select a record from Account Balance Sheet Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> SelectByAccountID(AccountChequeBookMaster item)
        {

            IBaseEntityResponse<AccountChequeBookMaster> entityResponse = new BaseEntityResponse<AccountChequeBookMaster>();
            try
            {
                entityResponse = _accountChequeBookMasterDataProvider.GetChequeFromNoByAccountID(item);
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
        /// Create new record of Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> InsertAccountChequeBookMaster(AccountChequeBookMaster item)
        {
            IBaseEntityResponse<AccountChequeBookMaster> entityResponse = new BaseEntityResponse<AccountChequeBookMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountChequeBookMasterBR.InsertAccountChequeBookMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountChequeBookMasterDataProvider.InsertAccountChequeBookMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Update a specific record of Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> UpdateAccountChequeBookMaster(AccountChequeBookMaster item)
        {
            IBaseEntityResponse<AccountChequeBookMaster> entityResponse = new BaseEntityResponse<AccountChequeBookMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountChequeBookMasterBR.UpdateAccountChequeBookMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountChequeBookMasterDataProvider.UpdateAccountChequeBookMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Delete a selected record from Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> DeleteAccountChequeBookMaster(AccountChequeBookMaster item)
        {
            IBaseEntityResponse<AccountChequeBookMaster> entityResponse = new BaseEntityResponse<AccountChequeBookMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountChequeBookMasterBR.DeleteAccountChequeBookMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountChequeBookMasterDataProvider.DeleteAccountChequeBookMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
