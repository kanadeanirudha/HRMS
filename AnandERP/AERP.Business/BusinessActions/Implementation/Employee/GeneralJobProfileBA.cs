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
    public class GeneralJobProfileBA : IGeneralJobProfileBA
    {
        IGeneralJobProfileDataProvider _generalJobProfileDataProvider;
        IGeneralJobProfileBR _generalJobProfileBR;
        private ILogger _logException;
        public GeneralJobProfileBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalJobProfileBR = new GeneralJobProfileBR();
            _generalJobProfileDataProvider = new GeneralJobProfileDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralJobProfile.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobProfile> InsertGeneralJobProfile(GeneralJobProfile item)
        {
            IBaseEntityResponse<GeneralJobProfile> entityResponse = new BaseEntityResponse<GeneralJobProfile>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalJobProfileBR.InsertGeneralJobProfileValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalJobProfileDataProvider.InsertGeneralJobProfile(item);
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
        /// Update a specific record  of GeneralJobProfile.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobProfile> UpdateGeneralJobProfile(GeneralJobProfile item)
        {
            IBaseEntityResponse<GeneralJobProfile> entityResponse = new BaseEntityResponse<GeneralJobProfile>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalJobProfileBR.UpdateGeneralJobProfileValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalJobProfileDataProvider.UpdateGeneralJobProfile(item);
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
        /// Delete a selected record from GeneralJobProfile.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobProfile> DeleteGeneralJobProfile(GeneralJobProfile item)
        {
            IBaseEntityResponse<GeneralJobProfile> entityResponse = new BaseEntityResponse<GeneralJobProfile>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalJobProfileBR.DeleteGeneralJobProfileValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalJobProfileDataProvider.DeleteGeneralJobProfile(item);
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
        /// Select all record from GeneralJobProfile table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralJobProfile> GetBySearch(GeneralJobProfileSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralJobProfile> GeneralJobProfileCollection = new BaseEntityCollectionResponse<GeneralJobProfile>();
            try
            {
                if (_generalJobProfileDataProvider != null)
                    GeneralJobProfileCollection = _generalJobProfileDataProvider.GetGeneralJobProfileBySearch(searchRequest);
                else
                {
                    GeneralJobProfileCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralJobProfileCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralJobProfileCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralJobProfileCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralJobProfileCollection;
        }
        /// <summary>
        /// Select a record from GeneralJobProfile table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobProfile> SelectByID(GeneralJobProfile item)
        {
            IBaseEntityResponse<GeneralJobProfile> entityResponse = new BaseEntityResponse<GeneralJobProfile>();
            try
            {
                entityResponse = _generalJobProfileDataProvider.GetGeneralJobProfileByID(item);
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
        /// Select record from GeneralJobProfile table with for dropdown.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralJobProfile> GetBySearchList(GeneralJobProfileSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralJobProfile> GeneralJobProfileCollection = new BaseEntityCollectionResponse<GeneralJobProfile>();
            try
            {
                if (_generalJobProfileDataProvider != null)
                    GeneralJobProfileCollection = _generalJobProfileDataProvider.GetGeneralJobProfileGetBySearchList(searchRequest);
                else
                {
                    GeneralJobProfileCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralJobProfileCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralJobProfileCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralJobProfileCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralJobProfileCollection;
        }
    }
}
