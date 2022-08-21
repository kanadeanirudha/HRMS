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
    public class LeaveAvailedBA : ILeaveAvailedBA
    {
        ILeaveAvailedDataProvider _leaveAvailedDataProvider;
        ILeaveAvailedBR _leaveAvailedBR;
        private ILogger _logException;
        public LeaveAvailedBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveAvailedBR = new LeaveAvailedBR();
            _leaveAvailedDataProvider = new LeaveAvailedDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveAvailed.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAvailed> InsertLeaveAvailed(LeaveAvailed item)
        {
            IBaseEntityResponse<LeaveAvailed> entityResponse = new BaseEntityResponse<LeaveAvailed>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveAvailedBR.InsertLeaveAvailedValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveAvailedDataProvider.InsertLeaveAvailed(item);
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
        /// Update a specific record  of LeaveAvailed.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAvailed> UpdateLeaveAvailed(LeaveAvailed item)
        {
            IBaseEntityResponse<LeaveAvailed> entityResponse = new BaseEntityResponse<LeaveAvailed>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveAvailedBR.UpdateLeaveAvailedValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveAvailedDataProvider.UpdateLeaveAvailed(item);
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
        /// Delete a selected record from LeaveAvailed.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAvailed> DeleteLeaveAvailed(LeaveAvailed item)
        {
            IBaseEntityResponse<LeaveAvailed> entityResponse = new BaseEntityResponse<LeaveAvailed>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveAvailedBR.DeleteLeaveAvailedValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveAvailedDataProvider.DeleteLeaveAvailed(item);
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
        /// Select all record from LeaveAvailed table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveAvailed> GetBySearch(LeaveAvailedSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveAvailed> LeaveAvailedCollection = new BaseEntityCollectionResponse<LeaveAvailed>();
            try
            {
                if (_leaveAvailedDataProvider != null)
                    LeaveAvailedCollection = _leaveAvailedDataProvider.GetLeaveAvailedBySearch(searchRequest);
                else
                {
                    LeaveAvailedCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveAvailedCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveAvailedCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveAvailedCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveAvailedCollection;
        }
        /// <summary>
        /// Select a record from LeaveAvailed table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveAvailed> SelectByID(LeaveAvailed item)
        {
            IBaseEntityResponse<LeaveAvailed> entityResponse = new BaseEntityResponse<LeaveAvailed>();
            try
            {
                entityResponse = _leaveAvailedDataProvider.GetLeaveAvailedByID(item);
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
        /// Select all record from LeaveAvailed table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveAvailed> GetLeaveRequestForApproval_ByPersonID(LeaveAvailedSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveAvailed> LeaveAvailedCollection = new BaseEntityCollectionResponse<LeaveAvailed>();
            try
            {
                if (_leaveAvailedDataProvider != null)
                    LeaveAvailedCollection = _leaveAvailedDataProvider.GetLeaveRequestForApproval_ByPersonID(searchRequest);
                else
                {
                    LeaveAvailedCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveAvailedCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveAvailedCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveAvailedCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveAvailedCollection;
        }
        
    }
}
