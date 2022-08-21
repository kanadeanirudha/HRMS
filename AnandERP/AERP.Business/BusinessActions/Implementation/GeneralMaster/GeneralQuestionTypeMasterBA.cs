
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
    public class GeneralQuestionTypeMasterBA : IGeneralQuestionTypeMasterBA
    {
        IGeneralQuestionTypeMasterDataProvider _GeneralQuestionTypeMasterDataProvider;
        IGeneralQuestionTypeMasterBR _GeneralQuestionTypeMasterBR;
        private ILogger _logException;
        public GeneralQuestionTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralQuestionTypeMasterBR = new GeneralQuestionTypeMasterBR();
            _GeneralQuestionTypeMasterDataProvider = new GeneralQuestionTypeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralQuestionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralQuestionTypeMaster> InsertGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item)
        {
            IBaseEntityResponse<GeneralQuestionTypeMaster> entityResponse = new BaseEntityResponse<GeneralQuestionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralQuestionTypeMasterBR.InsertGeneralQuestionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralQuestionTypeMasterDataProvider.InsertGeneralQuestionTypeMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Update a specific record  of GeneralQuestionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralQuestionTypeMaster> UpdateGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item)
        {
            IBaseEntityResponse<GeneralQuestionTypeMaster> entityResponse = new BaseEntityResponse<GeneralQuestionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralQuestionTypeMasterBR.UpdateGeneralQuestionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralQuestionTypeMasterDataProvider.UpdateGeneralQuestionTypeMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Delete a selected record from GeneralQuestionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralQuestionTypeMaster> DeleteGeneralQuestionTypeMaster(GeneralQuestionTypeMaster item)
        {
            IBaseEntityResponse<GeneralQuestionTypeMaster> entityResponse = new BaseEntityResponse<GeneralQuestionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralQuestionTypeMasterBR.DeleteGeneralQuestionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralQuestionTypeMasterDataProvider.DeleteGeneralQuestionTypeMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Select all record from GeneralQuestionTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetBySearch(GeneralQuestionTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GeneralQuestionTypeMasterCollection = new BaseEntityCollectionResponse<GeneralQuestionTypeMaster>();
            try
            {
                if (_GeneralQuestionTypeMasterDataProvider != null)
                    GeneralQuestionTypeMasterCollection = _GeneralQuestionTypeMasterDataProvider.GetGeneralQuestionTypeMasterBySearch(searchRequest);
                else
                {
                    GeneralQuestionTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralQuestionTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralQuestionTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralQuestionTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralQuestionTypeMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GetGeneralQuestionTypeMasterSearchList(GeneralQuestionTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> GeneralQuestionTypeMasterCollection = new BaseEntityCollectionResponse<GeneralQuestionTypeMaster>();
            try
            {
                if (_GeneralQuestionTypeMasterDataProvider != null)
                    GeneralQuestionTypeMasterCollection = _GeneralQuestionTypeMasterDataProvider.GetGeneralQuestionTypeMasterSearchList(searchRequest);
                else
                {
                    GeneralQuestionTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralQuestionTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralQuestionTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralQuestionTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralQuestionTypeMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralQuestionTypeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralQuestionTypeMaster> SelectByID(GeneralQuestionTypeMaster item)
        {
            IBaseEntityResponse<GeneralQuestionTypeMaster> entityResponse = new BaseEntityResponse<GeneralQuestionTypeMaster>();
            try
            {
                entityResponse = _GeneralQuestionTypeMasterDataProvider.GetGeneralQuestionTypeMasterByID(item);
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
