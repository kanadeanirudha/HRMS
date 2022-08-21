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
    public class InventoryBrandMasterBA : IInventoryBrandMasterBA
    {
        IInventoryBrandMasterDataProvider _InventoryBrandMasterDataProvider;
        IInventoryBrandMasterBR _InventoryBrandMasterBR;
        private ILogger _logException;
        public InventoryBrandMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryBrandMasterBR = new InventoryBrandMasterBR();
            _InventoryBrandMasterDataProvider = new InventoryBrandMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryBrandMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryBrandMaster> InsertInventoryBrandMaster(InventoryBrandMaster item)
        {
            IBaseEntityResponse<InventoryBrandMaster> entityResponse = new BaseEntityResponse<InventoryBrandMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryBrandMasterBR.InsertInventoryBrandMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryBrandMasterDataProvider.InsertInventoryBrandMaster(item);
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
        /// Update a specific record  of InventoryBrandMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryBrandMaster> UpdateInventoryBrandMaster(InventoryBrandMaster item)
        {
            IBaseEntityResponse<InventoryBrandMaster> entityResponse = new BaseEntityResponse<InventoryBrandMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryBrandMasterBR.UpdateInventoryBrandMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryBrandMasterDataProvider.UpdateInventoryBrandMaster(item);
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
        /// Delete a selected record from InventoryBrandMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryBrandMaster> DeleteInventoryBrandMaster(InventoryBrandMaster item)
        {
            IBaseEntityResponse<InventoryBrandMaster> entityResponse = new BaseEntityResponse<InventoryBrandMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryBrandMasterBR.DeleteInventoryBrandMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryBrandMasterDataProvider.DeleteInventoryBrandMaster(item);
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
        /// Select all record from InventoryBrandMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryBrandMaster> GetBySearch(InventoryBrandMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryBrandMaster> InventoryBrandMasterCollection = new BaseEntityCollectionResponse<InventoryBrandMaster>();
            try
            {
                if (_InventoryBrandMasterDataProvider != null)
                    InventoryBrandMasterCollection = _InventoryBrandMasterDataProvider.GetInventoryBrandMasterBySearch(searchRequest);
                else
                {
                    InventoryBrandMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryBrandMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryBrandMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryBrandMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryBrandMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryBrandMaster> GetInventoryBrandMasterSearchList(InventoryBrandMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryBrandMaster> InventoryBrandMasterCollection = new BaseEntityCollectionResponse<InventoryBrandMaster>();
            try
            {
                if (_InventoryBrandMasterDataProvider != null)
                    InventoryBrandMasterCollection = _InventoryBrandMasterDataProvider.GetInventoryBrandMasterSearchList(searchRequest);
                else
                {
                    InventoryBrandMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryBrandMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryBrandMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryBrandMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryBrandMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryBrandMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryBrandMaster> SelectByID(InventoryBrandMaster item)
        {
            IBaseEntityResponse<InventoryBrandMaster> entityResponse = new BaseEntityResponse<InventoryBrandMaster>();
            try
            {
                entityResponse = _InventoryBrandMasterDataProvider.GetInventoryBrandMasterByID(item);
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
