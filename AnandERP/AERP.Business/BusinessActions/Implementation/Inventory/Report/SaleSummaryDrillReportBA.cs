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
    public class SaleSummaryDrillReportBA : ISaleSummaryDrillReportBA
    {
        ISaleSummaryDrillReportDataProvider _SaleSummaryDrillReportDataProvider;
        private ILogger _logException;
        public SaleSummaryDrillReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleSummaryDrillReportDataProvider = new SaleSummaryDrillReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_YearList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> RetailReportsCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
            try
            {
                if (_SaleSummaryDrillReportDataProvider != null)
                    RetailReportsCollection = _SaleSummaryDrillReportDataProvider.GetSaleSummaryDrillReport_YearList(searchRequest);
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
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_MonthList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> RetailReportsCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
            try
            {
                if (_SaleSummaryDrillReportDataProvider != null)
                    RetailReportsCollection = _SaleSummaryDrillReportDataProvider.GetSaleSummaryDrillReport_MonthList(searchRequest);
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
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_DayList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> RetailReportsCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
            try
            {
                if (_SaleSummaryDrillReportDataProvider != null)
                    RetailReportsCollection = _SaleSummaryDrillReportDataProvider.GetSaleSummaryDrillReport_DayList(searchRequest);
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
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_BillList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> RetailReportsCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
            try
            {
                if (_SaleSummaryDrillReportDataProvider != null)
                    RetailReportsCollection = _SaleSummaryDrillReportDataProvider.GetSaleSummaryDrillReport_BillList(searchRequest);
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
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> RetailReportsCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
            try
            {
                if (_SaleSummaryDrillReportDataProvider != null)
                    RetailReportsCollection = _SaleSummaryDrillReportDataProvider.GetSaleSummaryDrillReport_ItemList(searchRequest);
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

        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemListSaleReturn(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleSummaryDrillReport> RetailReportsCollection = new BaseEntityCollectionResponse<SaleSummaryDrillReport>();
            try
            {
                if (_SaleSummaryDrillReportDataProvider != null)
                    RetailReportsCollection = _SaleSummaryDrillReportDataProvider.GetSaleSummaryDrillReport_ItemListSaleReturn(searchRequest);
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
