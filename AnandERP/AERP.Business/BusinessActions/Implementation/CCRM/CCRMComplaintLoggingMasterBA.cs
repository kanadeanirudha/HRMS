using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.Business.BusinessRules;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;

namespace AERP.Business.BusinessAction
{
   public class CCRMComplaintLoggingMasterBA :ICCRMComplaintLoggingMasterBA
    {
        
        ICCRMComplaintLoggingMasterDataProvider _CCRMComplaintLoggingMasterDataProvider;
        ICCRMComplaintLoggingMasterBR _CCRMComplaintLoggingMasterBR;
        private ILogger _logException;

        public CCRMComplaintLoggingMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMComplaintLoggingMasterBR = new CCRMComplaintLoggingMasterBR();
            _CCRMComplaintLoggingMasterDataProvider = new CCRMComplaintLoggingMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> InsertCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityResponse<CCRMComplaintLoggingMaster> entityResponse = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMComplaintLoggingMasterBR.InsertCCRMComplaintLoggingMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMComplaintLoggingMasterDataProvider.InsertCCRMComplaintLoggingMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> UpdateCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityResponse<CCRMComplaintLoggingMaster> entityResponse = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMComplaintLoggingMasterBR.UpdateCCRMComplaintLoggingMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMComplaintLoggingMasterDataProvider.UpdateCCRMComplaintLoggingMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> DeleteCCRMComplaintLoggingMaster(CCRMComplaintLoggingMaster item)
        {
            IBaseEntityResponse<CCRMComplaintLoggingMaster> entityResponse = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMComplaintLoggingMasterBR.DeleteCCRMComplaintLoggingMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMComplaintLoggingMasterDataProvider.DeleteCCRMComplaintLoggingMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        public IBaseEntityResponse<CCRMComplaintLoggingMaster> SelectByID(CCRMComplaintLoggingMaster item)
        {

            IBaseEntityResponse<CCRMComplaintLoggingMaster> entityResponse = new BaseEntityResponse<CCRMComplaintLoggingMaster>();
            try
            {
                entityResponse = _CCRMComplaintLoggingMasterDataProvider.GetCCRMComplaintLoggingMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetBySearch(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_CCRMComplaintLoggingMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMComplaintLoggingMasterDataProvider.GetCCRMComplaintLoggingMasterBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetListOfPriviousCallByID(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> CCRMComplaintLoggingMasterCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_CCRMComplaintLoggingMasterDataProvider != null)
                    CCRMComplaintLoggingMasterCollection = _CCRMComplaintLoggingMasterDataProvider.GetListOfPriviousCallByID(searchRequest);
                else
                {
                    CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMComplaintLoggingMasterCollection;
        }
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMCallerSearchList(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> CCRMComplaintLoggingMasterCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_CCRMComplaintLoggingMasterDataProvider != null)
                    CCRMComplaintLoggingMasterCollection = _CCRMComplaintLoggingMasterDataProvider.GetCCRMCallerSearchList(searchRequest);
                else
                {
                    CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMComplaintLoggingMasterCollection;
        }
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggingMasterSearchList(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> CCRMComplaintLoggingMasterCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_CCRMComplaintLoggingMasterDataProvider != null)
                    CCRMComplaintLoggingMasterCollection = _CCRMComplaintLoggingMasterDataProvider.GetCCRMComplaintLoggingMasterSearchList(searchRequest);
                else
                {
                    CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMComplaintLoggingMasterCollection;
        }

        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetDeviceToken(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> CCRMComplaintLoggingMasterCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_CCRMComplaintLoggingMasterDataProvider != null)
                    CCRMComplaintLoggingMasterCollection = _CCRMComplaintLoggingMasterDataProvider.GetDeviceToken(searchRequest);
                else
                {
                    CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMComplaintLoggingMasterCollection;
        }
        public IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> GetCCRMComplaintLoggedByList(CCRMComplaintLoggingMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> CCRMComplaintLoggingMasterCollection = new BaseEntityCollectionResponse<CCRMComplaintLoggingMaster>();
            try
            {
                if (_CCRMComplaintLoggingMasterDataProvider != null)
                {
                    CCRMComplaintLoggingMasterCollection = _CCRMComplaintLoggingMasterDataProvider.GetCCRMComplaintLoggedByList(searchRequest);
                }
                else
                {
                    CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMComplaintLoggingMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMComplaintLoggingMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMComplaintLoggingMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMComplaintLoggingMasterCollection;
        }
    }
}
