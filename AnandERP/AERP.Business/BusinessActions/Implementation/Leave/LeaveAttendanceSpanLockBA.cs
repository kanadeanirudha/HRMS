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
    public class LeaveAttendanceSpanLockBA : ILeaveAttendanceSpanLockBA
    {
        ILeaveAttendanceSpanLockDataProvider _leaveAttendanceSpanLockDataProvider;
        ILeaveAttendanceSpanLockBR _leaveAttendanceSpanLockBR;
        private ILogger _logException;
        public LeaveAttendanceSpanLockBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveAttendanceSpanLockBR = new LeaveAttendanceSpanLockBR();
            _leaveAttendanceSpanLockDataProvider = new LeaveAttendanceSpanLockDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveAttendanceSpanLock.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAttendanceSpanLock> InsertLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item)
        {
            IBaseEntityResponse<LeaveAttendanceSpanLock> entityResponse = new BaseEntityResponse<LeaveAttendanceSpanLock>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveAttendanceSpanLockBR.InsertLeaveAttendanceSpanLockValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveAttendanceSpanLockDataProvider.InsertLeaveAttendanceSpanLock(item);
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
        /// Update a specific record  of LeaveAttendanceSpanLock.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAttendanceSpanLock> UpdateLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item)
        {
            IBaseEntityResponse<LeaveAttendanceSpanLock> entityResponse = new BaseEntityResponse<LeaveAttendanceSpanLock>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveAttendanceSpanLockBR.UpdateLeaveAttendanceSpanLockValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveAttendanceSpanLockDataProvider.UpdateLeaveAttendanceSpanLock(item);
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
        /// Delete a selected record from LeaveAttendanceSpanLock.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAttendanceSpanLock> DeleteLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item)
        {
            IBaseEntityResponse<LeaveAttendanceSpanLock> entityResponse = new BaseEntityResponse<LeaveAttendanceSpanLock>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveAttendanceSpanLockBR.DeleteLeaveAttendanceSpanLockValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveAttendanceSpanLockDataProvider.DeleteLeaveAttendanceSpanLock(item);
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
        /// Select all record from LeaveAttendanceSpanLock table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetBySearch(LeaveAttendanceSpanLockSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> LeaveAttendanceSpanLockCollection = new BaseEntityCollectionResponse<LeaveAttendanceSpanLock>();
            try
            {
                if (_leaveAttendanceSpanLockDataProvider != null)
                    LeaveAttendanceSpanLockCollection = _leaveAttendanceSpanLockDataProvider.GetLeaveAttendanceSpanLockBySearch(searchRequest);
                else
                {
                    LeaveAttendanceSpanLockCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveAttendanceSpanLockCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveAttendanceSpanLockCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveAttendanceSpanLockCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveAttendanceSpanLockCollection;
        }
        /// <summary>
        /// Select a record from LeaveAttendanceSpanLock table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAttendanceSpanLock> SelectByID(LeaveAttendanceSpanLock item)
        {
            IBaseEntityResponse<LeaveAttendanceSpanLock> entityResponse = new BaseEntityResponse<LeaveAttendanceSpanLock>();
            try
            {
                entityResponse = _leaveAttendanceSpanLockDataProvider.GetLeaveAttendanceSpanLockByID(item);
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

        public IBaseEntityResponse<LeaveAttendanceSpanLock> SelectByCentreCode(LeaveAttendanceSpanLock item)
        {
            IBaseEntityResponse<LeaveAttendanceSpanLock> entityResponse = new BaseEntityResponse<LeaveAttendanceSpanLock>();
            try
            {
                entityResponse = _leaveAttendanceSpanLockDataProvider.SelectByCentreCode(item);
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
        /// Select all record from LeaveAttendanceSpanLock table with search parameters centre code.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetByCentreCode(LeaveAttendanceSpanLockSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> LeaveAttendanceSpanLockCollection = new BaseEntityCollectionResponse<LeaveAttendanceSpanLock>();
            try
            {
                if (_leaveAttendanceSpanLockDataProvider != null)
                    LeaveAttendanceSpanLockCollection = _leaveAttendanceSpanLockDataProvider.GetLeaveAttendanceSpanLockByCentreCode(searchRequest);
                else
                {
                    LeaveAttendanceSpanLockCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveAttendanceSpanLockCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveAttendanceSpanLockCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveAttendanceSpanLockCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveAttendanceSpanLockCollection;
        }
        
        /// <summary>
        /// Select all record from LeaveAttendanceSpanLock table with search parameters centre code.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetByCentreCodeDepartmentIDAndSalarySpanID(LeaveAttendanceSpanLockSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> LeaveAttendanceSpanLockCollection = new BaseEntityCollectionResponse<LeaveAttendanceSpanLock>();
            try
            {
                if (_leaveAttendanceSpanLockDataProvider != null)
                    LeaveAttendanceSpanLockCollection = _leaveAttendanceSpanLockDataProvider.GetByCentreCodeDepartmentIDAndSalarySpanID(searchRequest);
                else
                {
                    LeaveAttendanceSpanLockCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveAttendanceSpanLockCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveAttendanceSpanLockCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveAttendanceSpanLockCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveAttendanceSpanLockCollection;
        }
        
    }
}
