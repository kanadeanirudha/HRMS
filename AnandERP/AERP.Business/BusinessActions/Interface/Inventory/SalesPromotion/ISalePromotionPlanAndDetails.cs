
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ISalePromotionPlanAndDetailsBA
    {
        IBaseEntityResponse<SalePromotionPlanAndDetails> InsertSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item);
        IBaseEntityResponse<SalePromotionPlanAndDetails> InsertSalePromotionPlan(SalePromotionPlanAndDetails item);
        IBaseEntityResponse<SalePromotionPlanAndDetails> UpdateSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item);
        IBaseEntityResponse<SalePromotionPlanAndDetails> DeleteSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetBySearch(SalePromotionPlanAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetSalePromotionPlanAndDetailsSearchList(SalePromotionPlanAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalePromotionPlanAndDetails> SelectByID(SalePromotionPlanAndDetails item);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetPlanDescriptionByPlanCode(SalePromotionPlanAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetDiscountInPercentLIst(SalePromotionPlanAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetBillAmountrangeForGiftVoucher(SalePromotionPlanAndDetailsSearchRequest searchRequest);

    }
}

