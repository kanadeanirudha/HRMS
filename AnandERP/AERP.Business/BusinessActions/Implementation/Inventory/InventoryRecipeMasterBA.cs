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
    public class InventoryRecipeMasterBA : IInventoryRecipeMasterBA
    {
        IInventoryRecipeMasterDataProvider _InventoryRecipeMasterDataProvider;
        IInventoryRecipeMasterBR _InventoryRecipeMasterBR;
        private ILogger _logException;
        public InventoryRecipeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryRecipeMasterBR = new InventoryRecipeMasterBR();
            _InventoryRecipeMasterDataProvider = new InventoryRecipeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryRecipeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeMaster> InsertInventoryRecipeMaster(InventoryRecipeMaster item)
        {
            IBaseEntityResponse<InventoryRecipeMaster> entityResponse = new BaseEntityResponse<InventoryRecipeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRecipeMasterBR.InsertInventoryRecipeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRecipeMasterDataProvider.InsertInventoryRecipeMaster(item);
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
        /// Update a specific record  of InventoryRecipeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeMaster> UpdateInventoryRecipeMaster(InventoryRecipeMaster item)
        {
            IBaseEntityResponse<InventoryRecipeMaster> entityResponse = new BaseEntityResponse<InventoryRecipeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRecipeMasterBR.UpdateInventoryRecipeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRecipeMasterDataProvider.UpdateInventoryRecipeMaster(item);
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
        /// Delete a selected record from InventoryRecipeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeMaster> DeleteInventoryRecipeMaster(InventoryRecipeMaster item)
        {
            IBaseEntityResponse<InventoryRecipeMaster> entityResponse = new BaseEntityResponse<InventoryRecipeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRecipeMasterBR.DeleteInventoryRecipeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRecipeMasterDataProvider.DeleteInventoryRecipeMaster(item);
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
        /// Select all record from InventoryRecipeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryRecipeMaster> GetBySearch(InventoryRecipeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeMaster> InventoryRecipeMasterCollection = new BaseEntityCollectionResponse<InventoryRecipeMaster>();
            try
            {
                if (_InventoryRecipeMasterDataProvider != null)
                    InventoryRecipeMasterCollection = _InventoryRecipeMasterDataProvider.GetInventoryRecipeMasterBySearch(searchRequest);
                else
                {
                    InventoryRecipeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryRecipeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryRecipeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryRecipeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryRecipeMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryRecipeMaster> GetInventoryRecipeMasterSearchList(InventoryRecipeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeMaster> InventoryRecipeMasterCollection = new BaseEntityCollectionResponse<InventoryRecipeMaster>();
            try
            {
                if (_InventoryRecipeMasterDataProvider != null)
                    InventoryRecipeMasterCollection = _InventoryRecipeMasterDataProvider.GetInventoryRecipeMasterSearchList(searchRequest);
                else
                {
                    InventoryRecipeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryRecipeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryRecipeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryRecipeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryRecipeMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryRecipeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeMaster> SelectByID(InventoryRecipeMaster item)
        {
            IBaseEntityResponse<InventoryRecipeMaster> entityResponse = new BaseEntityResponse<InventoryRecipeMaster>();
            try
            {
                entityResponse = _InventoryRecipeMasterDataProvider.GetInventoryRecipeMasterByID(item);
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
