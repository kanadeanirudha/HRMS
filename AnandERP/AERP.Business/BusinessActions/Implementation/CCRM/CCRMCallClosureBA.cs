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
   public class CCRMCallClosureBA :ICCRMCallClosureBA
    {
        ICCRMCallClosureDataProvider _CCRMCallClosureDataProvider;
        ICCRMCallClosureBR _CCRMCallClosureBR;
        private ILogger _logException;

        public CCRMCallClosureBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMCallClosureBR = new CCRMCallClosureBR();
            _CCRMCallClosureDataProvider = new CCRMCallClosureDataProvider();
        }
        public IBaseEntityResponse<CCRMCallClosure> UpdateCCRMCallClosure(CCRMCallClosure item)
        {
            IBaseEntityResponse<CCRMCallClosure> entityResponse = new BaseEntityResponse<CCRMCallClosure>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCallClosureBR.UpdateCCRMCallClosureValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCallClosureDataProvider.UpdateCCRMCallClosure(item);
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
        public IBaseEntityResponse<CCRMCallClosure> DeleteCCRMCallClosure(CCRMCallClosure item)
        {
            IBaseEntityResponse<CCRMCallClosure> entityResponse = new BaseEntityResponse<CCRMCallClosure>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCallClosureBR.DeleteCCRMCallClosureValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCallClosureDataProvider.DeleteCCRMCallClosure(item);
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
        public IBaseEntityResponse<CCRMCallClosure> SelectByID(CCRMCallClosure item)
        {

            IBaseEntityResponse<CCRMCallClosure> entityResponse = new BaseEntityResponse<CCRMCallClosure>();
            try
            {
                entityResponse = _CCRMCallClosureDataProvider.GetCCRMCallClosureByID(item);
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
        public IBaseEntityCollectionResponse<CCRMCallClosure> GetBySearch(CCRMCallClosureSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallClosure> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMCallClosure>();
            try
            {
                if (_CCRMCallClosureDataProvider != null)
                {
                    categoryMasterCollection = _CCRMCallClosureDataProvider.GetCCRMCallClosureBySearch(searchRequest);
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
