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
    public class AccountGroupMasterBA: IAccountGroupMasterBA
    {
        IAccountGroupMasterDataProvider _accountGroupMasterDataProvider;
        IAccountGroupMasterBR _accountGroupMasterBR;
        private ILogger _logException;

        public AccountGroupMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountGroupMasterBR = new AccountGroupMasterBR();
            _accountGroupMasterDataProvider = new AccountGroupMasterDataProvider();
        }

        /// <summary>
        /// Create new record of Account Group Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGroupMaster> InsertAccountGroupMaster(AccountGroupMaster item)
        {
            IBaseEntityResponse<AccountGroupMaster> entityResponse = new BaseEntityResponse<AccountGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountGroupMasterBR.InsertAccountGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountGroupMasterDataProvider.InsertAccountGroupMaster(item);
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
        /// Update a specific record of Account Group Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGroupMaster> UpdateAccountGroupMaster(AccountGroupMaster item)
        {
            IBaseEntityResponse<AccountGroupMaster> entityResponse = new BaseEntityResponse<AccountGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountGroupMasterBR.UpdateAccountGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountGroupMasterDataProvider.UpdateAccountGroupMaster(item);
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
        /// Delete a selected record from Account Group Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGroupMaster> DeleteAccountGroupMaster(AccountGroupMaster item)
        {
            IBaseEntityResponse<AccountGroupMaster> entityResponse = new BaseEntityResponse<AccountGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountGroupMasterBR.DeleteAccountGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountGroupMasterDataProvider.DeleteAccountGroupMaster(item);
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
        /// Select all record from Account Group Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGroupMaster> GetBySearch(AccountGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGroupMaster> AccountGroupMasterCollection = new BaseEntityCollectionResponse<AccountGroupMaster>();
            try
            {
                if (_accountGroupMasterDataProvider != null)
                {
                    AccountGroupMasterCollection = _accountGroupMasterDataProvider.GetAccountGroupMasterBySearch(searchRequest);
                }
                else
                {
                    AccountGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountGroupMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountGroupMasterCollection;
        }

        /// <summary>
        /// Select a record from Account Group Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGroupMaster> SelectByID(AccountGroupMaster item)
        {

            IBaseEntityResponse<AccountGroupMaster> entityResponse = new BaseEntityResponse<AccountGroupMaster>();
            try
            {
                entityResponse = _accountGroupMasterDataProvider.GetAccountGroupMasterByID(item);
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
