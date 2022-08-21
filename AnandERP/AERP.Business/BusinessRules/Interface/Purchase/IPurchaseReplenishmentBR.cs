using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IPurchaseReplenishmentBR
    {
        IValidateBusinessRuleResponse InsertPurchaseReplenishmentValidate(PurchaseReplenishment item);
        IValidateBusinessRuleResponse UpdatePurchaseReplenishmentValidate(PurchaseReplenishment item);
        IValidateBusinessRuleResponse DeletePurchaseReplenishmentValidate(PurchaseReplenishment item);
    }
}
