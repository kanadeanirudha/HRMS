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
   public class CCRMMIFReportBA :ICCRMMIFReportBA
    {

        ICCRMMIFReportDataProvider _CCRMMIFReportDataProvider;
        private ILogger _logException;
        public CCRMMIFReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CCRMMIFReportDataProvider = new CCRMMIFReportDataProvider();
        }
        public IBaseEntityCollectionResponse<CCRMMIFReport> GetCCRMMIFReportBySearch(CCRMMIFReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFReport> CCRMMIFReportCollection = new BaseEntityCollectionResponse<CCRMMIFReport>();
            try
            {
                if (_CCRMMIFReportDataProvider != null)
                    CCRMMIFReportCollection = _CCRMMIFReportDataProvider.GetCCRMMIFReportBySearch(searchRequest);
                else
                {
                    CCRMMIFReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMMIFReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMMIFReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMMIFReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMMIFReportCollection;
        }
    }
}

