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
      public class GeneralNationalityMasterBA :IGeneralNationalityMasterBA
    {
         IGeneralNationalityMasterDataProvider _GeneralNationalityMasterDataProvider;
        IGeneralNationalityMasterBR _GeneralNationalityMasterBR;
        private ILogger _logException;

        public GeneralNationalityMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralNationalityMasterBR = new GeneralNationalityMasterBR();
            _GeneralNationalityMasterDataProvider = new GeneralNationalityMasterDataProvider();
        }

        public IBaseEntityResponse<GeneralNationalityMaster> InsertGeneralNationalityMaster(GeneralNationalityMaster item)
        {
            IBaseEntityResponse<GeneralNationalityMaster> entityResponse = new BaseEntityResponse<GeneralNationalityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralNationalityMasterBR.InsertGeneralNationalityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralNationalityMasterDataProvider.InsertGeneralNationalityMaster(item);
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

        public IBaseEntityResponse<GeneralNationalityMaster> UpdateGeneralNationalityMaster(GeneralNationalityMaster item)
        {
            IBaseEntityResponse<GeneralNationalityMaster> entityResponse = new BaseEntityResponse<GeneralNationalityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralNationalityMasterBR.UpdateGeneralNationalityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralNationalityMasterDataProvider.UpdateGeneralNationalityMaster(item);
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

        public IBaseEntityResponse<GeneralNationalityMaster> DeleteGeneralNationalityMaster(GeneralNationalityMaster item)
        {
            IBaseEntityResponse<GeneralNationalityMaster> entityResponse = new BaseEntityResponse<GeneralNationalityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralNationalityMasterBR.DeleteGeneralNationalityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralNationalityMasterDataProvider.DeleteGeneralNationalityMaster(item);
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

        public IBaseEntityCollectionResponse<GeneralNationalityMaster> GetBySearch(GeneralNationalityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralNationalityMaster> GeneralNationalityMasterCollection = new BaseEntityCollectionResponse<GeneralNationalityMaster>();
            try
            {
                if (_GeneralNationalityMasterDataProvider != null)
                {
                    GeneralNationalityMasterCollection = _GeneralNationalityMasterDataProvider.GetGeneralNationalityMasterBySearch(searchRequest);
                }
                else
                {
                    GeneralNationalityMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralNationalityMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralNationalityMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                GeneralNationalityMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralNationalityMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralNationalityMaster> GetBySearchList(GeneralNationalityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralNationalityMaster> GeneralNationalityMasterCollection = new BaseEntityCollectionResponse<GeneralNationalityMaster>();
            try
            {
                if (_GeneralNationalityMasterDataProvider != null)
                {
                    GeneralNationalityMasterCollection = _GeneralNationalityMasterDataProvider.GetGeneralNationalityMasterGetBySearchList(searchRequest);
                }
                else
                {
                    GeneralNationalityMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralNationalityMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralNationalityMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                GeneralNationalityMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralNationalityMasterCollection;
        }

        public IBaseEntityResponse<GeneralNationalityMaster> SelectByID(GeneralNationalityMaster item)
        {

            IBaseEntityResponse<GeneralNationalityMaster> entityResponse = new BaseEntityResponse<GeneralNationalityMaster>();
            try
            {
                entityResponse = _GeneralNationalityMasterDataProvider.GetGeneralNationalityMasterByID(item);
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

