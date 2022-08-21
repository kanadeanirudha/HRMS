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
    public class LeaveManualAttendanceBA : ILeaveManualAttendanceBA
    {
        ILeaveManualAttendanceDataProvider _leaveManualAttendanceDataProvider;
        ILeaveManualAttendanceBR _leaveManualAttendanceBR;
        private ILogger _logException;
        public LeaveManualAttendanceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveManualAttendanceBR = new LeaveManualAttendanceBR();
            _leaveManualAttendanceDataProvider = new LeaveManualAttendanceDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveManualAttendance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveManualAttendance> InsertLeaveManualAttendance(LeaveManualAttendance item)
        {
            IBaseEntityResponse<LeaveManualAttendance> entityResponse = new BaseEntityResponse<LeaveManualAttendance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveManualAttendanceBR.InsertLeaveManualAttendanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveManualAttendanceDataProvider.InsertLeaveManualAttendance(item);
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
        /// Update a specific record  of LeaveManualAttendance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveManualAttendance> UpdateLeaveManualAttendance(LeaveManualAttendance item)
        {
            IBaseEntityResponse<LeaveManualAttendance> entityResponse = new BaseEntityResponse<LeaveManualAttendance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveManualAttendanceBR.UpdateLeaveManualAttendanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveManualAttendanceDataProvider.UpdateLeaveManualAttendance(item);
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
        /// Delete a selected record from LeaveManualAttendance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveManualAttendance> DeleteLeaveManualAttendance(LeaveManualAttendance item)
        {
            IBaseEntityResponse<LeaveManualAttendance> entityResponse = new BaseEntityResponse<LeaveManualAttendance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveManualAttendanceBR.DeleteLeaveManualAttendanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveManualAttendanceDataProvider.DeleteLeaveManualAttendance(item);
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
        /// Select all record from LeaveManualAttendance table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveManualAttendance> GetBySearch(LeaveManualAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveManualAttendance> LeaveManualAttendanceCollection = new BaseEntityCollectionResponse<LeaveManualAttendance>();
            try
            {
                if (_leaveManualAttendanceDataProvider != null)
                    LeaveManualAttendanceCollection = _leaveManualAttendanceDataProvider.GetLeaveManualAttendanceBySearch(searchRequest);
                else
                {
                    LeaveManualAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveManualAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveManualAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveManualAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveManualAttendanceCollection;
        }
        /// <summary>
        /// Select a record from LeaveManualAttendance table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveManualAttendance> SelectByID(LeaveManualAttendance item)
        {
            IBaseEntityResponse<LeaveManualAttendance> entityResponse = new BaseEntityResponse<LeaveManualAttendance>();
            try
            {
                entityResponse = _leaveManualAttendanceDataProvider.GetLeaveManualAttendanceByID(item);
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
