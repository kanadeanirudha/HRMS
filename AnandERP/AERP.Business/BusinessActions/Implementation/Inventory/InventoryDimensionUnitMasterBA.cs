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
    public class InventoryDimensionUnitMasterBA : IInventoryDimensionUnitMasterBA
    {
        IInventoryDimensionUnitMasterDataProvider _InventoryDimensionUnitMasterDataProvider;
        IInventoryDimensionUnitMasterBR _InventoryDimensionUnitMasterBR;
        private ILogger _logException;
        public InventoryDimensionUnitMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryDimensionUnitMasterBR = new InventoryDimensionUnitMasterBR();
            _InventoryDimensionUnitMasterDataProvider = new InventoryDimensionUnitMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryDimensionUnitMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryDimensionUnitMaster> InsertInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item)
        {
            IBaseEntityResponse<InventoryDimensionUnitMaster> entityResponse = new BaseEntityResponse<InventoryDimensionUnitMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryDimensionUnitMasterBR.InsertInventoryDimensionUnitMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryDimensionUnitMasterDataProvider.InsertInventoryDimensionUnitMaster(item);
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
        /// Update a specific record  of InventoryDimensionUnitMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryDimensionUnitMaster> UpdateInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item)
        {
            IBaseEntityResponse<InventoryDimensionUnitMaster> entityResponse = new BaseEntityResponse<InventoryDimensionUnitMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryDimensionUnitMasterBR.UpdateInventoryDimensionUnitMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryDimensionUnitMasterDataProvider.UpdateInventoryDimensionUnitMaster(item);
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
        /// Delete a selected record from InventoryDimensionUnitMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryDimensionUnitMaster> DeleteInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item)
        {
            IBaseEntityResponse<InventoryDimensionUnitMaster> entityResponse = new BaseEntityResponse<InventoryDimensionUnitMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryDimensionUnitMasterBR.DeleteInventoryDimensionUnitMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryDimensionUnitMasterDataProvider.DeleteInventoryDimensionUnitMaster(item);
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
        /// Select all record from InventoryDimensionUnitMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetBySearch(InventoryDimensionUnitMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> InventoryDimensionUnitMasterCollection = new BaseEntityCollectionResponse<InventoryDimensionUnitMaster>();
            try
            {
                if (_InventoryDimensionUnitMasterDataProvider != null)
                    InventoryDimensionUnitMasterCollection = _InventoryDimensionUnitMasterDataProvider.GetInventoryDimensionUnitMasterBySearch(searchRequest);
                else
                {
                    InventoryDimensionUnitMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryDimensionUnitMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryDimensionUnitMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryDimensionUnitMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryDimensionUnitMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetInventoryDimensionUnitMasterSearchList(InventoryDimensionUnitMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> InventoryDimensionUnitMasterCollection = new BaseEntityCollectionResponse<InventoryDimensionUnitMaster>();
            try
            {
                if (_InventoryDimensionUnitMasterDataProvider != null)
                    InventoryDimensionUnitMasterCollection = _InventoryDimensionUnitMasterDataProvider.GetInventoryDimensionUnitMasterSearchList(searchRequest);
                else
                {
                    InventoryDimensionUnitMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryDimensionUnitMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryDimensionUnitMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryDimensionUnitMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryDimensionUnitMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryDimensionUnitMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryDimensionUnitMaster> SelectByID(InventoryDimensionUnitMaster item)
        {
            IBaseEntityResponse<InventoryDimensionUnitMaster> entityResponse = new BaseEntityResponse<InventoryDimensionUnitMaster>();
            try
            {
                entityResponse = _InventoryDimensionUnitMasterDataProvider.GetInventoryDimensionUnitMasterByID(item);
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
