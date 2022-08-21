using AERP.Base.DTO;
using AERP.Business.BusinessRules;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public class GeneralExperienceTypeMasterBA : IGeneralExperienceTypeMasterBA
    {
        IGeneralExperienceTypeMasterDataProvider _generalExperienceTypeMasterDataProvider;
        IGeneralExperienceTypeMasterBR _generalExperienceTypeMasterBR;
        private ILogger _logException;
        public GeneralExperienceTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalExperienceTypeMasterBR = new GeneralExperienceTypeMasterBR();
            _generalExperienceTypeMasterDataProvider = new GeneralExperienceTypeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralExperienceTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralExperienceTypeMaster> InsertGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item)
        {
            IBaseEntityResponse<GeneralExperienceTypeMaster> entityResponse = new BaseEntityResponse<GeneralExperienceTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalExperienceTypeMasterBR.InsertGeneralExperienceTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalExperienceTypeMasterDataProvider.InsertGeneralExperienceTypeMaster(item);
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
        /// Update a specific record  of GeneralExperienceTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralExperienceTypeMaster> UpdateGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item)
        {
            IBaseEntityResponse<GeneralExperienceTypeMaster> entityResponse = new BaseEntityResponse<GeneralExperienceTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalExperienceTypeMasterBR.UpdateGeneralExperienceTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalExperienceTypeMasterDataProvider.UpdateGeneralExperienceTypeMaster(item);
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
        /// Delete a selected record from GeneralExperienceTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralExperienceTypeMaster> DeleteGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item)
        {
            IBaseEntityResponse<GeneralExperienceTypeMaster> entityResponse = new BaseEntityResponse<GeneralExperienceTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalExperienceTypeMasterBR.DeleteGeneralExperienceTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalExperienceTypeMasterDataProvider.DeleteGeneralExperienceTypeMaster(item);
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
        /// Select all record from GeneralExperienceTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetBySearch(GeneralExperienceTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GeneralExperienceTypeMasterCollection = new BaseEntityCollectionResponse<GeneralExperienceTypeMaster>();
            try
            {
                if (_generalExperienceTypeMasterDataProvider != null)
                    GeneralExperienceTypeMasterCollection = _generalExperienceTypeMasterDataProvider.GetGeneralExperienceTypeMasterBySearch(searchRequest);
                else
                {
                    GeneralExperienceTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralExperienceTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralExperienceTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralExperienceTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralExperienceTypeMasterCollection;
        }

        /// <summary>
        /// Select all record from GeneralExperienceTypeMaster table with search parameters for dropdown.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetBySearchList(GeneralExperienceTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GeneralExperienceTypeMasterCollection = new BaseEntityCollectionResponse<GeneralExperienceTypeMaster>();
            try
            {
                if (_generalExperienceTypeMasterDataProvider != null)
                    GeneralExperienceTypeMasterCollection = _generalExperienceTypeMasterDataProvider.GetGeneralExperienceTypeMasterBySearchList(searchRequest);
                else
                {
                    GeneralExperienceTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralExperienceTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralExperienceTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralExperienceTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralExperienceTypeMasterCollection;
        }

        /// <summary>
        /// Select a record from GeneralExperienceTypeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralExperienceTypeMaster> SelectByID(GeneralExperienceTypeMaster item)
        {
            IBaseEntityResponse<GeneralExperienceTypeMaster> entityResponse = new BaseEntityResponse<GeneralExperienceTypeMaster>();
            try
            {
                entityResponse = _generalExperienceTypeMasterDataProvider.GetGeneralExperienceTypeMasterByID(item);
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
