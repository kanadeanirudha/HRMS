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
    public class EnterpriseDrillThroughReportBA : IEnterpriseDrillThroughReportBA
    {
          IEnterpriseDrillThroughReportDataProvider _EnterpriseDrillThroughReportDataProvider;
        private ILogger _logException;
        public EnterpriseDrillThroughReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EnterpriseDrillThroughReportDataProvider = new EnterpriseDrillThroughReportDataProvider();
        }
        
        public IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Centre(EnterpriseDrillThroughReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> EnterpriseDrillThroughReportCollection = new BaseEntityCollectionResponse<EnterpriseDrillThroughReport>();
            try
            {
                if (_EnterpriseDrillThroughReportDataProvider != null)
                    EnterpriseDrillThroughReportCollection = _EnterpriseDrillThroughReportDataProvider.GetEnterpriseDrillThroughReportBySearch_Centre(searchRequest);
                else
                {
                    EnterpriseDrillThroughReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EnterpriseDrillThroughReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EnterpriseDrillThroughReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EnterpriseDrillThroughReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EnterpriseDrillThroughReportCollection;
        }
        public IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Department(EnterpriseDrillThroughReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> EnterpriseDrillThroughReportCollection = new BaseEntityCollectionResponse<EnterpriseDrillThroughReport>();
            try
            {
                if (_EnterpriseDrillThroughReportDataProvider != null)
                    EnterpriseDrillThroughReportCollection = _EnterpriseDrillThroughReportDataProvider.GetEnterpriseDrillThroughReportBySearch_Department(searchRequest);
                else
                {
                    EnterpriseDrillThroughReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EnterpriseDrillThroughReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EnterpriseDrillThroughReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EnterpriseDrillThroughReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EnterpriseDrillThroughReportCollection;
        }
        public IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> GetEnterpriseDrillThroughReportBySearch_Employee(EnterpriseDrillThroughReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> EnterpriseDrillThroughReportCollection = new BaseEntityCollectionResponse<EnterpriseDrillThroughReport>();
            try
            {
                if (_EnterpriseDrillThroughReportDataProvider != null)
                    EnterpriseDrillThroughReportCollection = _EnterpriseDrillThroughReportDataProvider.GetEnterpriseDrillThroughReportBySearch_Employee(searchRequest);
                else
                {
                    EnterpriseDrillThroughReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EnterpriseDrillThroughReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EnterpriseDrillThroughReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EnterpriseDrillThroughReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EnterpriseDrillThroughReportCollection;
        }
    }
}
