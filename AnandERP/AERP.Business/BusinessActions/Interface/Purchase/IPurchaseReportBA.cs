using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IPurchaseReportBA
    {
        //PurchaseReport
        IBaseEntityCollectionResponse<PurchaseReport> GetTopFiveVendorReport(PurchaseReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyPurchaseReport(PurchaseReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReport> GetRequisitionConversionReport(PurchaseReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReport> GetPurchaseOrderConversionReport(PurchaseReportSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseReport> PurchaseReportSparkLineChartReportByEmployeeID(PurchaseReport item);

        IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyPurchaseOrderDetails(PurchaseReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyMarginDetails(PurchaseReportSearchRequest searchRequest);
    }
}
