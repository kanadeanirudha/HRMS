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
namespace AMS.Business.BusinessAction
{
    public class GeneralTimeSlotMasterBA : IGeneralTimeSlotMasterBA
    {
        IGeneralTimeSlotMasterDataProvider _generalTimeSlotMasterDataProvider;
        IGeneralTimeSlotMasterBR _generalTimeSlotMasterBR;
        private ILogger _logException;
        public GeneralTimeSlotMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTimeSlotMasterBR = new GeneralTimeSlotMasterBR();
            _generalTimeSlotMasterDataProvider = new GeneralTimeSlotMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralTimeSlotMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTimeSlotMaster> InsertGeneralTimeSlotMaster(GeneralTimeSlotMaster item)
        {
            IBaseEntityResponse<GeneralTimeSlotMaster> entityResponse = new BaseEntityResponse<GeneralTimeSlotMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTimeSlotMasterBR.InsertGeneralTimeSlotMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTimeSlotMasterDataProvider.InsertGeneralTimeSlotMaster(item);
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
        /// Update a specific record  of GeneralTimeSlotMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTimeSlotMaster> UpdateGeneralTimeSlotMaster(GeneralTimeSlotMaster item)
        {
            IBaseEntityResponse<GeneralTimeSlotMaster> entityResponse = new BaseEntityResponse<GeneralTimeSlotMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTimeSlotMasterBR.UpdateGeneralTimeSlotMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTimeSlotMasterDataProvider.UpdateGeneralTimeSlotMaster(item);
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
        /// Delete a selected record from GeneralTimeSlotMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTimeSlotMaster> DeleteGeneralTimeSlotMaster(GeneralTimeSlotMaster item)
        {
            IBaseEntityResponse<GeneralTimeSlotMaster> entityResponse = new BaseEntityResponse<GeneralTimeSlotMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTimeSlotMasterBR.DeleteGeneralTimeSlotMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTimeSlotMasterDataProvider.DeleteGeneralTimeSlotMaster(item);
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
        /// Select all record from GeneralTimeSlotMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GetBySearch(GeneralTimeSlotMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GeneralTimeSlotMasterCollection = new BaseEntityCollectionResponse<GeneralTimeSlotMaster>();
            try
            {
                if (_generalTimeSlotMasterDataProvider != null)
                    GeneralTimeSlotMasterCollection = _generalTimeSlotMasterDataProvider.GetGeneralTimeSlotMasterBySearch(searchRequest);
                else
                {
                    GeneralTimeSlotMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTimeSlotMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTimeSlotMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTimeSlotMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTimeSlotMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralTimeSlotMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTimeSlotMaster> SelectByID(GeneralTimeSlotMaster item)
        {
            IBaseEntityResponse<GeneralTimeSlotMaster> entityResponse = new BaseEntityResponse<GeneralTimeSlotMaster>();
            try
            {
                entityResponse = _generalTimeSlotMasterDataProvider.GetGeneralTimeSlotMasterByID(item);
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
        /// Select all record from GeneralTimeSlotMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GeneralTimeSlotMasterSearchList(GeneralTimeSlotMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GeneralTimeSlotMasterCollection = new BaseEntityCollectionResponse<GeneralTimeSlotMaster>();
            try
            {
                if (_generalTimeSlotMasterDataProvider != null)
                    GeneralTimeSlotMasterCollection = _generalTimeSlotMasterDataProvider.GeneralTimeSlotMasterSearchList(searchRequest);
                else
                {
                    GeneralTimeSlotMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTimeSlotMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTimeSlotMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTimeSlotMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTimeSlotMasterCollection;
        }
        
        // For GeneralTimeZoneMaster Searchlist
        public IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GetGeneralTimeZoneMasterSearchlist(GeneralTimeSlotMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GeneralTimeSlotMasterCollection = new BaseEntityCollectionResponse<GeneralTimeSlotMaster>();
            try
            {
                if (_generalTimeSlotMasterDataProvider != null)
                    GeneralTimeSlotMasterCollection = _generalTimeSlotMasterDataProvider.GetGeneralTimeZoneMasterSearchlist(searchRequest);
                else
                {
                    GeneralTimeSlotMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTimeSlotMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTimeSlotMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTimeSlotMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTimeSlotMasterCollection;
        }
        
    }
}
