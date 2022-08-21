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
    public class LeaveSummaryBA : ILeaveSummaryBA
    {
        ILeaveSummaryDataProvider _leaveSummaryDataProvider;
        ILeaveSummaryBR _leaveSummaryBR;
        private ILogger _logException;
        public LeaveSummaryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveSummaryBR = new LeaveSummaryBR();
            _leaveSummaryDataProvider = new LeaveSummaryDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveSummary.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSummary> InsertLeaveSummary(LeaveSummary item)
        {
            IBaseEntityResponse<LeaveSummary> entityResponse = new BaseEntityResponse<LeaveSummary>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSummaryBR.InsertLeaveSummaryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSummaryDataProvider.InsertLeaveSummary(item);
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
        /// Update a specific record  of LeaveSummary.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSummary> UpdateLeaveSummary(LeaveSummary item)
        {
            IBaseEntityResponse<LeaveSummary> entityResponse = new BaseEntityResponse<LeaveSummary>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSummaryBR.UpdateLeaveSummaryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSummaryDataProvider.UpdateLeaveSummary(item);
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
        /// Delete a selected record from LeaveSummary.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSummary> DeleteLeaveSummary(LeaveSummary item)
        {
            IBaseEntityResponse<LeaveSummary> entityResponse = new BaseEntityResponse<LeaveSummary>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveSummaryBR.DeleteLeaveSummaryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveSummaryDataProvider.DeleteLeaveSummary(item);
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
        /// Select all record from LeaveSummary table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveSummary> GetBySearch(LeaveSummarySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveSummary> LeaveSummaryCollection = new BaseEntityCollectionResponse<LeaveSummary>();
            try
            {
                if (_leaveSummaryDataProvider != null)
                    LeaveSummaryCollection = _leaveSummaryDataProvider.GetLeaveSummaryBySearch(searchRequest);
                else
                {
                    LeaveSummaryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveSummaryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveSummaryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveSummaryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveSummaryCollection;
        }
        /// <summary>
        /// Select a record from LeaveSummary table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveSummary> SelectByID(LeaveSummary item)
        {
            IBaseEntityResponse<LeaveSummary> entityResponse = new BaseEntityResponse<LeaveSummary>();
            try
            {
                entityResponse = _leaveSummaryDataProvider.GetLeaveSummaryByID(item);
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
