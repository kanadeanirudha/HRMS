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
    public class LeavePostBA : ILeavePostBA
    {
        ILeavePostDataProvider _LeavePostDataProvider;
        ILeavePostBR _LeavePostBR;
        private ILogger _logException;
        public LeavePostBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _LeavePostBR = new LeavePostBR();
            _LeavePostDataProvider = new LeavePostDataProvider();
        }
        /// <summary>
        /// Create new record of LeavePost.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeavePost> InsertLeavePostAtOpening(LeavePost item)
        {
            IBaseEntityResponse<LeavePost> entityResponse = new BaseEntityResponse<LeavePost>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _LeavePostBR.InsertLeavePostValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _LeavePostDataProvider.InsertLeavePostAtOpening(item);
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
        /// Update a specific record  of LeavePost.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeavePost> UpdateLeavePost(LeavePost item)
        {
            IBaseEntityResponse<LeavePost> entityResponse = new BaseEntityResponse<LeavePost>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _LeavePostBR.UpdateLeavePostValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _LeavePostDataProvider.UpdateLeavePost(item);
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
        /// Delete a selected record from LeavePost.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeavePost> DeleteLeavePost(LeavePost item)
        {
            IBaseEntityResponse<LeavePost> entityResponse = new BaseEntityResponse<LeavePost>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _LeavePostBR.DeleteLeavePostValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _LeavePostDataProvider.DeleteLeavePost(item);
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
        /// Select all record from LeavePost table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeavePost> GetBySearch(LeavePostSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeavePost> LeavePostCollection = new BaseEntityCollectionResponse<LeavePost>();
            try
            {
                if (_LeavePostDataProvider != null)
                    LeavePostCollection = _LeavePostDataProvider.GetLeavePostBySearch(searchRequest);
                else
                {
                    LeavePostCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeavePostCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeavePostCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeavePostCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeavePostCollection;
        }
        /// <summary>
        /// Select a record from LeavePost table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeavePost> SelectByID(LeavePost item)
        {
            IBaseEntityResponse<LeavePost> entityResponse = new BaseEntityResponse<LeavePost>();
            try
            {
                entityResponse = _LeavePostDataProvider.GetLeavePostByID(item);
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
        /// Create new record of LeavePost.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeavePost> InsertLeavePostAtYearEnd(LeavePost item)
        {
            IBaseEntityResponse<LeavePost> entityResponse = new BaseEntityResponse<LeavePost>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _LeavePostBR.InsertLeavePostValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _LeavePostDataProvider.InsertLeavePostAtYearEnd(item);
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
        /// Select all record from LeavePost table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeavePost> GetLeaveSummaryAtTheYearEndBySearch(LeavePostSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeavePost> LeavePostCollection = new BaseEntityCollectionResponse<LeavePost>();
            try
            {
                if (_LeavePostDataProvider != null)
                    LeavePostCollection = _LeavePostDataProvider.GetLeaveSummaryAtTheYearEndBySearch(searchRequest);
                else
                {
                    LeavePostCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeavePostCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeavePostCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeavePostCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeavePostCollection;
        }
        
    }
}
