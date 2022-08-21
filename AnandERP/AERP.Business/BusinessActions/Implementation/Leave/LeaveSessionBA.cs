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
    public class LeaveSessionBA : ILeaveSessionBA
    {
        ILeaveSessionDataProvider _leaveSessionDataProvider;
        ILeaveSessionBR _leaveSessionBR;
        private ILogger _logException;
        public LeaveSessionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveSessionBR = new LeaveSessionBR();
            _leaveSessionDataProvider = new LeaveSessionDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveSession.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSession> InsertLeaveSession(LeaveSession item)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSessionBR.InsertLeaveSessionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSessionDataProvider.InsertLeaveSession(item);
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
        /// Update a specific record  of LeaveSession.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSession> UpdateLeaveSession(LeaveSession item)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSessionBR.UpdateLeaveSessionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSessionDataProvider.UpdateLeaveSession(item);
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
        /// Delete a selected record from LeaveSession.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSession> DeleteLeaveSession(LeaveSession item)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSessionBR.DeleteLeaveSessionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSessionDataProvider.DeleteLeaveSession(item);
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
        /// Select all record from LeaveSession table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveSession> GetBySearch(LeaveSessionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveSession> LeaveSessionCollection = new BaseEntityCollectionResponse<LeaveSession>();
            try
            {
                if (_leaveSessionDataProvider != null)
                    LeaveSessionCollection = _leaveSessionDataProvider.GetLeaveSessionBySearch(searchRequest);
                else
                {
                    LeaveSessionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveSessionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveSessionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveSessionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveSessionCollection;
        }
        /// <summary>
        /// Select a record from LeaveSession table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSession> SelectByID(LeaveSession item)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                entityResponse = _leaveSessionDataProvider.GetLeaveSessionByID(item);
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

        public IBaseEntityResponse<LeaveSession> SelectByEmployeeIDAndCentreCode(LeaveSessionSearchRequest searchRequest)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                entityResponse = _leaveSessionDataProvider.SelectByEmployeeIDAndCentreCode(searchRequest);
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
        /// Select all record from LeaveSession table with search parameters CentreCode.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
      


        /// <summary>
        /// Select all record from LeaveSession table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveSession> GetByFromLeaveSessionID(LeaveSessionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveSession> LeaveSessionCollection = new BaseEntityCollectionResponse<LeaveSession>();
            try
            {
                if (_leaveSessionDataProvider != null)
                    LeaveSessionCollection = _leaveSessionDataProvider.GetByFromLeaveSessionID(searchRequest);
                else
                {
                    LeaveSessionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveSessionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveSessionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveSessionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveSessionCollection;
        }


        
        public IBaseEntityResponse<LeaveSession> InsertLeaveSessionDetails(LeaveSession item)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSessionBR.InsertLeaveSessionDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSessionDataProvider.InsertLeaveSessionDetails(item);
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
        /// Update a specific record  of LeaveSessionDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSession> UpdateLeaveSessionDetails(LeaveSession item)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSessionBR.UpdateLeaveSessionDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSessionDataProvider.UpdateLeaveSessionDetails(item);
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
        /// Delete a selected record from LeaveSessionDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSession> DeleteLeaveSessionDetails(LeaveSession item)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSessionBR.DeleteLeaveSessionDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSessionDataProvider.DeleteLeaveSessionDetails(item);
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
        /// Select all record from LeaveSessionDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveSession> GetLeaveSessionDetailsBySearch(LeaveSessionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveSession> LeaveSessionDetailsCollection = new BaseEntityCollectionResponse<LeaveSession>();
            try
            {
                if (_leaveSessionDataProvider != null)
                    LeaveSessionDetailsCollection = _leaveSessionDataProvider.GetLeaveSessionDetailsBySearch(searchRequest);
                else
                {
                    LeaveSessionDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveSessionDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveSessionDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveSessionDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveSessionDetailsCollection;
        }
        /// <summary>
        /// Select a record from LeaveSessionDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSession> SelectLeaveSessionDetailsByID(LeaveSession item)
        {
            IBaseEntityResponse<LeaveSession> entityResponse = new BaseEntityResponse<LeaveSession>();
            try
            {
                entityResponse = _leaveSessionDataProvider.GetLeaveSessionDetailsByID(item);
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
