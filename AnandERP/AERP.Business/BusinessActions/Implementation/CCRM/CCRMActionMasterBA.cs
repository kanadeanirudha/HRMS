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
   public class CCRMActionMasterBA :ICCRMActionMasterBA
    {
        ICCRMActionMasterDataProvider _CCRMActionMasterDataProvider;
        ICCRMActionMasterBR _CCRMActionMasterBR;
        private ILogger _logException;

        public CCRMActionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMActionMasterBR = new CCRMActionMasterBR();
            _CCRMActionMasterDataProvider = new CCRMActionMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMActionMaster> InsertCCRMActionMaster(CCRMActionMaster item)
        {
            IBaseEntityResponse<CCRMActionMaster> entityResponse = new BaseEntityResponse<CCRMActionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMActionMasterBR.InsertCCRMActionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMActionMasterDataProvider.InsertCCRMActionMaster(item);
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
        public IBaseEntityResponse<CCRMActionMaster> UpdateCCRMActionMaster(CCRMActionMaster item)
        {
            IBaseEntityResponse<CCRMActionMaster> entityResponse = new BaseEntityResponse<CCRMActionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMActionMasterBR.UpdateCCRMActionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMActionMasterDataProvider.UpdateCCRMActionMaster(item);
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
        public IBaseEntityResponse<CCRMActionMaster> DeleteCCRMActionMaster(CCRMActionMaster item)
        {
            IBaseEntityResponse<CCRMActionMaster> entityResponse = new BaseEntityResponse<CCRMActionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMActionMasterBR.DeleteCCRMActionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMActionMasterDataProvider.DeleteCCRMActionMaster(item);
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
        public IBaseEntityResponse<CCRMActionMaster> SelectByID(CCRMActionMaster item)
        {

            IBaseEntityResponse<CCRMActionMaster> entityResponse = new BaseEntityResponse<CCRMActionMaster>();
            try
            {
                entityResponse = _CCRMActionMasterDataProvider.GetCCRMActionMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMActionMaster> GetBySearch(CCRMActionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMActionMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMActionMaster>();
            try
            {
                if (_CCRMActionMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMActionMasterDataProvider.GetCCRMActionMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMActionMaster> GetCCRMActionMasterSearchList(CCRMActionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMActionMaster> CCRMActionMasterCollection = new BaseEntityCollectionResponse<CCRMActionMaster>();
            try
            {
                if (_CCRMActionMasterDataProvider != null)
                    CCRMActionMasterCollection = _CCRMActionMasterDataProvider.GetCCRMActionMasterSearchList(searchRequest);
                else
                {
                    CCRMActionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMActionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMActionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMActionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMActionMasterCollection;
        }
    }
}
