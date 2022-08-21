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
    public class AccountHeadMasterBA: IAccountHeadMasterBA
    {
        IAccountHeadMasterDataProvider _accountHeadMasterDataProvider;
        IAccountHeadMasterBR _accountHeadMasterBR;
        private ILogger _logException;

        public AccountHeadMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountHeadMasterBR = new AccountHeadMasterBR();
            _accountHeadMasterDataProvider = new AccountHeadMasterDataProvider();
        }

        /// <summary>
        /// Create new record of Account Head Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMaster> InsertAccountHeadMaster(AccountHeadMaster item)
        {
            IBaseEntityResponse<AccountHeadMaster> entityResponse = new BaseEntityResponse<AccountHeadMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountHeadMasterBR.InsertAccountHeadMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountHeadMasterDataProvider.InsertAccountHeadMaster(item);
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
        /// Update a specific record of Account Head Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMaster> UpdateAccountHeadMaster(AccountHeadMaster item)
        {
            IBaseEntityResponse<AccountHeadMaster> entityResponse = new BaseEntityResponse<AccountHeadMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountHeadMasterBR.UpdateAccountHeadMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountHeadMasterDataProvider.UpdateAccountHeadMaster(item);
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
        /// Delete a selected record from Account Head Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMaster> DeleteAccountHeadMaster(AccountHeadMaster item)
        {
            IBaseEntityResponse<AccountHeadMaster> entityResponse = new BaseEntityResponse<AccountHeadMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _accountHeadMasterBR.DeleteAccountHeadMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _accountHeadMasterDataProvider.DeleteAccountHeadMaster(item);
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
        /// Select all record from Account Head Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountHeadMaster> GetAccountHeadMasterBySearch(AccountHeadMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountHeadMaster> AdminMenuApplicableCollection = new BaseEntityCollectionResponse<AccountHeadMaster>();
            try
            {
                if (_accountHeadMasterDataProvider != null)
                {
                    AdminMenuApplicableCollection = _accountHeadMasterDataProvider.GetAccountHeadMasterBySearch(searchRequest);
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
        /// Select all record from Account Head Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountHeadMaster> GetAccountHeadNameList(AccountHeadMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountHeadMaster> AdminMenuApplicableCollection = new BaseEntityCollectionResponse<AccountHeadMaster>();
            try
            {
                if (_accountHeadMasterDataProvider != null)
                {
                    AdminMenuApplicableCollection = _accountHeadMasterDataProvider.GetAccountHeadNameList(searchRequest);
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
        /// Select a record from Account Head Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMaster> GetAccountHeadMasterByID(AccountHeadMaster item)
        {

            IBaseEntityResponse<AccountHeadMaster> entityResponse = new BaseEntityResponse<AccountHeadMaster>();
            try
            {
                entityResponse = _accountHeadMasterDataProvider.GetAccountHeadMasterByID(item);
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
