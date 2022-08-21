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
   public class CCRMBillTypeMasterBA : ICCRMBillTypeMasterBA
    {
        ICCRMBillTypeMasterDataProvider _CCRMBillTypeMasterDataProvider;
        ICCRMBillTypeMasterBR _CCRMBillTypeMasterBR;
        private ILogger _logException;

        public CCRMBillTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMBillTypeMasterBR = new CCRMBillTypeMasterBR();
            _CCRMBillTypeMasterDataProvider = new CCRMBillTypeMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMBillTypeMaster> InsertCCRMBillTypeMaster(CCRMBillTypeMaster item)
        {
            IBaseEntityResponse<CCRMBillTypeMaster> entityResponse = new BaseEntityResponse<CCRMBillTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBillTypeMasterBR.InsertCCRMBillTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBillTypeMasterDataProvider.InsertCCRMBillTypeMaster(item);
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
        public IBaseEntityResponse<CCRMBillTypeMaster> UpdateCCRMBillTypeMaster(CCRMBillTypeMaster item)
        {
            IBaseEntityResponse<CCRMBillTypeMaster> entityResponse = new BaseEntityResponse<CCRMBillTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBillTypeMasterBR.UpdateCCRMBillTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBillTypeMasterDataProvider.UpdateCCRMBillTypeMaster(item);
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
        public IBaseEntityResponse<CCRMBillTypeMaster> DeleteCCRMBillTypeMaster(CCRMBillTypeMaster item)
        {
            IBaseEntityResponse<CCRMBillTypeMaster> entityResponse = new BaseEntityResponse<CCRMBillTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBillTypeMasterBR.DeleteCCRMBillTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBillTypeMasterDataProvider.DeleteCCRMBillTypeMaster(item);
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
        public IBaseEntityResponse<CCRMBillTypeMaster> SelectByID(CCRMBillTypeMaster item)
        {

            IBaseEntityResponse<CCRMBillTypeMaster> entityResponse = new BaseEntityResponse<CCRMBillTypeMaster>();
            try
            {
                entityResponse = _CCRMBillTypeMasterDataProvider.GetCCRMBillTypeMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMBillTypeMaster> GetBySearch(CCRMBillTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMBillTypeMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMBillTypeMaster>();
            try
            {
                if (_CCRMBillTypeMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMBillTypeMasterDataProvider.GetCCRMBillTypeMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMBillTypeMaster> GetCCRMBillTypeMasterList(CCRMBillTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMBillTypeMaster> CCRMBillTypeMasterCollection = new BaseEntityCollectionResponse<CCRMBillTypeMaster>();
            try
            {
                if (_CCRMBillTypeMasterDataProvider != null)
                {
                    CCRMBillTypeMasterCollection = _CCRMBillTypeMasterDataProvider.GetCCRMBillTypeMasterList(searchRequest);
                }
                else
                {
                    CCRMBillTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMBillTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMBillTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMBillTypeMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMBillTypeMasterCollection;
        }
    }
}
