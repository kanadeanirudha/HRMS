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
    public class AccountCategoryMasterBA: IAccountCategoryMasterBA
    {
        IAccountCategoryMasterDataProvider _accountCategoryMasterDataProvider;
        IAccountCategoryMasterBR _accountCategoryMasterBR;
        private ILogger _logException;

        public AccountCategoryMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountCategoryMasterBR = new AccountCategoryMasterBR();
            _accountCategoryMasterDataProvider = new AccountCategoryMasterDataProvider();
        }


        /// <summary>
        /// Create new record of Account Category Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMaster> InsertAccountCategoryMaster(AccountCategoryMaster item)
        {
            IBaseEntityResponse<AccountCategoryMaster> entityResponse = new BaseEntityResponse<AccountCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountCategoryMasterBR.InsertAccountCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountCategoryMasterDataProvider.InsertAccountCategoryMaster(item);
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
        /// Update a specific record of Account Category Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMaster> UpdateAccountCategoryMaster(AccountCategoryMaster item)
        {
            IBaseEntityResponse<AccountCategoryMaster> entityResponse = new BaseEntityResponse<AccountCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountCategoryMasterBR.UpdateAccountCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountCategoryMasterDataProvider.UpdateAccountCategoryMaster(item);
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
        /// Delete a selected record from Account Category Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMaster> DeleteAccountCategoryMaster(AccountCategoryMaster item)
        {
            IBaseEntityResponse<AccountCategoryMaster> entityResponse = new BaseEntityResponse<AccountCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountCategoryMasterBR.DeleteAccountCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountCategoryMasterDataProvider.DeleteAccountCategoryMaster(item);
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
        /// Select all record from Account Category Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMaster> GetBySearch(AccountCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCategoryMaster> AccountCategoryMasterCollection = new BaseEntityCollectionResponse<AccountCategoryMaster>();
            try
            {
                if (_accountCategoryMasterDataProvider != null)
                {
                    AccountCategoryMasterCollection = _accountCategoryMasterDataProvider.GetAccountCategoryMasterBySearch(searchRequest);
                }
                else
                {
                    AccountCategoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountCategoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountCategoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountCategoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountCategoryMasterCollection;
        }


        /// <summary>
        /// Select all category names from Account Category Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMaster> GetCategoryList(AccountCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCategoryMaster> AccountCategoryMasterCollection = new BaseEntityCollectionResponse<AccountCategoryMaster>();
            try
            {
                if (_accountCategoryMasterDataProvider != null)
                {
                    AccountCategoryMasterCollection = _accountCategoryMasterDataProvider.GetAccountCategoryNameList(searchRequest);
                }
                else
                {
                    AccountCategoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountCategoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountCategoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountCategoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountCategoryMasterCollection;
        }





        /// <summary>
        /// Select a record from Account Category Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMaster> SelectByID(AccountCategoryMaster item)
        {

            IBaseEntityResponse<AccountCategoryMaster> entityResponse = new BaseEntityResponse<AccountCategoryMaster>();
            try
            {
                entityResponse = _accountCategoryMasterDataProvider.GetAccountCategoryMasterByID(item);
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
