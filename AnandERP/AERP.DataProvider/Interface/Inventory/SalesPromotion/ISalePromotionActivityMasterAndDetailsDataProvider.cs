using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ISalePromotionActivityMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeleteSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeletePromotionActivityDiscounteItemList(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetailsRules(SalePromotionActivityMasterAndDetails item);

        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertItemDetails(SalePromotionActivityMasterAndDetails item);

        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsBySearch(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsByID(SalePromotionActivityMasterAndDetails item);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetPlanForFixedAmount(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetItemList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetFixAmountDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetConcessionfreeItemsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemFreeConcessionTypeList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetails item);

        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
    }
}
