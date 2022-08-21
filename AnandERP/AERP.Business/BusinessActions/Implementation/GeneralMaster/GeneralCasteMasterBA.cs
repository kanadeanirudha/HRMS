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
using AMS.Business.BusinessActions;
namespace AMS.Business.BusinessAction
{
    public class GeneralCasteMasterBA : IGeneralCasteMasterBA
    {
        IGeneralCasteMasterDataProvider _generalCasteMasterDataProvider;
        IGeneralCasteMasterBR _generalCasteMasterBR;
        private ILogger _logException;

        public GeneralCasteMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalCasteMasterBR = new GeneralCasteMasterBR();
            _generalCasteMasterDataProvider = new GeneralCasteMasterDataProvider();
        }

        public IBaseEntityResponse<GeneralCasteMaster> InsertGeneralCasteMaster(GeneralCasteMaster item)
        {
            IBaseEntityResponse<GeneralCasteMaster> entityResponse = new BaseEntityResponse<GeneralCasteMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalCasteMasterBR.InsertGeneralCasteMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalCasteMasterDataProvider.InsertGeneralCasteMaster(item);
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

        //Caste

        public IBaseEntityCollectionResponse<GeneralCasteMaster> GetGeneralCasteMasterGetBySearchList(GeneralCasteMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCasteMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCasteMaster>();
            try
            {
                if (_generalCasteMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalCasteMasterDataProvider.GetGeneralCasteMasterGetBySearchList(searchRequest);
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


        public IBaseEntityResponse<GeneralCasteMaster> UpdateGeneralCasteMaster(GeneralCasteMaster item)
        {
            IBaseEntityResponse<GeneralCasteMaster> entityResponse = new BaseEntityResponse<GeneralCasteMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalCasteMasterBR.UpdateGeneralCasteMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalCasteMasterDataProvider.UpdateGeneralCasteMaster(item);
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

        public IBaseEntityResponse<GeneralCasteMaster> DeleteGeneralCasteMaster(GeneralCasteMaster item)
        {
            IBaseEntityResponse<GeneralCasteMaster> entityResponse = new BaseEntityResponse<GeneralCasteMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalCasteMasterBR.DeleteGeneralCasteMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalCasteMasterDataProvider.DeleteGeneralCasteMaster(item);
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

        public IBaseEntityCollectionResponse<GeneralCasteMaster> GetBySearch(GeneralCasteMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCasteMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCasteMaster>();
            try
            {
                if (_generalCasteMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalCasteMasterDataProvider.GetGeneralCasteMasterBySearch(searchRequest);
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



        public IBaseEntityResponse<GeneralCasteMaster> SelectByID(GeneralCasteMaster item)
        {

            IBaseEntityResponse<GeneralCasteMaster> entityResponse = new BaseEntityResponse<GeneralCasteMaster>();
            try
            {
                entityResponse = _generalCasteMasterDataProvider.GetGeneralCasteMasterByID(item);
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
