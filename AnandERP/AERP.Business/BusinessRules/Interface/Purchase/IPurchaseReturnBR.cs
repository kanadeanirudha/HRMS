

using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IPurchaseReturnBR
    {
        IValidateBusinessRuleResponse InsertPurchaseReturnValidate(PurchaseReturn item);
        IValidateBusinessRuleResponse UpdatePurchaseReturnValidate(PurchaseReturn item);
        IValidateBusinessRuleResponse DeletePurchaseReturnValidate(PurchaseReturn item);
    }
}
