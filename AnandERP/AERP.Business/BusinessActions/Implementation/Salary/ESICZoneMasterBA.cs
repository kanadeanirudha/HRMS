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
    public class ESICZoneMasterBA : IESICZoneMasterBA
    {
        IESICZoneMasterDataProvider _ESICZoneMasterDataProvider;
        IESICZoneMasterBR _ESICZoneMasterBR;
        private ILogger _logException;
        public ESICZoneMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _ESICZoneMasterBR = new ESICZoneMasterBR();
            _ESICZoneMasterDataProvider = new ESICZoneMasterDataProvider();
        }
        /// <summary>
        /// Create new record of ESICZoneMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ESICZoneMaster> InsertESICZoneMaster(ESICZoneMaster item)
        {
            IBaseEntityResponse<ESICZoneMaster> entityResponse = new BaseEntityResponse<ESICZoneMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ESICZoneMasterBR.InsertESICZoneMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ESICZoneMasterDataProvider.InsertESICZoneMaster(item);
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
        /// Update a specific record  of ESICZoneMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ESICZoneMaster> UpdateESICZoneMaster(ESICZoneMaster item)
        {
            IBaseEntityResponse<ESICZoneMaster> entityResponse = new BaseEntityResponse<ESICZoneMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ESICZoneMasterBR.UpdateESICZoneMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ESICZoneMasterDataProvider.UpdateESICZoneMaster(item);
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
        /// Delete a selected record from ESICZoneMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ESICZoneMaster> DeleteESICZoneMaster(ESICZoneMaster item)
        {
            IBaseEntityResponse<ESICZoneMaster> entityResponse = new BaseEntityResponse<ESICZoneMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ESICZoneMasterBR.DeleteESICZoneMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ESICZoneMasterDataProvider.DeleteESICZoneMaster(item);
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
        /// Select all record from ESICZoneMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ESICZoneMaster> GetBySearch(ESICZoneMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ESICZoneMaster> ESICZoneMasterCollection = new BaseEntityCollectionResponse<ESICZoneMaster>();
            try
            {
                if (_ESICZoneMasterDataProvider != null)
                    ESICZoneMasterCollection = _ESICZoneMasterDataProvider.GetESICZoneMasterBySearch(searchRequest);
                else
                {
                    ESICZoneMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ESICZoneMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ESICZoneMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ESICZoneMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ESICZoneMasterCollection;
        }

        public IBaseEntityCollectionResponse<ESICZoneMaster> GetESICZoneMasterSearchList(ESICZoneMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ESICZoneMaster> ESICZoneMasterCollection = new BaseEntityCollectionResponse<ESICZoneMaster>();
            try
            {
                if (_ESICZoneMasterDataProvider != null)
                    ESICZoneMasterCollection = _ESICZoneMasterDataProvider.GetESICZoneMasterSearchList(searchRequest);
                else
                {
                    ESICZoneMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ESICZoneMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ESICZoneMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ESICZoneMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ESICZoneMasterCollection;
        }
        /// <summary>
        /// Select a record from ESICZoneMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ESICZoneMaster> SelectByID(ESICZoneMaster item)
        {
            IBaseEntityResponse<ESICZoneMaster> entityResponse = new BaseEntityResponse<ESICZoneMaster>();
            try
            {
                entityResponse = _ESICZoneMasterDataProvider.GetESICZoneMasterByID(item);
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

        public IBaseEntityCollectionResponse<ESICZoneMaster> GetDropDownListforESICZoneMaster(ESICZoneMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ESICZoneMaster> ESICZoneMasterCollection = new BaseEntityCollectionResponse<ESICZoneMaster>();
            try
            {
                if (_ESICZoneMasterDataProvider != null)
                    ESICZoneMasterCollection = _ESICZoneMasterDataProvider.GetDropDownListforESICZoneMaster(searchRequest);
                else
                {
                    ESICZoneMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ESICZoneMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ESICZoneMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ESICZoneMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ESICZoneMasterCollection;
        }
    }
}
