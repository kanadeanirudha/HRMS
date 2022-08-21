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
    public class AccountVoucherSettingMasterBA : IAccountVoucherSettingMasterBA
    {
        IAccountVoucherSettingMasterDataProvider _AccountVoucherSettingMasterDataProvider;
        IAccountVoucherSettingMasterBR _AccountVoucherSettingMasterBR;
        private ILogger _logException;
        public AccountVoucherSettingMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _AccountVoucherSettingMasterBR = new AccountVoucherSettingMasterBR();
            _AccountVoucherSettingMasterDataProvider = new AccountVoucherSettingMasterDataProvider();
        }
        /// <summary>
        /// Create new record of AccountVoucherSettingMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountVoucherSettingMaster> InsertAccountVoucherSettingMaster(AccountVoucherSettingMaster item)
        {
            IBaseEntityResponse<AccountVoucherSettingMaster> entityResponse = new BaseEntityResponse<AccountVoucherSettingMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AccountVoucherSettingMasterBR.InsertAccountVoucherSettingMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AccountVoucherSettingMasterDataProvider.InsertAccountVoucherSettingMaster(item);
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
        /// Update a specific record  of AccountVoucherSettingMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountVoucherSettingMaster> UpdateAccountVoucherSettingMaster(AccountVoucherSettingMaster item)
        {
            IBaseEntityResponse<AccountVoucherSettingMaster> entityResponse = new BaseEntityResponse<AccountVoucherSettingMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AccountVoucherSettingMasterBR.UpdateAccountVoucherSettingMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AccountVoucherSettingMasterDataProvider.UpdateAccountVoucherSettingMaster(item);
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
        /// Delete a selected record from AccountVoucherSettingMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountVoucherSettingMaster> DeleteAccountVoucherSettingMaster(AccountVoucherSettingMaster item)
        {
            IBaseEntityResponse<AccountVoucherSettingMaster> entityResponse = new BaseEntityResponse<AccountVoucherSettingMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AccountVoucherSettingMasterBR.DeleteAccountVoucherSettingMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AccountVoucherSettingMasterDataProvider.DeleteAccountVoucherSettingMaster(item);
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
        /// Select all record from AccountVoucherSettingMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountVoucherSettingMaster> GetBySearch(AccountVoucherSettingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountVoucherSettingMaster> AccountVoucherSettingMasterCollection = new BaseEntityCollectionResponse<AccountVoucherSettingMaster>();
            try
            {
                if (_AccountVoucherSettingMasterDataProvider != null)
                    AccountVoucherSettingMasterCollection = _AccountVoucherSettingMasterDataProvider.GetAccountVoucherSettingMasterBySearch(searchRequest);
                else
                {
                    AccountVoucherSettingMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountVoucherSettingMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountVoucherSettingMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountVoucherSettingMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountVoucherSettingMasterCollection;
        }
        /// <summary>
        /// Select a record from AccountVoucherSettingMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountVoucherSettingMaster> SelectByID(AccountVoucherSettingMaster item)
        {
            IBaseEntityResponse<AccountVoucherSettingMaster> entityResponse = new BaseEntityResponse<AccountVoucherSettingMaster>();
            try
            {
                entityResponse = _AccountVoucherSettingMasterDataProvider.GetAccountVoucherSettingMasterByID(item);
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
