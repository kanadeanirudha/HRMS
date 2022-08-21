using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IPurchaseOrderMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertPurchaseOrderMasterAndDetailsValidate(PurchaseOrderMasterAndDetails item);
        IValidateBusinessRuleResponse UpdatePurchaseOrderMasterAndDetailsValidate(PurchaseOrderMasterAndDetails item);
        IValidateBusinessRuleResponse DeletePurchaseOrderMasterAndDetailsValidate(PurchaseOrderMasterAndDetails item);
    }
}
