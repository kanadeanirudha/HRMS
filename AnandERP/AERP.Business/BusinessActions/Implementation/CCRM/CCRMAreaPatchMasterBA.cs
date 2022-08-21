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
   public class CCRMAreaPatchMasterBA :ICCRMAreaPatchMasterBA
    {
        ICCRMAreaPatchMasterDataProvider _CCRMAreaPatchMasterDataProvider;
        ICCRMAreaPatchMasterBR _CCRMAreaPatchMasterBR;
        private ILogger _logException;

        public CCRMAreaPatchMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMAreaPatchMasterBR = new CCRMAreaPatchMasterBR();
            _CCRMAreaPatchMasterDataProvider = new CCRMAreaPatchMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMAreaPatchMaster> InsertCCRMAreaPatchMaster(CCRMAreaPatchMaster item)
        {
            IBaseEntityResponse<CCRMAreaPatchMaster> entityResponse = new BaseEntityResponse<CCRMAreaPatchMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMAreaPatchMasterBR.InsertCCRMAreaPatchMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMAreaPatchMasterDataProvider.InsertCCRMAreaPatchMaster(item);
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
        public IBaseEntityResponse<CCRMAreaPatchMaster> UpdateCCRMAreaPatchMaster(CCRMAreaPatchMaster item)
        {
            IBaseEntityResponse<CCRMAreaPatchMaster> entityResponse = new BaseEntityResponse<CCRMAreaPatchMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMAreaPatchMasterBR.UpdateCCRMAreaPatchMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMAreaPatchMasterDataProvider.UpdateCCRMAreaPatchMaster(item);
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
        public IBaseEntityResponse<CCRMAreaPatchMaster> DeleteCCRMAreaPatchMaster(CCRMAreaPatchMaster item)
        {
            IBaseEntityResponse<CCRMAreaPatchMaster> entityResponse = new BaseEntityResponse<CCRMAreaPatchMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMAreaPatchMasterBR.DeleteCCRMAreaPatchMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMAreaPatchMasterDataProvider.DeleteCCRMAreaPatchMaster(item);
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
        public IBaseEntityResponse<CCRMAreaPatchMaster> SelectByID(CCRMAreaPatchMaster item)
        {

            IBaseEntityResponse<CCRMAreaPatchMaster> entityResponse = new BaseEntityResponse<CCRMAreaPatchMaster>();
            try
            {
                entityResponse = _CCRMAreaPatchMasterDataProvider.GetCCRMAreaPatchMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMAreaPatchMaster> GetBySearch(CCRMAreaPatchMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMAreaPatchMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMAreaPatchMaster>();
            try
            {
                if (_CCRMAreaPatchMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMAreaPatchMasterDataProvider.GetCCRMAreaPatchMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMAreaPatchMaster> GetCCRMAreaPatchMasterSearchList(CCRMAreaPatchMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMAreaPatchMaster> CCRMAreaPatchMasterCollection = new BaseEntityCollectionResponse<CCRMAreaPatchMaster>();
            try
            {
                if (_CCRMAreaPatchMasterDataProvider != null)
                    CCRMAreaPatchMasterCollection = _CCRMAreaPatchMasterDataProvider.GetCCRMAreaPatchMasterSearchList(searchRequest);
                else
                {
                    CCRMAreaPatchMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMAreaPatchMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMAreaPatchMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMAreaPatchMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMAreaPatchMasterCollection;
        }
        public IBaseEntityCollectionResponse<CCRMAreaPatchMaster> GetCCRMAreaPatchMasterList(CCRMAreaPatchMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMAreaPatchMaster> CCRMAreaPatchMasterCollection = new BaseEntityCollectionResponse<CCRMAreaPatchMaster>();
            try
            {
                if (_CCRMAreaPatchMasterDataProvider != null)
                {
                    CCRMAreaPatchMasterCollection = _CCRMAreaPatchMasterDataProvider.GetCCRMAreaPatchMasterList(searchRequest);
                }
                else
                {
                    CCRMAreaPatchMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMAreaPatchMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMAreaPatchMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMAreaPatchMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMAreaPatchMasterCollection;
        }
    }
}
