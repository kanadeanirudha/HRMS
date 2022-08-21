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
    public class TillReportBA : ITillReportBA
    {
        ITillReportDataProvider _TillReportDataProvider;
        private ILogger _logException;
        public TillReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _TillReportDataProvider = new TillReportDataProvider();
        }

        public IBaseEntityCollectionResponse<TillReport> GetTillReport(TillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TillReport> TillReportCollection = new BaseEntityCollectionResponse<TillReport>();
            try
            {
                if (_TillReportDataProvider != null)
                    TillReportCollection = _TillReportDataProvider.GetTillReport(searchRequest);
                else
                {
                    TillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    TillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                TillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                TillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TillReportCollection;
        }

        public IBaseEntityResponse<TillReport> TillReportGetData(TillReport item)
        {
            IBaseEntityResponse<TillReport> entityResponse = new BaseEntityResponse<TillReport>();
            try
            {
                if (_TillReportDataProvider != null)
                {
                    entityResponse = _TillReportDataProvider.TillReportGetData(item);
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

        public IBaseEntityResponse<TillReport> TillReportSaveData(TillReport item)
        {
            IBaseEntityResponse<TillReport> entityResponse = new BaseEntityResponse<TillReport>();
            try
            {
                if (_TillReportDataProvider != null)
                {
                    entityResponse = _TillReportDataProvider.TillReportSaveData(item);
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
    }
}
