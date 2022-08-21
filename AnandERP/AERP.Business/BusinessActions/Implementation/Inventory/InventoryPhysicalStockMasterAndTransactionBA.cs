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
    public class InventoryPhysicalStockMasterAndTransactionBA : IInventoryPhysicalStockMasterAndTransactionBA
    {
        IInventoryPhysicalStockMasterAndTransactionDataProvider _InventoryPhysicalStockMasterAndTransactionDataProvider;
        IInventoryPhysicalStockMasterAndTransactionBR _InventoryPhysicalStockMasterAndTransactionBR;
        private ILogger _logException;
        public InventoryPhysicalStockMasterAndTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryPhysicalStockMasterAndTransactionBR = new InventoryPhysicalStockMasterAndTransactionBR();
            _InventoryPhysicalStockMasterAndTransactionDataProvider = new InventoryPhysicalStockMasterAndTransactionDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryPhysicalStockMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> InsertInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPhysicalStockMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryPhysicalStockMasterAndTransactionBR.InsertInventoryPhysicalStockMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryPhysicalStockMasterAndTransactionDataProvider.InsertInventoryPhysicalStockMasterAndTransaction(item);
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
        /// Update a specific record  of InventoryPhysicalStockMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> UpdateInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPhysicalStockMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryPhysicalStockMasterAndTransactionBR.UpdateInventoryPhysicalStockMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryPhysicalStockMasterAndTransactionDataProvider.UpdateInventoryPhysicalStockMasterAndTransaction(item);
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
        /// Delete a selected record from InventoryPhysicalStockMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> DeleteInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPhysicalStockMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryPhysicalStockMasterAndTransactionBR.DeleteInventoryPhysicalStockMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryPhysicalStockMasterAndTransactionDataProvider.DeleteInventoryPhysicalStockMasterAndTransaction(item);
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
        /// Select all record from InventoryPhysicalStockMasterAndTransaction table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetBySearch(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> InventoryPhysicalStockMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction>();
            try
            {
                if (_InventoryPhysicalStockMasterAndTransactionDataProvider != null)
                    InventoryPhysicalStockMasterAndTransactionCollection = _InventoryPhysicalStockMasterAndTransactionDataProvider.GetInventoryPhysicalStockMasterAndTransactionBySearch(searchRequest);
                else
                {
                    InventoryPhysicalStockMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryPhysicalStockMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryPhysicalStockMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryPhysicalStockMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryPhysicalStockMasterAndTransactionCollection;
        }

        public IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryPhysicalStockMasterAndTransactionSearchList(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> InventoryPhysicalStockMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction>();
            try
            {
                if (_InventoryPhysicalStockMasterAndTransactionDataProvider != null)
                    InventoryPhysicalStockMasterAndTransactionCollection = _InventoryPhysicalStockMasterAndTransactionDataProvider.GetInventoryPhysicalStockMasterAndTransactionSearchList(searchRequest);
                else
                {
                    InventoryPhysicalStockMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryPhysicalStockMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryPhysicalStockMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryPhysicalStockMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryPhysicalStockMasterAndTransactionCollection;
        }
        /// <summary>
        /// Select a record from InventoryPhysicalStockMasterAndTransaction table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> SelectByID(InventoryPhysicalStockMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPhysicalStockMasterAndTransaction>();
            try
            {
                entityResponse = _InventoryPhysicalStockMasterAndTransactionDataProvider.GetInventoryPhysicalStockMasterAndTransactionByID(item);
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


        public IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryStockDetails(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> InventoryPhysicalStockMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction>();
            try
            {
                if (_InventoryPhysicalStockMasterAndTransactionDataProvider != null)
                    InventoryPhysicalStockMasterAndTransactionCollection = _InventoryPhysicalStockMasterAndTransactionDataProvider.GetInventoryStockDetails(searchRequest);
                else
                {
                    InventoryPhysicalStockMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryPhysicalStockMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryPhysicalStockMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryPhysicalStockMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryPhysicalStockMasterAndTransactionCollection;
        }

    
    
    }
}
