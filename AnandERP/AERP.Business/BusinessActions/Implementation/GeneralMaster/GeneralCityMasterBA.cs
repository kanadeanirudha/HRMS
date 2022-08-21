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
    public class GeneralCityMasterBA : IGeneralCityMasterBA
    {
        IGeneralCityMasterDataProvider _generalCityMasterDataProvider;
        IGeneralCityMasterBR _generalCityMasterBR;
        private ILogger _logException;

        public GeneralCityMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalCityMasterBR = new GeneralCityMasterBR();
            _generalCityMasterDataProvider = new GeneralCityMasterDataProvider();
        }

        /// <summary>
        /// Create new record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCityMaster> InsertGeneralCityMaster(GeneralCityMaster item)
        {
            IBaseEntityResponse<GeneralCityMaster> entityResponse = new BaseEntityResponse<GeneralCityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalCityMasterBR.InsertGeneralCityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalCityMasterDataProvider.InsertGeneralCityMaster(item);
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

        /// <summary>
        /// Update a specific record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCityMaster> UpdateGeneralCityMaster(GeneralCityMaster item)
        {
            IBaseEntityResponse<GeneralCityMaster> entityResponse = new BaseEntityResponse<GeneralCityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalCityMasterBR.UpdateGeneralCityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalCityMasterDataProvider.UpdateGeneralCityMaster(item);
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

        /// <summary>
        /// Delete a selected record from General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCityMaster> DeleteGeneralCityMaster(GeneralCityMaster item)
        {
            IBaseEntityResponse<GeneralCityMaster> entityResponse = new BaseEntityResponse<GeneralCityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalCityMasterBR.DeleteGeneralCityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalCityMasterDataProvider.DeleteGeneralCityMaster(item);
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

        /// <summary>
        /// Select all record from General City Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralCityMaster> GetBySearch(GeneralCityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCityMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCityMaster>();
            try
            {
                if (_generalCityMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalCityMasterDataProvider.GetGeneralCityMasterBySearch(searchRequest);
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

        

        /// <summary>
        /// Select all record from General City Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralCityMaster> GetByRegionID(GeneralCityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCityMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCityMaster>();
            try
            {
                if (_generalCityMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalCityMasterDataProvider.GetGeneralCityMasterGetByRegionID(searchRequest);
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
          
        /// <summary>
        /// Select a record from General City Master Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCityMaster> SelectByID(GeneralCityMaster item)
        {

            IBaseEntityResponse<GeneralCityMaster> entityResponse = new BaseEntityResponse<GeneralCityMaster>();
            try
            {
                entityResponse = _generalCityMasterDataProvider.GetGeneralCityMasterByID(item);
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

        public IBaseEntityCollectionResponse<GeneralCityMaster> GetBySearchList(GeneralCityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCityMaster> GeneralCityMasterCollection = new BaseEntityCollectionResponse<GeneralCityMaster>();
            try
            {
                if (_generalCityMasterDataProvider != null)
                {
                    GeneralCityMasterCollection = _generalCityMasterDataProvider.GetGeneralCityMasterGetBySearchList(searchRequest);
                }
                else
                {
                    GeneralCityMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralCityMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralCityMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                GeneralCityMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralCityMasterCollection;
        }
    }
}