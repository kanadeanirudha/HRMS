using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IRetailSalesAndMarginDrillDownReportBA
    {
        IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> GetRetailSalesAndMarginDrillDownReportBySearch(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_GroupDescriptionList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseDepartmentList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseSubCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseBaseCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_ItemDescriptionList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_StoreList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest);

    }
}
