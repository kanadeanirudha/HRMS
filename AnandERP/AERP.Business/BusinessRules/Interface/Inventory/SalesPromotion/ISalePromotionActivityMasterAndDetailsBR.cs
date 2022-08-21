using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface ISalePromotionActivityMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertSalePromotionActivityMasterAndDetailsValidate(SalePromotionActivityMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateSalePromotionActivityMasterAndDetailsValidate(SalePromotionActivityMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteSalePromotionActivityMasterAndDetailsValidate(SalePromotionActivityMasterAndDetails item);
        IValidateBusinessRuleResponse DeletePromotionActivityDiscounteItemListValidate(SalePromotionActivityMasterAndDetails item);
        IValidateBusinessRuleResponse InsertSalePromotionActivityMasterAndDetailsRulesValidate(SalePromotionActivityMasterAndDetails item);
        IValidateBusinessRuleResponse InsertItemDetailsValidate(SalePromotionActivityMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateSelectedItemOfConcessionTypeValidate(SalePromotionActivityMasterAndDetails item);
        IValidateBusinessRuleResponse InsertSalePromotionGiftVocherDetailsValidate(SalePromotionActivityMasterAndDetails item);


    }
}
