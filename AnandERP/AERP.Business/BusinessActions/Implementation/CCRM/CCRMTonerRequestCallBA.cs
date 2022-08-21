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
   public class CCRMTonerRequestCallBA :ICCRMTonerRequestCallBA
    {
        ICCRMTonerRequestCallDataProvider _CCRMTonerRequestCallDataProvider;
        ICCRMTonerRequestCallBR _CCRMTonerRequestCallBR;
        private ILogger _logException;

        public CCRMTonerRequestCallBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMTonerRequestCallBR = new CCRMTonerRequestCallBR();
            _CCRMTonerRequestCallDataProvider = new CCRMTonerRequestCallDataProvider();
        }
        public IBaseEntityResponse<CCRMTonerRequestCall> InsertCCRMTonerRequestCall(CCRMTonerRequestCall item)
        {
            IBaseEntityResponse<CCRMTonerRequestCall> entityResponse = new BaseEntityResponse<CCRMTonerRequestCall>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMTonerRequestCallBR.InsertCCRMTonerRequestCallValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMTonerRequestCallDataProvider.InsertCCRMTonerRequestCall(item);
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
        public IBaseEntityResponse<CCRMTonerRequestCall> SelectByID(CCRMTonerRequestCall item)
        {

            IBaseEntityResponse<CCRMTonerRequestCall> entityResponse = new BaseEntityResponse<CCRMTonerRequestCall>();
            try
            {
                entityResponse = _CCRMTonerRequestCallDataProvider.GetCCRMTonerRequestCallByID(item);
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
        public IBaseEntityCollectionResponse<CCRMTonerRequestCall> GetBySearch(CCRMTonerRequestCallSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMTonerRequestCall> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMTonerRequestCall>();
            try
            {
                if (_CCRMTonerRequestCallDataProvider != null)
                {
                    categoryMasterCollection = _CCRMTonerRequestCallDataProvider.GetCCRMTonerRequestCallBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMTonerRequestCall> GetLastCallByModelNo(CCRMTonerRequestCallSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMTonerRequestCall> CCRMTonerRequestCallCollection = new BaseEntityCollectionResponse<CCRMTonerRequestCall>();
            try
            {
                if (_CCRMTonerRequestCallDataProvider != null)
                {
                    CCRMTonerRequestCallCollection = _CCRMTonerRequestCallDataProvider.GetLastCallByModelNo(searchRequest);
                }
                else
                {
                    CCRMTonerRequestCallCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMTonerRequestCallCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMTonerRequestCallCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMTonerRequestCallCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMTonerRequestCallCollection;
        }

    }
}
