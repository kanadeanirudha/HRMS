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
    public class SalesRegisterReportBA : ISalesRegisterReportBA
    {
        ISalesRegisterReportDataProvider _SalesRegisterReportDataProvider;
        private ILogger _logException;

        public SalesRegisterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalesRegisterReportDataProvider = new SalesRegisterReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SalesRegisterReport> GetSalesRegisterReportList(SalesRegisterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesRegisterReport> SalesRegisterReportCollection = new BaseEntityCollectionResponse<SalesRegisterReport>();
            try
            {
                if (_SalesRegisterReportDataProvider != null)
                    SalesRegisterReportCollection = _SalesRegisterReportDataProvider.GetSalesRegisterReportList(searchRequest);
                else
                {
                    SalesRegisterReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesRegisterReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesRegisterReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesRegisterReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesRegisterReportCollection;
        }
       
    }
}