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
    public class GeneralEducationTypeMasterBA :IGeneralEducationTypeMasterBA
    {

        IGeneralEducationTypeMasterDataProvider _generalEducationTypeMasterDataProvider;
        IGeneralEducationTypeMasterBR _generalEducationTypeMasterBR;
        private ILogger _logException;

        public GeneralEducationTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalEducationTypeMasterBR = new GeneralEducationTypeMasterBR();
            _generalEducationTypeMasterDataProvider = new GeneralEducationTypeMasterDataProvider();
        }

        public IBaseEntityResponse<GeneralEducationTypeMaster> InsertGeneralEducationTypeMaster(GeneralEducationTypeMaster item)
        {
            IBaseEntityResponse<GeneralEducationTypeMaster> entityResponse = new BaseEntityResponse<GeneralEducationTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalEducationTypeMasterBR.InsertGeneralEducationTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalEducationTypeMasterDataProvider.InsertGeneralEducationTypeMaster(item);
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

        public IBaseEntityResponse<GeneralEducationTypeMaster> UpdateGeneralEducationTypeMaster(GeneralEducationTypeMaster item)
        {
            IBaseEntityResponse<GeneralEducationTypeMaster> entityResponse = new BaseEntityResponse<GeneralEducationTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalEducationTypeMasterBR.UpdateGeneralEducationTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalEducationTypeMasterDataProvider.UpdateGeneralEducationTypeMaster(item);
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

        public IBaseEntityResponse<GeneralEducationTypeMaster> DeleteGeneralEducationTypeMaster(GeneralEducationTypeMaster item)
        {
            IBaseEntityResponse<GeneralEducationTypeMaster> entityResponse = new BaseEntityResponse<GeneralEducationTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalEducationTypeMasterBR.DeleteGeneralEducationTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalEducationTypeMasterDataProvider.DeleteGeneralEducationTypeMaster(item);
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

        public IBaseEntityCollectionResponse<GeneralEducationTypeMaster> GetBySearch(GeneralEducationTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralEducationTypeMaster> generalEducationTypeMaster = new BaseEntityCollectionResponse<GeneralEducationTypeMaster>();
            try
            {
                if (_generalEducationTypeMasterDataProvider != null)
                {
                    generalEducationTypeMaster = _generalEducationTypeMasterDataProvider.GetGeneralEducationTypeMasterBySearch(searchRequest);
                }
                else
                {
                    generalEducationTypeMaster.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    generalEducationTypeMaster.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                generalEducationTypeMaster.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                generalEducationTypeMaster.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return generalEducationTypeMaster;
        }



        public IBaseEntityCollectionResponse<GeneralEducationTypeMaster> GetBySearchList(GeneralEducationTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralEducationTypeMaster> generalEducationTypeMaster = new BaseEntityCollectionResponse<GeneralEducationTypeMaster>();
            try
            {
                if (_generalEducationTypeMasterDataProvider != null)
                {
                    generalEducationTypeMaster = _generalEducationTypeMasterDataProvider.GetGeneralEducationTypeMasterGetBySearchList(searchRequest);
                }
                else
                {
                    generalEducationTypeMaster.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    generalEducationTypeMaster.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                generalEducationTypeMaster.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                generalEducationTypeMaster.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return generalEducationTypeMaster;
        }



        public IBaseEntityResponse<GeneralEducationTypeMaster> SelectByID(GeneralEducationTypeMaster item)
        {

            IBaseEntityResponse<GeneralEducationTypeMaster> entityResponse = new BaseEntityResponse<GeneralEducationTypeMaster>();
            try
            {
                entityResponse = _generalEducationTypeMasterDataProvider.GetGeneralEducationTypeMasterByID(item);
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
