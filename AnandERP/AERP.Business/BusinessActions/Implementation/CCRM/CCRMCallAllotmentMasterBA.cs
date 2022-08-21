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
   public class CCRMCallAllotmentMasterBA :ICCRMCallAllotmentMasterBA
    {
        ICCRMCallAllotmentMasterDataProvider _CCRMCallAllotmentMasterDataProvider;
        ICCRMCallAllotmentMasterBR _CCRMCallAllotmentMasterBR;
        private ILogger _logException;

        public CCRMCallAllotmentMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMCallAllotmentMasterBR = new CCRMCallAllotmentMasterBR();
            _CCRMCallAllotmentMasterDataProvider = new CCRMCallAllotmentMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMCallAllotmentMaster> UpdateCCRMCallAllotmentMaster(CCRMCallAllotmentMaster item)
        {
            IBaseEntityResponse<CCRMCallAllotmentMaster> entityResponse = new BaseEntityResponse<CCRMCallAllotmentMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCallAllotmentMasterBR.UpdateCCRMCallAllotmentMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCallAllotmentMasterDataProvider.UpdateCCRMCallAllotmentMaster(item);
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
        public IBaseEntityResponse<CCRMCallAllotmentMaster> DeleteCCRMCallAllotmentMaster(CCRMCallAllotmentMaster item)
        {
            IBaseEntityResponse<CCRMCallAllotmentMaster> entityResponse = new BaseEntityResponse<CCRMCallAllotmentMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCallAllotmentMasterBR.DeleteCCRMCallAllotmentMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCallAllotmentMasterDataProvider.DeleteCCRMCallAllotmentMaster(item);
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
        public IBaseEntityResponse<CCRMCallAllotmentMaster> SelectByID(CCRMCallAllotmentMaster item)
        {

            IBaseEntityResponse<CCRMCallAllotmentMaster> entityResponse = new BaseEntityResponse<CCRMCallAllotmentMaster>();
            try
            {
                entityResponse = _CCRMCallAllotmentMasterDataProvider.GetCCRMCallAllotmentMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetBySearch(CCRMCallAllotmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMCallAllotmentMaster>();
            try
            {
                if (_CCRMCallAllotmentMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMCallAllotmentMasterDataProvider.GetCCRMCallAllotmentMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetListPendingCallByID(CCRMCallAllotmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> CCRMCallAllotmentMasterCollection = new BaseEntityCollectionResponse<CCRMCallAllotmentMaster>();
            try
            {
                if (_CCRMCallAllotmentMasterDataProvider != null)
                    CCRMCallAllotmentMasterCollection = _CCRMCallAllotmentMasterDataProvider.GetListPendingCallByID(searchRequest);
                else
                {
                    CCRMCallAllotmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMCallAllotmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMCallAllotmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMCallAllotmentMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMCallAllotmentMasterCollection;
        }
        public IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> GetCCRMCallAllotmentMasterList(CCRMCallAllotmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallAllotmentMaster> CCRMCallAllotmentMasterCollection = new BaseEntityCollectionResponse<CCRMCallAllotmentMaster>();
            try
            {
                if (_CCRMCallAllotmentMasterDataProvider != null)
                {
                    CCRMCallAllotmentMasterCollection = _CCRMCallAllotmentMasterDataProvider.GetCCRMCallAllotmentMasterList(searchRequest);
                }
                else
                {
                    CCRMCallAllotmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMCallAllotmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMCallAllotmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMCallAllotmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMCallAllotmentMasterCollection;
        }
    }
}
