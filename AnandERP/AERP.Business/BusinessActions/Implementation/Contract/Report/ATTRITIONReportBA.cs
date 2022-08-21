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
    public class ATTRITIONReportBA : IATTRITIONReportBA
    {
        IATTRITIONReportDataProvider _ATTRITIONReportDataProvider;
        private ILogger _logException;

        public ATTRITIONReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _ATTRITIONReportDataProvider = new ATTRITIONReportDataProvider();
        }

        public IBaseEntityCollectionResponse<ATTRITIONReport> GetATTRITIONReportDataList(ATTRITIONReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ATTRITIONReport> ATTRITIONReportCollection = new BaseEntityCollectionResponse<ATTRITIONReport>();
            try
            {
                if (_ATTRITIONReportDataProvider != null)
                    ATTRITIONReportCollection = _ATTRITIONReportDataProvider.GetATTRITIONReportDataList(searchRequest);
                else
                {
                    ATTRITIONReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ATTRITIONReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ATTRITIONReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ATTRITIONReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ATTRITIONReportCollection;
        }


    }
}