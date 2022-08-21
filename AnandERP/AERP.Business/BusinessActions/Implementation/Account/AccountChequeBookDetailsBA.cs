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
    public class AccountChequeBookDetailsBA : IAccountChequeBookDetailsBA
	{
        IAccountChequeBookDetailsDataProvider _AccountChequeBookDetailsDataProvider;
		IAccountChequeBookDetailsBR _AccountChequeBookDetailsBR;
		private ILogger _logException;
		public AccountChequeBookDetailsBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_AccountChequeBookDetailsBR = new AccountChequeBookDetailsBR();
			_AccountChequeBookDetailsDataProvider = new AccountChequeBookDetailsDataProvider();
		}
		/// <summary>
		/// Create new record of AccountChequeBookDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<AccountChequeBookDetails> InsertAccountChequeBookDetails(AccountChequeBookDetails item)
		{
            IBaseEntityResponse<AccountChequeBookDetails> entityResponse = new BaseEntityResponse<AccountChequeBookDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _AccountChequeBookDetailsBR.InsertAccountChequeBookDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _AccountChequeBookDetailsDataProvider.InsertAccountChequeBookDetails(item);
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
		/// Update a specific record  of AccountChequeBookDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<AccountChequeBookDetails> UpdateAccountChequeBookDetails(AccountChequeBookDetails item)
		{
			IBaseEntityResponse<AccountChequeBookDetails> entityResponse = new BaseEntityResponse<AccountChequeBookDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _AccountChequeBookDetailsBR.UpdateAccountChequeBookDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _AccountChequeBookDetailsDataProvider.UpdateAccountChequeBookDetails(item);
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
		/// Delete a selected record from AccountChequeBookDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<AccountChequeBookDetails> DeleteAccountChequeBookDetails(AccountChequeBookDetails item)
		{
			IBaseEntityResponse<AccountChequeBookDetails> entityResponse = new BaseEntityResponse<AccountChequeBookDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _AccountChequeBookDetailsBR.DeleteAccountChequeBookDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _AccountChequeBookDetailsDataProvider.DeleteAccountChequeBookDetails(item);
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
		/// Select all record from AccountChequeBookDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<AccountChequeBookDetails> GetBySearch(AccountChequeBookDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<AccountChequeBookDetails> AccountChequeBookDetailsCollection = new BaseEntityCollectionResponse<AccountChequeBookDetails>();
			try
			{
				if (_AccountChequeBookDetailsDataProvider != null)
				AccountChequeBookDetailsCollection = _AccountChequeBookDetailsDataProvider.GetAccountChequeBookDetailsBySearch(searchRequest);
				else
				{
					AccountChequeBookDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					AccountChequeBookDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				AccountChequeBookDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				AccountChequeBookDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return AccountChequeBookDetailsCollection;
		}
        
		/// <summary>
		/// Select all record from AccountChequeBookDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<AccountChequeBookDetails> GetBySearchForEditView(AccountChequeBookDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<AccountChequeBookDetails> AccountChequeBookDetailsCollection = new BaseEntityCollectionResponse<AccountChequeBookDetails>();
			try
			{
				if (_AccountChequeBookDetailsDataProvider != null)
                    AccountChequeBookDetailsCollection = _AccountChequeBookDetailsDataProvider.GetAccountChequeBookDetailsBySearchForEditView(searchRequest);
				else
				{
					AccountChequeBookDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					AccountChequeBookDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				AccountChequeBookDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				AccountChequeBookDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return AccountChequeBookDetailsCollection;
		}
		/// <summary>
		/// Select a record from AccountChequeBookDetails table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<AccountChequeBookDetails> SelectByID(AccountChequeBookDetails item)
		{
			IBaseEntityResponse<AccountChequeBookDetails> entityResponse = new BaseEntityResponse<AccountChequeBookDetails>();
			try
			{
				 entityResponse = _AccountChequeBookDetailsDataProvider.GetAccountChequeBookDetailsByID(item);
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
