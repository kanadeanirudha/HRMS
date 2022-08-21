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
    public class GrossOperatingProfitReportBA : IGrossOperatingProfitReportBA
    {
        IGrossOperatingProfitReportDataProvider _GrossOperatingProfitReportDataProvider;
        private ILogger _logException;

        public GrossOperatingProfitReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GrossOperatingProfitReportDataProvider = new GrossOperatingProfitReportDataProvider();
        }

        public IBaseEntityCollectionResponse<GrossOperatingProfitReport> GetGrossOperatingProfitReportDataList(GrossOperatingProfitReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GrossOperatingProfitReport> GrossOperatingProfitReportCollection = new BaseEntityCollectionResponse<GrossOperatingProfitReport>();
            try
            {
                if (_GrossOperatingProfitReportDataProvider != null)
                    GrossOperatingProfitReportCollection = _GrossOperatingProfitReportDataProvider.GetGrossOperatingProfitReportDataList(searchRequest);
                else
                {
                    GrossOperatingProfitReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GrossOperatingProfitReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GrossOperatingProfitReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GrossOperatingProfitReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GrossOperatingProfitReportCollection;
        }


    }
}