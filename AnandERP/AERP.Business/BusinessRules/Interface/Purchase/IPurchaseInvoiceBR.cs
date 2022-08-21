using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IPurchaseInvoiceBR
    {
        IValidateBusinessRuleResponse InsertPurchaseInvoiceValidate(PurchaseInvoice item);
        IValidateBusinessRuleResponse UpdatePurchaseInvoiceValidate(PurchaseInvoice item);
        IValidateBusinessRuleResponse DeletePurchaseInvoiceValidate(PurchaseInvoice item);
    }
}
