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
    public class InventoryAttributeMasterBA : IInventoryAttributeMasterBA
    {
        IInventoryAttributeMasterDataProvider _InventoryAttributeMasterDataProvider;
        IInventoryAttributeMasterBR _InventoryAttributeMasterBR;
        private ILogger _logException;
        public InventoryAttributeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryAttributeMasterBR = new InventoryAttributeMasterBR();
            _InventoryAttributeMasterDataProvider = new InventoryAttributeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryAttributeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryAttributeMaster> InsertInventoryAttributeMaster(InventoryAttributeMaster item)
        {
            IBaseEntityResponse<InventoryAttributeMaster> entityResponse = new BaseEntityResponse<InventoryAttributeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryAttributeMasterBR.InsertInventoryAttributeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryAttributeMasterDataProvider.InsertInventoryAttributeMaster(item);
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
        /// Update a specific record  of InventoryAttributeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryAttributeMaster> UpdateInventoryAttributeMaster(InventoryAttributeMaster item)
        {
            IBaseEntityResponse<InventoryAttributeMaster> entityResponse = new BaseEntityResponse<InventoryAttributeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryAttributeMasterBR.UpdateInventoryAttributeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryAttributeMasterDataProvider.UpdateInventoryAttributeMaster(item);
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
        /// Delete a selected record from InventoryAttributeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryAttributeMaster> DeleteInventoryAttributeMaster(InventoryAttributeMaster item)
        {
            IBaseEntityResponse<InventoryAttributeMaster> entityResponse = new BaseEntityResponse<InventoryAttributeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryAttributeMasterBR.DeleteInventoryAttributeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryAttributeMasterDataProvider.DeleteInventoryAttributeMaster(item);
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
        /// Select all record from InventoryAttributeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryAttributeMaster> GetBySearch(InventoryAttributeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryAttributeMaster> InventoryAttributeMasterCollection = new BaseEntityCollectionResponse<InventoryAttributeMaster>();
            try
            {
                if (_InventoryAttributeMasterDataProvider != null)
                    InventoryAttributeMasterCollection = _InventoryAttributeMasterDataProvider.GetInventoryAttributeMasterBySearch(searchRequest);
                else
                {
                    InventoryAttributeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryAttributeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryAttributeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryAttributeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryAttributeMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryAttributeMaster> GetInventoryAttributeMasterSearchList(InventoryAttributeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryAttributeMaster> InventoryAttributeMasterCollection = new BaseEntityCollectionResponse<InventoryAttributeMaster>();
            try
            {
                if (_InventoryAttributeMasterDataProvider != null)
                    InventoryAttributeMasterCollection = _InventoryAttributeMasterDataProvider.GetInventoryAttributeMasterSearchList(searchRequest);
                else
                {
                    InventoryAttributeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryAttributeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryAttributeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryAttributeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryAttributeMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryAttributeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryAttributeMaster> SelectByID(InventoryAttributeMaster item)
        {
            IBaseEntityResponse<InventoryAttributeMaster> entityResponse = new BaseEntityResponse<InventoryAttributeMaster>();
            try
            {
                entityResponse = _InventoryAttributeMasterDataProvider.GetInventoryAttributeMasterByID(item);
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
