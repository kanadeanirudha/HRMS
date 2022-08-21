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
    public class InventoryProductionMasterAndTransactionBA : IInventoryProductionMasterAndTransactionBA
    {
        IInventoryProductionMasterAndTransactionDataProvider _InventoryProductionMasterAndTransactionDataProvider;
        IInventoryProductionMasterAndTransactionBR _InventoryProductionMasterAndTransactionBR;
        private ILogger _logException;
        public InventoryProductionMasterAndTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryProductionMasterAndTransactionBR = new InventoryProductionMasterAndTransactionBR();
            _InventoryProductionMasterAndTransactionDataProvider = new InventoryProductionMasterAndTransactionDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryProductionMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryProductionMasterAndTransaction> InsertInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryProductionMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryProductionMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryProductionMasterAndTransactionBR.InsertInventoryProductionMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryProductionMasterAndTransactionDataProvider.InsertInventoryProductionMasterAndTransaction(item);
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
        /// Update a specific record  of InventoryProductionMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryProductionMasterAndTransaction> UpdateInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryProductionMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryProductionMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryProductionMasterAndTransactionBR.UpdateInventoryProductionMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryProductionMasterAndTransactionDataProvider.UpdateInventoryProductionMasterAndTransaction(item);
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
        /// Delete a selected record from InventoryProductionMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryProductionMasterAndTransaction> DeleteInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryProductionMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryProductionMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryProductionMasterAndTransactionBR.DeleteInventoryProductionMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryProductionMasterAndTransactionDataProvider.DeleteInventoryProductionMasterAndTransaction(item);
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
        /// Select all record from InventoryProductionMasterAndTransaction table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetBySearch(InventoryProductionMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> InventoryProductionMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryProductionMasterAndTransaction>();
            try
            {
                if (_InventoryProductionMasterAndTransactionDataProvider != null)
                    InventoryProductionMasterAndTransactionCollection = _InventoryProductionMasterAndTransactionDataProvider.GetInventoryProductionMasterAndTransactionBySearch(searchRequest);
                else
                {
                    InventoryProductionMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryProductionMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryProductionMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryProductionMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryProductionMasterAndTransactionCollection;
        }

        public IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetInventoryProductionMasterAndTransactionSearchList(InventoryProductionMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> InventoryProductionMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryProductionMasterAndTransaction>();
            try
            {
                if (_InventoryProductionMasterAndTransactionDataProvider != null)
                    InventoryProductionMasterAndTransactionCollection = _InventoryProductionMasterAndTransactionDataProvider.GetInventoryProductionMasterAndTransactionSearchList(searchRequest);
                else
                {
                    InventoryProductionMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryProductionMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryProductionMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryProductionMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryProductionMasterAndTransactionCollection;
        }
        /// <summary>
        /// Select a record from InventoryProductionMasterAndTransaction table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryProductionMasterAndTransaction> SelectByID(InventoryProductionMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryProductionMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryProductionMasterAndTransaction>();
            try
            {
                entityResponse = _InventoryProductionMasterAndTransactionDataProvider.GetInventoryProductionMasterAndTransactionByID(item);
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

        public IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> SelectIngridentsByVarients(InventoryProductionMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> InventoryProductionMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryProductionMasterAndTransaction>();
            try
            {
                if (_InventoryProductionMasterAndTransactionDataProvider != null)
                    InventoryProductionMasterAndTransactionCollection = _InventoryProductionMasterAndTransactionDataProvider.GetIngridentsListByVarients(searchRequest);
                else
                {
                    InventoryProductionMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryProductionMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryProductionMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryProductionMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryProductionMasterAndTransactionCollection;
        }

        //public IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetUnitsByItemNumber(InventoryProductionMasterAndTransactionSearchRequest searchRequest)
        //{
        //    IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> InventoryProductionMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryProductionMasterAndTransaction>();
        //    try
        //    {
        //        if (_InventoryProductionMasterAndTransactionDataProvider != null)
        //            InventoryProductionMasterAndTransactionCollection = _InventoryProductionMasterAndTransactionDataProvider.GetUnitsByItemNumber(searchRequest);
        //        else
        //        {
        //            InventoryProductionMasterAndTransactionCollection.Message.Add(new MessageDTO
        //            {
        //                ErrorMessage = Resources.Null_Object_Exception,
        //                MessageType = MessageTypeEnum.Error
        //            });
        //            InventoryProductionMasterAndTransactionCollection.CollectionResponse = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        InventoryProductionMasterAndTransactionCollection.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        InventoryProductionMasterAndTransactionCollection.CollectionResponse = null;
        //        if (_logException != null)
        //        {
        //            _logException.Error(ex.Message);
        //        }
        //    }
        //    return InventoryProductionMasterAndTransactionCollection;
        //}
    }
}
