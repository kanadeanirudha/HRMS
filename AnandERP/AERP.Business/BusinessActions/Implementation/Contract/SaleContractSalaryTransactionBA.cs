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
    public class SaleContractSalaryTransactionBA : ISaleContractSalaryTransactionBA
    {
        ISaleContractSalaryTransactionDataProvider _SaleContractSalaryTransactionDataProvider;
        private ILogger _logException;

        public SaleContractSalaryTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractSalaryTransactionDataProvider = new SaleContractSalaryTransactionDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSaleContractSalaryTransactionBySearch(SaleContractSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> SaleContractSalaryTransactionCollection = new BaseEntityCollectionResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                    SaleContractSalaryTransactionCollection = _SaleContractSalaryTransactionDataProvider.GetSaleContractSalaryTransactionBySearch(searchRequest);
                else
                {
                    SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryTransactionCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionForGeneration(SaleContractSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> SaleContractSalaryTransactionCollection = new BaseEntityCollectionResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                    SaleContractSalaryTransactionCollection = _SaleContractSalaryTransactionDataProvider.GetSalaryTransactionForGeneration(searchRequest);
                else
                {
                    SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryTransactionCollection;
        }
        public IBaseEntityResponse<SaleContractSalaryTransaction> GenerateSaleContractSalaryTransaction(SaleContractSalaryTransaction item)
        {
            IBaseEntityResponse<SaleContractSalaryTransaction> entityResponse = new BaseEntityResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractSalaryTransactionDataProvider.GenerateSaleContractSalaryTransaction(item);
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

        public IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionDetailsByID(SaleContractSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> SaleContractSalaryTransactionCollection = new BaseEntityCollectionResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                    SaleContractSalaryTransactionCollection = _SaleContractSalaryTransactionDataProvider.GetSalaryTransactionDetailsByID(searchRequest);
                else
                {
                    SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryTransactionCollection;
        }
        public IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionForBulkGeneration(SaleContractSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> SaleContractSalaryTransactionCollection = new BaseEntityCollectionResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                    SaleContractSalaryTransactionCollection = _SaleContractSalaryTransactionDataProvider.GetSalaryTransactionForBulkGeneration(searchRequest);
                else
                {
                    SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryTransactionCollection;
        }

        public IBaseEntityResponse<SaleContractSalaryTransaction> GenerateSaleContractBulkSalaryTransaction(SaleContractSalaryTransaction item)
        {
            IBaseEntityResponse<SaleContractSalaryTransaction> entityResponse = new BaseEntityResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractSalaryTransactionDataProvider.GenerateSaleContractBulkSalaryTransaction(item);
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

        public IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionDetailsForSalarySheet(SaleContractSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> SaleContractSalaryTransactionCollection = new BaseEntityCollectionResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                    SaleContractSalaryTransactionCollection = _SaleContractSalaryTransactionDataProvider.GetSalaryTransactionDetailsForSalarySheet(searchRequest);
                else
                {
                    SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryTransactionCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionDetailsForNRSheet(SaleContractSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> SaleContractSalaryTransactionCollection = new BaseEntityCollectionResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                    SaleContractSalaryTransactionCollection = _SaleContractSalaryTransactionDataProvider.GetSalaryTransactionDetailsForNRSheet(searchRequest);
                else
                {
                    SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryTransactionCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetListSaleContractSalaryTransactionDeduction(SaleContractSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> SaleContractSalaryTransactionCollection = new BaseEntityCollectionResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                    SaleContractSalaryTransactionCollection = _SaleContractSalaryTransactionDataProvider.GetListSaleContractSalaryTransactionDeduction(searchRequest);
                else
                {
                    SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryTransactionCollection;
        }

        public IBaseEntityResponse<SaleContractSalaryTransaction> AddSaleContractSalaryTransactionDeduction(SaleContractSalaryTransaction item)
        {
            IBaseEntityResponse<SaleContractSalaryTransaction> entityResponse = new BaseEntityResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractSalaryTransactionDataProvider.AddSaleContractSalaryTransactionDeduction(item);
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

        public IBaseEntityResponse<SaleContractSalaryTransaction> SaveSaleContractSalaryTransaction(SaleContractSalaryTransaction item)
        {
            IBaseEntityResponse<SaleContractSalaryTransaction> entityResponse = new BaseEntityResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractSalaryTransactionDataProvider.SaveSaleContractSalaryTransaction(item);
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

        public IBaseEntityResponse<SaleContractSalaryTransaction> SaveSaleContractBulkSalaryTransaction(SaleContractSalaryTransaction item)
        {
            IBaseEntityResponse<SaleContractSalaryTransaction> entityResponse = new BaseEntityResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                {
                    entityResponse = _SaleContractSalaryTransactionDataProvider.SaveSaleContractBulkSalaryTransaction(item);
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
        public IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionDetailsForAllEmployeeinExcel(SaleContractSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> SaleContractSalaryTransactionCollection = new BaseEntityCollectionResponse<SaleContractSalaryTransaction>();
            try
            {
                if (_SaleContractSalaryTransactionDataProvider != null)
                    SaleContractSalaryTransactionCollection = _SaleContractSalaryTransactionDataProvider.GetSalaryTransactionDetailsForAllEmployeeinExcel(searchRequest);
                else
                {
                    SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryTransactionCollection;
        }
    }
}