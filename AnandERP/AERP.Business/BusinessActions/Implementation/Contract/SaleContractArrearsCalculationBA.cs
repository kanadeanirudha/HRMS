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
    public class SaleContractArrearsCalculationBA : ISaleContractArrearsCalculationBA
    {
        ISaleContractArrearsCalculationDataProvider _SaleContractArrearsCalculationDataProvider;
        private ILogger _logException;

        public SaleContractArrearsCalculationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractArrearsCalculationDataProvider = new SaleContractArrearsCalculationDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSaleContractArrearsCalculationBySearch(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetSaleContractArrearsCalculationBySearch(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionForGeneration(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetSalaryTransactionForGeneration(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }
        public IBaseEntityResponse<SaleContractArrearsCalculation> GenerateSaleContractArrearsCalculation(SaleContractArrearsCalculation item)
        {
            IBaseEntityResponse<SaleContractArrearsCalculation> entityResponse = new BaseEntityResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                {
                    entityResponse = _SaleContractArrearsCalculationDataProvider.GenerateSaleContractArrearsCalculation(item);
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsByID(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetSalaryTransactionDetailsByID(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }
        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionForBulkGeneration(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetSalaryTransactionForBulkGeneration(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }

        public IBaseEntityResponse<SaleContractArrearsCalculation> GenerateSaleContractBulkSalaryTransaction(SaleContractArrearsCalculation item)
        {
            IBaseEntityResponse<SaleContractArrearsCalculation> entityResponse = new BaseEntityResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                {
                    entityResponse = _SaleContractArrearsCalculationDataProvider.GenerateSaleContractBulkSalaryTransaction(item);
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsForSalarySheet(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetSalaryTransactionDetailsForSalarySheet(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsForNRSheet(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetSalaryTransactionDetailsForNRSheet(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetListSaleContractArrearsCalculationDeduction(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetListSaleContractArrearsCalculationDeduction(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }

        public IBaseEntityResponse<SaleContractArrearsCalculation> AddSaleContractArrearsCalculationDeduction(SaleContractArrearsCalculation item)
        {
            IBaseEntityResponse<SaleContractArrearsCalculation> entityResponse = new BaseEntityResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                {
                    entityResponse = _SaleContractArrearsCalculationDataProvider.AddSaleContractArrearsCalculationDeduction(item);
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

        public IBaseEntityResponse<SaleContractArrearsCalculation> AddSaleContractArrearsAttendance(SaleContractArrearsCalculation item)
        {
            IBaseEntityResponse<SaleContractArrearsCalculation> entityResponse = new BaseEntityResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                {
                    entityResponse = _SaleContractArrearsCalculationDataProvider.AddSaleContractArrearsAttendance(item);
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

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSaleContractArrearsAttendanceSpanWise(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetSaleContractArrearsAttendanceSpanWise(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetAttendanceListForSpanWise(SaleContractArrearsCalculationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> SaleContractArrearsCalculationCollection = new BaseEntityCollectionResponse<SaleContractArrearsCalculation>();
            try
            {
                if (_SaleContractArrearsCalculationDataProvider != null)
                    SaleContractArrearsCalculationCollection = _SaleContractArrearsCalculationDataProvider.GetAttendanceListForSpanWise(searchRequest);
                else
                {
                    SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractArrearsCalculationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractArrearsCalculationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractArrearsCalculationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractArrearsCalculationCollection;
        }
    }
}