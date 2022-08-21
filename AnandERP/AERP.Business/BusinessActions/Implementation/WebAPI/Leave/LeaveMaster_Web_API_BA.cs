using AERP.Base.DTO;
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
    public class LeaveMaster_Web_API_BA : ILeaveMaster_Web_API_BA
    {
        private ILogger _logException;
        private ILeaveMaster_Web_API_DataProvider _ILeaveMaster_Web_API_DataProvider;
        
        public LeaveMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ILeaveMaster_Web_API_DataProvider = new LeaveMaster_Web_API_DataProvider();
        }
        public IBaseEntityCollectionResponse<LeaveMaster> getLeaves(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> LeaveMasterCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            try
            {
                if (_ILeaveMaster_Web_API_DataProvider != null)
                    LeaveMasterCollection = _ILeaveMaster_Web_API_DataProvider.getLeaves(item);
                else
                {
                    LeaveMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveMasterCollection;
        }

        public IBaseEntityCollectionResponse<LeaveMaster> getVersionNumber(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> LeaveMasterCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            try
            {
                if (_ILeaveMaster_Web_API_DataProvider != null)
                    LeaveMasterCollection = _ILeaveMaster_Web_API_DataProvider.getVersionNumber(item);
                else
                {
                    LeaveMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveMasterCollection;
        }

        public IBaseEntityCollectionResponse<LeaveMaster> GetLeaveApplicationApprocedPendingStatus_SearchList(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> LeaveMasterCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            try
            {
                if (_ILeaveMaster_Web_API_DataProvider != null)
                    LeaveMasterCollection = _ILeaveMaster_Web_API_DataProvider.GetLeaveApplicationApprocedPendingStatus_SearchList(item);
                else
                {
                    LeaveMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveMasterCollection;
        }

        public IBaseEntityCollectionResponse<LeaveMaster> GetLeaveDetails(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> LeaveMasterCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            try
            {
                if (_ILeaveMaster_Web_API_DataProvider != null)
                    LeaveMasterCollection = _ILeaveMaster_Web_API_DataProvider.GetLeaveDetails(item);
                else
                {
                    LeaveMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveMasterCollection;
        }

        public IBaseEntityCollectionResponse<LeaveMaster> GetSpecialLeave(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> LeaveMasterCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            try
            {
                if (_ILeaveMaster_Web_API_DataProvider != null)
                    LeaveMasterCollection = _ILeaveMaster_Web_API_DataProvider.GetSpecialLeave(item);
                else
                {
                    LeaveMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveMasterCollection;
        }


        public IBaseEntityCollectionResponse<LeaveMaster> GetManualAttendance(LeaveMaster item)
        {
            IBaseEntityCollectionResponse<LeaveMaster> LeaveMasterCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            try
            {
                if (_ILeaveMaster_Web_API_DataProvider != null)
                    LeaveMasterCollection = _ILeaveMaster_Web_API_DataProvider.GetManualAttendance(item);
                else
                {
                    LeaveMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveMasterCollection;
        }
        public IBaseEntityResponse<LeaveMaster> InsertLeaveApplicationCancel(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> entityResponse = new BaseEntityResponse<LeaveMaster>();
            try
            {
                entityResponse = _ILeaveMaster_Web_API_DataProvider.InsertLeaveApplicationCancel(item);

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
        public IBaseEntityResponse<LeaveManualAttendance> InsertLeaveManualAttendance(LeaveManualAttendance item)
        {
            IBaseEntityResponse<LeaveManualAttendance> entityResponse = new BaseEntityResponse<LeaveManualAttendance>();
            try
            {
                entityResponse = _ILeaveMaster_Web_API_DataProvider.InsertLeaveManualAttendance(item);

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

        public IBaseEntityResponse<AddAttendance> AddAttendance(AddAttendance item)
        {
            IBaseEntityResponse<AddAttendance> entityResponse = new BaseEntityResponse<AddAttendance>();
            try
            {
                entityResponse = _ILeaveMaster_Web_API_DataProvider.AddAttendance(item);

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

        public IBaseEntityResponse<LeaveAttendanceSpecialRequest> InsertSpecialLeaveAttendance(LeaveAttendanceSpecialRequest item)
        {
            IBaseEntityResponse<LeaveAttendanceSpecialRequest> entityResponse = new BaseEntityResponse<LeaveAttendanceSpecialRequest>();
            try
            {
                entityResponse = _ILeaveMaster_Web_API_DataProvider.InsertSpecialLeaveAttendance(item);
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
