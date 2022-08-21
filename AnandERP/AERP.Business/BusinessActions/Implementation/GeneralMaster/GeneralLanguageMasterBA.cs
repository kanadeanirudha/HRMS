using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public class GeneralLanguageMasterBA : IGeneralLanguageMasterBA
    {
        IGeneralLanguageMasterDataProvider _languageMasterDataProvider;
        IGeneralLanguageMasterBR _languageMasterBR;
        private ILogger _logException;

        public GeneralLanguageMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _languageMasterBR = new GeneralLanguageMasterBR();
            _languageMasterDataProvider = new GeneralLanguageMasterDataProvider();
        }

        public IBaseEntityResponse<GeneralLanguageMaster> InsertGeneralLanguageMaster(GeneralLanguageMaster item)
        {
            IBaseEntityResponse<GeneralLanguageMaster> entityResponse = new BaseEntityResponse<GeneralLanguageMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _languageMasterBR.InsertGeneralLanguageMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _languageMasterDataProvider.InsertGeneralLanguageMaster(item);
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

        public IBaseEntityResponse<GeneralLanguageMaster> UpdateGeneralLanguageMaster(GeneralLanguageMaster item)
        {
            IBaseEntityResponse<GeneralLanguageMaster> entityResponse = new BaseEntityResponse<GeneralLanguageMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _languageMasterBR.UpdateGeneralLanguageMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _languageMasterDataProvider.UpdateGeneralLanguageMaster(item);
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

        public IBaseEntityResponse<GeneralLanguageMaster> DeleteGeneralLanguageMaster(GeneralLanguageMaster item)
        {
            IBaseEntityResponse<GeneralLanguageMaster> entityResponse = new BaseEntityResponse<GeneralLanguageMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _languageMasterBR.DeleteGeneralLanguageMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _languageMasterDataProvider.DeleteGeneralLanguageMaster(item);
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

        public IBaseEntityCollectionResponse<GeneralLanguageMaster> GetBySearch(GeneralLanguageMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLanguageMaster> languageMasterCollection = new BaseEntityCollectionResponse<GeneralLanguageMaster>();
            try
            {
                if (_languageMasterDataProvider != null)
                {
                    languageMasterCollection = _languageMasterDataProvider.GetGeneralLanguageMasterBySearch(searchRequest);
                }
                else
                {
                    languageMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    languageMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                languageMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                languageMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return languageMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralLanguageMaster> GetBySearchList(GeneralLanguageMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLanguageMaster> languageMasterCollection = new BaseEntityCollectionResponse<GeneralLanguageMaster>();
            try
            {
                if (_languageMasterDataProvider != null)
                {
                    languageMasterCollection = _languageMasterDataProvider.GetGeneralLanguageMasterGetBySearchList(searchRequest);
                }
                else
                {
                    languageMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    languageMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                languageMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                languageMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return languageMasterCollection;
        }

        public IBaseEntityResponse<GeneralLanguageMaster> SelectByID(GeneralLanguageMaster item)
        {

            IBaseEntityResponse<GeneralLanguageMaster> entityResponse = new BaseEntityResponse<GeneralLanguageMaster>();
            try
            {
                entityResponse = _languageMasterDataProvider.GetGeneralLanguageMasterByID(item);
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
    }
}
