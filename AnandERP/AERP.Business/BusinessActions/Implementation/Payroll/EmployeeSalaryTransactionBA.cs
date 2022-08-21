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
    public class EmployeeSalaryTransactionBA : IEmployeeSalaryTransactionBA
    {
        IEmployeeSalaryTransactionDataProvider _EmployeeSalaryTransactionDataProvider;
        private ILogger _logException;

        public EmployeeSalaryTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeeSalaryTransactionDataProvider = new EmployeeSalaryTransactionDataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetEmployeeSalaryTransactionBySearch(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> EmployeeSalaryTransactionCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                    EmployeeSalaryTransactionCollection = _EmployeeSalaryTransactionDataProvider.GetEmployeeSalaryTransactionBySearch(searchRequest);
                else
                {
                    EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalaryTransactionCollection;
        }

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionForGeneration(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> EmployeeSalaryTransactionCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                    EmployeeSalaryTransactionCollection = _EmployeeSalaryTransactionDataProvider.GetSalaryTransactionForGeneration(searchRequest);
                else
                {
                    EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalaryTransactionCollection;
        }
        public IBaseEntityResponse<EmployeeSalaryTransaction> GenerateEmployeeSalaryTransaction(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> entityResponse = new BaseEntityResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                {
                    entityResponse = _EmployeeSalaryTransactionDataProvider.GenerateEmployeeSalaryTransaction(item);
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

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsByID(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> EmployeeSalaryTransactionCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                    EmployeeSalaryTransactionCollection = _EmployeeSalaryTransactionDataProvider.GetSalaryTransactionDetailsByID(searchRequest);
                else
                {
                    EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalaryTransactionCollection;
        }
        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionForBulkGeneration(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> EmployeeSalaryTransactionCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                    EmployeeSalaryTransactionCollection = _EmployeeSalaryTransactionDataProvider.GetSalaryTransactionForBulkGeneration(searchRequest);
                else
                {
                    EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalaryTransactionCollection;
        }

        public IBaseEntityResponse<EmployeeSalaryTransaction> GenerateSaleContractBulkSalaryTransaction(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> entityResponse = new BaseEntityResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                {
                    entityResponse = _EmployeeSalaryTransactionDataProvider.GenerateSaleContractBulkSalaryTransaction(item);
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

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsForSalarySheet(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> EmployeeSalaryTransactionCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                    EmployeeSalaryTransactionCollection = _EmployeeSalaryTransactionDataProvider.GetSalaryTransactionDetailsForSalarySheet(searchRequest);
                else
                {
                    EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalaryTransactionCollection;
        }


        public IBaseEntityResponse<EmployeeSalaryTransaction> DeleteEmployeeSalary(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> entityResponse = new BaseEntityResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                {
                    entityResponse = _EmployeeSalaryTransactionDataProvider.DeleteEmployeeSalary(item);
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

        public IBaseEntityResponse<EmployeeSalaryTransaction> AddSaleContractSalaryTransactionDeduction(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> entityResponse = new BaseEntityResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                {
                    entityResponse = _EmployeeSalaryTransactionDataProvider.AddEmployeeSalaryTransactionDeduction(item);
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


        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetEmployeeSalaryDetailsForExcel(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> EmployeeSalaryDetailsForExcelCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                {
                    EmployeeSalaryDetailsForExcelCollection = _EmployeeSalaryTransactionDataProvider.GetEmployeeSalarySheetExcel(searchRequest);
                }
                else
                {
                    EmployeeSalaryDetailsForExcelCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalaryDetailsForExcelCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalaryDetailsForExcelCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                EmployeeSalaryDetailsForExcelCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalaryDetailsForExcelCollection;
        }


        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsForNRSheet(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> EmployeeSalaryTransactionCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                    EmployeeSalaryTransactionCollection = _EmployeeSalaryTransactionDataProvider.GetSalaryTransactionDetailsForNRSheet(searchRequest);
                else
                {
                    EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalaryTransactionCollection;
        }

        public IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetListEmployeeSalaryTransactionDeduction(EmployeeSalaryTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryTransaction> EmployeeSalaryTransactionCollection = new BaseEntityCollectionResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                    EmployeeSalaryTransactionCollection = _EmployeeSalaryTransactionDataProvider.GetListEmployeeSalaryTransactionDeduction(searchRequest);
                else
                {
                    EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalaryTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalaryTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSalaryTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalaryTransactionCollection;
        }

        public IBaseEntityResponse<EmployeeSalaryTransaction> AddEmployeeSalaryTransactionDeduction(EmployeeSalaryTransaction item)
        {
            IBaseEntityResponse<EmployeeSalaryTransaction> entityResponse = new BaseEntityResponse<EmployeeSalaryTransaction>();
            try
            {
                if (_EmployeeSalaryTransactionDataProvider != null)
                {
                    entityResponse = _EmployeeSalaryTransactionDataProvider.AddEmployeeSalaryTransactionDeduction(item);
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