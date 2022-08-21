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
    public class LeaveLateMarkRulesDetailsBA : ILeaveLateMarkRulesDetailsBA
    {
        ILeaveLateMarkRulesDetailsDataProvider _leaveLateMarkRulesDetailsDataProvider;
        ILeaveLateMarkRulesDetailsBR _leaveLateMarkRulesDetailsBR;
        private ILogger _logException;
        public LeaveLateMarkRulesDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveLateMarkRulesDetailsBR = new LeaveLateMarkRulesDetailsBR();
            _leaveLateMarkRulesDetailsDataProvider = new LeaveLateMarkRulesDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveLateMarkRulesDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveLateMarkRulesDetails> InsertLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item)
        {
            IBaseEntityResponse<LeaveLateMarkRulesDetails> entityResponse = new BaseEntityResponse<LeaveLateMarkRulesDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveLateMarkRulesDetailsBR.InsertLeaveLateMarkRulesDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveLateMarkRulesDetailsDataProvider.InsertLeaveLateMarkRulesDetails(item);
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
        /// Update a specific record  of LeaveLateMarkRulesDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveLateMarkRulesDetails> UpdateLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item)
        {
            IBaseEntityResponse<LeaveLateMarkRulesDetails> entityResponse = new BaseEntityResponse<LeaveLateMarkRulesDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveLateMarkRulesDetailsBR.UpdateLeaveLateMarkRulesDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveLateMarkRulesDetailsDataProvider.UpdateLeaveLateMarkRulesDetails(item);
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
        /// Delete a selected record from LeaveLateMarkRulesDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveLateMarkRulesDetails> DeleteLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item)
        {
            IBaseEntityResponse<LeaveLateMarkRulesDetails> entityResponse = new BaseEntityResponse<LeaveLateMarkRulesDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveLateMarkRulesDetailsBR.DeleteLeaveLateMarkRulesDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveLateMarkRulesDetailsDataProvider.DeleteLeaveLateMarkRulesDetails(item);
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
        /// Select all record from LeaveLateMarkRulesDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveLateMarkRulesDetails> GetBySearch(LeaveLateMarkRulesDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveLateMarkRulesDetails> LeaveLateMarkRulesDetailsCollection = new BaseEntityCollectionResponse<LeaveLateMarkRulesDetails>();
            try
            {
                if (_leaveLateMarkRulesDetailsDataProvider != null)
                    LeaveLateMarkRulesDetailsCollection = _leaveLateMarkRulesDetailsDataProvider.GetLeaveLateMarkRulesDetailsBySearch(searchRequest);
                else
                {
                    LeaveLateMarkRulesDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveLateMarkRulesDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveLateMarkRulesDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveLateMarkRulesDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveLateMarkRulesDetailsCollection;
        }
        /// <summary>
        /// Select a record from LeaveLateMarkRulesDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveLateMarkRulesDetails> SelectByID(LeaveLateMarkRulesDetails item)
        {
            IBaseEntityResponse<LeaveLateMarkRulesDetails> entityResponse = new BaseEntityResponse<LeaveLateMarkRulesDetails>();
            try
            {
                entityResponse = _leaveLateMarkRulesDetailsDataProvider.GetLeaveLateMarkRulesDetailsByID(item);
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
