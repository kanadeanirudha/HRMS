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
    public class InventoryVariationMasterBA : IInventoryVariationMasterBA
    {
        IInventoryVariationMasterDataProvider _InventoryVariationMasterDataProvider;
        IInventoryVariationMasterBR _InventoryVariationMasterBR;
        private ILogger _logException;
        public InventoryVariationMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryVariationMasterBR = new InventoryVariationMasterBR();
            _InventoryVariationMasterDataProvider = new InventoryVariationMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryVariationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryVariationMaster> InsertInventoryVariationMaster(InventoryVariationMaster item)
        {
            IBaseEntityResponse<InventoryVariationMaster> entityResponse = new BaseEntityResponse<InventoryVariationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryVariationMasterBR.InsertInventoryVariationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryVariationMasterDataProvider.InsertInventoryVariationMaster(item);
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
        /// Update a specific record  of InventoryVariationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryVariationMaster> UpdateInventoryVariationMaster(InventoryVariationMaster item)
        {
            IBaseEntityResponse<InventoryVariationMaster> entityResponse = new BaseEntityResponse<InventoryVariationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryVariationMasterBR.UpdateInventoryVariationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryVariationMasterDataProvider.UpdateInventoryVariationMaster(item);
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
        /// Delete a selected record from InventoryVariationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryVariationMaster> DeleteInventoryVariationMaster(InventoryVariationMaster item)
        {
            IBaseEntityResponse<InventoryVariationMaster> entityResponse = new BaseEntityResponse<InventoryVariationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryVariationMasterBR.DeleteInventoryVariationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryVariationMasterDataProvider.DeleteInventoryVariationMaster(item);
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
        /// Select all record from InventoryVariationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryVariationMaster> GetBySearch(InventoryVariationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryVariationMaster> InventoryVariationMasterCollection = new BaseEntityCollectionResponse<InventoryVariationMaster>();
            try
            {
                if (_InventoryVariationMasterDataProvider != null)
                    InventoryVariationMasterCollection = _InventoryVariationMasterDataProvider.GetInventoryVariationMasterBySearch(searchRequest);
                else
                {
                    InventoryVariationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryVariationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryVariationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryVariationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryVariationMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryVariationMaster> GetInventoryVariationMasterSearchList(InventoryVariationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryVariationMaster> InventoryVariationMasterCollection = new BaseEntityCollectionResponse<InventoryVariationMaster>();
            try
            {
                if (_InventoryVariationMasterDataProvider != null)
                    InventoryVariationMasterCollection = _InventoryVariationMasterDataProvider.GetInventoryVariationMasterSearchList(searchRequest);
                else
                {
                    InventoryVariationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryVariationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryVariationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryVariationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryVariationMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryVariationMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryVariationMaster> SelectByID(InventoryVariationMaster item)
        {
            IBaseEntityResponse<InventoryVariationMaster> entityResponse = new BaseEntityResponse<InventoryVariationMaster>();
            try
            {
                entityResponse = _InventoryVariationMasterDataProvider.GetInventoryVariationMasterByID(item);
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
