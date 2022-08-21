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
    public class SaleContractDashboardReportBA : ISaleContractDashboardReportBA
    {
        ISaleContractDashboardReportDataProvider _SaleContractDashboardReportDataProvider;
        private ILogger _logException;

        public SaleContractDashboardReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractDashboardReportDataProvider = new SaleContractDashboardReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractDashboardReport> GetSaleContractMonthlySaleReportList(SaleContractDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractDashboardReport> SaleContractDashboardReportCollection = new BaseEntityCollectionResponse<SaleContractDashboardReport>();
            try
            {
                if (_SaleContractDashboardReportDataProvider != null)
                    SaleContractDashboardReportCollection = _SaleContractDashboardReportDataProvider.GetSaleContractMonthlySaleReportList(searchRequest);
                else
                {
                    SaleContractDashboardReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractDashboardReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractDashboardReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractDashboardReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractDashboardReportCollection;
        }

        public IBaseEntityResponse<SaleContractDashboardReport> SaleContractDashboardSparklineChartsReportByEmployeeID(SaleContractDashboardReport item)
        {
            IBaseEntityResponse<SaleContractDashboardReport> entityResponse = new BaseEntityResponse<SaleContractDashboardReport>();
            try
            {
                if (_SaleContractDashboardReportDataProvider!= null)
                {
                    entityResponse = _SaleContractDashboardReportDataProvider.SaleContractDashboardSparklineChartsReportByEmployeeID(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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