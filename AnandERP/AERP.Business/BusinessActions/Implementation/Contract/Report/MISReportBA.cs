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
    public class MISReportBA : IMISReportBA
    {
        IMISReportDataProvider _MISReportDataProvider;
        private ILogger _logException;

        public MISReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _MISReportDataProvider = new MISReportDataProvider();
        }

        public IBaseEntityCollectionResponse<MISReport> GetMISReportDataList(MISReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<MISReport> MISReportCollection = new BaseEntityCollectionResponse<MISReport>();
            try
            {
                if (_MISReportDataProvider != null)
                    MISReportCollection = _MISReportDataProvider.GetMISReportDataList(searchRequest);
                else
                {
                    MISReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    MISReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                MISReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                MISReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return MISReportCollection;
        }


    }
}