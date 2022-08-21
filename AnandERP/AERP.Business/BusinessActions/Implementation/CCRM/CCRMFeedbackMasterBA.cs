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
  public  class CCRMFeedbackMasterBA : ICCRMFeedbackMasterBA
    {
        ICCRMFeedbackMasterDataProvider _CCRMFeedbackMasterDataProvider;
        ICCRMFeedbackMasterBR _CCRMFeedbackMasterBR;
        private ILogger _logException;

        public CCRMFeedbackMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMFeedbackMasterBR = new CCRMFeedbackMasterBR();
            _CCRMFeedbackMasterDataProvider = new CCRMFeedbackMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMFeedbackMaster> InsertCCRMFeedbackMaster(CCRMFeedbackMaster item)
        {
            IBaseEntityResponse<CCRMFeedbackMaster> entityResponse = new BaseEntityResponse<CCRMFeedbackMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMFeedbackMasterBR.InsertCCRMFeedbackMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMFeedbackMasterDataProvider.InsertCCRMFeedbackMaster(item);
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
        public IBaseEntityResponse<CCRMFeedbackMaster> UpdateCCRMFeedbackMaster(CCRMFeedbackMaster item)
        {
            IBaseEntityResponse<CCRMFeedbackMaster> entityResponse = new BaseEntityResponse<CCRMFeedbackMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMFeedbackMasterBR.UpdateCCRMFeedbackMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMFeedbackMasterDataProvider.UpdateCCRMFeedbackMaster(item);
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
        public IBaseEntityResponse<CCRMFeedbackMaster> DeleteCCRMFeedbackMaster(CCRMFeedbackMaster item)
        {
            IBaseEntityResponse<CCRMFeedbackMaster> entityResponse = new BaseEntityResponse<CCRMFeedbackMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMFeedbackMasterBR.DeleteCCRMFeedbackMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMFeedbackMasterDataProvider.DeleteCCRMFeedbackMaster(item);
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
        public IBaseEntityResponse<CCRMFeedbackMaster> SelectByID(CCRMFeedbackMaster item)
        {

            IBaseEntityResponse<CCRMFeedbackMaster> entityResponse = new BaseEntityResponse<CCRMFeedbackMaster>();
            try
            {
                entityResponse = _CCRMFeedbackMasterDataProvider.GetCCRMFeedbackMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMFeedbackMaster> GetBySearch(CCRMFeedbackMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMFeedbackMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMFeedbackMaster>();
            try
            {
                if (_CCRMFeedbackMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMFeedbackMasterDataProvider.GetCCRMFeedbackMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMFeedbackMaster> GetCCRMFeedbackMasterList(CCRMFeedbackMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMFeedbackMaster> CCRMFeedbackMasterCollection = new BaseEntityCollectionResponse<CCRMFeedbackMaster>();
            try
            {
                if (_CCRMFeedbackMasterDataProvider != null)
                {
                    CCRMFeedbackMasterCollection = _CCRMFeedbackMasterDataProvider.GetCCRMFeedbackMasterList(searchRequest);
                }
                else
                {
                    CCRMFeedbackMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMFeedbackMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMFeedbackMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMFeedbackMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMFeedbackMasterCollection;
        }
    }
}
