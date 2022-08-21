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
  public  class CCRMLocationTypeMasterBA :ICCRMLocationTypeMasterBA
    {
        ICCRMLocationTypeMasterDataProvider _CCRMLocationTypeMasterDataProvider;
        ICCRMLocationTypeMasterBR _CCRMLocationTypeMasterBR;
        private ILogger _logException;

        public CCRMLocationTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMLocationTypeMasterBR = new CCRMLocationTypeMasterBR();
            _CCRMLocationTypeMasterDataProvider = new CCRMLocationTypeMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMLocationTypeMaster> InsertCCRMLocationTypeMaster(CCRMLocationTypeMaster item)
        {
            IBaseEntityResponse<CCRMLocationTypeMaster> entityResponse = new BaseEntityResponse<CCRMLocationTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMLocationTypeMasterBR.InsertCCRMLocationTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMLocationTypeMasterDataProvider.InsertCCRMLocationTypeMaster(item);
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
        public IBaseEntityResponse<CCRMLocationTypeMaster> UpdateCCRMLocationTypeMaster(CCRMLocationTypeMaster item)
        {
            IBaseEntityResponse<CCRMLocationTypeMaster> entityResponse = new BaseEntityResponse<CCRMLocationTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMLocationTypeMasterBR.UpdateCCRMLocationTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMLocationTypeMasterDataProvider.UpdateCCRMLocationTypeMaster(item);
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
        public IBaseEntityResponse<CCRMLocationTypeMaster> DeleteCCRMLocationTypeMaster(CCRMLocationTypeMaster item)
        {
            IBaseEntityResponse<CCRMLocationTypeMaster> entityResponse = new BaseEntityResponse<CCRMLocationTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMLocationTypeMasterBR.DeleteCCRMLocationTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMLocationTypeMasterDataProvider.DeleteCCRMLocationTypeMaster(item);
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
        public IBaseEntityResponse<CCRMLocationTypeMaster> SelectByID(CCRMLocationTypeMaster item)
        {

            IBaseEntityResponse<CCRMLocationTypeMaster> entityResponse = new BaseEntityResponse<CCRMLocationTypeMaster>();
            try
            {
                entityResponse = _CCRMLocationTypeMasterDataProvider.GetCCRMLocationTypeMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMLocationTypeMaster> GetBySearch(CCRMLocationTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMLocationTypeMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMLocationTypeMaster>();
            try
            {
                if (_CCRMLocationTypeMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMLocationTypeMasterDataProvider.GetCCRMLocationTypeMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMLocationTypeMaster> GetCCRMLocationTypeMasterList(CCRMLocationTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMLocationTypeMaster> CCRMLocationTypeMasterCollection = new BaseEntityCollectionResponse<CCRMLocationTypeMaster>();
            try
            {
                if (_CCRMLocationTypeMasterDataProvider != null)
                {
                    CCRMLocationTypeMasterCollection = _CCRMLocationTypeMasterDataProvider.GetCCRMLocationTypeMasterList(searchRequest);
                }
                else
                {
                    CCRMLocationTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMLocationTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMLocationTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMLocationTypeMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMLocationTypeMasterCollection;
        }
    }
}
