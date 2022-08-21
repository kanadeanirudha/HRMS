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
    public class CCRMSymptomMasterBA : ICCRMSymptomMasterBA
    {
        ICCRMSymptomMasterDataProvider _CCRMSymptomMasterDataProvider;
        ICCRMSymptomMasterBR _CCRMSymptomMasterBR;
        private ILogger _logException;
        public CCRMSymptomMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CCRMSymptomMasterBR = new CCRMSymptomMasterBR();
            _CCRMSymptomMasterDataProvider = new CCRMSymptomMasterDataProvider();
        }
        /// <summary>
        /// Create new record of CCRMEngineersGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CCRMSymptomMaster> InsertCCRMSymptomMaster(CCRMSymptomMaster item)
        {
            IBaseEntityResponse<CCRMSymptomMaster> entityResponse = new BaseEntityResponse<CCRMSymptomMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMSymptomMasterBR.InsertCCRMSymptomMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMSymptomMasterDataProvider.InsertCCRMSymptomMaster(item);
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
        public IBaseEntityResponse<CCRMSymptomMaster> InsertCCRMSymptomType(CCRMSymptomMaster item)
        {
            IBaseEntityResponse<CCRMSymptomMaster> entityResponse = new BaseEntityResponse<CCRMSymptomMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMSymptomMasterBR.InsertCCRMSymptomMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMSymptomMasterDataProvider.InsertCCRMSymptomType(item);
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
        public IBaseEntityResponse<CCRMSymptomMaster> UpdateCCRMSymptomType(CCRMSymptomMaster item)
        {
            IBaseEntityResponse<CCRMSymptomMaster> entityResponse = new BaseEntityResponse<CCRMSymptomMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMSymptomMasterBR.UpdateCCRMSymptomTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMSymptomMasterDataProvider.UpdateCCRMSymptomType(item);
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
        public IBaseEntityResponse<CCRMSymptomMaster> DeleteCCRMSymptomMaster(CCRMSymptomMaster item)
        {
            IBaseEntityResponse<CCRMSymptomMaster> entityResponse = new BaseEntityResponse<CCRMSymptomMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMSymptomMasterBR.DeleteCCRMSymptomMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMSymptomMasterDataProvider.DeleteCCRMSymptomMaster(item);
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
        public IBaseEntityCollectionResponse<CCRMSymptomMaster> GetBySearch(CCRMSymptomMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMSymptomMaster> CCRMSymptomMasterCollection = new BaseEntityCollectionResponse<CCRMSymptomMaster>();
            try
            {
                if (_CCRMSymptomMasterDataProvider != null)
                    CCRMSymptomMasterCollection = _CCRMSymptomMasterDataProvider.GetCCRMSymptomMasterBySearch(searchRequest);
                else
                {
                    CCRMSymptomMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMSymptomMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMSymptomMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMSymptomMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMSymptomMasterCollection;
        }

        public IBaseEntityCollectionResponse<CCRMSymptomMaster> GetCCRMSymptomMasterSearchList(CCRMSymptomMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMSymptomMaster> CCRMSymptomMasterCollection = new BaseEntityCollectionResponse<CCRMSymptomMaster>();
            try
            {
                if (_CCRMSymptomMasterDataProvider != null)
                    CCRMSymptomMasterCollection = _CCRMSymptomMasterDataProvider.GetCCRMSymptomMasterSearchList(searchRequest);
                else
                {
                    CCRMSymptomMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMSymptomMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMSymptomMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMSymptomMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMSymptomMasterCollection;
        }
        /// <summary>
        /// Select a record from CCRMEngineersGroupMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CCRMSymptomMaster> SelectByID(CCRMSymptomMaster item)
        {
            IBaseEntityResponse<CCRMSymptomMaster> entityResponse = new BaseEntityResponse<CCRMSymptomMaster>();
            try
            {
                entityResponse = _CCRMSymptomMasterDataProvider.GetCCRMSymptomTypeByID(item);
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

        public IBaseEntityCollectionResponse<CCRMSymptomMaster> GetDropDownListforCCRMSymptomMaster(CCRMSymptomMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMSymptomMaster> CCRMSymptomMasterCollection = new BaseEntityCollectionResponse<CCRMSymptomMaster>();
            try
            {
                if (_CCRMSymptomMasterDataProvider != null)
                    CCRMSymptomMasterCollection = _CCRMSymptomMasterDataProvider.GetDropDownListforCCRMSymptomMaster(searchRequest);
                else
                {
                    CCRMSymptomMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMSymptomMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMSymptomMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMSymptomMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMSymptomMasterCollection;
        }
    }
}
