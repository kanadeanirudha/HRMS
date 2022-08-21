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
    public class AccountMasterBA: IAccountMasterBA
    {
        IAccountMasterDataProvider _accountMasterDataProvider;
        IAccountMasterBR _accountMasterBR;
        private ILogger _logException;

        public AccountMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountMasterBR = new AccountMasterBR();
            _accountMasterDataProvider = new AccountMasterDataProvider();
        }

        /// <summary>
        /// Select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetBySearch(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> AccBalsheetMasterCollection = new BaseEntityCollectionResponse<AccountMaster>();
            try
            {
                if (_accountMasterDataProvider != null)
                {
                    AccBalsheetMasterCollection = _accountMasterDataProvider.GetAccountMasterBySearch(searchRequest);
                }
                else
                {
                    AccBalsheetMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccBalsheetMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccBalsheetMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccBalsheetMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccBalsheetMasterCollection;
        }

        /// <summary>
        /// Select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAccountList(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> AccountMasterCollection = new BaseEntityCollectionResponse<AccountMaster>();
            try
            {
                if (_accountMasterDataProvider != null)
                {
                    AccountMasterCollection = _accountMasterDataProvider.GetAccountList(searchRequest);
                }
                else
                {
                    AccountMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountMasterCollection;
        }

                /// <summary>
        /// Select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAccountListForReport(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> AccountMasterCollection = new BaseEntityCollectionResponse<AccountMaster>();
            try
            {
                if (_accountMasterDataProvider != null)
                {
                    AccountMasterCollection = _accountMasterDataProvider.GetAccountListForReport(searchRequest);
                }
                else
                {
                    AccountMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountMasterCollection;
        }
        
        /// <summary>
        /// Select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetSurplusDeficitList(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> AccountMasterCollection = new BaseEntityCollectionResponse<AccountMaster>();
            try
            {
                if (_accountMasterDataProvider != null)
                {
                    AccountMasterCollection = _accountMasterDataProvider.GetSurplusDeficitList(searchRequest);
                }
                else
                {
                    AccountMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountMasterCollection;
        }

        /// <summary>
        /// Select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAlternateGroupList(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> AccountMasterCollection = new BaseEntityCollectionResponse<AccountMaster>();
            try
            {
                if (_accountMasterDataProvider != null)
                {
                    AccountMasterCollection = _accountMasterDataProvider.GetAlternateGroupList(searchRequest);
                }
                else
                {
                    AccountMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountMasterCollection;
        }
        
        /// <summary>
        /// Select a record from Account Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> SelectByID(AccountMaster item)
        {

            IBaseEntityResponse<AccountMaster> entityResponse = new BaseEntityResponse<AccountMaster>();
            try
            {
                entityResponse = _accountMasterDataProvider.GetAccountMasterByID(item);
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
        /// Create new record of Account Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> InsertAccountMaster(AccountMaster item)
        {
            IBaseEntityResponse<AccountMaster> entityResponse = new BaseEntityResponse<AccountMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountMasterBR.InsertAccountMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountMasterDataProvider.InsertAccountMaster(item);
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
        /// Update a specific record of Account Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> UpdateAccountMaster(AccountMaster item)
        {
            IBaseEntityResponse<AccountMaster> entityResponse = new BaseEntityResponse<AccountMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountMasterBR.UpdateAccountMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountMasterDataProvider.UpdateAccountMaster(item);
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
        /// Delete a selected record from Account Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> DeleteAccountMaster(AccountMaster item)
        {
            IBaseEntityResponse<AccountMaster> entityResponse = new BaseEntityResponse<AccountMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountMasterBR.DeleteAccountMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountMasterDataProvider.DeleteAccountMaster(item);
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

        public IBaseEntityCollectionResponse<AccountMaster> GetAccountMasterSearchList(AccountMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMaster> AccBalsheetMasterCollection = new BaseEntityCollectionResponse<AccountMaster>();
            try
            {
                if (_accountMasterDataProvider != null)
                {
                    AccBalsheetMasterCollection = _accountMasterDataProvider.GetAccountMasterSearchList(searchRequest);
                }
                else
                {
                    AccBalsheetMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccBalsheetMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccBalsheetMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccBalsheetMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccBalsheetMasterCollection;
        }

    }

   

}
