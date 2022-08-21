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
    public class GeneralTitleMasterBA : IGeneralTitleMasterBA
    {
        IGeneralTitleMasterDataProvider _generalTitleMasterDataProvider;
        IGeneralTitleMasterBR _generalTitleMasterBR;
        private ILogger _logException;
        public GeneralTitleMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new GeneralTitleMasterBR();
            _generalTitleMasterDataProvider = new GeneralTitleMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralTitleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTitleMaster> InsertGeneralTitleMaster(GeneralTitleMaster item)
        {
            IBaseEntityResponse<GeneralTitleMaster> entityResponse = new BaseEntityResponse<GeneralTitleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertGeneralTitleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertGeneralTitleMaster(item);
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
        /// Update a specific record  of GeneralTitleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTitleMaster> UpdateGeneralTitleMaster(GeneralTitleMaster item)
        {
            IBaseEntityResponse<GeneralTitleMaster> entityResponse = new BaseEntityResponse<GeneralTitleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateGeneralTitleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateGeneralTitleMaster(item);
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
        /// Delete a selected record from GeneralTitleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTitleMaster> DeleteGeneralTitleMaster(GeneralTitleMaster item)
        {
            IBaseEntityResponse<GeneralTitleMaster> entityResponse = new BaseEntityResponse<GeneralTitleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteGeneralTitleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteGeneralTitleMaster(item);
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
        /// Select all record from GeneralTitleMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTitleMaster> GetBySearch(GeneralTitleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTitleMaster> GeneralTitleMasterCollection = new BaseEntityCollectionResponse<GeneralTitleMaster>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralTitleMasterCollection = _generalTitleMasterDataProvider.GetGeneralTitleMasterBySearch(searchRequest);
                else
                {
                    GeneralTitleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTitleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTitleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTitleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTitleMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralTitleMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTitleMaster> SelectByID(GeneralTitleMaster item)
        {
            IBaseEntityResponse<GeneralTitleMaster> entityResponse = new BaseEntityResponse<GeneralTitleMaster>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.GetGeneralTitleMasterByID(item);
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
        /// Select all record from GeneralTitleMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTitleMaster> GetBySearchList(GeneralTitleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTitleMaster> GeneralTitleMasterCollection = new BaseEntityCollectionResponse<GeneralTitleMaster>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralTitleMasterCollection = _generalTitleMasterDataProvider.GetGeneralTitleMasterBySearchList(searchRequest);
                else
                {
                    GeneralTitleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTitleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTitleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTitleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTitleMasterCollection;
        }
    }
}
