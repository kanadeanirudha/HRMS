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
    public class GeneralLevelMasterBA : IGeneralLevelMasterBA
    {
        IGeneralLevelMasterDataProvider _generalLevelMasterDataProvider;
        IGeneralLevelMasterBR _generalLevelMasterBR;
        private ILogger _logException;
        public GeneralLevelMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalLevelMasterBR = new GeneralLevelMasterBR();
            _generalLevelMasterDataProvider = new GeneralLevelMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralLevelMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLevelMaster> InsertGeneralLevelMaster(GeneralLevelMaster item)
        {
            IBaseEntityResponse<GeneralLevelMaster> entityResponse = new BaseEntityResponse<GeneralLevelMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalLevelMasterBR.InsertGeneralLevelMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalLevelMasterDataProvider.InsertGeneralLevelMaster(item);
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
        /// Update a specific record  of GeneralLevelMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLevelMaster> UpdateGeneralLevelMaster(GeneralLevelMaster item)
        {
            IBaseEntityResponse<GeneralLevelMaster> entityResponse = new BaseEntityResponse<GeneralLevelMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalLevelMasterBR.UpdateGeneralLevelMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalLevelMasterDataProvider.UpdateGeneralLevelMaster(item);
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
        /// Delete a selected record from GeneralLevelMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLevelMaster> DeleteGeneralLevelMaster(GeneralLevelMaster item)
        {
            IBaseEntityResponse<GeneralLevelMaster> entityResponse = new BaseEntityResponse<GeneralLevelMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalLevelMasterBR.DeleteGeneralLevelMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalLevelMasterDataProvider.DeleteGeneralLevelMaster(item);
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
        /// Select all record from GeneralLevelMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLevelMaster> GetBySearch(GeneralLevelMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLevelMaster> GeneralLevelMasterCollection = new BaseEntityCollectionResponse<GeneralLevelMaster>();
            try
            {
                if (_generalLevelMasterDataProvider != null)
                    GeneralLevelMasterCollection = _generalLevelMasterDataProvider.GetGeneralLevelMasterBySearch(searchRequest);
                else
                {
                    GeneralLevelMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralLevelMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralLevelMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralLevelMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralLevelMasterCollection;
        }
        /// <summary>
        /// Select records from GeneralLevelMaster table for dropdown.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLevelMaster> GetBySearchList(GeneralLevelMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLevelMaster> GeneralLevelMasterCollection = new BaseEntityCollectionResponse<GeneralLevelMaster>();
            try
            {
                if (_generalLevelMasterDataProvider != null)
                    GeneralLevelMasterCollection = _generalLevelMasterDataProvider.GetGeneralLevelMasterBySearchList(searchRequest);
                else
                {
                    GeneralLevelMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralLevelMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralLevelMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralLevelMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralLevelMasterCollection;
        }

        /// <summary>
        /// Select a record from GeneralLevelMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLevelMaster> SelectByID(GeneralLevelMaster item)
        {
            IBaseEntityResponse<GeneralLevelMaster> entityResponse = new BaseEntityResponse<GeneralLevelMaster>();
            try
            {
                entityResponse = _generalLevelMasterDataProvider.GetGeneralLevelMasterByID(item);
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
