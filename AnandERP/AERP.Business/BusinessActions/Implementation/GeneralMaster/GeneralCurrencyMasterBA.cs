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
    public class GeneralCurrencyMasterBA : IGeneralCurrencyMasterBA
    {
        IGeneralCurrencyMasterDataProvider _generalTitleMasterDataProvider;
        IGeneralCurrencyMasterBR _generalTitleMasterBR;
        private ILogger _logException;
        public GeneralCurrencyMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new GeneralCurrencyMasterBR();
            _generalTitleMasterDataProvider = new GeneralCurrencyMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralCurrencyMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCurrencyMaster> InsertGeneralCurrencyMaster(GeneralCurrencyMaster item)
        {
            IBaseEntityResponse<GeneralCurrencyMaster> entityResponse = new BaseEntityResponse<GeneralCurrencyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertGeneralCurrencyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertGeneralCurrencyMaster(item);
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
        /// Update a specific record  of GeneralCurrencyMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCurrencyMaster> UpdateGeneralCurrencyMaster(GeneralCurrencyMaster item)
        {
            IBaseEntityResponse<GeneralCurrencyMaster> entityResponse = new BaseEntityResponse<GeneralCurrencyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateGeneralCurrencyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateGeneralCurrencyMaster(item);
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
        /// Delete a selected record from GeneralCurrencyMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCurrencyMaster> DeleteGeneralCurrencyMaster(GeneralCurrencyMaster item)
        {
            IBaseEntityResponse<GeneralCurrencyMaster> entityResponse = new BaseEntityResponse<GeneralCurrencyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteGeneralCurrencyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteGeneralCurrencyMaster(item);
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
        /// Select all record from GeneralCurrencyMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetBySearch(GeneralCurrencyMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCurrencyMaster> GeneralCurrencyMasterCollection = new BaseEntityCollectionResponse<GeneralCurrencyMaster>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralCurrencyMasterCollection = _generalTitleMasterDataProvider.GetGeneralCurrencyMasterBySearch(searchRequest);
                else
                {
                    GeneralCurrencyMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralCurrencyMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralCurrencyMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralCurrencyMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralCurrencyMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralCurrencyMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCurrencyMaster> SelectByID(GeneralCurrencyMaster item)
        {
            IBaseEntityResponse<GeneralCurrencyMaster> entityResponse = new BaseEntityResponse<GeneralCurrencyMaster>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.GetGeneralCurrencyMasterByID(item);
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
        /// Select all record from GeneralCurrencyMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetBySearchList(GeneralCurrencyMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCurrencyMaster> GeneralCurrencyMasterCollection = new BaseEntityCollectionResponse<GeneralCurrencyMaster>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralCurrencyMasterCollection = _generalTitleMasterDataProvider.GetGeneralCurrencyMasterBySearchList(searchRequest);
                else
                {
                    GeneralCurrencyMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralCurrencyMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralCurrencyMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralCurrencyMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralCurrencyMasterCollection;
        }
    }
}
