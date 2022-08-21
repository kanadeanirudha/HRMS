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
   public class CCRMServiceMasterBA :ICCRMServiceMasterBA
    {
        ICCRMServiceMasterDataProvider _CCRMServiceMasterDataProvider;
        ICCRMServiceMasterBR _CCRMServiceMasterBR;
        private ILogger _logException;

        public CCRMServiceMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMServiceMasterBR = new CCRMServiceMasterBR();
            _CCRMServiceMasterDataProvider = new CCRMServiceMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMServiceMaster> InsertCCRMServiceMaster(CCRMServiceMaster item)
        {
            IBaseEntityResponse<CCRMServiceMaster> entityResponse = new BaseEntityResponse<CCRMServiceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMServiceMasterBR.InsertCCRMServiceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMServiceMasterDataProvider.InsertCCRMServiceMaster(item);
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
        public IBaseEntityResponse<CCRMServiceMaster> UpdateCCRMServiceMaster(CCRMServiceMaster item)
        {
            IBaseEntityResponse<CCRMServiceMaster> entityResponse = new BaseEntityResponse<CCRMServiceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMServiceMasterBR.UpdateCCRMServiceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMServiceMasterDataProvider.UpdateCCRMServiceMaster(item);
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
        public IBaseEntityResponse<CCRMServiceMaster> DeleteCCRMServiceMaster(CCRMServiceMaster item)
        {
            IBaseEntityResponse<CCRMServiceMaster> entityResponse = new BaseEntityResponse<CCRMServiceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMServiceMasterBR.DeleteCCRMServiceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMServiceMasterDataProvider.DeleteCCRMServiceMaster(item);
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
        public IBaseEntityResponse<CCRMServiceMaster> SelectByID(CCRMServiceMaster item)
        {

            IBaseEntityResponse<CCRMServiceMaster> entityResponse = new BaseEntityResponse<CCRMServiceMaster>();
            try
            {
                entityResponse = _CCRMServiceMasterDataProvider.GetCCRMServiceMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMServiceMaster> GetBySearch(CCRMServiceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMServiceMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMServiceMaster>();
            try
            {
                if (_CCRMServiceMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMServiceMasterDataProvider.GetCCRMServiceMasterBySearch(searchRequest);
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
    }
}
