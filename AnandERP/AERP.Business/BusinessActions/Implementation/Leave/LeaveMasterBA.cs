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
    public class LeaveMasterBA : ILeaveMasterBA
    {
        ILeaveMasterDataProvider _leaveMasterDataProvider;
        ILeaveMasterBR _leaveMasterBR;
        private ILogger _logException;
        public LeaveMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveMasterBR = new LeaveMasterBR();
            _leaveMasterDataProvider = new LeaveMasterDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveMaster> InsertLeaveMaster(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> entityResponse = new BaseEntityResponse<LeaveMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveMasterBR.InsertLeaveMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveMasterDataProvider.InsertLeaveMaster(item);
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
        /// Update a specific record  of LeaveMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveMaster> UpdateLeaveMaster(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> entityResponse = new BaseEntityResponse<LeaveMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveMasterBR.UpdateLeaveMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveMasterDataProvider.UpdateLeaveMaster(item);
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
        /// Delete a selected record from LeaveMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveMaster> DeleteLeaveMaster(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> entityResponse = new BaseEntityResponse<LeaveMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveMasterBR.DeleteLeaveMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveMasterDataProvider.DeleteLeaveMaster(item);
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
        /// Select all record from LeaveMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveMaster> GetBySearch(LeaveMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveMaster> LeaveMasterCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            try
            {
                if (_leaveMasterDataProvider != null)
                    LeaveMasterCollection = _leaveMasterDataProvider.GetLeaveMasterBySearch(searchRequest);
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
                LeaveMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveMasterCollection;
        }
        /// <summary>
        /// Select a record from LeaveMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveMaster> SelectByID(LeaveMaster item)
        {
            IBaseEntityResponse<LeaveMaster> entityResponse = new BaseEntityResponse<LeaveMaster>();
            try
            {
                entityResponse = _leaveMasterDataProvider.GetLeaveMasterByID(item);
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
        /// Select all record from LeaveMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveMaster> GetBySearchList(LeaveMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveMaster> LeaveMasterCollection = new BaseEntityCollectionResponse<LeaveMaster>();
            try
            {
                if (_leaveMasterDataProvider != null)
                    LeaveMasterCollection = _leaveMasterDataProvider.GetBySearchList(searchRequest);
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
                LeaveMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveMasterCollection;
        }
        
    }
}
