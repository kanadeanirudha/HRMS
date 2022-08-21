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
    public class GeneralCountryMasterBA : IGeneralCountryMasterBA
    {
        IGeneralCountryMasterDataProvider _generalRegionMasterDataProvider;
        IGeneralCountryMasterBR _generalRegionMasterBR;
        private ILogger _logException;

        public GeneralCountryMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new GeneralCountryMasterBR();
            _generalRegionMasterDataProvider = new GeneralCountryMasterDataProvider();
        }

        /// <summary>
        /// Create new record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCountryMaster> InsertGeneralCountryMaster(GeneralCountryMaster item)
        {
            IBaseEntityResponse<GeneralCountryMaster> entityResponse = new BaseEntityResponse<GeneralCountryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertGeneralCountryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.InsertGeneralCountryMaster(item);
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
        /// Update a specific record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCountryMaster> UpdateGeneralCountryMaster(GeneralCountryMaster item)
        {
            IBaseEntityResponse<GeneralCountryMaster> entityResponse = new BaseEntityResponse<GeneralCountryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.UpdateGeneralCountryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.UpdateGeneralCountryMaster(item);
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
        /// Delete a selected record from GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCountryMaster> DeleteGeneralCountryMaster(GeneralCountryMaster item)
        {
            IBaseEntityResponse<GeneralCountryMaster> entityResponse = new BaseEntityResponse<GeneralCountryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.DeleteGeneralCountryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.DeleteGeneralCountryMaster(item);
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
        /// Select all record from GeneralCountryMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralCountryMaster> GetBySearch(GeneralCountryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCountryMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCountryMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetGeneralCountryMasterBySearch(searchRequest);
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
        /// Select all record from GeneralCountryMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralCountryMaster> GetBySearchList(GeneralCountryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCountryMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCountryMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetGeneralCountryMasterGetBySearchList(searchRequest);
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
        /// Select a record from GeneralCountryMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCountryMaster> SelectByID(GeneralCountryMaster item)
        {

            IBaseEntityResponse<GeneralCountryMaster> entityResponse = new BaseEntityResponse<GeneralCountryMaster>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.GetGeneralCountryMasterByID(item);
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