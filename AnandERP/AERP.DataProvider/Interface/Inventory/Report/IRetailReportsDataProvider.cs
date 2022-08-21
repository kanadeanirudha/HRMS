using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IRetailReportsDataProvider
    {
        IBaseEntityCollectionResponse<RetailReports> GetRetailReportsBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetInventoryDaysOfCoverReportBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetInventoryBillDetailReportBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetInventoryCounterDetailReportBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetRetailSalesAndMarginReportsBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetVendorServiceLevelBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetInventoryStockGapAnalysisReportBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetInventoryDiscountReportBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetRetailReportsBySearch_GetDinningReportList(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetConsumptionDetailReportBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch_DateWise(RetailReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch_OrderNoWise(RetailReportsSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<RetailReports> GetInventoryCurrentStockAmount(RetailReportsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<RetailReports> GetVendorWiseSaleAndPurchaseReport(RetailReportsSearchRequest searchRequest);
    }
}
