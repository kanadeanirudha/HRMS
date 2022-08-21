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
    public class AccountBalancesheetMasterBA: IAccountBalancesheetMasterBA
    {
        IAccountBalancesheetMasterDataProvider _accountBalancesheetMasterDataProvider;
        IAccountBalancesheetMasterBR _accountBalancesheetMasterBR;
        private ILogger _logException;

        public AccountBalancesheetMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountBalancesheetMasterBR = new AccountBalancesheetMasterBR();
            _accountBalancesheetMasterDataProvider = new AccountBalancesheetMasterDataProvider();
        }

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBySearch(AccountBalancesheetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> AccBalsheetMasterCollection = new BaseEntityCollectionResponse<AccountBalancesheetMaster>();
            try
            {
                if (_accountBalancesheetMasterDataProvider != null)
                {
                    AccBalsheetMasterCollection = _accountBalancesheetMasterDataProvider.GetAccountBalancesheetMasterBySearch(searchRequest);
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
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalanceSheetList(AccountBalancesheetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> AccBalsheetMasterCollection = new BaseEntityCollectionResponse<AccountBalancesheetMaster>();
            try
            {
                if (_accountBalancesheetMasterDataProvider != null)
                {
                    AccBalsheetMasterCollection = _accountBalancesheetMasterDataProvider.GetAccountBalancesheetMasterList(searchRequest);
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
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForAccountMasterSearchList(AccountBalancesheetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> AccBalsheetMasterCollection = new BaseEntityCollectionResponse<AccountBalancesheetMaster>();
            try
            {
                if (_accountBalancesheetMasterDataProvider != null)
                {
                    AccBalsheetMasterCollection = _accountBalancesheetMasterDataProvider.GetBalancesheetForAccountMasterSearchList(searchRequest);
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
        /// Businnes Action Method to select Balancesheet for Multiple Select List in Account Master Form.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForMultipleSelectList(AccountBalancesheetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> AccBalsheetMasterCollection = new BaseEntityCollectionResponse<AccountBalancesheetMaster>();
            try
            {
                if (_accountBalancesheetMasterDataProvider != null)
                {
                    AccBalsheetMasterCollection = _accountBalancesheetMasterDataProvider.GetBalancesheetForMultipleSelectList(searchRequest);
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
        /// Select a record from Account Balance Sheet Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetMaster> SelectByID(AccountBalancesheetMaster item)
        {

            IBaseEntityResponse<AccountBalancesheetMaster> entityResponse = new BaseEntityResponse<AccountBalancesheetMaster>();
            try
            {
                entityResponse = _accountBalancesheetMasterDataProvider.GetAccountBalancesheetMasterByID(item);
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
        public IBaseEntityResponse<AccountBalancesheetMaster> InsertAccBalsheetMaster(AccountBalancesheetMaster item)
        {
            IBaseEntityResponse<AccountBalancesheetMaster> entityResponse = new BaseEntityResponse<AccountBalancesheetMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountBalancesheetMasterBR.InsertAccBalsheetMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountBalancesheetMasterDataProvider.InsertAccountBalancesheetMaster(item);
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
        public IBaseEntityResponse<AccountBalancesheetMaster> UpdateAccBalsheetMaster(AccountBalancesheetMaster item)
        {
            IBaseEntityResponse<AccountBalancesheetMaster> entityResponse = new BaseEntityResponse<AccountBalancesheetMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountBalancesheetMasterBR.UpdateAccBalsheetMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountBalancesheetMasterDataProvider.UpdateAccountBalancesheetMaster(item);
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
        public IBaseEntityResponse<AccountBalancesheetMaster> DeleteAccBalsheetMaster(AccountBalancesheetMaster item)
        {
            IBaseEntityResponse<AccountBalancesheetMaster> entityResponse = new BaseEntityResponse<AccountBalancesheetMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountBalancesheetMasterBR.DeleteAccBalsheetMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountBalancesheetMasterDataProvider.DeleteAccountBalancesheetMaster(item);
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
