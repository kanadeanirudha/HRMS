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
   public class CCRMServiceCallTypesBA : ICCRMServiceCallTypesBA
    {
        
            ICCRMServiceCallTypesDataProvider _CCRMServiceCallTypesDataProvider;
            ICCRMServiceCallTypesBR _CCRMServiceCallTypesBR;
            private ILogger _logException;

            public CCRMServiceCallTypesBA()
            {
                _logException = new ExceptionManager.ExceptionManager();
                _CCRMServiceCallTypesBR = new CCRMServiceCallTypesBR();
                _CCRMServiceCallTypesDataProvider = new CCRMServiceCallTypesDataProvider();
            }
            public IBaseEntityResponse<CCRMServiceCallTypes> InsertCCRMServiceCallTypes(CCRMServiceCallTypes item)
            {
                IBaseEntityResponse<CCRMServiceCallTypes> entityResponse = new BaseEntityResponse<CCRMServiceCallTypes>();
                try
                {
                    IValidateBusinessRuleResponse brResponse = _CCRMServiceCallTypesBR.InsertCCRMServiceCallTypesValidate(item);
                    if (brResponse.Passed)
                    {
                        entityResponse = _CCRMServiceCallTypesDataProvider.InsertCCRMServiceCallTypes(item);
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
        public IBaseEntityResponse<CCRMServiceCallTypes> UpdateCCRMServiceCallTypes(CCRMServiceCallTypes item)
        {
            IBaseEntityResponse<CCRMServiceCallTypes> entityResponse = new BaseEntityResponse<CCRMServiceCallTypes>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMServiceCallTypesBR.UpdateCCRMServiceCallTypesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMServiceCallTypesDataProvider.UpdateCCRMServiceCallTypes(item);
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
        public IBaseEntityResponse<CCRMServiceCallTypes> DeleteCCRMServiceCallTypes(CCRMServiceCallTypes item)
        {
            IBaseEntityResponse<CCRMServiceCallTypes> entityResponse = new BaseEntityResponse<CCRMServiceCallTypes>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMServiceCallTypesBR.DeleteCCRMServiceCallTypesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMServiceCallTypesDataProvider.DeleteCCRMServiceCallTypes(item);
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
        public IBaseEntityResponse<CCRMServiceCallTypes> SelectByID(CCRMServiceCallTypes item)
        {

            IBaseEntityResponse<CCRMServiceCallTypes> entityResponse = new BaseEntityResponse<CCRMServiceCallTypes>();
            try
            {
                entityResponse = _CCRMServiceCallTypesDataProvider.GetCCRMServiceCallTypesByID(item);
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
        public IBaseEntityCollectionResponse<CCRMServiceCallTypes> GetBySearch(CCRMServiceCallTypesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMServiceCallTypes> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMServiceCallTypes>();
            try
            {
                if (_CCRMServiceCallTypesDataProvider != null)
                {
                    categoryMasterCollection = _CCRMServiceCallTypesDataProvider.GetCCRMServiceCallTypesBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMServiceCallTypes> GetCCRMServiceCallTypesList(CCRMServiceCallTypesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMServiceCallTypes> CCRMServiceCallTypesCollection = new BaseEntityCollectionResponse<CCRMServiceCallTypes>();
            try
            {
                if (_CCRMServiceCallTypesDataProvider != null)
                {
                    CCRMServiceCallTypesCollection = _CCRMServiceCallTypesDataProvider.GetCCRMServiceCallTypesList(searchRequest);
                }
                else
                {
                    CCRMServiceCallTypesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMServiceCallTypesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMServiceCallTypesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMServiceCallTypesCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMServiceCallTypesCollection;
        }
    }
}
