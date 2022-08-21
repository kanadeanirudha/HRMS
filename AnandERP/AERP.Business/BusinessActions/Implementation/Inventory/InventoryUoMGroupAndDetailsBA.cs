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
    public class InventoryUoMGroupAndDetailsBA : IInventoryUoMGroupAndDetailsBA
    {
        IInventoryUoMGroupAndDetailsDataProvider _InventoryUoMGroupAndDetailsDataProvider;
        IInventoryUoMGroupAndDetailsBR _InventoryUoMGroupAndDetailsBR;
        private ILogger _logException;
        public InventoryUoMGroupAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryUoMGroupAndDetailsBR = new InventoryUoMGroupAndDetailsBR();
            _InventoryUoMGroupAndDetailsDataProvider = new InventoryUoMGroupAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryUoMGroupAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> InsertInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item)
        {
            IBaseEntityResponse<InventoryUoMGroupAndDetails> entityResponse = new BaseEntityResponse<InventoryUoMGroupAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMGroupAndDetailsBR.InsertInventoryUoMGroupAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMGroupAndDetailsDataProvider.InsertInventoryUoMGroupAndDetails(item);
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
        /// Update a specific record  of InventoryUoMGroupAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> UpdateInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item)
        {
            IBaseEntityResponse<InventoryUoMGroupAndDetails> entityResponse = new BaseEntityResponse<InventoryUoMGroupAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMGroupAndDetailsBR.UpdateInventoryUoMGroupAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMGroupAndDetailsDataProvider.UpdateInventoryUoMGroupAndDetails(item);
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
        /// Delete a selected record from InventoryUoMGroupAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> DeleteInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item)
        {
            IBaseEntityResponse<InventoryUoMGroupAndDetails> entityResponse = new BaseEntityResponse<InventoryUoMGroupAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMGroupAndDetailsBR.DeleteInventoryUoMGroupAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMGroupAndDetailsDataProvider.DeleteInventoryUoMGroupAndDetails(item);
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
        /// Select all record from InventoryUoMGroupAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetBySearch(InventoryUoMGroupAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> InventoryUoMGroupAndDetailsCollection = new BaseEntityCollectionResponse<InventoryUoMGroupAndDetails>();
            try
            {
                if (_InventoryUoMGroupAndDetailsDataProvider != null)
                    InventoryUoMGroupAndDetailsCollection = _InventoryUoMGroupAndDetailsDataProvider.GetInventoryUoMGroupAndDetailsBySearch(searchRequest);
                else
                {
                    InventoryUoMGroupAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMGroupAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMGroupAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMGroupAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMGroupAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUoMGroupAndDetailsSearchList(InventoryUoMGroupAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> InventoryUoMGroupAndDetailsCollection = new BaseEntityCollectionResponse<InventoryUoMGroupAndDetails>();
            try
            {
                if (_InventoryUoMGroupAndDetailsDataProvider != null)
                    InventoryUoMGroupAndDetailsCollection = _InventoryUoMGroupAndDetailsDataProvider.GetInventoryUoMGroupAndDetailsSearchList(searchRequest);
                else
                {
                    InventoryUoMGroupAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMGroupAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMGroupAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMGroupAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMGroupAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from InventoryUoMGroupAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> SelectByID(InventoryUoMGroupAndDetails item)
        {
            IBaseEntityResponse<InventoryUoMGroupAndDetails> entityResponse = new BaseEntityResponse<InventoryUoMGroupAndDetails>();
            try
            {
                entityResponse = _InventoryUoMGroupAndDetailsDataProvider.GetInventoryUoMGroupAndDetailsByID(item);
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

        //*******************************************************************************************************
        /// <summary>
        /// Create new record of InventoryUoMGroupAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> InsertInventoryUoMGroup(InventoryUoMGroupAndDetails item)
        {
            IBaseEntityResponse<InventoryUoMGroupAndDetails> entityResponse = new BaseEntityResponse<InventoryUoMGroupAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMGroupAndDetailsBR.InsertInventoryUoMGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMGroupAndDetailsDataProvider.InsertInventoryUoMGroup(item);
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
        /// Update a specific record  of InventoryUoMGroupAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> UpdateInventoryUoMGroup(InventoryUoMGroupAndDetails item)
        {
            IBaseEntityResponse<InventoryUoMGroupAndDetails> entityResponse = new BaseEntityResponse<InventoryUoMGroupAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMGroupAndDetailsBR.UpdateInventoryUoMGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMGroupAndDetailsDataProvider.UpdateInventoryUoMGroup(item);
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
        /// Delete a selected record from InventoryUoMGroupAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> DeleteInventoryUoMGroup(InventoryUoMGroupAndDetails item)
        {
            IBaseEntityResponse<InventoryUoMGroupAndDetails> entityResponse = new BaseEntityResponse<InventoryUoMGroupAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryUoMGroupAndDetailsBR.DeleteInventoryUoMGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryUoMGroupAndDetailsDataProvider.DeleteInventoryUoMGroup(item);
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

        public IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> SelectByInventoryUoMGroupID(InventoryUoMGroupAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> InventoryUoMGroupAndDetailsCollection = new BaseEntityCollectionResponse<InventoryUoMGroupAndDetails>();
            try
            {
                if (_InventoryUoMGroupAndDetailsDataProvider != null)
                    InventoryUoMGroupAndDetailsCollection = _InventoryUoMGroupAndDetailsDataProvider.GetInventoryUoMGroupAndDetailsByInventoryUoMGroupID(searchRequest);
                else
                {
                    InventoryUoMGroupAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMGroupAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMGroupAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMGroupAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMGroupAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUomCodeByUomGroupCode(InventoryUoMGroupAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> InventoryUoMGroupAndDetailsCollection = new BaseEntityCollectionResponse<InventoryUoMGroupAndDetails>();
            try
            {
                if (_InventoryUoMGroupAndDetailsDataProvider != null)
                    InventoryUoMGroupAndDetailsCollection = _InventoryUoMGroupAndDetailsDataProvider.GetInventoryUomCodeByUomGroupCode(searchRequest);
                else
                {
                    InventoryUoMGroupAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryUoMGroupAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryUoMGroupAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryUoMGroupAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryUoMGroupAndDetailsCollection;
        }
    }
}
