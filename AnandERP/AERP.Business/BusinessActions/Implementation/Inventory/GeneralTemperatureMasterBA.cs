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
    public class GeneralTemperatureMasterBA : IGeneralTemperatureMasterBA
    {
        IGeneralTemperatureMasterDataProvider _GeneralTemperatureMasterDataProvider;
        IGeneralTemperatureMasterBR _GeneralTemperatureMasterBR;
        private ILogger _logException;
        public GeneralTemperatureMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralTemperatureMasterBR = new GeneralTemperatureMasterBR();
            _GeneralTemperatureMasterDataProvider = new GeneralTemperatureMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralTemperatureMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTemperatureMaster> InsertGeneralTemperatureMaster(GeneralTemperatureMaster item)
        {
            IBaseEntityResponse<GeneralTemperatureMaster> entityResponse = new BaseEntityResponse<GeneralTemperatureMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTemperatureMasterBR.InsertGeneralTemperatureMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTemperatureMasterDataProvider.InsertGeneralTemperatureMaster(item);
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
        /// Update a specific record  of GeneralTemperatureMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTemperatureMaster> UpdateGeneralTemperatureMaster(GeneralTemperatureMaster item)
        {
            IBaseEntityResponse<GeneralTemperatureMaster> entityResponse = new BaseEntityResponse<GeneralTemperatureMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTemperatureMasterBR.UpdateGeneralTemperatureMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTemperatureMasterDataProvider.UpdateGeneralTemperatureMaster(item);
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
        /// Delete a selected record from GeneralTemperatureMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTemperatureMaster> DeleteGeneralTemperatureMaster(GeneralTemperatureMaster item)
        {
            IBaseEntityResponse<GeneralTemperatureMaster> entityResponse = new BaseEntityResponse<GeneralTemperatureMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTemperatureMasterBR.DeleteGeneralTemperatureMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTemperatureMasterDataProvider.DeleteGeneralTemperatureMaster(item);
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
        /// Select all record from GeneralTemperatureMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetBySearch(GeneralTemperatureMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTemperatureMaster> GeneralTemperatureMasterCollection = new BaseEntityCollectionResponse<GeneralTemperatureMaster>();
            try
            {
                if (_GeneralTemperatureMasterDataProvider != null)
                    GeneralTemperatureMasterCollection = _GeneralTemperatureMasterDataProvider.GetGeneralTemperatureMasterBySearch(searchRequest);
                else
                {
                    GeneralTemperatureMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTemperatureMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTemperatureMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTemperatureMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTemperatureMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterSearchList(GeneralTemperatureMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTemperatureMaster> GeneralTemperatureMasterCollection = new BaseEntityCollectionResponse<GeneralTemperatureMaster>();
            try
            {
                if (_GeneralTemperatureMasterDataProvider != null)
                    GeneralTemperatureMasterCollection = _GeneralTemperatureMasterDataProvider.GetGeneralTemperatureMasterSearchList(searchRequest);
                else
                {
                    GeneralTemperatureMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTemperatureMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTemperatureMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTemperatureMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTemperatureMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralTemperatureMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTemperatureMaster> SelectByID(GeneralTemperatureMaster item)
        {
            IBaseEntityResponse<GeneralTemperatureMaster> entityResponse = new BaseEntityResponse<GeneralTemperatureMaster>();
            try
            {
                entityResponse = _GeneralTemperatureMasterDataProvider.GetGeneralTemperatureMasterByID(item);
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
