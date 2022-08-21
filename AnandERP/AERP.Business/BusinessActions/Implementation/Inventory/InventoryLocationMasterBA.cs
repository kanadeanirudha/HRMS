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
    public class InventoryLocationMasterBA : IInventoryLocationMasterBA
    {
        IInventoryLocationMasterDataProvider _InventoryLocationMasterDataProvider;
        IInventoryLocationMasterBR _InventoryLocationMasterBR;
        private ILogger _logException;
        public InventoryLocationMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryLocationMasterBR = new InventoryLocationMasterBR();
            _InventoryLocationMasterDataProvider = new InventoryLocationMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryLocationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryLocationMaster> InsertInventoryLocationMaster(InventoryLocationMaster item)
        {
            IBaseEntityResponse<InventoryLocationMaster> entityResponse = new BaseEntityResponse<InventoryLocationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryLocationMasterBR.InsertInventoryLocationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryLocationMasterDataProvider.InsertInventoryLocationMaster(item);
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
        /// Update a specific record  of InventoryLocationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryLocationMaster> UpdateInventoryLocationMaster(InventoryLocationMaster item)
        {
            IBaseEntityResponse<InventoryLocationMaster> entityResponse = new BaseEntityResponse<InventoryLocationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryLocationMasterBR.UpdateInventoryLocationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryLocationMasterDataProvider.UpdateInventoryLocationMaster(item);
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
        /// Delete a selected record from InventoryLocationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryLocationMaster> DeleteInventoryLocationMaster(InventoryLocationMaster item)
        {
            IBaseEntityResponse<InventoryLocationMaster> entityResponse = new BaseEntityResponse<InventoryLocationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryLocationMasterBR.DeleteInventoryLocationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryLocationMasterDataProvider.DeleteInventoryLocationMaster(item);
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
        /// Select all record from InventoryLocationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetBySearch(InventoryLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster> InventoryLocationMasterCollection = new BaseEntityCollectionResponse<InventoryLocationMaster>();
            try
            {
                if (_InventoryLocationMasterDataProvider != null)
                    InventoryLocationMasterCollection = _InventoryLocationMasterDataProvider.GetInventoryLocationMasterBySearch(searchRequest);
                else
                {
                    InventoryLocationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterList(InventoryLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster> InventoryLocationMasterCollection = new BaseEntityCollectionResponse<InventoryLocationMaster>();
            try
            {
                if (_InventoryLocationMasterDataProvider != null)
                    InventoryLocationMasterCollection = _InventoryLocationMasterDataProvider.GetInventoryLocationMasterList(searchRequest);
                else
                {
                    InventoryLocationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryLocationMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryLocationMaster> SelectByID(InventoryLocationMaster item)
        {
            IBaseEntityResponse<InventoryLocationMaster> entityResponse = new BaseEntityResponse<InventoryLocationMaster>();
            try
            {
                entityResponse = _InventoryLocationMasterDataProvider.GetInventoryLocationMasterByID(item);
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

        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterSearchList(InventoryLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster> InventoryLocationMasterCollection = new BaseEntityCollectionResponse<InventoryLocationMaster>();
            try
            {
                if (_InventoryLocationMasterDataProvider != null)
                    InventoryLocationMasterCollection = _InventoryLocationMasterDataProvider.GetInventoryLocationMasterSearchList(searchRequest);
                else
                {
                    InventoryLocationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterlistCenterCodeWise(InventoryLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster> InventoryLocationMasterCollection = new BaseEntityCollectionResponse<InventoryLocationMaster>();
            try
            {
                if (_InventoryLocationMasterDataProvider != null)
                    InventoryLocationMasterCollection = _InventoryLocationMasterDataProvider.GetInventoryLocationMasterlistCenterCodeWise(searchRequest);
                else
                {
                    InventoryLocationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterlistByAdminRole(InventoryLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster> InventoryLocationMasterCollection = new BaseEntityCollectionResponse<InventoryLocationMaster>();
            try
            {
                if (_InventoryLocationMasterDataProvider != null)
                    InventoryLocationMasterCollection = _InventoryLocationMasterDataProvider.GetInventoryLocationMasterlistByAdminRole(searchRequest);
                else
                {
                    InventoryLocationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMasterCollection;
        }
        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryStorageLocationByCentreCodeAndUnitsID(InventoryLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster> InventoryLocationMasterCollection = new BaseEntityCollectionResponse<InventoryLocationMaster>();
            try
            {
                if (_InventoryLocationMasterDataProvider != null)
                    InventoryLocationMasterCollection = _InventoryLocationMasterDataProvider.GetInventoryStorageLocationByCentreCodeAndUnitsID(searchRequest);
                else
                {
                    InventoryLocationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMasterCollection;
        }


        public IBaseEntityResponse<InventoryLocationMaster> GetUnitsNameByLocationID(InventoryLocationMaster item)
        {
            IBaseEntityResponse<InventoryLocationMaster> entityResponse = new BaseEntityResponse<InventoryLocationMaster>();
            try
            {
                entityResponse = _InventoryLocationMasterDataProvider.GetUnitsNameByLocationID(item);
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
