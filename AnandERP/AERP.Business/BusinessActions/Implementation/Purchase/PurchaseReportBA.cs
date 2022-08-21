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
    public class PurchaseReportBA : IPurchaseReportBA
    {
        IPurchaseReportDataProvider PurchaseReportDataProvider;

        private ILogger _logException;

        public PurchaseReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            PurchaseReportDataProvider = new PurchaseReportDataProvider();
        }

        //PurchaseReport

        public IBaseEntityCollectionResponse<PurchaseReport> GetTopFiveVendorReport(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<PurchaseReport>();
            try
            {
                if (PurchaseReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = PurchaseReportDataProvider.GetTopFiveVendorReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyPurchaseReport(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<PurchaseReport>();
            try
            {
                if (PurchaseReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = PurchaseReportDataProvider.GetMonthlyPurchaseReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseReport> GetRequisitionConversionReport(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<PurchaseReport>();
            try
            {
                if (PurchaseReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = PurchaseReportDataProvider.GetRequisitionConversionReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseReport> GetPurchaseOrderConversionReport(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<PurchaseReport>();
            try
            {
                if (PurchaseReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = PurchaseReportDataProvider.GetPurchaseOrderConversionReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }

        public IBaseEntityResponse<PurchaseReport> PurchaseReportSparkLineChartReportByEmployeeID(PurchaseReport item)
        {
            IBaseEntityResponse<PurchaseReport> entityResponse = new BaseEntityResponse<PurchaseReport>();
            try
            {
                entityResponse = PurchaseReportDataProvider.PurchaseReportSparkLineChartReportByEmployeeID(item);
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


        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyMarginDetails(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<PurchaseReport>();
            try
            {
                if (PurchaseReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = PurchaseReportDataProvider.GetMonthlyMarginDetails(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }


        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyPurchaseOrderDetails(PurchaseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<PurchaseReport>();
            try
            {
                if (PurchaseReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = PurchaseReportDataProvider.GetMonthlyPurchaseOrderDetails(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }

    }
}
