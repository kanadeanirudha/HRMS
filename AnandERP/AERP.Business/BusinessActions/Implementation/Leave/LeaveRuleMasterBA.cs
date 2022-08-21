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
    public class LeaveRuleMasterBA : ILeaveRuleMasterBA
    {
        ILeaveRuleMasterDataProvider _leaveRuleMasterDataProvider;
        ILeaveRuleMasterBR _leaveRuleMasterBR;
        private ILogger _logException;
        public LeaveRuleMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveRuleMasterBR = new LeaveRuleMasterBR();
            _leaveRuleMasterDataProvider = new LeaveRuleMasterDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveRuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleMaster> InsertLeaveRuleMaster(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> entityResponse = new BaseEntityResponse<LeaveRuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleMasterBR.InsertLeaveRuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleMasterDataProvider.InsertLeaveRuleMaster(item);
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
        /// Update a specific record  of LeaveRuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleMaster> UpdateLeaveRuleMaster(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> entityResponse = new BaseEntityResponse<LeaveRuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleMasterBR.UpdateLeaveRuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleMasterDataProvider.UpdateLeaveRuleMaster(item);
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
        /// Delete a selected record from LeaveRuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleMaster> DeleteLeaveRuleMaster(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> entityResponse = new BaseEntityResponse<LeaveRuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleMasterBR.DeleteLeaveRuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleMasterDataProvider.DeleteLeaveRuleMaster(item);
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
        /// Select all record from LeaveRuleMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveRuleMaster> GetBySearch(LeaveRuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleMaster> LeaveRuleMasterCollection = new BaseEntityCollectionResponse<LeaveRuleMaster>();
            try
            {
                if (_leaveRuleMasterDataProvider != null)
                    LeaveRuleMasterCollection = _leaveRuleMasterDataProvider.GetLeaveRuleMasterBySearch(searchRequest);
                else
                {
                    LeaveRuleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveRuleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveRuleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveRuleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveRuleMasterCollection;
        }
        /// <summary>
        /// Select a record from LeaveRuleMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleMaster> SelectByID(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> entityResponse = new BaseEntityResponse<LeaveRuleMaster>();
            try
            {
                entityResponse = _leaveRuleMasterDataProvider.GetLeaveRuleMasterByID(item);
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
        /// Select all record from LeaveRuleMaster table with search parameters LeaveCode.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveRuleMaster> GetByLeaveCode(LeaveRuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleMaster> LeaveRuleMasterCollection = new BaseEntityCollectionResponse<LeaveRuleMaster>();
            try
            {
                if (_leaveRuleMasterDataProvider != null)
                    LeaveRuleMasterCollection = _leaveRuleMasterDataProvider.GetLeaveRuleMasterByLeaveCode(searchRequest);
                else
                {
                    LeaveRuleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveRuleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveRuleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveRuleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveRuleMasterCollection;
        }
         /// <summary>
        /// Select a record from LeaveRuleMasteR,LeaveMaster,LeaveSumary table by LeaveMasterID,EmployeeID and LeaveSessionID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleMaster> GetLeaveDetails(LeaveRuleMaster item)
        {
            IBaseEntityResponse<LeaveRuleMaster> entityResponse = new BaseEntityResponse<LeaveRuleMaster>();
            try
            {
                entityResponse = _leaveRuleMasterDataProvider.GetLeaveDetails(item);
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

        public IBaseEntityCollectionResponse<LeaveRuleMaster> LeaveRuleStatusGetByCentreAndEmployee(LeaveRuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleMaster> LeaveRuleMasterCollection = new BaseEntityCollectionResponse<LeaveRuleMaster>();
            try
            {
                if (_leaveRuleMasterDataProvider != null)
                    LeaveRuleMasterCollection = _leaveRuleMasterDataProvider.LeaveRuleStatusGetByCentreAndEmployee(searchRequest);
                else
                {
                    LeaveRuleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveRuleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveRuleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveRuleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveRuleMasterCollection;
        }
    }
}
