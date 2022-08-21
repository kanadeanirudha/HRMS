using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IPurchaseReportBR
    {
        IValidateBusinessRuleResponse InsertPurchaseReportValidate(PurchaseReport item);
        IValidateBusinessRuleResponse UpdatePurchaseReportValidate(PurchaseReport item);
        IValidateBusinessRuleResponse DeletePurchaseReportValidate(PurchaseReport item);
    }
}
