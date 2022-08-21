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

namespace AERP.Business.BusinessActions
{
  public  class CCRMCallLogReportBA :ICCRMCallLogReportBA
    {
        ICCRMCallLogReportDataProvider _CCRMCallLogReportDataProvider;
        private ILogger _logException;
        public CCRMCallLogReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CCRMCallLogReportDataProvider = new CCRMCallLogReportDataProvider();
        }
        public IBaseEntityCollectionResponse<CCRMCallLogReport> GetCCRMCallLogReportBySearch(CCRMCallLogReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallLogReport> CCRMCallLogReportCollection = new BaseEntityCollectionResponse<CCRMCallLogReport>();
            try
            {
                if (_CCRMCallLogReportDataProvider != null)
                    CCRMCallLogReportCollection = _CCRMCallLogReportDataProvider.GetCCRMCallLogReportBySearch(searchRequest);
                else
                {
                    CCRMCallLogReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMCallLogReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMCallLogReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMCallLogReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMCallLogReportCollection;
        }
    }
}
