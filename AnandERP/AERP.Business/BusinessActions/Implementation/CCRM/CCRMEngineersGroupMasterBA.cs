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
    public class CCRMEngineersGroupMasterBA : ICCRMEngineersGroupMasterBA
    {
        ICCRMEngineersGroupMasterDataProvider _CCRMEngineersGroupMasterDataProvider;
        ICCRMEngineersGroupMasterBR _CCRMEngineersGroupMasterBR;
        private ILogger _logException;
        public CCRMEngineersGroupMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CCRMEngineersGroupMasterBR = new CCRMEngineersGroupMasterBR();
            _CCRMEngineersGroupMasterDataProvider = new CCRMEngineersGroupMasterDataProvider();
        }
        /// <summary>
        /// Create new record of CCRMEngineersGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CCRMEngineersGroupMaster> InsertCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item)
        {
            IBaseEntityResponse<CCRMEngineersGroupMaster> entityResponse = new BaseEntityResponse<CCRMEngineersGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMEngineersGroupMasterBR.InsertCCRMEngineersGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMEngineersGroupMasterDataProvider.InsertCCRMEngineersGroupMaster(item);
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
        public IBaseEntityResponse<CCRMEngineersGroupMaster> InsertCCRMEngineersGroupDetails(CCRMEngineersGroupMaster item)
        {
            IBaseEntityResponse<CCRMEngineersGroupMaster> entityResponse = new BaseEntityResponse<CCRMEngineersGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMEngineersGroupMasterBR.InsertCCRMEngineersGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMEngineersGroupMasterDataProvider.InsertCCRMEngineersGroupDetails(item);
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
        /// Update a specific record  of CCRMEngineersGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CCRMEngineersGroupMaster> UpdateCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item)
        {
            IBaseEntityResponse<CCRMEngineersGroupMaster> entityResponse = new BaseEntityResponse<CCRMEngineersGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMEngineersGroupMasterBR.UpdateCCRMEngineersGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMEngineersGroupMasterDataProvider.UpdateCCRMEngineersGroupMaster(item);
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
        /// Delete a selected record from CCRMEngineersGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CCRMEngineersGroupMaster> DeleteCCRMEngineersGroupMaster(CCRMEngineersGroupMaster item)
        {
            IBaseEntityResponse<CCRMEngineersGroupMaster> entityResponse = new BaseEntityResponse<CCRMEngineersGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMEngineersGroupMasterBR.DeleteCCRMEngineersGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMEngineersGroupMasterDataProvider.DeleteCCRMEngineersGroupMaster(item);
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
        /// Select all record from CCRMEngineersGroupMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetBySearch(CCRMEngineersGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> CCRMEngineersGroupMasterCollection = new BaseEntityCollectionResponse<CCRMEngineersGroupMaster>();
            try
            {
                if (_CCRMEngineersGroupMasterDataProvider != null)
                    CCRMEngineersGroupMasterCollection = _CCRMEngineersGroupMasterDataProvider.GetCCRMEngineersGroupMasterBySearch(searchRequest);
                else
                {
                    CCRMEngineersGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMEngineersGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMEngineersGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMEngineersGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMEngineersGroupMasterCollection;
        }

        public IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMasterSearchList(CCRMEngineersGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> CCRMEngineersGroupMasterCollection = new BaseEntityCollectionResponse<CCRMEngineersGroupMaster>();
            try
            {
                if (_CCRMEngineersGroupMasterDataProvider != null)
                    CCRMEngineersGroupMasterCollection = _CCRMEngineersGroupMasterDataProvider.GetCCRMEngineersGroupMasterSearchList(searchRequest);
                else
                {
                    CCRMEngineersGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMEngineersGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMEngineersGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMEngineersGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMEngineersGroupMasterCollection;
        }
        /// <summary>
        /// Select a record from CCRMEngineersGroupMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CCRMEngineersGroupMaster> SelectByID(CCRMEngineersGroupMaster item)
        {
            IBaseEntityResponse<CCRMEngineersGroupMaster> entityResponse = new BaseEntityResponse<CCRMEngineersGroupMaster>();
            try
            {
                entityResponse = _CCRMEngineersGroupMasterDataProvider.GetCCRMEngineersGroupMasterByID(item);
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

        public IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetDropDownListforCCRMEngineersGroupMaster(CCRMEngineersGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> CCRMEngineersGroupMasterCollection = new BaseEntityCollectionResponse<CCRMEngineersGroupMaster>();
            try
            {
                if (_CCRMEngineersGroupMasterDataProvider != null)
                    CCRMEngineersGroupMasterCollection = _CCRMEngineersGroupMasterDataProvider.GetDropDownListforCCRMEngineersGroupMaster(searchRequest);
                else
                {
                    CCRMEngineersGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMEngineersGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMEngineersGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMEngineersGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMEngineersGroupMasterCollection;
        }
        public IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> GetCCRMEngineersGroupMasterList(CCRMEngineersGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMEngineersGroupMaster> CCRMEngineersGroupMasterCollection = new BaseEntityCollectionResponse<CCRMEngineersGroupMaster>();
            try
            {
                if (_CCRMEngineersGroupMasterDataProvider != null)
                {
                    CCRMEngineersGroupMasterCollection = _CCRMEngineersGroupMasterDataProvider.GetCCRMEngineersGroupMasterList(searchRequest);
                }
                else
                {
                    CCRMEngineersGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMEngineersGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMEngineersGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMEngineersGroupMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMEngineersGroupMasterCollection;
        }
    }
}
