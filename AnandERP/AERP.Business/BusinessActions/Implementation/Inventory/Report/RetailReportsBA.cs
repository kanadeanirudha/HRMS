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
    public class RetailReportsBA : IRetailReportsBA
    {
        IRetailReportsDataProvider _RetailReportsDataProvider;
        private ILogger _logException;
        public RetailReportsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RetailReportsDataProvider = new RetailReportsDataProvider();
        }

        public IBaseEntityCollectionResponse<RetailReports> GetRetailReportsBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetRetailReportsBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryDaysOfCoverReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetInventoryDaysOfCoverReportBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }

        public IBaseEntityCollectionResponse<RetailReports> GetInventoryBillDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetInventoryBillDetailReportBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryCounterDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetInventoryCounterDetailReportBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetRetailSalesAndMarginReportsBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetRetailSalesAndMarginReportsBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryDiscountReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetInventoryDiscountReportBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryStockGapAnalysisReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetInventoryStockGapAnalysisReportBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetVendorServiceLevelBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetVendorServiceLevelBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        //For TakeAwayVsFineDiningReport 
        public IBaseEntityCollectionResponse<RetailReports> GetRetailReportsBySearch_GetDinningReportList(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetRetailReportsBySearch_GetDinningReportList(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }

        public IBaseEntityCollectionResponse<RetailReports> GetConsumptionDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetConsumptionDetailReportBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }

        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetSaleSummaryReportBySearch(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch_DateWise(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetSaleSummaryReportBySearch_DateWise(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch_OrderNoWise(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetSaleSummaryReportBySearch_OrderNoWise(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
        //public IBaseEntityCollectionResponse<RetailReports> GetInventoryCurrentStockAmount(RetailReportsSearchRequest searchRequest)
        //{
        //    IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
        //    try
        //    {
        //        if (_RetailReportsDataProvider != null)
        //            RetailReportsCollection = _RetailReportsDataProvider.GetInventoryCurrentStockAmount(searchRequest);
        //        else
        //        {
        //            RetailReportsCollection.Message.Add(new MessageDTO
        //            {
        //                ErrorMessage = Resources.Null_Object_Exception,
        //                MessageType = MessageTypeEnum.Error
        //            });
        //            RetailReportsCollection.CollectionResponse = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RetailReportsCollection.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        RetailReportsCollection.CollectionResponse = null;
        //        if (_logException != null)
        //        {
        //            _logException.Error(ex.Message);
        //        }
        //    }
        //    return RetailReportsCollection;
        //}

        public IBaseEntityCollectionResponse<RetailReports> GetVendorWiseSaleAndPurchaseReport(RetailReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailReports> RetailReportsCollection = new BaseEntityCollectionResponse<RetailReports>();
            try
            {
                if (_RetailReportsDataProvider != null)
                    RetailReportsCollection = _RetailReportsDataProvider.GetVendorWiseSaleAndPurchaseReport(searchRequest);
                else
                {
                    RetailReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailReportsCollection;
        }
    }
}
