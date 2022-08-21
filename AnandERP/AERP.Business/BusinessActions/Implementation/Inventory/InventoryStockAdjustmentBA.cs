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
    public class InventoryStockAdjustmentBA : IInventoryStockAdjustmentBA
    {
        IInventoryStockAdjustmentDataProvider _InventoryStockAdjustmentDataProvider;
        IInventoryStockAdjustmentBR _InventoryStockAdjustmentBR;
        private ILogger _logException;
        public InventoryStockAdjustmentBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryStockAdjustmentBR = new InventoryStockAdjustmentBR();
            _InventoryStockAdjustmentDataProvider = new InventoryStockAdjustmentDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryStockAdjustment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustment(InventoryStockAdjustment item)
        {
            IBaseEntityResponse<InventoryStockAdjustment> entityResponse = new BaseEntityResponse<InventoryStockAdjustment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryStockAdjustmentBR.InsertInventoryStockAdjustmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryStockAdjustmentDataProvider.InsertInventoryStockAdjustment(item);
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
        /// Update a specific record  of InventoryStockAdjustment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryStockAdjustment> UpdateInventoryStockAdjustment(InventoryStockAdjustment item)
        {
            IBaseEntityResponse<InventoryStockAdjustment> entityResponse = new BaseEntityResponse<InventoryStockAdjustment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryStockAdjustmentBR.UpdateInventoryStockAdjustmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryStockAdjustmentDataProvider.UpdateInventoryStockAdjustment(item);
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
        /// Delete a selected record from InventoryStockAdjustment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryStockAdjustment> DeleteInventoryStockAdjustment(InventoryStockAdjustment item)
        {
            IBaseEntityResponse<InventoryStockAdjustment> entityResponse = new BaseEntityResponse<InventoryStockAdjustment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryStockAdjustmentBR.DeleteInventoryStockAdjustmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryStockAdjustmentDataProvider.DeleteInventoryStockAdjustment(item);
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
        /// Select all record from InventoryStockAdjustment table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetBySearch(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryStockAdjustment> InventoryStockAdjustmentCollection = new BaseEntityCollectionResponse<InventoryStockAdjustment>();
            try
            {
                if (_InventoryStockAdjustmentDataProvider != null)
                    InventoryStockAdjustmentCollection = _InventoryStockAdjustmentDataProvider.GetInventoryStockAdjustmentBySearch(searchRequest);
                else
                {
                    InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryStockAdjustmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryStockAdjustmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryStockAdjustmentCollection;
        }

        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentSearchList(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryStockAdjustment> InventoryStockAdjustmentCollection = new BaseEntityCollectionResponse<InventoryStockAdjustment>();
            try
            {
                if (_InventoryStockAdjustmentDataProvider != null)
                    InventoryStockAdjustmentCollection = _InventoryStockAdjustmentDataProvider.GetInventoryStockAdjustmentSearchList(searchRequest);
                else
                {
                    InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryStockAdjustmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryStockAdjustmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryStockAdjustmentCollection;
        }
        /// <summary>
        /// Select a record from InventoryStockAdjustment table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryStockAdjustment> SelectByID(InventoryStockAdjustment item)
        {
            IBaseEntityResponse<InventoryStockAdjustment> entityResponse = new BaseEntityResponse<InventoryStockAdjustment>();
            try
            {
                entityResponse = _InventoryStockAdjustmentDataProvider.GetInventoryStockAdjustmentByID(item);
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

        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetItemNameForCurrentStock(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryStockAdjustment> InventoryStockAdjustmentCollection = new BaseEntityCollectionResponse<InventoryStockAdjustment>();
            try
            {
                if (_InventoryStockAdjustmentDataProvider != null)
                    InventoryStockAdjustmentCollection = _InventoryStockAdjustmentDataProvider.GetItemNameForCurrentStock(searchRequest);
                else
                {
                    InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryStockAdjustmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryStockAdjustmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryStockAdjustmentCollection;
        }

        public IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustmentXML(InventoryStockAdjustment item)
        {
            IBaseEntityResponse<InventoryStockAdjustment> entityResponse = new BaseEntityResponse<InventoryStockAdjustment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryStockAdjustmentBR.InsertXMLInventoryStockAdjustmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryStockAdjustmentDataProvider.InsertInventoryStockAdjustmentXML(item);
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

        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentSearchListForRecipeItem(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryStockAdjustment> InventoryStockAdjustmentCollection = new BaseEntityCollectionResponse<InventoryStockAdjustment>();
            try
            {
                if (_InventoryStockAdjustmentDataProvider != null)
                    InventoryStockAdjustmentCollection = _InventoryStockAdjustmentDataProvider.GetInventoryStockAdjustmentSearchListForRecipeItem(searchRequest);
                else
                {
                    InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryStockAdjustmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryStockAdjustmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryStockAdjustmentCollection;
        }

        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentIngridentListForRecipeItem(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryStockAdjustment> InventoryStockAdjustmentCollection = new BaseEntityCollectionResponse<InventoryStockAdjustment>();
            try
            {
                if (_InventoryStockAdjustmentDataProvider != null)
                    InventoryStockAdjustmentCollection = _InventoryStockAdjustmentDataProvider.GetInventoryStockAdjustmentIngridentListForRecipeItem(searchRequest);
                else
                {
                    InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryStockAdjustmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryStockAdjustmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryStockAdjustmentCollection;
        }


        public IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustmentXMLForRecipe(InventoryStockAdjustment item)
        {
            IBaseEntityResponse<InventoryStockAdjustment> entityResponse = new BaseEntityResponse<InventoryStockAdjustment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryStockAdjustmentBR.InsertXMLForRecipeInventoryStockAdjustmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryStockAdjustmentDataProvider.InsertInventoryStockAdjustmentXMLForRecipe(item);
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
        public IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryItemBatchMasterList(InventoryStockAdjustmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryStockAdjustment> InventoryStockAdjustmentCollection = new BaseEntityCollectionResponse<InventoryStockAdjustment>();
            try
            {
                if (_InventoryStockAdjustmentDataProvider != null)
                    InventoryStockAdjustmentCollection = _InventoryStockAdjustmentDataProvider.GetInventoryItemBatchMasterList(searchRequest);
                else
                {
                    InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryStockAdjustmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryStockAdjustmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryStockAdjustmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryStockAdjustmentCollection;
        }
    }
}
