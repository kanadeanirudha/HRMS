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
    public class InventoryUoMMasterBA : IInventoryUoMMasterBA
    {
        IInventoryUoMMasterDataProvider _InventoryUoMMasterDataProvider;
        IInventoryUoMMasterBR _InventoryUoMMasterBR;
        private ILogger _logException;
        public InventoryUoMMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryUoMMasterBR = new InventoryUoMMasterBR();
            _InventoryUoMMasterDataProvider = new InventoryUoMMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryUoMMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMMaster> InsertInventoryUoMMaster(InventoryUoMMaster item)
        {
            IBaseEntityResponse<InventoryUoMMaster> entityResponse = new BaseEntityResponse<InventoryUoMMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMMasterBR.InsertInventoryUoMMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMMasterDataProvider.InsertInventoryUoMMaster(item);
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
        /// Update a specific record  of InventoryUoMMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMMaster> UpdateInventoryUoMMaster(InventoryUoMMaster item)
        {
            IBaseEntityResponse<InventoryUoMMaster> entityResponse = new BaseEntityResponse<InventoryUoMMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMMasterBR.UpdateInventoryUoMMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMMasterDataProvider.UpdateInventoryUoMMaster(item);
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
        /// Delete a selected record from InventoryUoMMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMMaster> DeleteInventoryUoMMaster(InventoryUoMMaster item)
        {
            IBaseEntityResponse<InventoryUoMMaster> entityResponse = new BaseEntityResponse<InventoryUoMMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMMasterBR.DeleteInventoryUoMMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMMasterDataProvider.DeleteInventoryUoMMaster(item);
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
        /// Select all record from InventoryUoMMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetBySearch(InventoryUoMMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMMaster> InventoryUoMMasterCollection = new BaseEntityCollectionResponse<InventoryUoMMaster>();
            try
            {
                if (_InventoryUoMMasterDataProvider != null)
                    InventoryUoMMasterCollection = _InventoryUoMMasterDataProvider.GetInventoryUoMMasterBySearch(searchRequest);
                else
                {
                    InventoryUoMMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterSearchList(InventoryUoMMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMMaster> InventoryUoMMasterCollection = new BaseEntityCollectionResponse<InventoryUoMMaster>();
            try
            {
                if (_InventoryUoMMasterDataProvider != null)
                    InventoryUoMMasterCollection = _InventoryUoMMasterDataProvider.GetInventoryUoMMasterSearchList(searchRequest);
                else
                {
                    InventoryUoMMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryUoMMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMMaster> SelectByID(InventoryUoMMaster item)
        {
            IBaseEntityResponse<InventoryUoMMaster> entityResponse = new BaseEntityResponse<InventoryUoMMaster>();
            try
            {
                entityResponse = _InventoryUoMMasterDataProvider.GetInventoryUoMMasterByID(item);
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

        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforUomCode(InventoryUoMMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMMaster> InventoryUoMMasterCollection = new BaseEntityCollectionResponse<InventoryUoMMaster>();
            try
            {
                if (_InventoryUoMMasterDataProvider != null)
                    InventoryUoMMasterCollection = _InventoryUoMMasterDataProvider.GetInventoryUoMMasterDropDownforUomCode(searchRequest);
                else
                {
                    InventoryUoMMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMMasterCollection;
        }
        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetBySearchList(InventoryUoMMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMMaster> InventoryUoMMasterCollection = new BaseEntityCollectionResponse<InventoryUoMMaster>();
            try
            {
                if (_InventoryUoMMasterDataProvider != null)
                {
                    InventoryUoMMasterCollection = _InventoryUoMMasterDataProvider.GetInventoryUoMMasterGetBySearchList(searchRequest);
                }
                else
                {
                    InventoryUoMMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                InventoryUoMMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforSaleUomCode(InventoryUoMMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMMaster> InventoryUoMMasterCollection = new BaseEntityCollectionResponse<InventoryUoMMaster>();
            try
            {
                if (_InventoryUoMMasterDataProvider != null)
                    InventoryUoMMasterCollection = _InventoryUoMMasterDataProvider.GetInventoryUoMMasterDropDownforSaleUomCode(searchRequest);
                else
                {
                    InventoryUoMMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforPurchaseUomCode(InventoryUoMMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMMaster> InventoryUoMMasterCollection = new BaseEntityCollectionResponse<InventoryUoMMaster>();
            try
            {
                if (_InventoryUoMMasterDataProvider != null)
                    InventoryUoMMasterCollection = _InventoryUoMMasterDataProvider.GetInventoryUoMMasterDropDownforPurchaseUomCode(searchRequest);
                else
                {
                    InventoryUoMMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMMasterCollection;
        }
    
    }
}
