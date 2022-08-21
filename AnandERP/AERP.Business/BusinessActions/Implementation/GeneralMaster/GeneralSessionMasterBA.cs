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

namespace AMS.Business
{
    public class GeneralSessionMasterBA : IGeneralSessionMasterBA
    {
        IGeneralSessionMasterDataProvider _generalSessionMasterDataProvider;
        IGeneralSessionMasterBR _generalSessionMasterBR;
        private ILogger _logException;

        public GeneralSessionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalSessionMasterBR = new GeneralSessionMasterBR();
            _generalSessionMasterDataProvider = new GeneralSessionMasterDataProvider();
        }

        /// <summary>
        /// Create new record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSessionMaster> InsertGeneralSessionMaster(GeneralSessionMaster item)
        {
            IBaseEntityResponse<GeneralSessionMaster> entityResponse = new BaseEntityResponse<GeneralSessionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSessionMasterBR.InsertGeneralSessionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSessionMasterDataProvider.InsertGeneralSessionMaster(item);
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
        /// Update a specific record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSessionMaster> UpdateGeneralSessionMaster(GeneralSessionMaster item)
        {
            IBaseEntityResponse<GeneralSessionMaster> entityResponse = new BaseEntityResponse<GeneralSessionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSessionMasterBR.UpdateGeneralSessionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSessionMasterDataProvider.UpdateGeneralSessionMaster(item);
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
        /// Delete a selected record from General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSessionMaster> DeleteGeneralSessionMaster(GeneralSessionMaster item)
        {
            IBaseEntityResponse<GeneralSessionMaster> entityResponse = new BaseEntityResponse<GeneralSessionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSessionMasterBR.DeleteGeneralSessionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSessionMasterDataProvider.DeleteGeneralSessionMaster(item);
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
        /// Select all record from General Session Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralSessionMaster> GetBySearch(GeneralSessionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralSessionMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralSessionMaster>();
            try
            {
                if (_generalSessionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSessionMasterDataProvider.GetGeneralSessionMasterBySearch(searchRequest);
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
        /// Select all record from General Session Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralSessionMaster> GetBySearchList(GeneralSessionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralSessionMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralSessionMaster>();
            try
            {
                if (_generalSessionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSessionMasterDataProvider.GetGeneralSessionMasterGetBySearchList(searchRequest);
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
        /// Select a record from General Session Master Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSessionMaster> SelectByID(GeneralSessionMaster item)
        {

            IBaseEntityResponse<GeneralSessionMaster> entityResponse = new BaseEntityResponse<GeneralSessionMaster>();
            try
            {
                entityResponse = _generalSessionMasterDataProvider.GetGeneralSessionMasterByID(item);
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
        public IBaseEntityCollectionResponse<GeneralSessionMaster> GetSession(GeneralSessionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralSessionMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralSessionMaster>();
            try
            {
                if (_generalSessionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSessionMasterDataProvider.GetSession(searchRequest);
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
    }
}
