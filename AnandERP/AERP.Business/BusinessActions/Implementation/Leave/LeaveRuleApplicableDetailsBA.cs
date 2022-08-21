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
    public class LeaveRuleApplicableDetailsBA : ILeaveRuleApplicableDetailsBA
    {
        ILeaveRuleApplicableDetailsDataProvider _leaveRuleApplicableDetailsDataProvider;
        ILeaveRuleApplicableDetailsBR _leaveRuleApplicableDetailsBR;
        private ILogger _logException;
        public LeaveRuleApplicableDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveRuleApplicableDetailsBR = new LeaveRuleApplicableDetailsBR();
            _leaveRuleApplicableDetailsDataProvider = new LeaveRuleApplicableDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveRuleApplicableDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleApplicableDetails> InsertLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item)
        {
            IBaseEntityResponse<LeaveRuleApplicableDetails> entityResponse = new BaseEntityResponse<LeaveRuleApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleApplicableDetailsBR.InsertLeaveRuleApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleApplicableDetailsDataProvider.InsertLeaveRuleApplicableDetails(item);
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
        /// Update a specific record  of LeaveRuleApplicableDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleApplicableDetails> UpdateLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item)
        {
            IBaseEntityResponse<LeaveRuleApplicableDetails> entityResponse = new BaseEntityResponse<LeaveRuleApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleApplicableDetailsBR.UpdateLeaveRuleApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleApplicableDetailsDataProvider.UpdateLeaveRuleApplicableDetails(item);
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
        /// Delete a selected record from LeaveRuleApplicableDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleApplicableDetails> DeleteLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item)
        {
            IBaseEntityResponse<LeaveRuleApplicableDetails> entityResponse = new BaseEntityResponse<LeaveRuleApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleApplicableDetailsBR.DeleteLeaveRuleApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleApplicableDetailsDataProvider.DeleteLeaveRuleApplicableDetails(item);
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
        /// Select all record from LeaveRuleApplicableDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> GetBySearch(LeaveRuleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> LeaveRuleApplicableDetailsCollection = new BaseEntityCollectionResponse<LeaveRuleApplicableDetails>();
            try
            {
                if (_leaveRuleApplicableDetailsDataProvider != null)
                    LeaveRuleApplicableDetailsCollection = _leaveRuleApplicableDetailsDataProvider.GetLeaveRuleApplicableDetailsBySearch(searchRequest);
                else
                {
                    LeaveRuleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveRuleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveRuleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveRuleApplicableDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveRuleApplicableDetailsCollection;
        }
        
        /// <summary>
        /// Select all record from LeaveRuleApplicableDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> SelectByLeaveRuleMasterID(LeaveRuleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> LeaveRuleApplicableDetailsCollection = new BaseEntityCollectionResponse<LeaveRuleApplicableDetails>();
            try
            {
                if (_leaveRuleApplicableDetailsDataProvider != null)
                    LeaveRuleApplicableDetailsCollection = _leaveRuleApplicableDetailsDataProvider.SelectByLeaveRuleMasterID(searchRequest);
                else
                {
                    LeaveRuleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveRuleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveRuleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveRuleApplicableDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveRuleApplicableDetailsCollection;
        }
        

        /// <summary>
        /// Select a record from LeaveRuleApplicableDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleApplicableDetails> SelectByID(LeaveRuleApplicableDetails item)
        {
            IBaseEntityResponse<LeaveRuleApplicableDetails> entityResponse = new BaseEntityResponse<LeaveRuleApplicableDetails>();
            try
            {
                entityResponse = _leaveRuleApplicableDetailsDataProvider.GetLeaveRuleApplicableDetailsByID(item);
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
