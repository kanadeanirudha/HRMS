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
    public class AccountBalancesheetTypeMasterBA: IAccountBalancesheetTypeMasterBA
    {
        IAccountBalancesheetTypeMasterDataProvider _accountBalancesheetTypeMasterDataProvider;
        IAccountBalancesheetTypeMasterBR _accountBalancesheetTypeMasterBR;
        private ILogger _logException;

        public AccountBalancesheetTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountBalancesheetTypeMasterBR = new AccountBalancesheetTypeMasterBR();
            _accountBalancesheetTypeMasterDataProvider = new AccountBalancesheetTypeMasterDataProvider();
        }

        /// <summary>
        /// Create new record of Account Balance Sheet Type Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetTypeMaster> InsertAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item)
        {
            IBaseEntityResponse<AccountBalancesheetTypeMaster> entityResponse = new BaseEntityResponse<AccountBalancesheetTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountBalancesheetTypeMasterBR.InsertAccountBalancesheetTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountBalancesheetTypeMasterDataProvider.InsertAccountBalancesheetTypeMaster(item);
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
        /// Update a specific record of Account Balance Sheet Type Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetTypeMaster> UpdateAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item)
        {
            IBaseEntityResponse<AccountBalancesheetTypeMaster> entityResponse = new BaseEntityResponse<AccountBalancesheetTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountBalancesheetTypeMasterBR.UpdateAccountBalancesheetTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountBalancesheetTypeMasterDataProvider.UpdateAccountBalancesheetTypeMaster(item);
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
        /// Delete a selected record from Account Balance Sheet Type Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetTypeMaster> DeleteAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item)
        {
            IBaseEntityResponse<AccountBalancesheetTypeMaster> entityResponse = new BaseEntityResponse<AccountBalancesheetTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountBalancesheetTypeMasterBR.DeleteAccountBalancesheetTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountBalancesheetTypeMasterDataProvider.DeleteAccountBalancesheetTypeMaster(item);
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
        /// Select all record from Account Balance Sheet Type Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> GetBySearch(AccountBalancesheetTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> AdminMenuApplicableCollection = new BaseEntityCollectionResponse<AccountBalancesheetTypeMaster>();
            try
            {
                if (_accountBalancesheetTypeMasterDataProvider != null)
                {
                    AdminMenuApplicableCollection = _accountBalancesheetTypeMasterDataProvider.GetAccountBalancesheetTypeMasterBySearch(searchRequest);
                }
                else
                {
                    AdminMenuApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminMenuApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminMenuApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminMenuApplicableCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminMenuApplicableCollection;
        }

        /// <summary>
        /// Select a record from Account Balance Sheet Type Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetTypeMaster> SelectByID(AccountBalancesheetTypeMaster item)
        {

            IBaseEntityResponse<AccountBalancesheetTypeMaster> entityResponse = new BaseEntityResponse<AccountBalancesheetTypeMaster>();
            try
            {
                entityResponse = _accountBalancesheetTypeMasterDataProvider.GetAccountBalancesheetTypeMasterByID(item);
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
