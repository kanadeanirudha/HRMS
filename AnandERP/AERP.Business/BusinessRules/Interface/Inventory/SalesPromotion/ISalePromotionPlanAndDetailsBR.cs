using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface ISalePromotionPlanAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertSalePromotionPlanValidate(SalePromotionPlanAndDetails item);
        IValidateBusinessRuleResponse InsertSalePromotionPlanAndDetailsValidate(SalePromotionPlanAndDetails item);
        IValidateBusinessRuleResponse UpdateSalePromotionPlanAndDetailsValidate(SalePromotionPlanAndDetails item);
        IValidateBusinessRuleResponse DeleteSalePromotionPlanAndDetailsValidate(SalePromotionPlanAndDetails item);
    }
}
