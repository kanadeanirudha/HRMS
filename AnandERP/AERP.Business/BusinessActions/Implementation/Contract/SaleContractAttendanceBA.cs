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
    public class SaleContractAttendanceBA : ISaleContractAttendanceBA
    {
        ISaleContractAttendanceDataProvider _SaleContractAttendanceDataProvider;
        private ILogger _logException;

        public SaleContractAttendanceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractAttendanceDataProvider = new SaleContractAttendanceDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetMonthListBySaleContractMaster(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> SaleContractAttendanceCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                    SaleContractAttendanceCollection = _SaleContractAttendanceDataProvider.GetMonthListBySaleContractMaster(searchRequest);
                else
                {
                    SaleContractAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractAttendanceCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendance(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> SaleContractAttendanceCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                    SaleContractAttendanceCollection = _SaleContractAttendanceDataProvider.GetSaleContractAttendance(searchRequest);
                else
                {
                    SaleContractAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractAttendanceCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForAttendanceDate(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> SaleContractAttendanceCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                    SaleContractAttendanceCollection = _SaleContractAttendanceDataProvider.GetAttendanceListForAttendanceDate(searchRequest);
                else
                {
                    SaleContractAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractAttendanceCollection;
        }

        public IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendance(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> entityResponse = new BaseEntityResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractAttendanceDataProvider.InsertSaleContractAttendance(item);
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForMonthWise(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> SaleContractAttendanceCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                    SaleContractAttendanceCollection = _SaleContractAttendanceDataProvider.GetAttendanceListForMonthWise(searchRequest);
                else
                {
                    SaleContractAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractAttendanceCollection;
        }

        public IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendanceMonthWise(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> entityResponse = new BaseEntityResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractAttendanceDataProvider.InsertSaleContractAttendanceMonthWise(item);
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

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendanceMonthWise(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> SaleContractAttendanceCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                    SaleContractAttendanceCollection = _SaleContractAttendanceDataProvider.GetSaleContractAttendanceMonthWise(searchRequest);
                else
                {
                    SaleContractAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractAttendanceCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendanceSpanWise(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> SaleContractAttendanceCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                    SaleContractAttendanceCollection = _SaleContractAttendanceDataProvider.GetSaleContractAttendanceSpanWise(searchRequest);
                else
                {
                    SaleContractAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractAttendanceCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetSpanListBySaleContractMaster(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> SaleContractAttendanceCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                    SaleContractAttendanceCollection = _SaleContractAttendanceDataProvider.GetSpanListBySaleContractMaster(searchRequest);
                else
                {
                    SaleContractAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractAttendanceCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForSpanWise(SaleContractAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractAttendance> SaleContractAttendanceCollection = new BaseEntityCollectionResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                    SaleContractAttendanceCollection = _SaleContractAttendanceDataProvider.GetAttendanceListForSpanWise(searchRequest);
                else
                {
                    SaleContractAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractAttendanceCollection;
        }

        public IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendanceSpanWise(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> entityResponse = new BaseEntityResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractAttendanceDataProvider.InsertSaleContractAttendanceSpanWise(item);
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

        public IBaseEntityResponse<SaleContractAttendance> InsertSaleContractSplitSalarySpan(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> entityResponse = new BaseEntityResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractAttendanceDataProvider.InsertSaleContractSplitSalarySpan(item);
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

        public IBaseEntityResponse<SaleContractAttendance> GetSalaryForManPowerItem(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> entityResponse = new BaseEntityResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractAttendanceDataProvider.GetSalaryForManPowerItem(item);
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

        public IBaseEntityResponse<SaleContractAttendance> InsertSalaryForManPowerItem(SaleContractAttendance item)
        {
            IBaseEntityResponse<SaleContractAttendance> entityResponse = new BaseEntityResponse<SaleContractAttendance>();
            try
            {
                if (_SaleContractAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractAttendanceDataProvider.InsertSalaryForManPowerItem(item);
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