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
    public class GeneralEducationMasterBA : IGeneralEducationMasterBA
    {
        IGeneralEducationMasterDataProvider _generalEducationMasterDataProvider;
        IGeneralEducationMasterBR _generalEducationMasterBR;
        private ILogger _logException;

        public GeneralEducationMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalEducationMasterBR = new GeneralEducationMasterBR();
            _generalEducationMasterDataProvider = new GeneralEducationMasterDataProvider();
        }

        public IBaseEntityResponse<GeneralEducationMaster> InsertGeneralEducationMaster(GeneralEducationMaster item)
        {
            IBaseEntityResponse<GeneralEducationMaster> entityResponse = new BaseEntityResponse<GeneralEducationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalEducationMasterBR.InsertGeneralEducationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalEducationMasterDataProvider.InsertGeneralEducationMaster(item);
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

        public IBaseEntityResponse<GeneralEducationMaster> UpdateGeneralEducationMaster(GeneralEducationMaster item)
        {
            IBaseEntityResponse<GeneralEducationMaster> entityResponse = new BaseEntityResponse<GeneralEducationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalEducationMasterBR.UpdateGeneralEducationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalEducationMasterDataProvider.UpdateGeneralEducationMaster(item);
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

        public IBaseEntityResponse<GeneralEducationMaster> DeleteGeneralEducationMaster(GeneralEducationMaster item)
        {
            IBaseEntityResponse<GeneralEducationMaster> entityResponse = new BaseEntityResponse<GeneralEducationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalEducationMasterBR.DeleteGeneralEducationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalEducationMasterDataProvider.DeleteGeneralEducationMaster(item);
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

        public IBaseEntityCollectionResponse<GeneralEducationMaster> GetBySearch(GeneralEducationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralEducationMaster> GeneralEducationMasterCollection = new BaseEntityCollectionResponse<GeneralEducationMaster>();
            try
            {
                if (_generalEducationMasterDataProvider != null)
                {
                    GeneralEducationMasterCollection = _generalEducationMasterDataProvider.GetGeneralEducationMasterBySearch(searchRequest);
                }
                else
                {
                    GeneralEducationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralEducationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralEducationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                GeneralEducationMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralEducationMasterCollection;
        }

        public IBaseEntityResponse<GeneralEducationMaster> SelectByID(GeneralEducationMaster item)
        {

            IBaseEntityResponse<GeneralEducationMaster> entityResponse = new BaseEntityResponse<GeneralEducationMaster>();
            try
            {
                entityResponse = _generalEducationMasterDataProvider.GetGeneralEducationMasterByID(item);
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

        public IBaseEntityCollectionResponse<GeneralEducationMaster> GetByEducationTypeID(GeneralEducationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralEducationMaster> GeneralEducationMasterCollection = new BaseEntityCollectionResponse<GeneralEducationMaster>();
            try
            {
                if (_generalEducationMasterDataProvider != null)
                {
                    GeneralEducationMasterCollection = _generalEducationMasterDataProvider.GetByEducationTypeID(searchRequest);
                }
                else
                {
                    GeneralEducationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralEducationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralEducationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                GeneralEducationMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralEducationMasterCollection;
        }
    }
}

