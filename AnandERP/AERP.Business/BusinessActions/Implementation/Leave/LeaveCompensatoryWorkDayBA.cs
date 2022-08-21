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
    public class LeaveCompensatoryWorkDayBA : ILeaveCompensatoryWorkDayBA
    {
        ILeaveCompensatoryWorkDayDataProvider _leaveCompensatoryWorkDayDataProvider;
        ILeaveCompensatoryWorkDayBR _leaveCompensatoryWorkDayBR;
        private ILogger _logException;
        public LeaveCompensatoryWorkDayBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveCompensatoryWorkDayBR = new LeaveCompensatoryWorkDayBR();
            _leaveCompensatoryWorkDayDataProvider = new LeaveCompensatoryWorkDayDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveCompensatoryWorkDay.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> InsertLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item)
        {
            IBaseEntityResponse<LeaveCompensatoryWorkDay> entityResponse = new BaseEntityResponse<LeaveCompensatoryWorkDay>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveCompensatoryWorkDayBR.InsertLeaveCompensatoryWorkDayValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveCompensatoryWorkDayDataProvider.InsertLeaveCompensatoryWorkDay(item);
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
        /// Update a specific record  of LeaveCompensatoryWorkDay.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> UpdateLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item)
        {
            IBaseEntityResponse<LeaveCompensatoryWorkDay> entityResponse = new BaseEntityResponse<LeaveCompensatoryWorkDay>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveCompensatoryWorkDayBR.UpdateLeaveCompensatoryWorkDayValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveCompensatoryWorkDayDataProvider.UpdateLeaveCompensatoryWorkDay(item);
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
        /// Delete a selected record from LeaveCompensatoryWorkDay.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> DeleteLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item)
        {
            IBaseEntityResponse<LeaveCompensatoryWorkDay> entityResponse = new BaseEntityResponse<LeaveCompensatoryWorkDay>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveCompensatoryWorkDayBR.DeleteLeaveCompensatoryWorkDayValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveCompensatoryWorkDayDataProvider.DeleteLeaveCompensatoryWorkDay(item);
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
        /// Select all record from LeaveCompensatoryWorkDay table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> GetBySearch(LeaveCompensatoryWorkDaySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> LeaveCompensatoryWorkDayCollection = new BaseEntityCollectionResponse<LeaveCompensatoryWorkDay>();
            try
            {
                if (_leaveCompensatoryWorkDayDataProvider != null)
                    LeaveCompensatoryWorkDayCollection = _leaveCompensatoryWorkDayDataProvider.GetLeaveCompensatoryWorkDayBySearch(searchRequest);
                else
                {
                    LeaveCompensatoryWorkDayCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveCompensatoryWorkDayCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveCompensatoryWorkDayCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveCompensatoryWorkDayCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveCompensatoryWorkDayCollection;
        }
        /// <summary>
        /// Select a record from LeaveCompensatoryWorkDay table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> SelectByID(LeaveCompensatoryWorkDay item)
        {
            IBaseEntityResponse<LeaveCompensatoryWorkDay> entityResponse = new BaseEntityResponse<LeaveCompensatoryWorkDay>();
            try
            {
                entityResponse = _leaveCompensatoryWorkDayDataProvider.GetLeaveCompensatoryWorkDayByID(item);
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
        /// Select a record from LeaveCompensatoryWorkDay table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> GetCompensatoryOffDayApplicationDetailsByID(LeaveCompensatoryWorkDay item)
        {
            IBaseEntityResponse<LeaveCompensatoryWorkDay> entityResponse = new BaseEntityResponse<LeaveCompensatoryWorkDay>();
            try
            {
                entityResponse = _leaveCompensatoryWorkDayDataProvider.GetCompensatoryOffDayApplicationDetailsByID(item);
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
        /// Create new record of LeaveCompensatoryWorkDay.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveCompensatoryWorkDay> InsertApprovedCompensatoryWorkDayRecord(LeaveCompensatoryWorkDay item)
        {
            IBaseEntityResponse<LeaveCompensatoryWorkDay> entityResponse = new BaseEntityResponse<LeaveCompensatoryWorkDay>();
            try
            {
                //IValidateBusinessRuleResponse brResponse = _leaveCompensatoryWorkDayBR.InsertLeaveCompensatoryWorkDayValidate(item);
                //if (brResponse.Passed)
                //{
                entityResponse = _leaveCompensatoryWorkDayDataProvider.InsertApprovedCompensatoryWorkDayRecord(item);
                //}
                //else
                //{
                //    entityResponse.Message.Add(new MessageDTO
                //    {
                //        ErrorMessage = Resources.Null_Object_Exception,
                //        MessageType = MessageTypeEnum.Error
                //    });
                //    entityResponse.Entity = null; ;
                //}
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
        /// Select all record from LeaveCompensatoryWorkDay table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> GetCompensatoryWorkDayDataByEmployeeAndLeaveSessionID(LeaveCompensatoryWorkDaySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> LeaveCompensatoryWorkDayCollection = new BaseEntityCollectionResponse<LeaveCompensatoryWorkDay>();
            try
            {
                if (_leaveCompensatoryWorkDayDataProvider != null)
                    LeaveCompensatoryWorkDayCollection = _leaveCompensatoryWorkDayDataProvider.GetCompensatoryWorkDayDataByEmployeeAndLeaveSessionID(searchRequest);
                else
                {
                    LeaveCompensatoryWorkDayCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveCompensatoryWorkDayCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveCompensatoryWorkDayCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveCompensatoryWorkDayCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveCompensatoryWorkDayCollection;
        }
        
    }
}
