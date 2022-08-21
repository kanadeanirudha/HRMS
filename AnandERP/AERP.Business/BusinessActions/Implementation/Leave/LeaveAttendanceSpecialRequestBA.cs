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
	public class LeaveAttendanceSpecialRequestBA : ILeaveAttendanceSpecialRequestBA
	{
		ILeaveAttendanceSpecialRequestDataProvider _LeaveAttendanceSpecialRequestDataProvider;
		ILeaveAttendanceSpecialRequestBR _LeaveAttendanceSpecialRequestBR;
		private ILogger _logException;
		public LeaveAttendanceSpecialRequestBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_LeaveAttendanceSpecialRequestBR = new LeaveAttendanceSpecialRequestBR();
			_LeaveAttendanceSpecialRequestDataProvider = new LeaveAttendanceSpecialRequestDataProvider();
		}
		/// <summary>
		/// Create new record of LeaveAttendanceSpecialRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveAttendanceSpecialRequest> InsertLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item)
		{
			IBaseEntityResponse<LeaveAttendanceSpecialRequest> entityResponse = new BaseEntityResponse<LeaveAttendanceSpecialRequest>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _LeaveAttendanceSpecialRequestBR.InsertLeaveAttendanceSpecialRequestValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _LeaveAttendanceSpecialRequestDataProvider.InsertLeaveAttendanceSpecialRequest(item);
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
		/// Update a specific record  of LeaveAttendanceSpecialRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveAttendanceSpecialRequest> UpdateLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item)
		{
			IBaseEntityResponse<LeaveAttendanceSpecialRequest> entityResponse = new BaseEntityResponse<LeaveAttendanceSpecialRequest>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _LeaveAttendanceSpecialRequestBR.UpdateLeaveAttendanceSpecialRequestValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _LeaveAttendanceSpecialRequestDataProvider.UpdateLeaveAttendanceSpecialRequest(item);
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
		/// Delete a selected record from LeaveAttendanceSpecialRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveAttendanceSpecialRequest> DeleteLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item)
		{
			IBaseEntityResponse<LeaveAttendanceSpecialRequest> entityResponse = new BaseEntityResponse<LeaveAttendanceSpecialRequest>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _LeaveAttendanceSpecialRequestBR.DeleteLeaveAttendanceSpecialRequestValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _LeaveAttendanceSpecialRequestDataProvider.DeleteLeaveAttendanceSpecialRequest(item);
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
		/// Select all record from LeaveAttendanceSpecialRequest table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<LeaveAttendanceSpecialRequest> GetBySearch(LeaveAttendanceSpecialRequestSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<LeaveAttendanceSpecialRequest> LeaveAttendanceSpecialRequestCollection = new BaseEntityCollectionResponse<LeaveAttendanceSpecialRequest>();
			try
			{
				if (_LeaveAttendanceSpecialRequestDataProvider != null)
				LeaveAttendanceSpecialRequestCollection = _LeaveAttendanceSpecialRequestDataProvider.GetLeaveAttendanceSpecialRequestBySearch(searchRequest);
				else
				{
					LeaveAttendanceSpecialRequestCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					LeaveAttendanceSpecialRequestCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				LeaveAttendanceSpecialRequestCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				LeaveAttendanceSpecialRequestCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return LeaveAttendanceSpecialRequestCollection;
		}
		/// <summary>
		/// Select a record from LeaveAttendanceSpecialRequest table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<LeaveAttendanceSpecialRequest> SelectByID(LeaveAttendanceSpecialRequest item)
		{
			IBaseEntityResponse<LeaveAttendanceSpecialRequest> entityResponse = new BaseEntityResponse<LeaveAttendanceSpecialRequest>();
			try
			{
				 entityResponse = _LeaveAttendanceSpecialRequestDataProvider.GetLeaveAttendanceSpecialRequestByID(item);
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
