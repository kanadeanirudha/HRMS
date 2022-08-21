using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ISalePromotionPlanAndDetailsDataProvider
    {
        IBaseEntityResponse<SalePromotionPlanAndDetails> InsertSalePromotionPlan(SalePromotionPlanAndDetails item);
        IBaseEntityResponse<SalePromotionPlanAndDetails> InsertSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item);
        IBaseEntityResponse<SalePromotionPlanAndDetails> UpdateSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item);
        IBaseEntityResponse<SalePromotionPlanAndDetails> DeleteSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetSalePromotionPlanAndDetailsBySearch(SalePromotionPlanAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetSalePromotionPlanAndDetailsSearchList(SalePromotionPlanAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalePromotionPlanAndDetails> GetSalePromotionPlanAndDetailsByID(SalePromotionPlanAndDetails item);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetPlanDescriptionByPlanCode(SalePromotionPlanAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetDiscountInPercentLIst(SalePromotionPlanAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetBillAmountrangeForGiftVoucher(SalePromotionPlanAndDetailsSearchRequest searchRequest);
    }
}
