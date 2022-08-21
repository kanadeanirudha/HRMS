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
namespace AERP.Business.BusinessActions
{
    public class AttendenceMonitoringSystemBA : IAttendenceMonitoringSystemBA
    {
        IAttendenceMonitoringSystemDataProvider _AttendenceMonitoringSystemDataProvider;
       // IAttendenceMonitoringSystemBR _AttendenceMonitoringSystemBR;
        private ILogger _logException;
        public AttendenceMonitoringSystemBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
           // _AttendenceMonitoringSystemBR = new AttendenceMonitoringSystemBR();
            _AttendenceMonitoringSystemDataProvider = new AttendenceMonitoringSystemDataProvider();
        }
       
        /// <summary>
        /// Select all record from AttendenceMonitoringSystem table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemBySearch(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AttendenceMonitoringSystem> AttendenceMonitoringSystemCollection = new BaseEntityCollectionResponse<AttendenceMonitoringSystem>();
            try
            {
                if (_AttendenceMonitoringSystemDataProvider != null)
                    AttendenceMonitoringSystemCollection = _AttendenceMonitoringSystemDataProvider.GetAttendenceMonitoringSystemBySearch(searchRequest);
                else
                {
                    AttendenceMonitoringSystemCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AttendenceMonitoringSystemCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AttendenceMonitoringSystemCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AttendenceMonitoringSystemCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AttendenceMonitoringSystemCollection;
        }
        /// <summary>
        /// Select a record from AttendenceMonitoringSystem table by CentreCode
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemByCentreCode(AttendenceMonitoringSystem item)
        {
            IBaseEntityResponse<AttendenceMonitoringSystem> entityResponse = new BaseEntityResponse<AttendenceMonitoringSystem>();
            try
            {
                entityResponse = _AttendenceMonitoringSystemDataProvider.GetAttendenceMonitoringSystemByCentreCode(item);
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
        /// Select all record from AttendenceMonitoringSystem table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetEmployeeList(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AttendenceMonitoringSystem> AttendenceMonitoringSystemCollection = new BaseEntityCollectionResponse<AttendenceMonitoringSystem>();
            try
            {
                if (_AttendenceMonitoringSystemDataProvider != null)
                    AttendenceMonitoringSystemCollection = _AttendenceMonitoringSystemDataProvider.GetEmployeeList(searchRequest);
                else
                {
                    AttendenceMonitoringSystemCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AttendenceMonitoringSystemCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AttendenceMonitoringSystemCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AttendenceMonitoringSystemCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AttendenceMonitoringSystemCollection;
        }
        /// <summary>
        /// Select all record from AttendenceMonitoringSystem table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceDetailsByEmployeeID_WebAPI(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AttendenceMonitoringSystem> AttendenceMonitoringSystemCollection = new BaseEntityCollectionResponse<AttendenceMonitoringSystem>();
            try
            {
                if (_AttendenceMonitoringSystemDataProvider != null)
                    AttendenceMonitoringSystemCollection = _AttendenceMonitoringSystemDataProvider.GetAttendenceDetailsByEmployeeID_WebAPI(searchRequest);
                else
                {
                    AttendenceMonitoringSystemCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AttendenceMonitoringSystemCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AttendenceMonitoringSystemCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AttendenceMonitoringSystemCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AttendenceMonitoringSystemCollection;
        }

        public IBaseEntityCollectionResponse<AttendenceMonitoringSystem> GetAttendenceDetailsByEmployeeID(AttendenceMonitoringSystemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AttendenceMonitoringSystem> AttendenceMonitoringSystemCollection = new BaseEntityCollectionResponse<AttendenceMonitoringSystem>();
            try
            {
                if (_AttendenceMonitoringSystemDataProvider != null)
                    AttendenceMonitoringSystemCollection = _AttendenceMonitoringSystemDataProvider.GetAttendenceDetailsByEmployeeID(searchRequest);
                else
                {
                    AttendenceMonitoringSystemCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AttendenceMonitoringSystemCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AttendenceMonitoringSystemCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AttendenceMonitoringSystemCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AttendenceMonitoringSystemCollection;
        }

    }
}
