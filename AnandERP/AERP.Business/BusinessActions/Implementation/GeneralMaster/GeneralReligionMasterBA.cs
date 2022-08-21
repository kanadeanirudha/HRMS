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
    public class GeneralReligionMasterBA : IGeneralReligionMasterBA
    {
               IGeneralReligionMasterDataProvider __orgReligionMasterDataProvider;
        IGeneralReligionMasterBR __orgReligionMasterBR;
        private ILogger _logException;

        public GeneralReligionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            __orgReligionMasterBR = new GeneralReligionMasterBR();
            __orgReligionMasterDataProvider = new GeneralReligionMasterDataProvider();
        }

        public IBaseEntityResponse<GeneralReligionMaster> InsertGeneralReligionMaster(GeneralReligionMaster item)
        {
            IBaseEntityResponse<GeneralReligionMaster> entityResponse = new BaseEntityResponse<GeneralReligionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = __orgReligionMasterBR.InsertGeneralReligionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = __orgReligionMasterDataProvider.InsertGeneralReligionMaster(item);
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

        public IBaseEntityResponse<GeneralReligionMaster> UpdateGeneralReligionMaster(GeneralReligionMaster item)
        {
            IBaseEntityResponse<GeneralReligionMaster> entityResponse = new BaseEntityResponse<GeneralReligionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = __orgReligionMasterBR.UpdateGeneralReligionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = __orgReligionMasterDataProvider.UpdateGeneralReligionMaster(item);
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

        public IBaseEntityResponse<GeneralReligionMaster> DeleteGeneralReligionMaster(GeneralReligionMaster item)
        {
            IBaseEntityResponse<GeneralReligionMaster> entityResponse = new BaseEntityResponse<GeneralReligionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = __orgReligionMasterBR.DeleteGeneralReligionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = __orgReligionMasterDataProvider.DeleteGeneralReligionMaster(item);
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

        public IBaseEntityCollectionResponse<GeneralReligionMaster> GetBySearch(GeneralReligionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralReligionMaster> _orgReligionMasterCollection = new BaseEntityCollectionResponse<GeneralReligionMaster>();
            try
            {
                if (__orgReligionMasterDataProvider != null)
                {
                    _orgReligionMasterCollection = __orgReligionMasterDataProvider.GetGeneralReligionMasterBySearch(searchRequest);
                }
                else
                {
                    _orgReligionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    _orgReligionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                _orgReligionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                _orgReligionMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return _orgReligionMasterCollection;
        }



        public IBaseEntityResponse<GeneralReligionMaster> SelectByID(GeneralReligionMaster item)
        {

            IBaseEntityResponse<GeneralReligionMaster> entityResponse = new BaseEntityResponse<GeneralReligionMaster>();
            try
            {
                entityResponse = __orgReligionMasterDataProvider.GetGeneralReligionMasterByID(item);
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

        public IBaseEntityCollectionResponse<GeneralReligionMaster> GetBySearchList(GeneralReligionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralReligionMaster> GeneralReligionMasterCollection = new BaseEntityCollectionResponse<GeneralReligionMaster>();
            try
            {
                if (__orgReligionMasterDataProvider != null)
                {
                    GeneralReligionMasterCollection = __orgReligionMasterDataProvider.GetGeneralReligionMasterGetBySearchList(searchRequest);
                }
                else
                {
                    GeneralReligionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralReligionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralReligionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                GeneralReligionMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralReligionMasterCollection;
        }
    }
}
