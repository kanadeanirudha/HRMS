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
   public class CCRMBrokenCallReasonMasterBA :ICCRMBrokenCallReasonMasterBA
    {
        ICCRMBrokenCallReasonMasterDataProvider _CCRMBrokenCallReasonMasterDataProvider;
        ICCRMBrokenCallReasonMasterBR _CCRMBrokenCallReasonMasterBR;
        private ILogger _logException;

        public CCRMBrokenCallReasonMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMBrokenCallReasonMasterBR = new CCRMBrokenCallReasonMasterBR();
            _CCRMBrokenCallReasonMasterDataProvider = new CCRMBrokenCallReasonMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMBrokenCallReasonMaster> InsertCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item)
        {
            IBaseEntityResponse<CCRMBrokenCallReasonMaster> entityResponse = new BaseEntityResponse<CCRMBrokenCallReasonMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBrokenCallReasonMasterBR.InsertCCRMBrokenCallReasonMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBrokenCallReasonMasterDataProvider.InsertCCRMBrokenCallReasonMaster(item);
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
        public IBaseEntityResponse<CCRMBrokenCallReasonMaster> UpdateCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item)
        {
            IBaseEntityResponse<CCRMBrokenCallReasonMaster> entityResponse = new BaseEntityResponse<CCRMBrokenCallReasonMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBrokenCallReasonMasterBR.UpdateCCRMBrokenCallReasonMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBrokenCallReasonMasterDataProvider.UpdateCCRMBrokenCallReasonMaster(item);
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
        public IBaseEntityResponse<CCRMBrokenCallReasonMaster> DeleteCCRMBrokenCallReasonMaster(CCRMBrokenCallReasonMaster item)
        {
            IBaseEntityResponse<CCRMBrokenCallReasonMaster> entityResponse = new BaseEntityResponse<CCRMBrokenCallReasonMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBrokenCallReasonMasterBR.DeleteCCRMBrokenCallReasonMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBrokenCallReasonMasterDataProvider.DeleteCCRMBrokenCallReasonMaster(item);
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
        public IBaseEntityResponse<CCRMBrokenCallReasonMaster> SelectByID(CCRMBrokenCallReasonMaster item)
        {

            IBaseEntityResponse<CCRMBrokenCallReasonMaster> entityResponse = new BaseEntityResponse<CCRMBrokenCallReasonMaster>();
            try
            {
                entityResponse = _CCRMBrokenCallReasonMasterDataProvider.GetCCRMBrokenCallReasonMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> GetBySearch(CCRMBrokenCallReasonMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMBrokenCallReasonMaster>();
            try
            {
                if (_CCRMBrokenCallReasonMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMBrokenCallReasonMasterDataProvider.GetCCRMBrokenCallReasonMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> GetCCRMBrokenCallReasonMasterList(CCRMBrokenCallReasonMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> CCRMBrokenCallReasonMasterCollection = new BaseEntityCollectionResponse<CCRMBrokenCallReasonMaster>();
            try
            {
                if (_CCRMBrokenCallReasonMasterDataProvider != null)
                {
                    CCRMBrokenCallReasonMasterCollection = _CCRMBrokenCallReasonMasterDataProvider.GetCCRMBrokenCallReasonMasterList(searchRequest);
                }
                else
                {
                    CCRMBrokenCallReasonMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMBrokenCallReasonMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMBrokenCallReasonMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMBrokenCallReasonMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMBrokenCallReasonMasterCollection;
        }
    }
}
