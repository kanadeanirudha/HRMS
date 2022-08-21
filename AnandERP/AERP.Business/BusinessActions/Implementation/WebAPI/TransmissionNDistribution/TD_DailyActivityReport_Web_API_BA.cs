using AERP.Base.DTO;
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
    public class TD_DailyActivityReport_Web_API_BA : ITD_DailyActivityReport_Web_API_BA
    {
        private ILogger _logException;
        private ITD_DailyActivityReport_Web_API_DataProvider _ITD_DailyActivityReport_Web_API_DataProvider;
        public TD_DailyActivityReport_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ITD_DailyActivityReport_Web_API_DataProvider = new TD_DailyActivityReport_Web_API_DataProvider();
        }
        public IBaseEntityResponse<DailyActivityReport> InsertDailyActivityReport(DailyActivityReport item)
        {
            IBaseEntityResponse<DailyActivityReport> entityResponse = new BaseEntityResponse<DailyActivityReport>();
            try
            {
                entityResponse = _ITD_DailyActivityReport_Web_API_DataProvider.InsertDailyActivityReport(item);
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

        public IBaseEntityResponse<DailyActivityReport> InsertScheduleActivity(DailyActivityReport item)
        {
            IBaseEntityResponse<DailyActivityReport> entityResponse = new BaseEntityResponse<DailyActivityReport>();
            try
            {
                entityResponse = _ITD_DailyActivityReport_Web_API_DataProvider.InsertScheduleActivity(item);
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

        public IBaseEntityCollectionResponse<DailyActivityReport> GetWorkHistory(DailyActivityReport item)
        {
            IBaseEntityCollectionResponse<DailyActivityReport> DailyActivityReportCollection = new BaseEntityCollectionResponse<DailyActivityReport>();
            try
            {
                if (_ITD_DailyActivityReport_Web_API_DataProvider != null)
                    DailyActivityReportCollection = _ITD_DailyActivityReport_Web_API_DataProvider.GetWorkHistory(item);
                else
                {
                    DailyActivityReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DailyActivityReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DailyActivityReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DailyActivityReportCollection;
        }

        public IBaseEntityCollectionResponse<DailyActivityReport> GetWorkDetails(DailyActivityReport item)
        {
            IBaseEntityCollectionResponse<DailyActivityReport> DailyActivityReportCollection = new BaseEntityCollectionResponse<DailyActivityReport>();
            try
            {
                if (_ITD_DailyActivityReport_Web_API_DataProvider != null)
                    DailyActivityReportCollection = _ITD_DailyActivityReport_Web_API_DataProvider.GetWorkDetails(item);
                else
                {
                    DailyActivityReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DailyActivityReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DailyActivityReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DailyActivityReportCollection;
        }
    }
}
