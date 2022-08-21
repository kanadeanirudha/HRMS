using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ISalePromotionActivityMasterAndDetailsBA
    {
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeleteSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeletePromotionActivityDiscounteItemList(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetailsRules(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertItemDetails(SalePromotionActivityMasterAndDetails item);

        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetBySearch(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetItemList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetFixAmountDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> SelectByID(SalePromotionActivityMasterAndDetails item);

        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetPlanForFixedAmount(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetConcessionfreeItemsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemFreeConcessionTypeList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetails item);
        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetails item);
        IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest);

    }
}

