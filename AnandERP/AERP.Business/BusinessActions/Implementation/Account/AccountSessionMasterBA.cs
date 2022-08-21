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
	public class AccountSessionMasterBA : IAccountSessionMasterBA
	{
        IAccountSessionMasterDataProvider _AccountSessionMasterDataProvider;
		IAccountSessionMasterBR _AccountSessionMasterBR;
		private ILogger _logException;
		public AccountSessionMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_AccountSessionMasterBR = new AccountSessionMasterBR();
			_AccountSessionMasterDataProvider = new AccountSessionMasterDataProvider();
		}
		/// <summary>
		/// Create new record of AccountSessionMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<AccountSessionMaster> InsertAccountSessionMaster(AccountSessionMaster item)
		{
			IBaseEntityResponse<AccountSessionMaster> entityResponse = new BaseEntityResponse<AccountSessionMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _AccountSessionMasterBR.InsertAccountSessionMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _AccountSessionMasterDataProvider.InsertAccountSessionMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Update a specific record  of AccountSessionMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<AccountSessionMaster> UpdateAccountSessionMaster(AccountSessionMaster item)
		{
			IBaseEntityResponse<AccountSessionMaster> entityResponse = new BaseEntityResponse<AccountSessionMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _AccountSessionMasterBR.UpdateAccountSessionMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _AccountSessionMasterDataProvider.UpdateAccountSessionMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Delete a selected record from AccountSessionMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<AccountSessionMaster> DeleteAccountSessionMaster(AccountSessionMaster item)
		{
			IBaseEntityResponse<AccountSessionMaster> entityResponse = new BaseEntityResponse<AccountSessionMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _AccountSessionMasterBR.DeleteAccountSessionMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _AccountSessionMasterDataProvider.DeleteAccountSessionMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Select all record from AccountSessionMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<AccountSessionMaster> GetBySearch(AccountSessionMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<AccountSessionMaster> AccountSessionMasterCollection = new BaseEntityCollectionResponse<AccountSessionMaster>();
			try
			{
				if (_AccountSessionMasterDataProvider != null)
				AccountSessionMasterCollection = _AccountSessionMasterDataProvider.GetAccountSessionMasterBySearch(searchRequest);
				else
				{
					AccountSessionMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					AccountSessionMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				AccountSessionMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				AccountSessionMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return AccountSessionMasterCollection;
		}
		/// <summary>
		/// Select all record from AccountSessionMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<AccountSessionMaster> GetAccountSessionList(AccountSessionMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<AccountSessionMaster> AccountSessionMasterCollection = new BaseEntityCollectionResponse<AccountSessionMaster>();
			try
			{
				if (_AccountSessionMasterDataProvider != null)
                    AccountSessionMasterCollection = _AccountSessionMasterDataProvider.GetAccountSessionList(searchRequest);
				else
				{
					AccountSessionMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					AccountSessionMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				AccountSessionMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				AccountSessionMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return AccountSessionMasterCollection;
		}        
		/// <summary>
		/// Select a record from AccountSessionMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<AccountSessionMaster> SelectByID(AccountSessionMaster item)
		{
			IBaseEntityResponse<AccountSessionMaster> entityResponse = new BaseEntityResponse<AccountSessionMaster>();
			try
			{
				 entityResponse = _AccountSessionMasterDataProvider.GetAccountSessionMasterByID(item);
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
        /// Select a record from AccountSessionMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountSessionMaster> GetCurrentAccountSession(AccountSessionMaster item)
        {
            IBaseEntityResponse<AccountSessionMaster> entityResponse = new BaseEntityResponse<AccountSessionMaster>();
            try
            {
                entityResponse = _AccountSessionMasterDataProvider.GetCurrentAccountSession(item);
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

        public IBaseEntityResponse<AccountSessionMaster> InsertAccountYearEndJob(AccountSessionMaster item)
        {
            IBaseEntityResponse<AccountSessionMaster> entityResponse = new BaseEntityResponse<AccountSessionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AccountSessionMasterBR.InsertAccountYearEndJobValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AccountSessionMasterDataProvider.InsertAccountYearEndJob(item);
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

        public IBaseEntityResponse<AccountSessionMaster> GetCurrentAccountSession_AccountYearEnd(AccountSessionMaster item)
        {
            IBaseEntityResponse<AccountSessionMaster> entityResponse = new BaseEntityResponse<AccountSessionMaster>();
            try
            {
                entityResponse = _AccountSessionMasterDataProvider.GetCurrentAccountSession_AccountYearEnd(item);
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

        public IBaseEntityCollectionResponse<AccountSessionMaster> GetCentreWiseBalncesheetForYearEndJobList(AccountSessionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountSessionMaster> AccountSessionMasterCollection = new BaseEntityCollectionResponse<AccountSessionMaster>();
            try
            {
                if (_AccountSessionMasterDataProvider != null)
                    AccountSessionMasterCollection = _AccountSessionMasterDataProvider.GetCentreWiseBalncesheetForYearEndJobList(searchRequest);
                else
                {
                    AccountSessionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountSessionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountSessionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountSessionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountSessionMasterCollection;
        }
        public IBaseEntityCollectionResponse<AccountSessionMaster> GetAccountSessionMasterSelectList(AccountSessionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountSessionMaster> AccountSessionMasterCollection = new BaseEntityCollectionResponse<AccountSessionMaster>();
            try
            {
                if (_AccountSessionMasterDataProvider != null)
                    AccountSessionMasterCollection = _AccountSessionMasterDataProvider.GetAccountSessionMasterSelectList(searchRequest);
                else
                {
                    AccountSessionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountSessionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountSessionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountSessionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountSessionMasterCollection;
        }
    }
}
