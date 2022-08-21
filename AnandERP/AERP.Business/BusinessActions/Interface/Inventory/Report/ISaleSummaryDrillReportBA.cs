using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface ISaleSummaryDrillReportBA
    {
        IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_YearList(SaleSummaryDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_MonthList(SaleSummaryDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_DayList(SaleSummaryDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_BillList(SaleSummaryDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemList(SaleSummaryDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemListSaleReturn(SaleSummaryDrillReportSearchRequest searchRequest); 
    }
}
