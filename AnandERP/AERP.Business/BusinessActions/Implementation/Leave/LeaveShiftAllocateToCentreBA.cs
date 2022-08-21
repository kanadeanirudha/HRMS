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
	public class LeaveShiftAllocateToCentreBA : ILeaveShiftAllocateToCentreBA
	{
		ILeaveShiftAllocateToCentreDataProvider _LeaveShiftAllocateToCentreDataProvider;
		ILeaveShiftAllocateToCentreBR _LeaveShiftAllocateToCentreBR;
		private ILogger _logException;
		public LeaveShiftAllocateToCentreBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_LeaveShiftAllocateToCentreBR = new LeaveShiftAllocateToCentreBR();
			_LeaveShiftAllocateToCentreDataProvider = new LeaveShiftAllocateToCentreDataProvider();
		}
		/// <summary>
		/// Create new record of LeaveShiftAllocateToCentre.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveShiftAllocateToCentre> InsertLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item)
		{
			IBaseEntityResponse<LeaveShiftAllocateToCentre> entityResponse = new BaseEntityResponse<LeaveShiftAllocateToCentre>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _LeaveShiftAllocateToCentreBR.InsertLeaveShiftAllocateToCentreValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _LeaveShiftAllocateToCentreDataProvider.InsertLeaveShiftAllocateToCentre(item);
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
		/// Update a specific record  of LeaveShiftAllocateToCentre.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveShiftAllocateToCentre> UpdateLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item)
		{
			IBaseEntityResponse<LeaveShiftAllocateToCentre> entityResponse = new BaseEntityResponse<LeaveShiftAllocateToCentre>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _LeaveShiftAllocateToCentreBR.UpdateLeaveShiftAllocateToCentreValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _LeaveShiftAllocateToCentreDataProvider.UpdateLeaveShiftAllocateToCentre(item);
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
		/// Delete a selected record from LeaveShiftAllocateToCentre.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveShiftAllocateToCentre> DeleteLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item)
		{
			IBaseEntityResponse<LeaveShiftAllocateToCentre> entityResponse = new BaseEntityResponse<LeaveShiftAllocateToCentre>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _LeaveShiftAllocateToCentreBR.DeleteLeaveShiftAllocateToCentreValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _LeaveShiftAllocateToCentreDataProvider.DeleteLeaveShiftAllocateToCentre(item);
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
		/// Select all record from LeaveShiftAllocateToCentre table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<LeaveShiftAllocateToCentre> GetBySearch(LeaveShiftAllocateToCentreSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<LeaveShiftAllocateToCentre> LeaveShiftAllocateToCentreCollection = new BaseEntityCollectionResponse<LeaveShiftAllocateToCentre>();
			try
			{
				if (_LeaveShiftAllocateToCentreDataProvider != null)
				LeaveShiftAllocateToCentreCollection = _LeaveShiftAllocateToCentreDataProvider.GetLeaveShiftAllocateToCentreBySearch(searchRequest);
				else
				{
					LeaveShiftAllocateToCentreCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					LeaveShiftAllocateToCentreCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				LeaveShiftAllocateToCentreCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				LeaveShiftAllocateToCentreCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return LeaveShiftAllocateToCentreCollection;
		}
		/// <summary>
		/// Select a record from LeaveShiftAllocateToCentre table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveShiftAllocateToCentre> SelectByID(LeaveShiftAllocateToCentre item)
		{
			IBaseEntityResponse<LeaveShiftAllocateToCentre> entityResponse = new BaseEntityResponse<LeaveShiftAllocateToCentre>();
			try
			{
				 entityResponse = _LeaveShiftAllocateToCentreDataProvider.GetLeaveShiftAllocateToCentreByID(item);
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
