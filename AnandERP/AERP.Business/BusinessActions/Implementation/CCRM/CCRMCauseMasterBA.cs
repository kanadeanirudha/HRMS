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
   public class CCRMCauseMasterBA :ICCRMCauseMasterBA
    {
        ICCRMCauseMasterDataProvider _CCRMCauseMasterDataProvider;
        ICCRMCauseMasterBR _CCRMCauseMasterBR;
        private ILogger _logException;
        public CCRMCauseMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CCRMCauseMasterBR = new CCRMCauseMasterBR();
            _CCRMCauseMasterDataProvider = new CCRMCauseMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMCauseMaster> InsertCCRMCauseMaster(CCRMCauseMaster item)
        {
            IBaseEntityResponse<CCRMCauseMaster> entityResponse = new BaseEntityResponse<CCRMCauseMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCauseMasterBR.InsertCCRMCauseMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCauseMasterDataProvider.InsertCCRMCauseMaster(item);
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
        public IBaseEntityResponse<CCRMCauseMaster> InsertCCRMCauseType(CCRMCauseMaster item)
        {
            IBaseEntityResponse<CCRMCauseMaster> entityResponse = new BaseEntityResponse<CCRMCauseMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCauseMasterBR.InsertCCRMCauseMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCauseMasterDataProvider.InsertCCRMCauseType(item);
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
        public IBaseEntityResponse<CCRMCauseMaster> UpdateCCRMCauseType(CCRMCauseMaster item)
        {
            IBaseEntityResponse<CCRMCauseMaster> entityResponse = new BaseEntityResponse<CCRMCauseMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCauseMasterBR.UpdateCCRMCauseTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCauseMasterDataProvider.UpdateCCRMCauseType(item);
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
        public IBaseEntityResponse<CCRMCauseMaster> DeleteCCRMCauseMaster(CCRMCauseMaster item)
        {
            IBaseEntityResponse<CCRMCauseMaster> entityResponse = new BaseEntityResponse<CCRMCauseMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCauseMasterBR.DeleteCCRMCauseMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCauseMasterDataProvider.DeleteCCRMCauseMaster(item);
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
        public IBaseEntityCollectionResponse<CCRMCauseMaster> GetBySearch(CCRMCauseMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCauseMaster> CCRMCauseMasterCollection = new BaseEntityCollectionResponse<CCRMCauseMaster>();
            try
            {
                if (_CCRMCauseMasterDataProvider != null)
                    CCRMCauseMasterCollection = _CCRMCauseMasterDataProvider.GetCCRMCauseMasterBySearch(searchRequest);
                else
                {
                    CCRMCauseMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMCauseMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMCauseMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMCauseMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMCauseMasterCollection;
        }
        public IBaseEntityCollectionResponse<CCRMCauseMaster> GetCCRMCauseMasterSearchList(CCRMCauseMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCauseMaster> CCRMCauseMasterCollection = new BaseEntityCollectionResponse<CCRMCauseMaster>();
            try
            {
                if (_CCRMCauseMasterDataProvider != null)
                    CCRMCauseMasterCollection = _CCRMCauseMasterDataProvider.GetCCRMCauseMasterSearchList(searchRequest);
                else
                {
                    CCRMCauseMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMCauseMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMCauseMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMCauseMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMCauseMasterCollection;
        }
        public IBaseEntityResponse<CCRMCauseMaster> SelectByID(CCRMCauseMaster item)
        {
            IBaseEntityResponse<CCRMCauseMaster> entityResponse = new BaseEntityResponse<CCRMCauseMaster>();
            try
            {
                entityResponse = _CCRMCauseMasterDataProvider.GetCCRMCauseTypeByID(item);
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
        public IBaseEntityCollectionResponse<CCRMCauseMaster> GetDropDownListforCCRMCauseMaster(CCRMCauseMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCauseMaster> CCRMCauseMasterCollection = new BaseEntityCollectionResponse<CCRMCauseMaster>();
            try
            {
                if (_CCRMCauseMasterDataProvider != null)
                    CCRMCauseMasterCollection = _CCRMCauseMasterDataProvider.GetDropDownListforCCRMCauseMaster(searchRequest);
                else
                {
                    CCRMCauseMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMCauseMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMCauseMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMCauseMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMCauseMasterCollection;
        }
    }
}
