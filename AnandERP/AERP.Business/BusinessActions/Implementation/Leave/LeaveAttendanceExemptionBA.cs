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
	public class LeaveAttendanceExemptionBA : ILeaveAttendanceExemptionBA
	{
		ILeaveAttendanceExemptionDataProvider _leaveAttendanceExemptionDataProvider;
		ILeaveAttendanceExemptionBR _leaveAttendanceExemptionBR;
		private ILogger _logException;
		public LeaveAttendanceExemptionBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_leaveAttendanceExemptionBR = new LeaveAttendanceExemptionBR();
			_leaveAttendanceExemptionDataProvider = new LeaveAttendanceExemptionDataProvider();
		}
		/// <summary>
		/// Create new record of LeaveAttendanceExemption.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveAttendanceExemption> InsertLeaveAttendanceExemption(LeaveAttendanceExemption item)
		{
			IBaseEntityResponse<LeaveAttendanceExemption> entityResponse = new BaseEntityResponse<LeaveAttendanceExemption>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _leaveAttendanceExemptionBR.InsertLeaveAttendanceExemptionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _leaveAttendanceExemptionDataProvider.InsertLeaveAttendanceExemption(item);
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
		/// Update a specific record  of LeaveAttendanceExemption.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveAttendanceExemption> UpdateLeaveAttendanceExemption(LeaveAttendanceExemption item)
		{
			IBaseEntityResponse<LeaveAttendanceExemption> entityResponse = new BaseEntityResponse<LeaveAttendanceExemption>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _leaveAttendanceExemptionBR.UpdateLeaveAttendanceExemptionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _leaveAttendanceExemptionDataProvider.UpdateLeaveAttendanceExemption(item);
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
		/// Delete a selected record from LeaveAttendanceExemption.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveAttendanceExemption> DeleteLeaveAttendanceExemption(LeaveAttendanceExemption item)
		{
			IBaseEntityResponse<LeaveAttendanceExemption> entityResponse = new BaseEntityResponse<LeaveAttendanceExemption>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _leaveAttendanceExemptionBR.DeleteLeaveAttendanceExemptionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _leaveAttendanceExemptionDataProvider.DeleteLeaveAttendanceExemption(item);
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
		/// Select all record from LeaveAttendanceExemption table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<LeaveAttendanceExemption> GetBySearch(LeaveAttendanceExemptionSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<LeaveAttendanceExemption> LeaveAttendanceExemptionCollection = new BaseEntityCollectionResponse<LeaveAttendanceExemption>();
			try
			{
				if (_leaveAttendanceExemptionDataProvider != null)
				LeaveAttendanceExemptionCollection = _leaveAttendanceExemptionDataProvider.GetLeaveAttendanceExemptionBySearch(searchRequest);
				else
				{
					LeaveAttendanceExemptionCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					LeaveAttendanceExemptionCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				LeaveAttendanceExemptionCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				LeaveAttendanceExemptionCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return LeaveAttendanceExemptionCollection;
		}
		/// <summary>
		/// Select a record from LeaveAttendanceExemption table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveAttendanceExemption> SelectByID(LeaveAttendanceExemption item)
		{
			IBaseEntityResponse<LeaveAttendanceExemption> entityResponse = new BaseEntityResponse<LeaveAttendanceExemption>();
			try
			{
				 entityResponse = _leaveAttendanceExemptionDataProvider.GetLeaveAttendanceExemptionByID(item);
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
