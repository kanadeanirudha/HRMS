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
   public class CCRMCustomerSegementBA:ICCRMCustomerSegementBA
    {
        ICCRMCustomerSegementDataProvider _CCRMCustomerSegementDataProvider;
        ICCRMCustomerSegementBR _CCRMCustomerSegementBR;
        private ILogger _logException;

        public CCRMCustomerSegementBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMCustomerSegementBR = new CCRMCustomerSegementBR();
            _CCRMCustomerSegementDataProvider = new CCRMCustomerSegementDataProvider();
        }
        public IBaseEntityResponse<CCRMCustomerSegement> InsertCCRMCustomerSegement(CCRMCustomerSegement item)
        {
            IBaseEntityResponse<CCRMCustomerSegement> entityResponse = new BaseEntityResponse<CCRMCustomerSegement>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCustomerSegementBR.InsertCCRMCustomerSegementValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCustomerSegementDataProvider.InsertCCRMCustomerSegement(item);
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
        public IBaseEntityResponse<CCRMCustomerSegement> UpdateCCRMCustomerSegement(CCRMCustomerSegement item)
        {
            IBaseEntityResponse<CCRMCustomerSegement> entityResponse = new BaseEntityResponse<CCRMCustomerSegement>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCustomerSegementBR.UpdateCCRMCustomerSegementValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCustomerSegementDataProvider.UpdateCCRMCustomerSegement(item);
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
        public IBaseEntityResponse<CCRMCustomerSegement> DeleteCCRMCustomerSegement(CCRMCustomerSegement item)
        {
            IBaseEntityResponse<CCRMCustomerSegement> entityResponse = new BaseEntityResponse<CCRMCustomerSegement>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCustomerSegementBR.DeleteCCRMCustomerSegementValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCustomerSegementDataProvider.DeleteCCRMCustomerSegement(item);
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
        public IBaseEntityResponse<CCRMCustomerSegement> SelectByID(CCRMCustomerSegement item)
        {

            IBaseEntityResponse<CCRMCustomerSegement> entityResponse = new BaseEntityResponse<CCRMCustomerSegement>();
            try
            {
                entityResponse = _CCRMCustomerSegementDataProvider.GetCCRMCustomerSegementByID(item);
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
        public IBaseEntityCollectionResponse<CCRMCustomerSegement> GetBySearch(CCRMCustomerSegementSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCustomerSegement> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMCustomerSegement>();
            try
            {
                if (_CCRMCustomerSegementDataProvider != null)
                {
                    categoryMasterCollection = _CCRMCustomerSegementDataProvider.GetCCRMCustomerSegementBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMCustomerSegement> GetCCRMCustomerSegementList(CCRMCustomerSegementSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCustomerSegement> CCRMCustomerSegementCollection = new BaseEntityCollectionResponse<CCRMCustomerSegement>();
            try
            {
                if (_CCRMCustomerSegementDataProvider != null)
                {
                    CCRMCustomerSegementCollection = _CCRMCustomerSegementDataProvider.GetCCRMCustomerSegementList(searchRequest);
                }
                else
                {
                    CCRMCustomerSegementCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMCustomerSegementCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMCustomerSegementCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMCustomerSegementCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMCustomerSegementCollection;
        }
    }
}
