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
    public class GeneralServiceMasterBA : IGeneralServiceMasterBA
    {
        IGeneralServiceMasterDataProvider _generalRegionMasterDataProvider;
        IGeneralServiceMasterBR _generalRegionMasterBR;
        private ILogger _logException;

        public GeneralServiceMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new GeneralServiceMasterBR();
            _generalRegionMasterDataProvider = new GeneralServiceMasterDataProvider();
        }

        /// <summary>
        /// Create new record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralServiceMaster> InsertGeneralServiceMaster(GeneralServiceMaster item)
        {
            IBaseEntityResponse<GeneralServiceMaster> entityResponse = new BaseEntityResponse<GeneralServiceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertGeneralServiceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.InsertGeneralServiceMaster(item);
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
        /// Update a specific record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralServiceMaster> UpdateGeneralServiceMaster(GeneralServiceMaster item)
        {
            IBaseEntityResponse<GeneralServiceMaster> entityResponse = new BaseEntityResponse<GeneralServiceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.UpdateGeneralServiceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.UpdateGeneralServiceMaster(item);
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
        /// Delete a selected record from GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralServiceMaster> DeleteGeneralServiceMaster(GeneralServiceMaster item)
        {
            IBaseEntityResponse<GeneralServiceMaster> entityResponse = new BaseEntityResponse<GeneralServiceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.DeleteGeneralServiceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.DeleteGeneralServiceMaster(item);
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
        /// Select all record from GeneralServiceMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralServiceMaster> GetBySearch(GeneralServiceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralServiceMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralServiceMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetGeneralServiceMasterBySearch(searchRequest);
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
        /// Select all record from GeneralServiceMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralServiceMaster> GetBySearchList(GeneralServiceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralServiceMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralServiceMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetGeneralServiceMasterGetBySearchList(searchRequest);
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
        /// Select a record from GeneralServiceMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralServiceMaster> SelectByID(GeneralServiceMaster item)
        {

            IBaseEntityResponse<GeneralServiceMaster> entityResponse = new BaseEntityResponse<GeneralServiceMaster>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.GetGeneralServiceMasterByID(item);
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