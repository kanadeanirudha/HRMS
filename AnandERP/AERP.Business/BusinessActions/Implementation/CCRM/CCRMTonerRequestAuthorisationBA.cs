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
   public class CCRMTonerRequestAuthorisationBA:ICCRMTonerRequestAuthorisationBA
    {
        ICCRMTonerRequestAuthorisationDataProvider _CCRMTonerRequestAuthorisationDataProvider;
        ICCRMTonerRequestAuthorisationBR _CCRMTonerRequestAuthorisationBR;
        private ILogger _logException;

        public CCRMTonerRequestAuthorisationBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMTonerRequestAuthorisationBR = new CCRMTonerRequestAuthorisationBR();
            _CCRMTonerRequestAuthorisationDataProvider = new CCRMTonerRequestAuthorisationDataProvider();
        }
        public IBaseEntityResponse<CCRMTonerRequestAuthorisation> UpdateCCRMTonerRequestAuthorisation(CCRMTonerRequestAuthorisation item)
        {
            IBaseEntityResponse<CCRMTonerRequestAuthorisation> entityResponse = new BaseEntityResponse<CCRMTonerRequestAuthorisation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMTonerRequestAuthorisationBR.UpdateCCRMTonerRequestAuthorisationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMTonerRequestAuthorisationDataProvider.UpdateCCRMTonerRequestAuthorisation(item);
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
        public IBaseEntityResponse<CCRMTonerRequestAuthorisation> DeleteCCRMTonerRequestAuthorisation(CCRMTonerRequestAuthorisation item)
        {
            IBaseEntityResponse<CCRMTonerRequestAuthorisation> entityResponse = new BaseEntityResponse<CCRMTonerRequestAuthorisation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMTonerRequestAuthorisationBR.DeleteCCRMTonerRequestAuthorisationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMTonerRequestAuthorisationDataProvider.DeleteCCRMTonerRequestAuthorisation(item);
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
        public IBaseEntityResponse<CCRMTonerRequestAuthorisation> SelectByID(CCRMTonerRequestAuthorisation item)
        {

            IBaseEntityResponse<CCRMTonerRequestAuthorisation> entityResponse = new BaseEntityResponse<CCRMTonerRequestAuthorisation>();
            try
            {
                entityResponse = _CCRMTonerRequestAuthorisationDataProvider.GetCCRMTonerRequestAuthorisationByID(item);
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
        public IBaseEntityCollectionResponse<CCRMTonerRequestAuthorisation> GetBySearch(CCRMTonerRequestAuthorisationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMTonerRequestAuthorisation> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMTonerRequestAuthorisation>();
            try
            {
                if (_CCRMTonerRequestAuthorisationDataProvider != null)
                {
                    categoryMasterCollection = _CCRMTonerRequestAuthorisationDataProvider.GetCCRMTonerRequestAuthorisationBySearch(searchRequest);
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
