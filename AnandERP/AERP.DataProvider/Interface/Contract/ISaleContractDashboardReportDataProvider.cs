using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractDashboardReportDataProvider
    {
        IBaseEntityCollectionResponse<SaleContractDashboardReport> GetSaleContractMonthlySaleReportList(SaleContractDashboardReportSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractDashboardReport> SaleContractDashboardSparklineChartsReportByEmployeeID(SaleContractDashboardReport item);
    }
}
