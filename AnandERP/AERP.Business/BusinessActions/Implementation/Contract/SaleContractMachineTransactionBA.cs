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
    public class SaleContractMachineTransactionBA : ISaleContractMachineTransactionBA
    {
        ISaleContractMachineTransactionDataProvider _SaleContractMachineTransactionDataProvider;
        private ILogger _logException;

        public SaleContractMachineTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractMachineTransactionDataProvider = new SaleContractMachineTransactionDataProvider();
        }

        /// <summary>
        /// Create new record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractMachineTransaction> InsertSaleContractMachineTransaction(SaleContractMachineTransaction item)
        {
            IBaseEntityResponse<SaleContractMachineTransaction> entityResponse = new BaseEntityResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractMachineTransactionDataProvider.InsertSaleContractMachineTransaction(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Update a specific record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractMachineTransaction> UpdateSaleContractMachineTransaction(SaleContractMachineTransaction item)
        {
            IBaseEntityResponse<SaleContractMachineTransaction> entityResponse = new BaseEntityResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractMachineTransactionDataProvider.UpdateSaleContractMachineTransaction(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Delete a selected record from SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractMachineTransaction> DeleteSaleContractMachineTransaction(SaleContractMachineTransaction item)
        {
            IBaseEntityResponse<SaleContractMachineTransaction> entityResponse = new BaseEntityResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractMachineTransactionDataProvider.DeleteSaleContractMachineTransaction(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Select all record from SaleContractMachineTransaction table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetBySearch(SaleContractMachineTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMachineTransaction> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractMachineTransactionDataProvider.GetSaleContractMachineTransactionBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from SaleContractMachineTransaction table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetBySearchList(SaleContractMachineTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMachineTransaction> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractMachineTransactionDataProvider.GetSaleContractMachineTransactionGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


        /// <summary>
        /// Select a record from SaleContractMachineTransaction table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractMachineTransaction> SelectByID(SaleContractMachineTransaction item)
        {

            IBaseEntityResponse<SaleContractMachineTransaction> entityResponse = new BaseEntityResponse<SaleContractMachineTransaction>();
            try
            {
                entityResponse = _SaleContractMachineTransactionDataProvider.GetSaleContractMachineTransactionByID(item);
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

        public IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetMachineMasterBySearchWord(SaleContractMachineTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMachineTransaction> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractMachineTransactionDataProvider.GetMachineMasterBySearchWord(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetListSaleContractMachineTransaction(SaleContractMachineTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMachineTransaction> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractMachineTransactionDataProvider.GetListSaleContractMachineTransaction(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


         public IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetListSaleContractMachineAttendance(SaleContractMachineTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMachineTransaction> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractMachineTransactionDataProvider.GetListSaleContractMachineAttendance(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        public IBaseEntityResponse<SaleContractMachineTransaction> RemoveSaleContractMachineTransaction(SaleContractMachineTransaction item)
        {
            IBaseEntityResponse<SaleContractMachineTransaction> entityResponse = new BaseEntityResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractMachineTransactionDataProvider.RemoveSaleContractMachineTransaction(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        public IBaseEntityResponse<SaleContractMachineTransaction> AddMachineInSaleContract(SaleContractMachineTransaction item)
        {
            IBaseEntityResponse<SaleContractMachineTransaction> entityResponse = new BaseEntityResponse<SaleContractMachineTransaction>();
            try
            {
                if (_SaleContractMachineTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractMachineTransactionDataProvider.AddMachineInSaleContract(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
    }
}